// ------------------------------------------------------------
//  Copyright (c) CloudBrick.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------
using CloudBrick.Extensions.Configuration.ServiceFabric;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Text;

namespace Microsoft.Extensions.Configuration.ServiceFabric
{
    public static class ServiceFabricConfigurationExtensions
    {
        public static IConfigurationBuilder AddServiceFabricSettings(this IConfigurationBuilder builder, ServiceContext serviceContext,IHostingEnvironment environment)
        {
           return builder.Add(new ServiceFabricConfigurationSource(serviceContext,environment.EnvironmentName));            
        }
    }

}
