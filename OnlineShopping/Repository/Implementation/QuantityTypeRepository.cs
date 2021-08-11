using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Implementation
{
    public class QuantityTypeRepository : Repository<QuantityType, int> , IQuantityTypeRepository
    {
        public QuantityTypeRepository(DbContext context) :
            base(context)
        {
        }
    }
}
