﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Quartz.HttpApi.Contract;
using Quartz.Impl;

namespace Quartz.HttpApi.Controllers
{
    [Route("schedulers/{schedulerName}/calendars")]
    public class CalendarsController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IReadOnlyCollection<string>> Calendars(string schedulerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var calendarNames = await scheduler.GetCalendarNames().ConfigureAwait(false);

            return calendarNames;
        }

        [HttpGet]
        [Route("{calendarName}")]
        public async Task<IActionResult> CalendarDetails(string schedulerName, string calendarName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var calendar = await scheduler.GetCalendar(calendarName).ConfigureAwait(false);
            if (calendar is null)
            {
                return NotFound();
            }
            return Ok(CalendarDetailDto.Create(calendar));
        }

        [HttpPut]
        [Route("{calendarName}")]
        public async Task AddCalendar(string schedulerName, string calendarName, bool replace, bool updateTriggers)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            // TODO ICalendar calendar = null;
            // TODO await scheduler.AddCalendar(calendarName, calendar, replace, updateTriggers).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{calendarName}")]
        public async Task DeleteCalendar(string schedulerName, string calendarName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.DeleteCalendar(calendarName).ConfigureAwait(false);
        }

        private static async Task<IScheduler> GetScheduler(string schedulerName)
        {
            var scheduler = await SchedulerRepository.Instance.Lookup(schedulerName).ConfigureAwait(false);
            if (scheduler == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                throw new KeyNotFoundException($"Scheduler {schedulerName} not found!");
            }
            return scheduler;
        }
    }
}