using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class BlobTriggerEntityTypeConfiguration : IEntityTypeConfiguration<QuartzBlobTrigger>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public BlobTriggerEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzBlobTrigger> builder)
        {
            builder.ToTable($"{_prefix}BLOB_TRIGGERS", _schema);

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

            builder.Property(x => x.BlobData)
              .HasColumnName(QuartzColumnNameConstants.BlobData)
              .HasColumnType("BLOB");

            builder.HasOne(x => x.Trigger)
              .WithMany(x => x.BlobTriggers)
              .HasForeignKey(x => new { x.SchedulerName, x.TriggerName, x.TriggerGroup })
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
