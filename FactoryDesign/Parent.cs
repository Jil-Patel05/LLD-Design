using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.FactoryDesign
{
    public class NotificationFactory
    {

        public static INotification getObjectBasedOnType(string objectType)
        {
            // if else condition to return object here
            // By adding if else we just disobey the open/closed principle
            // Understand it resolve it
            if (objectType == "SMS")
            {
                return new SMS();
            }
            else if (objectType == "Email")
            {
                return new Email();
            }
            else
            {
                return new NullObject();// this is null object design to avoid null checks
                // but sometimes we need null values to throw exception then don't use this
            }
        }

    }
}