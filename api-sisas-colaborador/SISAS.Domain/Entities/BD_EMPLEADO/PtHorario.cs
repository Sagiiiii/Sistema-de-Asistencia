using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_horario")]
[Index("CategoriaHorarioId", Name = "categoria_horario_id")]
[Index("HorarioGlobalId", Name = "horario_global_id")]
public partial class PtHorario : BaseEntity
{


    [Column("horario_global_id", TypeName = "int(11)")]
    public int? HorarioGlobalId { get; set; }

    [Column("categoria_horario_id", TypeName = "int(11)")]
    public int? CategoriaHorarioId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    [Column("year", TypeName = "year(4)")]
    public short? Year { get; set; }

    /// <summary>
    /// TIEMPO COMPLETO = 1, MEDIO TIEMPO = 2
    /// </summary>
    [Column("tipo", TypeName = "int(11)")]
    public int? Tipo { get; set; }

    /// <summary>
    /// MAÑANA = 1, TARDE = 2, NOCHE = 3
    /// </summary>
    [Column("turno")]
    public string? Turno { get; set; }

    [Column("fecha_inicio")]
    public DateOnly? FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateOnly? FechaFin { get; set; }

    [Column("hora_inicio", TypeName = "time")]
    public TimeOnly? HoraInicio { get; set; }

    [Column("hora_fin", TypeName = "time")]
    public TimeOnly? HoraFin { get; set; }

    [Column("hora_apertura_ingreso", TypeName = "time")]
    public TimeOnly? HoraAperturaIngreso { get; set; }

    [Column("hora_cierre_ingreso", TypeName = "time")]
    public TimeOnly? HoraCierreIngreso { get; set; }

    [Column("tolerancia", TypeName = "time")]
    public TimeOnly? Tolerancia { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }


    [InverseProperty("Horario")]
    public virtual ICollection<PtHorarioContrato> PtHorarioContratos { get; set; } = new List<PtHorarioContrato>();
}
