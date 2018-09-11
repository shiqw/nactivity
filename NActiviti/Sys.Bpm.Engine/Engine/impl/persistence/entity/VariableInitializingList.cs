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

namespace org.activiti.engine.impl.persistence.entity
{
    using org.activiti.engine.impl.context;
    using org.activiti.engine.impl.variable;
    using System.Collections;

    /// <summary>
    /// List that initialises binary variable values if command-context is active.
    /// 
    /// 
    /// </summary>
    public class VariableInitializingList : IList<IVariableInstanceEntity>
    {
        private IList<IVariableInstanceEntity> variables = new List<IVariableInstanceEntity>();

        private const long serialVersionUID = 1L;

        public IVariableInstanceEntity this[int index]
        {
            get => variables[index];
            set => variables[index] = value;
        }

        public int Count => throw new System.NotImplementedException();

        public bool IsReadOnly => throw new System.NotImplementedException();

        public virtual void add(int index, IVariableInstanceEntity e)
        {
            variables.Insert(index, e);
            initializeVariable(e);
        }

        public virtual bool add(IVariableInstanceEntity e)
        {
            initializeVariable(e);
            variables.Add(e);
            return true;
        }

        public virtual bool addAll<T1>(ICollection<T1> c) where T1 : IVariableInstanceEntity
        {
            foreach (IVariableInstanceEntity e in c)
            {
                initializeVariable(e);
                variables.Add(e);
            }
            return true;
        }

        public virtual bool addAll<T1>(int index, ICollection<T1> c) where T1 : IVariableInstanceEntity
        {
            foreach (IVariableInstanceEntity e in c)
            {
                initializeVariable(e);
                variables.Add(e);
            }
            return true;
        }

        public void Clear()
        {
            variables?.Clear();
        }

        public bool Contains(IVariableInstanceEntity item)
        {
            return (variables?.Contains(item)).GetValueOrDefault(false);
        }

        public void CopyTo(IVariableInstanceEntity[] array, int arrayIndex)
        {
            variables?.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IVariableInstanceEntity> GetEnumerator()
        {
            return variables?.GetEnumerator();
        }

        public int IndexOf(IVariableInstanceEntity item)
        {
            return (variables?.IndexOf(item)).GetValueOrDefault(-1);
        }

        public void Insert(int index, IVariableInstanceEntity item)
        {
            variables?.Insert(index, item);
        }

        public bool Remove(IVariableInstanceEntity item)
        {
            return (variables?.Remove(item)).GetValueOrDefault(false);
        }

        public void RemoveAt(int index)
        {
            variables?.RemoveAt(index);
        }

        /// <summary>
        /// If the passed <seealso cref="IVariableInstanceEntity"/> is a binary variable and the command-context is active, the variable value is fetched to ensure the byte-array is populated.
        /// </summary>
        protected internal virtual void initializeVariable(IVariableInstanceEntity e)
        {
            if (Context.CommandContext != null && e != null && e.Type != null)
            {
                //e.Value;

                // make sure JPA entities are cached for later retrieval
                if (JPAEntityVariableType.TYPE_NAME.Equals(e.Type.TypeName) || JPAEntityListVariableType.TYPE_NAME.Equals(e.Type.TypeName))
                {
                    ((ICacheableVariable)e.Type).ForceCacheable = true;
                }
            }
        }

        void ICollection<IVariableInstanceEntity>.Add(IVariableInstanceEntity item)
        {
            variables?.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return variables?.GetEnumerator();
        }
    }
}