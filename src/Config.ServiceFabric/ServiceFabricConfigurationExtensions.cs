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
