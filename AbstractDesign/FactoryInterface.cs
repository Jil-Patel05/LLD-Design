using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.AbstractDesign
{
    public interface IFactory
    {
        public Bike createBike();
        public Car createCar();
    }
    public class Suzuki : IFactory
    {
        public Bike createBike()
        {
            return new SuzukiBike();
        }
        public Car createCar()
        {
            return new SuzukiCar();
        }
    }
    public class Toyota : IFactory
    {
        public Bike createBike()
        {
            return new ToyotaBike();
        }
        public Car createCar()
        {
            return new ToyotaCar();
        }
    }
}