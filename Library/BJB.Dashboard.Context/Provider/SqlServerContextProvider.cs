using System;
using BJB.Dashboard.Context.Context;
using BJB.Dashboard.Context.ContextProvider;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BJB.Dashboard.Context.Provider;

public class SqlServerContextProvider : IContextProvider
{
    private EfDbContext _dbContext;
    public SqlServerContextProvider(SqlServerDbContext sqlServerDbContext)
    {
        _dbContext = sqlServerDbContext;
    }

    public EfDbContext Initiate()
    {
        throw new NotImplementedException();
    }

    public EfDbContext GetContext()
    {
        return _dbContext;
    }
}
