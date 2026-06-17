using System;
using BJB.Dashboard.Repository.Repositories.Base;

namespace BJB.Dashboard.Service.Services.Base;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _repository;
    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }
    
    public Task Create(T entity)
    {
        return _repository.Create(entity);
    }

    public Task CreateBulk(IEnumerable<T> entities)
    {
        return _repository.CreateBulk(entities);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<T?> GetById(Guid id)
    {
        return _repository.GetById(id);
    }
    
    public Task Update(T entity)
    {
        return _repository.Update(entity);
    }

    public Task Delete(T entity)
    {
        return _repository.Delete(entity);
    }

    public Task DeleteById(Guid id)
    {
        return _repository.DeleteById(id);
    }
}
