﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class SimplePropertyTriggerEntityTypeConfiguration : IEntityTypeConfiguration<QuartzSimplePropertyTrigger>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public SimplePropertyTriggerEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzSimplePropertyTrigger> builder)
        {
            builder.ToTable($"{_prefix}SIMPROP_TRIGGERS", _schema);

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

            builder.Property(x => x.StringProperty1)
              .HasColumnName(QuartzColumnNameConstants.StrProp1)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.StrPropLength);

            builder.Property(x => x.StringProperty2)
              .HasColumnName(QuartzColumnNameConstants.StrProp2)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.StrPropLength);

            builder.Property(x => x.StringProperty3)
              .HasColumnName(QuartzColumnNameConstants.StrProp3)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.StrPropLength);

            builder.Property(x => x.IntegerProperty1)
              .HasColumnName(QuartzColumnNameConstants.IntProp1)
              .HasColumnType("INT");

            builder.Property(x => x.IntegerProperty2)
              .HasColumnName(QuartzColumnNameConstants.IntProp2)
              .HasColumnType("INT");

            builder.Property(x => x.LongProperty1)
              .HasColumnName(QuartzColumnNameConstants.LongProp1)
              .HasColumnType("BIGINT");

            builder.Property(x => x.LongProperty2)
              .HasColumnName(QuartzColumnNameConstants.LongProp2)
              .HasColumnType("BIGINT");

            builder.Property(x => x.DecimalProperty1)
              .HasColumnName(QuartzColumnNameConstants.DecProp1)
              .HasColumnType("NUMERIC");

            builder.Property(x => x.DecimalProperty2)
              .HasColumnName(QuartzColumnNameConstants.DecProp2)
              .HasColumnType("NUMERIC");

            builder.Property(x => x.BooleanProperty1)
              .HasColumnName(QuartzColumnNameConstants.BoolProp1)
              .HasColumnType("BIT");

            builder.Property(x => x.BooleanProperty2)
              .HasColumnName(QuartzColumnNameConstants.BoolProp2)
              .HasColumnType("BIT");

            builder.Property(x => x.TimeZoneId)
              .HasColumnName(QuartzColumnNameConstants.TimeZoneId)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.TimeZoneIdLength);

            builder.HasOne(x => x.Trigger)
              .WithMany(x => x.SimplePropertyTriggers)
              .HasForeignKey(x => new { x.SchedulerName, x.TriggerName, x.TriggerGroup })
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}