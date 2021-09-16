using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class JobDetailEntityTypeConfiguration : IEntityTypeConfiguration<QuartzJobDetail>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public JobDetailEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzJobDetail> builder)
        {
            builder.ToTable($"{_prefix}JOB_DETAILS", _schema);

            builder.HasKey(x => new { x.SchedulerName, x.JobName, x.JobGroup });

            builder.Property(x => x.SchedulerName)
              .HasColumnName(QuartzColumnNameConstants.SchedulerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
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

            builder.Property(x => x.JobClassName)
              .HasColumnName(QuartzColumnNameConstants.JobClassName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.JobClassNameLength)
              .IsRequired();

            builder.Property(x => x.IsDurable)
              .HasColumnName(QuartzColumnNameConstants.IsDurable)
              .HasColumnType("BIT")
              .IsRequired();

            builder.Property(x => x.IsNonConcurrent)
              .HasColumnName(QuartzColumnNameConstants.IsNonconcurrent)
              .HasColumnType("BIT")
              .IsRequired();

            builder.Property(x => x.IsUpdateData)
              .HasColumnName(QuartzColumnNameConstants.IsUpdateData)
              .HasColumnType("BIT")

              .IsRequired();

            builder.Property(x => x.RequestsRecovery)
              .HasColumnName(QuartzColumnNameConstants.RequestsRecovery)
              .HasColumnType("BIT")
              .IsRequired();

            builder.Property(x => x.JobData)
              .HasColumnName(QuartzColumnNameConstants.JobData)
              .HasColumnType("BLOB");
        }
    }
}
