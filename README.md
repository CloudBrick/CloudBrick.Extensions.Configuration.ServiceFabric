## How to use:

Added your settings to the service Settings.xml. 
Use the section name to define the settings based on the environment name and add 
the parameters same as in appsettings.json delimited by :

### Example: 
```
<?xml version="1.0" encoding="utf-8" ?>
<Settings xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2011/01/fabric">
  <!-- Add your custom configuration sections and parameters here -->
  
  <Section Name="Production">
    <Parameter Name="ConnectionStrings:DefaultConnection" Value="Some Production server database connection string" />
  </Section>
  <Section Name="Development">
    <Parameter Name="ConnectionStrings:DefaultConnection" Value="Some local Server database connection string" />
  </Section>
</Settings>
```

## Register the provider: 

```
protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");
                        return new WebHostBuilder()
                                    .UseKestrel()
                                    .ConfigureAppConfiguration(
                                        (h,c) =>
                                                c.AddServiceFabricSettings(serviceContext,h.HostingEnvironment))
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<StatelessServiceContext>(serviceContext))
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls(url)
                                    .Build();
                    }))
            };
        }
```
