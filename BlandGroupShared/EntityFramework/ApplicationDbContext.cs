using Microsoft.EntityFrameworkCore;
using BlandGroupShared.EntityFramework.Entities;


namespace BlandGroupShared.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<Plate> Plates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
                
            }
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


    }
}

