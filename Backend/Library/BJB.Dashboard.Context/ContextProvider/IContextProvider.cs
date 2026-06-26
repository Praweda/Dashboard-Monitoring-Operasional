using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BJB.Dashboard.Context.ContextProvider;

public interface IContextProvider
{
    EfDbContext Initiate();
    EfDbContext GetContext();
}
