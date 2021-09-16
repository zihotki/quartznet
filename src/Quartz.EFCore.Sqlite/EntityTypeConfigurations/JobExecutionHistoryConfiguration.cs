using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class JobExecutionHistoryConfiguration : IEntityTypeConfiguration<QuartzJobExecutionHistory>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public JobExecutionHistoryConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzJobExecutionHistory> builder)
        {
            builder.ToTable($"{_prefix}JOB_HISTORY", _schema);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnType("BLOB")
                .HasValueGenerator<SequentialGuidValueGenerator>()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.SchedulerName)
                .HasColumnName(QuartzColumnNameConstants.SchedulerName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
                .IsRequired();

            builder.Property(x => x.SchedulerInstanceId)
                .HasColumnName("SCHEDULER_INSTANCE_ID")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
                .IsRequired();

            builder.Property(x => x.FireInstanceId)
                .HasColumnName("FIRE_INSTANCE_ID")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(QuartzColumnLengthConstants.FireInstanceIdLength)
                .IsRequired();

            builder.Property(x => x.JobName)
                .HasColumnName(QuartzColumnNameConstants.JobName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(QuartzColumnLengthConstants.JobNameLength)
                .IsRequired();

            builder.Property(x => x.JobGroup)
                .HasColumnName(QuartzColumnNameConstants.JobGroup)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(QuartzColumnLengthConstants.JobGroupLength)
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

            builder.Property(x => x.ScheduledFireTimeUtc)
                .HasColumnName("SCHEDULED_FIRE_TIME_UTC")
                .HasColumnType("DATETIME");

            builder.Property(x => x.ActualFireTimeUtc)
                .HasColumnName("ACTUAL_FIRE_TIME_UTC")
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.FinishedTimeUtc)
                .HasColumnName("FINISHED_TIME_UTC")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Recovering)
                .HasColumnName("RECOVERING")
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.Vetoed)
                .HasColumnName("VETOED")
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.ExceptionMessage)
                .HasColumnName("EXCEPTION")
                .HasColumnType("TEXT");

            builder.Property(x => x.JobData)
                .HasColumnName(QuartzColumnNameConstants.JobData)
                .HasColumnType("BLOB");

            builder.Property(x => x.TriggerData)
                .HasColumnName(QuartzColumnNameConstants.TriggerData)
                .HasColumnType("BLOB");

            builder.HasIndex(x => x.TriggerName)
                .HasDatabaseName($"IX_{_prefix}JOB_HISTORY_TRIGGER_NAME");

            builder.HasIndex(x => x.TriggerGroup)
                .HasDatabaseName($"IX_{_prefix}JOB_HISTORY_TRIGGER_GROUP");

            builder.HasIndex(x => new { x.SchedulerName, x.TriggerName, x.TriggerGroup })
                .HasDatabaseName($"IX_{_prefix}JOB_HISTORY_SCHED_NAME_TRIGGER_NAME_TRIGGER_GROUP");

            builder.HasIndex(x => x.FireInstanceId)
                .HasDatabaseName($"IX_{_prefix}JOB_HISTORY_INSTANCE_NAME");

            builder.HasIndex(x => x.JobName)
                .HasDatabaseName($"IX_{_prefix}JOB_HISTORY_JOB_NAME");

            builder.HasIndex(x => x.JobGroup)
                .HasDatabaseName($"IX_{_prefix}JOB_HISTORY_JOB_GROUP");
        }
    }
}
