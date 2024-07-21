using Domain.Entities.Security;

namespace Domain.Ports;
public interface IJwtServices
{
    Task<string> GenerateAccessToken(User user);
    Task<string> GenerateRefreshToken(User user);
}
