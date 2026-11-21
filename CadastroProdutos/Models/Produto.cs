using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo Quantidade em Estoque não pode ser negativo.")]
        public int QuantidadeEstoque { get; set; }
    }
}   