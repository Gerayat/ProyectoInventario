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
    public partial class VentanaCategoria : Form
    {
        InventarioDataContext bd;
        VentanaProducto padre;
        public VentanaCategoria()
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
            insertarCategoria();
        }
        public void insertarCategoria()
        {
            String cate = textBox1.Text.Trim();
            if (cate.Length > 0)
            {

                tbCategoria reCat = new tbCategoria() {
                //codCategoria=incremental
                categoria=textBox1.Text.Trim(),
                descripcion=textBox2.Text.Trim()
                };
                bd.tbCategoria.InsertOnSubmit(reCat);
                try
                {

                    bd.SubmitChanges();
                    padre.llenarComboCategoria();
                    MessageBox.Show("Se ha agregado una nueva categoria");
                    this.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Error al ingresar registro" + ec.Message);
                }
            }
            else
            {
                MessageBox.Show("No se ha especificado una categoria");
            }
        }
        public void referenciaPadre(VentanaProducto padre)
        {
            this.padre = padre;
        }
    }
}
