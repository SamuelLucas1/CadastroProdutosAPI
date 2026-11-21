using CadastroProdutos.Models;

namespace CadastroProdutos.Services.Contracts
{
    public interface IProduct
    {
        public List<Produto> GetAll();
        public Produto? GetById(int id);
        public void Create(Produto produtoNovo);
        public bool Update(int id, Produto produtoAtualizado);
        public bool Delete(int id);
    }
}