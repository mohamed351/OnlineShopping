using Microsoft.EntityFrameworkCore;
using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Implementation
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public virtual void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual TEntity GetByID(TKey Key)
        {
            return _context.Find<TEntity>(Key);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> GetByCondition(Func<TEntity, bool> search)
        {
            return _context.Set<TEntity>().Where(search);
        }

        public virtual DataTableViewModel<TEntity> GetDataTable(int start = 0, int lenght = 10, Func<TEntity, bool> search = null, Func<TEntity, TKey> OrderBy = null)
        {
            ///query the skip number of Rows and Take number of rows 
            ///Like Take and Fetch 
            var query = _context.Set<TEntity>().Where(search)
                   .OrderBy(OrderBy).Skip(start)
                   .Take(lenght);
            ///Get the Total Count 
            var count = _context.Set<TEntity>().Where(search).Count();
            ///Return The ViewModel That DataTable will take it in Json 
            return new DataTableViewModel<TEntity>()
            {
                data = query,
                recordsFiltered = count,
                recordsTotal = count
            };
        }

        public virtual IQueryable<TEntity> GetIQueryable()
        {
            return _context.Set<TEntity>();
        }


    }
}
