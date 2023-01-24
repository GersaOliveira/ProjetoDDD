using System.Collections.Generic;
using System.Linq;
using Produtos.Domain.DTOs;
using Produtos.Domain.Interfaces;

namespace Produtos.Domain.Models
{
    public class Produtoservice
    {
        private readonly IRepository<Produto> _ProdutoRepository;

        public Produtoservice(IRepository<Produto> ProdutoRepository)
        {
            _ProdutoRepository = ProdutoRepository;
        }

        public void Create(ProdutoCreateDTO produto)
        {
            var Produto = _ProdutoRepository.GetProdutos(produto.Id);

            if(Produto == null)
            {
                Produto = new Produto(produto);
                _ProdutoRepository.PostProdItem(Produto);
            }
            else
                _ProdutoRepository.PutProduto(Produto);
        }

        public void Delete(Produto id)
        {
             _ProdutoRepository.Delete(id);            
        }

        public void PutProduto(Produto produto)
        {
             _ProdutoRepository.PutProduto(produto);            
        }

         public void Get(int id)
        {
             _ProdutoRepository.GetProdutos(id);            
        }

        public IEnumerable<Produto> GetAll()
        {
            var retorno =  _ProdutoRepository.GetTodoProdutos();

           return  retorno.Where(x => x.Status == true).ToList();            
        }
        
    }
}