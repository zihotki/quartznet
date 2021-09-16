using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class SchedulerStateEntityTypeConfiguration : IEntityTypeConfiguration<QuartzSchedulerState>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public SchedulerStateEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzSchedulerState> builder)
        {
            builder.ToTable($"{_prefix}SCHEDULER_STATE", _schema);

            builder.HasKey(x => new { x.SchedulerName, x.InstanceName });

            builder.Property(x => x.SchedulerName)
              .HasColumnName(QuartzColumnNameConstants.SchedulerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
              .IsRequired();

            builder.Property(x => x.InstanceName)
              .HasColumnName(QuartzColumnNameConstants.InstanceName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.InstanceNameLength)
              .IsRequired();

            builder.Property(x => x.LastCheckInTime)
              .HasColumnName(QuartzColumnNameConstants.LastCheckingTime)
              .HasColumnType("BIGINT")
              .IsRequired();

            builder.Property(x => x.CheckInInterval)
              .HasColumnName(QuartzColumnNameConstants.CheckinInterval)
              .HasColumnType("BIGINT")
              .IsRequired();
        }
    }
}
