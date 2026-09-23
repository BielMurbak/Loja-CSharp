using Microsoft.AspNetCore.Http.HttpResults;
using MinhaApi.Entities;

namespace MinhaApi.Repositories

{
    public class ProdutoRepository
    {
        
        private static readonly List<Produto> _produtos = new List<Produto>
        {
            new Produto {
                Id = 1,
                Nome = "Teclado",
                Preco = 150m
            },

            new Produto {
                Id = 2,
                Nome = "Mouse",
                Preco = 50m
            }
        };

        public int Tamanho()
        {
            return _produtos.Count;
        }

        public List<Produto> Listar()
        {
            return _produtos;
        }

        public Produto? BuscarPorId(int id)
        {
            return _produtos.FirstOrDefault(produto => produto.Id == id);
        }

        public Produto Cadastrar(Produto produto)
        {
            _produtos.Add(produto);
            return produto;
        }

        public Produto? Alterar(int id, Produto novoProduto)
        {
            Produto? produtoExistente = _produtos.FirstOrDefault(produto => produto.Id == id);

        if (produtoExistente == null)
        {
            return null;
        }

        produtoExistente.Nome = novoProduto.Nome;
        produtoExistente.Preco = novoProduto.Preco;

        return produtoExistente;
        }

        public bool Apagar(int id)
        {
            Produto? produto = _produtos.FirstOrDefault(produto => produto.Id == id);

            if (produto == null)
            {
                return false;
            }

            _produtos.Remove(produto);
            return true;
        }
    }
}


















