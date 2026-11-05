using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_distrito")]
[Index("ProvinciaId", Name = "provincia_id")]
public partial class PtDistrito
{
    [Key]
    [Column("id_distrito", TypeName = "int(11)")]
    public int IdDistrito { get; set; }

    [Column("provincia_id", TypeName = "int(11)")]
    public int ProvinciaId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("ProvinciaId")]
    [InverseProperty("PtDistritos")]
    public virtual PtProvincium Provincia { get; set; } = null!;

    [InverseProperty("Distrito")]
    public virtual ICollection<PtEmpresa> PtEmpresas { get; set; } = new List<PtEmpresa>();
}
