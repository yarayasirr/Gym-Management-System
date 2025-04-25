using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Gym_Management_System
{
    public class Member: Person
    {
        public Member() { }
        public Membership Membership { get; set; }
        public Member(string name,int age,string PhoneNumber)
        {
            Name = name;
            this.age = age;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
