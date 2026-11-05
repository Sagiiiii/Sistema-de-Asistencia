using SISAS.Domain.Entities.BD_EMPLEADO;
using SISAS.Infraestructure.Commons.Bases.Request;
using SISAS.Infraestructure.Commons.Bases.Response;
using SISAS.Infraestructure.Helpers;
using SISAS.Infraestructure.Persistences.Contexts;
using SISAS.Infraestructure.Persistences.Interfaces;
using SISAS.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SISAS.Infraestructure.Persistences.Repositories
{
    public class HorarioRepository : GenericRepository<PtHorario, EmpleadoDbContext>, IHorarioRepository
    {
        public HorarioRepository(EmpleadoDbContext context) : base(context) { }

        protected override IReadOnlyDictionary<string, string> SortableColumns { get; } =
            new Dictionary<string, string>
            {
                ["idHorario"] = "Id",
                ["nombre"] = "Nombre",
                ["descripcion"] = "Descripcion",
                ["estado"] = "Estado",
            };

        public async Task<BaseEntityResponse<PtHorario>> ListHorarios(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<PtHorario>();
            var horario = GetEntityQuery().ApplyFilters(filters,
                new Dictionary<int, Expression<Func<PtHorario, string?>>>
                {
                    [1] = x => x.Nombre,
                    [2] = x => x.Descripcion,
                });

            response.TotalRecords = await horario.CountAsync();

            response.Items = await Ordering(filters, horario, true).ToListAsync();

            return response;
        }
    }
}
