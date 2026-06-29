using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BJB.Dashboard.Context.UnitOfWork;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BJB.Dashboard.Repository.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    static string? GetActualAsyncMethodName([CallerMemberName] string? name = null) => name;
    private readonly EfDbContext _dbContext;
    private readonly DbSet<T> _entitySet;
    private readonly ILogger<T> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public BaseRepository(EfDbContext dbContext, ILogger<T> logger, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _entitySet = dbContext.Set<T>();
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task Create(T entity)
    {
        try
        {
            await _entitySet.AddAsync(entity, CancellationToken.None);
            await _dbContext.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
        }
    }

    public async Task CreateBulk(IEnumerable<T> entities)
    {
        try
        {
            await _entitySet.AddRangeAsync(entities, CancellationToken.None);
            await _dbContext.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await _entitySet.AsNoTracking().ToListAsync(CancellationToken.None);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
            throw;
        }
    }

    public async Task<T?> GetById(object id)
    {
        try
        {
            return await _entitySet.FindAsync(new object[] { id }, CancellationToken.None);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
            throw;
        }
    }

    public async Task Update(T entity)
    {
        try
        {
            _entitySet.Update(entity);
            await _dbContext.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
            throw;
        }
    }

    public async Task Delete(T entity)
    {
        try
        {
            _entitySet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
            throw;
        }
    }

    public async Task DeleteById(object id)
    {
        try
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                await Delete(entity);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
        }
    }

    public async Task<IEnumerable<T>> ExecuteSqlReturnList(System.FormattableString sql)
    {
        IEnumerable<T> listData = new List<T>();

        try
        {
            listData = await _dbContext.Set<T>().FromSqlInterpolated(sql).ToListAsync();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ClassName}-{Method}", GetType().Name, GetActualAsyncMethodName());
        }

        return listData;
    }
}
