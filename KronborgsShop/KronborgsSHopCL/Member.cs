﻿using System;
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
        public Address Address { get; set; }
        //public Member() : this(0)
        //{

        //}
        public Member(int ID)
        {
            this.MemberID = ID;
            //this.Address = address;
        }
    }
}
