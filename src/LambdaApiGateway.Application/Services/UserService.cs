using LambdaApiGateway.Application.Interfaces;
using LambdaApiGateway.Domain.Entities;
using LambdaApiGateway.Infrastructure.Interfaces;

namespace LambdaApiGateway.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> CreateAsyn(string name, string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email is required");
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name is required");
        var user = User.CreateUser(email, name);
        await _userRepository.CreateAsync(user, cancellationToken);
        return user;
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is required");
        await _userRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is required");
        return await _userRepository.GetAsync(id, cancellationToken);
    }

    public async Task<User> UpdateAsync(string id, string email, string name, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email is required");
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name is required");
        var user = await _userRepository.GetAsync(id, cancellationToken) ?? throw new Exception("User not found");

        user.Update(email, name);

        await _userRepository.UpdateAsync(user, cancellationToken);

        return user;
    }
}