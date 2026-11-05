using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_modulo")]
[Index("AppId", Name = "app_id")]
public partial class PtModulo
{
    [Key]
    [Column("id_modulo", TypeName = "int(11)")]
    public int IdModulo { get; set; }

    [Column("app_id", TypeName = "int(11)")]
    public int AppId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(50)]
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

    [ForeignKey("AppId")]
    [InverseProperty("PtModulos")]
    public virtual PtApp App { get; set; } = null!;

    [InverseProperty("Modulo")]
    public virtual ICollection<PtPagina> PtPaginas { get; set; } = new List<PtPagina>();
}
