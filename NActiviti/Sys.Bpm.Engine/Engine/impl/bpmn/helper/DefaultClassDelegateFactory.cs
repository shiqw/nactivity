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
namespace Sys.Workflow.Engine.Impl.Bpmn.Helper
{

    using Sys.Workflow.Bpmn.Models;
    using Sys.Workflow.Engine.Delegate;
    using Sys.Workflow.Engine.Impl.Bpmn.Parser;

    public class DefaultClassDelegateFactory : IClassDelegateFactory
    {
        public virtual ClassDelegate Create(string id, string className, IList<FieldDeclaration> fieldDeclarations, IExpression skipExpression, IList<MapExceptionEntry> mapExceptions)
        {
            return new ClassDelegate(id, className, fieldDeclarations, skipExpression, mapExceptions);
        }

        public virtual ClassDelegate Create(string className, IList<FieldDeclaration> fieldDeclarations)
        {
            return new ClassDelegate(className, fieldDeclarations);
        }
    }

}