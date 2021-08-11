using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public QuantityType QuantityType { get; set; }
        [ForeignKey(nameof(QuantityType))]
        public int QuantityTypeID { get; set; }

        public Category Category { get; set; }
        [ForeignKey(nameof(Category))]
        public int CateogryID { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public Company Company { get; set; }


        public int ProductSizeID { get; set; }
        public ProductSize ProductSize  { get; set; }

        public string Description { get; set; }


        public string ImageURL { get; set; }
        public bool IsDeleted { get; set; }
       


    }
   

}
