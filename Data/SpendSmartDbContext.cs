using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpendSmart_Second_Web_application_.Models;
using System.Runtime.CompilerServices;

namespace SpendSmart_Second_Web_application_.Data
{
    //Якщо треба зробити ауторизацію, то треба наслідуватися з IdentityDbContext<UserModel>
    public class SpendSmartDbContext : IdentityDbContext<UserModel>
    {
        private readonly IConfiguration _configuration;
        public SpendSmartDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
