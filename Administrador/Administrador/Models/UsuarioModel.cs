﻿using Administrador.Enums;
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
        [Required(ErrorMessage = "Informe o perfil do Usuário")]
        public required PerfilEnum? Perfil { get; set; }
        
        public string? Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public bool ValidaSenha(string senha)
        {
            return Senha == senha;
        }

    }
}
