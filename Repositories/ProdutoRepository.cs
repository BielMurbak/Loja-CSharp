using MinhaApi.Entities;
using MinhaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MinhaApi.Repositories;


    public class ProdutoRepository : IProdutoRepository
    {
        
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> Listar()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> BuscarPorId(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(produto => produto.Id == id);
        }

        public async Task<Produto> Cadastrar(Produto produto)
        {   
            _context.Produtos.Add(produto);

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto?> Alterar(int id, Produto novoProduto)
        {
            Produto? produtoExistente = await _context.Produtos.FirstOrDefaultAsync(produto => produto.Id == id);

            if (produtoExistente == null)
            {
                return null;
            }

            produtoExistente.Nome = novoProduto.Nome;
            produtoExistente.Preco = novoProduto.Preco;

            await _context.SaveChangesAsync();

            return produtoExistente;
        }

        public async Task<bool> Apagar(int id)
        {
            Produto? produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.Id == id);

            if (produto == null)
            {
                return false;
            }

            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();

            return true;
        }
    }



















