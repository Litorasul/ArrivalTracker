using ArrivalTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrivalTracker.Data;

public class ArrivalsDbContext : DbContext
{
    public ArrivalsDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Role> Roles { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ArrivalTime> ArrivalTimes { get; set; }

}
