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
namespace org.activiti.engine.impl
{
    using Newtonsoft.Json.Linq;
    using org.activiti.engine.impl.context;
    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.impl.persistence.entity;
    using org.activiti.engine.impl.variable;
    using org.activiti.engine.task;

    /// 
    /// 
    /// 
    /// 
    public class TaskQueryImpl : AbstractVariableQueryImpl<ITaskQuery, ITask>, ITaskQuery
    {

        private const long serialVersionUID = 1L;
        protected internal string taskId_Renamed;
        protected internal string name;
        protected internal string nameLike;
        protected internal string nameLikeIgnoreCase;
        protected internal IList<string> nameList;
        protected internal IList<string> nameListIgnoreCase;
        protected internal string description;
        protected internal string descriptionLike;
        protected internal string descriptionLikeIgnoreCase;
        protected internal int? priority;
        protected internal int? minPriority;
        protected internal int? maxPriority;
        protected internal string assignee;
        protected internal string assigneeLike;
        protected internal string assigneeLikeIgnoreCase;
        protected internal IList<string> assigneeIds;
        protected internal string involvedUser;
        protected internal IList<string> involvedGroups;
        protected internal string owner;
        protected internal string ownerLike;
        protected internal string ownerLikeIgnoreCase;
        protected internal bool unassigned;
        protected internal bool noDelegationState;
        protected internal DelegationState? delegationState;
        protected internal string candidateUser;
        protected internal string candidateGroup;
        protected internal IList<string> candidateGroups;
        protected internal string tenantId;
        protected internal string tenantIdLike;
        protected internal bool withoutTenantId;

        protected internal string processInstanceId_Renamed;
        protected internal IList<string> processInstanceIds;

        protected internal string executionId_Renamed;
        protected internal DateTime? createTime;
        protected internal DateTime? createTimeBefore;
        protected internal DateTime? createTimeAfter;
        protected internal string category;
        protected internal string key;
        protected internal string keyLike;

        protected internal string processDefinitionKey_Renamed;

        protected internal string processDefinitionKeyLike_Renamed;

        protected internal string processDefinitionKeyLikeIgnoreCase_Renamed;
        protected internal IList<string> processDefinitionKeys;

        protected internal string processDefinitionId_Renamed;

        protected internal string processDefinitionName_Renamed;

        protected internal string processDefinitionNameLike_Renamed;
        protected internal IList<string> processCategoryInList;
        protected internal IList<string> processCategoryNotInList;

        protected internal string deploymentId_Renamed;
        protected internal IList<string> deploymentIds;

        protected internal string processInstanceBusinessKey_Renamed;

        protected internal string processInstanceBusinessKeyLike_Renamed;

        protected internal string processInstanceBusinessKeyLikeIgnoreCase_Renamed;

        protected internal DateTime? dueDate_Renamed;

        protected internal DateTime? dueBefore_Renamed;

        protected internal DateTime? dueAfter_Renamed;

        protected internal bool withoutDueDate_Renamed;
        protected internal ISuspensionState suspensionState;

        protected internal bool excludeSubtasks_Renamed;

        protected internal bool includeTaskLocalVariables_Renamed;

        protected internal bool includeProcessVariables_Renamed;
        protected internal int? taskVariablesLimit;
        protected internal string userIdForCandidateAndAssignee;
        protected internal bool bothCandidateAndAssigned;

        protected internal string locale_Renamed;

        protected internal bool withLocalizationFallback_Renamed;
        protected internal bool orActive;
        protected internal IList<TaskQueryImpl> orQueryObjects = new List<TaskQueryImpl>();
        protected internal TaskQueryImpl currentOrQueryObject = null;

        public TaskQueryImpl()
        {
        }

        public TaskQueryImpl(ICommandContext commandContext) : base(commandContext)
        {
        }

        public TaskQueryImpl(ICommandExecutor commandExecutor) : base(commandExecutor)
        {
        }

        public TaskQueryImpl(ICommandExecutor commandExecutor, string databaseType) : base(commandExecutor)
        {
            this.databaseType = databaseType;
        }

        public virtual ITaskQuery taskId(string taskId)
        {
            if (string.ReferenceEquals(taskId, null))
            {
                throw new ActivitiIllegalArgumentException("Task id is null");
            }

            if (orActive)
            {
                currentOrQueryObject.taskId_Renamed = taskId;
            }
            else
            {
                this.taskId_Renamed = taskId;
            }
            return this;
        }

        public virtual ITaskQuery taskName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActivitiIllegalArgumentException("Task name is null");
            }

            if (orActive)
            {
                currentOrQueryObject.name = name;
            }
            else
            {
                this.name = name;
            }
            return this;
        }

        public virtual ITaskQuery taskNameIn(IList<string> nameList)
        {
            if (nameList == null)
            {
                throw new ActivitiIllegalArgumentException("Task name list is null");
            }
            if (nameList.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Task name list is empty");
            }
            foreach (string name in nameList)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ActivitiIllegalArgumentException("None of the given task names can be null");
                }
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskNameIn and name");
            }
            if (!string.IsNullOrWhiteSpace(nameLike))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskNameIn and nameLike");
            }
            if (!string.IsNullOrWhiteSpace(nameLikeIgnoreCase))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskNameIn and nameLikeIgnoreCase");
            }

            if (orActive)
            {
                currentOrQueryObject.nameList = nameList;
            }
            else
            {
                this.nameList = nameList;
            }
            return this;
        }

        public virtual ITaskQuery taskNameInIgnoreCase(IList<string> nameList)
        {
            if (nameList == null)
            {
                throw new ActivitiIllegalArgumentException("Task name list is null");
            }
            if (nameList.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Task name list is empty");
            }
            foreach (string name in nameList)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ActivitiIllegalArgumentException("None of the given task names can be null");
                }
            }

            if (name != null)
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskNameInIgnoreCase and name");
            }
            if (nameLike != null)
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskNameInIgnoreCase and nameLike");
            }
            if (nameLikeIgnoreCase != null)
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskNameInIgnoreCase and nameLikeIgnoreCase");
            }


            int nameListSize = nameList.Count;

            IList<string> caseIgnoredNameList = new List<string>(nameListSize);
            foreach (string name in nameList)
            {
                caseIgnoredNameList.Add(name.ToLower());
            }

            if (orActive)
            {
                this.currentOrQueryObject.nameListIgnoreCase = caseIgnoredNameList;
            }
            else
            {
                this.nameListIgnoreCase = caseIgnoredNameList;
            }
            return this;
        }

        public virtual ITaskQuery taskNameLike(string nameLike)
        {
            if (string.IsNullOrWhiteSpace(nameLike))
            {
                throw new ActivitiIllegalArgumentException("Task namelike is null");
            }

            if (orActive)
            {
                currentOrQueryObject.nameLike = nameLike;
            }
            else
            {
                this.nameLike = nameLike;
            }
            return this;
        }

        public virtual ITaskQuery taskNameLikeIgnoreCase(string nameLikeIgnoreCase)
        {
            if (string.IsNullOrWhiteSpace(nameLikeIgnoreCase))
            {
                throw new ActivitiIllegalArgumentException("Task nameLikeIgnoreCase is null");
            }

            if (orActive)
            {
                currentOrQueryObject.nameLikeIgnoreCase = nameLikeIgnoreCase.ToLower();
            }
            else
            {
                this.nameLikeIgnoreCase = nameLikeIgnoreCase.ToLower();
            }
            return this;
        }

        public virtual ITaskQuery taskDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ActivitiIllegalArgumentException("Description is null");
            }

            if (orActive)
            {
                currentOrQueryObject.description = description;
            }
            else
            {
                this.description = description;
            }
            return this;
        }

        public virtual ITaskQuery taskDescriptionLike(string descriptionLike)
        {
            if (string.IsNullOrWhiteSpace(descriptionLike))
            {
                throw new ActivitiIllegalArgumentException("Task descriptionlike is null");
            }
            if (orActive)
            {
                currentOrQueryObject.descriptionLike = descriptionLike;
            }
            else
            {
                this.descriptionLike = descriptionLike;
            }
            return this;
        }

        public virtual ITaskQuery taskDescriptionLikeIgnoreCase(string descriptionLikeIgnoreCase)
        {
            if (string.ReferenceEquals(descriptionLikeIgnoreCase, null))
            {
                throw new ActivitiIllegalArgumentException("Task descriptionLikeIgnoreCase is null");
            }
            if (orActive)
            {
                currentOrQueryObject.descriptionLikeIgnoreCase = descriptionLikeIgnoreCase.ToLower();
            }
            else
            {
                this.descriptionLikeIgnoreCase = descriptionLikeIgnoreCase.ToLower();
            }
            return this;
        }

        public virtual ITaskQuery taskPriority(int? priority)
        {
            if (priority == null)
            {
                throw new ActivitiIllegalArgumentException("Priority is null");
            }
            if (orActive)
            {
                currentOrQueryObject.priority = priority;
            }
            else
            {
                this.priority = priority;
            }
            return this;
        }

        public virtual ITaskQuery taskMinPriority(int? minPriority)
        {
            if (minPriority == null)
            {
                throw new ActivitiIllegalArgumentException("Min Priority is null");
            }
            if (orActive)
            {
                currentOrQueryObject.minPriority = minPriority;
            }
            else
            {
                this.minPriority = minPriority;
            }
            return this;
        }

        public virtual ITaskQuery taskMaxPriority(int? maxPriority)
        {
            if (maxPriority == null)
            {
                throw new ActivitiIllegalArgumentException("Max Priority is null");
            }
            if (orActive)
            {
                currentOrQueryObject.maxPriority = maxPriority;
            }
            else
            {
                this.maxPriority = maxPriority;
            }
            return this;
        }

        public virtual ITaskQuery taskAssignee(string assignee)
        {
            if (string.ReferenceEquals(assignee, null))
            {
                throw new ActivitiIllegalArgumentException("Assignee is null");
            }
            if (orActive)
            {
                currentOrQueryObject.assignee = assignee;
            }
            else
            {
                this.assignee = assignee;
            }
            return this;
        }

        public virtual ITaskQuery taskAssigneeLike(string assigneeLike)
        {
            if (string.ReferenceEquals(assigneeLike, null))
            {
                throw new ActivitiIllegalArgumentException("AssigneeLike is null");
            }
            if (orActive)
            {
                currentOrQueryObject.assigneeLike = assignee;
            }
            else
            {
                this.assigneeLike = assigneeLike;
            }
            return this;
        }

        public virtual ITaskQuery taskAssigneeLikeIgnoreCase(string assigneeLikeIgnoreCase)
        {
            if (string.ReferenceEquals(assigneeLikeIgnoreCase, null))
            {
                throw new ActivitiIllegalArgumentException("assigneeLikeIgnoreCase is null");
            }
            if (orActive)
            {
                currentOrQueryObject.assigneeLikeIgnoreCase = assigneeLikeIgnoreCase.ToLower();
            }
            else
            {
                this.assigneeLikeIgnoreCase = assigneeLikeIgnoreCase.ToLower();
            }
            return this;
        }

        public virtual ITaskQuery taskAssigneeIds(IList<string> assigneeIds)
        {
            if (assigneeIds == null)
            {
                throw new ActivitiIllegalArgumentException("Task assignee list is null");
            }
            if (assigneeIds.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Task assignee list is empty");
            }
            foreach (string assignee in assigneeIds)
            {
                if (string.ReferenceEquals(assignee, null))
                {
                    throw new ActivitiIllegalArgumentException("None of the given task assignees can be null");
                }
            }

            if (!string.ReferenceEquals(assignee, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskAssigneeIds and taskAssignee");
            }
            if (!string.ReferenceEquals(assigneeLike, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskAssigneeIds and taskAssigneeLike");
            }
            if (!string.ReferenceEquals(assigneeLikeIgnoreCase, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both taskAssigneeIds and taskAssigneeLikeIgnoreCase");
            }

            if (orActive)
            {
                currentOrQueryObject.assigneeIds = assigneeIds;
            }
            else
            {
                this.assigneeIds = assigneeIds;
            }
            return this;
        }

        public virtual ITaskQuery taskOwner(string owner)
        {
            if (string.ReferenceEquals(owner, null))
            {
                throw new ActivitiIllegalArgumentException("Owner is null");
            }
            if (orActive)
            {
                currentOrQueryObject.owner = owner;
            }
            else
            {
                this.owner = owner;
            }
            return this;
        }

        public virtual ITaskQuery taskOwnerLike(string ownerLike)
        {
            if (string.ReferenceEquals(ownerLike, null))
            {
                throw new ActivitiIllegalArgumentException("Owner is null");
            }
            if (orActive)
            {
                currentOrQueryObject.ownerLike = ownerLike;
            }
            else
            {
                this.ownerLike = ownerLike;
            }
            return this;
        }

        public virtual ITaskQuery taskOwnerLikeIgnoreCase(string ownerLikeIgnoreCase)
        {
            if (string.ReferenceEquals(ownerLikeIgnoreCase, null))
            {
                throw new ActivitiIllegalArgumentException("OwnerLikeIgnoreCase");
            }
            if (orActive)
            {
                currentOrQueryObject.ownerLikeIgnoreCase = ownerLikeIgnoreCase.ToLower();
            }
            else
            {
                this.ownerLikeIgnoreCase = ownerLikeIgnoreCase.ToLower();
            }
            return this;
        }

        public virtual ITaskQuery taskUnassigned()
        {
            if (orActive)
            {
                currentOrQueryObject.unassigned = true;
            }
            else
            {
                this.unassigned = true;
            }
            return this;
        }

        public virtual ITaskQuery taskDelegationState(DelegationState? delegationState)
        {
            if (orActive)
            {
                if (!delegationState.HasValue)
                {
                    currentOrQueryObject.noDelegationState = true;
                }
                else
                {
                    currentOrQueryObject.delegationState = delegationState.Value;
                }
            }
            else
            {
                if (!delegationState.HasValue)
                {
                    this.noDelegationState = true;
                }
                else
                {
                    this.delegationState = delegationState.Value;
                }
            }
            return this;
        }

        public virtual ITaskQuery taskCandidateUser(string candidateUser)
        {
            if (string.ReferenceEquals(candidateUser, null))
            {
                throw new ActivitiIllegalArgumentException("Candidate user is null");
            }

            if (orActive)
            {
                currentOrQueryObject.candidateUser = candidateUser;
            }
            else
            {
                this.candidateUser = candidateUser;
            }

            return this;
        }

        public virtual ITaskQuery taskCandidateUser(string candidateUser, IList<string> usersGroups)
        {
            if (string.ReferenceEquals(candidateUser, null))
            {
                throw new ActivitiIllegalArgumentException("Candidate user is null");
            }

            if (orActive)
            {
                currentOrQueryObject.candidateUser = candidateUser;
                currentOrQueryObject.candidateGroups = usersGroups;
            }
            else
            {
                this.candidateUser = candidateUser;
                this.candidateGroups = usersGroups;
            }

            return this;
        }

        public virtual ITaskQuery taskInvolvedUser(string involvedUser)
        {
            if (string.ReferenceEquals(involvedUser, null))
            {
                throw new ActivitiIllegalArgumentException("Involved user is null");
            }
            if (orActive)
            {
                currentOrQueryObject.involvedUser = involvedUser;
            }
            else
            {
                this.involvedUser = involvedUser;
            }
            return this;
        }

        public virtual ITaskQuery taskInvolvedGroupsIn(IList<string> involvedGroups)
        {
            if (involvedGroups == null || involvedGroups.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Involved groups list is null or empty.");
            }

            if (orActive)
            {
                currentOrQueryObject.involvedGroups = involvedGroups;
            }
            else
            {
                this.involvedGroups = involvedGroups;
            }

            return this;
        }

        public virtual ITaskQuery taskCandidateGroup(string candidateGroup)
        {
            if (string.ReferenceEquals(candidateGroup, null))
            {
                throw new ActivitiIllegalArgumentException("Candidate group is null");
            }

            if (candidateGroups != null)
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both candidateGroup and candidateGroupIn");
            }

            if (orActive)
            {
                currentOrQueryObject.candidateGroup = candidateGroup;
            }
            else
            {
                this.candidateGroup = candidateGroup;
            }
            return this;
        }

        public virtual ITaskQuery taskCandidateOrAssigned(string userIdForCandidateAndAssignee)
        {
            if (!string.ReferenceEquals(candidateGroup, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set candidateGroup");
            }
            if (!string.ReferenceEquals(candidateUser, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both candidateGroup and candidateUser");
            }

            if (orActive)
            {
                currentOrQueryObject.bothCandidateAndAssigned = true;
                currentOrQueryObject.userIdForCandidateAndAssignee = userIdForCandidateAndAssignee;
            }
            else
            {
                this.bothCandidateAndAssigned = true;
                this.userIdForCandidateAndAssignee = userIdForCandidateAndAssignee;
            }

            return this;
        }


        public virtual ITaskQuery taskCandidateOrAssigned(string userIdForCandidateAndAssignee, IList<string> usersGroups)
        {
            if (!string.ReferenceEquals(candidateGroup, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set candidateGroup");
            }
            if (!string.ReferenceEquals(candidateUser, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both candidateGroup and candidateUser");
            }

            if (orActive)
            {
                currentOrQueryObject.bothCandidateAndAssigned = true;
                currentOrQueryObject.userIdForCandidateAndAssignee = userIdForCandidateAndAssignee;
                currentOrQueryObject.candidateGroups = usersGroups;
            }
            else
            {
                this.bothCandidateAndAssigned = true;
                this.userIdForCandidateAndAssignee = userIdForCandidateAndAssignee;
                this.candidateGroups = usersGroups;
            }

            return this;
        }

        public virtual ITaskQuery taskCandidateGroupIn(IList<string> candidateGroups)
        {
            if (candidateGroups == null)
            {
                throw new ActivitiIllegalArgumentException("Candidate group list is null");
            }

            if (candidateGroups.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Candidate group list is empty");
            }

            if (!string.ReferenceEquals(candidateGroup, null))
            {
                throw new ActivitiIllegalArgumentException("Invalid query usage: cannot set both candidateGroupIn and candidateGroup");
            }

            if (orActive)
            {
                currentOrQueryObject.candidateGroups = candidateGroups;
            }
            else
            {
                this.candidateGroups = candidateGroups;
            }
            return this;
        }

        public virtual ITaskQuery taskTenantId(string tenantId)
        {
            if (string.ReferenceEquals(tenantId, null))
            {
                throw new ActivitiIllegalArgumentException("task tenant id is null");
            }
            if (orActive)
            {
                currentOrQueryObject.tenantId = tenantId;
            }
            else
            {
                this.tenantId = tenantId;
            }
            return this;
        }

        public virtual ITaskQuery taskTenantIdLike(string tenantIdLike)
        {
            if (string.ReferenceEquals(tenantIdLike, null))
            {
                throw new ActivitiIllegalArgumentException("task tenant id is null");
            }
            if (orActive)
            {
                currentOrQueryObject.tenantIdLike = tenantIdLike;
            }
            else
            {
                this.tenantIdLike = tenantIdLike;
            }
            return this;
        }

        public virtual ITaskQuery taskWithoutTenantId()
        {
            if (orActive)
            {
                currentOrQueryObject.withoutTenantId = true;
            }
            else
            {
                this.withoutTenantId = true;
            }
            return this;
        }

        public virtual ITaskQuery processInstanceId(string processInstanceId)
        {
            if (orActive)
            {
                currentOrQueryObject.processInstanceId_Renamed = processInstanceId;
            }
            else
            {
                this.processInstanceId_Renamed = processInstanceId;
            }
            return this;
        }

        public virtual ITaskQuery processInstanceIdIn(IList<string> processInstanceIds)
        {
            if (processInstanceIds == null)
            {
                throw new ActivitiIllegalArgumentException("Process instance id list is null");
            }
            if (processInstanceIds.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Process instance id list is empty");
            }
            foreach (string processInstanceId in processInstanceIds)
            {
                if (string.ReferenceEquals(processInstanceId, null))
                {
                    throw new ActivitiIllegalArgumentException("None of the given process instance ids can be null");
                }
            }

            if (orActive)
            {
                currentOrQueryObject.processInstanceIds = processInstanceIds;
            }
            else
            {
                this.processInstanceIds = processInstanceIds;
            }
            return this;
        }

        public virtual ITaskQuery processInstanceBusinessKey(string processInstanceBusinessKey)
        {
            if (orActive)
            {
                currentOrQueryObject.processInstanceBusinessKey_Renamed = processInstanceBusinessKey;
            }
            else
            {
                this.processInstanceBusinessKey_Renamed = processInstanceBusinessKey;
            }
            return this;
        }

        public virtual ITaskQuery processInstanceBusinessKeyLike(string processInstanceBusinessKeyLike)
        {
            if (orActive)
            {
                currentOrQueryObject.processInstanceBusinessKeyLike_Renamed = processInstanceBusinessKeyLike;
            }
            else
            {
                this.processInstanceBusinessKeyLike_Renamed = processInstanceBusinessKeyLike;
            }
            return this;
        }

        public virtual ITaskQuery processInstanceBusinessKeyLikeIgnoreCase(string processInstanceBusinessKeyLikeIgnoreCase)
        {
            if (orActive)
            {
                currentOrQueryObject.processInstanceBusinessKeyLikeIgnoreCase_Renamed = processInstanceBusinessKeyLikeIgnoreCase.ToLower();
            }
            else
            {
                this.processInstanceBusinessKeyLikeIgnoreCase_Renamed = processInstanceBusinessKeyLikeIgnoreCase.ToLower();
            }
            return this;
        }

        public virtual ITaskQuery executionId(string executionId)
        {
            if (orActive)
            {
                currentOrQueryObject.executionId_Renamed = executionId;
            }
            else
            {
                this.executionId_Renamed = executionId;
            }
            return this;
        }

        public virtual ITaskQuery taskCreatedOn(DateTime createTime)
        {
            if (orActive)
            {
                currentOrQueryObject.createTime = createTime;
            }
            else
            {
                this.createTime = createTime;
            }
            return this;
        }

        public virtual ITaskQuery taskCreatedBefore(DateTime before)
        {
            if (orActive)
            {
                currentOrQueryObject.createTimeBefore = before;
            }
            else
            {
                this.createTimeBefore = before;
            }
            return this;
        }

        public virtual ITaskQuery taskCreatedAfter(DateTime after)
        {
            if (orActive)
            {
                currentOrQueryObject.createTimeAfter = after;
            }
            else
            {
                this.createTimeAfter = after;
            }
            return this;
        }

        public virtual ITaskQuery taskCategory(string category)
        {
            if (orActive)
            {
                currentOrQueryObject.category = category;
            }
            else
            {
                this.category = category;
            }
            return this;
        }

        public virtual ITaskQuery taskDefinitionKey(string key)
        {
            if (orActive)
            {
                currentOrQueryObject.key = key;
            }
            else
            {
                this.key = key;
            }
            return this;
        }

        public virtual ITaskQuery taskDefinitionKeyLike(string keyLike)
        {
            if (orActive)
            {
                currentOrQueryObject.keyLike = keyLike;
            }
            else
            {
                this.keyLike = keyLike;
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueEquals(string variableName, object variableValue)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueEquals(variableName, variableValue);
            }
            else
            {
                this.variableValueEquals(variableName, variableValue);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueEquals(object variableValue)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueEquals(variableValue);
            }
            else
            {
                this.variableValueEquals(variableValue);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueEqualsIgnoreCase(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueEqualsIgnoreCase(name, value);
            }
            else
            {
                this.variableValueEqualsIgnoreCase(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueNotEqualsIgnoreCase(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueNotEqualsIgnoreCase(name, value);
            }
            else
            {
                this.variableValueNotEqualsIgnoreCase(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueNotEquals(string variableName, object variableValue)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueNotEquals(variableName, variableValue);
            }
            else
            {
                this.variableValueNotEquals(variableName, variableValue);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueGreaterThan(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueGreaterThan(name, value);
            }
            else
            {
                this.variableValueGreaterThan(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueGreaterThanOrEqual(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueGreaterThanOrEqual(name, value);
            }
            else
            {
                this.variableValueGreaterThanOrEqual(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueLessThan(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLessThan(name, value);
            }
            else
            {
                this.variableValueLessThan(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueLessThanOrEqual(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLessThanOrEqual(name, value);
            }
            else
            {
                this.variableValueLessThanOrEqual(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueLike(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLike(name, value);
            }
            else
            {
                this.variableValueLike(name, value);
            }
            return this;
        }

        public virtual ITaskQuery taskVariableValueLikeIgnoreCase(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLikeIgnoreCase(name, value);
            }
            else
            {
                this.variableValueLikeIgnoreCase(name, value);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueEquals(string variableName, object variableValue)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueEquals(variableName, variableValue, false);
            }
            else
            {
                this.variableValueEquals(variableName, variableValue, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueNotEquals(string variableName, object variableValue)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueNotEquals(variableName, variableValue, false);
            }
            else
            {
                this.variableValueNotEquals(variableName, variableValue, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueEquals(object variableValue)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueEquals(variableValue, false);
            }
            else
            {
                this.variableValueEquals(variableValue, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueEqualsIgnoreCase(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueEqualsIgnoreCase(name, value, false);
            }
            else
            {
                this.variableValueEqualsIgnoreCase(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueNotEqualsIgnoreCase(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueNotEqualsIgnoreCase(name, value, false);
            }
            else
            {
                this.variableValueNotEqualsIgnoreCase(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueGreaterThan(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueGreaterThan(name, value, false);
            }
            else
            {
                this.variableValueGreaterThan(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueGreaterThanOrEqual(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueGreaterThanOrEqual(name, value, false);
            }
            else
            {
                this.variableValueGreaterThanOrEqual(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueLessThan(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLessThan(name, value, false);
            }
            else
            {
                this.variableValueLessThan(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueLessThanOrEqual(string name, object value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLessThanOrEqual(name, value, false);
            }
            else
            {
                this.variableValueLessThanOrEqual(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueLike(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLike(name, value, false);
            }
            else
            {
                this.variableValueLike(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processVariableValueLikeIgnoreCase(string name, string value)
        {
            if (orActive)
            {
                currentOrQueryObject.variableValueLikeIgnoreCase(name, value, false);
            }
            else
            {
                this.variableValueLikeIgnoreCase(name, value, false);
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionKey(string processDefinitionKey)
        {
            if (orActive)
            {
                currentOrQueryObject.processDefinitionKey_Renamed = processDefinitionKey;
            }
            else
            {
                this.processDefinitionKey_Renamed = processDefinitionKey;
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionKeyLike(string processDefinitionKeyLike)
        {
            if (orActive)
            {
                currentOrQueryObject.processDefinitionKeyLike_Renamed = processDefinitionKeyLike;
            }
            else
            {
                this.processDefinitionKeyLike_Renamed = processDefinitionKeyLike;
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionKeyLikeIgnoreCase(string processDefinitionKeyLikeIgnoreCase)
        {
            if (orActive)
            {
                currentOrQueryObject.processDefinitionKeyLikeIgnoreCase_Renamed = processDefinitionKeyLikeIgnoreCase.ToLower();
            }
            else
            {
                this.processDefinitionKeyLikeIgnoreCase_Renamed = processDefinitionKeyLikeIgnoreCase.ToLower();
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionKeyIn(IList<string> processDefinitionKeys)
        {
            if (orActive)
            {
                this.currentOrQueryObject.processDefinitionKeys = processDefinitionKeys;
            }
            else
            {
                this.processDefinitionKeys = processDefinitionKeys;
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionId(string processDefinitionId)
        {
            if (orActive)
            {
                currentOrQueryObject.processDefinitionId_Renamed = processDefinitionId;
            }
            else
            {
                this.processDefinitionId_Renamed = processDefinitionId;
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionName(string processDefinitionName)
        {
            if (orActive)
            {
                currentOrQueryObject.processDefinitionName_Renamed = processDefinitionName;
            }
            else
            {
                this.processDefinitionName_Renamed = processDefinitionName;
            }
            return this;
        }

        public virtual ITaskQuery processDefinitionNameLike(string processDefinitionNameLike)
        {
            if (orActive)
            {
                currentOrQueryObject.processDefinitionNameLike_Renamed = processDefinitionNameLike;
            }
            else
            {
                this.processDefinitionNameLike_Renamed = processDefinitionNameLike;
            }
            return this;
        }

        public virtual ITaskQuery processCategoryIn(IList<string> processCategoryInList)
        {
            if (processCategoryInList == null)
            {
                throw new ActivitiIllegalArgumentException("Process category list is null");
            }
            if (processCategoryInList.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Process category list is empty");
            }
            foreach (string processCategory in processCategoryInList)
            {
                if (string.ReferenceEquals(processCategory, null))
                {
                    throw new ActivitiIllegalArgumentException("None of the given process categories can be null");
                }
            }

            if (orActive)
            {
                currentOrQueryObject.processCategoryInList = processCategoryInList;
            }
            else
            {
                this.processCategoryInList = processCategoryInList;
            }
            return this;
        }

        public virtual ITaskQuery processCategoryNotIn(IList<string> processCategoryNotInList)
        {
            if (processCategoryNotInList == null)
            {
                throw new ActivitiIllegalArgumentException("Process category list is null");
            }
            if (processCategoryNotInList.Count == 0)
            {
                throw new ActivitiIllegalArgumentException("Process category list is empty");
            }
            foreach (string processCategory in processCategoryNotInList)
            {
                if (string.ReferenceEquals(processCategory, null))
                {
                    throw new ActivitiIllegalArgumentException("None of the given process categories can be null");
                }
            }

            if (orActive)
            {
                currentOrQueryObject.processCategoryNotInList = processCategoryNotInList;
            }
            else
            {
                this.processCategoryNotInList = processCategoryNotInList;
            }
            return this;
        }

        public virtual ITaskQuery deploymentId(string deploymentId)
        {
            if (orActive)
            {
                currentOrQueryObject.deploymentId_Renamed = deploymentId;
            }
            else
            {
                this.deploymentId_Renamed = deploymentId;
            }
            return this;
        }

        public virtual ITaskQuery deploymentIdIn(IList<string> deploymentIds)
        {
            if (orActive)
            {
                currentOrQueryObject.deploymentIds = deploymentIds;
            }
            else
            {
                this.deploymentIds = deploymentIds;
            }
            return this;
        }

        public virtual ITaskQuery dueDate(DateTime dueDate)
        {
            if (orActive)
            {
                currentOrQueryObject.dueDate_Renamed = dueDate;
                currentOrQueryObject.withoutDueDate_Renamed = false;
            }
            else
            {
                this.dueDate_Renamed = dueDate;
                this.withoutDueDate_Renamed = false;
            }
            return this;
        }

        public virtual ITaskQuery taskDueDate(DateTime dueDate)
        {
            return this.dueDate(dueDate);
        }

        public virtual ITaskQuery dueBefore(DateTime dueBefore)
        {
            if (orActive)
            {
                currentOrQueryObject.dueBefore_Renamed = dueBefore;
                currentOrQueryObject.withoutDueDate_Renamed = false;
            }
            else
            {
                this.dueBefore_Renamed = dueBefore;
                this.withoutDueDate_Renamed = false;
            }
            return this;
        }

        public virtual ITaskQuery taskDueBefore(DateTime dueDate)
        {
            return dueBefore(dueDate);
        }

        public virtual ITaskQuery dueAfter(DateTime dueAfter)
        {
            if (orActive)
            {
                currentOrQueryObject.dueAfter_Renamed = dueAfter;
                currentOrQueryObject.withoutDueDate_Renamed = false;
            }
            else
            {
                this.dueAfter_Renamed = dueAfter;
                this.withoutDueDate_Renamed = false;
            }
            return this;
        }

        public virtual ITaskQuery taskDueAfter(DateTime dueDate)
        {
            return dueAfter(dueDate);
        }

        public virtual ITaskQuery withoutDueDate()
        {
            if (orActive)
            {
                currentOrQueryObject.withoutDueDate_Renamed = true;
            }
            else
            {
                this.withoutDueDate_Renamed = true;
            }
            return this;
        }

        public virtual ITaskQuery withoutTaskDueDate()
        {
            return withoutDueDate();
        }

        public virtual ITaskQuery excludeSubtasks()
        {
            if (orActive)
            {
                currentOrQueryObject.excludeSubtasks_Renamed = true;
            }
            else
            {
                this.excludeSubtasks_Renamed = true;
            }
            return this;
        }

        public virtual ITaskQuery suspended()
        {
            if (orActive)
            {
                currentOrQueryObject.suspensionState = org.activiti.engine.impl.persistence.entity.SuspensionState_Fields.SUSPENDED;
            }
            else
            {
                this.suspensionState = org.activiti.engine.impl.persistence.entity.SuspensionState_Fields.SUSPENDED;
            }
            return this;
        }

        public virtual ITaskQuery active()
        {
            if (orActive)
            {
                currentOrQueryObject.suspensionState = org.activiti.engine.impl.persistence.entity.SuspensionState_Fields.ACTIVE;
            }
            else
            {
                this.suspensionState = org.activiti.engine.impl.persistence.entity.SuspensionState_Fields.ACTIVE;
            }
            return this;
        }

        public virtual ITaskQuery locale(string locale)
        {
            this.locale_Renamed = locale;
            return this;
        }

        public virtual ITaskQuery withLocalizationFallback()
        {
            withLocalizationFallback_Renamed = true;
            return this;
        }

        public virtual ITaskQuery includeTaskLocalVariables()
        {
            this.includeTaskLocalVariables_Renamed = true;
            return this;
        }

        public virtual ITaskQuery includeProcessVariables()
        {
            this.includeProcessVariables_Renamed = true;
            return this;
        }

        public virtual ITaskQuery limitTaskVariables(int? taskVariablesLimit)
        {
            this.taskVariablesLimit = taskVariablesLimit;
            return this;
        }

        public virtual int? TaskVariablesLimit
        {
            get
            {
                return taskVariablesLimit;
            }
        }

        public virtual IList<string> CandidateGroups
        {
            get
            {
                if (!string.ReferenceEquals(candidateGroup, null))
                {
                    IList<string> candidateGroupList = new List<string>(1);
                    candidateGroupList.Add(candidateGroup);
                    return candidateGroupList;

                }
                else if (candidateGroups != null)
                {
                    return candidateGroups;

                }
                else if (!string.ReferenceEquals(candidateUser, null))
                {
                    return getGroupsForCandidateUser(candidateUser);

                }
                else if (!string.ReferenceEquals(userIdForCandidateAndAssignee, null))
                {
                    return getGroupsForCandidateUser(userIdForCandidateAndAssignee);
                }
                return null;
            }
        }

        protected internal virtual IList<string> getGroupsForCandidateUser(string candidateUser)
        {
            IUserGroupLookupProxy userGroupLookupProxy = Context.ProcessEngineConfiguration.UserGroupLookupProxy;
            if (userGroupLookupProxy != null)
            {
                return userGroupLookupProxy.getGroupsForCandidateUser(candidateUser);
            }
            else
            {
                //log.warn("No UserGroupLookupProxy set on ProcessEngineConfiguration. Tasks queried only where user is directly related, not through groups.");
            }
            return null;
        }

        protected internal override void ensureVariablesInitialized()
        {
            IVariableTypes types = Context.ProcessEngineConfiguration.VariableTypes;
            foreach (QueryVariableValue var in queryVariableValues)
            {
                var.initialize(types);
            }

            foreach (TaskQueryImpl orQueryObject in orQueryObjects)
            {
                orQueryObject.ensureVariablesInitialized();
            }
        }

        // or query ////////////////////////////////////////////////////////////////

        public virtual ITaskQuery or()
        {
            if (orActive)
            {
                throw new ActivitiException("the query is already in an or statement");
            }

            // Create instance of the orQuery
            orActive = true;
            currentOrQueryObject = new TaskQueryImpl();
            orQueryObjects.Add(currentOrQueryObject);
            return this;
        }

        public virtual ITaskQuery endOr()
        {
            if (!orActive)
            {
                throw new ActivitiException("endOr() can only be called after calling or()");
            }

            orActive = false;
            currentOrQueryObject = null;
            return this;
        }

        // ordering ////////////////////////////////////////////////////////////////

        public virtual ITaskQuery orderByTaskId()
        {
            return orderBy(TaskQueryProperty.TASK_ID);
        }

        public virtual ITaskQuery orderByTaskName()
        {
            return orderBy(TaskQueryProperty.NAME);
        }

        public virtual ITaskQuery orderByTaskDescription()
        {
            return orderBy(TaskQueryProperty.DESCRIPTION);
        }

        public virtual ITaskQuery orderByTaskPriority()
        {
            return orderBy(TaskQueryProperty.PRIORITY);
        }

        public virtual ITaskQuery orderByProcessInstanceId()
        {
            return orderBy(TaskQueryProperty.PROCESS_INSTANCE_ID);
        }

        public virtual ITaskQuery orderByExecutionId()
        {
            return orderBy(TaskQueryProperty.EXECUTION_ID);
        }

        public virtual ITaskQuery orderByProcessDefinitionId()
        {
            return orderBy(TaskQueryProperty.PROCESS_DEFINITION_ID);
        }

        public virtual ITaskQuery orderByTaskAssignee()
        {
            return orderBy(TaskQueryProperty.ASSIGNEE);
        }

        public virtual ITaskQuery orderByTaskOwner()
        {
            return orderBy(TaskQueryProperty.OWNER);
        }

        public virtual ITaskQuery orderByTaskCreateTime()
        {
            return orderBy(TaskQueryProperty.CREATE_TIME);
        }

        public virtual ITaskQuery orderByDueDate()
        {
            return orderBy(TaskQueryProperty.DUE_DATE);
        }

        public virtual ITaskQuery orderByTaskDueDate()
        {
            return orderByDueDate();
        }

        public virtual ITaskQuery orderByTaskDefinitionKey()
        {
            return orderBy(TaskQueryProperty.TASK_DEFINITION_KEY);
        }

        public virtual ITaskQuery orderByDueDateNullsFirst()
        {
            return orderBy(TaskQueryProperty.DUE_DATE, NullHandlingOnOrder.NULLS_FIRST);
        }

        public virtual ITaskQuery orderByDueDateNullsLast()
        {
            return orderBy(TaskQueryProperty.DUE_DATE, NullHandlingOnOrder.NULLS_LAST);
        }

        public virtual ITaskQuery orderByTenantId()
        {
            return orderBy(TaskQueryProperty.TENANT_ID);
        }

        public virtual string MssqlOrDB2OrderBy
        {
            get
            {
                string specialOrderBy = base.OrderBy;
                if (!string.ReferenceEquals(specialOrderBy, null) && specialOrderBy.Length > 0)
                {
                    specialOrderBy = specialOrderBy.Replace("RES.", "TEMPRES_");
                }
                return specialOrderBy;
            }
        }

        // results ////////////////////////////////////////////////////////////////

        public override IList<ITask> executeList(ICommandContext commandContext, Page page)
        {
            ensureVariablesInitialized();
            checkQueryOk();
            IList<ITask> tasks = null;
            if (includeTaskLocalVariables_Renamed || includeProcessVariables_Renamed)
            {
                tasks = commandContext.TaskEntityManager.findTasksAndVariablesByQueryCriteria(this);
            }
            else
            {
                tasks = commandContext.TaskEntityManager.findTasksByQueryCriteria(this);
            }

            if (tasks != null && Context.ProcessEngineConfiguration.PerformanceSettings.EnableLocalization)
            {
                foreach (ITask task in tasks)
                {
                    localize(task);
                }
            }

            return tasks;
        }

        public override long executeCount(ICommandContext commandContext)
        {
            ensureVariablesInitialized();
            checkQueryOk();
            return commandContext.TaskEntityManager.findTaskCountByQueryCriteria(this);
        }

        protected internal virtual void localize(ITask task)
        {
            task.LocalizedName = null;
            task.LocalizedDescription = null;

            if (!string.IsNullOrWhiteSpace(locale_Renamed))
            {
                string processDefinitionId = task.ProcessDefinitionId;
                if (!string.IsNullOrWhiteSpace(processDefinitionId))
                {
                    JToken languageNode = Context.getLocalizationElementProperties(locale_Renamed, task.TaskDefinitionKey, processDefinitionId, withLocalizationFallback_Renamed);
                    if (languageNode != null)
                    {
                        JToken languageNameNode = languageNode[DynamicBpmnConstants_Fields.LOCALIZATION_NAME];
                        if (languageNameNode != null)
                        {
                            task.LocalizedName = languageNameNode.ToString();
                        }

                        JToken languageDescriptionNode = languageNode[DynamicBpmnConstants_Fields.LOCALIZATION_DESCRIPTION];
                        if (languageDescriptionNode != null)
                        {
                            task.LocalizedDescription = languageDescriptionNode.ToString();
                        }
                    }
                }
            }
        }

        // getters ////////////////////////////////////////////////////////////////

        public virtual string Name
        {
            get
            {
                return name;
            }
        }

        public virtual string NameLike
        {
            get
            {
                return nameLike;
            }
        }

        public virtual IList<string> NameList
        {
            get
            {
                return nameList;
            }
        }

        public virtual IList<string> NameListIgnoreCase
        {
            get
            {
                return nameListIgnoreCase;
            }
        }

        public virtual string Assignee
        {
            get
            {
                return assignee;
            }
        }

        public virtual bool Unassigned
        {
            get
            {
                return unassigned;
            }
        }

        public virtual DelegationState? DelegationState
        {
            get
            {
                return delegationState;
            }
        }

        public virtual bool NoDelegationState
        {
            get
            {
                return noDelegationState;
            }
        }

        public virtual string DelegationStateString
        {
            get
            {
                return delegationState.ToString();
            }
        }

        public virtual string CandidateUser
        {
            get
            {
                return candidateUser;
            }
        }

        public virtual string CandidateGroup
        {
            get
            {
                return candidateGroup;
            }
        }

        public virtual string ProcessInstanceId
        {
            get
            {
                return processInstanceId_Renamed;
            }
        }

        public virtual IList<string> ProcessInstanceIds
        {
            get
            {
                return processInstanceIds;
            }
        }

        public virtual string ExecutionId
        {
            get
            {
                return executionId_Renamed;
            }
        }

        public virtual string TaskId
        {
            get
            {
                return taskId_Renamed;
            }
        }

        public virtual string Description
        {
            get
            {
                return description;
            }
        }

        public virtual string DescriptionLike
        {
            get
            {
                return descriptionLike;
            }
        }

        public virtual int? Priority
        {
            get
            {
                return priority;
            }
        }

        public virtual DateTime? CreateTime
        {
            get
            {
                return createTime;
            }
        }

        public virtual DateTime? CreateTimeBefore
        {
            get
            {
                return createTimeBefore;
            }
        }

        public virtual DateTime? CreateTimeAfter
        {
            get
            {
                return createTimeAfter;
            }
        }

        public virtual string Key
        {
            get
            {
                return key;
            }
        }

        public virtual string KeyLike
        {
            get
            {
                return keyLike;
            }
        }

        public virtual string ProcessDefinitionKey
        {
            get
            {
                return processDefinitionKey_Renamed;
            }
        }

        public virtual string ProcessDefinitionId
        {
            get
            {
                return processDefinitionId_Renamed;
            }
        }

        public virtual string ProcessDefinitionName
        {
            get
            {
                return processDefinitionName_Renamed;
            }
        }

        public virtual string ProcessInstanceBusinessKey
        {
            get
            {
                return processInstanceBusinessKey_Renamed;
            }
        }

        public virtual bool ExcludeSubtasks
        {
            get
            {
                return excludeSubtasks_Renamed;
            }
        }

        public virtual string TenantId
        {
            get
            {
                return tenantId;
            }
        }

        public virtual string TenantIdLike
        {
            get
            {
                return tenantIdLike;
            }
        }

        public virtual bool WithoutTenantId
        {
            get
            {
                return withoutTenantId;
            }
        }

        public virtual string UserIdForCandidateAndAssignee
        {
            get
            {
                return userIdForCandidateAndAssignee;
            }
        }

        public virtual IList<TaskQueryImpl> OrQueryObjects
        {
            get
            {
                return orQueryObjects;
            }
            set
            {
                this.orQueryObjects = value;
            }
        }


        public virtual int? MinPriority
        {
            get
            {
                return minPriority;
            }
        }

        public virtual int? MaxPriority
        {
            get
            {
                return maxPriority;
            }
        }

        public virtual string AssigneeLike
        {
            get
            {
                return assigneeLike;
            }
        }

        public virtual IList<string> AssigneeIds
        {
            get
            {
                return assigneeIds;
            }
        }

        public virtual string InvolvedUser
        {
            get
            {
                return involvedUser;
            }
        }

        public virtual IList<string> InvolvedGroups
        {
            get
            {
                return involvedGroups;
            }
        }

        public virtual string Owner
        {
            get
            {
                return owner;
            }
        }

        public virtual string OwnerLike
        {
            get
            {
                return ownerLike;
            }
        }

        public virtual string Category
        {
            get
            {
                return category;
            }
        }

        public virtual string ProcessDefinitionKeyLike
        {
            get
            {
                return processDefinitionKeyLike_Renamed;
            }
        }

        public virtual IList<string> ProcessDefinitionKeys
        {
            get
            {
                return processDefinitionKeys;
            }
        }

        public virtual string ProcessDefinitionNameLike
        {
            get
            {
                return processDefinitionNameLike_Renamed;
            }
        }

        public virtual IList<string> ProcessCategoryInList
        {
            get
            {
                return processCategoryInList;
            }
        }

        public virtual IList<string> ProcessCategoryNotInList
        {
            get
            {
                return processCategoryNotInList;
            }
        }

        public virtual string DeploymentId
        {
            get
            {
                return deploymentId_Renamed;
            }
        }

        public virtual IList<string> DeploymentIds
        {
            get
            {
                return deploymentIds;
            }
        }

        public virtual string ProcessInstanceBusinessKeyLike
        {
            get
            {
                return processInstanceBusinessKeyLike_Renamed;
            }
        }

        public virtual DateTime? DueDate
        {
            get
            {
                return dueDate_Renamed;
            }
        }

        public virtual DateTime? DueBefore
        {
            get
            {
                return dueBefore_Renamed;
            }
        }

        public virtual DateTime? DueAfter
        {
            get
            {
                return dueAfter_Renamed;
            }
        }

        public virtual bool WithoutDueDate
        {
            get
            {
                return withoutDueDate_Renamed;
            }
        }

        public virtual ISuspensionState SuspensionState
        {
            get
            {
                return suspensionState;
            }
        }

        public virtual bool IncludeTaskLocalVariables
        {
            get
            {
                return includeTaskLocalVariables_Renamed;
            }
        }

        public virtual bool IncludeProcessVariables
        {
            get
            {
                return includeProcessVariables_Renamed;
            }
        }

        public virtual bool BothCandidateAndAssigned
        {
            get
            {
                return bothCandidateAndAssigned;
            }
        }

        public virtual string NameLikeIgnoreCase
        {
            get
            {
                return nameLikeIgnoreCase;
            }
        }

        public virtual string DescriptionLikeIgnoreCase
        {
            get
            {
                return descriptionLikeIgnoreCase;
            }
        }

        public virtual string AssigneeLikeIgnoreCase
        {
            get
            {
                return assigneeLikeIgnoreCase;
            }
        }

        public virtual string OwnerLikeIgnoreCase
        {
            get
            {
                return ownerLikeIgnoreCase;
            }
        }

        public virtual string ProcessInstanceBusinessKeyLikeIgnoreCase
        {
            get
            {
                return processInstanceBusinessKeyLikeIgnoreCase_Renamed;
            }
        }

        public virtual string ProcessDefinitionKeyLikeIgnoreCase
        {
            get
            {
                return processDefinitionKeyLikeIgnoreCase_Renamed;
            }
        }

        public virtual string Locale
        {
            get
            {
                return locale_Renamed;
            }
        }

        public virtual bool OrActive
        {
            get
            {
                return orActive;
            }
        }
    }

}