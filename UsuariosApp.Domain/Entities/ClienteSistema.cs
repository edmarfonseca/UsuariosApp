namespace UsuariosApp.Domain.Entities
{
    public class ClienteSistema : EntityBase
    {
        public int ClienteId {  get; set; }
        public int SistemaId {  get; set; }

        public Cliente? Cliente { get; set; }
        public Sistema? Sistema { get; set; }
        public ICollection<UsuarioPerfil>? UsuariosPerfis { get; set; }
    }
}