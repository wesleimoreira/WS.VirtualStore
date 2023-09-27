﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WS.VirtualStore.Api.Context;

#nullable disable

namespace WS.VirtualStore.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230927181507_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Carrinho", b =>
                {
                    b.Property<int>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrinhoId"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Carrinhos");

                    b.HasData(
                        new
                        {
                            CarrinhoId = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            CarrinhoId = 2,
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.CarrinhoItem", b =>
                {
                    b.Property<int>("CarrinhoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrinhoItemId"));

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<int>("CarrinhoItemQuantidade")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoItemId");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CarrinhoItems");
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("CategoriaIcone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            CategoriaIcone = "fas fa-spa",
                            CategoriaNome = "Beleza"
                        },
                        new
                        {
                            CategoriaId = 2,
                            CategoriaIcone = "fas fa-couch",
                            CategoriaNome = "Moveis"
                        },
                        new
                        {
                            CategoriaId = 3,
                            CategoriaIcone = "fas fa-headphones",
                            CategoriaNome = "Eletronicos"
                        },
                        new
                        {
                            CategoriaId = 4,
                            CategoriaIcone = "fas fa-shoe-prints",
                            CategoriaNome = "Calcados"
                        });
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("ProdutoDescricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProdutoImagem")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("ProdutoPreco")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProdutoQuantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            CategoriaId = 1,
                            ProdutoDescricao = "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele",
                            ProdutoImagem = "/Imagens/Beleza/Beleza1.png",
                            ProdutoNome = "Glossier - Beleza Kit",
                            ProdutoPreco = 100m,
                            ProdutoQuantidade = 100
                        },
                        new
                        {
                            ProdutoId = 2,
                            CategoriaId = 1,
                            ProdutoDescricao = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                            ProdutoImagem = "/Imagens/Beleza/Beleza2.png",
                            ProdutoNome = "Curology - Kit para Pele",
                            ProdutoPreco = 50m,
                            ProdutoQuantidade = 45
                        },
                        new
                        {
                            ProdutoId = 3,
                            CategoriaId = 1,
                            ProdutoDescricao = "Um kit fornecido pela Glossier, contendo produtos para cuidados com a pele",
                            ProdutoImagem = "/Imagens/Beleza/Beleza3.png",
                            ProdutoNome = "Óleo de Coco Orgânico",
                            ProdutoPreco = 20m,
                            ProdutoQuantidade = 30
                        },
                        new
                        {
                            ProdutoId = 4,
                            CategoriaId = 1,
                            ProdutoDescricao = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                            ProdutoImagem = "/Imagens/Beleza/Beleza4.png",
                            ProdutoNome = "Schwarzkopf - Kit de cuidados com a pele e cabelo",
                            ProdutoPreco = 50m,
                            ProdutoQuantidade = 60
                        },
                        new
                        {
                            ProdutoId = 5,
                            CategoriaId = 1,
                            ProdutoDescricao = "Kit de cuidados com a pele, contendo produtos para cuidados com a pele e cabelos",
                            ProdutoImagem = "/Imagens/Beleza/Beleza5.png",
                            ProdutoNome = "Kit de cuidados com a pele",
                            ProdutoPreco = 30m,
                            ProdutoQuantidade = 85
                        },
                        new
                        {
                            ProdutoId = 6,
                            CategoriaId = 3,
                            ProdutoDescricao = "Air Pods - fones de ouvido sem fio intra-auriculares",
                            ProdutoImagem = "/Imagens/Eletronicos/eletronico1.png",
                            ProdutoNome = "Fones de ouvidos",
                            ProdutoPreco = 100m,
                            ProdutoQuantidade = 120
                        },
                        new
                        {
                            ProdutoId = 7,
                            CategoriaId = 3,
                            ProdutoDescricao = "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio",
                            ProdutoImagem = "/Imagens/Eletronicos/eletronico2.png",
                            ProdutoNome = "Fones de ouvido dourados",
                            ProdutoPreco = 40m,
                            ProdutoQuantidade = 200
                        },
                        new
                        {
                            ProdutoId = 8,
                            CategoriaId = 3,
                            ProdutoDescricao = "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio",
                            ProdutoImagem = "/Imagens/Eletronicos/eletronico3.png",
                            ProdutoNome = "Fones de ouvido pretos",
                            ProdutoPreco = 40m,
                            ProdutoQuantidade = 300
                        },
                        new
                        {
                            ProdutoId = 9,
                            CategoriaId = 3,
                            ProdutoDescricao = "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé",
                            ProdutoImagem = "/Imagens/Eletronicos/eletronico4.png",
                            ProdutoNome = "Câmera digital Sennheiser com tripé",
                            ProdutoPreco = 600m,
                            ProdutoQuantidade = 20
                        },
                        new
                        {
                            ProdutoId = 10,
                            CategoriaId = 3,
                            ProdutoDescricao = "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon",
                            ProdutoImagem = "/Imagens/Eletronicos/eletronico5.png",
                            ProdutoNome = "Câmera Digital Canon",
                            ProdutoPreco = 500m,
                            ProdutoQuantidade = 15
                        },
                        new
                        {
                            ProdutoId = 11,
                            CategoriaId = 3,
                            ProdutoDescricao = "Gameboy - Fornecido por Nintendo",
                            ProdutoImagem = "/Imagens/Eletronicos/tecnologia6.png",
                            ProdutoNome = "Nintendo Gameboy",
                            ProdutoPreco = 100m,
                            ProdutoQuantidade = 60
                        },
                        new
                        {
                            ProdutoId = 12,
                            CategoriaId = 2,
                            ProdutoDescricao = "Cadeira de escritório em couro preto muito confortável",
                            ProdutoImagem = "/Imagens/Moveis/moveis1.png",
                            ProdutoNome = "Cadeira de escritório de couro preto",
                            ProdutoPreco = 50m,
                            ProdutoQuantidade = 212
                        },
                        new
                        {
                            ProdutoId = 13,
                            CategoriaId = 2,
                            ProdutoDescricao = "Cadeira de escritório em couro rosa muito confortável",
                            ProdutoImagem = "/Imagens/Moveis/moveis2.png",
                            ProdutoNome = "Cadeira de escritório de couro rosa",
                            ProdutoPreco = 50m,
                            ProdutoQuantidade = 112
                        },
                        new
                        {
                            ProdutoId = 14,
                            CategoriaId = 2,
                            ProdutoDescricao = "Poltrona muito confortável",
                            ProdutoImagem = "/Imagens/Moveis/moveis3.png",
                            ProdutoNome = "Espreguiçadeira",
                            ProdutoPreco = 70m,
                            ProdutoQuantidade = 90
                        },
                        new
                        {
                            ProdutoId = 15,
                            CategoriaId = 2,
                            ProdutoDescricao = "Poltrona prateada muito confortável",
                            ProdutoImagem = "/Imagens/Moveis/moveis4.png",
                            ProdutoNome = "Silver Lounge Chair",
                            ProdutoPreco = 120m,
                            ProdutoQuantidade = 95
                        },
                        new
                        {
                            ProdutoId = 16,
                            CategoriaId = 2,
                            ProdutoDescricao = "Abajur de mesa de porcelana branco e azul",
                            ProdutoImagem = "/Imagens/Moveis/moveis6.png",
                            ProdutoNome = "Luminária de mesa de porcelana",
                            ProdutoPreco = 15m,
                            ProdutoQuantidade = 100
                        },
                        new
                        {
                            ProdutoId = 17,
                            CategoriaId = 2,
                            ProdutoDescricao = "Abajur de mesa de escritório",
                            ProdutoImagem = "/Imagens/Moveis/moveis7.png",
                            ProdutoNome = "Office Table Lamp",
                            ProdutoPreco = 20m,
                            ProdutoQuantidade = 73
                        },
                        new
                        {
                            ProdutoId = 18,
                            CategoriaId = 4,
                            ProdutoDescricao = "Tênis Puma confortáveis na maioria dos tamanhos",
                            ProdutoImagem = "/Imagens/Calcados/calcado1.png",
                            ProdutoNome = "Tênis Puma",
                            ProdutoPreco = 100m,
                            ProdutoQuantidade = 50
                        },
                        new
                        {
                            ProdutoId = 19,
                            CategoriaId = 4,
                            ProdutoDescricao = "Tênis coloridos - disponíveis na maioria dos tamanhos",
                            ProdutoImagem = "/Imagens/Calcados/calcado2.png",
                            ProdutoNome = "Tênis Colodiros",
                            ProdutoPreco = 150m,
                            ProdutoQuantidade = 60
                        },
                        new
                        {
                            ProdutoId = 20,
                            CategoriaId = 4,
                            ProdutoDescricao = "Tênis Nike azul - disponível na maioria dos tamanhos",
                            ProdutoImagem = "/Imagens/Calcados/calcado3.png",
                            ProdutoNome = "Tênis Nike Azul",
                            ProdutoPreco = 200m,
                            ProdutoQuantidade = 70
                        },
                        new
                        {
                            ProdutoId = 21,
                            CategoriaId = 4,
                            ProdutoDescricao = "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos",
                            ProdutoImagem = "/Imagens/Calcados/calcado4.png",
                            ProdutoNome = "Tênis Hummel Coloridos",
                            ProdutoPreco = 120m,
                            ProdutoQuantidade = 120
                        },
                        new
                        {
                            ProdutoId = 22,
                            CategoriaId = 4,
                            ProdutoDescricao = "Tênis Nike vermelho - disponível na maioria dos tamanhos",
                            ProdutoImagem = "/Imagens/Calcados/calcado5.png",
                            ProdutoNome = "Tênis Nike Vermelho",
                            ProdutoPreco = 200m,
                            ProdutoQuantidade = 100
                        },
                        new
                        {
                            ProdutoId = 23,
                            CategoriaId = 4,
                            ProdutoDescricao = "Sandálias Birkenstock - disponíveis na maioria dos tamanhos",
                            ProdutoImagem = "/Imagens/Calcados/calcado6.png",
                            ProdutoNome = "Sandálidas Birkenstock",
                            ProdutoPreco = 50m,
                            ProdutoQuantidade = 150
                        });
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            UsuarioNome = "Weslei"
                        },
                        new
                        {
                            UsuarioId = 2,
                            UsuarioNome = "Janice"
                        });
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Carrinho", b =>
                {
                    b.HasOne("WS.VirtualStore.Api.Entities.Usuario", null)
                        .WithOne("Carrinho")
                        .HasForeignKey("WS.VirtualStore.Api.Entities.Carrinho", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.CarrinhoItem", b =>
                {
                    b.HasOne("WS.VirtualStore.Api.Entities.Carrinho", "Carrinho")
                        .WithMany("CarrinhoItems")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WS.VirtualStore.Api.Entities.Produto", "Produto")
                        .WithMany("CarrinhoItems")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Produto", b =>
                {
                    b.HasOne("WS.VirtualStore.Api.Entities.Categoria", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Carrinho", b =>
                {
                    b.Navigation("CarrinhoItems");
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Produto", b =>
                {
                    b.Navigation("CarrinhoItems");
                });

            modelBuilder.Entity("WS.VirtualStore.Api.Entities.Usuario", b =>
                {
                    b.Navigation("Carrinho");
                });
#pragma warning restore 612, 618
        }
    }
}
