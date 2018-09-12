// ------------------------------------------------------------
//  Copyright (c) CloudBrick.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Text;

namespace CloudBrick.Extensions.Configuration.ServiceFabric
{
    internal class ServiceFabricConfigurationSource : IConfigurationSource
    {
        private readonly ServiceContext _serviceContext;
        private readonly string _environmentName;
        public ServiceFabricConfigurationSource(ServiceContext serviceContext, string environmentName)
        {
            _serviceContext = serviceContext;
            _environmentName = environmentName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder) => new ServiceFabricConfigurationProvider(_serviceContext, _environmentName);
    }
}
