using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_cargo_contrato")]
[Index("CargoId", Name = "cargo_id")]
[Index("ContratoId", Name = "contrato_id")]
public partial class PtCargoContrato
{
    [Key]
    [Column("id_cargo_contrato", TypeName = "int(11)")]
    public int IdCargoContrato { get; set; }

    [Column("contrato_id", TypeName = "int(11)")]
    public int? ContratoId { get; set; }

    [Column("cargo_id", TypeName = "int(11)")]
    public int? CargoId { get; set; }

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

    [ForeignKey("CargoId")]
    [InverseProperty("PtCargoContratos")]
    public virtual PtCargo? Cargo { get; set; }

    [ForeignKey("ContratoId")]
    [InverseProperty("PtCargoContratos")]
    public virtual PtContrato? Contrato { get; set; }

    [InverseProperty("CargoContrato")]
    public virtual ICollection<PtDocumento> PtDocumentos { get; set; } = new List<PtDocumento>();
}
