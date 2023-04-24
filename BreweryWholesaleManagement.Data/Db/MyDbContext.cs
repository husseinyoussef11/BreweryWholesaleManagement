using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryWholesaleManagement.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BreweryWholesaleManagement.Data.Db
{
    public class MyDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        //private readonly string _connectionString;

        //public MyDbContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}
        //public MyDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration; 
        //}
        //public MyDbContext()
        //{
        //}
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Brewery> Breweries { get; set; } = null!;
        public virtual DbSet<Beer> Beers { get; set; } = null!;
        public virtual DbSet<ClientOrder> ClientOrders { get; set; } = null!;
        public virtual DbSet<Wholesaler> Wholesalers { get; set; } = null!;
        public virtual DbSet<WholesalerStock> WholesalerStocks { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
                .Property(b => b.IsActive)
                .HasDefaultValue(1);
            modelBuilder.Entity<Beer>()
          .Property(b => b.Created)
          .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Beer>()
         .Property(b => b.Id)
         .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Brewery>()
               .Property(b => b.IsActive)
               .HasDefaultValue(1);
            modelBuilder.Entity<Brewery>()
       .Property(b => b.Id)
       .HasDefaultValueSql("newid()");

            modelBuilder.Entity<ClientOrder>()
     .Property(b => b.Id)
     .HasDefaultValueSql("newid()");
            modelBuilder.Entity<ClientOrder>()
                .Property(b => b.Created)
          .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<Log>()
     .Property(b => b.Id)
     .HasDefaultValueSql("newid()");
            modelBuilder.Entity<Log>()
                .Property(b => b.Created)
          .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Wholesaler>()
            .Property(b => b.IsActive)
            .HasDefaultValue(1);
            modelBuilder.Entity<Wholesaler>()
       .Property(b => b.Id)
       .HasDefaultValueSql("newid()");


            modelBuilder.Entity<WholesalerStock>()
     .Property(b => b.Id)
     .HasDefaultValueSql("newid()");
            modelBuilder.Entity<WholesalerStock>()
                .Property(b => b.Created)
          .HasDefaultValueSql("getdate()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer(_configuration["DefaultConnection"].ToString());
            }
        }
    }
}
