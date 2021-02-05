using Microsoft.AspNetCore.Mvc;
using ProductMangment.Model;
using ProductMangment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMangment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        public ProductController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("/api/Product/all")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var data =  ProductVM.getAll(UnitOfWork);
            return data;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("/api/Product")]
        public string Post(ProductVM productVM)
        {
            var data = ProductVM.AddNew(UnitOfWork, productVM);
            if (data)
            {
                return "Data Saved";
            }
            else
            {
                return "There is error";
            }
          
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [Route("/api/Product")]
        public string Put(ProductVM productVM)
        {
            
            var data = ProductVM.Edit(UnitOfWork, productVM);
            if (data)
            {
                return "Data Saved";
            }
            else
            {
                return "There is error";
            }
        }

        // DELETE api/<ProductController>/5
        [Route("/api/Product")]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var data = ProductVM.Remove(UnitOfWork, id);
            if (data)
            {
                return "Data Saved";
            }
            else
            {
                return "There is error";
            }
        }
    }
}
