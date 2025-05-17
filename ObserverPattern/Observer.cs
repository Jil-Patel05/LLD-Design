using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ObserverPattern
{
    public interface IObserver
    {
        public void add(ISubject sub);
        public void remove(ISubject sub);
        public void setData(int data);
    }
    public class Observer : IObserver
    {
        public List<ISubject> list = new List<ISubject>();
        int initialData = 0;

        public void add(ISubject sub)
        {
            Console.WriteLine(sub);
            list.Add(sub);
        }
        public void remove(ISubject sub)
        {
            list.Remove(sub);
        }
        private void notify()
        {
            foreach (ISubject sub in list)
            {
                sub.update();
            }
        }
        public void setData(int data)
        {
            initialData += data;
            notify();
        }

    }
}