using Microsoft.VisualBasic;
using MinhaApi.Entities;
using MinhaApi.Repositories;

namespace MinhaApi.Services;

public class ProdutoService
{   

    private readonly ProdutoRepository _produtoRepository;

    public ProdutoService(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }


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

    public Produto Cadastrar(Produto produto)
    {
        produto.Id = _produtoRepository.Tamanho() + 1;
        return _produtoRepository.Cadastrar(produto);
    } 

    public List<Produto> Listar(){

        return _produtoRepository.Listar();

    }

    public Produto? BuscarPorId (int id)
    {
        return _produtoRepository.BuscarPorId(id);
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