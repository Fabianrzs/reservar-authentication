using Domain.Entities.Security;
using Domain.Ports.Repository;
using System.Data;

namespace Infrastructura.Adapters.Repository;

public class AuthRepository(IDbConnection dbConnection, IDbTransaction dbTransaction)
    : GenericRepository<User>(dbConnection, dbTransaction), IAuthRepository
{

        /*Expression<Func<User, bool>> filter = (u => u.Password == password && u.UserName == email);
        return await this.GetFilter(filter);*/

    public async Task<User> ValidateUserCredentials(string email, string password) {
        return await GetByFilterAsync(new User { Password = password, UserName = email });
    }
    public async Task<User> ChangeEmail(Guid id, string email)
    {
        throw new NotImplementedException();
    }

    public async Task<User> ChangePassword(Guid id, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateUserCredentials(User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeteleUserCredentials(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserCredentials(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> ValidatePassword(Guid id, string password)
    {
        throw new NotImplementedException();
    }
}
