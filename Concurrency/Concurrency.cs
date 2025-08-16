using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.Concurrency
{
    public class Concurrency
    {
        public void print()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Print something here..");
        }

        public void threadUse()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            // I can pass the function to thread when it is initilized, without initilized i can't pass the function
            // Thread t = new Thread(new ThreadStart(print)); // We created new thread
            // t.Start();
            print(); // Same thread is used
        }

        public void neeThreadUse()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            // Task t = new Task(print);
            // t.Start();
            // // When main thread execution is completed program in exited, and other task created is also exited
            // t.Wait(); 

            // Task.Run(() =>
            // {
            //     Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            // });
            // Task.Delay(200); // It is kind of task which is executed in 200ms
            // If main thread is executed here then all other thread is automatically exited
        }
    }

}