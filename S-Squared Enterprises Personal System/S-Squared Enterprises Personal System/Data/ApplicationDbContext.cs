using Microsoft.EntityFrameworkCore;
using S_Squared_Enterprises_Personal_System.Models;

namespace S_Squared_Enterprises_Personal_System.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().
                HasOne(e => e.Manager).
                WithMany().
                OnDelete(DeleteBehavior.SetNull);      
                
        }
    }
}
