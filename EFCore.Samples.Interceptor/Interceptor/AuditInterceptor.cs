using EFCore.Samples.Interceptor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCore.Samples.Interceptor.Interceptor;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        BeforeSaveTriggers(eventData.Context);
        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        BeforeSaveTriggers(eventData.Context);
        return ValueTask.FromResult(result);
    }

    private static void BeforeSaveTriggers(DbContext? context)
    {
        var entries = context?.ChangeTracker
            .Entries()
            .Where(e => e is { Entity: IEntity, State: EntityState.Added or EntityState.Modified }).ToList();

        if (entries == null || entries.Count == 0) return;

        foreach (var entityEntry in entries)
        {
            ((IEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
            if (entityEntry.State == EntityState.Added)
            {
                ((IEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
            }
        }
    }
}