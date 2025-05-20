using Forge.Persistence.Common.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forge.Persistence.Sqlite.Configurations;

public class ScoreReadModelConfiguration : IEntityTypeConfiguration<ScoreReadModel>
{
    public void Configure(EntityTypeBuilder<ScoreReadModel> builder)
    {
        builder.ToTable("Scores");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.TotalScore)
            .IsRequired();
    }
}
