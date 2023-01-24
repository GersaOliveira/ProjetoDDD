using System.Collections.Generic;
using System.Linq;
using Produtos.Domain.DTOs;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Infra.Context;

namespace Produtos.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        

        public void PostProdItem(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public TEntity GetProdutos(int id)
        {
             var produto =  _context.Set<TEntity>().Find(id);

            if (produto == null)
                return null;

            return produto;
        }

        public IEnumerable<TEntity> GetTodoProdutos()
        {
           var query = _context.Set<TEntity>();

            if(query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            var produto = _context.Set<TEntity>();


                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
            

        }

        public void Save(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void PutProduto(TEntity entity)
        {

            var produto  =  _context.Set<TEntity>().Find(entity.Id);        
                produto = entity;
                _context.Update(produto);
                 _context.SaveChanges();

        }
    }
}