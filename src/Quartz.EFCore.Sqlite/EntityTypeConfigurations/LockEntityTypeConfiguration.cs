using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quartz.EFCore.Models;

namespace Quartz.EFCore.Sqlite.EntityTypeConfigurations
{
    public class LockEntityTypeConfiguration : IEntityTypeConfiguration<QuartzLock>
    {
        private readonly string _prefix;
        private readonly string? _schema;

        public LockEntityTypeConfiguration(string prefix, string? schema)
        {
            _prefix = prefix;
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<QuartzLock> builder)
        {
            builder.ToTable($"{_prefix}LOCKS", _schema);

            builder.HasKey(x => new { x.SchedulerName, x.LockName });

            builder.Property(x => x.SchedulerName)
              .HasColumnName(QuartzColumnNameConstants.SchedulerName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.SchedulerNameLength)
              .IsRequired();

            builder.Property(x => x.LockName)
              .HasColumnName(QuartzColumnNameConstants.LockName)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(QuartzColumnLengthConstants.LockNameLength)
              .IsRequired();
        }
    }
}
