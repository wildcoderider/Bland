using System;
using BlandGroupApi.Services;
using BlandGroupApi.Models;
using BlandGroupShared.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using BlandGroupApi.EntityFramework;

namespace BlandGroupApi.Tests.Services
{
    public class PlateReaderServiceTests
    {
        [Fact]
        public async Task GetPlatesAsync_WithValidParameters_ReturnsPlatesList()
        {
            // Arrange
            var dbContext = GetDbContextWithData();
            var plateReaderService = new PlateReaderService(Mock.Of<IConfiguration>(), dbContext);

            // Act
            var result = await plateReaderService.GetPlatesAsync("Camera1", DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<PlateResponse>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetPlatesAsync_WithNullCamera_ReturnsAllPlates()
        {
            // Arrange
            var dbContext = GetDbContextWithData();
            var plateReaderService = new PlateReaderService(Mock.Of<IConfiguration>(), dbContext);

            // Act
            var result = await plateReaderService.GetPlatesAsync(null, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<PlateResponse>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetPlatesAsync_WithDefaultDate_ReturnsPlatesList()
        {
            // Arrange
            var dbContext = GetDbContextWithData();
            var plateReaderService = new PlateReaderService(Mock.Of<IConfiguration>(), dbContext);

            // Act
            var result = await plateReaderService.GetPlatesAsync("Camera1", default, default);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<PlateResponse>>(result);
            Assert.NotEmpty(result);
        }

        

        private ApplicationDbContext GetDbContextWithData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            dbContext.Plates.AddRange(
                new Plate { CameraName = "Camera1", CaptureDateTime = DateTime.UtcNow, RegNumber = "ABC123" },
                new Plate { CameraName = "Camera2", CaptureDateTime = DateTime.UtcNow.AddDays(-5), RegNumber = "XYZ456" }
            );

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
