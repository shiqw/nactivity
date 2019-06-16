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

namespace Sys.Workflow.Engine.Impl.Persistence.Entity.Data
{

    /// 
    public interface IDataManager<EntityImpl> where EntityImpl : IEntity
    {

        EntityImpl Create();

        TOut FindById<TOut>(KeyValuePair<string, object> entityId);

        void Insert(EntityImpl entity);

        EntityImpl Update(EntityImpl entity);

        void Delete(KeyValuePair<string, object> entityId);

        void Delete(EntityImpl entity);

    }

}