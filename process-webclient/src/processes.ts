import { inject } from "aurelia-framework";
import { EventAggregator } from "aurelia-event-aggregator";


@inject(EventAggregator)
export class Processes {
  defines = [
    {
      id: 1,
      key: "Process_0",
      name: '会议注册路径',
      xml: `<?xml version="1.0" encoding="UTF-8"?>
            <bpmn2:definitions xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:bpmn2="http://www.omg.org/spec/BPMN/20100524/MODEL" xmlns:bpmndi="http://www.omg.org/spec/BPMN/20100524/DI" xmlns:dc="http://www.omg.org/spec/DD/20100524/DC" xmlns:di="http://www.omg.org/spec/DD/20100524/DI" xmlns:camunda="http://camunda.org/schema/1.0/bpmn" id="sample-diagram" targetNamespace="http://bpmn.io/schema/bpmn" xsi:schemaLocation="http://www.omg.org/spec/BPMN/20100524/MODEL BPMN20.xsd">
              <bpmn2:process id="Process_0" isExecutable="true">
                <bpmn2:startEvent id="StartEvent_1">
                  <bpmn2:outgoing>SequenceFlow_0ihgz1d</bpmn2:outgoing>
                </bpmn2:startEvent>
                <bpmn2:sequenceFlow id="SequenceFlow_0ihgz1d" sourceRef="StartEvent_1" targetRef="Task_085qd6k" />
                <bpmn2:userTask id="Task_0opugm1" name="教师注册" camunda:formKey="3">
                  <bpmn2:incoming>SequenceFlow_1kbdvpj</bpmn2:incoming>
                </bpmn2:userTask>
                <bpmn2:sequenceFlow id="SequenceFlow_1kbdvpj" sourceRef="Task_085qd6k" targetRef="Task_0opugm1" />
                <bpmn2:userTask id="Task_085qd6k" name="学生注册" camunda:formKey="2">
                  <bpmn2:incoming>SequenceFlow_0ihgz1d</bpmn2:incoming>
                  <bpmn2:outgoing>SequenceFlow_1kbdvpj</bpmn2:outgoing>
                </bpmn2:userTask>
              </bpmn2:process>
              <bpmndi:BPMNDiagram id="BPMNDiagram_1">
                <bpmndi:BPMNPlane id="BPMNPlane_1" bpmnElement="Process_1">
                  <bpmndi:BPMNShape id="_BPMNShape_StartEvent_2" bpmnElement="StartEvent_1">
                    <dc:Bounds x="127" y="161" width="36" height="36" />
                  </bpmndi:BPMNShape>
                  <bpmndi:BPMNEdge id="SequenceFlow_0ihgz1d_di" bpmnElement="SequenceFlow_0ihgz1d">
                    <di:waypoint x="163" y="179" />
                    <di:waypoint x="338" y="179" />
                  </bpmndi:BPMNEdge>
                  <bpmndi:BPMNShape id="UserTask_16tu8q7_di" bpmnElement="Task_0opugm1">
                    <dc:Bounds x="567" y="139" width="100" height="80" />
                  </bpmndi:BPMNShape>
                  <bpmndi:BPMNEdge id="SequenceFlow_1kbdvpj_di" bpmnElement="SequenceFlow_1kbdvpj">
                    <di:waypoint x="438" y="179" />
                    <di:waypoint x="567" y="179" />
                  </bpmndi:BPMNEdge>
                  <bpmndi:BPMNShape id="UserTask_0ornknv_di" bpmnElement="Task_085qd6k">
                    <dc:Bounds x="338" y="139" width="100" height="80" />
                  </bpmndi:BPMNShape>
                </bpmndi:BPMNPlane>
              </bpmndi:BPMNDiagram>
            </bpmn2:definitions>`
    },
    {
      id: 2,
      key: "Process_1",
      name: '条件会议注册路径',
      xml: `<?xml version="1.0" encoding="UTF-8"?>
            <bpmn2:definitions xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:bpmn2="http://www.omg.org/spec/BPMN/20100524/MODEL" xmlns:bpmndi="http://www.omg.org/spec/BPMN/20100524/DI" xmlns:dc="http://www.omg.org/spec/DD/20100524/DC" xmlns:di="http://www.omg.org/spec/DD/20100524/DI" xmlns:camunda="http://camunda.org/schema/1.0/bpmn" id="sample-diagram" targetNamespace="http://bpmn.io/schema/bpmn" xsi:schemaLocation="http://www.omg.org/spec/BPMN/20100524/MODEL BPMN20.xsd">
              <bpmn2:process id="Process_1" name="条件会议注册路径" isExecutable="true">
                <bpmn2:startEvent id="StartEvent_1">
                  <bpmn2:outgoing>SequenceFlow_0ihgz1d</bpmn2:outgoing>
                </bpmn2:startEvent>
                <bpmn2:sequenceFlow id="SequenceFlow_0ihgz1d" name="从基本信息提交的数据判断会议注册人是否为教师" sourceRef="StartEvent_1" targetRef="ExclusiveGateway_1y6gcmn" />
                <bpmn2:userTask id="Task_0opugm1" name="教师注册" camunda:formKey="3">
                  <bpmn2:incoming>SequenceFlow_1gm6tlc</bpmn2:incoming>
                </bpmn2:userTask>
                <bpmn2:userTask id="Task_085qd6k" name="学生注册" camunda:formKey="2">
                  <bpmn2:incoming>SequenceFlow_0uc2k2q</bpmn2:incoming>
                </bpmn2:userTask>
                <bpmn2:exclusiveGateway id="ExclusiveGateway_1y6gcmn">
                  <bpmn2:incoming>SequenceFlow_0ihgz1d</bpmn2:incoming>
                  <bpmn2:outgoing>SequenceFlow_1gm6tlc</bpmn2:outgoing>
                  <bpmn2:outgoing>SequenceFlow_0uc2k2q</bpmn2:outgoing>
                </bpmn2:exclusiveGateway>
                <bpmn2:sequenceFlow id="SequenceFlow_1gm6tlc" name="如果是教师跳转教师注册" sourceRef="ExclusiveGateway_1y6gcmn" targetRef="Task_0opugm1">
                  <bpmn2:conditionExpression xsi:type="bpmn2:tFormalExpression">\${isTecher==true}</bpmn2:conditionExpression>
                </bpmn2:sequenceFlow>
                <bpmn2:sequenceFlow id="SequenceFlow_0uc2k2q" name="如果不是教师跳转学生注册" sourceRef="ExclusiveGateway_1y6gcmn" targetRef="Task_085qd6k">
                  <bpmn2:conditionExpression xsi:type="bpmn2:tFormalExpression">\${isTecher==false}</bpmn2:conditionExpression>
                </bpmn2:sequenceFlow>
              </bpmn2:process>
              <bpmndi:BPMNDiagram id="BPMNDiagram_1">
                <bpmndi:BPMNPlane id="BPMNPlane_1" bpmnElement="Process_1">
                  <bpmndi:BPMNShape id="_BPMNShape_StartEvent_2" bpmnElement="StartEvent_1">
                    <dc:Bounds x="127" y="161" width="36" height="36" />
                  </bpmndi:BPMNShape>
                  <bpmndi:BPMNEdge id="SequenceFlow_0ihgz1d_di" bpmnElement="SequenceFlow_0ihgz1d">
                    <di:waypoint x="163" y="179" />
                    <di:waypoint x="308" y="179" />
                    <bpmndi:BPMNLabel>
                      <dc:Bounds x="190" y="136" width="88" height="40" />
                    </bpmndi:BPMNLabel>
                  </bpmndi:BPMNEdge>
                  <bpmndi:BPMNShape id="UserTask_16tu8q7_di" bpmnElement="Task_0opugm1">
                    <dc:Bounds x="535" y="245" width="100" height="80" />
                  </bpmndi:BPMNShape>
                  <bpmndi:BPMNShape id="UserTask_0ornknv_di" bpmnElement="Task_085qd6k">
                    <dc:Bounds x="535" y="48" width="100" height="80" />
                  </bpmndi:BPMNShape>
                  <bpmndi:BPMNShape id="ExclusiveGateway_1y6gcmn_di" bpmnElement="ExclusiveGateway_1y6gcmn" isMarkerVisible="true">
                    <dc:Bounds x="308" y="154" width="50" height="50" />
                  </bpmndi:BPMNShape>
                  <bpmndi:BPMNEdge id="SequenceFlow_1gm6tlc_di" bpmnElement="SequenceFlow_1gm6tlc">
                    <di:waypoint x="333" y="204" />
                    <di:waypoint x="333" y="285" />
                    <di:waypoint x="535" y="285" />
                    <bpmndi:BPMNLabel>
                      <dc:Bounds x="340" y="256" width="77" height="27" />
                    </bpmndi:BPMNLabel>
                  </bpmndi:BPMNEdge>
                  <bpmndi:BPMNEdge id="SequenceFlow_0uc2k2q_di" bpmnElement="SequenceFlow_0uc2k2q">
                    <di:waypoint x="333" y="154" />
                    <di:waypoint x="333" y="88" />
                    <di:waypoint x="535" y="88" />
                    <bpmndi:BPMNLabel>
                      <dc:Bounds x="338" y="93" width="77" height="27" />
                    </bpmndi:BPMNLabel>
                  </bpmndi:BPMNEdge>
                </bpmndi:BPMNPlane>
              </bpmndi:BPMNDiagram>
            </bpmn2:definitions>
            `
    }
  ]

  constructor(private es: EventAggregator) {

  }

  selected(id) {
    this.es.publish("openWorkflow", this.defines.find(x => x.id == id));
  }
}