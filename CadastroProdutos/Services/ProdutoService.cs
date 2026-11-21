using CadastroProdutos.Models;
using CadastroProdutos.Services.Contracts;

namespace CadastroProdutos.Services
{
    public class ProdutoService : IProduct
    {
        public static List<Produto> produtos = new List<Produto>()
        {
            new Produto { Id = 1, Nome = "Teclado IYX 68 MU PRO", Preco = 1000.00m, QuantidadeEstoque = 100 },
            new Produto { Id = 2, Nome = "Placa de Video: RTX 5090", Preco = 12000.00m, QuantidadeEstoque = 50 },
        };

        public List<Produto> GetAll()
        {
            return produtos;
        }

        public Produto? GetById(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Produto produtoNovo)
        {
            produtos.Add(produtoNovo);
        }

        public bool Update(int id, Produto produtoAtualizado)
        {
            var produtoExistente = produtos.FirstOrDefault(p => p.Id == id);

            if (produtoExistente is null)
            {
                return false;
            }

            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.QuantidadeEstoque = produtoAtualizado.QuantidadeEstoque;

            return true;
        }

        public bool Delete(int id)
        {
            var produtoExistente = produtos.FirstOrDefault(p => p.Id == id);

            if (produtoExistente is null)
            {
                return false;
            }

            produtos.Remove(produtoExistente);

            return true;
        }
    }
}