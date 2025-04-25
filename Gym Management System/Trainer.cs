using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_System
{
    public class Trainer: Person
    {
        public string speciality {  get; set; }
        public Trainer(string name,string speciality,int age)
        {
            this.Name= name;
            this.speciality = speciality;
            this.age = age;
        }
    }
}
