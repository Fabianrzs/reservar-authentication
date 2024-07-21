﻿using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;
using Domain.Services;
using Domain.Ports;
using Domain.Utils;

namespace Application.UseCase.Security.Authentication.Commands;

public class AuthenticationHandler(IMapper _mapper, AuthService _authService, IJwtServices _jwtServices) 
    : IRequestHandler<AuthenticationCommand, ServiceResponse<AuthenticationDto>>
{

    public async Task<ServiceResponse<AuthenticationDto>> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        Guid sessionId = Guid.NewGuid();
        var userSession = await _authService.SingIn(CrypterDefault.Encrypt(request.UserName), CrypterDefault.Encrypt(request.Password), sessionId);


        var userResponse = _mapper.Map<AuthenticationDto>(userSession);
        userResponse.RefreshToken = _jwtServices.GenerateRefreshToken(userSession, sessionId);
        userResponse.AccessToken = _jwtServices.GenerateAccessToken(userSession, sessionId);

        /*var userResponse = new AuthenticationDto
        {
            RefreshToken = _jwtServices.GenerateRefreshToken(userSession, sessionId),
            AccessToken = _jwtServices.GenerateAccessToken(userSession, sessionId)
        };*/
        return new ServiceResponse<AuthenticationDto>(string.Empty, userResponse, true);
    }
}
