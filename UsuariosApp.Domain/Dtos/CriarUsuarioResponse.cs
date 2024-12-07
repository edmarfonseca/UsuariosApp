namespace UsuariosApp.Domain.Dtos
{
    public class CriarUsuarioResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataInclusao { get; set; }
        public ClienteResponse? Cliente { get; set; }
    }
}