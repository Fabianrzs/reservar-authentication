﻿using Domain.Ports.Repository;

namespace Domain.Ports;

public interface IUnitOfWork
{
    IAuthRepository AuthRepository { get; }
    ISessionRepository SessionRepository { get; }
    IRoleRepository RoleRepository { get; }
    Task<int> SaveChangesAsync();
    void Dispose();
}
