using Microsoft.EntityFrameworkCore;
using System;
using EF.Models;

namespace EF.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
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