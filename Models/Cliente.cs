using System.ComponentModel.DataAnnotations;

namespace ProjetoAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public bool Disponivel { get; set; }
        public bool Status { get; set; }
    }
}