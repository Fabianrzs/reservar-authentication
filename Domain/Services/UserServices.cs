
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.Ports;
using Notes.Domain.Services.Base;

namespace Domain.Services;
[DomainService]
public class AuthService(IUnitOfWork _unitOfWork)
{
    public async Task<User> SingIn(string userName, string password)
    {
		try
		{
			var user = await _unitOfWork.AuthRepository.ValidateUserCredentials(userName, password) 
                ?? throw new FailCredentialsException("UserName or Password incorrect");

            await _unitOfWork.SessionRepository.CreateUserSession(
                new Session { Active = true, UserId = user.Id, 
                    StartTime = DateTime.UtcNow, Id = new Guid()});

            await _unitOfWork.SaveChangesAsync();
			return user;
        }
		catch
		{
			_unitOfWork.Dispose();
            throw;
        }
    }
}
