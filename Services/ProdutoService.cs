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
        
        return _produtoRepository.Alterar(id, novoProduto);

    }

    public bool Apagar(int id)
    {
        return _produtoRepository.Apagar(id);
    }

}