﻿using System.Collections.Generic;

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
namespace org.activiti.validation.validator.impl
{

    using org.activiti.bpmn.model;

    /// 
    public class IntermediateCatchEventValidator : ProcessLevelValidator
    {

        protected internal override void executeValidation(BpmnModel bpmnModel, Process process, IList<ValidationError> errors)
        {
            IList<IntermediateCatchEvent> intermediateCatchEvents = process.findFlowElementsOfType<IntermediateCatchEvent>();
            foreach (IntermediateCatchEvent intermediateCatchEvent in intermediateCatchEvents)
            {
                EventDefinition eventDefinition = null;
                if (intermediateCatchEvent.EventDefinitions.Count > 0)
                {
                    eventDefinition = intermediateCatchEvent.EventDefinitions[0];
                }

                if (eventDefinition == null)
                {
                    addError(errors, org.activiti.validation.validator.Problems_Fields.INTERMEDIATE_CATCH_EVENT_NO_EVENTDEFINITION, process, intermediateCatchEvent, "No event definition for intermediate catch event ");
                }
                else
                {
                    if (!(eventDefinition is TimerEventDefinition) && !(eventDefinition is SignalEventDefinition) && !(eventDefinition is MessageEventDefinition))
                    {
                        addError(errors, org.activiti.validation.validator.Problems_Fields.INTERMEDIATE_CATCH_EVENT_INVALID_EVENTDEFINITION, process, intermediateCatchEvent, "Unsupported intermediate catch event type");
                    }
                }
            }
        }

    }

}