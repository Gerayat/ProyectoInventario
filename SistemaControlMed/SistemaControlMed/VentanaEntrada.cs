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
  
    public partial class VentanaEntrada : Form
    {
        List<int> codigosProducto = new List<int>();
        List<int> codigosPresentacion = new List<int>();
        List<int> codigosProveedor= new List<int>();
        InventarioDataContext bdatos;
        public VentanaEntrada()
        {
            InitializeComponent();
            bdatos = new InventarioDataContext();
            llenarComboProducto();
            llenarComboPresentacion();
            llenarComboProveedor();
        }

       // SALIR
        private void button5_Click(object sender, EventArgs e)
        {
           // if (confirme salida == true) { this.Close(); }
            this.Close();

        }
        //NUEVO PRODUCTO
        private void button3_Click(object sender, EventArgs e)
        { 
            VentanaProducto vpr = new VentanaProducto();
            vpr.referenciaPadre(this);
            vpr.Show();
        }
       //NUEVA PRESENTACION
        private void button1_Click_1(object sender, EventArgs e)
        {
            VentanaPresentacio vp = new VentanaPresentacio();
            vp.referenciaPadre(this);
            vp.Show();
        }
        //NUEVO PROVEEDOR
        private void button2_Click(object sender, EventArgs e)
        {
            VentanaProveedor vnp = new VentanaProveedor();
            vnp.referenciaPadre(this);
            vnp.Show();
        }
        //REGISTRAR
        private void button4_Click(object sender, EventArgs e)
        {
             insertarEntrada();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void llenarComboPresentacion() {
            comboBox1.Items.Clear();
            codigosPresentacion.Clear();
            var presentacion = from pr in bdatos.tbPresentacion.AsEnumerable() select new {
            pr.codPresentacion,pr.presentacion
            }; 

            foreach (var p in presentacion) { codigosPresentacion.Add(p.codPresentacion); comboBox1.Items.Add(p.presentacion); }
        }
        public void llenarComboProducto()
        {
            comboBox3.Items.Clear();
            codigosProducto.Clear();
            var productos = from pr in bdatos.tbProducto.AsEnumerable() select new {
                pr.codProducto,pr.nombre
            };
            foreach (var p in productos) { codigosProducto.Add(p.codProducto); comboBox3.Items.Add(p.nombre); }
        }
        public void llenarComboProveedor()
        {
            comboBox2.Items.Clear();
            codigosProveedor.Clear();
            var proveedores = from pr in bdatos.tbProveedor.AsEnumerable() select new {pr.codProveedor, pr.proveedor };
            foreach (var p in proveedores) { codigosProveedor.Add(p.codProveedor); comboBox2.Items.Add(p.proveedor); }
        }
        public void insertarEntrada() {
            if ((comboBox1.SelectedIndex!=-1)&&(comboBox2.SelectedIndex != -1)&&(comboBox3.SelectedIndex != -1)&&(textBox1.Text.Trim().Length>0)&&(textBox2.Text.Trim().Length>0)) {

             int codigoProductoProvee = registrarTbProductoProveedor();
            int codigoProductoPres=registrarTbProductoPresentacion();
                insertarTbEntrada(codigoProductoProvee);
                MessageBox.Show("Producto registrado exitosamente");
            }
        }
        public int registrarTbProductoProveedor() {

         int cod = consultartbProductoProveedor();
            if (cod!=-1)
            {
                return cod;
            }
            else
            {
                tbProductoProveedor regProdPro = new tbProductoProveedor()
                {
                    // codProductoProveedor=incremental
                    codProducto = codigosProducto.ElementAt(comboBox3.SelectedIndex),
                    codProveedor = codigosProveedor.ElementAt(comboBox2.SelectedIndex)
                };
                bdatos.tbProductoProveedor.InsertOnSubmit(regProdPro);
              
                try
                {

                    bdatos.SubmitChanges();
                    
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Error: " + ec.Message);
                }
            }
            //si se crea uno nuevo se registra el precio fechadeCambio estado = 1
            cod = consultartbProductoProveedor();
            insertarTbPrecioCosto(cod);
            return  cod;
        }
        public int consultartbProductoProveedor() {
            var codProdProveed = from p in bdatos.tbProductoProveedor.AsEnumerable()
                                 where p.codProveedor == codigosProveedor.ElementAt(comboBox2.SelectedIndex) &&
                                 p.codProducto == codigosProducto.ElementAt(comboBox3.SelectedIndex)
                                 select p.codProductoProveedor;
            if (codProdProveed.ToList().Count > 0)
            {
                return codProdProveed.ToList().ElementAt(0);
            }
            return -1;
        }
        public int registrarTbProductoPresentacion() {
            int cod = consultarTbProductoPresent();
            if (cod != -1)
            {
                return cod;
            }
            tbProductoPresentacion rtbpp = new tbProductoPresentacion()
            {
                // codProductoPresentacion= incremental
                codProducto = codigosProducto.ElementAt(comboBox3.SelectedIndex),
                codPresentacion = codigosPresentacion.ElementAt(comboBox1.SelectedIndex)
            };
            bdatos.tbProductoPresentacion.InsertOnSubmit(rtbpp);
            try
            {
                bdatos.SubmitChanges();
               
            }
            catch (Exception ec)
            {
                MessageBox.Show("Error: " + ec.Message);
            }
            return consultarTbProductoPresent();
        }
        public int consultarTbProductoPresent() {
            var codProdPresen = from p in bdatos.tbProductoPresentacion.AsEnumerable()
                                 where p.codProducto == codigosProducto.ElementAt(comboBox3.SelectedIndex) &&
                                 p.codPresentacion == codigosPresentacion.ElementAt(comboBox1.SelectedIndex)
                                 select p.codProductoPresentacion;
            if (codProdPresen.ToList().Count > 0)
            {
                return codProdPresen.ToList().ElementAt(0);
            }
            return -1;
        }
        public void insertarTbPrecioCosto(int codProdProev) {

            tbPrecioCosto regtbpcosto = new tbPrecioCosto() {
              //  codPrecioCosto=incremental
            codProductoProveedor= codProdProev,
            precio=Convert.ToDecimal(textBox1.Text),
            fechaCambio = dateTimePicker2.Value.Date,
            estado = 1//significa que esta activo
            };
        }
        public void insertarTbEntrada(int cprodProv) {
            tbEntrada tbEn = new tbEntrada()
            {
            //codEntrada=incremental
            codProductoProveedor=cprodProv,
            codPresentacion = codigosPresentacion.ElementAt(comboBox1.SelectedIndex),
            costoEntrada=Convert.ToDecimal(textBox1.Text),
            cantidad=Convert.ToInt32(textBox2.Text),
            fechaIngreso = dateTimePicker2.Value.Date,
            fechaVencimiento=dateTimePicker1.Value.Date
            };
            bdatos.tbEntrada.InsertOnSubmit(tbEn);
            try {
                bdatos.SubmitChanges();
            }
            catch (Exception e) {
                MessageBox.Show("Error: " + e.Message);
            }
        }
    }
}
