using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    internal class Persona
    {
        //Creacion de los atributos de la Clase, con sus correspondientes
        //accesadores de la clase.
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime Fecha_Alta { get; set; }

        //Creacion del Constructor de las Personas.
        public Persona(string nombre, string apellido, string dni, DateTime fecha_alta)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.DNI = dni;
            this.Fecha_Alta = fecha_alta;
        }

        //Creacion de un metodo de la clase que se utilizará para realizar
        //el calculo de la antiguedad de la persona.
        public int calculoant(DateTime fecha_alta)
        {
            DateTime ant = fecha_alta;
            DateTime inicio = DateTime.Now.Date;
            //TimeSpan span = inicio.Subtract(ant);            
            int result = inicio.Year - ant.Year;
            
            if (inicio.Month < fecha_alta.Month || (inicio.Month == fecha_alta.Month && inicio.Day < fecha_alta.Day))
            {
                result--;
            }
            return result;

        }

        //Creacion del destructor de la clase Persona, con mensaje
        //de borrado de la persona identificada por su numero de DNI.
        ~Persona() 
        {
            MessageBox.Show($"La persona que tiene el DNI {this.DNI}, ha sido correctamente eliminada");
        }
        
    }
}
