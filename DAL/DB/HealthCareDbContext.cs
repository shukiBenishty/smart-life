using BE.API.Nutritionix.Result;
using BE.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.DB
{
    public class SmartLifeDbContext : DbContext
    {
        public SmartLifeDbContext() : base("SmartLifeDb")
        {

        }
       
        public DbSet<SearchFood> SearchFood { get; set; }
        public DbSet<FoodUnit> FoodsUnits { get; set; }
        public DbSet<FoodNutritionsItem> FoodsNutritions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CurrentAccount> CurrentAccount { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
