using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shortly.Authorization.Domain;

namespace Shortly.Authorization.DAL.PostgreSQL.Configurations;

public class EntryConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne<Domain.Authorization>()
            .WithMany()
            .HasForeignKey(x => x.AuthorizationId)
            .IsRequired();

        builder.Property(x => x.Ip)
            .IsRequired();

        builder.Property(x => x.UserAgent)
            .IsRequired();

        builder.Property(x => x.RefreshToken);

        builder.Property(x => x.IsAllowed);
    }
}