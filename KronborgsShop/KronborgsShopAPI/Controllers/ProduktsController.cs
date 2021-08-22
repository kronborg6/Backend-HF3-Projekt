using KronborgsSHopCL;
using KronborgsShopORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KronborgsShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduktsController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public ProduktsController()
        {
            ORM = new ORM_MsSql();
        }


        
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product;

            try
            {
                product = ORM.GetProduct(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (product == null) return NotFound();

            // 200 ok 
            return Ok(product);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            List<Product> products = new();

            try
            {
                products = ORM.GetProducts();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            //if (products.Count < 1) return NotFound();

            return products;
        }
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            ORM.CreateProduct(product);
            return product;
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Product product;

            try
            {
                product = ORM.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (product == null) return NotFound();

            // 200 ok 
            return Ok();
        }
    }
}
