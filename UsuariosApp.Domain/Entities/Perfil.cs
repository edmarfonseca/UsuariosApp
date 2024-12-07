namespace UsuariosApp.Domain.Entities
{
    public class Perfil : EntityBase
    {
        public string? Nome { get; set; }
        public int SistemaId { get; set; }

        public Sistema? Sistema {  get; set; }
        public ICollection<PerfilApi>? Apis { get; set; }
        public ICollection<UsuarioPerfil>? Usuarios { get; set; }
    }
}