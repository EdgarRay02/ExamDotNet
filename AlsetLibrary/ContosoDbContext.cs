using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AlsetLibrary
{
    public class ContosoDbContext : DbContext
    {
        public DbSet<Researcher> Researchers { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public ContosoDbContext()
        {

        }

        /*public ContosoDbContext(DbContextOptions<ContosoDbContext> options) : base(options)
        {
        }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-A9MDP5F\\SQLEXPRESS;Database=dbAlset;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
