using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_departamento")]
public partial class PtDepartamento
{
    [Key]
    [Column("id_departamento", TypeName = "int(11)")]
    public int IdDepartamento { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Departamento")]
    public virtual ICollection<PtProvincium> PtProvincia { get; set; } = new List<PtProvincium>();
}
