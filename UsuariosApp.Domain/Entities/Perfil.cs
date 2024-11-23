namespace UsuariosApp.Domain.Entities
{
    public class Perfil
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<PerfilPermissao>? Permissoes { get; set; }
    }
}