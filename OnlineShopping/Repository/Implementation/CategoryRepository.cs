using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Repository.Implementation
{
    public class CategoryRepository:Repository<Category,int>, ICategoryRepository
    {
        public CategoryRepository(DbContext context)
            :base(context)
        {

        }
        public override void Delete(Category entity)
        {
            entity.IsDeleted = true;
        }

    }
}
