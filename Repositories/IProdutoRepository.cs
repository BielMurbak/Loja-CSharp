using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhaApi.Entities;

namespace MinhaApi.Repositories;

    public interface IProdutoRepository
    {
    List<Produto> Listar();
    Produto? BuscarPorId(int id);
    Produto Cadastrar(Produto produto);
    Produto? Alterar(int id, Produto novoProduto);
    bool Apagar(int id);
    }