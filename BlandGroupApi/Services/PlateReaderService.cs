using System;
using BlandGroupApi.EntityFramework;
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


            IQueryable<Plate> query = _dbContext.Plates;

            if(camera != null)
            {
                query = query.Where(x => x.CameraName == camera);
            }

            if (dateFrom != default)
            {
                query = query.Where(x => x.CaptureDateTime >= dateFrom);
            }

            if (dateTo != default)
            {
                query = query.Where(x => x.CaptureDateTime <= dateTo);
            }

            List<PlateResponse> plates = await query
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

