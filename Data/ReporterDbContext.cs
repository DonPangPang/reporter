using Microsoft.EntityFrameworkCore;
using Reporter.Entities;
using Reporter.Entities.Base;

namespace Reporter.Data;

public class ReporterDbContext : DbContext
{
    public ReporterDbContext(DbContextOptions<ReporterDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var types = typeof(IEntity).Assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(IEntity)) && !x.IsAbstract);

        foreach (var type in types)
        {
            if (modelBuilder.Model.FindEntityType(type) is null)
            {
                modelBuilder.Model.AddEntityType(type);
            }
        }

        modelBuilder.Entity<Work>().HasData(new[]
        {
            new Work()
            {
                Content = "111111"
            },
            new Work()
            {
                Content = "222222"
            },
            new Work()
            {
                Content = "333333"
            },
            new Work()
            {
                Content = "444444"
            }
        });

        base.OnModelCreating(modelBuilder);
    }
}