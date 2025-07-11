using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
  public void Configure(EntityTypeBuilder<ProjectEntity> builder)
  {
    builder.Property(e => e.Completion).IsRequired().HasColumnType("datetime");
    builder.Property(e => e.Id).ValueGeneratedNever();
    builder.Property(e => e.Language).IsRequired().HasConversion(v => v.ToString(),
        v => (Language)Enum.Parse(typeof(Language), v));
    builder.Property(e => e.ProjectLink).IsRequired();
    builder.Property(e => e.ProjectName).IsRequired();
    builder.Property(e => e.ProjectSummary).IsRequired();
    builder.HasKey(e => e.Id);
    builder.ToTable("Projects");
  }
}
