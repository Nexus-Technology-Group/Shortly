using Microsoft.EntityFrameworkCore;
using Shortly.Authorization.Domain;

namespace Shortly.Authorization.DAL.PostgreSQL.Context;

public interface IEntryContext
{
    DbSet<Entry> Entries { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}