using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("rol")]
public partial class Rol
{
    [Key]
    [Column("id_rol")]
    public int IdRol { get; set; }

    [Column("nombre_rol")]
    [StringLength(255)]
    [Unicode(false)]
    public string NombreRol { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("IdRols")]
    public virtual ICollection<Permiso> IdPermisos { get; set; } = new List<Permiso>();

    [ForeignKey("IdRol")]
    [InverseProperty("IdRols")]
    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
