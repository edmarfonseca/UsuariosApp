namespace UsuariosApp.Domain.Entities
{
    public class Usuario : EntityBase
    { 
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
        public ICollection<UsuarioPerfil>? Perfis { get; set; }
    }
}