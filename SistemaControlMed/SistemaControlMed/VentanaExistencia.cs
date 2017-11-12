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
    
    public partial class VentanaExistencia : Form
    {
        InventarioDataContext bdatos;
        public VentanaExistencia()
        {
            InitializeComponent();
            bdatos = new InventarioDataContext();
            llenarExistencia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void llenarExistencia() {
            dataGridView1.DataSource = bdatos.productoExistencia.ToList();
        }
    }
}
