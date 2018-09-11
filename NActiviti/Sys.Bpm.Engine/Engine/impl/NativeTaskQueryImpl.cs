﻿using System;
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

namespace org.activiti.engine.impl
{

    using org.activiti.engine.impl.interceptor;
    using org.activiti.engine.task;

    [Serializable]
    public class NativeTaskQueryImpl : AbstractNativeQuery<INativeTaskQuery, ITask>, INativeTaskQuery
    {

        private const long serialVersionUID = 1L;

        public NativeTaskQueryImpl(ICommandContext commandContext) : base(commandContext)
        {
        }

        public NativeTaskQueryImpl(ICommandExecutor commandExecutor) : base(commandExecutor)
        {
        }

        // results ////////////////////////////////////////////////////////////////

        public override IList<ITask> executeList(ICommandContext commandContext, IDictionary<string, object> parameterMap, int firstResult, int maxResults)
        {
            return commandContext.TaskEntityManager.findTasksByNativeQuery(parameterMap, firstResult, maxResults);
        }

        public override long executeCount(ICommandContext commandContext, IDictionary<string, object> parameterMap)
        {
            return commandContext.TaskEntityManager.findTaskCountByNativeQuery(parameterMap);
        }

    }

}