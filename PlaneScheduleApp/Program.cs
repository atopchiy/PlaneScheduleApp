using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlaneScheduleApp;
using PlaneScheduleApp.Operations.Flights;
using PlaneScheduleApp.Operations.Orders;
using PlaneScheduleApp.Services.AppStarterService;
using PlaneScheduleApp.Services.DataOutputProvider;
using PlaneScheduleApp.Services.FileService;

using var host = CreateHostBuilder().Build();

using var scope = host.Services.CreateScope();

var serviceProvider = scope.ServiceProvider;
var appStart = serviceProvider.GetService<AppStarterService>()
    ?? throw new InvalidOperationException("App start service is not registered");
appStart.Run();


IHostBuilder CreateHostBuilder()
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            RegisterDb(services);
            RegisterServices(services);
            RegisterOperations(services);
        });
}

void RegisterServices(IServiceCollection serviceCollection)
{
    serviceCollection.AddScoped<IDataOutputProvider, ConsoleDataOutputProvider>();
    serviceCollection.AddScoped<IDataOutputProvider, FileDataOutputProvider>();
    serviceCollection.AddScoped<DataOutputResolver>();
    serviceCollection.AddScoped<AppStarterService>();
    serviceCollection.AddScoped<IFileService, FileService>();
}

void RegisterDb(IServiceCollection serviceCollection)
{
    serviceCollection.AddSingleton<PlaneScheduleDb>();
}

void RegisterOperations(IServiceCollection serviceCollection)
{
    serviceCollection.AddScoped<FlightGetList>();
    serviceCollection.AddScoped<OrderGetListFromFile>();
}
