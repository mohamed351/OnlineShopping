using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Implementation
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) :
            base(context)
        {
        }
    }
}
