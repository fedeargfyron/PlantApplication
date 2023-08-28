using Domain.Entities;

namespace Infrastructure.Extensions;

public static class IntEnumerableExtensions
{
    public static List<T> GetNewEntities<T>(this IEnumerable<int> maintainedEntitiesIds,
    IEnumerable<int> newEntitiesIds, Func<int, T> entityFactory)
    where T : BaseEntity
    {
        return newEntitiesIds.Except(maintainedEntitiesIds)
            .Select(entityFactory)
            .ToList();
    }
}
