using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Interfaces
{
   public interface IProductRepository:IRepository<Product,int>
    {
    }
}
