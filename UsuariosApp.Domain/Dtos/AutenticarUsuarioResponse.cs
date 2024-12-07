namespace UsuariosApp.Domain.Dtos
{
    public class AutenticarUsuarioResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
        public string? AccessToken { get; set; }

        public ICollection<UsuarioPerfisResponse>? Sistemas { get; set; }
    }
}