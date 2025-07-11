using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;
using Moonglade.Data.Specifications;

namespace Moonglade.Data.SqlServer.Configurations;

internal class TestimonialConfiguration : IEntityTypeConfiguration<TestimonialEntity>
{
  public void Configure(EntityTypeBuilder<TestimonialEntity> builder)
  {
    builder.Property(e => e.Id).ValueGeneratedNever();
    builder.Property(e => e.ImagePath).HasMaxLength(150);
    builder.Property(e => e.Link).HasMaxLength(150);
    builder.Property(e => e.Recommender).HasMaxLength(50).IsRequired();
    builder.Property(e => e.RecommenderJob).HasMaxLength(50);
    builder.Property(e => e.RecommenderLocation).HasMaxLength(50);
    builder.Property(e => e.Relationship).HasMaxLength(50);
    builder.Property(e => e.Summary).HasMaxLength(300).IsRequired();
    builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
    builder.Property(e => e.Language).HasConversion(v => v.ToString(),
        v => (Language)Enum.Parse(typeof(Language), v));
    builder.Property(e => e.Audience).HasConversion(
      v => v.ToString(),
      v => (Audience)Enum.Parse(typeof(Audience), v)
    );
    builder.HasKey(e => e.Id);
    builder.ToTable("Testimonials");
  }
}
