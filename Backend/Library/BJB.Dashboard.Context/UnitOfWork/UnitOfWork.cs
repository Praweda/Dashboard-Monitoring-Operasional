using System;
using BJB.Dashboard.Context.ContextProvider;
using Microsoft.Extensions.Logging;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BJB.Dashboard.Context.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfDbContext _dbContext;
    private readonly ILogger<UnitOfWork> _logger;


    public UnitOfWork(IContextProvider provider, ILogger<UnitOfWork> logger)
    {
        _dbContext = provider.GetContext();
        _logger = logger;
    }

    public void Commit()
    {
        try
        {
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogDebug("UnitOfWork - Commit : {0}", ex.Message);
        }
    }

    public async Task<int> CommitAsync()
    {
        try
        {
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogDebug("UnitOfWork - CommitAsynchronouse : {0}", ex.Message);
            return 0;
        }
    }

    public void Rollback()
    {
        try
        {
            _dbContext.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogDebug("UnitOfWork - Rollback : {0}", ex.Message);
        }
    }

    public async Task RollbackAsync()
    {
        try
        {
            await _dbContext.DisposeAsync();
        }
        catch (Exception ex)
        {
            _logger.LogDebug("UnitOfWork - RollbackAsync : {0}", ex.Message);
        }
    }
}
