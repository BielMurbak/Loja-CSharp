using MinhaApi.Entities;

namespace MinhaApi.Repositories;

    public interface IProdutoRepository
    {
    Task<List<Produto>> Listar();
    Task<Produto?> BuscarPorId(int id);
    Task<Produto> Cadastrar(Produto produto);
    Task<Produto?> Alterar(int id, Produto novoProduto);
    Task<bool> Apagar(int id);
    }