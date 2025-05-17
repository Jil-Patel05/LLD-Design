using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ProxyDesign
{
    public class ProxyPayement
    {
        private Payement p;
        public ProxyPayement()
        {
            p = new Payement();
        }
        public void makePayement()
        {
            // We can apply some authentication + authorization here
            // This will helpfull to restrict access of object and use it proxy
            this.p.makePayment();
        }

    }
    public interface Ione
    {
        public void one();
    }
    public interface ITwo : Ione
    {
        public void Two();
    }

    public class Practise : Ione
    {
        // ITwo i = new Practise();
        public void one()
        {
            throw new NotImplementedException();
        }

        // public void Two()
        // {
        //     throw new NotImplementedException();
        // }
        
    }

}