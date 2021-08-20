using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{

    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int InvoiceNumber { get; set; }
        public UserOrderType OrderType { get; set; }
        public bool IsCancelled { get; set; }
        public AppUser AppUser { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int AppUserID { get; set; }


    }
}
