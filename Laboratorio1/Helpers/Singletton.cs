using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio1.Models;
using MLSClassLibrary;

namespace Laboratorio1.Helpers
{
    public class Singletton
    {
        private static Singletton _instance = null;
        public static Singletton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singletton();
                return _instance;
            }
        }
        public LinkedList<Jugador> PlayerList = new LinkedList<Jugador>();
        public LinkedList<Jugador> Search = new LinkedList<Jugador>();
        public DoubleList<Jugador> listaJugador = new DoubleList<Jugador>();
        public Nodo<Jugador> Procedimiento = new Nodo<Jugador>();
        public List<Jugador> Nueva = new List<Jugador>();
        public Stopwatch TiempoListaC = new Stopwatch();
        public Stopwatch TiempoListaEnlazada = new Stopwatch();
    }

}
