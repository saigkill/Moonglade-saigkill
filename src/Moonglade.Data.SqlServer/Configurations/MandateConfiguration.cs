using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class MandateConfiguration : IEntityTypeConfiguration<MandateEntity>
{
  public void Configure(EntityTypeBuilder<MandateEntity> builder)
  {
    builder.Property(e => e.Id).ValueGeneratedOnAdd();
    builder.Property(e => e.Language).IsRequired().HasConversion(c => c.ToString(),
      c => (Language)Enum.Parse(typeof(Language), c!));
    builder.Property(e => e.Link).HasMaxLength(150).IsRequired();
    builder.Property(e => e.Organization).HasMaxLength(150).IsRequired();
    builder.Property(e => e.Summary).HasMaxLength(150).IsRequired();
    builder.Property(e => e.Years).HasMaxLength(50).IsRequired();
    builder.HasKey(e => e.Id);
    builder.ToTable("Mandates");
  }
}
