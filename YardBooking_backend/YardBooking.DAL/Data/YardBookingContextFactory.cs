using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YardBooking.DAL.Data
{
    public class YardBookingContextFactory : IDesignTimeDbContextFactory<YardBookingContext>
    {
        public YardBookingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<YardBookingContext>();

            optionsBuilder.UseSqlServer("Server=.;Database=YardBookingDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new YardBookingContext(optionsBuilder.Options);
        }
    }
}
