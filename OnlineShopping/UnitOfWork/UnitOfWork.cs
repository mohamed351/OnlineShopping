using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Repository.Implementation;
using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            this.Categories = new CategoryRepository(context);
        }
        public ICategoryRepository Categories { get; set; }

        public int Completed()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
