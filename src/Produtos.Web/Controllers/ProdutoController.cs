using System.Collections.Generic;
using System.Linq;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Produtos.Domain.DTOs;

namespace Produtos.Web.Controllers
{
     [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly Produtoservice _Produtoservice;
        private readonly IRepository<Produto> _ProdutoRepository;

        public ProdutoController(Produtoservice Produtoservice,
            IRepository<Produto> ProdutoRepository)
        {
            _Produtoservice = Produtoservice;
            _ProdutoRepository = ProdutoRepository;
        }

         [HttpGet]
         public IEnumerable<Produto> GetProdutos()
         {
             return  _Produtoservice.GetAll();            
         }


         [HttpGet("{id}")]
         public  ActionResult<Produto> GetProdutos(int id)
         {
             var Produto =  _ProdutoRepository.GetProdutos(id);
             if (Produto == null)
             {
                 return NotFound(new { message = $"Produto de id={id} não encontrado" });
             }
             return Produto;
         }

        [HttpDelete("{id}")]
        public  void Delet([FromBody] Produto produto)
        {
            produto.Status = false;
             _Produtoservice.Delete(produto);

         }

        [HttpPost]
        public void PostProdItem([FromBody] ProdutoCreateDTO ProdutoDTO)
        {
             _Produtoservice.Create(ProdutoDTO);

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProdutoCreateDTO produtoDTO)
        {
              produtoDTO.Id = id;
             _Produtoservice.PutProduto(new Produto(produtoDTO));

        }
    }
}