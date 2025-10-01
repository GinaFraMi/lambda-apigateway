using Amazon.DynamoDBv2.DataModel;

namespace LambdaApiGateway.Infrastructure.Models;

[DynamoDBTable("Users")]
public class UserItem
{
    [DynamoDBHashKey]
    public string Id { get; set; } = string.Empty;
    [DynamoDBProperty]
    public string Email { get; set; } = string.Empty;
    [DynamoDBProperty]
    public string Name { get; set; } = string.Empty;
    [DynamoDBProperty]
    public DateTime CreatedAt { get; set; }
    [DynamoDBProperty]
    public DateTime? UpdatedAt { get; set; }
    
}