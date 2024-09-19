using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class VideoConfiguration : IEntityTypeConfiguration<VideoEntity>
{
    public void Configure(EntityTypeBuilder<VideoEntity> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Description).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(150);
        builder.Property(e => e.VideoCode).IsRequired().HasMaxLength(20);
        builder.Property(e => e.DatePublished).HasColumnType("datetime");
        builder.Property(e => e.Language).IsRequired().HasConversion(e => e.ToString(),
            e => (Language)Enum.Parse(typeof(Language), e!));
        builder.Property(e => e.VideoType).IsRequired().HasConversion(e => e.ToString(),
            e => (VideoType)Enum.Parse(typeof(VideoType), e!));
        builder.HasKey(e => e.Id);
        builder.ToTable("Videos");
    }
}
