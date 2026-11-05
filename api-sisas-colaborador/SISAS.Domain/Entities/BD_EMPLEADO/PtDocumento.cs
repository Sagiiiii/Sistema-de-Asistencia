using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SISAS.Domain.Entities.BD_EMPLEADO;

[Table("pt_documento")]
[Index("CargoContratoId", Name = "cargo_contrato_id")]
[Index("ContratoId", Name = "contrato_id")]
public partial class PtDocumento
{
    [Key]
    [Column("id_documento", TypeName = "int(11)")]
    public int IdDocumento { get; set; }

    [Column("contrato_id", TypeName = "int(11)")]
    public int ContratoId { get; set; }

    [Column("cargo_contrato_id", TypeName = "int(11)")]
    public int CargoContratoId { get; set; }

    [Column("codigo")]
    [StringLength(100)]
    public string Codigo { get; set; } = null!;

    /// <summary>
    /// CERTIFICADO = 1, CONSTANCIA = 2
    /// </summary>
    [Column("tipo")]
    [StringLength(100)]
    public string Tipo { get; set; } = null!;

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("year", TypeName = "year(4)")]
    public short? Year { get; set; }

    [Column("year_nombre")]
    [StringLength(500)]
    public string YearNombre { get; set; } = null!;

    [Column("titulo")]
    [StringLength(500)]
    public string Titulo { get; set; } = null!;

    [Column("empresa")]
    [StringLength(50)]
    public string? Empresa { get; set; }

    [Column("empresa_razon_social")]
    [StringLength(500)]
    public string EmpresaRazonSocial { get; set; } = null!;

    [Column("empresa_ruc")]
    [StringLength(50)]
    public string EmpresaRuc { get; set; } = null!;

    [Column("empresa_representante")]
    [StringLength(500)]
    public string EmpresaRepresentante { get; set; } = null!;

    [Column("empresa_representante_cargo")]
    [StringLength(100)]
    public string EmpresaRepresentanteCargo { get; set; } = null!;

    [Column("empresa_direccion")]
    [StringLength(500)]
    public string? EmpresaDireccion { get; set; }

    [Column("empresa_distrito")]
    [StringLength(100)]
    public string EmpresaDistrito { get; set; } = null!;

    [Column("empresa_provincia")]
    [StringLength(100)]
    public string? EmpresaProvincia { get; set; }

    [Column("empresa_departamento")]
    [StringLength(100)]
    public string? EmpresaDepartamento { get; set; }

    /// <summary>
    /// CERTIFICA, HACE CONSTAR, ETC
    /// </summary>
    [Column("accion")]
    [StringLength(50)]
    public string Accion { get; set; } = null!;

    /// <summary>
    /// SR., SRITA, LIC, ETC
    /// </summary>
    [Column("empleado_sustantivo")]
    [StringLength(10)]
    public string? EmpleadoSustantivo { get; set; }

    /// <summary>
    /// OTROS = 1, DNI = 2, LIBRETA ELECTORAL = 3, PASAPORTE = 4
    /// </summary>
    [Column("empleado_tipo_documento")]
    [StringLength(100)]
    public string EmpleadoTipoDocumento { get; set; } = null!;

    [Column("empleado_numero_documento")]
    [StringLength(100)]
    public string EmpleadoNumeroDocumento { get; set; } = null!;

    [Column("empleado_nombres")]
    [StringLength(500)]
    public string EmpleadoNombres { get; set; } = null!;

    [Column("empleado_cargo")]
    [StringLength(500)]
    public string? EmpleadoCargo { get; set; }

    [Column("empleado_inicio", TypeName = "datetime")]
    public DateTime? EmpleadoInicio { get; set; }

    [Column("empleado_fin", TypeName = "datetime")]
    public DateTime? EmpleadoFin { get; set; }

    [Column("firma_ciudad")]
    [StringLength(100)]
    public string FirmaCiudad { get; set; } = null!;

    [Column("firma_fecha", TypeName = "datetime")]
    public DateTime FirmaFecha { get; set; }

    /// <summary>
    /// PENDIENTE = 1, EXPEDIDO = 2, ANULADO = 3
    /// </summary>
    [Column("estado")]
    [StringLength(100)]
    public string Estado { get; set; } = null!;

    [Column("estado_detalles")]
    [StringLength(500)]
    public string? EstadoDetalles { get; set; }

    [Column("fecha_primera_generacion", TypeName = "datetime")]
    public DateTime? FechaPrimeraGeneracion { get; set; }

    [Column("fecha_ultima_generacion", TypeName = "datetime")]
    public DateTime? FechaUltimaGeneracion { get; set; }

    [Column("ruta")]
    [StringLength(5000)]
    public string? Ruta { get; set; }

    [Column("detalles")]
    [StringLength(1000)]
    public string? Detalles { get; set; }

    [Column("created_by")]
    [StringLength(250)]
    public string? CreatedBy { get; set; }

    [Column("updated_by")]
    [StringLength(250)]
    public string? UpdatedBy { get; set; }

    [Column("deleted_by")]
    [StringLength(250)]
    public string? DeletedBy { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CargoContratoId")]
    [InverseProperty("PtDocumentos")]
    public virtual PtCargoContrato CargoContrato { get; set; } = null!;

    [ForeignKey("ContratoId")]
    [InverseProperty("PtDocumentos")]
    public virtual PtContrato Contrato { get; set; } = null!;
}
