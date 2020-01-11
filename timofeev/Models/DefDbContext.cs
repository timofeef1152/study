using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class DefDbContext : DbContext
    {
        public DefDbContext() : base("DefaultConnection") 
        {
                       
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<ConfectioneryCategory> ConfectioneryCategories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderTheme> OrderThemes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}