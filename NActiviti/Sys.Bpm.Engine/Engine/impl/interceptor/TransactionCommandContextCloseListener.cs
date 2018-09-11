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

namespace org.activiti.engine.impl.interceptor
{
    using org.activiti.engine.impl.cfg;

    /// 
    public class TransactionCommandContextCloseListener : ICommandContextCloseListener
    {

        protected internal ITransactionContext transactionContext;

        public TransactionCommandContextCloseListener(ITransactionContext transactionContext)
        {
            this.transactionContext = transactionContext;
        }

        public virtual void closing(ICommandContext commandContext)
        {

        }

        public virtual void afterSessionsFlush(ICommandContext commandContext)
        {
            transactionContext.commit();
        }

        public virtual void closed(ICommandContext commandContext)
        {

        }

        public virtual void closeFailure(ICommandContext commandContext)
        {
            transactionContext.rollback();
        }

    }

}