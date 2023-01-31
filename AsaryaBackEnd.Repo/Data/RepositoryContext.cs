using AsaryaBackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AsaryaBackEnd.Repo.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemData());
            modelBuilder.ApplyConfiguration(new CustomerData());
            modelBuilder.ApplyConfiguration(new SupplierData());

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
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceEntry> SalesInvoiceEntries { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceEntry> PurchaseInvoiceEntries { get; set; }

    }
}
