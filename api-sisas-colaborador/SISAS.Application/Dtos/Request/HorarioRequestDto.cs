using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Dtos.Request
{
    public class HorarioRequestDto
    {
        public string? Nombre { get; set; }
        public int? Estado { get; set; }
        public int? Tipo { get; set; }
        public string? Turno { get; set; }
        public DateOnly? FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        public TimeOnly? HoraAperturaIngreso { get; set; }
        public TimeOnly? HoraCierreIngreso { get; set; }
        public TimeOnly? Tolerancia { get; set; }

        public string? Descripcion { get; set; }
    }
}
