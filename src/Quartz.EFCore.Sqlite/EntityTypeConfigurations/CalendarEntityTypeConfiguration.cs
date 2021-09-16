using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class CalendarEntityTypeConfiguration : IEntityTypeConfiguration<QuartzCalendar>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public CalendarEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzCalendar> builder)
        {
            builder.ToTable($"{_prefix}CALENDARS", _schema);

            builder.HasKey(x => new { x.SchedulerName, x.CalendarName });

            builder.Property(x => x.SchedulerName)
              .HasColumnName(QuartzColumnNameConstants.SchedulerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
              .IsRequired();

            builder.Property(x => x.CalendarName)
              .HasColumnName(QuartzColumnNameConstants.CalendarName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.CalendarNameLength)
              .IsRequired();

            builder.Property(x => x.Calendar)
              .HasColumnName(QuartzColumnNameConstants.Calendar)
              .HasColumnType("BLOB")
              .IsRequired();
        }
    }
}
