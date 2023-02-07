using Microsoft.EntityFrameworkCore;
using StudentCard.Application.Users.Enums;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Application.Users.Models;
using StudentCard.Data.Nomenclatures.Constants;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Students;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Logs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Users
{
	public class RegisterService : IRegisterService
	{
		private readonly IAppDbContext context;
		private readonly IRdpzsdDbContext rdpzsdDbContext;
		private readonly ILoggingService loggingService;
		private readonly IUserService userService;
		private readonly DomainValidationService validation;

		public RegisterService(
			IAppDbContext context,
			IRdpzsdDbContext rdpzsdDbContext,
			ILoggingService loggingService,
			IUserService userService,
			DomainValidationService validation)
		{
			this.context = context;
			this.validation = validation;
			this.loggingService = loggingService;
			this.userService = userService;
			this.rdpzsdDbContext = rdpzsdDbContext;
		}

		public async Task<string> Register(UserRegisterInfoDto model, CancellationToken cancellationToken)
		{
			var student = this.rdpzsdDbContext.Set<PersonLot>()
				.Where(s => s.State == LotState.Actual)
				.AsQueryable();

			switch (model.IdentificationType)
			{
				case RegisterIdentificationEnum.UIN:
					student = student.Where(s => s.PersonBasic.Uin == model.Identificator);
					break;
				case RegisterIdentificationEnum.ForeignerNumber:
					student = student.Where(s => s.PersonBasic.ForeignerNumber == model.Identificator);
					break;
				case RegisterIdentificationEnum.IDN:
					student = student.Where(s => s.PersonBasic.IdnNumber == model.Identificator);
					break;
				case RegisterIdentificationEnum.UAN:
					student = student.Where(s => s.Uan == model.Identificator);
					break;
				default:
					break;
			}

			var studentRegInfo = await student
				.Select(personLot => new RegisterInfoDto
				{
					HasActivePersonStudent = personLot.PersonStudents.Any(ps => ps.StudentStatus.Alias == "active"),
					HasActivePersonDoctoral = personLot.PersonDoctorals.Any(ps => ps.StudentStatus.Alias == "active"),
					Email = personLot.PersonBasic.Email,
					UAN = personLot.Uan,
					ExternalId = personLot.Id,
					BirthDate = personLot.PersonBasic.BirthDate,
					Uin = personLot.PersonBasic.Uin
				})
				.SingleOrDefaultAsync(cancellationToken);

			if (studentRegInfo == null)
			{
				await this.loggingService.LogMessageAsync($"Student with identificator {model.IdentificationType} - {model.Identificator} not found!");

				this.validation.ThrowErrorMessage(UserErrorCode.UserRegisterNotFoundWithGivenIdentificator);
			}

			if (studentRegInfo.HasActivePersonStudent == false && studentRegInfo.HasActivePersonDoctoral == false)
			{
				await this.loggingService.LogMessageAsync($"Student with Uan {studentRegInfo.UAN} has no active education!");

				this.validation.ThrowErrorMessage(UserErrorCode.UserRegisterNotActive);
			}

			if (studentRegInfo.Email == "NoEmail" || string.IsNullOrWhiteSpace(studentRegInfo.Email))
			{
				await this.loggingService.LogMessageAsync($"Student with email {model.Email} not found in Rdpzsd!");

				this.validation.ThrowErrorMessage(UserErrorCode.UserRegisterEmailNotFoundInRDPZSD);
			}

			if (studentRegInfo.Email != model.Email)
			{
				var email = studentRegInfo.Email;
				var maskedEmail = string.Format("{0}****{1}", email[0], email.Substring(email.IndexOf('@') - 1));

				return maskedEmail;
			}

			return await this.CreateStudent(studentRegInfo, cancellationToken);
		}

		private async Task<string> CreateStudent(RegisterInfoDto model, CancellationToken cancellationToken)
        {
			var exist = await this.context.Set<Student>()
				.AnyAsync(s => s.UAN == model.UAN, cancellationToken);

			if (exist)
			{
				await this.loggingService.LogMessageAsync($"Student with Uan {model.UAN} already has registration in the student card");

				var existingStudent = await this.rdpzsdDbContext.Set<PersonLot>()
					.SingleOrDefaultAsync(s => s.Uan == model.UAN, cancellationToken);

				existingStudent.StudentCardStatus = StudentCardStatus.Created;
				await this.rdpzsdDbContext.SaveChangesAsync(cancellationToken);

				this.validation.ThrowErrorMessage(UserErrorCode.UserAlreadyHasProfileWIthGivenUan);
			}

			var isTaken = await this.context.Set<Student>()
				.AnyAsync(s => s.Email.Trim().ToLower() == model.Email.Trim().ToLower(), cancellationToken);

			if (isTaken)
			{
				await this.loggingService.LogMessageAsync($"Email {model.Email} is taken!");

				this.validation.ThrowErrorMessage(UserErrorCode.UserEmailTaken);
			}

			var newStudent = new Student()
			{
				Email = model.Email,
				UAN = model.UAN,
				ExternalId = model.ExternalId,
				BirthDate = model.BirthDate,
				Uin = model.Uin
			};

			newStudent.AddUser(model.Email);
			await this.context.Set<Student>().AddAsync(newStudent, cancellationToken);
			await this.context.SaveChangesAsync(cancellationToken);

			if (newStudent.Id != 0)
			{
				await this.userService.SendEmail(newStudent.Id, EmailTypeAlias.USER_ACTIVATION, newStudent.Email, cancellationToken);

				await this.ChangeStudentsStatus(newStudent.UAN, StudentCardStatus.Created);
			}
			else
			{
				await this.loggingService.LogMessageAsync($"Student with Uan {newStudent.UAN} not registered in the student card");

				await this.ChangeStudentsStatus(newStudent.UAN, StudentCardStatus.NotCreated);
			}

			return null;
		}

		private async Task ChangeStudentsStatus(string UAN, StudentCardStatus status)
		{
			var existingStudent = await this.rdpzsdDbContext.Set<PersonLot>()
						.SingleOrDefaultAsync(s => s.Uan == UAN);

			existingStudent.StudentCardStatus = status;
			await this.rdpzsdDbContext.SaveChangesAsync();
		}
	}
}
