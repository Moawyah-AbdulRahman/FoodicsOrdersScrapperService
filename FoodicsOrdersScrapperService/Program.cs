using FoodicsOrdersScrapperService.application;
using FoodicsOrdersScrapperService.domain.persistance;
using FoodicsOrdersScrapperService.domain.services;
using FoodicsOrdersScrapperService.infrastructure.persistance;
using FoodicsOrdersScrapperService.infrastructure.webClients;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        services.AddHostedService<OrdersScrapingWorker>();

        services.AddSingleton<IOrderScrappingService, OrderScrappingService>();
        services.AddSingleton<IOrderWebSource, OrderWebSource>();
        services.AddSingleton<IOrderRepository, OrderRepository>();

        services.AddDbContext<FoodicsDbContext>();

        services.AddHttpClient("foodics", client =>
        {
            client.BaseAddress = new Uri(configuration["EndpointInfo:BaseUri"]);
            client.DefaultRequestHeaders.Authorization = new("Bearer", configuration["EndpointInfo:AuthBearer"]);
        });

    })
    .Build();


host.Run();
