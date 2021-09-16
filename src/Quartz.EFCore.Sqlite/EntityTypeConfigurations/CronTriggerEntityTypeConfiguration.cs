using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class CronTriggerEntityTypeConfiguration : IEntityTypeConfiguration<QuartzCronTrigger>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public CronTriggerEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzCronTrigger> builder)
        {
            builder.ToTable($"{_prefix}CRON_TRIGGERS", _schema);

            builder.HasKey(x => new { x.SchedulerName, x.TriggerName, x.TriggerGroup });

            builder.Property(x => x.SchedulerName)
              .HasColumnName(QuartzColumnNameConstants.SchedulerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
              .IsRequired();

            builder.Property(x => x.TriggerName)
              .HasColumnName(QuartzColumnNameConstants.TriggerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.TriggerNameLength)
              .IsRequired();

            builder.Property(x => x.TriggerGroup)
              .HasColumnName(QuartzColumnNameConstants.TriggerGroup)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.TriggerGroupLength)
              .IsRequired();

            builder.Property(x => x.CronExpression)
              .HasColumnName(QuartzColumnNameConstants.CronExpression)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.CronExpressionLength)
              .IsRequired();

            builder.Property(x => x.TimeZoneId)
              .HasColumnName(QuartzColumnNameConstants.TimeZoneId)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.TimeZoneIdLength);

            builder.HasOne(x => x.Trigger)
              .WithMany(x => x.CronTriggers)
              .HasForeignKey(x => new { x.SchedulerName, x.TriggerName, x.TriggerGroup })
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
