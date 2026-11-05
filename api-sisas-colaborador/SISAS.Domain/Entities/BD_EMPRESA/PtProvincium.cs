using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_provincia")]
[Index("DepartamentoId", Name = "departamento_id")]
public partial class PtProvincium
{
    [Key]
    [Column("id_provincia", TypeName = "int(11)")]
    public int IdProvincia { get; set; }

    [Column("departamento_id", TypeName = "int(11)")]
    public int DepartamentoId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("DepartamentoId")]
    [InverseProperty("PtProvincia")]
    public virtual PtDepartamento Departamento { get; set; } = null!;

    [InverseProperty("Provincia")]
    public virtual ICollection<PtDistrito> PtDistritos { get; set; } = new List<PtDistrito>();
}
