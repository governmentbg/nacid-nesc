using Microsoft.EntityFrameworkCore;
using StudentCard.Application.Students.Dtos.PersonLotDtos;
using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonBasicDtos;
using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonDoctoralDtos;
using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonStudentDtos;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Application.Users.Models;
using StudentCard.Data.Nomenclatures.Constants;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Students;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Helpers.Dtos;
using StudentCard.Infrastructure.Helpers.Extensions;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Students
{
	public class StudentService : IStudentService
	{
		private readonly IAppDbContext context;
		private readonly IRdpzsdDbContext rdpzsdContext;
		private readonly IUserService userService;
		private readonly ILoggingService loggingService;
		private readonly IUserContext userContext;
		private readonly DomainValidationService validation;

		public StudentService(
			IAppDbContext context,
			IRdpzsdDbContext rdpzsdContext,
			IUserService userService,
			ILoggingService loggingService,
			IUserContext userContext,
			DomainValidationService validation
			)
		{
			this.context = context;
			this.rdpzsdContext = rdpzsdContext;
			this.userService = userService;
			this.loggingService = loggingService;
			this.userContext = userContext;
			this.validation = validation;
		}

		public async Task CreateStudents(int limit, CancellationToken cancellationToken)
		{
			var requestedStudents = await this.GetRequestedStudents(limit);

			var successfullyCreatedStudents = new List<string>();

			foreach (var student in requestedStudents)
			{
				if (string.IsNullOrWhiteSpace(student.Email))
				{
					var existingStudent = await this.rdpzsdContext.Set<PersonLot>()
						.SingleOrDefaultAsync(s => s.Uan == student.UAN, cancellationToken);

					existingStudent.StudentCardStatus = StudentCardStatus.NoEmail;
					await this.rdpzsdContext.SaveChangesAsync(cancellationToken);

					continue;
				}

				var exist = await this.context.Set<Student>()
					.AnyAsync(s => s.UAN == student.UAN, cancellationToken);
				if (exist)
				{
					await this.loggingService.LogMessageAsync($"Student with Uan {student.UAN} already has registration in the student card");

					var existingStudent = await this.rdpzsdContext.Set<PersonLot>()
						.SingleOrDefaultAsync(s => s.Uan == student.UAN, cancellationToken);

					existingStudent.StudentCardStatus = StudentCardStatus.Created;
					await this.rdpzsdContext.SaveChangesAsync(cancellationToken);

					continue;
				}

				var isTaken = await this.context.Set<Student>()
					.AnyAsync(s => s.Email.Trim().ToLower() == student.Email.Trim().ToLower(), cancellationToken);
				if (isTaken)
				{
					await this.loggingService.LogMessageAsync($"Email {student.Email} is taken!");

					continue;
				}

				student.AddUser(student.Email);
				await this.context.Set<Student>().AddAsync(student, cancellationToken);
				await this.context.SaveChangesAsync(cancellationToken);

				if (student.Id != 0)
				{
					successfullyCreatedStudents.Add(student.UAN);
					await this.userService.SendEmail(student.Id, EmailTypeAlias.USER_ACTIVATION, student.Email, cancellationToken);
				}
				else
				{
					await this.loggingService.LogMessageAsync($"Student with Uan {student.UAN} not registered in the student card");

					var existingStudent = await this.rdpzsdContext.Set<PersonLot>()
						.SingleOrDefaultAsync(s => s.Uan == student.UAN, cancellationToken);

					existingStudent.StudentCardStatus = StudentCardStatus.NotCreated;
					await this.rdpzsdContext.SaveChangesAsync(cancellationToken);
				}
			}

			await this.ChangeRequestedStudentsStatus(successfullyCreatedStudents);
		}

		public async Task<PersonLotDto> GetStudentByUan(CancellationToken cancellationToken)
		{
			var loggedInStudent = await this.GetLoggedInStudent();

			var student = await this.rdpzsdContext.Set<PersonLot>()
				.Where(s => s.Uan == loggedInStudent.UAN)
				.Select(personLot => new PersonLotDto
				{
					Uan = personLot.Uan,
					State = personLot.State,
					CreateDate = personLot.CreateDate,
					PersonBasicDto = new PersonBasicDto
					{
						FirstName = personLot.PersonBasic.FirstName,
						MiddleName = personLot.PersonBasic.MiddleName,
						LastName = personLot.PersonBasic.LastName,
						OtherNames = personLot.PersonBasic.OtherNames,
						FirstNameAlt = personLot.PersonBasic.FirstNameAlt,
						MiddleNameAlt = personLot.PersonBasic.MiddleNameAlt,
						LastNameAlt = personLot.PersonBasic.LastNameAlt,
						OtherNamesAlt = personLot.PersonBasic.OtherNamesAlt,
						Uin = personLot.PersonBasic.Uin,
						ForeignerNumber = personLot.PersonBasic.ForeignerNumber,
						IdnNumber = personLot.PersonBasic.IdnNumber,
						Email = personLot.PersonBasic.Email,
						PhoneNumber = personLot.PersonBasic.PhoneNumber != "9999999999"
						 ? personLot.PersonBasic.PhoneNumber
						 : "",
						PostCode = personLot.PersonBasic.PostCode,
						Gender = personLot.PersonBasic.Gender,
						BirthDate = personLot.PersonBasic.BirthDate,
						BirthCountry = personLot.PersonBasic.BirthCountry.ToNomenclatureCodeDto(),
						BirthDistrict = personLot.PersonBasic.BirthDistrict.ToNomenclatureCodeDto(),
						BirthMunicipality = personLot.PersonBasic.BirthMunicipality.ToNomenclatureCodeDto(),
						BirthSettlement = personLot.PersonBasic.BirthSettlement.ToNomenclatureCodeDto(),
						ForeignerBirthSettlement = personLot.PersonBasic.ForeignerBirthSettlement,
						Citizenship = personLot.PersonBasic.Citizenship.ToNomenclatureDto(),
						SecondCitizenship = personLot.PersonBasic.SecondCitizenship.ToNomenclatureDto(),
						CitizenshipFull = CombineStrings(personLot.PersonBasic.Citizenship.Name, personLot.PersonBasic.SecondCitizenship.Name),
						CitizenshipFullAlt = CombineStrings(personLot.PersonBasic.Citizenship.NameAlt, personLot.PersonBasic.SecondCitizenship.NameAlt),
						ResidenceCountry = personLot.PersonBasic.ResidenceCountry.ToNomenclatureCodeDto(),
						ResidenceDistrict = personLot.PersonBasic.ResidenceDistrict.ToNomenclatureCodeDto(),
						ResidenceMunicipality = personLot.PersonBasic.ResidenceMunicipality.ToNomenclatureCodeDto(),
						ResidenceSettlement = personLot.PersonBasic.ResidenceSettlement.ToNomenclatureCodeDto(),
						ResidenceAddress = personLot.PersonBasic.ResidenceAddress,
						ResidenceSettlementAndPostCode = CombineStrings(personLot.PersonBasic.ResidenceSettlement.Name, personLot.PersonBasic.PostCode != null ? $"п.к. {personLot.PersonBasic.PostCode}" : null),
						ResidenceSettlementAndPostCodeAlt = CombineStrings(personLot.PersonBasic.ResidenceSettlement.NameAlt, personLot.PersonBasic.PostCode != null ? $"p.c. {personLot.PersonBasic.PostCode}" : null),
						PersonImage = personLot.PersonBasic.PersonImage != null
						 ? new PersonImage
						 {
							 Hash = personLot.PersonBasic.PersonImage.Hash,
							 Key = personLot.PersonBasic.PersonImage.Key,
							 Name = personLot.PersonBasic.PersonImage.Name,
							 MimeType = personLot.PersonBasic.PersonImage.MimeType,
							 Size = personLot.PersonBasic.PersonImage.Size,
							 DbId = personLot.PersonBasic.PersonImage.DbId
						 }
						 : null
					},
					//PersonSecondaryDto = new PersonSecondaryDto
					//{
					//	GraduationYear = personLot.PersonSecondary.GraduationYear,
					//	Country = personLot.PersonSecondary.Country.ToNomenclatureDto(),
					//	School = personLot.PersonSecondary.School.ToNomenclatureDto(),
					//	SchoolSettlement = personLot.PersonSecondary.School.Settlement.ToNomenclatureDto(),
					//	ForeignSchoolName = personLot.PersonSecondary.ForeignSchoolName,
					//	Profession = personLot.PersonSecondary.Profession,
					//	DiplomaNumber = personLot.PersonSecondary.DiplomaNumber,
					//	DiplomaDate = personLot.PersonSecondary.DiplomaDate,
					//},
					PersonStudentsDto = personLot.PersonStudents.Select(ps => new PersonStudentDto
					{
						FacultyNumber = ps.FacultyNumber,
						Qualification = ps.Qualification,
						School = personLot.PersonSecondary != null 
						? personLot.PersonSecondary.School.ToNomenclatureDto()
						: null,
						SchoolSettlement = personLot.PersonSecondary != null 
						? personLot.PersonSecondary.School.Settlement.ToNomenclatureDto()
						: null,
						Institution = ps.Institution != null
						? new InstitutionDto
						{
							Name = ps.Institution.Name,
							NameAlt = ps.Institution.NameAlt,
							ShortName = ps.Institution.ShortName,
							ShortNameAlt = ps.Institution.ShortNameAlt
						}
						: null,
						Subordinate = ps.Subordinate.ToNomenclatureDto(),
						Speciality = ps.InstitutionSpeciality.Speciality.ToNomenclatureDto(),
						AdmissionReason = ps.AdmissionReason.ToNomenclatureDto(),
						Duration = ps.InstitutionSpeciality.Duration,
						EducationalForm = ps.InstitutionSpeciality.EducationalForm.ToNomenclatureDto(),
						EducationalQualification = ps.InstitutionSpeciality.Speciality.EducationalQualification.ToNomenclatureDto(),
						Semesters = ps.Semesters.Select(s => new StudentSemesterDto
						{
							Id = s.Id,
							StudentStatus = s.StudentStatus != null
								? new StudentStatusDto
								{
									Alias = s.StudentStatus.Alias,
									Name = s.StudentStatus.Name,
									NameAlt = s.StudentStatus.NameAlt
								}
								: null,
							StudentEvent = s.StudentEvent.ToNomenclatureDto(),
							EducationFeeType = s.EducationFeeType.ToNomenclatureDto(),
							Period = new PeriodDto
                            {
								Name = s.Period.Name,
								NameAlt = s.Period.NameAlt,
								Alias = s.Period.Alias,
								Year = s.Period.Year,
								Semester = s.Period.Semester
							},
							Course = s.Course,
							Semester = s.StudentSemester
						}).OrderByDescending(e => e.Period.Year)
						  .ThenByDescending(e => e.Period.Semester)
						  .ThenByDescending(e => e.Id)
						  .ToList(),
						PeType = ps.PeType,
						PeHighSchoolType = ps.PeHighSchoolType,
						PeDiplomaNumber = ps.PeDiplomaNumber,
						PeDiplomaDate = ps.PeDiplomaDate,
						PeResearchArea = ps.PeResearchArea != null
							? new ResearchAreaDto
							{
								Name = ps.PeResearchArea.Name,
								NameAlt = ps.PeResearchArea.NameAlt,
								Code = ps.PeResearchArea.Code
							}
							: null,
						PeEducationalQualification = ps.PeEducationalQualification.ToNomenclatureDto(),
						PeAcquiredForeignEducationalQualification = ps.PeAcquiredForeignEducationalQualification.ToNomenclatureDto(),
						PeInstitution = ps.PeInstitution.ToNomenclatureDto(),
						PeSubordinate = ps.PeSubordinate.ToNomenclatureDto(),
						PeSpeciality = ps.PeInstitutionSpeciality.Speciality.ToNomenclatureDto(),
						PeInstitutionName = ps.PeInstitutionName,
						PeSubordinateName = ps.PeSubordinateName,
						PeSpecialityName = ps.PeSpecialityName,
						PeCountry = ps.PeCountry.ToNomenclatureDto(),
						PeRecognizedSpeciality = ps.PeRecognizedSpeciality,
						PeAcquiredSpeciality = ps.PeAcquiredSpeciality,
						PeRecognitionNumber = ps.PeRecognitionNumber,
						PeRecognitionDate = ps.PeRecognitionDate,
						Diploma = ps.Diploma != null
						? new PersonStudentDiplomaDto
						{
							DiplomaNumber = ps.Diploma.DiplomaNumber,
							DiplomaDate = ps.Diploma.DiplomaDate,
							RegistrationDiplomaNumber = ps.Diploma.RegistrationDiplomaNumber,
							IsValid = ps.Diploma.IsValid,
							File = ps.Diploma.File
						}
						: null,
						StudentStatus = ps.StudentStatus.ToNomenclatureDto(),
						StudentEvent = ps.StudentEvent.ToNomenclatureDto()
					}).ToList(),
					PersonDoctoralsDto = personLot.PersonDoctorals.Select(pd => new PersonDoctoralDto
					{
						StartDate = pd.StartDate,
						//EndDate = pd.EndDate,
						PeRecognitionDocument = pd.PeRecognitionDocument,
						Institution = pd.Institution != null
						? new InstitutionDto
						{
							Name = pd.Institution.Name,
							NameAlt = pd.Institution.NameAlt,
							ShortName = pd.Institution.ShortName,
							ShortNameAlt = pd.Institution.ShortNameAlt
						}
						: null,
						Subordinate = pd.Subordinate.ToNomenclatureDto(),
						Speciality = pd.InstitutionSpeciality.Speciality.ToNomenclatureDto(),
						AdmissionReason = pd.AdmissionReason.ToNomenclatureDto(),
						Duration = pd.InstitutionSpeciality.Duration,
						EducationalForm = pd.InstitutionSpeciality.EducationalForm.ToNomenclatureDto(),
						EducationalQualification = pd.InstitutionSpeciality.Speciality.EducationalQualification.ToNomenclatureDto(),
						Semesters = pd.Semesters.Select(s => new DoctoralSemesterDto
						{
							Id = s.Id,
							StudentStatus = s.StudentStatus != null
								? new StudentStatusDto
								{
									Alias = s.StudentStatus.Alias,
									Name = s.StudentStatus.Name,
									NameAlt = s.StudentStatus.NameAlt
								}
								: null,
							StudentEvent = s.StudentEvent.ToNomenclatureDto(),
							EducationFeeType = s.EducationFeeType.ToNomenclatureDto(),
							ProtocolDate = s.ProtocolDate,
							ProtocolNumber = s.ProtocolNumber,
							YearType = s.YearType,
						}).OrderByDescending(s => s.ProtocolDate.Date)
					      .ThenByDescending(s => s.Id)
					      .ToList(),
						PeType = pd.PeType,
						PeHighSchoolType = pd.PeHighSchoolType,
						PeDiplomaNumber = pd.PeDiplomaNumber,
						PeDiplomaDate = pd.PeDiplomaDate,
						PeResearchArea = pd.PeResearchArea != null
							? new ResearchAreaDto
							{
								Name = pd.PeResearchArea.Name,
								NameAlt = pd.PeResearchArea.NameAlt,
								Code = pd.PeResearchArea.Code
							}
							: null,
						PeEducationalQualification = pd.PeEducationalQualification.ToNomenclatureDto(),
						PeAcquiredForeignEducationalQualification = pd.PeAcquiredForeignEducationalQualification.ToNomenclatureDto(),
						PeInstitution = pd.PeInstitution.ToNomenclatureDto(),
						PeSubordinate = pd.PeSubordinate.ToNomenclatureDto(),
						PeSpeciality = pd.PeInstitutionSpeciality.Speciality.ToNomenclatureDto(),
						PeInstitutionName = pd.PeInstitutionName,
						PeSubordinateName = pd.PeSubordinateName,
						PeSpecialityName = pd.PeSpecialityName,
						PeCountry = pd.PeCountry.ToNomenclatureDto(),
						PeRecognizedSpeciality = pd.PeRecognizedSpeciality,
						PeAcquiredSpeciality = pd.PeAcquiredSpeciality,
						PeRecognitionNumber = pd.PeRecognitionNumber,
						PeRecognitionDate = pd.PeRecognitionDate,
						StudentStatus = pd.StudentStatus.ToNomenclatureDto(),
						StudentEvent = pd.StudentEvent.ToNomenclatureDto()
					}).ToList()
				})
				.SingleOrDefaultAsync(cancellationToken);

			if (student == null)
			{
				this.validation.ThrowErrorMessage(StudentErrorCode.StudentNotFoundByUAN);
			}

			return student;
		}

		private async Task<List<Student>> GetRequestedStudents(int limit)
		{
			return await this.rdpzsdContext.Set<PersonLot>()
				.Where(s => s.StudentCardStatus == StudentCardStatus.Requested && s.PersonBasic.Email.Trim().ToLower() != "noemail")
				.Select(s => new Student
				{
					UAN = s.Uan,
					Email = s.PersonBasic.Email,
					ExternalId = s.Id,
					BirthDate = s.PersonBasic.BirthDate,
					Uin = s.PersonBasic.Uin
				})
				.Take(limit)
				.ToListAsync();
		}

		private async Task ChangeRequestedStudentsStatus(List<string> studentsUan)
		{
			var studentsToUpdate = await this.rdpzsdContext.Set<PersonLot>()
				.Where(s => studentsUan.Contains(s.Uan))
				.ToListAsync();

			studentsToUpdate.ForEach(s => s.StudentCardStatus = StudentCardStatus.Created);

			await this.rdpzsdContext.SaveChangesAsync();
		}

		private static string CombineStrings(params string[] values)
		{
			return string.Join(", ", values.Where(e => !string.IsNullOrWhiteSpace(e)));
		}

		public async Task<Student> GetLoggedInStudent()
		{
			return await this.context.Set<Student>()
				.Where(s => s.Id == this.userContext.UserId)
				.SingleOrDefaultAsync();
		}

		public async Task ValidateRequestedDiplomaAccess(Guid key)
		{
			var loggedInStudent = await this.GetLoggedInStudent();

			var hasAccessToDiploma = await this.rdpzsdContext.Set<PersonLot>()
				.AnyAsync(x => x.Uan == loggedInStudent.UAN && x.PersonStudents.Any(ps => ps.Diploma.File.Key == key));

			if (!hasAccessToDiploma)
			{
				this.validation.ThrowErrorMessage(StudentErrorCode.NotAccessForRequestedDiploma);
			}
		}
    }
}
