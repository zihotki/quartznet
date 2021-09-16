using System;

namespace Quartz.EFCore
{
    public interface IQuartzModelBuilder
    {
        IQuartzModelBuilder UsePrefix(string prefix);

        IQuartzModelBuilder UseSchema(string schema);

        IQuartzModelBuilder UseQuartzEntityConfigurations(Action<QuartzEntitiesConfigurationContext> entityTypeConfigurations);
    }
}
