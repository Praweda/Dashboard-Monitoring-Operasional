using System.Runtime.CompilerServices;
using BJB.Dashboard.Context.UnitOfWork;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Repository.Repositories.Base;
using Microsoft.Extensions.Logging;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BJB.Dashboard.Repository.Repositories.DashboardItem;

public class DashboardItemRepository : BaseRepository<DashboardItemEntity>, IDashboardItemRepository
{
    static string? GetActualAsyncMethodName([CallerMemberName] string? name = null) => name;

    private readonly EfDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DashboardItemEntity> _logger;

    public DashboardItemRepository(
        EfDbContext dbContext,
        IUnitOfWork unitOfWork,
        ILogger<DashboardItemEntity> logger) : base(dbContext, logger, unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }


    public async Task<IEnumerable<DashboardItemEntity>> RetrieveByStatus(string status)
    {
        var items = await GetAll();
        return items.Where(item => string.Equals(item.Status, status, StringComparison.OrdinalIgnoreCase));
    }
}
