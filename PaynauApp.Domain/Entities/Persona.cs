namespace PaynauApp_Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
    }
}
