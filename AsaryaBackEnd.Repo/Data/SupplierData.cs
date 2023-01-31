using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Core.Models.Value;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaryaBackEnd.Repo.Data
{
    public class SupplierData : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new Supplier(
                    new Person("local", "Supplier"),
                    new Address("seyaheyya", "Tripoli"))
                {
                    Id = 1,
                });
        }
    {
    }
}
