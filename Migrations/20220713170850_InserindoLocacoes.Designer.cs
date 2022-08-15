﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoAPI.Data;

namespace ProjetoAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220713170850_InserindoLocacoes")]
    partial class InserindoLocacoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ProjetoAPI.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "892.190.982-15",
                            Email = "joao.silva@gft.com",
                            Nome = "João da Silva",
                            Status = true,
                            Telefone = "9988-1294"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "192.889.021-44",
                            Email = "maria.souza@gft.com",
                            Nome = "Maria de Souza",
                            Status = true,
                            Telefone = "9876-5566"
                        },
                        new
                        {
                            Id = 3,
                            Cpf = "231.114.569-01",
                            Email = "marcos.rocha@gft.com",
                            Nome = "Marcos Rocha",
                            Status = true,
                            Telefone = "9911-8721"
                        },
                        new
                        {
                            Id = 4,
                            Cpf = "734.231.892-54",
                            Email = "marcelo.guedes@gft.com",
                            Nome = "Marcelo Guedes",
                            Status = true,
                            Telefone = "9723-9012"
                        });
                });

            modelBuilder.Entity("ProjetoAPI.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Disponivel = true,
                            Genero = "Guerra",
                            Status = true,
                            Titulo = "O Resgate do Soldado Ryan"
                        },
                        new
                        {
                            Id = 2,
                            Disponivel = true,
                            Genero = "Drama",
                            Status = true,
                            Titulo = "Titanic"
                        },
                        new
                        {
                            Id = 3,
                            Disponivel = true,
                            Genero = "Comédia",
                            Status = true,
                            Titulo = "Gente Grande"
                        },
                        new
                        {
                            Id = 4,
                            Disponivel = true,
                            Genero = "Terror",
                            Status = true,
                            Titulo = "A Bruxa de Blair"
                        });
                });

            modelBuilder.Entity("ProjetoAPI.Models.Locacao", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("EntregaEmAtraso")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.ToTable("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
