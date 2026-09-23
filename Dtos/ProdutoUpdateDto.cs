using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Dtos

{
    public class ProdutoUpdateDto
    {
        [Required]
        public string Nome {get; set;} = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Preco {get; set;}
    }
}