using OnlineShopping.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public ICategoryRepository Categories { get;  }
        public ICompanyRepository Companies { get; }
        public IQuantityTypeRepository QuantityTypes { get;  }
        int Completed();
        
    }
}
