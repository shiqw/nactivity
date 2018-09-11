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
namespace org.activiti.engine.impl.persistence.entity.data
{

	using org.activiti.engine.history;


	public interface IHistoricDetailDataManager : IDataManager<IHistoricDetailEntity>
	{

	  IHistoricDetailAssignmentEntity createHistoricDetailAssignment();

	  IHistoricDetailTransitionInstanceEntity createHistoricDetailTransitionInstance();

	  IHistoricDetailVariableInstanceUpdateEntity createHistoricDetailVariableInstanceUpdate();

	  IList<IHistoricDetailEntity> findHistoricDetailsByProcessInstanceId(string processInstanceId);

	  IList<IHistoricDetailEntity> findHistoricDetailsByTaskId(string taskId);

	  long findHistoricDetailCountByQueryCriteria(IHistoricDetailQuery historicVariableUpdateQuery);

	  IList<IHistoricDetail> findHistoricDetailsByQueryCriteria(IHistoricDetailQuery historicVariableUpdateQuery, Page page);

	  IList<IHistoricDetail> findHistoricDetailsByNativeQuery(IDictionary<string, object> parameterMap, int firstResult, int maxResults);

	  long findHistoricDetailCountByNativeQuery(IDictionary<string, object> parameterMap);

	}

}