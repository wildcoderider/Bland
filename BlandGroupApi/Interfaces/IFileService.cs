using System;
using BlandGroupShared.EntityFramework.Entities;

namespace BlandGroupApi.Interfaces
{
	public interface IFileService
	{
        Task<UserFile> ProcessFileAsync(Stream fileStream, string fileName, string contentType, string extension);
	}
}

