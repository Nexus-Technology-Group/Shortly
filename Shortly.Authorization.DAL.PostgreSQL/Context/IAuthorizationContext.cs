using Microsoft.EntityFrameworkCore;

namespace Shortly.Authorization.DAL.PostgreSQL.Context;

public interface IAuthorizationContext
{
    DbSet<Domain.Authorization> Authorizations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}