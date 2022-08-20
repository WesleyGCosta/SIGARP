﻿// <auto-generated />
using System;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Ata", b =>
                {
                    b.Property<int>("CodigoAta")
                        .HasColumnType("int");

                    b.Property<int>("AnoAta")
                        .HasColumnType("int");

                    b.Property<int>("AnoPregao")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataFinalVigencia")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataHomologacao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataPublicacaoDOE")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataPublicacaoSistema")
                        .HasColumnType("date");

                    b.Property<double>("LimiteAdesao")
                        .HasColumnType("float");

                    b.Property<string>("NumeroPregao")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("NumeroProcesso")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("ObjetoResumido")
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<bool>("Publicada")
                        .HasColumnType("bit");

                    b.Property<string>("TipoPregao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CodigoAta", "AnoAta");

                    b.ToTable("Atas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Detentora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("Varchar(18)");

                    b.Property<string>("Email")
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Pessoa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("Varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Detentoras", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetentoraItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DetentoraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DetentoraId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("DetentorasItens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("Varchar(10)");

                    b.Property<Guid>("DetentoraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("Varchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("DetentoraId");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnoAta")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CodigoAta")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(8000)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<int>("NumeroItem")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoMercado")
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("PrecoRegistrado")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UnidadeAquisicao")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoAta", "AnoAta");

                    b.ToTable("Itens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ParticipanteItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UnidadeAdministrativaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UnidadeAdministrativaId");

                    b.ToTable("ParticipantesItens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProgramacaoConsumoParticipante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Aditivo")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("ConsumoEstimado")
                        .HasColumnType("int");

                    b.Property<Guid>("ParticipanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("SaldoAnterior")
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("Transferido")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.HasIndex("ParticipanteId")
                        .IsUnique();

                    b.ToTable("ProgamacaoConsumoParticipantes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UnidadeAdministrativa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("EsferaAdministrativa")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NomeUnidadeAdministrativa")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<bool>("OrgaoEx")
                        .HasColumnType("bit");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("Varchar(10)");

                    b.Property<string>("UnidadeDaFederacao")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UnidadesAdministrativas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetentoraItem", b =>
                {
                    b.HasOne("Domain.Entities.Detentora", "Detentora")
                        .WithMany("DetentorasItens")
                        .HasForeignKey("DetentoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Item", "Item")
                        .WithOne("DetentoraItem")
                        .HasForeignKey("Domain.Entities.DetentoraItem", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detentora");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domain.Entities.Endereco", b =>
                {
                    b.HasOne("Domain.Entities.Detentora", "Detentora")
                        .WithMany("Enderecos")
                        .HasForeignKey("DetentoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Detentora");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.HasOne("Domain.Entities.Ata", "Ata")
                        .WithMany("Itens")
                        .HasForeignKey("CodigoAta", "AnoAta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ata");
                });

            modelBuilder.Entity("Domain.Entities.ParticipanteItem", b =>
                {
                    b.HasOne("Domain.Entities.Item", "Item")
                        .WithMany("ParticipantesItens")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UnidadeAdministrativa", "UnidadeAdministrativa")
                        .WithMany("ParticipantesItens")
                        .HasForeignKey("UnidadeAdministrativaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("UnidadeAdministrativa");
                });

            modelBuilder.Entity("Domain.Entities.ProgramacaoConsumoParticipante", b =>
                {
                    b.HasOne("Domain.Entities.ParticipanteItem", "ParticipanteItem")
                        .WithOne("ProgramacoesConsumoParticipantes")
                        .HasForeignKey("Domain.Entities.ProgramacaoConsumoParticipante", "ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParticipanteItem");
                });

            modelBuilder.Entity("Domain.Entities.Ata", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("Domain.Entities.Detentora", b =>
                {
                    b.Navigation("DetentorasItens");

                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Navigation("DetentoraItem");

                    b.Navigation("ParticipantesItens");
                });

            modelBuilder.Entity("Domain.Entities.ParticipanteItem", b =>
                {
                    b.Navigation("ProgramacoesConsumoParticipantes");
                });

            modelBuilder.Entity("Domain.Entities.UnidadeAdministrativa", b =>
                {
                    b.Navigation("ParticipantesItens");
                });
#pragma warning restore 612, 618
        }
    }
}
