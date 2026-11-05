using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Dtos.Response
{
    public class AreaResponseDto
    {
        public int IdArea { get; set; }
        public int? EmpresaId { get; set; }
        public int? AreaId { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int? Estado { get; set; }

        public string? StateCategory { get; set; }
        public string? Descripcion { get; set; }

    }
}
