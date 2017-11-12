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
    public partial class VentanaProducto : Form
    {
        InventarioDataContext bd;
        VentanaEntrada padre;
        int indice;
        public VentanaProducto()
        {
            InitializeComponent();
            bd = new InventarioDataContext();
            llenarComboCategoria();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertarProducto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             VentanaCategoria vc = new VentanaCategoria();
            vc.referenciaPadre(this);
            vc.Show();  
        }
        public void insertarProducto()
        {
            int ind = comboBox1.SelectedIndex;
            String name = textBox2.Text.Trim();

            if ((name.Length > 0) && (ind != -1))
            {
                var codCatSelecionado = from cat in bd.tbCategoria where cat.categoria.Equals(comboBox1.Text) select cat.codCategoria;
               
                tbProducto regProd = new tbProducto()
                {
                    //codProducto=incremental,
                    nombre = textBox2.Text.Trim(),
                    descripcion= textBox3.Text.Trim(),
                    codCategoria = codCatSelecionado.ToList().ElementAt(0),
                    ubicacion = textBox5.Text.Trim(),
                    estado=true

                };
                bd.tbProducto.InsertOnSubmit(regProd);
                try
                {

                    bd.SubmitChanges();
                    padre.llenarComboProducto();
                    MessageBox.Show("Se ha agregado una nueva producto");
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
        public void llenarComboCategoria() {
            comboBox1.Items.Clear();
            var categorias = from cat in bd.tbCategoria select cat.categoria;
            foreach (var c in categorias) { comboBox1.Items.Add(c); }
        }


    }
}
