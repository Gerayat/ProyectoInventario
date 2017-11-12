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
    public partial class VentanaProveedor : Form
    {
        InventarioDataContext bd;
        VentanaEntrada padre;
        public VentanaProveedor()
        {
            InitializeComponent();
            bd = new InventarioDataContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertarProveedor();
        }
        public void insertarProveedor()
        {
            String prov = textBox1.Text.Trim();
            String cont = textBox2.Text.Trim();
            String tel = textBox4.Text.Trim();
            if ((prov.Length > 0) && (cont.Length > 0)&& (tel.Length > 0))
            {

                tbProveedor tbproveedor = new tbProveedor()
                {
                   // codProveedor = incremetal,
                    proveedor = textBox1.Text.Trim(),
                    contacto = textBox2.Text.Trim(),
                    direccion = textBox3.Text.Trim(),
                    telefono = textBox4.Text.Trim(),
                    codigoPostal = textBox5.Text.Trim(),
                    fax = textBox6.Text.Trim(),
                    nit = textBox7.Text.Trim(),
                    estadoFiscal = textBox8.Text.Trim(),
                    cuentaBancaria = textBox9.Text.Trim()

                };
                bd.tbProveedor.InsertOnSubmit(tbproveedor);
                try
                {

                    bd.SubmitChanges();
                    padre.llenarComboProveedor();
                    MessageBox.Show("Se ha agregado una nuevo proveedor");
                    this.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Error al ingresar registro" + ec.Message);
                }
            }
            else
            {

                MessageBox.Show("Debe llenar los campos obligatorios");
            }
        }
        public void referenciaPadre(VentanaEntrada padre)
        {
            this.padre = padre;
        }

    }
}
