using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("usuarios")]
[Index("Correo", Name = "UQ__usuarios__2A586E0BA440ACDF", IsUnique = true)]
[Index("Usuario1", Name = "UQ__usuarios__9AFF8FC6BC826AAA", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("usuario")]
    [StringLength(255)]
    [Unicode(false)]
    public string Usuario1 { get; set; } = null!;

    [Column("correo")]
    [StringLength(255)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("estado")]
    public bool Estado { get; set; }

    [Column("fecha_inscripcion")]
    public DateOnly? FechaInscripcion { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("Usuarios")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("IdUsuarios")]
    public virtual ICollection<Rol> IdRols { get; set; } = new List<Rol>();
}
