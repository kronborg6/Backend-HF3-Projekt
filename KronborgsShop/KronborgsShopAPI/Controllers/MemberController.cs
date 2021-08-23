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
    public class MemberController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public MemberController()
        {
            ORM = new ORM_MsSql();
        }
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            Member member;

            try
            {
                member = ORM.GetMember(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            if (member == null) return NotFound();

            // 200 ok 
            return Ok(member);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {
            List<Member> members = new();

            try
            {
                members = ORM.GetMembers();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong" + ex.Message);
            }

            //if (products.Count < 1) return NotFound();

            return members;
        }
    }
}
