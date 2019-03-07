﻿using org.activiti.api.runtime.shared.query;
using org.activiti.cloud.services.api.commands;
using org.activiti.cloud.services.api.model;
using org.activiti.cloud.services.api.utils;
using org.activiti.cloud.services.core.pageable;
using org.activiti.engine;
using org.activiti.engine.impl;
using org.activiti.engine.repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace org.activiti.cloud.services.api.commands
{
    public class QueryDeploymentCmd : ICommand
    {
        public string Id => "queryDeploymentCmd";

        public IPage<Deployment> loadPage(IRepositoryService repositoryService, 
            PageableDeploymentRespositoryService pageableRepositoryService, 
            DeploymentQuery qo)
        {
            DeploymentQueryImpl query = repositoryService.createDeploymentQuery() as DeploymentQueryImpl;

            FastCopy.Copy<DeploymentQuery, DeploymentQueryImpl>(qo, query);

            pageableRepositoryService.SortApplier.applySort(query, qo.Pageable);

            IPage<Deployment> defs = pageableRepositoryService.PageRetriever.loadPage(query, qo.Pageable, pageableRepositoryService.DeploymentConverter);

            return defs;
        }
    }
}