using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_asistencia_contrato")]
[Index("ContratoId", Name = "contrato_id")]
[Index("HorarioContratoId", Name = "horario_contrato_id")]
[Index("SesionId", Name = "sesion_id")]
public partial class PtAsistenciaContrato
{
    [Key]
    [Column("id_asistencia_contrato", TypeName = "int(11)")]
    public int IdAsistenciaContrato { get; set; }

    [Column("contrato_id", TypeName = "int(11)")]
    public int? ContratoId { get; set; }

    [Column("horario_contrato_id", TypeName = "int(11)")]
    public int? HorarioContratoId { get; set; }

    [Column("sesion_id", TypeName = "int(11)")]
    public int? SesionId { get; set; }

    [Column("fecha_ingreso", TypeName = "datetime")]
    public DateTime? FechaIngreso { get; set; }

    [Column("fecha_salida", TypeName = "datetime")]
    public DateTime? FechaSalida { get; set; }

    [Column("tiempo_permanencia", TypeName = "time")]
    public TimeOnly? TiempoPermanencia { get; set; }

    [Column("tardanza", TypeName = "time")]
    public TimeOnly? Tardanza { get; set; }

    /// <summary>
    /// PENDIENTE = 1, ASISTIÓ = 2, FALTÓ = 3, TARDE = 4, JUSTIFICADO = 5
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    [Column("detalles_estado")]
    public string? DetallesEstado { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_by")]
    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [Column("updated_by")]
    [StringLength(100)]
    public string? UpdatedBy { get; set; }

    [Column("deleted_by")]
    [StringLength(100)]
    public string? DeletedBy { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ContratoId")]
    [InverseProperty("PtAsistenciaContratos")]
    public virtual PtContrato? Contrato { get; set; }

    [ForeignKey("HorarioContratoId")]
    [InverseProperty("PtAsistenciaContratos")]
    public virtual PtHorarioContrato? HorarioContrato { get; set; }
}
