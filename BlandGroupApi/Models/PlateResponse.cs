

namespace BlandGroupApi.Models
{
	public class PlateResponse
	{
        
        public string? CountryOfVehicle { get; set; }

        public string? RegNumber { get; set; }

        public int ConfidenceLevel { get; set; }

        public string? CameraName { get; set; }

        public DateTime CaptureDateTime { get; set; }

        public string? ImageFilename { get; set; }
    }
}

