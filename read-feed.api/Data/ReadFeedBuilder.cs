using Microsoft.EntityFrameworkCore;
using read_feed.api.Entities;

namespace read_feed.api.Data;

public partial class ReadFeedContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(e => e.Email)
            .IsUnique();
    }
}