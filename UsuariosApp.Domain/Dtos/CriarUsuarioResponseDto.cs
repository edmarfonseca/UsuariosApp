namespace UsuariosApp.Domain.Dtos
{
    public class CriarUsuarioResponseDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public PerfilResponseDto? Perfil { get; set; }
    }
}