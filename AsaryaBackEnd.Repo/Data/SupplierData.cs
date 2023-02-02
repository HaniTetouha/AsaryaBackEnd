using AsaryaBackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaryaBackEnd.Repo.Data
{
    public class SupplierData : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new
                {
                    Id = 1
                });
            builder.OwnsOne(p => p.Person).HasData(new { FirstName = "Local", LastName = "Supplier", SupplierId = 1 });
            builder.OwnsOne(p => p.Address).HasData(new { Street = "gergarsh", City = "Tripoli", SupplierId = 1 });

        }
    }
}
