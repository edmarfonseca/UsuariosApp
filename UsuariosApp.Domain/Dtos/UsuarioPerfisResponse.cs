namespace UsuariosApp.Domain.Dtos
{
    public class UsuarioPerfisResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public PerfilResponse? Perfil { get; set; }
    }
}