
using DevTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Infrastructure.Persistance;

public class DevTrackContext : DbContext
{


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\src\personal\myDb.db");
    }

    public DbSet<Package> Packages { get; set; } = null!;
    public DbSet<PackageUpdate> Updates { get; set; } = null!;


}