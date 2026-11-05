using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_infraccion")]
[Index("CategoriaInfraccionId", Name = "categoria_infraccion_id")]
[Index("SancionId", Name = "sancion_id")]
public partial class PtInfraccion
{
    [Key]
    [Column("id_infraccion", TypeName = "int(11)")]
    public int IdInfraccion { get; set; }

    [Column("categoria_infraccion_id", TypeName = "int(11)")]
    public int? CategoriaInfraccionId { get; set; }

    [Column("sancion_id", TypeName = "int(11)")]
    public int? SancionId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("escala", TypeName = "int(11)")]
    public int? Escala { get; set; }

    /// <summary>
    /// LEVE = 1, GRAVE = 2, MUY GRAVE = 3
    /// </summary>
    [Column("gravedad", TypeName = "int(11)")]
    public int? Gravedad { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CategoriaInfraccionId")]
    [InverseProperty("PtInfraccions")]
    public virtual PtCategoriaInfraccion? CategoriaInfraccion { get; set; }

    [ForeignKey("SancionId")]
    [InverseProperty("PtInfraccions")]
    public virtual PtSancion? Sancion { get; set; }
}
