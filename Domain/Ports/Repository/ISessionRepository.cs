using Domain.Entities.Security;

namespace Domain.Ports.Repository;

public interface ISessionRepository: IGenericRepository<Session>
{
    public Task<Session> CreateUserSession(Session session);
    public Task CloseUserSession(Guid id);

}
