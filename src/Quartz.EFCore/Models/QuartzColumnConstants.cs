namespace Quartz.EFCore.Models
{
    public static class QuartzColumnLengthConstants
    {
        public const int SchedulerNameLength = 120;

        public const int TriggerNameLength = 150;

        public const int TriggerGroupLength = 150;

        public const int JobNameLength = 150;

        public const int JobGroupLength = 150;

        public const int DescriptionLength = 250;

        public const int JobClassNameLength = 250;

        public const int TriggerStateLength = 16;

        public const int StateLength = TriggerStateLength;

        public const int TriggerTypeLength = 8;

        public const int CalendarNameLength = 200;

        public const int CronExpressionLength = 250;

        public const int TimeZoneIdLength = 80;

        public const int EntryIdLength = 140;

        public const int InstanceNameLength = 200;

        public const int FireInstanceIdLength = InstanceNameLength + 20 /* in Quartz long counter is used as a suffix for this field */ ;

        public const int LockNameLength = 40;

        public const int StrPropLength = 512;
    }
}
