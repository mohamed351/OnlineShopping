using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();

        public IQueryable<TEntity> GetIQueryable();

        public IEnumerable<TEntity> GetByCondition(Func<TEntity, bool> search);

        public TEntity GetByID(TKey Key);

        public void Add(TEntity entity);

        public void Edit(TEntity entity);

        public void Delete(TEntity entity);

        public DataTableViewModel<TEntity> GetDataTable(int start, int lenght, Func<TEntity, bool> search, Func<TEntity, TKey> OrderBy);
        public TEntity GetByIDWithAsNoTracking(Func<TEntity, bool> func);

    }

    /// <summary>
    /// DataTable ViewModel i didn't use Naming Convention in this class because they what their own name
    /// </summary>
    /// <typeparam name="T">The class that will apply on Data Table</typeparam>
    public class DataTableViewModel<T> where T : class
    {
        /// <summary>
        /// The Data whether the Model or Brand , etc
        /// That class is  generic
        /// </summary>
        public IEnumerable<T> data { get; set; }
        /// <summary>
        /// The Total Number of Filtered Records 
        /// </summary>
        public int recordsFiltered { get; set; }
        /// <summary>
        /// The Total Number of Records
        /// </summary>
        public int recordsTotal { get; set; }

    }
}
