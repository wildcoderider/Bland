using System;
using System.ComponentModel.DataAnnotations;

namespace BlandGroupShared.EntityFramework.Entities
{
	public class Plate : BaseEntity
	{
        //[MaxLength(3)]
        public string? CountryOfVehicle { get; set; }

        //[MaxLength(10)]
        public string? RegNumber { get; set; }

        public int ConfidenceLevel { get; set; }

        //[MaxLength(10)]
        public string? CameraName { get; set; }

        public DateTime CaptureDateTime { get; set; }

        //[MaxLength(100)]
        public string? ImageFilename { get; set; }
    }
}

