using Microsoft.EntityFrameworkCore;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Application.Users.Models;
using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Rdpzsd.Students.Parts.History;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System;
using System.Collections;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentCard.Application.Students
{
	public class RdpzsdService : IRdpzsdService
	{
		private readonly IRdpzsdDbContext rdpzsdContext;
        private readonly DomainValidationService validation;

        public RdpzsdService(IRdpzsdDbContext rdpzsdContext, DomainValidationService validation)
		{
			this.rdpzsdContext = rdpzsdContext;
            this.validation = validation;
		}

		public async Task UpdateStudentName(string uan, RegiXGRAOResponse dto)
		{
			var actualPart = await new PersonBasic().IncludeAll(rdpzsdContext.Set<PersonBasic>()
                        .AsQueryable())
						.Include(e => e.PartInfo)
						.SingleOrDefaultAsync(e => e.Lot.Uan == uan && e.State == PartState.Actual);

            var regixFullName = $"{dto.PersonNames.FirstName} {dto.PersonNames.SurName} {dto.PersonNames.FamilyName}";
            var regixFullNameAlt = $"{dto.LatinNames.FirstName} {dto.LatinNames.SurName} {dto.LatinNames.FamilyName}";

			if (regixFullName == actualPart.FullName && regixFullNameAlt == actualPart.FullNameAlt)
            {
                this.validation.ThrowErrorMessage(StudentErrorCode.NoDifferenceFoundInNames);
            }

            await this.CreatePersonBasicHistory(actualPart);

            await this.AddPersonLotAction(actualPart.Id, PersonLotActionType.PersonBasicEdit, "Промяна на имената на студент");

            actualPart.PartInfo = new PersonBasicInfo
            {
                ActionDate = DateTime.Now,
                UserFullname = "Промяна от студента през портал \"НЕСК\"",
                UserId = null
            };

            actualPart.FirstName = dto.PersonNames.FirstName;
            actualPart.FirstNameAlt = dto.LatinNames.FirstName;

            actualPart.MiddleName = dto.PersonNames.SurName;
            actualPart.MiddleNameAlt = dto.LatinNames.SurName;

            actualPart.LastName = dto.PersonNames.FamilyName;
            actualPart.LastNameAlt = dto.LatinNames.FamilyName;

            actualPart.FullName = regixFullName;
            actualPart.FullNameAlt = regixFullNameAlt;

            await this.rdpzsdContext.SaveChangesAsync();
        }

		public async Task UpdateEmail(string uan, string newEmail)
		{
			var actualPart = await new PersonBasic().IncludeAll(rdpzsdContext.Set<PersonBasic>()
						.AsQueryable())
						.Include(e => e.PartInfo)
						.SingleOrDefaultAsync(e => e.Lot.Uan == uan && e.State == PartState.Actual);
			
			await this.CreatePersonBasicHistory(actualPart);

			await this.AddPersonLotAction(actualPart.Id, PersonLotActionType.PersonBasicEdit, "Промяна на имейл адрес на студент");

			actualPart.PartInfo = new PersonBasicInfo
			{
				ActionDate = DateTime.Now,
				UserFullname = "Промяна от студента през портал \"НЕСК\"",
				UserId = null
			};

			actualPart.Email = newEmail;

			await this.rdpzsdContext.SaveChangesAsync();
		}

		private async Task CreatePersonBasicHistory(PersonBasic actualPart)
        {
            var partHistory = Activator.CreateInstance(typeof(PersonBasicHistory)) as PersonBasicHistory;
            CloneProperties(actualPart, partHistory);
            partHistory.PartId = actualPart.Id;
            await this.rdpzsdContext.Set<PersonBasicHistory>().AddAsync(partHistory);
        }

        private async Task AddPersonLotAction(int lotId, PersonLotActionType actionType, string note)
		{
            var newPersonLotAction = new PersonLotAction
            {
                ActionDate = DateTime.Now,
                ActionType = actionType,
                InstitutionId = null,
                SubordinateId = null,
                LotId = lotId,
                Note = note,
                UserFullname = "Промяна през портал \"НЕСК\""
			};

            await this.rdpzsdContext.Set<PersonLotAction>().AddAsync(newPersonLotAction);
        }

        private static void CloneProperties(object originalEntity, object updateEntity)
        {
            var originalProperties = originalEntity.GetType().GetProperties(
                    BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.NonPublic);

            foreach (var originalProperty in originalProperties)
            {
                if (originalProperty.Name == "Id" || originalProperty.Name == "Version" || SkipAttribute.IsDeclared(originalProperty))
                {
                    continue;
                }

                PropertyInfo updateProperty = updateEntity.GetType().GetProperty(originalProperty.Name, BindingFlags.Public | BindingFlags.Instance);
                var value = originalProperty.GetValue(originalEntity, null);

                if (updateProperty != null && updateProperty.CanWrite && value != null)
                {
                    if (updateProperty.PropertyType.IsValueType
                            || updateProperty.PropertyType.IsEnum
                            || updateProperty.PropertyType.Equals(typeof(string)))
                    {
                        updateProperty.SetValue(updateEntity, value, null);
                    }
                    else if (value.GetType().GetInterface("IList", true) != null)
                    {
                        // No need to create instance, if there is initialization in constructor.
                        var updateCollection = updateProperty.GetValue(updateEntity);

                        foreach (var originalCollectionItem in (IEnumerable)value)
                        {
                            var updateCollectionItem = Activator.CreateInstance(updateProperty.PropertyType.GetGenericArguments()[0]);
                            CloneProperties(originalCollectionItem, updateCollectionItem);
                            ((IList)updateCollection).Add(updateCollectionItem);
                        }
                    }
                    else
                    {
                        if (updateProperty.PropertyType.IsClass && value != null)
                        {
                            var updateObject = updateProperty.GetValue(updateEntity);

                            if (updateObject == null)
                            {
                                updateObject = Activator.CreateInstance(updateProperty.PropertyType);
                            }

                            CloneProperties(value, updateObject);

                            updateProperty.SetValue(updateEntity, updateObject, null);
                        }
                    }
                }
            }
        }
    }
}
