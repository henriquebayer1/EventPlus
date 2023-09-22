

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{


    [Table(nameof(TiposEvento))]
    public class TiposEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O titulo e obrigatorio")]
        public string? Titulo { get; set; }
    }
}
