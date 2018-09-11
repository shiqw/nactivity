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
namespace org.activiti.bpmn.converter.parser
{

    using org.activiti.bpmn.constants;
    using org.activiti.bpmn.converter.util;
    using org.activiti.bpmn.model;

    /// 
    public class ItemDefinitionParser : IBpmnXMLConstants
    {
        public virtual void parse(XMLStreamReader xtr, BpmnModel model)
        {
            if (!string.IsNullOrWhiteSpace(xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_ID)))
            {
                string itemDefinitionId = model.TargetNamespace + ":" + xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_ID);
                string structureRef = xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_STRUCTURE_REF);
                if (!string.IsNullOrWhiteSpace(structureRef))
                {
                    ItemDefinition item = new ItemDefinition();
                    item.Id = itemDefinitionId;
                    BpmnXMLUtil.addXMLLocation(item, xtr);

                    int indexOfP = structureRef.IndexOf(':');
                    if (indexOfP != -1)
                    {
                        string prefix = structureRef.Substring(0, indexOfP);
                        string resolvedNamespace = model.getNamespace(prefix);
                        structureRef = resolvedNamespace + ":" + structureRef.Substring(indexOfP + 1);
                    }
                    else
                    {
                        structureRef = model.TargetNamespace + ":" + structureRef;
                    }

                    item.StructureRef = structureRef;
                    item.ItemKind = xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_ITEM_KIND);
                    BpmnXMLUtil.parseChildElements(org.activiti.bpmn.constants.BpmnXMLConstants.ELEMENT_ITEM_DEFINITION, item, xtr, model);
                    model.addItemDefinition(itemDefinitionId, item);
                }
            }
        }
    }

}