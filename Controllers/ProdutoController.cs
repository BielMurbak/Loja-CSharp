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
    public IActionResult Get()
    {
        
        try{List<Produto> produtos = _produtoService.Listar();
        
        List<ProdutoResponseDto> resposta = produtos.Select(produto => new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco

        }).ToList();
        
        return Ok(resposta);

        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Ocorreu um erro ao listar");


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Ocorreu um erro interno no servidor.");

        }
    }   

    [HttpGet("{id}")]

    public IActionResult GetId(int id)
    {
        Produto? resultado = _produtoService.BuscarPorId(id);

        if (resultado == null)
        {
            return NotFound("Produto nao encontrado");
        }
        return Ok(resultado);
    }

    [HttpPost]
    public IActionResult Post(ProdutoCreateDto dto)
    {
        Produto produto = new Produto()
        {
            Nome = dto.Nome,
            Preco = dto.Preco

        };
        try
        {
            Produto resultado = _produtoService.Cadastrar(produto);
            ProdutoResponseDto resposta = new ProdutoResponseDto()
            {
            Id = resultado.Id,
            Nome = resultado.Nome,
            Preco = resultado.Preco

            };
            return Ok(resposta);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Ocorreu um erro ao processar os dados do produto.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Ocorreu um erro interno no servidor.");
        }
        
    }   

    [HttpPut("{id}")]
    public IActionResult Put(int id, ProdutoUpdateDto dto)
    {
        Produto produto = new Produto()
        {
            Nome = dto.Nome,
            Preco = dto.Preco
        };

        Produto? resultado = _produtoService.Alterar(id, produto);

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
    public IActionResult Delete(int id)
    {
        bool resultado = _produtoService.Apagar(id);

        if(!resultado)
        {
            return NotFound("Produto não encontrado.");
        }

        return NoContent();

    }
}