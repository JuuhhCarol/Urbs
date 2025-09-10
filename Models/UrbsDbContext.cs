using Microsoft.EntityFrameworkCore;

namespace Urbs.Models;

public class UrbsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<Point> Points => Set<Point>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<User>()
            .HasOne(u => u.Tour)
            .WithMany(t => t.U)
            .HasForeignKey(u => u.TourId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Tour>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tour)
            .HasForeignKey(u => u.PointId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Point>()
            .HasOne(p => p.Tour)
            .WithMany(t => t.Point)
            .HasForeignKey(u => u.TourId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}

