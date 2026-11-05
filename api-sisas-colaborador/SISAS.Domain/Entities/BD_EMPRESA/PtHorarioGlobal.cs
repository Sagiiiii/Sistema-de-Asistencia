using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

/// <summary>
/// Guarda horarios en global
/// </summary>
[Table("pt_horario_global")]
public partial class PtHorarioGlobal
{
    [Key]
    [Column("id_horario_global", TypeName = "int(11)")]
    public int IdHorarioGlobal { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

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

    [Column("anticipacion", TypeName = "time")]
    public TimeOnly? Anticipacion { get; set; }

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

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("HorarioGlobal")]
    public virtual ICollection<PtHorario> PtHorarios { get; set; } = new List<PtHorario>();
}
