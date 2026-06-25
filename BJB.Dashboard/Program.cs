using BJB.Dashboard.Context.Context;
using BJB.Dashboard.Context.ContextProvider;
using BJB.Dashboard.Context.Provider;
using BJB.Dashboard.Context.UnitOfWork;
using BJB.Dashboard.Library.Configuration;
using BJB.Dashboard.Repository.Repositories.Base;
using BJB.Dashboard.Repository.Repositories.DashboardItem;
using BJB.Dashboard.Repository.Repositories.Payment;
using BJB.Dashboard.Repository.Repositories.PaymentAndHistory;
using BJB.Dashboard.Repository.Repositories.PaymentMonitoring;
using BJB.Dashboard.Repository.Repositories.PaymentSaga;
using BJB.Dashboard.Service.Services.Base;
using BJB.Dashboard.Service.Services.DashboardItem;
using BJB.Dashboard.Service.Services.Payment;
using BJB.Dashboard.Service.Services.PaymentAndHistory;
using BJB.Dashboard.Service.Services.PaymentMonitoring;
using BJB.Dashboard.Service.Services.PaymentSaga;
using Microsoft.EntityFrameworkCore;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

var builder = WebApplication.CreateBuilder(args);

#region Configuration
var configuration = builder.Configuration;

ConfigurationBuilders.BuildConfiguration(configuration);
#endregion

#region DBEngine
var dbEngine = ConfigurationDictionary.GetConfig("ApplicationDatabaseEngine")?.ToLowerInvariant()
    ?? throw new InvalidOperationException("ApplicationDatabaseEngine is not configured.");

switch (dbEngine)
{
    case "mssql":
        var sqlServerConnection = ConfigurationDictionary.GetConfig("SqlServerDbContext")
            ?? throw new InvalidOperationException("SqlServerDbContext is not configured.");

        builder.Services.AddDbContext<SqlServerDbContext>(x => x.UseSqlServer(sqlServerConnection));
        builder.Services.AddScoped<EfDbContext>(provider => provider.GetRequiredService<SqlServerDbContext>());
        builder.Services.AddScoped<IContextProvider, SqlServerContextProvider>();
        break;
    // case "mysql":
    //     builder.Services.AddScoped<IContextProvider, MySqlContextProvider>();
    //     break;
    // case "postgre":
    //     builder.Services.AddScoped<IContextProvider, PostgreSqlContextProvider>();
    //     break;
    // case "oracle":
    //     builder.Services.AddScoped<IContextProvider, OracleContextProvider>();
    // break;
    default:
        throw new Exception("Invalid DB Engine specified in configuration.");
}
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IDashboardItemRepository, DashboardItemRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentSagaRepository, PaymentSagaRepository>();
builder.Services.AddScoped<IPaymentMonitoringRepository, PaymentMonitoringRepository>();
builder.Services.AddScoped<IPaymentAndHistoryRepository, PaymentAndHistoryRepository>();

builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddTransient<IDashboardItemService, DashboardItemService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IPaymentSagaService, PaymentSagaService>();
builder.Services.AddTransient<IPaymentMonitoringService, PaymentMonitoringService>();
builder.Services.AddTransient<IPaymentAndHistoryService, PaymentAndHistoryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
