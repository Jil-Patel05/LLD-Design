using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ObserverPattern
{
    public interface ISubject
    {
        public void update();
    }
    public class Subject : ISubject
    {
        public void update()
        {
            Console.WriteLine("update method is called");
        }

    }
}