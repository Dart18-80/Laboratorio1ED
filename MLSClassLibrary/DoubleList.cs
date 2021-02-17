using System;
using System.Collections.Generic;
using System.Text;


namespace MLSClassLibrary
{
    public class DoubleList <T> where T : IComparable
    {

        public  T Nodo { get; set; }
        public  DoubleList<T> Previous { get; set; }
        public  DoubleList<T> Next { get; set; }

        public static DoubleList<T> raiz = new DoubleList<T> { Nodo = default, Next = null, Previous = null };


        public static bool Empty(DoubleList<T> raiz)
        {
            if (raiz.Nodo == null)
                return true;
            else
                return false;
        }
        public void Insert(T Nuevo, DoubleList<T> raiz)
        {
            if (Empty(raiz))
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
                    Insert(Nuevo, raiz.Next);
                }
            }
        }
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
    }
}
