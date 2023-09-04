using System.ComponentModel.DataAnnotations;

namespace Administrador.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Contato!")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do Contato!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public required string Email { get; set;}
        [Required(ErrorMessage = "Digite o telefone do Contato!")]
        [Phone(ErrorMessage = "O Telefone informado não é válido")]
        public required string Telefone { get; set;}
    }
}
