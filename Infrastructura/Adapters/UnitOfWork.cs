﻿using Domain.Ports;
using Domain.Ports.Repository;
using System.Data;

namespace Infrastructura.Adapters;

public class UnitOfWork: IUnitOfWork
{
    private readonly IDbConnection _dbConnection;
    private IDbTransaction _dbTransaction;
    public IAuthRepository AuthRepository { get; }
    public ISessionRepository SessionRepository { get; }

    public UnitOfWork(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _dbConnection.Open();
        _dbTransaction = _dbConnection.BeginTransaction();
        //ProductRepository = new ProductRepository(_dbConnection, _dbTransaction);
    }

    //public IProductRepository ProductRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            _dbTransaction.Commit();
            return await Task.FromResult(1);
        }
        catch
        {
            _dbTransaction.Rollback();
            throw;
        }
        finally
        {
            _dbTransaction.Dispose();
            _dbTransaction = _dbConnection.BeginTransaction();
        }
    }

    public void Dispose()
    {
        _dbTransaction?.Dispose();
        _dbConnection?.Dispose();
        GC.SuppressFinalize(this);
    }
}
