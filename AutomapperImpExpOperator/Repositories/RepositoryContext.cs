using ImplicitOperator.Models;
using Microsoft.EntityFrameworkCore;

namespace ImplicitOperator.Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Human> Humans { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=master;User ID=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Human>()
                .HasMany(e => e.Pets)
                .WithOne(e => e.Human)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
