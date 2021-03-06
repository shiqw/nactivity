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
using System.Collections.Generic;

namespace Sys.Workflow.Engine.Impl.Persistence.Entity
{

    /// 
    public interface IProcessDefinitionInfoEntityManager : IEntityManager<IProcessDefinitionInfoEntity>
    {

        void InsertProcessDefinitionInfo(IProcessDefinitionInfoEntity processDefinitionInfo);

        void UpdateProcessDefinitionInfo(IProcessDefinitionInfoEntity updatedProcessDefinitionInfo);

        void DeleteProcessDefinitionInfo(string processDefinitionId);

        void UpdateInfoJson(string id, byte[] json);

        void DeleteInfoJson(IProcessDefinitionInfoEntity processDefinitionInfo);

        new IProcessDefinitionInfoEntity FindById<IProcessDefinitionInfoEntity>(KeyValuePair<string, object> id);

        IProcessDefinitionInfoEntity FindProcessDefinitionInfoByProcessDefinitionId(string processDefinitionId);

        byte[] FindInfoJsonById(string infoJsonId);
    }
}