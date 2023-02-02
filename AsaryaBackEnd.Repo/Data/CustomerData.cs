using AsaryaBackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaryaBackEnd.Repo.Data
{
    public class CustomerData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new
                {
                    Id = 1,
                });
            builder.OwnsOne(p => p.Person).HasData(new { FirstName = "Hani", LastName = "Tetouha", CustomerId = 1 });
            builder.OwnsOne(p => p.Address).HasData(new { Street = "seyyaheya", City = "Tripoli", CustomerId = 1 });

        }

    }
}
