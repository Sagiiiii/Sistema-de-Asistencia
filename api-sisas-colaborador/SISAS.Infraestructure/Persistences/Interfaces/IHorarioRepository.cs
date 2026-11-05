using SISAS.Domain.Entities.BD_EMPLEADO;
using SISAS.Infraestructure.Commons.Bases.Request;
using SISAS.Infraestructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Persistences.Interfaces
{
    public interface IHorarioRepository : IGenericRepository<PtHorario>
    {
        Task<BaseEntityResponse<PtHorario>> ListHorarios(BaseFiltersRequest filters);
    }
}
