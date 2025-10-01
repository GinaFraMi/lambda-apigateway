using Amazon.DynamoDBv2.DataModel;
using LambdaApiGateway.Domain.Entities;
using LambdaApiGateway.Infrastructure.Interfaces;
using LambdaApiGateway.Infrastructure.Models;

namespace LambdaApiGateway.Infrastructure.Repositories;

public class DynamoDBRepository : IUserRepository
{

    private readonly IDynamoDBContext _context;

    public DynamoDBRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        var item = ToItem(user);
        await _context.SaveAsync(item, cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        await _context.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        var search = _context.ScanAsync<UserItem>(new List<ScanCondition>());
        var items = await search.GetRemainingAsync(cancellationToken);
        return [.. items.Select(ToDomain)];
        
    }

    public async Task<User?> GetAsync(string id, CancellationToken cancellationToken)
    {
        var item = await _context.LoadAsync<UserItem>(id, cancellationToken);
        return item is null ? null : ToDomain(item);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        await _context.SaveAsync(ToItem(user), cancellationToken);
    }

    private static UserItem ToItem(User user)
    {
        return new UserItem
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    private static User ToDomain(UserItem item)
    {
        return new User
        {
            Id = item.Id,
            Email = item.Email,
            Name = item.Name,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt
        };

    }
}