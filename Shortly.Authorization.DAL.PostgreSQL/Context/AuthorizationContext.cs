using Microsoft.EntityFrameworkCore;
using Shortly.Authorization.Domain;

namespace Shortly.Authorization.DAL.PostgreSQL.Context;

public class AuthorizationContext : DbContext, IAuthorizationContext, IEntryContext
{
    public DbSet<Domain.Authorization> Authorizations => Set<Domain.Authorization>();

    public DbSet<Entry> Entries => Set<Entry>();
    
    public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorizationContext).Assembly);
    }
}