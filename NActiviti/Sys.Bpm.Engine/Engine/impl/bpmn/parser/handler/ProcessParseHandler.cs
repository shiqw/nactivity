﻿using System;
using System.Collections.Generic;

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
namespace Sys.Workflow.Engine.Impl.Bpmn.Parser.Handlers
{
    using Microsoft.Extensions.Logging;
    using Sys.Workflow.Bpmn.Models;
    using Sys.Workflow.Engine.Delegate.Events;
    using Sys.Workflow.Engine.Delegate.Events.Impl;
    using Sys.Workflow.Engine.Impl.Contexts;
    using Sys.Workflow.Engine.Impl.Persistence.Entity;

    /// 
    public class ProcessParseHandler : AbstractBpmnParseHandler<Process>
    {
        public const string PROPERTYNAME_DOCUMENTATION = "documentation";

        protected internal override Type HandledType
        {
            get
            {
                return typeof(Process);
            }
        }

        protected internal override void ExecuteParse(BpmnParse bpmnParse, Process process)
        {
            if (process.Executable == false)
            {
                logger.LogInformation("Ignoring non-executable process with id='" + process.Id + "'. Set the attribute isExecutable=\"true\" to deploy this process.");
            }
            else
            {
                bpmnParse.ProcessDefinitions.Add(TransformProcess(bpmnParse, process));
            }
        }

        protected internal virtual IProcessDefinitionEntity TransformProcess(BpmnParse bpmnParse, Process process)
        {
            IProcessDefinitionEntity currentProcessDefinition = Context.CommandContext.ProcessDefinitionEntityManager.Create();
            bpmnParse.CurrentProcessDefinition = currentProcessDefinition;

            /*
             * Mapping object model - bpmn xml: processDefinition.id -> generated by activiti engine processDefinition.key -> bpmn id (required) processDefinition.name -> bpmn name (optional)
             */
            currentProcessDefinition.Key = process.Id;
            currentProcessDefinition.Name = process.Name;
            currentProcessDefinition.Category = bpmnParse.BpmnModel.TargetNamespace;
            currentProcessDefinition.Description = process.Documentation;
            currentProcessDefinition.DeploymentId = bpmnParse.Deployment.Id;

            if (!(bpmnParse.Deployment.EngineVersion is null))
            {
                currentProcessDefinition.EngineVersion = bpmnParse.Deployment.EngineVersion;
            }

            CreateEventListeners(bpmnParse, process.EventListeners);

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug($"Parsing process {currentProcessDefinition.Key}");
            }

            bpmnParse.ProcessFlowElements(process.FlowElements);
            ProcessArtifacts(bpmnParse, process.Artifacts);

            return currentProcessDefinition;
        }

        protected internal virtual void CreateEventListeners(BpmnParse bpmnParse, IList<EventListener> eventListeners)
        {

            if (eventListeners != null && eventListeners.Count > 0)
            {
                foreach (EventListener eventListener in eventListeners)
                {
                    // Extract specific event-types (if any)
                    ActivitiEventType[] types = ActivitiEventType.GetTypesFromString(eventListener.Events);

                    if (ImplementationType.IMPLEMENTATION_TYPE_CLASS.Equals(eventListener.ImplementationType))
                    {
                        GetEventSupport(bpmnParse.BpmnModel).AddEventListener(bpmnParse.ListenerFactory.CreateClassDelegateEventListener(eventListener), types);

                    }
                    else if (ImplementationType.IMPLEMENTATION_TYPE_DELEGATEEXPRESSION.Equals(eventListener.ImplementationType))
                    {
                        GetEventSupport(bpmnParse.BpmnModel).AddEventListener(bpmnParse.ListenerFactory.CreateDelegateExpressionEventListener(eventListener), types);

                    }
                    else if (ImplementationType.IMPLEMENTATION_TYPE_THROW_SIGNAL_EVENT.Equals(eventListener.ImplementationType) || ImplementationType.IMPLEMENTATION_TYPE_THROW_GLOBAL_SIGNAL_EVENT.Equals(eventListener.ImplementationType) || ImplementationType.IMPLEMENTATION_TYPE_THROW_MESSAGE_EVENT.Equals(eventListener.ImplementationType) || ImplementationType.IMPLEMENTATION_TYPE_THROW_ERROR_EVENT.Equals(eventListener.ImplementationType))
                    {

                        GetEventSupport(bpmnParse.BpmnModel).AddEventListener(bpmnParse.ListenerFactory.CreateEventThrowingEventListener(eventListener), types);

                    }
                    else
                    {
                        logger.LogWarning("Unsupported implementation type for EventListener: " + eventListener.ImplementationType + " for element " + bpmnParse.CurrentFlowElement.Id);
                    }
                }
            }

        }

        protected internal virtual ActivitiEventSupport GetEventSupport(BpmnModel bpmnModel)
        {
            return (ActivitiEventSupport)bpmnModel.EventSupport;
        }
    }
}