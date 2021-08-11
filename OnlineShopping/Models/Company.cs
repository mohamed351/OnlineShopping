using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class Company
    {
        public Company()
        {
            this.Products = new HashSet<Product>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public string ArabicName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
