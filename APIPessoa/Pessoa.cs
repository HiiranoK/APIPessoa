using System.ComponentModel.DataAnnotations;

namespace APIPessoa
{
    public class Pessoa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome � obrigat�rio!")]
        [MaxLength(255)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => DateTime.Now.AddYears(-DataNascimento.Year).Year;
        [Range(0,20)]
        public int filhos;
    }
}