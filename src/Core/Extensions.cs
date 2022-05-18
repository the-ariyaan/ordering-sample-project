using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Core;

public static partial class Extensions
{
    public static IQueryable<TEntity> AddPredicate<TEntity>(this IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>>? predicate)
    {
        return predicate != null ? query.Where(predicate) : query;
    }


    public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> query,
        IEnumerable<Expression<Func<TEntity, object>>>? includes = null)
        where TEntity : class
    {
        includes?.ToList().ForEach(p => query = query.Include(p));
        return query;
    }
}