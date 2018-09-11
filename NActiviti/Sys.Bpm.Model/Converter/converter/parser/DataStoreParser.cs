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
    public class DataStoreParser : IBpmnXMLConstants
    {
        public virtual void parse(XMLStreamReader xtr, BpmnModel model)
        {
            string id = xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_ID);
            if (!string.IsNullOrWhiteSpace(id))
            {

                DataStore dataStore = new DataStore();
                dataStore.Id = xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_ID);

                string name = xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_NAME);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    dataStore.Name = name;
                }

                string itemSubjectRef = xtr.getAttributeValue(org.activiti.bpmn.constants.BpmnXMLConstants.ATTRIBUTE_ITEM_SUBJECT_REF);
                if (!string.IsNullOrWhiteSpace(itemSubjectRef))
                {
                    dataStore.ItemSubjectRef = itemSubjectRef;
                }

                BpmnXMLUtil.addXMLLocation(dataStore, xtr);

                model.addDataStore(dataStore.Id, dataStore);

                BpmnXMLUtil.parseChildElements(org.activiti.bpmn.constants.BpmnXMLConstants.ELEMENT_DATA_STORE, dataStore, xtr, model);
            }
        }
    }

}