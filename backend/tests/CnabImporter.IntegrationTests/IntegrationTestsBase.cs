using Microsoft.EntityFrameworkCore;
using CnabImporter.Infrastructure;

namespace CnabImporter.IntegrationTests
{
    public class IntegrationTestsBase
    {
        protected AppDbContext Context { get; private set; }

        [SetUp]
        public void Setup()
        {
            var connectionString = "Server=localhost,1436;Database=CnabImporterTestDb;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            Context = new AppDbContext(options);

            // Ensure database exists and migrations applied
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            SeedTestData();
        }

        private void SeedTestData()
        {
            // Seed initial stores
            Context.Stores.AddRange(
                new Domain.Models.Store { Name = "Bar do João", Owner = "JOÃO MACEDO" },
                new Domain.Models.Store { Name = "Loja do Ó - Matriz", Owner = "MARIA JOSEFINA" }
            );
            Context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}