﻿using Sys.Workflow.Api.Runtime.Shared.Query;
using Sys.Workflow.Engine.Impl;
using Sys.Workflow.Engine.Query;
using Sys.Workflow.Engine.Runtime;
using System;
using System.Collections.Generic;

/*
 * Licensed under the Apache License, Version 2.0 (the "License");
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
 *
 */

namespace Sys.Workflow.Cloud.Services.Core.Pageables.Sorts
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessInstanceSortApplier : BaseSortApplier<IProcessInstanceQuery, IProcessInstance>
    {

        private readonly IDictionary<string, IQueryProperty> orderByProperties = new Dictionary<string, IQueryProperty>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 
        /// </summary>
        public ProcessInstanceSortApplier()
        {
            orderByProperties["id"] = ProcessInstanceQueryProperty.PROCESS_INSTANCE_ID;
            orderByProperties["processDefinitionId"] = ProcessInstanceQueryProperty.PROCESS_DEFINITION_ID;
            orderByProperties["startDate"] = ProcessInstanceQueryProperty.PROCESS_EXECUTION_STARTDATE;
            orderByProperties["name"] = ProcessInstanceQueryProperty.PROCESS_EXECUTION_NAME;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void ApplyDefaultSort(IProcessInstanceQuery query)
        {
            query.OrderByProcessInstanceId().Asc();
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override IQueryProperty GetOrderByProperty(Sort.Order order)
        {
            orderByProperties.TryGetValue(order.Property, out IQueryProperty qp);

            return qp;
        }
    }

}