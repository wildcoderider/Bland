using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using BlandGroupShared.EntityFramework;
using BlandGroupShared.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

 public class Program
{
    
    private static ApplicationDbContext _dbContext;

    static void Main()
    {
        // Initialize the DbContext (you might want to do this at the beginning of your application)
        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=BlandGroup;User ID=sa;Password=blandGroup;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=false;").Options;

        _dbContext = new ApplicationDbContext(contextOptions);

        string relativeFilePath = "/Users/egoitz/Projects/BlandGroup/BlandGroupCamera/CameraPlates"; // Replace with your relative file path

       // Create a new instance of FileSystemWatcher
        using (FileSystemWatcher watcher = new FileSystemWatcher(relativeFilePath))
        {
            // Set IncludeSubdirectories to true to monitor subdirectories
            watcher.IncludeSubdirectories = true;

            // Subscribe to the Created event
            watcher.Created += (sender, args) => Task.Run(() => OnFileCreated(sender, args).Wait());

            // Start monitoring
            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Monitoring folder and subfolders: {relativeFilePath}");

            Console.WriteLine("Press 'q' to quit.");

            // Wait for user to press 'q' to exit the application
            while (Console.ReadKey().Key != ConsoleKey.Q) { }
        }

        // Dispose of the DbContext when it's no longer needed (you might want to do this at the end of your application)
        _dbContext.Dispose();
    }

    public static async Task OnFileCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"File created: {e.FullPath}");

        if (e.Name!.EndsWith(".lpr", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                // Read the content of the .lpr file
                string fileContent = File.ReadAllText(e.FullPath);

                string[] substrings = fileContent.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

                // Other solution is to create a compound primary key.
                var existingPlate = _dbContext.Plates.Where(x => x.ImageFilename == substrings[5] && x.CameraName == substrings[3]).FirstOrDefault();

                if (existingPlate == null)
                {
                    Plate plate = new Plate
                    {
                        CountryOfVehicle = substrings[0],
                        RegNumber = substrings[1].StartsWith("r", StringComparison.OrdinalIgnoreCase) ? substrings[1].Substring(1) : substrings[1],
                        ConfidenceLevel = int.Parse(substrings[2].StartsWith("r", StringComparison.OrdinalIgnoreCase) ? substrings[2].Substring(1) : substrings[2]),
                        CameraName = substrings[3].StartsWith("r", StringComparison.OrdinalIgnoreCase) ? substrings[3].Substring(1) : substrings[3],
                        CaptureDateTime = DateTime.ParseExact(substrings[4], "yyyyMMddHHmm", CultureInfo.InvariantCulture),
                        ImageFilename = substrings[6]
                    };

                    
                    _dbContext.Plates.Add(plate);

                    await _dbContext.SaveChangesAsync();
                }

                
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Not a .lpr file. Skipping reading process.");
        }
    }
}
