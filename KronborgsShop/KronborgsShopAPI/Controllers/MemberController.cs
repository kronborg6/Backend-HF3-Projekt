using KronborgsSHopCL;
using KronborgsShopORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KronborgsShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public MemberController()
        {
            ORM = new ORM_MsSql();
        }
        //[HttpGet("{id}")]
    }
}
