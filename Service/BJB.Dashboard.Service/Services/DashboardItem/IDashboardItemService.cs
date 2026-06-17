using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Service.Services.Base;

namespace BJB.Dashboard.Service.Services.DashboardItem;

public interface IDashboardItemService : IBaseService<DashboardItemEntity>
{
    Task<IEnumerable<DashboardItemEntity>> RetrieveByStatus(string status);
}
