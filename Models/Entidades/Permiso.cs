using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models.Entidades;

[Table("permisos")]
public partial class Permiso
{
    [Key]
    [Column("id_permiso")]
    public int IdPermiso { get; set; }

    [Column("nombre_permiso")]
    [StringLength(255)]
    [Unicode(false)]
    public string NombrePermiso { get; set; } = null!;

    [ForeignKey("IdPermiso")]
    [InverseProperty("IdPermisos")]
    public virtual ICollection<Rol> IdRols { get; set; } = new List<Rol>();
}
