using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.FactoryDesign
{
    public interface INotification
    {
        public void notifyUser();
    }


    public class SMS : INotification
    {

        public void notifyUser()
        {
            Console.WriteLine("SMS user notified");
        }
    }
    public class Email : INotification
    {

        public void notifyUser()
        {
            Console.WriteLine("Email user notified");
        }
    }

    public class NullObject : INotification
    {
        public void notifyUser()
        {
            throw new NotImplementedException();
        }
    }
}