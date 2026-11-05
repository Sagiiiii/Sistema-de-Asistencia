using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_empresa")]
[Index("DistritoId", Name = "distrito_id")]
public partial class PtEmpresa
{
    [Key]
    [Column("id_empresa", TypeName = "int(11)")]
    public int IdEmpresa { get; set; }

    [Column("distrito_id", TypeName = "int(11)")]
    public int? DistritoId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("razon_social")]
    [StringLength(500)]
    public string? RazonSocial { get; set; }

    [Column("ruc")]
    [StringLength(15)]
    public string? Ruc { get; set; }

    [Column("actividad_econonomica")]
    [StringLength(1000)]
    public string? ActividadEcononomica { get; set; }

    [Column("celulares")]
    [StringLength(100)]
    public string? Celulares { get; set; }

    [Column("correos")]
    [StringLength(500)]
    public string? Correos { get; set; }

    [Column("direccion")]
    [StringLength(500)]
    public string? Direccion { get; set; }

    [Column("representante")]
    [StringLength(500)]
    public string? Representante { get; set; }

    [Column("representante_cargo")]
    [StringLength(100)]
    public string? RepresentanteCargo { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("DistritoId")]
    [InverseProperty("PtEmpresas")]
    public virtual PtDistrito? Distrito { get; set; }

    [InverseProperty("Empresa")]
    public virtual ICollection<PtAppEmpresa> PtAppEmpresas { get; set; } = new List<PtAppEmpresa>();

    [InverseProperty("Empresa")]
    public virtual ICollection<PtSede> PtSedes { get; set; } = new List<PtSede>();
}
