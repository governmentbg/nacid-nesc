using FileStorageNetCore;
using FileStorageNetCore.Api;
using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesStorageController : FileStorageController
    {
		private readonly IStudentService studentService;
		private readonly IImageFileService imageFileService;

		public FilesStorageController(
			BlobStorageService service, 
			IStudentService studentService,
			IImageFileService imageFileService
			)
			:base(service)
        {
			this.studentService = studentService;
			this.imageFileService = imageFileService;
		}

		public async override Task<IActionResult> Get(Guid key, int dbId, string fileName = null, string mimeType = null)
		{
			await this.studentService.ValidateRequestedDiplomaAccess(key);

			return await base.Get(key, dbId, fileName, mimeType);
		}

		[HttpGet("image")]
		public async Task<string> GetImage([FromQuery] Guid key, [FromQuery] int dbId)
		{
			return await this.imageFileService.GetBase64ImageUrlAsync(key, dbId);
		}
	}
}
