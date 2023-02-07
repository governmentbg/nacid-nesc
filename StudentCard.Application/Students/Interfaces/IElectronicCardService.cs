using StudentCard.Application.Students.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Students.Interfaces
{
    public interface IElectronicCardService
    {
        Task<ElectronicCardDto> GetStudentElectronicCardInfo(bool inBulgarian, CancellationToken cancellationToken);

        Task<string> GetStudentElectronicCardPdf(bool inBulgarian, CancellationToken cancellationToken);
    }
}
