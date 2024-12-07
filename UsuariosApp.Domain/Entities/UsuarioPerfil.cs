namespace UsuariosApp.Domain.Entities
{
    public class UsuarioPerfil : EntityBase
    {
        public int UsuarioId { get; set; }        
        public int ClienteSistemaId { get; set; }
        public int PerfilId { get; set; }

        public Usuario? Usuario { get; set; }        
        public ClienteSistema? ClienteSistema { get; set; }
        public Perfil? Perfil { get; set; }
    }
}