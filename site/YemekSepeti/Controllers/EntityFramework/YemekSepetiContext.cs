using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepetiProje.Entities;
using YemekSepetiProje.Entitys;

namespace YemekSepeti.DataAccess.EntityFramework
{
    public class YemekSepetiContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public YemekSepetiContext() : base(@"server=(localdb)\mssqllocaldb;initial catalog=YemekSepeti;integrated security=true")
        {

        }
    }
}
