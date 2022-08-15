using System.ComponentModel.DataAnnotations;

namespace ProjetoAPI.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public bool Disponivel { get; set; }
        public bool Status { get; set; }
    }
}