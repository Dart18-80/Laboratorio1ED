using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


    }
}
