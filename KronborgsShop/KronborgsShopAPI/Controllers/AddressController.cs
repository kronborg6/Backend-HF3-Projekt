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
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public AddressController()
        {
            ORM = new ORM_MsSql();
        }
        [HttpGet("{id}")]
        public ActionResult<Address> Get(int id)
        {
            Address address;

            try
            {
                address = ORM.GetAddress(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (address == null) return NotFound();

            // 200 ok 
            return Ok(address);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            List<Address> addresses = new();

            try
            {
                addresses = ORM.GetAddresses();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            //if (products.Count < 1) return NotFound();

            return addresses;
        }
        [HttpPost]
        public ActionResult<Address> Post([FromBody] Address address)
        {
            ORM.CreateAddress(address);
            return Ok(address);

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                ORM.DeleteAddress(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            //if (product == null) return NotFound();

            // 200 ok 
            return Ok();
        }
    }
}
