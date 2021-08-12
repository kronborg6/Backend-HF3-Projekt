using KronborgsSHopCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronborgsShopORM
{
    public interface IORM
    {
        public List<Member> GetMembers();
    }
}
