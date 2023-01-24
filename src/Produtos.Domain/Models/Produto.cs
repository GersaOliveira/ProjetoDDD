using System;
using Produtos.Domain.DTOs;

namespace Produtos.Domain.Models
{
    public class Produto : BaseEntity
    {
        public Produto()
        {

        }
        public Produto(ProdutoCreateDTO produto)
        {
            ValidaCategoria(produto);
            CodProd = produto.CodProd;
            DescrProd = produto.DescFornecedor;
            Valor = produto.Valor;
            Status =produto.Status;
            DataFabricacao = produto.DataFabricacao;
            DataValidade = produto.DataValidade;
            CodFornecedor = produto.CodFornecedor;
            DescFornecedor = produto.DescFornecedor;
            CNPJFornecedor = produto.CNPJFornecedor;

        }

        public string CodProd { get; set; }
        public string DescrProd { get; set; }
        public int Valor { get; set; }
        public bool Status { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodFornecedor { get; set; }    
        public string DescFornecedor { get; set; }   
        public string CNPJFornecedor { get; set; }

        public void Update(ProdutoCreateDTO produto)
        {
           ValidaCategoria(produto);
        }
        private void ValidaCategoria(ProdutoCreateDTO produto)
        {
            if(string.IsNullOrEmpty(produto.DescrProd))
               throw new InvalidOperationException("O nome é inválido");

            if(string.IsNullOrEmpty(produto.CNPJFornecedor))
               throw new InvalidOperationException("O email é inválido");
        }
    }
}