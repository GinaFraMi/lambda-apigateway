using LambdaApiGateway.Domain.Entities;

namespace LambdaApiGateway.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<User?> GetAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
    Task CreateAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
}