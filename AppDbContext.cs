using Microsoft.EntityFrameworkCore;

namespace ContextAwareEFCore;

public class AppDbContext(DbContextOptions<AppDbContext> options, ContextInfo contextInfo) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!contextInfo.IsAdmin)
        {
            modelBuilder.Entity<Order>()
                .HasQueryFilter(o => o.UserId == contextInfo.UserId);
        }
    }
}