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

namespace Sys.Workflow.Engine.Impl.Variable
{
    using Sys.Workflow.Engine.Impl.Interceptor;
    using Sys.Data;

    /// 
    public interface IEntityManagerSession : ISession
    {
        /// <summary>
        /// Get an <seealso cref="EntityManager"/> instance associated with this session.
        /// </summary>
        /// <exception cref="ActivitiException">
        ///           when no <seealso cref="EntityManagerFactory"/> instance is configured for the process engine. </exception>
        IEntityManager EntityManager { get; }
    }

}