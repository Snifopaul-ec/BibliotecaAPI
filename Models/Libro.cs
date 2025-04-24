using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("libros")]
[Index("Isbn", Name = "UQ__libros__99F9D0A4F5C24661", IsUnique = true)]
public partial class Libro
{
    [Key]
    [Column("id_libro")]
    public int IdLibro { get; set; }

    [Column("titulo")]
    [StringLength(255)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("autor")]
    [StringLength(255)]
    [Unicode(false)]
    public string Autor { get; set; } = null!;

    [Column("editorial")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Editorial { get; set; }

    [Column("anio")]
    public int? Anio { get; set; }

    [Column("isbn")]
    [StringLength(13)]
    [Unicode(false)]
    public string? Isbn { get; set; }
}
