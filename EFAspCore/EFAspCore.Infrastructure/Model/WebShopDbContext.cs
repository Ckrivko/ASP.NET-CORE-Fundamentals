using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAspCore.Infrastructure.Model
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options)
            : base(options) // =>Database.EnsureCreated();  This will create DB if DB notexist
            //Any change in the date anetities will not change the DB
            //Update by hand! Ordrop and recreate after entity change
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }

    }
}
