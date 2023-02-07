using System;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Interfaces
{
	public interface IImageFileService
	{
		Task<string> GetBase64ImageUrlAsync(Guid key, int dbId);
	}
}
