namespace LambdaApiGateway.Domain.Entities;

public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public static User CreateUser(string Email, string Name) => new User
    {
        Id = Guid.NewGuid().ToString(),
        Email = Email,
        Name = Name,
        CreatedAt = DateTime.Now,
        UpdatedAt = null
    };

    public void Update(string email, string name)
    {
        Email = email;
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
}