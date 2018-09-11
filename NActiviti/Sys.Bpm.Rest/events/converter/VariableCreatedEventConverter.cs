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

using org.activiti.cloud.services.api.events;
using org.activiti.cloud.services.events.configuration;
using org.activiti.engine.@delegate.@event;
using org.activiti.engine.@delegate.@event.impl;

namespace org.activiti.cloud.services.events.converter
{
    public class VariableCreatedEventConverter : AbstractEventConverter
    {
        public VariableCreatedEventConverter(RuntimeBundleProperties runtimeBundleProperties) : base(runtimeBundleProperties)
        {
        }

        public override ProcessEngineEvent from(IActivitiEvent @event)
        {
            ActivitiVariableEventImpl variableEvent = (ActivitiVariableEventImpl)@event;

            return new VariableCreatedEventImpl(RuntimeBundleProperties.AppName, RuntimeBundleProperties.AppVersion, RuntimeBundleProperties.ServiceName, RuntimeBundleProperties.ServiceFullName, RuntimeBundleProperties.ServiceType, RuntimeBundleProperties.ServiceVersion, @event.ExecutionId, @event.ProcessDefinitionId, @event.ProcessInstanceId, variableEvent.VariableName, (variableEvent.VariableValue != null) ? variableEvent.VariableValue.ToString() : "", (variableEvent.VariableType != null) ? variableEvent.VariableType.TypeName : "", variableEvent.TaskId);
        }

        public override string handledType()
        {
            return ActivitiEventType.VARIABLE_CREATED.ToString();
        }
    }

}