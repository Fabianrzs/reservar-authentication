using Domain.Entities.Security;
using Domain.Ports.Repository;
using Infrastructura.Adapters;
using System.Data;

namespace Infrastrunture.Adapters.Repository;

public class RoleRepository(IDbConnection dbConnection, IDbTransaction dbTransaction) 
    : GenericRepository<Role>(dbConnection, dbTransaction), IRoleRepository
{
    public async Task<Role> GetRoleById(Guid id)
    {
        return await GetByIdAsync(id);
    }
}
