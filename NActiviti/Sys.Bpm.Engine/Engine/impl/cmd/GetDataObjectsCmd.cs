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
namespace org.activiti.engine.impl.cmd
{
    using Newtonsoft.Json.Linq;
    using org.activiti.bpmn.model;

    using org.activiti.engine.impl.context;
    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.impl.persistence.entity;
    using org.activiti.engine.impl.util;
    using org.activiti.engine.runtime;

    [Serializable]
    public class GetDataObjectsCmd : ICommand<IDictionary<string, IDataObject>>
    {

        private const long serialVersionUID = 1L;
        protected internal string executionId;
        protected internal ICollection<string> dataObjectNames;
        protected internal bool isLocal;
        protected internal string locale;
        protected internal bool withLocalizationFallback;

        public GetDataObjectsCmd(string executionId, ICollection<string> dataObjectNames, bool isLocal)
        {
            this.executionId = executionId;
            this.dataObjectNames = dataObjectNames;
            this.isLocal = isLocal;
        }

        public GetDataObjectsCmd(string executionId, ICollection<string> dataObjectNames, bool isLocal, string locale, bool withLocalizationFallback)
        {
            this.executionId = executionId;
            this.dataObjectNames = dataObjectNames;
            this.isLocal = isLocal;
            this.locale = locale;
            this.withLocalizationFallback = withLocalizationFallback;
        }

        public virtual IDictionary<string, IDataObject> execute(ICommandContext commandContext)
        {
            // Verify existance of execution
            if (string.ReferenceEquals(executionId, null))
            {
                throw new ActivitiIllegalArgumentException("executionId is null");
            }

            IExecutionEntity execution = commandContext.ExecutionEntityManager.findById<IExecutionEntity>(new KeyValuePair<string, object>("id", executionId));

            if (execution == null)
            {
                throw new ActivitiObjectNotFoundException("execution " + executionId + " doesn't exist", typeof(IExecution));
            }

            IDictionary<string, IVariableInstance> variables = null;
            if (dataObjectNames == null || dataObjectNames.Count == 0)
            {
                // Fetch all
                if (isLocal)
                {
                    variables = execution.VariableInstancesLocal;
                }
                else
                {
                    variables = execution.VariableInstances;
                }

            }
            else
            {
                // Fetch specific collection of variables
                if (isLocal)
                {
                    variables = execution.getVariableInstancesLocal(dataObjectNames, false);
                }
                else
                {
                    variables = execution.getVariableInstances(dataObjectNames, false);
                }
            }

            IDictionary<string, IDataObject> dataObjects = null;
            if (variables != null)
            {
                dataObjects = new Dictionary<string, IDataObject>(variables.Count);

                foreach (KeyValuePair<string, IVariableInstance> entry in variables.SetOfKeyValuePairs())
                {
                    string name = entry.Key;
                    IVariableInstance variableEntity = (IVariableInstance)entry.Value;

                    IExecutionEntity executionEntity = commandContext.ExecutionEntityManager.findById<IExecutionEntity>(new KeyValuePair<string, object>("id", variableEntity.ExecutionId));
                    while (!executionEntity.IsScope)
                    {
                        executionEntity = executionEntity.Parent;
                    }

                    BpmnModel bpmnModel = ProcessDefinitionUtil.getBpmnModel(execution.ProcessDefinitionId);
                    ValuedDataObject foundDataObject = null;
                    if (string.ReferenceEquals(executionEntity.ParentId, null))
                    {
                        foreach (ValuedDataObject dataObject in bpmnModel.MainProcess.DataObjects)
                        {
                            if (dataObject.Name.Equals(variableEntity.Name))
                            {
                                foundDataObject = dataObject;
                                break;
                            }
                        }
                    }
                    else
                    {
                        SubProcess subProcess = (SubProcess)bpmnModel.getFlowElement(execution.ActivityId);
                        foreach (ValuedDataObject dataObject in subProcess.DataObjects)
                        {
                            if (dataObject.Name.Equals(variableEntity.Name))
                            {
                                foundDataObject = dataObject;
                                break;
                            }
                        }
                    }

                    string localizedName = null;
                    string localizedDescription = null;

                    if (!string.ReferenceEquals(locale, null) && foundDataObject != null)
                    {
                        JToken languageNode = Context.getLocalizationElementProperties(locale, foundDataObject.Id, execution.ProcessDefinitionId, withLocalizationFallback);

                        if (languageNode != null)
                        {
                            JToken nameNode = languageNode[DynamicBpmnConstants_Fields.LOCALIZATION_NAME];
                            if (nameNode != null)
                            {
                                localizedName = nameNode.ToString();
                            }
                            JToken descriptionNode = languageNode[DynamicBpmnConstants_Fields.LOCALIZATION_DESCRIPTION];
                            if (descriptionNode != null)
                            {
                                localizedDescription = descriptionNode.ToString();
                            }
                        }
                    }

                    if (foundDataObject != null)
                    {
                        dataObjects[name] = new DataObjectImpl(variableEntity.Name, variableEntity.Value, foundDataObject.Documentation, foundDataObject.Type, localizedName, localizedDescription, foundDataObject.Id);
                    }
                }
            }

            return dataObjects;
        }
    }

}