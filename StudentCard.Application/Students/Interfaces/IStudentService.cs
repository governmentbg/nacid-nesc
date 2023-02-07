using StudentCard.Application.Students.Dtos.PersonLotDtos;
using StudentCard.Application.Users.Models;
using StudentCard.Data.Students;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Students.Interfaces
{
    public interface IStudentService
    {
        Task CreateStudents(int limit, CancellationToken cancellationToken);

        Task<PersonLotDto> GetStudentByUan(CancellationToken cancellationToken);

        Task ValidateRequestedDiplomaAccess(Guid key);

        Task<Student> GetLoggedInStudent();
    }
}
