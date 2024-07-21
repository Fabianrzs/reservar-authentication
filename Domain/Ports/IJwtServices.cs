using Domain.Entities.Security;

namespace Domain.Ports;
public interface IJwtServices
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}
