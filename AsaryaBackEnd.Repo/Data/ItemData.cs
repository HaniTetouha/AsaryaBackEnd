using AsaryaBackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaryaBackEnd.Repo.Data
{
    public class ItemData : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                new Item
                {
                    Id = 1,
                    Barcode = 1009,
                    Description = "Food",
                    Quantity = 5,
                    Price = 10
                },
                new Item
                {
                    Id = 2,
                    Barcode = 1010,
                    Description = "Drink",
                    Quantity = 16,
                    Price = 15
                }
                );
        }

    }
}
