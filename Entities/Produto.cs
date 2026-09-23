namespace MinhaApi.Entities;
using System.ComponentModel.DataAnnotations;

public class Produto
{
    public int Id {get; set;}

    public string Nome {get; set;} = string.Empty;

    public decimal Preco {get; set;}

}