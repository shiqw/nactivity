import Axios from 'axios';
import { EventAggregator } from "aurelia-event-aggregator";
import { inject } from 'aurelia-framework';
import { BaseForm } from './baseform';
import contants from '../contants';

export class BaseInfo extends BaseForm {

    isTecher = false;

    constructor(...args) {
        super(args[0], args[1]);
    }

    submit() {

        if (this.workflow == null){
            alert('先选择流程');
            return;
        }

        this.es.publish("registeredUser", this.user);

        Axios.post(`${contants.serverUrl}/workflow/process-instances/start`, {
            processDefinitionKey: this.workflow.key,
            businessKey: this.workflow.businessKey,
            variables: {
                "name": this.user.name,
                "initiator": this.user.name,
                "isTecher": this.isTecher
            }
        }).then((res) => {
            this.es.publish("reloadMyTasks");
            this.es.publish("started", res.data);
        }).catch((res) => {
            alert("是不是没有启动服务或是没有选择流程!那么就是未知错误喽.");
        });
    }
}