using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_sede")]
[Index("EmpresaId", Name = "empresa_id")]
public partial class PtSede
{
    [Key]
    [Column("id_sede", TypeName = "int(11)")]
    public int IdSede { get; set; }

    [Column("empresa_id", TypeName = "int(11)")]
    public int EmpresaId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string Codigo { get; set; } = null!;

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    [Column("abreviatura")]
    [StringLength(100)]
    public string? Abreviatura { get; set; }

    [Column("direccion")]
    [StringLength(500)]
    public string? Direccion { get; set; }

    [Column("dre")]
    [StringLength(100)]
    public string? Dre { get; set; }

    [Column("ugel")]
    [StringLength(100)]
    public string? Ugel { get; set; }

    [Column("codigo_modular_inicial")]
    [StringLength(100)]
    public string? CodigoModularInicial { get; set; }

    [Column("codigo_modular_primaria")]
    [StringLength(100)]
    public string? CodigoModularPrimaria { get; set; }

    [Column("codigo_modular_secundaria")]
    [StringLength(100)]
    public string? CodigoModularSecundaria { get; set; }

    [Column("ie")]
    [StringLength(100)]
    public string? Ie { get; set; }

    [Column("orden", TypeName = "int(11)")]
    public int? Orden { get; set; }

    [Column("contactos_publico", TypeName = "json")]
    public string? ContactosPublico { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO =2, DESHABILITADO = 3
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

    [ForeignKey("EmpresaId")]
    [InverseProperty("PtSedes")]
    public virtual PtEmpresa Empresa { get; set; } = null!;

    [InverseProperty("Sede")]
    public virtual ICollection<PtPabellon> PtPabellons { get; set; } = new List<PtPabellon>();
}
