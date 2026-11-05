using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Dtos.Response
{
    public class HorarioResponseDto
    {
        public int IdHorario { get; set; }
        public int? CategoriaHorarioId { get; set; }
        public string? Nombre { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public string? HoraAperturaIngreso { get; set; }
        public string? HoraCierreIngreso { get; set; }
        public string? Tolerancia { get; set; }

        public int? Estado { get; set; }
        public string? StateHorario { get; set; }
        public string? Descripcion { get; set; }
    }
}
