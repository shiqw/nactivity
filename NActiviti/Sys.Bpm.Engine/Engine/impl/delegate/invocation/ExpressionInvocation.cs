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
using Sys.Workflow.Engine.Impl.EL;

namespace Sys.Workflow.Engine.Impl.Delegate.Invocation
{

    /// <summary>
    /// Baseclass responsible for handling invocations of Expressions
    /// 
    /// 
    /// </summary>
    public abstract class ExpressionInvocation : DelegateInvocation
    {
        /// <summary>
        /// 
        /// </summary>
        protected internal readonly ValueExpression valueExpression;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueExpression"></param>
        public ExpressionInvocation(ValueExpression valueExpression)
        {
            this.valueExpression = valueExpression;
        }

        /// <summary>
        /// 
        /// </summary>
        public override object Target
        {
            get
            {
                return valueExpression;
            }
        }
    }
}