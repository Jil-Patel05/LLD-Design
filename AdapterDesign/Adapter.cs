using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.AdapterDesign
{
    public class PaymentAdapter : INewPayment
    {
        private IExisting e;
        public PaymentAdapter(IExisting e)
        {
            this.e = e;
        }

        public void processPayment()
        {
            this.e.makePayment();
        }
    }
}