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
    public class DataObjectValidator : ProcessLevelValidator
    {

        protected internal override void executeValidation(BpmnModel bpmnModel, Process process, IList<ValidationError> errors)
        {

            // Gather data objects
            IList<ValuedDataObject> allDataObjects = new List<ValuedDataObject>();
            ((List<ValuedDataObject>)allDataObjects).AddRange(process.DataObjects);
            IList<SubProcess> subProcesses = process.findFlowElementsOfType<SubProcess>(true);
            foreach (SubProcess subProcess in subProcesses)
            {
                ((List<ValuedDataObject>)allDataObjects).AddRange(subProcess.DataObjects);
            }

            // Validate
            foreach (ValuedDataObject dataObject in allDataObjects)
            {
                if (string.IsNullOrWhiteSpace(dataObject.Name))
                {
                    addError(errors, org.activiti.validation.validator.Problems_Fields.DATA_OBJECT_MISSING_NAME, process, dataObject, "Name is mandatory for a data object");
                }
            }
        }

    }

}