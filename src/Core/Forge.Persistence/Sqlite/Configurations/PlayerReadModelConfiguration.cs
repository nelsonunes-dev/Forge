using Forge.Persistence.Common.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forge.Persistence.Sqlite.Configurations;

public class PlayerReadModelConfiguration : IEntityTypeConfiguration<PlayerReadModel>
{
    public void Configure(EntityTypeBuilder<PlayerReadModel> builder)
    {
        builder.ToTable("Players");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

        builder.Property(x => x.Score)
                .IsRequired();
    }
}
