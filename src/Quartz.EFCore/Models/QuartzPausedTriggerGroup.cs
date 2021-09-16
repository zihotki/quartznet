namespace Quartz.EFCore.Models
{
    public class QuartzPausedTriggerGroup
    {
        public string SchedulerName { get; set; } = null!;

        public string TriggerGroup { get; set; } = null!;
    }
}
