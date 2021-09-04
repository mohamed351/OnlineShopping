using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.DTO
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
