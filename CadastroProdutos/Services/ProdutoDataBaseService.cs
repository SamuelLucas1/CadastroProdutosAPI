using CadastroProdutos.Models;
using CadastroProdutos.Services.Contracts;

namespace CadastroProdutos.Services
{
    public class ProdutoDataBaseService : IProduct
    {
        private readonly DbContext.AplicationDbContext _context;

        public ProdutoDataBaseService(DbContext.AplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Produto produtoNovo)
        {
           ValidateProduto(produtoNovo);
           _context.Produtos.Add(produtoNovo);
           _context.SaveChanges();
        }

        public bool Delete(int id)
        {
           var produto = _context.Produtos.Find(id);

           if (produto is null) return false;

           _context.Produtos.Remove(produto);
           _context.SaveChanges();

            return true;
        }

        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto? GetById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public bool Update(int id, Produto produtoAtualizado)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null) return false;

            ValidateProduto(produtoAtualizado);
            _context.Produtos.Update(produtoAtualizado);
            _context.SaveChanges();

            return true;
        }

        public void ValidateProduto(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new ArgumentException("O nome do produto não pode ser vazio.");
            }
            if(produto.Nome == "Produto 1")
            {
                throw new ArgumentException("O nome do produto não pode ser 'Produto 1'.");
            }
            if (produto.Preco < 0)
            {
                throw new ArgumentException("O preço do produto não pode ser negativo.");
            }
            if (produto.QuantidadeEstoque <= 0)
            {
                throw new ArgumentException("A quantidade em estoque não pode ser zero ou negativa.");
            }
        }
    }
}