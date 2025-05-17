using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.AbstractDesign
{
    public interface Bike
    {
        public void driveBike();
    }
    public interface Car
    {
        public void driveCar();
    }

    public class SuzukiBike : Bike
    {
        public void driveBike()
        {
            Console.WriteLine("driving bike");
        }
    }
    public class ToyotaBike : Bike
    {
        public void driveBike()
        {
            Console.WriteLine("driving bike");
        }
    }
    public class SuzukiCar : Car
    {
        public void driveCar()
        {
            Console.WriteLine("driving bike");
        }
    }
    public class ToyotaCar : Car
    {
        public void driveCar()
        {
            Console.WriteLine("driving bike");
        }
    }
}