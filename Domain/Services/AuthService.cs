using Notes.Domain.Services.Base;
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;
[DomainService]
public class AuthService(IUnitOfWork _unitOfWork)
{
    public async Task<User> SingIn(string userName, string password, Guid sessionId)
    {
		try
		{
			var user = await _unitOfWork.AuthRepository.ValidateUserCredentials(userName, password) 
                ?? throw new FailCredentialsException("UserName or Password incorrect");
            var role = await _unitOfWork.RoleRepository.GetRoleById(user.RoleId) 
                ?? throw new NoContentException("Role No Defined");
            user.Role = role;

            var session = new Session
            {
                Active = true,  UserId = user.Id,
                StartTime = DateTime.UtcNow, Id = sessionId,
            };
            
            await _unitOfWork.SessionRepository.CreateUserSession(session);

            _unitOfWork.SaveChanges();
			return user;
        }
		catch(Exception e)
		{
			_unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }
}
