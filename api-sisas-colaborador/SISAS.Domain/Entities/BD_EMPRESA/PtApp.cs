using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_app")]
public partial class PtApp
{
    [Key]
    [Column("id_app", TypeName = "int(11)")]
    public int IdApp { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("siglas")]
    [StringLength(50)]
    public string? Siglas { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    [Column("url")]
    [StringLength(1000)]
    public string? Url { get; set; }

    [Column("url_amigable")]
    [StringLength(1000)]
    public string? UrlAmigable { get; set; }

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

    [InverseProperty("App")]
    public virtual ICollection<PtAppEmpresa> PtAppEmpresas { get; set; } = new List<PtAppEmpresa>();

    [InverseProperty("App")]
    public virtual ICollection<PtModulo> PtModulos { get; set; } = new List<PtModulo>();
}
