using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_pabellon")]
[Index("SedeId", Name = "sede_id")]
public partial class PtPabellon
{
    [Key]
    [Column("id_pabellon", TypeName = "int(11)")]
    public int IdPabellon { get; set; }

    [Column("sede_id", TypeName = "int(11)")]
    public int? SedeId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(50)]
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

    [InverseProperty("Pabellon")]
    public virtual ICollection<PtAula> PtAulas { get; set; } = new List<PtAula>();

    [ForeignKey("SedeId")]
    [InverseProperty("PtPabellons")]
    public virtual PtSede? Sede { get; set; }
}
