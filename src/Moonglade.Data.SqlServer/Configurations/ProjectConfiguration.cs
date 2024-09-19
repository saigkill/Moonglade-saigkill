using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.Property(e => e.Authors).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Client).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Completion).IsRequired().HasColumnType("datetime");
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Language).IsRequired().HasConversion(v => v.ToString(),
            v => (Language)Enum.Parse(typeof(Language), v));
        builder.Property(e => e.PortfolioLink).HasMaxLength(150);
        builder.Property(e => e.ProjectLink).IsRequired().HasMaxLength(150);
        builder.Property(e => e.ProjectName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.ProjectSummary).IsRequired().HasMaxLength(200);
        builder.Property(e => e.ProjectType).IsRequired();
        builder.HasKey(e => e.Id);
        builder.ToTable("Projects");
    }
}
