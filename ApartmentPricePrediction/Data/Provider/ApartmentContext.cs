using Microsoft.EntityFrameworkCore;
using ScrapingApartments.Model;

namespace ScrapingApartments.Data.Provider
{
    public class ApartmentContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=ApartmentML; User ID=postgres; Password=P@ssw0rd;").UseSnakeCaseNamingConvention();
    }
}
