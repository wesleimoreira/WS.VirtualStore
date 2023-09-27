using Microsoft.EntityFrameworkCore;
using WS.VirtualStore.Api.Entities;

namespace WS.VirtualStore.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public  DbSet<Carrinho>? Carrinhos { get; set; }
        public  DbSet<CarrinhoItem>? CarrinhoItems { get; set; }
        public  DbSet<Produto> Produtos => Set<Produto>();
        public  DbSet<Categoria>? Categorias { get; set; }
        public  DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuários
            modelBuilder.Entity<Usuario>().HasData(data: new Usuario
            {
                UsuarioId = 1,
                UsuarioNome = "Weslei"
            });           
           
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                UsuarioId = 2,
                UsuarioNome = "Janice"

            });

            //Categorias
            modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            {
                CarrinhoId = 1,
                UsuarioId = 1

            });
            modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            {
                CarrinhoId = 2,
                UsuarioId = 2

            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = 1,
                CategoriaNome = "Beleza",
                CategoriaIcone = "fas fa-spa"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = 2,
                CategoriaNome = "Moveis",
                CategoriaIcone = "fas fa-couch"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = 3,
                CategoriaNome = "Eletronicos",
                CategoriaIcone = "fas fa-headphones"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = 4,
                CategoriaNome = "Calcados",
                CategoriaIcone = "fas fa-shoe-prints"
            });

            /// Produtos
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 1,
                ProdutoNome = "Glossier - Beleza Kit",
                ProdutoDescricao = "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele",
                ProdutoImagem = "/Imagens/Beleza/Beleza1.png",
                ProdutoPreco = 100,
                ProdutoQuantidade = 100,
                CategoriaId = 1

            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 2,
                ProdutoNome = "Curology - Kit para Pele",
                ProdutoDescricao = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                ProdutoImagem = "/Imagens/Beleza/Beleza2.png",
                ProdutoPreco = 50,
                ProdutoQuantidade = 45,
                CategoriaId = 1

            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 3,
                ProdutoNome = "Óleo de Coco Orgânico",
                ProdutoDescricao = "Um kit fornecido pela Glossier, contendo produtos para cuidados com a pele",
                ProdutoImagem = "/Imagens/Beleza/Beleza3.png",
                ProdutoPreco = 20,
                ProdutoQuantidade = 30,
                CategoriaId = 1

            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 4,
                ProdutoNome = "Schwarzkopf - Kit de cuidados com a pele e cabelo",
                ProdutoDescricao = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                ProdutoImagem = "/Imagens/Beleza/Beleza4.png",
                ProdutoPreco = 50,
                ProdutoQuantidade = 60,
                CategoriaId = 1

            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 5,
                ProdutoNome = "Kit de cuidados com a pele",
                ProdutoDescricao = "Kit de cuidados com a pele, contendo produtos para cuidados com a pele e cabelos",
                ProdutoImagem = "/Imagens/Beleza/Beleza5.png",
                ProdutoPreco = 30,
                ProdutoQuantidade = 85,
                CategoriaId = 1

            });
           
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 6,
                ProdutoNome = "Fones de ouvidos",
                ProdutoDescricao = "Air Pods - fones de ouvido sem fio intra-auriculares",
                ProdutoImagem = "/Imagens/Eletronicos/eletronico1.png",
                ProdutoPreco = 100,
                ProdutoQuantidade = 120,
                CategoriaId = 3

            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 7,
                ProdutoNome = "Fones de ouvido dourados",
                ProdutoDescricao = "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio",
                ProdutoImagem = "/Imagens/Eletronicos/eletronico2.png",
                ProdutoPreco = 40,
                ProdutoQuantidade = 200,
                CategoriaId = 3

            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 8,
                ProdutoNome = "Fones de ouvido pretos",
                ProdutoDescricao = "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio",
                ProdutoImagem = "/Imagens/Eletronicos/eletronico3.png",
                ProdutoPreco = 40,
                ProdutoQuantidade = 300,
                CategoriaId = 3

            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 9,
                ProdutoNome = "Câmera digital Sennheiser com tripé",
                ProdutoDescricao = "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé",
                ProdutoImagem = "/Imagens/Eletronicos/eletronico4.png",
                ProdutoPreco = 600,
                ProdutoQuantidade = 20,
                CategoriaId = 3

            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 10,
                ProdutoNome = "Câmera Digital Canon",
                ProdutoDescricao = "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon",
                ProdutoImagem = "/Imagens/Eletronicos/eletronico5.png",
                ProdutoPreco = 500,
                ProdutoQuantidade = 15,
                CategoriaId = 3

            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 11,
                ProdutoNome = "Nintendo Gameboy",
                ProdutoDescricao = "Gameboy - Fornecido por Nintendo",
                ProdutoImagem = "/Imagens/Eletronicos/tecnologia6.png",
                ProdutoPreco = 100,
                ProdutoQuantidade = 60,
                CategoriaId = 3
            });
        
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 12,
                ProdutoNome = "Cadeira de escritório de couro preto",
                ProdutoDescricao = "Cadeira de escritório em couro preto muito confortável",
                ProdutoImagem = "/Imagens/Moveis/moveis1.png",
                ProdutoPreco = 50,
                ProdutoQuantidade = 212,
                CategoriaId = 2
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 13,
                ProdutoNome = "Cadeira de escritório de couro rosa",
                ProdutoDescricao = "Cadeira de escritório em couro rosa muito confortável",
                ProdutoImagem = "/Imagens/Moveis/moveis2.png",
                ProdutoPreco = 50,
                ProdutoQuantidade = 112,
                CategoriaId = 2
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 14,
                ProdutoNome = "Espreguiçadeira",
                ProdutoDescricao = "Poltrona muito confortável",
                ProdutoImagem = "/Imagens/Moveis/moveis3.png",
                ProdutoPreco = 70,
                ProdutoQuantidade = 90,
                CategoriaId = 2
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 15,
                ProdutoNome = "Silver Lounge Chair",
                ProdutoDescricao = "Poltrona prateada muito confortável",
                ProdutoImagem = "/Imagens/Moveis/moveis4.png",
                ProdutoPreco = 120,
                ProdutoQuantidade = 95,
                CategoriaId = 2
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 16,
                ProdutoNome = "Luminária de mesa de porcelana",
                ProdutoDescricao = "Abajur de mesa de porcelana branco e azul",
                ProdutoImagem = "/Imagens/Moveis/moveis6.png",
                ProdutoPreco = 15,
                ProdutoQuantidade = 100,
                CategoriaId = 2
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 17,
                ProdutoNome = "Office Table Lamp",
                ProdutoDescricao = "Abajur de mesa de escritório",
                ProdutoImagem = "/Imagens/Moveis/moveis7.png",
                ProdutoPreco = 20,
                ProdutoQuantidade = 73,
                CategoriaId = 2
            });
        

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 18,
                ProdutoNome = "Tênis Puma",
                ProdutoDescricao = "Tênis Puma confortáveis na maioria dos tamanhos",
                ProdutoImagem = "/Imagens/Calcados/calcado1.png",
                ProdutoPreco = 100,
                ProdutoQuantidade = 50,
                CategoriaId = 4
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 19,
                ProdutoNome = "Tênis Colodiros",
                ProdutoDescricao = "Tênis coloridos - disponíveis na maioria dos tamanhos",
                ProdutoImagem = "/Imagens/Calcados/calcado2.png",
                ProdutoPreco = 150,
                ProdutoQuantidade = 60,
                CategoriaId = 4
            });

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 20,
                ProdutoNome = "Tênis Nike Azul",
                ProdutoDescricao = "Tênis Nike azul - disponível na maioria dos tamanhos",
                ProdutoImagem = "/Imagens/Calcados/calcado3.png",
                ProdutoPreco = 200,
                ProdutoQuantidade = 70,
                CategoriaId = 4
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 21,
                ProdutoNome = "Tênis Hummel Coloridos",
                ProdutoDescricao = "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos",
                ProdutoImagem = "/Imagens/Calcados/calcado4.png",
                ProdutoPreco = 120,
                ProdutoQuantidade = 120,
                CategoriaId = 4
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 22,
                ProdutoNome = "Tênis Nike Vermelho",
                ProdutoDescricao = "Tênis Nike vermelho - disponível na maioria dos tamanhos",
                ProdutoImagem = "/Imagens/Calcados/calcado5.png",
                ProdutoPreco = 200,
                ProdutoQuantidade = 100,
                CategoriaId = 4
            }); 

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 23,
                ProdutoNome = "Sandálidas Birkenstock",
                ProdutoDescricao = "Sandálias Birkenstock - disponíveis na maioria dos tamanhos",
                ProdutoImagem = "/Imagens/Calcados/calcado6.png",
                ProdutoPreco = 50,
                ProdutoQuantidade = 150,
                CategoriaId = 4
            });            
        }
    }
}
