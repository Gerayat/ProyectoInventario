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
    public partial class VentanaSalida : Form
    {
        InventarioDataContext bd;
        public VentanaSalida()
        {
            InitializeComponent();
            bd = new InventarioDataContext();
            llenarComboPresentacion();
            llenarComboProducto();
        }

        private void VentanaSalida_Load(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void llenarGrid() {
            if ((comboBox1.SelectedIndex!=-1)&&(comboBox2.SelectedIndex!=-1)) {
               dataGridView1.DataSource= bd.OBTENER_PRODUCTOS(comboBox1.Text,comboBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
        public void llenarComboPresentacion()
        {
            comboBox2.Items.Clear();

            var presentacion = from pr in bd.tbPresentacion
                               select pr.presentacion;
                               
            foreach (var p in presentacion.ToList()) {  comboBox2.Items.Add(p); }
        }
        public void llenarComboProducto()
        {
            comboBox1.Items.Clear();

            var productos = from pr in bd.tbProducto select pr.nombre;
foreach(var p in productos) { ; comboBox1.Items.Add(p); }
        }
    }
}
