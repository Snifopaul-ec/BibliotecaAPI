using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("auditoria")]
public partial class Auditorium
{
    [Key]
    [Column("id_auditoria")]
    public int IdAuditoria { get; set; }

    [Column("tabla_afectada")]
    [StringLength(255)]
    [Unicode(false)]
    public string TablaAfectada { get; set; } = null!;

    [Column("accion")]
    [StringLength(255)]
    [Unicode(false)]
    public string Accion { get; set; } = null!;

    [Column("fecha_hora", TypeName = "datetime")]
    public DateTime FechaHora { get; set; }

    [Column("usuario")]
    [StringLength(255)]
    [Unicode(false)]
    public string Usuario { get; set; } = null!;

    [Column("json_detalle")]
    public string? JsonDetalle { get; set; }
}
