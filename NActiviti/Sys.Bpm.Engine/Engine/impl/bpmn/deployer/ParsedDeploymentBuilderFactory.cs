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
namespace org.activiti.engine.impl.bpmn.deployer
{

	using org.activiti.engine.impl.bpmn.parser;
	using org.activiti.engine.impl.persistence.entity;

	public class ParsedDeploymentBuilderFactory
	{

	  protected internal BpmnParser bpmnParser;

	  public virtual BpmnParser BpmnParser
	  {
		  get
		  {
			return bpmnParser;
		  }
		  set
		  {
			this.bpmnParser = value;
		  }
	  }


	  public virtual ParsedDeploymentBuilder getBuilderForDeployment(IDeploymentEntity deployment)
	  {
		return getBuilderForDeploymentAndSettings(deployment, null);
	  }

	  public virtual ParsedDeploymentBuilder getBuilderForDeploymentAndSettings(IDeploymentEntity deployment, IDictionary<string, object> deploymentSettings)
	  {
		return new ParsedDeploymentBuilder(deployment, bpmnParser, deploymentSettings);
	  }

	}
}