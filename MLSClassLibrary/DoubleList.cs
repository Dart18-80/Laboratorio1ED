using System;
using System.Collections.Generic;
using System.Text;
using MLSClassLibrary;


namespace MLSClassLibrary
{
    public class DoubleList <T> where T : IComparable
    {
        public Nodo<T> Header { get; set; }
        public Nodo<T> Tail { get; set; }
        
        List<T> DataNode = new List<T>();

        public DoubleList()
        {
            Header = null;
            Tail = null;
        }

        public void AddHead(T data)
        {
            if (Header == null)
            {
                Header = new Nodo<T>() { Data = data };
                Tail = Header;
            }
            else
            {
                var oldHead = Header;
                Header = new Nodo<T>()
                {
                    Data = data,
                    Next = oldHead
                };
                oldHead.Previous = Header;
            }
        }
        public List<T> Mostrar(Nodo<T> Cabeza) 
        {
            if (Cabeza != null)
            {
                DataNode.Add(Cabeza.Data);
                Mostrar(Cabeza.Next);
                return null;
            }
            else
                return DataNode;

        }
        /*
        public T Buscar(T FoundNodo, Delegate Condicion)
        {
            if (Empty(raiz))
            {
                return default;
            }
            else
            {
                if (Convert.ToInt16(Condicion.DynamicInvoke(FoundNodo, raiz.Nodo)) == 0)
                {
                    return raiz.Nodo;
                }
                else
                {
                    CambioBuscar(FoundNodo, raiz, Condicion);
                }
                return default;
            }
        }

       
        
        public T CambioBuscar(T NodoBuscar, DoubleList<T> Busquedad, Delegate Condicion)
        {
            if (Busquedad.Next != null)
            {

                if (Convert.ToInt16(Condicion.DynamicInvoke(NodoBuscar, Busquedad.Next.Nodo)) == 0)
                {
                    return raiz.Next.Nodo;
                }
                else
                {
                    CambioBuscar(NodoBuscar, Busquedad.Next, Condicion);
                }
                return default;
            }
            else
            {
                return default;
            }
        }
        */
    }
}

