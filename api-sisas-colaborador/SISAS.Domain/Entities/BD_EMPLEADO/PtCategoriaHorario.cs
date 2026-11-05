using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_categoria_horario")]
public partial class PtCategoriaHorario
{
    [Key]
    [Column("id_categoria_horario", TypeName = "int(11)")]
    public int IdCategoriaHorario { get; set; }


    [Column("nombre")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("nombre_corto")]
    [StringLength(50)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }
}
