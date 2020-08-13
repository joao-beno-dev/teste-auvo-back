﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations.SqlServerMigrations
{
    [DbContext(typeof(MsSqlContext))]
    [Migration("20200812164901_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebPonto.Domain.Entities.Marcacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PessoaId")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("MARCACOES");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataHora = new DateTime(2020, 8, 8, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Inicio Dia 1",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 2,
                            DataHora = new DateTime(2020, 8, 8, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Fim Dia 1 (Inicio projeto e modelos)",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 3,
                            DataHora = new DateTime(2020, 8, 9, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Inicio Dia 2",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 4,
                            DataHora = new DateTime(2020, 8, 9, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Fim Dia 2 (modelos e persistencia)",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 5,
                            DataHora = new DateTime(2020, 8, 10, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Inicio Dia 3",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 6,
                            DataHora = new DateTime(2020, 8, 10, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Fim Dia 3 (Persistencia, migrations e dbs)",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 7,
                            DataHora = new DateTime(2020, 8, 11, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Inicio Dia 4",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 8,
                            DataHora = new DateTime(2020, 8, 11, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Fim Dia 4 (Seeds, Rotas e Testes)",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 9,
                            DataHora = new DateTime(2020, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Inicio Dia 5",
                            PessoaId = "João"
                        },
                        new
                        {
                            Id = 10,
                            DataHora = new DateTime(2020, 8, 8, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Fim Dia 5 (Bug Fixes, Remoção testes e Pipeline CD não implementados, Commit)",
                            PessoaId = "João"
                        });
                });

            modelBuilder.Entity("WebPonto.Domain.Entities.Pessoa", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("PESSOAS");

                    b.HasData(
                        new
                        {
                            Id = "João"
                        },
                        new
                        {
                            Id = "Pedro"
                        },
                        new
                        {
                            Id = "Vanessa"
                        },
                        new
                        {
                            Id = "Karla"
                        },
                        new
                        {
                            Id = "Maxwell"
                        },
                        new
                        {
                            Id = "Maxine"
                        },
                        new
                        {
                            Id = "Maxmiliano"
                        },
                        new
                        {
                            Id = "Mario"
                        });
                });

            modelBuilder.Entity("WebPonto.Domain.Entities.Marcacao", b =>
                {
                    b.HasOne("WebPonto.Domain.Entities.Pessoa", "Pessoa")
                        .WithMany("Marcacoes")
                        .HasForeignKey("PessoaId");
                });
#pragma warning restore 612, 618
        }
    }
}