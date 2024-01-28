using System;
using BlandGroupApi.Models;

namespace BlandGroupApi.Interfaces
{
	public interface IPlateReaderService
	{
        Task<List<PlateResponse>> GetPlatesAsync(string camera, DateTime dateFrom, DateTime dateTo);
	}
}

