using System.Runtime.CompilerServices;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.DashboardItem;
using BJB.Dashboard.Service.Services.Base;
using Microsoft.Extensions.Logging;

namespace BJB.Dashboard.Service.Services.DashboardItem;

public class DashboardItemService : BaseService<DashboardItemEntity>, IDashboardItemService
{
    static string? GetActualAsyncMethodName([CallerMemberName] string? name = null) => name;

    private readonly IDashboardItemRepository _repository;
    private readonly ILogger<DashboardItemService> _logger;

    public DashboardItemService(IDashboardItemRepository repository, ILogger<DashboardItemService> logger) : base(repository)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task<IEnumerable<DashboardItemEntity>> RetrieveByStatus(string status)
    {
        return _repository.RetrieveByStatus(status);
    }
}
