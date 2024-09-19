using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Moonglade.Data.Entities;

namespace Moonglade.Data.SqlServer.Configurations;

internal class CalendarConfiguration : IEntityTypeConfiguration<CalendarEntity>
{
    public void Configure(EntityTypeBuilder<CalendarEntity> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever().IsRequired();
        builder.Property(c => c.EventDate).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.EventDateFinished).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.EventName).HasMaxLength(150).IsRequired();
        builder.Property(c => c.Link).HasMaxLength(200).IsRequired();
        builder.Property(c => c.Location).HasMaxLength(50);
        builder.Property(c => c.Logo).HasMaxLength(150);
        builder.HasKey(c => c.Id);
        builder.ToTable("Calendar");
    }
}
