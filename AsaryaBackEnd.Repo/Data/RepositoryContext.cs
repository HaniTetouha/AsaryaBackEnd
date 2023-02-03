using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Core.Models.Value;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AsaryaBackEnd.Repo.Data
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemData());
            modelBuilder.ApplyConfiguration(new CustomerData());
            modelBuilder.ApplyConfiguration(new SupplierData());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurchaseInvoice>()
                .Property(e => e.Status)
                .HasConversion(
                p => p.ToString(),
                p => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), p));

            modelBuilder.Entity<SalesInvoice>()
               .Property(e => e.Status)
               .HasConversion(
               p => p.ToString(),
               p => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), p));

            modelBuilder.Entity<StockTransaction>()
                .Property(e => e.Type)
                .HasConversion(
                p => p.ToString(),
                p => (StockTransactionType)Enum.Parse(typeof(StockTransactionType), p));

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.OwnsOne(o => o.Person)
                 .Property(p => p.FirstName)
                 .HasColumnName("FirstName")
                 .HasColumnType("VARCHAR(250)")
                 .IsRequired();

                entity.OwnsOne(o => o.Person)
                 .Property(p => p.LastName)
                 .HasColumnName("LastName")
                 .HasColumnType("VARCHAR(250)")
                 .IsRequired();

                entity.OwnsOne(o => o.Address)
                .Property(p => p.Street)
                .HasColumnName("Street")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Address)
                .Property(p => p.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Contact)
                .Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Contact)
                .Property(p => p.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Contact)
                .Property(p => p.HomeNumber)
                .HasColumnName("HomeNumber")
                .HasColumnType("VARCHAR(250)");

            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.OwnsOne(o => o.Person)
                 .Property(p => p.FirstName)
                 .HasColumnName("FirstName")
                 .HasColumnType("VARCHAR(250)")
                 .IsRequired();

                entity.OwnsOne(o => o.Person)
                 .Property(p => p.LastName)
                 .HasColumnName("LastName")
                 .HasColumnType("VARCHAR(250)")
                 .IsRequired();

                entity.OwnsOne(o => o.Address)
                .Property(p => p.Street)
                .HasColumnName("Street")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Address)
                .Property(p => p.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Contact)
                .Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Contact)
                .Property(p => p.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("VARCHAR(250)");

                entity.OwnsOne(o => o.Contact)
                .Property(p => p.HomeNumber)
                .HasColumnName("HomeNumber")
                .HasColumnType("VARCHAR(250)");

            });
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceEntry> SalesInvoiceEntries { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceEntry> PurchaseInvoiceEntries { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

    }
}
