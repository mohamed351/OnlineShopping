using OnlineShopping.Models;
using OnlineShopping.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Interfaces
{
   public interface IProductRepository:IRepository<Product,int>
    {
        DataTableViewModel<ProductSelectViewModel> GetDataTableProduct(int start = 0, int lenght = 10, Func<Product, bool> search = null, Func<Product, int> OrderBy = null);
    }
}
