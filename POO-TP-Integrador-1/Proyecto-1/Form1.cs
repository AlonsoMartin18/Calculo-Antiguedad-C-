using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Proyecto_1
{
    public partial class Form1 : Form
    {
        // Aca lo que hacemos es instanciar la lista donde se van a ir guardando
        // los datos de las personas.
        List<Persona>listaPersona = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos y le asignamos el valor a las variables segun los datos 
            //cargados de las personas por teclado.
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string dni = textBox3.Text;
            DateTime fecha_alta = dateTimePicker1.Value.Date;


            //Hacemos las validacionesde los campos para que no se carguen vacios.
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe Ingresar un Nombre");
                textBox1.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Debe Ingresar un Apellido");
                textBox2.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Ingrese un DNI válido");
                textBox3.Focus();
                return;
            }

            //Instanciamos a la nueva persona con sus atributos contenidos en 
            //la clase Persona.
            Persona Persona1 = new Persona(nombre, apellido, dni, fecha_alta);
            listaPersona.Add(Persona1);

            //Aca llammos al metodo de la clase que calcula la antiguedad
            //y lo muestra en el textBox correspondiente.            
            int antiguedad = Persona1.calculoant(fecha_alta);
            textBox4.Text = antiguedad.ToString();                        

            //LLamada al metodo que muestra los datos en el datagridview.
            mostrarLista();
        }

        //Metodo que imprime los datos de las personas cargados en un 
        //dataGridView.
        private void mostrarLista()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaPersona;              
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        //En este boton creamos la funcion de buscar a la persona deseada
        //mediante el DNI ingresado por teclado.
        private void button2_Click(object sender, EventArgs e)
        {
            string dniABuscar = textBox3.Text;
            if(textBox3.Text == null)
            {
                MessageBox.Show("Ingrese el número de DNI que desea buscar");
            }
            else
            {
                Persona pEncontrada = buscarDni(dniABuscar);
                if(pEncontrada != null)
                {
                    textBox1.Text = pEncontrada.Nombre;
                    textBox2.Text = pEncontrada.Apellido;
                }
                else
                {
                    MessageBox.Show("No se encontró el DNI ingresado");
                }
            }
           
        }

        //Metodo creado para realizar la busqueda de la persona 
        //por numero de DNI.
        private Persona buscarDni(string dni)
        {            
            foreach (var persona in listaPersona)
            {
                if (persona.DNI == dni)
                {
                    return persona;
                }
            }
            return null;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
