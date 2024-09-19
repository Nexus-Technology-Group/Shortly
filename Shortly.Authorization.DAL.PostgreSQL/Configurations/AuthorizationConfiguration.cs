using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shortly.Authorization.DAL.PostgreSQL.Configurations;

public class AuthorizationConfiguration : IEntityTypeConfiguration<Domain.Authorization>
{
    public void Configure(EntityTypeBuilder<Domain.Authorization> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Login)
            .IsUnique();

        builder.Property(x => x.Password)
            .IsRequired();
    }
}