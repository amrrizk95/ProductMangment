using ProductMangment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMangment
{
   public interface IUnitOfWork:IDisposable
    {
    
        IProductRepository ProductRepository  { get;  }

        void Complete();
    }
}
