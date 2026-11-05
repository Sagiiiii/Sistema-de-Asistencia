using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_area")]
[Index("AreaId", Name = "area_id")]
[Index("EmpresaId", Name = "empresa_id")]
public partial class PtArea : BaseEntity
{
  

    [Column("empresa_id", TypeName = "int(11)")]
    public int? EmpresaId { get; set; }

    /// <summary>
    /// ÁREA PADRE
    /// </summary>
    [Column("area_id", TypeName = "int(11)")]
    public int? AreaId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("orden", TypeName = "int(11)")]
    public int? Orden { get; set; }

    [Column("funciones")]
    public string? Funciones { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
 

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }



    [ForeignKey("AreaId")]
    [InverseProperty("InverseArea")]
    public virtual PtArea? Area { get; set; }

    [InverseProperty("Area")]
    public virtual ICollection<PtArea> InverseArea { get; set; } = new List<PtArea>();

    [InverseProperty("Area")]
    public virtual ICollection<PtCargo> PtCargos { get; set; } = new List<PtCargo>();
}
