using System;
using Microsoft.EntityFrameworkCore;

namespace Quartz.EFCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddQuartz(this ModelBuilder modelBuilder, Action<IQuartzModelBuilder>? configure)
        {
            var model = new QuartzModelConfiguration();
            configure?.Invoke(new QuartzModelBuilder(model));

            if (model.QuartzEntityConfigurations is null)
            {
                throw new ArgumentException($"No database provider specified. Did you forget to call `.UseSqlite()` in `{nameof(configure)}` action?");
            }

            model.QuartzEntityConfigurations.Invoke(new QuartzEntitiesConfigurationContext(model.Prefix, model.Schema, modelBuilder));

            return modelBuilder;
        }
    }
}
