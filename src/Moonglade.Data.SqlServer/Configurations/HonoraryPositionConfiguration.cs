using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class HonoraryPositionConfiguration : IEntityTypeConfiguration<HonoraryPositionEntity>
{
  public void Configure(EntityTypeBuilder<HonoraryPositionEntity> builder)
  {
	builder.Property(e => e.Id).ValueGeneratedNever();
	builder.Property(e => e.Link).HasMaxLength(150);
	builder.Property(e => e.Organization).HasMaxLength(100).IsRequired();
	builder.Property(e => e.Summary).HasMaxLength(200);
	builder.Property(e => e.Active).HasDefaultValue(true).IsRequired();
	builder.Property(e => e.Language).IsRequired().HasConversion(c => c.ToString(),
		c => (Language)Enum.Parse(typeof(Language), c!));
	builder.HasKey(e => e.Id);
	builder.ToTable("HonoraryPositions");
  }
}
