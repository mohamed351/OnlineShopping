using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Implementation
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }

       

        public  DataTableViewModel<ProductSelectViewModel> GetDataTableProduct(int start = 0, int lenght = 10, Func<Product, bool> search = null, Func<Product, int> OrderBy = null)
        {
             var query = _context.Set<Product>().Include(a=>a.Category)
                .Include(a=>a.Company)
                .Include(a=>a.QuantityType)
                .Where(search)
                  .OrderBy(OrderBy).Skip(start)
                  .Take(lenght);
            ///Get the Total Count 
            var count = _context.Set<Product>().Where(search).Count();
            ///Return The ViewModel That DataTable will take it in Json 
            return new DataTableViewModel<ProductSelectViewModel>()
            {
                data = query.Select(a=> new ProductSelectViewModel { Company = a.Company.Name,
                    Name = a.Name, 
                    ID = a.ID, Price = a.Price,
                    Quantity = a.Quantity,
                    QuantityType = a.QuantityType.Name ,
                  Category = a.Category.Name}),
                recordsFiltered = count,
                recordsTotal = count
            };
        }
        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;

        }
    }
    public class ProductSelectViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Company { get; set; }
        public string QuantityType { get; set; }
        public string Category { get; set; }
    }


}
