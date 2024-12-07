using System.ComponentModel.DataAnnotations.Schema;

namespace UsuariosApp.Domain.Entities
{
    public class EntityBase
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("DATA_INCLUSAO")]
        public DateTime DataInclusao { get; set; }

        [Column("DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }
    }
}