using BillingApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BillingApi.Infra
{
    public class DataContext : DbContext
    {
        private IDbContextTransaction _transaction;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<BillingLine> BillingLine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region Transactions

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            if (Database.CurrentTransaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }

        #endregion Transactions
    }
}
