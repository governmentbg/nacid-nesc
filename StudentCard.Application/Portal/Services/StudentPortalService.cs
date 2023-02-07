using Microsoft.EntityFrameworkCore;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Infrastructure.Helpers.Dtos;
using StudentCard.Infrastructure.Helpers.Extensions;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileStorageNetCore.Models;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Application.Portal.Interfaces;
using StudentCard.Application.Portal.Dtos;

namespace StudentCard.Application.Portal.Services
{
	public class StudentPortalService : IStudentPortalService
	{
		private readonly IRdpzsdDbContext rdpzsdContext;
		private readonly DomainValidationService validation;

		public StudentPortalService(
			IRdpzsdDbContext rdpzsdContext,
			DomainValidationService validation
			)
		{
			this.rdpzsdContext = rdpzsdContext;
			this.validation = validation;
		}

		public async Task<StudentPortalBasicDto> GetStudentPortalBasicByUan(string uan, CancellationToken cancellationToken)
		{
			var student = await this.rdpzsdContext.Set<PersonLot>()
			   .Where(s => s.Uan == uan)
			   .Select(personLot => new StudentPortalBasicDto
			   {
				   FullName = personLot.PersonBasic.FullName,
				   FullNameAlt = personLot.PersonBasic.FullNameAlt,
				   Uan = personLot.Uan,
				   BirthDate = personLot.PersonBasic.BirthDate,
				   ImgFile = personLot.PersonBasic.PersonImage != null
				   ? new AttachedFile
				   {
					   Hash = personLot.PersonBasic.PersonImage.Hash,
					   Key = personLot.PersonBasic.PersonImage.Key,
					   Name = personLot.PersonBasic.PersonImage.Name,
					   MimeType = personLot.PersonBasic.PersonImage.MimeType,
					   Size = personLot.PersonBasic.PersonImage.Size,
					   DbId = personLot.PersonBasic.PersonImage.DbId
				   }
				   : null,
				   Universities = personLot.PersonStudents
					   .Select(ps => new EducationBasicDto
					   {
						   Id = ps.Id,
						   Institution = ps.Institution != null
							   ? new InstitutionDto
							   {
								   Name = ps.Institution.Name,
								   NameAlt = ps.Institution.NameAlt,
								   ShortName = ps.Institution.ShortName,
								   ShortNameAlt = ps.Institution.ShortNameAlt
							   }
							   : null,
						   Speciality = ps.InstitutionSpeciality.Speciality.ToNomenclatureDto(),
						   EducationalQualification = ps.InstitutionSpeciality.Speciality.EducationalQualification.ToNomenclatureDto(),
						   EducationalForm = ps.InstitutionSpeciality.EducationalForm.ToNomenclatureDto(),
						   Status = ps.StudentStatus != null
							   ? new StudentStatusDto
							   {
								   Name = ps.StudentStatus.Alias == "completed" ? "Недействащ" : ps.StudentStatus.Name,
								   NameAlt = ps.StudentStatus.NameAlt,
								   Alias = ps.StudentStatus.Alias,
							   }
							   : null
					   })
					   .OrderByDescending(ps => ps.Id).ToList(),
				   Doctorals = personLot.PersonDoctorals
					   .Select(pd => new EducationBasicDto
					   {
						   Id = pd.Id,
						   Institution = pd.Institution != null
						   ? new InstitutionDto
						   {
							   Name = pd.Institution.Name,
							   NameAlt = pd.Institution.NameAlt,
							   ShortName = pd.Institution.ShortName,
							   ShortNameAlt = pd.Institution.ShortNameAlt
						   }
						   : null,
						   Speciality = pd.InstitutionSpeciality.Speciality.ToNomenclatureDto(),
						   EducationalQualification = pd.InstitutionSpeciality.Speciality.EducationalQualification.ToNomenclatureDto(),
						   EducationalForm = pd.InstitutionSpeciality.EducationalForm.ToNomenclatureDto(),
						   Status = pd.StudentStatus != null
							   ? new StudentStatusDto
							   {
								   Name = pd.StudentStatus.Alias == "completed" ? "Недействащ" : pd.StudentStatus.Name,
								   NameAlt = pd.StudentStatus.NameAlt,
								   Alias = pd.StudentStatus.Alias,
							   }
							   : null
					   })
					   .OrderByDescending(pd => pd.Id).ToList()
			   })
			   .SingleOrDefaultAsync(cancellationToken);

			if (student == null)
			{
				this.validation.ThrowErrorMessage(StudentErrorCode.StudentNotFoundByUAN);
			}

			return student;
		}
	}
}
