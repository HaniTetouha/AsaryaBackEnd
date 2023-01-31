using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Core.Models.Value;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaryaBackEnd.Repo.Data
{
    public class CustomerData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer(
                    new Person("Hani", "Tetouha"),
                    new Address("seyaheyya", "Tripoli"))
                {
                    Id = 1,
                });
        }

    }
}
