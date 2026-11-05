using Microsoft.EntityFrameworkCore;
using SISAS.Domain.Entities.BD_EMPLEADO;
using SISAS.Infraestructure.Commons.Bases.Request;
using SISAS.Infraestructure.Commons.Bases.Response;
using SISAS.Infraestructure.Helpers;
using SISAS.Infraestructure.Persistences.Contexts;
using SISAS.Infraestructure.Persistences.Interfaces;
using SISAS.Infrastructure.Persistence.Repositories;
using System.Linq.Expressions;

namespace SISAS.Infraestructure.Persistences.Repositories
{
    public class AreaRepository : GenericRepository<PtArea, EmpleadoDbContext>, IAreaRepository
    {

        public AreaRepository(EmpleadoDbContext context) : base(context) { }

        protected override IReadOnlyDictionary<string, string> SortableColumns { get; } =
            new Dictionary<string, string>
            {
                ["idArea"] = "Id",
                ["nombre"] = "Nombre",
                ["descripcion"] = "Descripcion",
                ["estado"] = "Estado",
            };

        public async Task<BaseEntityResponse<PtArea>> ListAreas(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<PtArea>();
            var area = GetEntityQuery().ApplyFilters(filters,
                new Dictionary<int, Expression<Func<PtArea, string?>>>
                {
                    [1] = x => x.Nombre,
                    [2] = x => x.Descripcion,
                });

            response.TotalRecords = await area.CountAsync();

            response.Items = await Ordering(filters, area, true).ToListAsync();

            return response;
        }

    }
}
