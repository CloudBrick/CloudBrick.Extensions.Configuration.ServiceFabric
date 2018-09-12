using Microsoft.Extensions.Configuration;
using System;
using System.Fabric;
using System.Linq;


namespace CloudBrick.Extensions.Configuration.ServiceFabric
{
    internal class ServiceFabricConfigurationProvider : ConfigurationProvider
    {
        private readonly ServiceContext _serviceContext;
        private readonly string _environmentName;
        public ServiceFabricConfigurationProvider(ServiceContext serviceContext,string environmentName)
        {
            _serviceContext = serviceContext;
            _environmentName = environmentName;
        }

        public override void Load()
        {
            var config = _serviceContext.CodePackageActivationContext.GetConfigurationPackageObject("Config");

            var section = config.Settings.Sections.FirstOrDefault(x => x.Name == _environmentName);
            if (section == null) return;

            section.Parameters.ToList()
                .ForEach(parameter =>
                Data[parameter.Name] = parameter.Value);
        }
    }
}
