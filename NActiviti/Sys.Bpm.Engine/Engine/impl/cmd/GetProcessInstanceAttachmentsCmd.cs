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

namespace Sys.Workflow.Engine.Impl.Cmd
{

    using Sys.Workflow.Engine.Impl.Interceptor;
    using Sys.Workflow.Engine.Impl.Persistence.Entity;
    using Sys.Workflow.Engine.Tasks;

    /// 
    [Serializable]
    public class GetProcessInstanceAttachmentsCmd : ICommand<IList<IAttachmentEntity>>
    {

        private const long serialVersionUID = 1L;
        protected internal string processInstanceId;

        public GetProcessInstanceAttachmentsCmd(string taskId)
        {
            this.processInstanceId = taskId;
        }

        public virtual IList<IAttachmentEntity> Execute(ICommandContext commandContext)
        {
            return commandContext.AttachmentEntityManager.FindAttachmentsByProcessInstanceId(processInstanceId);
        }
    }

}