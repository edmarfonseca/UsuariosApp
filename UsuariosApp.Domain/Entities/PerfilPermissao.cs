namespace UsuariosApp.Domain.Entities
{
    public class PerfilPermissao
    {
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }

        public Perfil? Perfil { get; set; }
        public Permissao? Permissao { get; set; }
    }
}