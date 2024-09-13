using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OData.Data.Models;

namespace OData.Data.Configurations
{
    public class GadgetConfiguration : IEntityTypeConfiguration<Gadget>
    {
        public void Configure(EntityTypeBuilder<Gadget> builder)
        {
            builder.ToTable("Gadgets");
            builder.Property(p => p.Cost).HasPrecision(18);
            builder.HasData(
                new Gadget
                {
                    Id = 1,
                    ProductName = "Samsung Galaxy",
                    Brand = "Samsung",
                    Cost = 12000,
                    Type = "Mobile"
                }, 
                new Gadget
                {
                    Id = 2,
                    ProductName = "IPhone",
                    Brand = "Apple",
                    Cost = 13000,
                    Type = "Mobile"
                }, 
                new Gadget
                {
                    Id = 3,
                    ProductName = "IBM Thinkpad",
                    Brand = "IBM",
                    Cost = 34999,
                    Type = "Laptop"
                }, new Gadget
                {
                    Id = 4,
                    ProductName = "HP ProBook",
                    Brand = "HP",
                    Cost = 21000,
                    Type = "Laptop"
                }, new Gadget
                {
                    Id = 5,
                    ProductName = "Nokia 9222",
                    Brand = "Nokia",
                    Cost = 11000,
                    Type = "Mobile"
                });
        }
    }
}
