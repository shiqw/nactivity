﻿/*
 * Copyright 2018 Alfresco, Inc. and/or its affiliates.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Sys.Workflow.Cloud.Services.Api.Events;
using Sys.Workflow.Cloud.Services.Events.Configurations;
using Sys.Workflow.Engine.Delegate.Events;

namespace Sys.Workflow.Cloud.Services.Events.Converters
{

    /// <summary>
    /// 
    /// </summary>
    public class ActivityCompletedEventConverter : AbstractEventConverter
    {

        /// <summary>
        /// 
        /// </summary>
        public ActivityCompletedEventConverter(RuntimeBundleProperties runtimeBundleProperties) : base(runtimeBundleProperties)
        {
        }

        /// <summary>
        /// 
        /// </summary>

        public override IProcessEngineEvent From(IActivitiEvent @event)
        {
            return new ActivityCompletedEventImpl(RuntimeBundleProperties.AppName, RuntimeBundleProperties.AppVersion, RuntimeBundleProperties.ServiceName, RuntimeBundleProperties.ServiceFullName, RuntimeBundleProperties.ServiceType, RuntimeBundleProperties.ServiceVersion, @event.ExecutionId, @event.ProcessDefinitionId, @event.ProcessInstanceId, ((IActivitiActivityEvent)@event).ActivityId, ((IActivitiActivityEvent)@event).ActivityName, ((IActivitiActivityEvent)@event).ActivityType);
        }

        /// <summary>
        /// 
        /// </summary>

        public override string HandledType()
        {
            return ActivitiEventType.ACTIVITY_COMPLETED.ToString();
        }
    }

}