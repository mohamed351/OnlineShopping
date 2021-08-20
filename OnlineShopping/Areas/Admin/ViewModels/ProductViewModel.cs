using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
       
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

      

        public int QuantityTypeID { get; set; }

    
        public int CateogryID { get; set; }

   
        public int CompanyID { get; set; }
       


        public int? ProductSizeID { get; set; }
      

        public string Description { get; set; }


        public string ImageBase64 { get; set; }
       



    }

    public class ProductEditViewModel:ProductViewModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }





    }
}
