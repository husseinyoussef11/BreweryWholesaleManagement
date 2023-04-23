using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryWholesaleManagement.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BreweryWholesaleManagement.Data.Db
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

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
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=BreweryWholesaleDB;User Id=PracticeUser;Password=P@ssw0rd");
//            }
//        }
    }
}
