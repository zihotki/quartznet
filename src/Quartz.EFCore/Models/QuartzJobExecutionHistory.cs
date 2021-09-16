using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.EFCore.Models
{
    public class QuartzJobExecutionHistory
    {
        public Guid Id { get; set; }

        public string SchedulerName { get; set; } = null!;

        public string SchedulerInstanceId { get; set; } = null!;

        public string FireInstanceId { get; set; } = null!;

        public string JobName { get; set; } = null!;

        public string JobGroup { get; set; } = null!;

        public string TriggerName { get; set; } = null!;

        public string TriggerGroup { get; set; } = null!;

        public DateTime? ScheduledFireTimeUtc { get; set; }

        public DateTime ActualFireTimeUtc { get; set; }

        public DateTime? FinishedTimeUtc { get; set; }

        public bool Recovering { get; set; }

        public bool Vetoed { get; set; }

        public string? ExceptionMessage { get; set; }

        public byte[]? TriggerData { get; set; }

        public byte[]? JobData { get; set; }
    }
}
