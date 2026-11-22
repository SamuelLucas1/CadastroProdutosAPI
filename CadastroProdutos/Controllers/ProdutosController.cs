using Microsoft.AspNetCore.Http;
using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CadastroProdutos.Services.Contracts;

namespace CadastroProdutos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProduct _productService;

        public ProdutosController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = _productService.GetById(id);

            if (produto is null)
            {
                return NotFound($"Produto com ID '{id}' não encontrado.");
            }

            return Ok(produto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Produto> Create(Produto produtoNovo)
        {
            try
            {
                _productService.Create(produtoNovo);
                return Created();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Produto produtoAtualizado)
        {
            try
            {
                var atualizado = _productService.Update(id, produtoAtualizado);

                if (!atualizado)
                    return NotFound($"Produto com ID '{id}' não encontrado.");

                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var produtoExistente = _productService.GetById(id);

            if (produtoExistente is null)
            {
                return NotFound($"Produto com ID '{id}' não encontrado.");
            }

            _productService.Delete(id);

            return NoContent();
        }
    }
}