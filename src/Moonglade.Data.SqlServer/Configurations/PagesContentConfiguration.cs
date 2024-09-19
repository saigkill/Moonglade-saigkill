using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

public class PagesContentConfiguration : IEntityTypeConfiguration<PagesContentEntity>
{
  public void Configure(EntityTypeBuilder<PagesContentEntity> builder)
  {
    builder.Property(e => e.Id).ValueGeneratedNever();
    builder.Property(e => e.Language).IsRequired().HasConversion(e => e.ToString(), e => (Language)Enum.Parse(typeof(Language), e!));
    builder.Property(e => e.Key).IsRequired().HasMaxLength(50);
    builder.Property(e => e.Value).IsRequired().HasMaxLength(1000);
    builder.Property(e => e.RootPage).IsRequired().HasMaxLength(50);
    builder.HasKey(e => e.Id);
    builder.ToTable("PagesContent");
  }
}
