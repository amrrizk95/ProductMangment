

using ProductMangment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMangment
{
  public  class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _dbContext;
        public UnitOfWork(ProductContext dbContext)
        {
            _dbContext = new ProductContext();
        }

         IProductRepository productRepository ;



        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    return new ProductRepository(_dbContext);
                else
                    return productRepository;
            }
        }




        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Complete()
        {
            _dbContext.SaveChanges();
        }
    }
}
