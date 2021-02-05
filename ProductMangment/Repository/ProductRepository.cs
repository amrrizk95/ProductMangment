
using ProductMangment;
using ProductMangment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMangment
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
                
        }
    }
}
