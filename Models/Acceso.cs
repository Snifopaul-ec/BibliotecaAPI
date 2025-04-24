using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("acceso")]
public partial class Acceso
{
    [Key]
    [Column("id_acceso")]
    public int IdAcceso { get; set; }

    [Column("usuario")]
    [StringLength(255)]
    [Unicode(false)]
    public string Usuario { get; set; } = null!;

    [Column("fecha_hora", TypeName = "datetime")]
    public DateTime FechaHora { get; set; }

    [Column("exito")]
    public bool Exito { get; set; }
}
