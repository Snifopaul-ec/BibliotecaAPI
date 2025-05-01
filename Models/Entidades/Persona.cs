using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models.Entidades;

[Table("personas")]
[Index("Cedula", Name = "UQ__personas__415B7BE562FFEF3E", IsUnique = true)]
public partial class Persona
{
    [Key]
    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("nombres")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Nombres { get; set; }

    [Column("apellidos")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Apellidos { get; set; }

    [Column("cedula")]
    [StringLength(10)]
    [Unicode(false)]
    public string Cedula { get; set; } = null!;

    [Column("telefono")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
