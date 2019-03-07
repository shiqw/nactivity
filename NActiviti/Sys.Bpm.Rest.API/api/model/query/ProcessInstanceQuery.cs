﻿using org.activiti.api.runtime.shared.query;
using org.activiti.engine.impl.persistence.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace org.activiti.cloud.services.api.model
{
    /// <summary>
    /// 流程实例查询条件对象
    /// </summary>
    public class ProcessInstanceQuery : AbstractQuery
    {
        public ProcessInstanceQuery()
        {

        }

        /// <summary>
        /// 业务键
        /// </summary>
        public string BusinessKey { get; set; }

        /// <summary>
        /// 流程部署id
        /// </summary>
        public string DeploymentId { get; set; }

        /// <summary>
        /// 查询多个流程部署id
        /// </summary>
        public IList<string> DeploymentIds { get; set; }

        /// <summary>
        /// 是否排除子流程
        /// </summary>
        public bool? ExcludeSubprocesses { get; set; } = true;

        /// <summary>
        /// 流程实例id
        /// </summary>
        public string ExecutionId { get; set; }

        /// <summary>
        /// 包含指定业务键的子流程
        /// </summary>
        public bool? IncludeChildExecutionsWithBusinessKeyQuery { get; set; } = false;

        /// <summary>
        /// 是否包含流程变量
        /// </summary>
        public bool? IncludeProcessVariables { get; set; } = false;

        /// <summary>
        /// 查询分配人
        /// </summary>
        public string InvolvedUser { get; set; }

        /// <summary>
        /// 是否查询包含异常的作业任务
        /// </summary>
        public bool? IsWithException { get; set; } = false;

        /// <summary>
        /// 仅查询子流程
        /// </summary>
        public bool? OnlyChildExecutions { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool? OnlyProcessInstanceExecutions { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool? OnlyProcessInstances { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool? OnlySubProcessExecutions { get; set; } = false;

        /// <summary>
        /// 上级流程实例id
        /// </summary>
        public string ParentId { get; }

        /// <summary>
        /// 流程定义目录
        /// </summary>
        public string ProcessDefinitionCategory { get; set; }

        /// <summary>
        /// 流程定义id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 多个流程定义id
        /// </summary>
        public string[] ProcessDefinitionIds { get; set; }

        /// <summary>
        /// 流程定义业务键
        /// </summary>
        public string ProcessDefinitionKey { get; set; }

        /// <summary>
        /// 流程定义业务键列表
        /// </summary>
        public string[] ProcessDefinitionKeys { get; set; }

        /// <summary>
        /// 流程定义名称
        /// </summary>
        public string ProcessDefinitionName { get; set; }

        /// <summary>
        /// 流程定义版本号
        /// </summary>
        public int? ProcessDefinitionVersion { get; set; }

        /// <summary>
        /// 流程实例id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程实例id列表
        /// </summary>
        public string[] ProcessInstanceIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ProcessInstanceVariablesLimit { get; }

        /// <summary>
        /// 在某个时间之后开始
        /// </summary>
        public DateTime? StartedAfter { get; set; }

        /// <summary>
        /// 在某个时间之前开始
        /// </summary>
        public DateTime? StartedBefore { get; set; }

        /// <summary>
        /// 启动用户
        /// </summary>
        public string StartedBy { get; set; }

        /// <summary>
        /// 子流程id
        /// </summary>
        public string SubProcessInstanceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SuperProcessInstanceId { get; set; }

        /// <summary>
        /// 流程挂起状态
        /// </summary>
        public ISuspensionState SuspensionState { get; set; }

        /// <summary>
        /// 是否不使用租户id
        /// </summary>
        public bool? WithoutTenantId { get; set; } = false;
    }
}