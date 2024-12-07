namespace UsuariosApp.Domain.Entities
{
    public class Sistema : EntityBase
    {
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Url { get; set; }

        public ICollection<ClienteSistema>? Clientes { get; set; }
        public ICollection<Api>? Apis { get; set; }
        public ICollection<Perfil>? Perfis { get; set; }
    }
}