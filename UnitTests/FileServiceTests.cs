using System;
using System.IO;
using System.Threading.Tasks;
using BlandGroupApi.EntityFramework;
using BlandGroupApi.Interfaces;
using BlandGroupApi.Services;
using BlandGroupShared.EntityFramework;
using BlandGroupShared.EntityFramework.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class FileServiceTests
{
    [Fact]
    public async Task ProcessFileAsync_ValidFile_ReturnsUserFile()
    {
        // Arrange
        var configuration = new Mock<IConfiguration>();
        configuration.Setup(x => x.GetConnectionString("AzureStorage")).Returns("connection_string");

        var dbContext = new Mock<ApplicationDbContext>();

        var fileStream = new MemoryStream(new byte[] { 0x1, 0x2, 0x3 });
        var fileName = "testfile.txt";
        var contentType = "text/plain";
        var extension = ".txt";

        var fileService = new FileService(configuration.Object, dbContext.Object);

        // Act
        var result = await fileService.ProcessFileAsync(fileStream, fileName, contentType, extension);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fileName, result.Name);
        Assert.Equal(fileStream.Length, result.Size);
        Assert.Equal(contentType, result.ContentType);
        Assert.Equal(extension, result.Extension);
        Assert.NotNull(result.TimestampProcessed);
        Assert.NotNull(result.FilePath);
        Assert.True(result.FilePath.Contains("userFiles")); // Assuming "userFiles" is part of the path

        dbContext.Verify(x => x.UserFiles.Add(It.IsAny<UserFile>()), Times.Once);
        
        dbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

    }

    [Fact]
    public async Task ProcessFileAsync_InvalidFile_ThrowsException()
    {
        // Arrange
        var configuration = new Mock<IConfiguration>();
        configuration.Setup(x => x.GetConnectionString("AzureStorage")).Returns("connection_string");

        var dbContext = new Mock<ApplicationDbContext>();

        var invalidFileStream = new MemoryStream(); // Empty stream

        var fileService = new FileService(configuration.Object, dbContext.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ApplicationException> (async () => await fileService.ProcessFileAsync(invalidFileStream, "invalid.txt", "text/plain", ".txt"));
    }
}



