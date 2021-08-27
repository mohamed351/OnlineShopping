using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.DTO
{
    public class ProductCategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CateogryID { get; set; }
        public string Image { get; set; }
    }
}
