using System;
using System.Configuration;
using System.Threading;
using log4net.Config;
using log4net;
using Common.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Job;
namespace CDRService
{
    class CDRCronTrigger
    {
        log4net.ILog _logger = log4net.LogManager.GetLogger("File");
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public virtual void Run()
        {
            //Set Adapter
            _logger.Info("------- Initializing -------------------");

            // First we must get a reference to a scheduler
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sched = sf.GetScheduler();

            _logger.Info("------- Initialization Complete --------");

            _logger.Info("------- Scheduling Jobs ----------------");

            // jobs can be scheduled before sched.start() has been called

            JobDetail job = new JobDetail("job1", "group1", typeof(CDRJob));
            string cronExpression = ConfigurationSettings.AppSettings["cronExpression"];
            CronTrigger trigger = new CronTrigger("trigger1", "group1", "job1", "group1", cronExpression);
            sched.AddJob(job, true);
            DateTime ft = sched.ScheduleJob(trigger);
#if !NET_35
            ft = trigger.TimeZone.ToLocalTime(ft);
#else
		    ft = TimeZoneInfo.ConvertTimeFromUtc(ft, trigger.TimeZone);
#endif
            _logger.Info(string.Format("{0} has been scheduled to run at: {1} and repeat based on expression: {2}", job.FullName, ft.ToString("r"), trigger.CronExpressionString));

            _logger.Info("------- Starting Scheduler ----------------");

            // All of the jobs have been added to the scheduler, but none of the
            // jobs
            // will run until the scheduler has been started
            sched.Start();

            try
            {
                // wait 5 seconds to show jobs
                Thread.Sleep(5 * 1000);
                // executing...
            }
            catch (ThreadInterruptedException)
            {
            }
            SchedulerMetaData metaData = sched.GetMetaData();
            _logger.Info(string.Format("Executed {0} jobs.", metaData.NumJobsExecuted));
        }
    }
}
