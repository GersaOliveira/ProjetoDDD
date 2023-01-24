using System;
using System.ComponentModel.DataAnnotations;
using Produtos.Domain.Models;

namespace Produtos.Domain.DTOs
{
    public class ProdutoCreateDTO : BaseEntity
    {
         public string CodProd { get; set; }
        public string DescrProd { get; set; }
        public int Valor { get; set; }
        public bool Status { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodFornecedor { get; set; }    
        public string DescFornecedor { get; set; }   
        public string CNPJFornecedor { get; set; }
    }
}