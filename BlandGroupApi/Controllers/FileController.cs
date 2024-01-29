using System;
using BlandGroupApi.Interfaces;
using BlandGroupShared.EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlandGroupApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
	{
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("UploadFile")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserFile))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            using (var stream = file.OpenReadStream())
            {
                var fileModel = await _fileService.ProcessFileAsync(stream, file.FileName, file.ContentType, Path.GetExtension(file.FileName));
                return Ok(fileModel);
            }
        }


    }
}

