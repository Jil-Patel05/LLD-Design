using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.IteratorDesign
{
    public class Iterators<T> : IIterator<T>
    {
        private List<T> names = new List<T>();
        private int index = 0;
        public Iterators(List<T> names)
        {
            this.names = names;
        }

        public bool hasNext()
        {
            return index < this.names.Count();
        }

        public T next()
        {
            return this.names[index++];
        }
    }

    public class ProductsName<T>
    {
        private List<T> names = new List<T>();

        public ProductsName()
        {

        }

        public void add(T name)
        {
            names.Add(name);
        }

        public Iterators<T> getIterator()
        {
            return new Iterators<T>(names);
        }
    }
}