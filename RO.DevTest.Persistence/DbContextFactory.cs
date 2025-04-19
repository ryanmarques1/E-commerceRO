using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RO.DevTest.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();

            //Substitua com sua connection string real
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=rodevtest;Username=postgres;Password=root");

            return new DefaultContext(optionsBuilder.Options);
        }
    }
}
