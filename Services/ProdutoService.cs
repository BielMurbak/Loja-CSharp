using MinhaApi.Entities;
using MinhaApi.Repositories;

namespace MinhaApi.Services;

public class ProdutoService
{   

    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> Cadastrar(Produto produto)
    {
        return await _produtoRepository.Cadastrar(produto);
    } 

    public async Task<List<Produto>> Listar(){

        return await _produtoRepository.Listar();

    }

    public async Task<Produto?> BuscarPorId (int id)
    {
        return await _produtoRepository.BuscarPorId(id);
    }

    public async Task<Produto?> Alterar(int id, Produto novoProduto)
    {
        
        return await _produtoRepository.Alterar(id, novoProduto);

    }

    public async Task<bool> Apagar(int id)
    {
        return await _produtoRepository.Apagar(id);
    }

}