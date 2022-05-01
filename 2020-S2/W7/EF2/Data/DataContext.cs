using System;
using Microsoft.EntityFrameworkCore;
using EF2.Models;

namespace EF2.Data 
{
    public class DataContext : DbContext {
        
            public DataContext()
    {
    }
                public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.SetCommandTimeout(9000);
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Tienda> Tienda { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}