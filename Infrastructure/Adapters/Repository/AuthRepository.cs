using Domain.Entities.Security;
using Domain.Ports.Repository;
using System.Data;

namespace Infrastructura.Adapters.Repository;

public class AuthRepository(IDbConnection dbConnection, IDbTransaction dbTransaction)
    : GenericRepository<User>(dbConnection, dbTransaction), IAuthRepository
{
    public async Task<User> ValidateUserCredentials(string userName, string password) {
        return await GetByFilterAsync(new User { Password = password, UserName = userName });
    }
    public  Task<User> ChangeUserName(Guid id, string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User> ChangePassword(Guid id, string currentPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<User> RecorveryPassword(Guid id, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUserCredentials(User user)
    {
        throw new NotImplementedException();
    }

    public  Task DeteleUserCredentials(Guid id)
    {
        throw new NotImplementedException();
    }

    public  Task<User> GetUserCredentials(Guid id)
    {
        throw new NotImplementedException();
    }

    public  Task<User> ValidatePassword(Guid id, string password)
    {
        throw new NotImplementedException();
    }
}

/*Expression<Func<User, bool>> filter = (u => u.Password == password && u.UserName == userName);
       return await this.GetFilter(filter);*/

