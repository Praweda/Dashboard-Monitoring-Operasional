using System;

namespace BJB.Dashboard.Repository.Repositories.Base;

public interface IBaseRepository<T> where T : class
{
    Task Create(T entity);
    Task CreateBulk(IEnumerable<T> entities);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(object id);
    Task Update(T entity);
    Task Delete(T entity);
    Task DeleteById(object id);
    Task<IEnumerable<T>> ExecuteSqlReturnList(System.FormattableString sql);
}
