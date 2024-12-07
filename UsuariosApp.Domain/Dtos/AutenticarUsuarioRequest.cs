namespace UsuariosApp.Domain.Dtos
{
    public class AutenticarUsuarioRequest
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}