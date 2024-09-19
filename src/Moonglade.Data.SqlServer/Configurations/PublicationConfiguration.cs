using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class PublicationConfiguration : IEntityTypeConfiguration<PublicationEntity>
{
  public void Configure(EntityTypeBuilder<PublicationEntity> builder)
  {
    builder.Property(e => e.Id).ValueGeneratedNever();
    builder.Property(e => e.Authors).IsRequired();
    builder.Property(e => e.DatePublished).HasColumnType("datetime");
    builder.Property(e => e.Identifier).HasMaxLength(50);
    builder.Property(e => e.Link).HasMaxLength(150);
    builder.Property(e => e.PublicationName).IsRequired().HasMaxLength(200);
    builder.Property(e => e.Publisher).IsRequired();
    builder.Property(e => e.IsBook).IsRequired();
    builder.Property(e => e.Language).IsRequired().HasConversion(v => v.ToString(),
      v => (Language)Enum.Parse(typeof(Language), v));
    builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
    builder.HasKey(e => e.Id);
    builder.ToTable("Publication");
  }
}
