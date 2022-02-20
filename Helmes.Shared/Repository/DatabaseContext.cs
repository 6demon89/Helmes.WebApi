using Helmes.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helmes.Shared.Repository
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            if (Database.EnsureCreated())
                Seed();
            Configuration = configuration;
        }

        private void Seed()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Helmes.Shared.Seed.SeedingData.sql";
            string values = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                values = reader.ReadToEnd();
            }
            Database.ExecuteSqlRaw(values);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HelmesTask;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sectors>(entity =>
            {
                entity.HasKey(x => x.SectorID);
                entity.Property(x => x.Name);
                entity.HasOne(x => x.ParentSector)
                    .WithMany(x => x.SubSectors)
                    .HasForeignKey(x => x.ParentSectorID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Sectors> Sectors { get; set; }
        public DbSet<User> Users { get; set; }

        public override void Dispose()
        {
            Database.CloseConnection();
            base.Dispose();
        }
        public override ValueTask DisposeAsync()
        {
            Database.CloseConnection();
            return base.DisposeAsync();
        }
    }
}
