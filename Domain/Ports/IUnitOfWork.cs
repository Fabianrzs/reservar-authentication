using Domain.Ports.Repository;

namespace Domain.Ports;

public interface IUnitOfWork : IDisposable
{
    IAuthRepository AuthRepository { get; }
    ISessionRepository SessionRepository { get; }
    Task<int> SaveChangesAsync();
    void Dispose();
}
