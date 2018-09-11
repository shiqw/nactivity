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

namespace org.activiti.engine.impl.bpmn.behavior
{

    using org.activiti.bpmn.model;
    using org.activiti.engine.impl.context;
    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.impl.persistence.entity;

    /// <summary>
    /// Implementation of the BPMN 2.0 event subprocess message start event.
    /// 
    /// 
    /// </summary>
    [Serializable]
    public class EventSubProcessMessageStartEventActivityBehavior : AbstractBpmnActivityBehavior
    {

        private const long serialVersionUID = 1L;

        protected internal MessageEventDefinition messageEventDefinition;

        public EventSubProcessMessageStartEventActivityBehavior(MessageEventDefinition messageEventDefinition)
        {
            this.messageEventDefinition = messageEventDefinition;
        }

        public override void execute(IExecutionEntity execution)
        {
            StartEvent startEvent = (StartEvent)execution.CurrentFlowElement;
            EventSubProcess eventSubProcess = (EventSubProcess)startEvent.SubProcess;

            execution.IsScope = true;

            // initialize the template-defined data objects as variables
            IDictionary<string, object> dataObjectVars = processDataObjects(eventSubProcess.DataObjects);
            if (dataObjectVars != null)
            {
                execution.VariablesLocal = dataObjectVars;
            }
        }

        public override void trigger(IExecutionEntity execution, string triggerName, object triggerData)
        {
            ICommandContext commandContext = Context.CommandContext;
            IExecutionEntityManager executionEntityManager = commandContext.ExecutionEntityManager;

            StartEvent startEvent = (StartEvent)execution.CurrentFlowElement;
            if (startEvent.Interrupting)
            {
                IList<IExecutionEntity> childExecutions = executionEntityManager.findChildExecutionsByParentExecutionId(execution.ParentId);
                foreach (IExecutionEntity childExecution in childExecutions)
                {
                    if (!childExecution.Id.Equals(execution.Id))
                    {
                        executionEntityManager.deleteExecutionAndRelatedData(childExecution, org.activiti.engine.history.DeleteReason_Fields.EVENT_SUBPROCESS_INTERRUPTING + "(" + startEvent.Id + ")", false);
                    }
                }
            }

            IEventSubscriptionEntityManager eventSubscriptionEntityManager = Context.CommandContext.EventSubscriptionEntityManager;
            IList<IEventSubscriptionEntity> eventSubscriptions = execution.EventSubscriptions;
            foreach (IEventSubscriptionEntity eventSubscription in eventSubscriptions)
            {
                if (eventSubscription is IMessageEventSubscriptionEntity && eventSubscription.EventName.Equals(messageEventDefinition.MessageRef))
                {

                    eventSubscriptionEntityManager.delete(eventSubscription);
                }
            }

            execution.CurrentFlowElement = (SubProcess)execution.CurrentFlowElement.ParentContainer;
            execution.IsScope = true;

            IExecutionEntity outgoingFlowExecution = executionEntityManager.createChildExecution(execution);
            outgoingFlowExecution.CurrentFlowElement = startEvent;

            leave(outgoingFlowExecution);
        }

        protected internal virtual IDictionary<string, object> processDataObjects(ICollection<ValuedDataObject> dataObjects)
        {
            IDictionary<string, object> variablesMap = new Dictionary<string, object>();
            // convert data objects to process variables
            if (dataObjects != null)
            {
                foreach (ValuedDataObject dataObject in dataObjects)
                {
                    variablesMap[dataObject.Name] = dataObject.Value;
                }
            }
            return variablesMap;
        }
    }

}