namespace BibliotecaAPI.Models
{
    public class UpdatePersonaDto
    {
        //public Guid Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
