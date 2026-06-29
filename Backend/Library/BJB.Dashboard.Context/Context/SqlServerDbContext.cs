using System;
using BJB.Dashboard.Model.Entity;
using Microsoft.EntityFrameworkCore;
using EfDbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BJB.Dashboard.Context.Context;

public class SqlServerDbContext : EfDbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
    }

    public DbSet<DashboardItemEntity> DashboardItems => Set<DashboardItemEntity>();
    public DbSet<PaymentEntity> Payments => Set<PaymentEntity>();
    public DbSet<PaymentHistoryEntity> PaymentHistories => Set<PaymentHistoryEntity>();
    public DbSet<PaymentSagaEntity> PaymentSagas => Set<PaymentSagaEntity>();
    public DbSet<PaymentMonitoringEntity> PaymentMonitorings => Set<PaymentMonitoringEntity>();
    public DbSet<PaymentAndHistoryEntity> PaymentAndHistory => Set<PaymentAndHistoryEntity>();
    public DbSet<PaymentAndHistoryMonitoringEntity> PaymentAndHistoryMonitorings => Set<PaymentAndHistoryMonitoringEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PaymentEntity>(entity =>
        {
            entity.HasKey(payment => payment.Trn);
            entity.Property(payment => payment.Amount).HasPrecision(18, 2);
            entity.Property(payment => payment.AmountToBuy).HasPrecision(18, 2);
        });

        modelBuilder.Entity<PaymentHistoryEntity>(entity =>
        {
            entity.HasKey(payment => payment.Trn);
            entity.Property(payment => payment.Amount).HasPrecision(18, 2);
            entity.Property(payment => payment.AmountToBuy).HasPrecision(18, 2);
        });

        modelBuilder.Entity<PaymentSagaEntity>(entity =>
        {
            entity.HasKey(payment => payment.PaymentSagaId);
        });

        modelBuilder.Entity<PaymentMonitoringEntity>(entity =>
        {
            entity.HasKey(payment => new { payment.BusDate, payment.IO });
        });

        modelBuilder.Entity<PaymentAndHistoryEntity>(entity =>
        {
            entity.HasKey(payment => payment.Trn);
            entity.HasKey(payment => payment.BusDate);
        });

        modelBuilder.Entity<PaymentAndHistoryMonitoringEntity>(entity =>
        {
            entity.HasKey(payment => new { payment.BusDate, payment.IO });
            entity.Property(payment => payment.TotalAmount).HasPrecision(18, 2);
        });
    }
}
