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
namespace Sys.Workflow.Bpmn.Converters
{
    using Sys.Workflow.Bpmn.Constants;
    using Sys.Workflow.Bpmn.Converters.Utils;
    using Sys.Workflow.Bpmn.Models;

    /// 
    public class ComplexGatewayXMLConverter : BaseBpmnXMLConverter
    {

        public override Type BpmnElementType
        {
            get
            {
                // complex gateway is not supported so transform it to exclusive gateway
                return typeof(ComplexGateway);
            }
        }

        public override string XMLElementName
        {
            get
            {
                return BpmnXMLConstants.ELEMENT_GATEWAY_COMPLEX;
            }
        }
        protected internal override BaseElement ConvertXMLToElement(XMLStreamReader xtr, BpmnModel model)
        {
            ExclusiveGateway gateway = new ExclusiveGateway();
            BpmnXMLUtil.AddXMLLocation(gateway, xtr);
            ParseChildElements(XMLElementName, gateway, model, xtr);
            return gateway;
        }
        protected internal override void WriteAdditionalAttributes(BaseElement element, BpmnModel model, XMLStreamWriter xtw)
        {
        }
        protected internal override void WriteAdditionalChildElements(BaseElement element, BpmnModel model, XMLStreamWriter xtw)
        {

        }
    }

}