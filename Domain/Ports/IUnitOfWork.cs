using Domain.Ports.Repository;

namespace Domain.Ports;

public interface IUnitOfWork
{
    IAuthRepository AuthRepository { get; }
    ISessionRepository SessionRepository { get; }
    IRoleRepository RoleRepository { get; }
    void SaveChanges();
    void Dispose();
}
