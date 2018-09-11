﻿using System;
using System.Threading;

/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace org.activiti.engine.impl.asyncexecutor
{

    using org.activiti.engine.impl.cmd;
    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.impl.persistence.entity;

    /// 
    /// 
    public class AcquireAsyncJobsDueRunnable
    {

        //private static Logger log = LoggerFactory.getLogger(typeof(AcquireAsyncJobsDueRunnable));

        protected internal readonly IAsyncExecutor asyncExecutor;

        protected internal volatile bool isInterrupted;
        protected internal readonly object MONITOR = new object();
        protected internal bool isWaiting = false;// new AtomicBoolean(false);

        protected internal long millisToWait;

        protected internal ThreadStart Runable { get; private set; }

        public AcquireAsyncJobsDueRunnable(IAsyncExecutor asyncExecutor)
        {
            this.asyncExecutor = asyncExecutor;

            this.Runable += new ThreadStart(run);
        }

        public virtual void run()
        {
            lock (this)
            {
                //log.info("{} starting to acquire async jobs due");
                Thread.CurrentThread.Name = "activiti-acquire-async-jobs";

                ICommandExecutor commandExecutor = asyncExecutor.ProcessEngineConfiguration.CommandExecutor;

                while (!isInterrupted)
                {

                    try
                    {
                        AcquiredJobEntities acquiredJobs = commandExecutor.execute(new AcquireJobsCmd(asyncExecutor));

                        bool allJobsSuccessfullyOffered = true;
                        foreach (IJobEntity job in acquiredJobs.Jobs)
                        {
                            bool jobSuccessFullyOffered = asyncExecutor.executeAsyncJob(job);
                            if (!jobSuccessFullyOffered)
                            {
                                allJobsSuccessfullyOffered = false;
                            }
                        }

                        // If all jobs are executed, we check if we got back the amount we expected
                        // If not, we will wait, as to not query the database needlessly. 
                        // Otherwise, we set the wait time to 0, as to query again immediately.
                        millisToWait = asyncExecutor.DefaultAsyncJobAcquireWaitTimeInMillis;
                        int jobsAcquired = acquiredJobs.size();
                        if (jobsAcquired >= asyncExecutor.MaxAsyncJobsDuePerAcquisition)
                        {
                            millisToWait = 0;
                        }

                        // If the queue was full, we wait too (even if we got enough jobs back), as not overload the queue
                        if (millisToWait == 0 && !allJobsSuccessfullyOffered)
                        {
                            millisToWait = asyncExecutor.DefaultQueueSizeFullWaitTimeInMillis;
                        }

                    }
                    catch (ActivitiOptimisticLockingException optimisticLockingException)
                    {
                        //if (log.DebugEnabled)
                        //{
                        //    log.debug("Optimistic locking exception during async job acquisition. If you have multiple async executors running against the same database, " + "this exception means that this thread tried to acquire a due async job, which already was acquired by another async executor acquisition thread." + "This is expected behavior in a clustered environment. " + "You can ignore this message if you indeed have multiple async executor acquisition threads running against the same database. " + "Exception message: {}", optimisticLockingException.Message);
                        //}
                    }
                    catch (Exception e)
                    {
                        //log.error("exception during async job acquisition: {}", e.Message, e);
                        millisToWait = asyncExecutor.DefaultAsyncJobAcquireWaitTimeInMillis;
                    }

                    if (millisToWait > 0)
                    {
                        try
                        {
                            //if (log.DebugEnabled)
                            //{
                            //    log.debug("async job acquisition thread sleeping for {} millis", millisToWait);
                            //}
                            lock (MONITOR)
                            {
                                if (!isInterrupted)
                                {
                                    isWaiting = true;//.set(true);
                                    Monitor.Wait(MONITOR, TimeSpan.FromMilliseconds(millisToWait));
                                }
                            }

                            //if (log.DebugEnabled)
                            //{
                            //    log.debug("async job acquisition thread woke up");
                            //}
                        }
                        catch (ThreadInterruptedException e)
                        {
                            //if (log.DebugEnabled)
                            //{
                            //    log.debug("async job acquisition wait interrupted");
                            //}
                        }
                        finally
                        {
                            isWaiting = false;//.set(false);
                        }
                    }
                }

                //log.info("{} stopped async job due acquisition");
            }
        }

        public virtual void stop()
        {
            lock (MONITOR)
            {
                isInterrupted = true;
                if (isWaiting == true) //.compareAndSet(true, false))
                {
                    Monitor.PulseAll(MONITOR);
                }
            }
        }

        public virtual long MillisToWait
        {
            get
            {
                return millisToWait;
            }
            set
            {
                this.millisToWait = value;
            }
        }

    }

}