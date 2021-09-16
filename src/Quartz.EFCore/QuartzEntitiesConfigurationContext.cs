using Microsoft.EntityFrameworkCore;

namespace Quartz.EFCore
{
    public readonly struct QuartzEntitiesConfigurationContext
    {
        public string Prefix { get; }

        public string? Schema { get; }

        public ModelBuilder ModelBuilder { get; }

        public QuartzEntitiesConfigurationContext(string prefix, string? schema, ModelBuilder modelBuilder)
        {
            Prefix = prefix;
            Schema = schema;
            ModelBuilder = modelBuilder;
        }
    }
}
