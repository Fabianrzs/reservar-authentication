using Domain.Entities.Security;

namespace Domain.Ports.Repository;

public interface IRoleRepository: IGenericRepository<Role>
{
    public Task<Role> GetRoleById(Guid id);
}
