using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace lab11.DataBase
{
    public class AppDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=MyStore; Integrated Security=true; Encrypt=false;");
            base.OnConfiguring(optionsBuilder);
        }
        //"Data Source=SQL8005.site4now.net;Initial Catalog=db_aa52ba_logins;User Id=db_aa52ba_logins_admin;Password=TestPass_1;"
        //"server=localhost; database=Practica_database_final_f_tochno_final; Integrated Security=true; Encrypt=false;"
    }
}
