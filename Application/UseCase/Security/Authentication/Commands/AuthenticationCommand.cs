using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;
using Domain.Services;
using Domain.Ports;

namespace Application.UseCase.Security.Authentication.Commands;

public class AuthenticationHandler(IMapper _mapper, AuthService _authService, IJwtServices _jwtServices) 
    : IRequestHandler<AuthenticationCommand, ServiceResponse<AuthenticationDto>>
{

    public async Task<ServiceResponse<AuthenticationDto>> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        var userSession = await _authService.SingIn(request.UserName, request.Password);
        var userResponse = _mapper.Map<AuthenticationDto>(userSession);
        userResponse.RefreshToken = _jwtServices.GenerateRefreshToken(userSession);
        userResponse.AccessToken = _jwtServices.GenerateAccessToken(userSession);
        return new ServiceResponse<AuthenticationDto>(string.Empty, userResponse, true);
    }
}
