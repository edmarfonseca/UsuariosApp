namespace UsuariosApp.Domain.Entities
{
    public class Api : EntityBase
    {        
        public string? Nome { get; set; }
        public string? Uri { get; set; }
        public int SistemaId { get; set; }

        public Sistema? Sistema { get; set; }
        public ICollection<PerfilApi>? Perfis { get; set; }
    }
}