using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.AdapterDesign
{
    public interface INewPayment
    {
        public void processPayment();
    }
    public class NewPayment : INewPayment
    {
        public void processPayment()
        {
            Console.WriteLine("New payment");
        }
    }
}