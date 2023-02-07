using FileStorageNetCore.Api;
using StudentCard.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Services
{
	public class ImageFileService : IImageFileService
	{
		private readonly IBlobStorageService fileStorageRepository;

		public ImageFileService(IBlobStorageService fileStorageRepository)
		{
			this.fileStorageRepository = fileStorageRepository;
		}

		public async Task<string> GetBase64ImageUrlAsync(Guid key, int dbId)
		{
			var image = await this.fileStorageRepository.GetBytes(key, dbId);
			string base64ImageUrl;

			if (image != null)
			{
				base64ImageUrl = Convert.ToBase64String(image);
			}
			else
			{
				return null;
			}

			return base64ImageUrl;
		}
	}
}
