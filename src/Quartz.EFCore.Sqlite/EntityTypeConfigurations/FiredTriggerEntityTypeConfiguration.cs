using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class FiredTriggerEntityTypeConfiguration : IEntityTypeConfiguration<QuartzFiredTrigger>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public FiredTriggerEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzFiredTrigger> builder)
        {
            builder.ToTable($"{_prefix}FIRED_TRIGGERS", _schema);

            builder.HasKey(x => new { x.SchedulerName, x.EntryId });

            builder.Property(x => x.SchedulerName)
              .HasColumnName(QuartzColumnNameConstants.SchedulerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
              .IsRequired();

            builder.Property(x => x.EntryId)
              .HasColumnName(QuartzColumnNameConstants.EntryId)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.EntryIdLength)
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

            builder.Property(x => x.InstanceName)
              .HasColumnName(QuartzColumnNameConstants.InstanceName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.InstanceNameLength)
              .IsRequired();

            builder.Property(x => x.FiredTime)
              .HasColumnName(QuartzColumnNameConstants.FiredTime)
              .HasColumnType("BIGINT")
              .IsRequired();

            builder.Property(x => x.ScheduledTime)
              .HasColumnName(QuartzColumnNameConstants.SchedTime)
              .HasColumnType("BIGINT")
              .IsRequired();

            builder.Property(x => x.Priority)
              .HasColumnName(QuartzColumnNameConstants.Priority)
              .HasColumnType("INTEGER")
              .IsRequired();

            builder.Property(x => x.State)
              .HasColumnName(QuartzColumnNameConstants.StateName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.StateLength)
              .IsRequired();

            builder.Property(x => x.JobName)
              .HasColumnName(QuartzColumnNameConstants.JobName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.JobNameLength);

            builder.Property(x => x.JobGroup)
              .HasColumnName(QuartzColumnNameConstants.JobGroup)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.JobGroupLength);

            builder.Property(x => x.IsNonConcurrent)
              .HasColumnName(QuartzColumnNameConstants.IsNonconcurrent)
              .HasColumnType("BIT")
              .IsRequired();

            builder.Property(x => x.RequestsRecovery)
              .HasColumnName(QuartzColumnNameConstants.RequestsRecovery)
              .HasColumnType("BIT");


            builder.HasIndex(x => x.TriggerName)
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_TRIGGER_NAME");

            builder.HasIndex(x => x.TriggerGroup)
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_TRIGGER_GROUP");

            builder.HasIndex(x => new { x.SchedulerName, x.TriggerName, x.TriggerGroup })
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_SCHED_NAME_TRIGGER_NAME_TRIGGER_GROUP");

            builder.HasIndex(x => x.InstanceName)
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_INSTANCE_NAME");

            builder.HasIndex(x => x.JobName)
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_JOB_NAME");

            builder.HasIndex(x => x.JobGroup)
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_JOB_GROUP");

            builder.HasIndex(x => x.RequestsRecovery)
              .HasDatabaseName($"IX_{_prefix}FIRED_TRIGGERS_REQUESTS_RECOVERY");
        }
    }
}
