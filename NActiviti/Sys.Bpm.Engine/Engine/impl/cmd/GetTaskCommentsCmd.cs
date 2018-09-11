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

    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.task;

    /// 
    [Serializable]
    public class GetTaskCommentsCmd : ICommand<IList<IComment>>
    {

        private const long serialVersionUID = 1L;
        protected internal string taskId;

        public GetTaskCommentsCmd(string taskId)
        {
            this.taskId = taskId;
        }

        public virtual IList<IComment> execute(ICommandContext commandContext)
        {
            return commandContext.CommentEntityManager.findCommentsByTaskId(taskId);
        }
    }

}