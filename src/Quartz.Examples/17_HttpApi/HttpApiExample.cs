#region License

/*
 * All content copyright Marko Lahma, unless otherwise indicated. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy
 * of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 */

#endregion

#if NETCOREAPP

using System;
using System.Threading.Tasks;

using Quartz.Impl;

namespace Quartz.Examples.Example17
{
    /// <summary>
    /// This example will show hot to run asynchronous jobs.
    /// </summary>
    /// <author>Marko Lahma</author>
    public class HttpApiExample : IExample
    {
        public virtual async Task Run()
        {
            var schedulerHost = await SchedulerBuilder.Create()
                .UseHttpApi()
                .BuildScheduler();

            await schedulerHost.Start();

            Console.WriteLine("------- Initialization Complete -----------");

            Console.WriteLine("------- Scheduling Jobs -------------------");

            DirectSchedulerFactory.Instance.CreateRemoteScheduler("http://localhost:5000");
            var remoteScheduler = await DirectSchedulerFactory.Instance.GetScheduler();

            IJobDetail job = JobBuilder
                .Create<AsyncJob>()
                .WithIdentity("asyncJob")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("triggerForAsyncJob")
                .StartAt(DateTimeOffset.UtcNow.AddSeconds(1))
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(20).RepeatForever())
                .Build();

            await remoteScheduler.ScheduleJob(job, trigger);

            Console.WriteLine("------- Starting Scheduler ----------------");

            // start the schedule
            await remoteScheduler.Start();

            Console.WriteLine("------- Started Scheduler -----------------");

            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("------- Cancelling job via scheduler.Interrupt() -----------------");
            await remoteScheduler.Interrupt(job.Key);

            Console.WriteLine("------- Waiting five minutes... -----------");

            // wait five minutes to give our job a chance to run
            await Task.Delay(TimeSpan.FromMinutes(5));

            // shut down the scheduler
            Console.WriteLine("------- Shutting Down ---------------------");
            await remoteScheduler.Shutdown(true);
            Console.WriteLine("------- Shutdown Complete -----------------");
        }
    }
}

#endif