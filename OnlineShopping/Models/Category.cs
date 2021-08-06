using System.Collections.Generic;

namespace OnlineShopping.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }

    }
   

}
