using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPRESA;

[Table("pt_pagina")]
[Index("ModuloId", Name = "modulo_id")]
public partial class PtPagina
{
    [Key]
    [Column("id_pagina", TypeName = "int(11)")]
    public int IdPagina { get; set; }

    [Column("modulo_id", TypeName = "int(11)")]
    public int? ModuloId { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("nombre_corto")]
    [StringLength(100)]
    public string? NombreCorto { get; set; }

    [Column("nombre_largo")]
    [StringLength(100)]
    public string? NombreLargo { get; set; }

    [Column("url")]
    [StringLength(1000)]
    public string? Url { get; set; }

    [Column("url_amigable")]
    [StringLength(1000)]
    public string? UrlAmigable { get; set; }

    /// <summary>
    /// PENDIENTE = 1, INTERNO = 2, EXERNO = 3
    /// </summary>
    [Column("tipo", TypeName = "int(11)")]
    public int? Tipo { get; set; }

    /// <summary>
    ///  	PENDIENTE = 1, APP - FRONTEND = 2, API - BACKEND = 3 	
    /// </summary>
    [Column("tipo_uri", TypeName = "int(11)")]
    public int? TipoUri { get; set; }

    /// <summary>
    /// PENDIENTE = 1, HABILITADO = 2, DESHABILITADO = 3
    /// </summary>
    [Column("estado", TypeName = "int(11)")]
    public int? Estado { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

    [Column("descripcion")]
    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ModuloId")]
    [InverseProperty("PtPaginas")]
    public virtual PtModulo? Modulo { get; set; }
}
