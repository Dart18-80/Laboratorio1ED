using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio1.Models;

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

    }
}
