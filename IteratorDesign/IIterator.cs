using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.IteratorDesign
{
    public interface IIterator<T>
    {
        public bool hasNext();
        public T next();
    }
}