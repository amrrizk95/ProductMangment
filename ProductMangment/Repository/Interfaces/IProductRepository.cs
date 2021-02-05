
using ProductMangment;
using ProductMangment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMangment
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
