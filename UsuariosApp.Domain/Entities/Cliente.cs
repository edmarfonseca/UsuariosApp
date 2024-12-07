namespace UsuariosApp.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string? Nome { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<ClienteSistema>? Sistemas { get; set; }
    }
}