using Microsoft.EntityFrameworkCore;
using read_feed.api.Entities;

namespace read_feed.api.Data;

public partial class ReadFeedContext : DbContext
{
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<ReadItem> ReadItems => Set<ReadItem>();
    public DbSet<Token> Tokens => Set<Token>();
    public DbSet<User> Users => Set<User>();

    public ReadFeedContext(DbContextOptions<ReadFeedContext> dbContextOptions)
        : base(dbContextOptions) { }
}
