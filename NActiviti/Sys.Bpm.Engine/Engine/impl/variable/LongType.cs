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
namespace org.activiti.engine.impl.variable
{
    /// 
    public class LongType : AbstractVariableType
    {

        private const long serialVersionUID = 1L;

        public override string TypeName
        {
            get
            {
                return "long";
            }
        }

        public override bool Cachable
        {
            get
            {
                return true;
            }
        }

        public override object getValue(IValueFields valueFields)
        {
            return valueFields.LongValue;
        }

        public override void setValue(object value, IValueFields valueFields)
        {
            valueFields.LongValue = (long?)value;
            if (value != null)
            {
                valueFields.TextValue = value.ToString();
            }
            else
            {
                valueFields.TextValue = null;
            }
        }

        public override bool isAbleToStore(object value)
        {
            if (value == null)
            {
                return true;
            }
            return value.GetType().IsAssignableFrom(typeof(long)) || value.GetType().IsAssignableFrom(typeof(long));
        }
    }

}