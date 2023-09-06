using System.ComponentModel.DataAnnotations;

namespace Administrador.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Usuário!")]
        public required string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha!")]
        public required string Senha { get; set; }
    }
}
