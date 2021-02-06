using Microsoft.AspNetCore.Cors;
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
        [EnableCors("AllowCors")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var data =  ProductVM.getAll(UnitOfWork);
            return data;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [Route("/api/Product")]
        [EnableCors("AllowCors")]

        public Product Get(int id)
        {
            var data = ProductVM.get(UnitOfWork, id);
            return data;
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("/api/Product")]
        [EnableCors("AllowCors")]
        public string Post([FromForm]ProductVM productVM)
        {
            var data = ProductVM.AddNew(UnitOfWork, productVM);
            // upload photo here
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
        [HttpPut]
        [Route("/api/Product")]
        [EnableCors("AllowCors")]
        public string Put([FromForm]ProductVM productVM)
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
        [EnableCors("AllowCors")]
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
