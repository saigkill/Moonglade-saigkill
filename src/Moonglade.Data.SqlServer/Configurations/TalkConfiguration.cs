using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class TalkConfiguration : IEntityTypeConfiguration<TalkEntity>
{
  public void Configure(EntityTypeBuilder<TalkEntity> builder)
  {
    builder.Property(e => e.Id).ValueGeneratedNever();
    builder.Property(e => e.Date).HasColumnType("datetime");
    builder.Property(e => e.Language).IsRequired().HasConversion(e => e.ToString(),
      e => (Language)Enum.Parse(typeof(Language), e!));
    builder.Property(e => e.Link).HasMaxLength(150);
    builder.Property(e => e.Summary).HasMaxLength(150);
    builder.Property(e => e.TalkType).IsRequired().HasConversion(e => e.ToString(),
      e => (TalkType)Enum.Parse(typeof(TalkType), e!));
    builder.Property(e => e.Title).HasMaxLength(150);
    builder.Property(e => e.Where).HasMaxLength(50);
    builder.HasKey(e => e.Id);
    builder.ToTable("Talks");
  }
}
