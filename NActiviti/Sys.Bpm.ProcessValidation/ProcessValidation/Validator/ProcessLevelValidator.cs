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
namespace Sys.Workflow.Validation.Validators
{

    using Sys.Workflow.Bpmn.Models;

    /// 
    public abstract class ProcessLevelValidator : ValidatorImpl
    {

        public override void Validate(BpmnModel bpmnModel, IList<ValidationError> errors)
        {
            foreach (Process process in bpmnModel.Processes)
            {
                ExecuteValidation(bpmnModel, process, errors);
            }
        }

        protected internal abstract void ExecuteValidation(BpmnModel bpmnModel, Process process, IList<ValidationError> errors);
    }
}