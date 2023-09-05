using Administrador.Enums;
using System.ComponentModel.DataAnnotations;

namespace Administrador.Models
{
    public class UsuarioModel
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuário!")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do Usuário!")]
        public required string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do Usuário!")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é válido!")]
        public required string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do Usuário!")]
        public required string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
