using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.BuilderPattern
{
    public interface IStudentBuilder
    {
        public StudentBuilder buildRollNumber(int rollNumber);
        public StudentBuilder buildFirstName(string firstName);
        public StudentBuilder buildLastName(string lastName);
        public StudentBuilder buildAge(int age);
        public StudentBuilder buildAddress(string address);
    }
    public class StudentBuilder : IStudentBuilder
    {
        protected Student st;
        // If we don't have to make same variable use Student class
        // If we don't have to Use this student class then use variables for it
        public StudentBuilder()
        {
            st = new Student();
        }

        public StudentBuilder buildAddress(string address)
        {
            st.address = address;
            return this;
        }

        public StudentBuilder buildAge(int age)
        {
            st.age = age;
            return this;
        }

        public StudentBuilder buildFirstName(string firstName)
        {
            st.firstName = firstName;
            return this;
        }

        public StudentBuilder buildLastName(string lastName)
        {
            st.lastName = lastName;
            return this;
        }

        public StudentBuilder buildRollNumber(int rollNumber)
        {
            st.rollNumber = rollNumber;
            return this;
        }

        public Student build()
        {
            return st;
        }
    }

    public class FistStudent : StudentBuilder
    {
        public StudentBuilder addSubject(string subject)
        {
            st.subject = subject;
            return this;
        }
    }
    public class secondStudent : StudentBuilder
    {
        public StudentBuilder addSubject(string subject)
        {
            st.subject = subject;
            return this;
        }
    }
}