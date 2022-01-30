using bank_apiDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bank_apiRepository
{
    public sealed class BankApiContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankApiContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("ConnectionString Required");

            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(a =>
            {
                a.ToTable("Account").HasKey(b => b.Id);
                a.Property(b => b.Id).HasColumnName("AccountId");
            });

            modelBuilder.Entity<Customer>(a =>
            {
                a.ToTable("Customer").HasKey(b => b.Id);
                a.Property(b => b.Id).HasColumnName("CustomerId");
            });

            modelBuilder.Entity<Transaction>(a =>
            {
                a.ToTable("Transaction").HasKey(b => b.Id);
                a.Property(b => b.Id).HasColumnName("TransactionId");
            });
        }
    }
}
