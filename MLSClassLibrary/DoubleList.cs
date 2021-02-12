using System;
using System.Collections.Generic;
using System.Text;


namespace MLSClassLibrary
{
    class DoubleList <T> where T : IComparable
    {

        public T Nodo { get; set;}
        public DoubleList<T> Previous { get; set;}
        public DoubleList<T> Next { get; set; }

        private DoubleList<T> raiz = new DoubleList<T> { Nodo = default , Next = null, Previous = null};


        public bool empty (DoubleList<T> raiz) 
        {
            if (raiz.Nodo == null)
                return true;
            else
                return false;
        }
        public void Insert(T Nuevo, DoubleList<T> raiz) 
        {
            if (empty(raiz))
            {
                raiz.Nodo = Nuevo;
                raiz.Next = null;
                raiz.Previous = null;
            }
            else 
            {
                DoubleList<T> NewNode = new DoubleList<T> { Nodo = Nuevo, Next = null, Previous = null };
                if (raiz.Next == null)
                {
                    raiz.Next = NewNode;
                    NewNode.Previous = raiz;
                }
                else 
                {
                    Insert(Nuevo,raiz.Next);
                }
            }
        }

        public T Buscar(T FoundNodo, Delegate Condicion) 
        {
            bool Found = false;
            if (raiz!=null)
            {
                while (raiz.Next != null && Found != true)
                {
                    if (Convert.ToInt16(Condicion.DynamicInvoke(FoundNodo,raiz.Next.Nodo)) == 0)
                        return FoundNodo;
                    Previous = raiz.Next;
                }
            }
            else
            {
                return FoundNodo;
            }
        }
    }
}
