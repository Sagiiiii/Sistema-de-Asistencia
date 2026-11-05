using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_cargo")]
[Index("AreaId", Name = "area_id")]
public partial class PtCargo
{
    [Key]
    [Column("id_cargo", TypeName = "int(11)")]
    public int IdCargo { get; set; }

    [Column("area_id", TypeName = "int(11)")]
    public int? AreaId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("funciones")]
    public string? Funciones { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("PtCargos")]
    public virtual PtArea? Area { get; set; }

    [InverseProperty("Cargo")]
    public virtual ICollection<PtCargoContrato> PtCargoContratos { get; set; } = new List<PtCargoContrato>();
}
