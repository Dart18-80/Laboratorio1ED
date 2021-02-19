using System;
using System.Collections.Generic;
using System.Text;

namespace MLSClassLibrary
{
    public class Nodo <T> 
    {
        public Nodo<T> Previous { get; set; }
        public Nodo<T> Next { get; set; }

        public T Data { get; set; }
    }
}
