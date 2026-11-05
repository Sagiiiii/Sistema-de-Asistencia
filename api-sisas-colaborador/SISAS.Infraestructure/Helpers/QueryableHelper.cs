using SISAS.Domain.Entities.BD_EMPLEADO;
using SISAS.Infraestructure.Commons.Bases.Request;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SISAS.Infraestructure.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }

        public static IQueryable<T> ApplyFilters<T>(
            this IQueryable<T> queryable,
            BaseFiltersRequest request,
            IReadOnlyDictionary<int, Expression<Func<T, string?>>> textColumns)
            where T : BaseEntity
        {
            if (request.StateFilter is not null)
            {
                queryable = queryable.Where(x => x.Estado.Equals(request.StateFilter));
            }

            if (request.NumFilter is not null &&
                !string.IsNullOrEmpty(request.TextFilter) &&
                textColumns.TryGetValue(request.NumFilter.Value, out var selector))
            {
                var param = selector.Parameters[0];
                var property = selector.Body;
                var contains = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!;
                var term = Expression.Constant(request.TextFilter, typeof(string));
                var notNull = Expression.NotEqual(property, Expression.Constant(null, typeof(string)));
                var call = Expression.Call(property, contains, term);
                var lambda = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(notNull, call), param);

                queryable = queryable.Where(lambda);
            }

            return queryable;
        }
    }
}
