﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio1.Models
{
    public class Jugador : IComparable<Jugador>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        /*public Jugador(string Nombre, string Apellido, double Salario, string Posicion, string Equipo)
        {
            this.Name = Nombre;
            this.Surname = Apellido;
            this.Salary = Salario;
            this.Position = Posicion;
            this.Club = Equipo;
        }*/
        public int CompareTo(Jugador other, Delegate Condicion)
        {
            return Convert.ToInt32(Condicion.DynamicInvoke(this , other));
        }

        public static int CompareByName(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Name, Jugador2.Name);
        }
        public static int CompareBySurname(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Surname, Jugador2.Surname);
        }
        public static int CompareBySalary(Jugador Jugador1, Jugador Jugador2)
        {
            return Convert.ToInt32(Jugador1.Salary - Jugador2.Salary);
        }
        public static int CompareByPosition(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Position, Jugador2.Position);
        }
        public static int CompareByClub(Jugador Jugador1, Jugador Jugador2)
        {
            return String.Compare(Jugador1.Club, Jugador2.Club);
        }

        int IComparable<Jugador>.CompareTo(Jugador other)
        {
            throw new NotImplementedException();
        }
    }
}
