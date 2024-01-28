using System;
using BlandGroupApi.Interfaces;
using BlandGroupApi.Models;
using BlandGroupShared.EntityFramework;
using BlandGroupShared.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlandGroupApi.Services
{
	public class PlateReaderService : IPlateReaderService
    {
        
        private readonly ApplicationDbContext _dbContext;

        public PlateReaderService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PlateResponse>> GetPlatesAsync(string camera, DateTime dateFrom, DateTime dateTo)
        {

                List<PlateResponse> plates = await _dbContext.Plates
                .Where(x => x.CameraName == camera && x.CaptureDateTime >= dateFrom && x.CaptureDateTime <= dateTo) // Here we could use also automapper here ot at controller level.
                .Select(x => new PlateResponse
                {
                    CameraName = x.CameraName,
                    CaptureDateTime = x.CaptureDateTime,
                    RegNumber = x.RegNumber,
                    ConfidenceLevel = x.ConfidenceLevel,
                    CountryOfVehicle = x.CountryOfVehicle,
                    ImageFilename = x.ImageFilename
                })
                .ToListAsync();

            return plates;
        }

    }
}

