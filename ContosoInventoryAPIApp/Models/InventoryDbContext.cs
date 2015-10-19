using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ContosoInventoryAPIApp.Models
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {
            Database.SetInitializer<InventoryDbContext>(null);
        }
        public InventoryDbContext(string strConn)
            : base(strConn)
        {
            base.Database.Connection.ConnectionString = strConn;
            Database.SetInitializer<InventoryDbContext>(null);
        }

        public DbSet<InventoryData> inventoryData { get; set; }
        public DbSet<vProducts> vProducts { get; set; }


        //protected override void OnConfiguring(DbContextOptions options)
        //{

        //Console.WriteLine(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
        //    options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
        //}

    }

}
