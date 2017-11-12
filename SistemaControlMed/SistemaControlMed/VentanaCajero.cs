using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaControlMed
{
    public partial class VentanaCajero : Form
    {
        InventarioDataContext data;
        public VentanaCajero()
        {
            InitializeComponent();
            data = new InventarioDataContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertarCajero();
        }
        public void insertarCajero()
        {

            if ((textBox1.Text.Trim().Length > 0) && (textBox2.Text.Trim().Length > 0))
            {

                tbCajero caje = new tbCajero() {
                    nombres = textBox1.Text.Trim(),
                    apellidos = textBox2.Text.Trim(),
                    fechaNacimiento =dateTimePicker1.Value.Date,
                    telefono = textBox4.Text.Trim()
                };

                data.tbCajero.InsertOnSubmit(caje);
                try
                {

                    data.SubmitChanges();

                    MessageBox.Show("Se ha agregado una nuevo cajero");
                    this.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Error al ingresar registro" + ec.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos obligatorios");
            }
        }

    }
}
