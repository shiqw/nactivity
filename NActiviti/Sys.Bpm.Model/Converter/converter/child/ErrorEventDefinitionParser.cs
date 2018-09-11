﻿/* Licensed under the Apache License, Version 2.0 (the "License");
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
namespace org.activiti.bpmn.converter.child
{

    using org.activiti.bpmn.converter.util;
    using org.activiti.bpmn.model;

    public class ErrorEventDefinitionParser : BaseChildElementParser
    {

        public override string ElementName
        {
            get
            {
                return org.activiti.bpmn.constants.BpmnXMLConstants.ELEMENT_EVENT_ERRORDEFINITION;
            }
        }
        public override void parseChildElement(XMLStreamReader xtr, BaseElement parentElement, BpmnModel model)
        {
            if (!(parentElement is Event))
            {
                return;
            }

            ErrorEventDefinition eventDefinition = new ErrorEventDefinition();
            BpmnXMLUtil.addXMLLocation(eventDefinition, xtr);
            eventDefinition.ErrorCode = xtr.getAttributeValue("errorRef");

            BpmnXMLUtil.parseChildElements(org.activiti.bpmn.constants.BpmnXMLConstants.ELEMENT_EVENT_ERRORDEFINITION, eventDefinition, xtr, model);

            ((Event)parentElement).EventDefinitions.Add(eventDefinition);
        }
    }

}