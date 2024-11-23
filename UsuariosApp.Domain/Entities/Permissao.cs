namespace UsuariosApp.Domain.Entities
{
    public class Permissao
    {        
        public int Id { get; set; }
        public string? Nome { get; set; }

        public ICollection<PerfilPermissao>? Perfis { get; set; }
    }
}