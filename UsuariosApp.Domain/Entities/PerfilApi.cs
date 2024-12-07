namespace UsuariosApp.Domain.Entities
{
    public class PerfilApi : EntityBase
    {
        public int PerfilId { get; set; }
        public int ApiId { get; set; }

        public Perfil? Perfil { get; set; }
        public Api? Api { get; set; }
    }
}