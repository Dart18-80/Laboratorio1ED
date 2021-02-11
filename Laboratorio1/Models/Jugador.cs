using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio1.Models
{
    public class Jugador : IComparable
    {

        public Jugador(string Nombre, string Apellido, double Salario, string Posicion, string Equipo)
        {
            this.Name = Nombre;
            this.Surname = Apellido;
            this.Salary = Salario;
            this.Position = Posicion;
            this.Club = Equipo; 
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
    }
}
