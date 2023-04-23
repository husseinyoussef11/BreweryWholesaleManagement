using BreweryWholesaleManagement.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsApi
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json");

            var connectionString = builder.Configuration.GetSection("DefaultConnection").Value;

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new MyDbContext(dbContextOptionsBuilder.Options);
        }
    }

}
