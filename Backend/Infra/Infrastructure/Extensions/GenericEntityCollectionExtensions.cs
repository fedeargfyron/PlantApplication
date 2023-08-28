using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class GenericEntityCollectionExtensions
{
    public static void SetNewEntities<T>(this ICollection<T> collection,
        IEnumerable<int> actualIds, Context context, Func<int, T> entityFactory)
        where T : BaseEntity
    {
        var maintainedEntitiesIds = collection.Select(x => x.Id)
            .Intersect(actualIds);

        var newEntities = actualIds.Except(maintainedEntitiesIds)
            .Select(entityFactory)
            .ToList();

        collection.AddNewEntities(newEntities, context);
        collection.RemoveUnmaintainedEntities(maintainedEntitiesIds);
    }

    private static void AddNewEntities<T>(this ICollection<T> collection, List<T> newEntities, Context context)
        where T : BaseEntity
    {
        newEntities.ForEach(collection.Add);
        context.Set<T>().AttachRange(newEntities);
    }

    private static void RemoveUnmaintainedEntities<T>(this ICollection<T> entities, IEnumerable<int> mantainedEntitiesIds)
        where T : BaseEntity
    {
        entities.Where(x => !mantainedEntitiesIds.Contains(x.Id))
            .ToList()
            .ForEach(x => entities.Remove(x));
    }
}
