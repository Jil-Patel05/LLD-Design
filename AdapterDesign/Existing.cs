using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.AdapterDesign
{
    public interface IExisting
    {
        public void makePayment();
    }
    public class Existing : IExisting
    {
        public void makePayment()
        {
            Console.WriteLine("Existing make payment method");
        }
    }
}