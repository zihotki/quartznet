using System;

namespace Quartz.EFCore
{
    public class QuartzModelBuilder : IQuartzModelBuilder
    {
        private readonly QuartzModelConfiguration _quartzConfig;

        public QuartzModelBuilder(QuartzModelConfiguration quartzConfig)
        {
            _quartzConfig = quartzConfig;
        }

        public IQuartzModelBuilder UsePrefix(string prefix)
        {
            _quartzConfig.Prefix = prefix;

            return this;
        }

        public IQuartzModelBuilder UseSchema(string schema)
        {
            _quartzConfig.Schema = schema;

            return this;
        }

        public IQuartzModelBuilder UseQuartzEntityConfigurations(Action<QuartzEntitiesConfigurationContext> entityTypeConfigurations)
        {
            _quartzConfig.QuartzEntityConfigurations = entityTypeConfigurations;

            return this;
        }
    }
}
