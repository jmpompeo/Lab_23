using Lab23.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab23.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>().Property(x => x.Title).HasMaxLength(50);
        }
    }
}
