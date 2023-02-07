using System.Threading.Tasks;

namespace StudentCard.Application.Common.Interfaces
{
    public interface IPdfFileService
    {
        Task<byte[]> GeneratePdfFile<T>(T payload, byte[] content, bool closeStream = true);
    }
}
