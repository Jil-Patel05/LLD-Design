using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.BuilderPattern
{
    public class StudentDirector
    {
        StudentBuilder st;
        public StudentDirector(StudentBuilder st)
        {
            this.st = st;
        }
        public Student buildStudent()
        {
            return this.st.buildRollNumber(2).build();
        }
    }
}