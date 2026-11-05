using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_aula")]
[Index("PabellonId", Name = "pabellon_id")]
public partial class PtAula
{
    [Key]
    [Column("id_aula", TypeName = "int(11)")]
    public int IdAula { get; set; }

    [Column("pabellon_id", TypeName = "int(11)")]
    public int? PabellonId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(20)]
    public string? Nombre { get; set; }

    [Column("aforo_carpetas", TypeName = "int(11)")]
    public int? AforoCarpetas { get; set; }

    [Column("aforo_estudiantes", TypeName = "int(11)")]
    public int? AforoEstudiantes { get; set; }

    /// <summary>
    /// Tipo de aula: (Salón de clases, Sala de Cómputo, etc)
    /// </summary>
    [Column("tipo")]
    [StringLength(100)]
    public string? Tipo { get; set; }

    /// <summary>
    /// medidas en metros: ancho, largo y área
    /// </summary>
    [Column("dimensiones")]
    [StringLength(20)]
    public string? Dimensiones { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("piso_aula", TypeName = "int(11)")]
    public int? PisoAula { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("PabellonId")]
    [InverseProperty("PtAulas")]
    public virtual PtPabellon? Pabellon { get; set; }
}
