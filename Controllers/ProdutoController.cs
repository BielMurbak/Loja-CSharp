using Microsoft.AspNetCore.Mvc;
using MinhaApi.Entities;
using MinhaApi.Services;
using MinhaApi.Dtos;

namespace MinhaApi.Controllers;

[ApiController]
[Route("produtos")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Produto> produtos = await _produtoService.Listar();

        List<ProdutoResponseDto> resposta = produtos.Select(produto => new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco

        }).ToList();

        return Ok(resposta);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(int id)
    {
        Produto? resultado = await _produtoService.BuscarPorId(id);

        if (resultado == null)
        {
            return NotFound("Produto não encontrado.");
        }

        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoCreateDto dto)
    {
        Produto produto = new Produto()
        {
            Nome = dto.Nome,
            Preco = dto.Preco

        };

        Produto resultado = await _produtoService.Cadastrar(produto);

        ProdutoResponseDto resposta = new ProdutoResponseDto()
        {
            Id = resultado.Id,
            Nome = resultado.Nome,
            Preco = resultado.Preco

        };

        return Ok(resposta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ProdutoUpdateDto dto)
    {
        Produto produto = new Produto()
        {
            Nome = dto.Nome,
            Preco = dto.Preco
        };

        Produto? resultado = await _produtoService.Alterar(id, produto);

        if (resultado == null)
        {
            return NotFound("Produto nao encontrado");
        }

        ProdutoResponseDto resposta = new ProdutoResponseDto()
        {
            Nome = resultado.Nome,
            Preco = resultado.Preco
        };

        return Ok(resposta);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool resultado = await _produtoService.Apagar(id);

        if (!resultado)
        {
            return NotFound("Produto não encontrado.");
        }

        return NoContent();
    }
}