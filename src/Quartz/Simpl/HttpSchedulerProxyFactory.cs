using System;
using System.Collections.Generic;
using System.Net.Http;

using Quartz.Impl.Matchers;
using Quartz.Spi;

namespace Quartz.Simpl
{
    /// <summary>
    /// A <see cref="IRemotableSchedulerProxyFactory" /> implementation that creates
    /// connection to remote scheduler using HTTP.
    /// </summary>
    public class HttpSchedulerProxyFactory : IRemotableSchedulerProxyFactory
    {
        /// <summary>
        /// Gets or sets the remote scheduler address.
        /// </summary>
        /// <value>The remote scheduler address.</value>
        public string? Address { private get; set; }

        /// <summary>
        /// Returns a client proxy to a remote <see cref="IRemotableQuartzScheduler" />.
        /// </summary>
        public IRemotableQuartzScheduler GetProxy()
        {
            if (string.IsNullOrWhiteSpace(Address))
            {
                throw new InvalidOperationException("Address hasn't been configured");
            }

            return new HttpSchedulerProxy(Address);

        }

        /// <summary>
        /// Maps between Quartz API and HTTP REST API.
        /// </summary>
        private class HttpSchedulerProxy : IRemotableQuartzScheduler
        {
            // TODO private readonly HttpClient client;

            public HttpSchedulerProxy(string address)
            {
                /* TODO
                client = new HttpClient
                {
                    BaseAddress = new Uri(address)
                };
                */
            }

            // these we should cache

            // TODO now just to make DirectSchedulerFactory work
            public string SchedulerName => "SimpleQuartzScheduler";
            public string SchedulerInstanceId => "SIMPLE_NON_CLUSTERED";

            public string Version => throw new NotImplementedException();
            public Type JobStoreClass => throw new NotImplementedException();
            public Type ThreadPoolClass => throw new NotImplementedException();
            public int ThreadPoolSize => throw new NotImplementedException();

            public bool SupportsPersistence => throw new NotImplementedException();
            public bool Clustered => throw new NotImplementedException();
            public DateTimeOffset? RunningSince => throw new NotImplementedException();


            // these require a call
            public SchedulerContext SchedulerContext => throw new NotImplementedException();
            public bool InStandbyMode => throw new NotImplementedException();
            public bool IsShutdown => throw new NotImplementedException();
            public IReadOnlyCollection<IJobExecutionContext> CurrentlyExecutingJobs => throw new NotImplementedException();
            public int NumJobsExecuted => throw new NotImplementedException();

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public void Start()
            {
                throw new NotImplementedException();
            }

            public void StartDelayed(TimeSpan delay)
            {
                throw new NotImplementedException();
            }

            public void Standby()
            {
                throw new NotImplementedException();
            }

            public void Shutdown()
            {
                throw new NotImplementedException();
            }

            public void Shutdown(bool waitForJobsToComplete)
            {
                throw new NotImplementedException();
            }

            public DateTimeOffset ScheduleJob(IJobDetail jobDetail, ITrigger trigger)
            {
                throw new NotImplementedException();
            }

            public DateTimeOffset ScheduleJob(ITrigger trigger)
            {
                throw new NotImplementedException();
            }

            public void AddJob(IJobDetail jobDetail, bool replace)
            {
                throw new NotImplementedException();
            }

            public void AddJob(IJobDetail jobDetail, bool replace, bool storeNonDurableWhileAwaitingScheduling)
            {
                throw new NotImplementedException();
            }

            public bool IsJobGroupPaused(string groupName)
            {
                throw new NotImplementedException();
            }

            public bool IsTriggerGroupPaused(string groupName)
            {
                throw new NotImplementedException();
            }

            public bool DeleteJob(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public bool UnscheduleJob(TriggerKey triggerKey)
            {
                throw new NotImplementedException();
            }

            public DateTimeOffset? RescheduleJob(TriggerKey triggerKey, ITrigger newTrigger)
            {
                throw new NotImplementedException();
            }

            public void TriggerJob(JobKey jobKey, JobDataMap? data)
            {
                throw new NotImplementedException();
            }

            public void TriggerJob(IOperableTrigger trig)
            {
                throw new NotImplementedException();
            }

            public void PauseTrigger(TriggerKey triggerKey)
            {
                throw new NotImplementedException();
            }

            public void PauseTriggers(GroupMatcher<TriggerKey> matcher)
            {
                throw new NotImplementedException();
            }

            public void PauseJob(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public void PauseJobs(GroupMatcher<JobKey> matcher)
            {
                throw new NotImplementedException();
            }

            public void ResumeTrigger(TriggerKey triggerKey)
            {
                throw new NotImplementedException();
            }

            public void ResumeTriggers(GroupMatcher<TriggerKey> matcher)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<string> GetPausedTriggerGroups()
            {
                throw new NotImplementedException();
            }

            public void ResumeJob(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public void ResumeJobs(GroupMatcher<JobKey> matcher)
            {
                throw new NotImplementedException();
            }

            public void PauseAll()
            {
                throw new NotImplementedException();
            }

            public void ResumeAll()
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<string> GetJobGroupNames()
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<ITrigger> GetTriggersOfJob(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<string> GetTriggerGroupNames()
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher)
            {
                throw new NotImplementedException();
            }

            public IJobDetail? GetJobDetail(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public ITrigger? GetTrigger(TriggerKey triggerKey)
            {
                throw new NotImplementedException();
            }

            public TriggerState GetTriggerState(TriggerKey triggerKey)
            {
                throw new NotImplementedException();
            }

            public void AddCalendar(string calName, ICalendar calendar, bool replace, bool updateTriggers)
            {
                throw new NotImplementedException();
            }

            public bool DeleteCalendar(string calName)
            {
                throw new NotImplementedException();
            }

            public ICalendar? GetCalendar(string calName)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyCollection<string> GetCalendarNames()
            {
                throw new NotImplementedException();
            }

            public bool Interrupt(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public bool Interrupt(string fireInstanceId)
            {
                throw new NotImplementedException();
            }

            public bool CheckExists(JobKey jobKey)
            {
                throw new NotImplementedException();
            }

            public bool CheckExists(TriggerKey triggerKey)
            {
                throw new NotImplementedException();
            }

            public bool DeleteJobs(IReadOnlyCollection<JobKey> jobKeys)
            {
                throw new NotImplementedException();
            }

            public void ScheduleJobs(IReadOnlyDictionary<IJobDetail, IReadOnlyCollection<ITrigger>> triggersAndJobs, bool replace)
            {
                throw new NotImplementedException();
            }

            public void ScheduleJob(IJobDetail jobDetail, IReadOnlyCollection<ITrigger> triggersForJob, bool replace)
            {
                throw new NotImplementedException();
            }

            public bool UnscheduleJobs(IReadOnlyCollection<TriggerKey> triggerKeys)
            {
                throw new NotImplementedException();
            }
        }
    }
}
