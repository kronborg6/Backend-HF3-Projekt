using System;
using System.Collections.Generic;

namespace KronborgsSHopCL
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Fristname { get; set; }
        public string Lastname { get; set; }
        public int Mobil { get; set; }
        public string Email { get; set; }
        public List<Address> Addres { get; set; }
    }
}
