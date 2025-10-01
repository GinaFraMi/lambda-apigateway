using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LambdaApiGateway.Infrastructure.Options;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using LambdaApiGateway.Infrastructure.Interfaces;
using LambdaApiGateway.Infrastructure.Repositories;

namespace LambdaApiGateway.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DynamoDBOptions>(configuration.GetSection("DynamoDB"));
        var opts = configuration.GetSection("DynamoDB").Get<DynamoDBOptions>() ?? new DynamoDBOptions();

        services.AddSingleton<IAmazonDynamoDB>(_ =>
        {
            if (opts.UseLocal && !string.IsNullOrEmpty(opts.URLService))
            {
                return new AmazonDynamoDBClient(new AmazonDynamoDBConfig
                {
                    ServiceURL = opts.URLService,
                });
            }
            return new AmazonDynamoDBClient();
        });

        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
        services.AddScoped<IUserRepository, DynamoDBRepository>();

        return services;
    }
        
}