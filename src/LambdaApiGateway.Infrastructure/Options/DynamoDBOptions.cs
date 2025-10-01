namespace LambdaApiGateway.Infrastructure.Options;

public class DynamoDBOptions
{
    public bool UseLocal { get; set; } = false;
    public string? URLService { get; set; }
}