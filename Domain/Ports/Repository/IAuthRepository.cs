using Domain.Entities.Security;

namespace Domain.Ports.Repository;

public interface IAuthRepository: IGenericRepository<User>
{
    public Task<User> ValidateUserCredentials(string userName, string password);
    public Task<User> ValidatePassword(Guid id, string password);
    public Task<User> ChangePassword(Guid id, string currentPassword, string newPassword);
    public Task<User> RecorveryPassword(Guid id, string password);
    public Task<User> ChangeUserName(Guid id, string userName);
    public Task<User> CreateUserCredentials(User user);
    public Task<User> GetUserCredentials(Guid id);
    public Task DeteleUserCredentials(Guid id);
}
