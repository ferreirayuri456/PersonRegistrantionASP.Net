using System.ComponentModel.DataAnnotations;

namespace cadastroPessoa.Models
{
    public class Pessoa
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório" )]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        public string Telefone { get; set; }


    }
}