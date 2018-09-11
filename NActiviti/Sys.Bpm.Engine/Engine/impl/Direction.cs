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

namespace org.activiti.engine.impl
{

    /// 
    public class Direction
    {

        private static readonly IDictionary<string, Direction> directions = new Dictionary<string, Direction>();

        public static readonly Direction ASCENDING = new Direction("asc");
        public static readonly Direction DESCENDING = new Direction("desc");

        private string name;

        public Direction(string name)
        {
            this.name = name;
            directions[name] = this;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
        }

        public static Direction findByName(string directionName)
        {
            return directions[directionName];
        }
    }

}