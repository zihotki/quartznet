using Quartz.EFCore.Sqlite.EntityTypeConfigurations;

namespace Quartz.EFCore.Sqlite
{
    public static class QuartzModelBuilderSqliteSQLExtensions
    {
        public static IQuartzModelBuilder UseSqliteConfiguration(this IQuartzModelBuilder builder)
        {
            builder.UseQuartzEntityConfigurations(context =>
            {
                context.ModelBuilder.ApplyConfiguration(new JobDetailEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new TriggerEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new SimpleTriggerEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new SimplePropertyTriggerEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new CronTriggerEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new BlobTriggerEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new CalendarEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new PausedTriggerGroupEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new FiredTriggerEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new SchedulerStateEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new LockEntityTypeConfiguration(context.Prefix, context.Schema));

                context.ModelBuilder.ApplyConfiguration(new JobExecutionHistoryConfiguration(context.Prefix, context.Schema));
            });

            return builder;
        }
    }
}
