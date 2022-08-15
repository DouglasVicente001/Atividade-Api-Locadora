using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;
using System;

namespace ProjetoAPI.Data
{
    public class ApplicationDbContext  : DbContext
    {   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option){
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Filme>()
                .HasData(
                    new Filme { Id = 1, Titulo = "O Resgate do Soldado Ryan", Genero = "Guerra", Disponivel = true, Status = true },
                    new Filme { Id = 2, Titulo = "Titanic", Genero = "Drama", Disponivel = true, Status = true },
                    new Filme { Id = 3, Titulo = "Gente Grande", Genero = "Comédia", Disponivel = true, Status = true },
                    new Filme { Id = 4, Titulo = "A Bruxa de Blair", Genero = "Terror", Disponivel = true, Status = true }
                );

            modelBuilder.Entity<Cliente>()
                .HasData(
                    new Cliente { Id = 1, Nome = "João da Silva", Email = "joao.silva@gft.com", Telefone = "9988-1294", Cpf = "892.190.982-15", Status = true},
                    new Cliente { Id = 2, Nome = "Maria de Souza", Email = "maria.souza@gft.com", Telefone = "9876-5566", Cpf = "192.889.021-44", Status = true},
                    new Cliente { Id = 3, Nome = "Marcos Rocha", Email = "marcos.rocha@gft.com", Telefone = "9911-8721", Cpf = "231.114.569-01", Status = true},
                    new Cliente { Id = 4, Nome = "Marcelo Guedes", Email = "marcelo.guedes@gft.com", Telefone = "9723-9012", Cpf = "734.231.892-54", Status = true}
                );
        }
    }
}