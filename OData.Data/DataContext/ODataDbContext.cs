using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OData.Data.Models;

namespace OData.Data.DataContext
{
    public class ODataDbContext : DbContext
    {
        public ODataDbContext()
        {

        }

        public ODataDbContext(DbContextOptions<ODataDbContext> options) : base(options)
        {

        }

        public DbSet<Gadget> Gadgets { get; set; } = null!;

        private string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            string connectionString = configuration["ConnectionStrings:DefaultConnection"]!;
            return connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // gadget config
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ODataDbContext).Assembly);
        }
    }
}
