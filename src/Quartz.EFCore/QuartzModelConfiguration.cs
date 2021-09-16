using System;

namespace Quartz.EFCore
{
    public class QuartzModelConfiguration
    {
        private const string DefaultPrefix = "QRTZ_";

        private string _prefix = DefaultPrefix;

        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = string.IsNullOrWhiteSpace(value) ? DefaultPrefix : value; }
        }

        public string? Schema { get; set; }

        public Action<QuartzEntitiesConfigurationContext>? QuartzEntityConfigurations { get; set; }
    }
}
