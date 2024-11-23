namespace UsuariosApp.Domain.Dtos
{
    public class CriarUsuarioRequestDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}