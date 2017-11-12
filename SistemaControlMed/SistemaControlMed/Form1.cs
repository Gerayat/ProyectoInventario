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
    public partial class Form1 : Form
    {
        InventarioDataContext data;
        public Form1()
        {
            InitializeComponent();
            data = new InventarioDataContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDInventarioMedicoDataSet.tbCategoria' Puede moverla o quitarla según sea necesario.
          //  this.tbCategoriaTableAdapter.Fill(this.bDInventarioMedicoDataSet.tbCategoria);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentanaSalida vs = new VentanaSalida();
               vs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentanaEntrada ve = new VentanaEntrada();
            ve.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VentanaProducto np = new VentanaProducto();
            np.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VentanaCategoria vc = new VentanaCategoria();
            vc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VentanaVerProducto pvPr = new VentanaVerProducto();
            pvPr.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            VentanaProveedor vprov = new VentanaProveedor();
            vprov.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            VentanaPresentacio Vpres = new VentanaPresentacio();
            Vpres.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void sslirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaProducto np = new VentanaProducto();
            np.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaProveedor vprov = new VentanaProveedor();
            vprov.Show();
        }

        private void presentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaPresentacio Vpres = new VentanaPresentacio();
            Vpres.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaCategoria vc = new VentanaCategoria();
            vc.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaCliente vc= new VentanaCliente();
            vc.Show();

        }

        private void cajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaCajero vcaje = new VentanaCajero();
               vcaje.Show();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            VentanaExistencia vex = new VentanaExistencia();
            vex.Show();
        }
    }
}
