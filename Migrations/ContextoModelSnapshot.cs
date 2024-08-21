﻿// <auto-generated />
using System;
using Analista_Aula01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Analista_Aula01.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Analista_Aula01.Models.EntradaSaida", b =>
                {
                    b.Property<int>("EntradaSaidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EntradaSaidaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntradaSaidaId"));

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataMovimentacao");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("QntdMovimentacao")
                        .HasColumnType("int")
                        .HasColumnName("QntdMovimentacao");

                    b.Property<int>("TipoMovimentacaoId")
                        .HasColumnType("int");

                    b.HasKey("EntradaSaidaId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("TipoMovimentacaoId");

                    b.ToTable("EntradaSaida");
                });

            modelBuilder.Entity("Analista_Aula01.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProdutoNome");

                    b.Property<int>("ProdutoPeso")
                        .HasColumnType("int")
                        .HasColumnName("ProdutoPeso");

                    b.Property<int>("QntdEstoque")
                        .HasColumnType("int")
                        .HasColumnName("QntdEstoque");

                    b.Property<bool>("StatusProduto")
                        .HasColumnType("bit")
                        .HasColumnName("StatusProduto");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Analista_Aula01.Models.TipoMovimentacao", b =>
                {
                    b.Property<int>("TipoMovimentacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoMovimentacaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMovimentacaoId"));

                    b.Property<string>("NomeTipoMovimentacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoMovimentacao");

                    b.HasKey("TipoMovimentacaoId");

                    b.ToTable("TipoMovimentacao");
                });

            modelBuilder.Entity("Analista_Aula01.Models.TipoProduto", b =>
                {
                    b.Property<int>("TipoProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoProdutoId"));

                    b.Property<string>("NomeTipoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoProduto");

                    b.HasKey("TipoProdutoId");

                    b.ToTable("TipoProduto");
                });

            modelBuilder.Entity("Analista_Aula01.Models.EntradaSaida", b =>
                {
                    b.HasOne("Analista_Aula01.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Analista_Aula01.Models.TipoMovimentacao", "TipoMovimentacao")
                        .WithMany()
                        .HasForeignKey("TipoMovimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("TipoMovimentacao");
                });

            modelBuilder.Entity("Analista_Aula01.Models.Produto", b =>
                {
                    b.HasOne("Analista_Aula01.Models.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });
#pragma warning restore 612, 618
        }
    }
}
