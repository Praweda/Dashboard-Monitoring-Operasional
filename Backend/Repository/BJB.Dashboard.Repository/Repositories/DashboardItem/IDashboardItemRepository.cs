using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;

namespace BJB.Dashboard.Repository.Repositories.DashboardItem;

public interface IDashboardItemRepository : IBaseRepository<DashboardItemEntity>
{
    Task<IEnumerable<DashboardItemEntity>> RetrieveByStatus(string status);
}
