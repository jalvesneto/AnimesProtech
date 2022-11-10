using Microsoft.EntityFrameworkCore;
using AnimesProtech.DAL.Models;
using Microsoft.Extensions.Configuration;

public partial class AnimesProtechContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Director> Directors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            String ConnectionString = Environment.GetEnvironmentVariable("ANIMES_PROTECH_CONNECTION_STRING");
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
