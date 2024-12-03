using System;
using System.ComponentModel.DataAnnotations;

namespace FornecePro.Models
{
    public class CadastroModels
    {
        [Key]
        public long Id { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Razão Social é obrigatória.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; } // Alterado para string

        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Número é obrigatório.")]
        public string Numero { get; set; } // Alterado para string

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        public string Cep { get; set; } // Alterado para string

        [Required(ErrorMessage = "Nome do Contato é obrigatório.")]
        public string NomeContato { get; set; }
    }
}
