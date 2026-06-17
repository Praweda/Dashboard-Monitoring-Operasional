using System;

namespace BJB.Dashboard.Context.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    Task<int> CommitAsync();
    Task RollbackAsync();
}
