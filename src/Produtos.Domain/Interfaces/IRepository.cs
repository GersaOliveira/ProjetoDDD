using System.Collections.Generic;
using System.Threading.Tasks;
using Produtos.Domain.DTOs;

namespace Produtos.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
         TEntity GetProdutos(int id);
         IEnumerable<TEntity> GetTodoProdutos();
         void Save(TEntity entity);
         void PostProdItem(TEntity entity); 
         void PutProduto(TEntity entity);
         void Delete(TEntity id);
    }
}