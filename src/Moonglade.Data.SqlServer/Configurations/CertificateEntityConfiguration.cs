using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class CertificateEntityConfiguration : IEntityTypeConfiguration<CertificateEntity>
{
  public void Configure(EntityTypeBuilder<CertificateEntity> builder)
  {
	builder.Property(e => e.Id).ValueGeneratedNever();
	builder.Property(e => e.CertificateTitle).IsRequired().HasMaxLength(150);
	builder.Property(e => e.Content).IsRequired().HasMaxLength(300);
	builder.Property(e => e.Image).IsRequired().HasMaxLength(300);
	builder.Property(e => e.Provider).IsRequired().HasMaxLength(150);
	builder.Property(e => e.Year).IsRequired().HasMaxLength(50);
	builder.Property(e => e.Link).IsRequired().HasMaxLength(300);
	builder.Property(e => e.Landscape).IsRequired();
	builder.Property(e => e.Language).IsRequired().HasConversion(c => c.ToString(),
		c => (Language)Enum.Parse(typeof(Language), c!));
	builder.HasKey(e => e.Id);
	builder.ToTable("Certificate");
  }
}
