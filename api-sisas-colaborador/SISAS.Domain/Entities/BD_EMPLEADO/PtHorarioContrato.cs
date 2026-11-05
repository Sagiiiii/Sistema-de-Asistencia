using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_horario_contrato")]
[Index("AsignaturaSecionContratoId", Name = "asignatura_secion_contrato_id")]
[Index("ContratoId", Name = "contrato_id")]
[Index("HorarioId", Name = "horario_id")]
[Index("SedeId", Name = "sede_id")]
public partial class PtHorarioContrato
{
    [Key]
    [Column("id_horario_contrato", TypeName = "int(11)")]
    public int IdHorarioContrato { get; set; }

    [Column("contrato_id", TypeName = "int(11)")]
    public int? ContratoId { get; set; }

    [Column("horario_id", TypeName = "int(11)")]
    public int? HorarioId { get; set; }

    [Column("sede_id", TypeName = "int(11)")]
    public int? SedeId { get; set; }

    [Column("asignatura_secion_contrato_id", TypeName = "int(11)")]
    public int? AsignaturaSecionContratoId { get; set; }

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
    /// DÍAS DE LA SEMANA (LUNES = 1, ..., DOMINGO = 7)
    /// </summary>
    [Column("dias")]
    public string? Dias { get; set; }

    /// <summary>
    /// PENDIENTE = 1, ORDINARIO = 2, EXTRAORDINARIO = 3
    /// </summary>
    [Column("tipo", TypeName = "int(11)")]
    public int? Tipo { get; set; }

    /// <summary>
    /// PENDIENTE = 1, PLANILLA = 2, HONORARIOS = 3
    /// </summary>
    [Column("tipo_contrato", TypeName = "int(11)")]
    public int? TipoContrato { get; set; }

    [Column("fecha_inicio")]
    public DateOnly? FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateOnly? FechaFin { get; set; }

    [Column("hora_inicio", TypeName = "time")]
    public TimeOnly? HoraInicio { get; set; }

    [Column("hora_fin", TypeName = "time")]
    public TimeOnly? HoraFin { get; set; }

    /// <summary>
    /// MAÑANA = 1, TARDE = 2, NOCHE = 3
    /// </summary>
    [Column("turno")]
    public string? Turno { get; set; }

    /// <summary>
    /// 1, 2, 3, ETC 
    /// </summary>
    [Column("prioridad", TypeName = "int(11)")]
    public int Prioridad { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ContratoId")]
    [InverseProperty("PtHorarioContratos")]
    public virtual PtContrato? Contrato { get; set; }

    [ForeignKey("HorarioId")]
    [InverseProperty("PtHorarioContratos")]
    public virtual PtHorario? Horario { get; set; }

    [InverseProperty("HorarioContrato")]
    public virtual ICollection<PtAsistenciaContrato> PtAsistenciaContratos { get; set; } = new List<PtAsistenciaContrato>();
}
