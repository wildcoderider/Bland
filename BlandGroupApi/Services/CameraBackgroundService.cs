using System;
namespace BlandGroupApi.Services
{
    public class CameraBackgroundService : BackgroundService
    {
        private readonly ILogger<CameraBackgroundService> _logger;

        public CameraBackgroundService(ILogger<CameraBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Background service is running.");

                Console.WriteLine("Background service is running.");

                

                await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken); // Delay for 20 seconds
            }
        }
    }
}

