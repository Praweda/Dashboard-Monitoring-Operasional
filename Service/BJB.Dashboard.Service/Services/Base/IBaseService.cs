using System;

namespace BJB.Dashboard.Service.Services.Base;

public interface IBaseService<T> where T : class
{
    Task Create(T entity);
    Task CreateBulk(IEnumerable<T> entities);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task Update(T entity);
    Task Delete(T entity);
    Task DeleteById(Guid id);
}
