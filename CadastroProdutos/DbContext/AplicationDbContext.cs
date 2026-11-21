using CadastroProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.DbContext
{
    public class AplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}