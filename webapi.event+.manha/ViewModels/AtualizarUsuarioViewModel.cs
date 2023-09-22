using System.ComponentModel.DataAnnotations;

namespace webapi.event_.manha.ViewModels
{
    public class AtualizarUsuarioViewModel
    {

        [Required(ErrorMessage = "o email e obrigatorio!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "a senha e obrigatoria!")]
        public string? Senha { get; set; }


    }
}
