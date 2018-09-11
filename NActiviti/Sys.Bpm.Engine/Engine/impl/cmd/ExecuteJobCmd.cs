﻿using System;

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
namespace org.activiti.engine.impl.cmd
{
    using Microsoft.Extensions.Logging;
    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.impl.jobexecutor;
    using org.activiti.engine.impl.util;
    using org.activiti.engine.runtime;
    using Sys;
    using System.Collections.Generic;

    /// 
    /// 
    [Serializable]
    public class ExecuteJobCmd : ICommand<object>
    {
        private static readonly ILogger<ExecuteJobCmd> log = ProcessEngineServiceProvider.LoggerService<ExecuteJobCmd>();

        private const long serialVersionUID = 1L;

        protected internal string jobId;

        public ExecuteJobCmd(string jobId)
        {
            this.jobId = jobId;
        }

        public virtual object execute(ICommandContext commandContext)
        {
            if (string.ReferenceEquals(jobId, null))
            {
                throw new ActivitiIllegalArgumentException("jobId and job is null");
            }

            IJob job = commandContext.JobEntityManager.findById<IJob>(new KeyValuePair<string, object>("id", jobId));

            if (job == null)
            {
                throw new JobNotFoundException(jobId);
            }

            if (log.IsEnabled(LogLevel.Debug))
            {
                log.LogDebug($"Executing job {job.Id}");
            }

            commandContext.addCloseListener(new FailedJobListener(commandContext.ProcessEngineConfiguration.CommandExecutor, job));

            try
            {
                commandContext.JobManager.execute(job);
            }
            catch (Exception exception)
            {
                // Finally, Throw the exception to indicate the ExecuteJobCmd failed
                throw new ActivitiException("Job " + jobId + " failed", exception);
            }

            return null;
        }

        public virtual string JobId
        {
            get
            {
                return jobId;
            }
        }

    }

}