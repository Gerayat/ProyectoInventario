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
    public partial class VentanaPresentacio : Form
    {
        InventarioDataContext bd;
        VentanaEntrada padre;
        public VentanaPresentacio()
        {
            InitializeComponent();
            bd = new InventarioDataContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertarPresentacion();
        }
        public void insertarPresentacion() {
            String pre= textBox2.Text.Trim();
            if (pre.Length > 0)
            {

                tbPresentacion tbpresentacion = new tbPresentacion()
                {
                  //  codPresentacion =incremetal,
                    presentacion = pre,
                    descripcion = textBox1.Text.Trim()
                };
                bd.tbPresentacion.InsertOnSubmit(tbpresentacion);
                try
                {
                  
                      bd.SubmitChanges();
                    padre.llenarComboPresentacion();
                    MessageBox.Show("Se ha agregado una nueva presentacion");
                    this.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Error al ingresar registro" + ec.Message);
                }
            }
            else
            {
                MessageBox.Show("No se ha especificado una presentacion");
            }
        }
        public void referenciaPadre(VentanaEntrada padre) {
            this.padre = padre;
        }
       
    }
}
