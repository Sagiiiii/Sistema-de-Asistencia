using Microsoft.EntityFrameworkCore;

using SISAS.Domain.Entities.BD_EMPLEADO;

using SISAS.Infraestructure.Commons.Bases.Request;
using SISAS.Infraestructure.Helpers;
using SISAS.Infraestructure.Persistences.Interfaces;
using SISAS.Utilities.Static;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace SISAS.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T, TContext> : IGenericRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<T> _entity;

        protected virtual IReadOnlyDictionary<string, string> SortableColumns { get; } =
            new Dictionary<string, string>
            {
                ["id"] = "Id",
            };

        public GenericRepository(TContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }



        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity
                .Where(x => x.Estado == (int)StateTypes.Active)
                .AsNoTracking()
                .ToListAsync();

            return getAll;
        }

       

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return getById!;
        }

       

        public async Task<bool> RegisterAsync(T entity)
        {
            entity.Estado = (int)StateTypes.Active;

            await _context.Set<T>().AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

    

        public async Task<bool> EditAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;

            _context.Update(entity);

            _context.Entry(entity)
                .Property(x => x.CreatedAt)
                .IsModified = false;

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

       

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await _entity
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (entity == null)
                return false;

            entity.Estado = (int)StateTypes.Inactive;

            _context.Update(entity);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

       

        public IQueryable<T> GetEntityQuery(
            Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

      

        public IQueryable<TDTO> Ordering<TDTO>(
            BasePaginationRequest request,
            IQueryable<TDTO> queryable,
            bool pagination = false)
            where TDTO : class
        {
            var sort = request.Sort ?? string.Empty;
            if (!SortableColumns.TryGetValue(sort, out var column))
            {
                column = "Id";
            }

            var direction = string.Equals(request.Order, "desc", StringComparison.OrdinalIgnoreCase)
                ? "descending"
                : "ascending";

            IQueryable<TDTO> queryDto = queryable.OrderBy($"{column} {direction}");

            if (pagination)
            {
                queryDto = queryDto.Paginate(request);
            }

            return queryDto;
        }
    }
}