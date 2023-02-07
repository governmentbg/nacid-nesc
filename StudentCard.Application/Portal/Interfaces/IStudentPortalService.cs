using StudentCard.Application.Portal.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Portal.Interfaces
{
    public interface IStudentPortalService
    {
        Task<StudentPortalBasicDto> GetStudentPortalBasicByUan(string uan, CancellationToken cancellationToken);
    }
}
