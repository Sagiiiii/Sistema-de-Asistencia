using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_contrato")]
[Index("EmpleadoId", Name = "empleado_id")]
[Index("EmpleadoIdContratante", Name = "empleado_id_contratante")]
[Index("EscalaId", Name = "escala_id")]
public partial class PtContrato
{
    [Key]
    [Column("id_contrato", TypeName = "int(11)")]
    public int IdContrato { get; set; }

    [Column("empleado_id", TypeName = "int(11)")]
    public int? EmpleadoId { get; set; }

    [Column("escala_id", TypeName = "int(11)")]
    public int? EscalaId { get; set; }

    [Column("empleado_id_contratante", TypeName = "int(11)")]
    public int? EmpleadoIdContratante { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("year", TypeName = "year(4)")]
    public short? Year { get; set; }

    [Column("fecha_inicio")]
    public DateOnly? FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateOnly? FechaFin { get; set; }

    /// <summary>
    /// PENDIENTE = 1, PLANILLA = 2, HONORARIOS = 3
    /// </summary>
    [Column("tipo_contrato", TypeName = "int(11)")]
    public int? TipoContrato { get; set; }

    /// <summary>
    /// PENDIENTE = 1, TIEMPO COMPLETO = 2, MEDIO TIEMPO = 3
    /// </summary>
    [Column("tipo_horario", TypeName = "int(11)")]
    public int? TipoHorario { get; set; }

    /// <summary>
    /// PENDIENTE = 1, DOCENTE = 2, ADMINISTRATIVO = 3
    /// </summary>
    [Column("tipo_empleado", TypeName = "int(11)")]
    public int? TipoEmpleado { get; set; }

    /// <summary>
    /// PENDIENTE = 1, MAÑANA = 2, TARDE = 3
    /// </summary>
    [Column("turno_horario", TypeName = "int(11)")]
    public int? TurnoHorario { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    /// <summary>
    /// Nivel principal que dicta el docente
    /// </summary>
    [Column("nivel")]
    [StringLength(50)]
    public string? Nivel { get; set; }

    /// <summary>
    /// Asignatura principal que dicta el docente
    /// </summary>
    [Column("asignatura")]
    [StringLength(100)]
    public string? Asignatura { get; set; }

    [Column("modalidad_contrato")]
    [StringLength(50)]
    public string? ModalidadContrato { get; set; }

    [Column("fecha_contratacion", TypeName = "int(11)")]
    public int? FechaContratacion { get; set; }

    [Column("detalles")]
    public string? Detalles { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("EmpleadoId")]
    [InverseProperty("PtContratoEmpleados")]
    public virtual PtEmpleado? Empleado { get; set; }

    [ForeignKey("EmpleadoIdContratante")]
    [InverseProperty("PtContratoEmpleadoIdContratanteNavigations")]
    public virtual PtEmpleado? EmpleadoIdContratanteNavigation { get; set; }

    [ForeignKey("EscalaId")]
    [InverseProperty("PtContratos")]
    public virtual PtEscala? Escala { get; set; }

    [InverseProperty("Contrato")]
    public virtual ICollection<PtAsistenciaContrato> PtAsistenciaContratos { get; set; } = new List<PtAsistenciaContrato>();

    [InverseProperty("Contrato")]
    public virtual ICollection<PtCargoContrato> PtCargoContratos { get; set; } = new List<PtCargoContrato>();

    [InverseProperty("Contrato")]
    public virtual ICollection<PtContratoEvaluacionGlobal> PtContratoEvaluacionGlobals { get; set; } = new List<PtContratoEvaluacionGlobal>();

    [InverseProperty("Contrato")]
    public virtual ICollection<PtContratoEvaluacion> PtContratoEvaluacions { get; set; } = new List<PtContratoEvaluacion>();

    [InverseProperty("Contrato")]
    public virtual ICollection<PtDocumento> PtDocumentos { get; set; } = new List<PtDocumento>();

    [InverseProperty("Contrato")]
    public virtual ICollection<PtHorarioContrato> PtHorarioContratos { get; set; } = new List<PtHorarioContrato>();
}
