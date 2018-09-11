﻿using System;

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
namespace org.activiti.engine.impl.bpmn.data
{
    using org.activiti.engine.@delegate;
    using org.activiti.engine.impl.persistence.entity;

    /// <summary>
    /// A transformation based data output association
    /// 
    /// 
    /// </summary>
    [Serializable]
    public class TransformationDataOutputAssociation : AbstractDataAssociation
    {

        private const long serialVersionUID = 1L;

        protected internal IExpression transformation;

        public TransformationDataOutputAssociation(string sourceRef, string targetRef, IExpression transformation) : base(sourceRef, targetRef)
        {
            this.transformation = transformation;
        }

        public override void evaluate(IExecutionEntity execution)
        {
            object value = this.transformation.getValue(execution);
            execution.setVariable(this.Target, value);
        }
    }

}