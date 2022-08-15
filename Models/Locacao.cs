using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAPI.Models
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Status { get; set; }
    }
}