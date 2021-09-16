using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class TriggerEntityTypeConfiguration : IEntityTypeConfiguration<QuartzTrigger>
    {
        private readonly string? _prefix;
        private readonly string? _schema;

        public TriggerEntityTypeConfiguration(string? prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzTrigger> builder)
        {
            builder.ToTable($"{_prefix}TRIGGERS", _schema);

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

            builder.Property(x => x.Description)
              .HasColumnName(QuartzColumnNameConstants.Description)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.DescriptionLength);

            builder.Property(x => x.NextFireTime)
              .HasColumnName(QuartzColumnNameConstants.NextFireTime)
              .HasColumnType("BIGINT");

            builder.Property(x => x.PreviousFireTime)
              .HasColumnName(QuartzColumnNameConstants.PrevFireTime)
              .HasColumnType("BIGINT");

            builder.Property(x => x.Priority)
              .HasColumnName(QuartzColumnNameConstants.Priority)
              .HasColumnType("INTEGER");

            builder.Property(x => x.TriggerState)
              .HasColumnName(QuartzColumnNameConstants.TriggerState)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.TriggerStateLength)
              .IsRequired();

            builder.Property(x => x.TriggerType)
              .HasColumnName(QuartzColumnNameConstants.TriggerType)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.TriggerTypeLength)
              .IsRequired();

            builder.Property(x => x.StartTime)
              .HasColumnName(QuartzColumnNameConstants.StartTime)
              .HasColumnType("BIGINT")
              .IsRequired();

            builder.Property(x => x.EndTime)
              .HasColumnName(QuartzColumnNameConstants.EndTime)
              .HasColumnType("BIGINT");

            builder.Property(x => x.CalendarName)
              .HasColumnName(QuartzColumnNameConstants.CalendarName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.CalendarNameLength);

            builder.Property(x => x.MisfireInstruction)
              .HasColumnName(QuartzColumnNameConstants.MisfireInstr)
              .HasColumnType("INTEGER");

            builder.Property(x => x.JobData)
              .HasColumnName(QuartzColumnNameConstants.JobData)
              .HasColumnType("BLOB");

            builder.HasOne(x => x.JobDetail)
              .WithMany(x => x.Triggers)
              .HasForeignKey(x => new { x.SchedulerName, x.JobName, x.JobGroup })
              .IsRequired();

            builder.HasIndex(x => x.NextFireTime)
              .HasDatabaseName($"IX_{_prefix}TRIGGERS_NEXT_FIRE_TIME");

            builder.HasIndex(x => x.TriggerState)
              .HasDatabaseName($"IX_{_prefix}TRIGGERS_TRIGGER_STATE");

            builder.HasIndex(x => new { x.NextFireTime, x.TriggerState })
              .HasDatabaseName($"IX_{_prefix}TRIGGERS_NEXT_FIRE_TIME_TRIGGER_STATE");

            // Looks like triggers to enfoce FK cascade deletes are not needed since 
            // EF Core 3+ uses dlls compiled with enabled FK constraints.
            /*
            builder.BeforeDelete(trigger => trigger.Action(action =>
                action!.Delete<QuartzSimpleTrigger>((deleted, simpleTrigger) =>
                    deleted.SchedulerName == simpleTrigger.SchedulerName
                    && deleted.TriggerName == simpleTrigger.TriggerName
                    && deleted.TriggerGroup == simpleTrigger.TriggerGroup
                )
                .Delete<QuartzSimplePropertyTrigger>((deleted, simpleTrigger) =>
                    deleted.SchedulerName == simpleTrigger.SchedulerName
                    && deleted.TriggerName == simpleTrigger.TriggerName
                    && deleted.TriggerGroup == simpleTrigger.TriggerGroup
                )
                .Delete<QuartzCronTrigger>((deleted, simpleTrigger) =>
                    deleted.SchedulerName == simpleTrigger.SchedulerName
                    && deleted.TriggerName == simpleTrigger.TriggerName
                    && deleted.TriggerGroup == simpleTrigger.TriggerGroup
                )
                .Delete<QuartzBlobTrigger>((deleted, simpleTrigger) =>
                    deleted.SchedulerName == simpleTrigger.SchedulerName
                    && deleted.TriggerName == simpleTrigger.TriggerName
                    && deleted.TriggerGroup == simpleTrigger.TriggerGroup
                )
            ));
            */
        }
    }
}
