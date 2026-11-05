using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_escala")]
public partial class PtEscala
{
    [Key]
    [Column("id_escala", TypeName = "int(11)")]
    public int IdEscala { get; set; }

    [Column("nombre")]
    [StringLength(20)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Escala")]
    public virtual ICollection<PtContrato> PtContratos { get; set; } = new List<PtContrato>();
}
