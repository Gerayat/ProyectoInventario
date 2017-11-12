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
    public partial class VentanaVerProducto : Form
    {
        InventarioDataContext data;
        public VentanaVerProducto()
        {
            InitializeComponent();
            data = new InventarioDataContext();
            llenarProducto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void llenarProducto()
        {
            var tabla = from e in data.tbEntrada
                              join p in data.tbPresentacion on e.codPresentacion equals p.codPresentacion
                              join v in data.tbProductoProveedor on e.codProductoProveedor equals v.codProductoProveedor
                              join pr in data.tbProducto on v.codProducto equals pr.codProducto
                              select new {NMBRE= pr.nombre,PRESENTACION =p.presentacion,UBICACION =pr.ubicacion,CANTIDAD=e.cantidad,FECHA_DE_VENCIMIENTO = e.fechaVencimiento};
            this.dataGridView1.DataSource = tabla.ToList();

        }
    }
}
