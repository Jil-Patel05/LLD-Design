using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.FacadeDesign
{
    public class ProcessPayment
    {
        public void makePayement()
        {
            Console.WriteLine("Process payment");
        }
    }
    public class Inventory
    {
        public void managerInventory()
        {
            Console.WriteLine("Inventory management");
        }
    }
    public class Notification
    {
        public void notify()
        {
            Console.WriteLine("Notify user");
        }
    }
    public class OrderFacade
    {
        private ProcessPayment p;
        private Notification n;
        private Inventory inv;

        public OrderFacade()
        {
            p = new ProcessPayment();
            n = new Notification();
            inv = new Inventory();
        }

        public void makeOrder()
        {
            this.p.makePayement();
            this.inv.managerInventory();
            this.n.notify();
        }
    }
}