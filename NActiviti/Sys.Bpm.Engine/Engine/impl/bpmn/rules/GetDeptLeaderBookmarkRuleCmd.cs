///////////////////////////////////////////////////////////
//  GetDeptLeaderBookmarkRuleCmd.cs
//  Implementation of the Class GetDeptLeaderBookmarkRuleCmd
//  Generated by Enterprise Architect
//  Created on:      30-1月-2019 8:32:00
//  Original author: 张楠
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys.Workflow.Engine.Impl.Interceptor;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Sys.Workflow.Engine.Bpmn.Rules
{
    /// <summary>
    /// 根据人员id查找所在部门领导
    /// </summary>
    [GetBookmarkDescriptor("GetDeptLeader")]
    public class GetDeptLeaderBookmarkRuleCmd : BaseGetBookmarkRule
    {
        private readonly ExternalConnectorProvider externalConnector;

        /// <inheritdoc />
        public GetDeptLeaderBookmarkRuleCmd()
        {
            externalConnector = ProcessEngineServiceProvider.Resolve<ExternalConnectorProvider>();
        }

        /// <inheritdoc />
        public override IList<IUserInfo> Execute(ICommandContext commandContext)
        {
            IUserServiceProxy proxy = ProcessEngineServiceProvider.Resolve<IUserServiceProxy>();

            return AsyncHelper.RunSync(() => proxy.GetUsers(externalConnector.GetUserByDeptLeader, new
            {
                idList = Condition.QueryCondition.Select(x => x.Id).ToArray()
            }));
        }
    }
}