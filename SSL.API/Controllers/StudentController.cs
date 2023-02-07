using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSL.API.Models;
using StudentCard.Data.HistoryLogs;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Infrastructure.Interfaces.Contexts;

namespace SSL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private const string URBAN_MOBILITY_CENTER = "Център за градска мобилност";
        private readonly IRdpzsdDbContext context;
        private readonly IAppDbContext appDbContext;

        public StudentController(IRdpzsdDbContext context, IAppDbContext appDbContext)
        {
            this.context = context;
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<SearchResult> GetStudent([FromQuery] SearchFilter filter, CancellationToken cancellationToken)
        {
            var students = this.context.Set<PersonLot>()
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(filter.Uan))
            {
                students = students.Where(s => s.Uan == filter.Uan);
            }

            if (!string.IsNullOrWhiteSpace(filter.Uin))
            {
                students = students.Where(s => s.PersonBasic.Uin == filter.Uin);
            }

            if (!string.IsNullOrWhiteSpace(filter.ForeignerNumber))
            {
                students = students.Where(s => s.PersonBasic.ForeignerNumber == filter.ForeignerNumber);
            }

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                students = students.Where(s => s.PersonBasic.Email == filter.Email);
            }

            var student = await students
                .Select(personLot => new SearchResult
                {
                    Uan = personLot.Uan,
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
                    Email = personLot.PersonBasic.Email,
                    BirthDate = personLot.PersonBasic.BirthDate,
                    Specialities = personLot.PersonStudents
                        .Select(s => new SearchResultSpecialities
                        {
                            Institution = s.Institution.Name,
                            Qualification = s.InstitutionSpeciality.Speciality.EducationalQualification.Name,
                            Form = s.InstitutionSpeciality.EducationalForm.Name,
                            District = s.Subordinate.District.Name,
                            Status = s.StudentStatus.Name
                        })
                        .ToList(),
                    Doctorals = personLot.PersonDoctorals
                        .Select(s => new SearchResultDoctoral
                        {
                            Institution = s.Institution.Name,
                            District = s.Subordinate.District.Name,
                            Duration = s.InstitutionSpeciality.Duration,
                            StartDate = s.StartDate,
                            Qualification = s.InstitutionSpeciality.Speciality.EducationalQualification.Name,
                            Form = s.InstitutionSpeciality.EducationalForm.Name,
                            Status = s.StudentStatus.Name
                        }).ToList(),
                })
                .SingleOrDefaultAsync(cancellationToken);

            if (student != null)
            {
                await this.appDbContext.Set<HistoryLog>()
                   .AddAsync(new HistoryLog()
                   {
                       UAN = student.Uan,
                       Date = DateTime.Now,
                       IPAddress = URBAN_MOBILITY_CENTER
                   });

                await this.appDbContext.SaveChangesAsync(cancellationToken);
            }

            return student;
        }
    }
}
