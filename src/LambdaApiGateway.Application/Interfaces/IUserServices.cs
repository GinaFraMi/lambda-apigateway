using LambdaApiGateway.Domain.Entities; 

namespace LambdaApiGateway.Application.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User> CreateAsyn( string name, string email, CancellationToken cancellationToken);
    Task<User> UpdateAsync(string id, string name, string email, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
}