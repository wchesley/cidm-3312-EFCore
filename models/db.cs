using System; 
using Microsoft.EntityFrameworkCore;

namespace Homework_2
{
    class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=database.db");
        }
        public DbSet<PatientsModel> patient {get; set;}
    }
}