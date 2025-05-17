using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.SingletonPattern
{
    public class Singleton
    {
        //First thing you need is private constructor so that no one can make instance of class
        // Then static method which returns the instace of class
        public static Singleton? instace;
        private static Mutex _mutex = new Mutex();
        private Singleton()
        {

        }

        public static Singleton getInstance()
        {
            if (instace == null)
            {
                _mutex.WaitOne();
                if (instace == null)
                {
                    // When we have multiple threds then it can be critaical box to be executes
                    // We have to ensure it is executed correctly for multithreading
                    return instace = new Singleton();
                }
                _mutex.ReleaseMutex();
                // This double check ensures that mutex is applied only when instance is null
                // mutex is used for accross process,
                // lock is used for same process threads
                // use depend upon usecase
            }
            return instace;
        }

    }
}