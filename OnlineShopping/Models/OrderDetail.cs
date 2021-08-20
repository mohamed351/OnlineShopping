using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }


    }
}
