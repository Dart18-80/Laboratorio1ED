using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using MLSClassLibrary;

namespace Laboratorio1.Models
{
    public class Jugador : IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public IFormFile FileC { get; set; }
        public int Id { get; set; }
        public static int cont = 0;
        public int CompareTo(Jugador Jugador1, Jugador other, Delegate Condicion)
        {
            return Convert.ToInt32(Condicion.DynamicInvoke(Jugador1 , other));
        }

        public int CompareByName(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Name, Jugador2.Name);
        }
        public int CompareBySurname(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Surname, Jugador2.Surname);
        }
        public int CompareBySalary(Jugador Jugador1, Jugador Jugador2)
        {
            return Convert.ToInt32(Jugador1.Salary - Jugador2.Salary);
        }
        public int CompareByPosition(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Position, Jugador2.Position);
        }
        public int CompareByClub(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Club, Jugador2.Club);
        }

        public int CompareTo(object obj)
        {
            if (Convert.ToInt16(this.CompareTo(obj)) > 0)
                return 1;
            else if (Convert.ToInt16(this.CompareTo(obj)) < 0)
                return -1;
            else
                return 0;
        }

    }
}
