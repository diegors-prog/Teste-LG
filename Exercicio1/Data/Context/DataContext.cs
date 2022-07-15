using Exercicio1.Data.Types;
using Exercicio1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Contact> DbSetContact { get; set; }
        public DbSet<Customer> DbSetCustomer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }
    }
}