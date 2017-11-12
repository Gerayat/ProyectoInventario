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
    public partial class VentanaCliente : Form
    {
        InventarioDataContext bd;
        public VentanaCliente()
        {
            InitializeComponent();
            bd = new InventarioDataContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertarCliente();
        }
        public void insertarCliente()
        {
           
            if ((textBox1.Text.Trim().Length > 0)&& (textBox2.Text.Trim().Length > 0)&& (textBox5.Text.Trim().Length > 0))
            {
                tbCliente cli = new tbCliente() {
                    //codCliente= incremental
                    nombres = textBox1.Text.Trim(),
                    apellidos = textBox2.Text.Trim(),
                    nit = textBox3.Text.Trim(),
                    telefono=textBox4.Text.Trim(),
                    direccion=textBox5.Text.Trim()
                };
               
              
                bd.tbCliente.InsertOnSubmit(cli);
                try
                {

                    bd.SubmitChanges();
                  
                    MessageBox.Show("Se ha agregado una nuevo cliente");
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
