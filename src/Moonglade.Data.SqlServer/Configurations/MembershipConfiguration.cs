using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class MembershipConfiguration : IEntityTypeConfiguration<MembershipEntity>
{
  public void Configure(EntityTypeBuilder<MembershipEntity> builder)
  {
	builder.Property(e => e.Id).ValueGeneratedNever();
	builder.Property(e => e.Link).HasMaxLength(100).IsRequired();
	builder.Property(e => e.Organization).HasMaxLength(150).IsRequired();
	builder.Property(e => e.Summary).HasMaxLength(200).IsRequired();
	builder.Property(e => e.Active).IsRequired();
	builder.Property(e => e.Language).IsRequired().HasConversion(c => c.ToString(),
		c => (Language)Enum.Parse(typeof(Language), c!));
	builder.HasKey(k => k.Id);
	builder.ToTable("Memberships");
  }
}
