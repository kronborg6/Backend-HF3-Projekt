using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonConstructor]
        public Member(string fristName, string lastName)
        {
            Fristname = fristName;
            Lastname = lastName;
            //postnummer.PostnummerID = postnummerID;
        }
        public void SetMemberID(int id)
        {
            MemberID = id;
        }
    }
}
