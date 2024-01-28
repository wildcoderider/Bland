using System;
using System.ComponentModel.DataAnnotations;

namespace BlandGroupShared.EntityFramework.Entities
{
	public class UserFile : BaseEntity
	{
        public string? Name { get; set; }
        public long Size { get; set; }
        public string? ContentType { get; set; }
        public string? Extension { get; set; }
        public DateTime TimestampProcessed { get; set; }
        public string? FilePath { get; set; }
    }
}

