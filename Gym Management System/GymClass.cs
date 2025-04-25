using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_System
{
    public class GymClass
    {
        public string ClassName { get; set; }
        public Trainer Instructor { get; set; }
        public GymClass() { }
        public GymClass(string className, Trainer instructor)
        {
            ClassName = className;
            Instructor = instructor;
        }
    }
}
