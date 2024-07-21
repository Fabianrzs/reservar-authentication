using Notes.Domain.Services.Base;
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.Ports;

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

            user.Role = await _unitOfWork.RoleRepository.GetRoleById(user.RoleId) ?? throw new NoContentException("Role No Defined"); ;

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
