using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_empleado")]
[Index("DistritoIdResidencia", Name = "distrito_id_residencia")]
[Index("UsuarioId", Name = "usuario_id")]
public partial class PtEmpleado
{
    [Key]
    [Column("id_empleado", TypeName = "int(11)")]
    public int IdEmpleado { get; set; }

    [Column("usuario_id", TypeName = "int(11)")]
    public int? UsuarioId { get; set; }

    [Column("distrito_id_residencia", TypeName = "int(11)")]
    public int? DistritoIdResidencia { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    /// <summary>
    /// DNI = 1, LIBRETA ELECTORAL = 2, PASAPORTE = 3, OTROS = 4, GENERADO POR EL SISTEMA = 5
    /// </summary>
    [Column("tipo_documento", TypeName = "int(11)")]
    public int? TipoDocumento { get; set; }

    [Column("numero_documento")]
    [StringLength(100)]
    public string? NumeroDocumento { get; set; }

    [Column("apellido_paterno")]
    [StringLength(100)]
    public string? ApellidoPaterno { get; set; }

    [Column("apellido_materno")]
    [StringLength(100)]
    public string? ApellidoMaterno { get; set; }

    [Column("nombres")]
    [StringLength(100)]
    public string? Nombres { get; set; }

    [Column("direccion_residencia")]
    [StringLength(500)]
    public string? DireccionResidencia { get; set; }

    [Column("celulares")]
    [StringLength(100)]
    public string? Celulares { get; set; }

    [Column("correos")]
    [StringLength(500)]
    public string? Correos { get; set; }

    [Column("religion")]
    [StringLength(50)]
    public string? Religion { get; set; }

    /// <summary>
    /// 1 = MASCULINO, 2 = FEMENINO, 3 = OTROS, 4 = PREFIERO NO DECIRLO
    /// </summary>
    [Column("genero", TypeName = "int(11)")]
    public int? Genero { get; set; }

    /// <summary>
    /// EL SR. , LA SRA., ETC
    /// </summary>
    [Column("sustantivo")]
    [StringLength(50)]
    public string? Sustantivo { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("EmpleadoIdContratanteNavigation")]
    public virtual ICollection<PtContrato> PtContratoEmpleadoIdContratanteNavigations { get; set; } = new List<PtContrato>();

    [InverseProperty("Empleado")]
    public virtual ICollection<PtContrato> PtContratoEmpleados { get; set; } = new List<PtContrato>();
}
