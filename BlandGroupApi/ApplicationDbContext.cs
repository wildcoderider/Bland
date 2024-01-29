using Microsoft.EntityFrameworkCore;
using BlandGroupShared.EntityFramework.Entities;


namespace BlandGroupApi.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<Plate> Plates { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=BlandGroup;User ID=sa;Password=blandgroup;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=false;");

            }
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


    }
}

