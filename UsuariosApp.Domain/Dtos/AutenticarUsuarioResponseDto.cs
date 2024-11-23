namespace UsuariosApp.Domain.Dtos
{
    public class AutenticarUsuarioResponseDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public PerfilResponseDto? Perfil { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
        public string? AccessToken { get; set; }
    }
}