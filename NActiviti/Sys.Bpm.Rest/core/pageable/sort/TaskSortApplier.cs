﻿using org.activiti.engine.impl;
using org.activiti.engine.query;
using org.activiti.engine.task;
using org.springframework.data.domain;
using System.Collections.Generic;

/*
 * Copyright 2018 Alfresco, Inc. and/or its affiliates.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace org.activiti.cloud.services.core.pageable.sort
{
    //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
    //ORIGINAL LINE: @Component public class TaskSortApplier extends BaseSortApplier<org.activiti.engine.task.TaskQuery>
    public class TaskSortApplier : BaseSortApplier<ITaskQuery, ITask>
    {
        private IDictionary<string, IQueryProperty> orderByProperties = new Dictionary<string, IQueryProperty>();

        public TaskSortApplier()
        {
            orderByProperties["id"] = TaskQueryProperty.TASK_ID;
            orderByProperties["name"] = TaskQueryProperty.NAME;
            orderByProperties["assignee"] = TaskQueryProperty.ASSIGNEE;
        }

        protected internal override void applyDefaultSort(ITaskQuery query)
        {
            query.orderByTaskId().asc();
        }

        protected internal override IQueryProperty getOrderByProperty(Sort.Order order)
        {
            return orderByProperties[order.Property];
        }
    }
}