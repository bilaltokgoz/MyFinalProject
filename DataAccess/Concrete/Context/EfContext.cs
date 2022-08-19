using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Context
{
  public class EfContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=MyFinal_DB;Trusted_Connection=true");
        }
        public DbSet <Product>Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
