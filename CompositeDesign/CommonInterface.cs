using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.CompositeDesign
{
    public interface ICommonInterface
    {
        public void display();
    }
    public class File : ICommonInterface
    {
        private string name;
        private string type;
        public File(string name)
        {
            this.name = name;
        }

        public void display()
        {
            Console.WriteLine("File name: " + this.name);
        }
    }
    public class Directory : ICommonInterface
    {
        private string name;
        private string type;
        private List<ICommonInterface> dirList = new List<ICommonInterface>();
        public Directory(string name)
        {
            this.name = name;
            this.type = type;
        }
        public void add(ICommonInterface item)
        {
            dirList.Add(item);
        }
        public void display()
        {
            Console.WriteLine($"Dir name is {name}");
            foreach (ICommonInterface item in dirList)
            {
                item.display();
            }
        }
    }
}