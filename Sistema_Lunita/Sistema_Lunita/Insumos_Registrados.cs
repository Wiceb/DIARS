using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Polleria
{
    public partial class Insumos_Registrados : Form
    {
        public Insumos_Registrados()
        {
            InitializeComponent();
            gvInsumos.AutoGenerateColumns = false;
            gvInsumos.DataSource = new ne_insumos().insumos_sel();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gvInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            ColeccionClases obCol;
            id = Convert.ToInt32(gvInsumos.SelectedCells[0].Value);

            obCol=new ne_insumos().insumos_by_id(id);
            Listado_Insumos li = new Listado_Insumos();
            li.Show();
            foreach (Insumos obIns in obCol)
            {
                li.cmbProveedor.Text = obIns.Empresa;
                li.txtFecha.Text = Convert.ToString(obIns.Fecha_reg);
                li.cmbTipo.Text = obIns.Insumo;
                li.txtTipo.Text = obIns.Tipo_cant;
                li.txtCantidad.Text =Convert.ToString(obIns.Cantidad);
                li.txtDescrip.Text = obIns.Descripcion;
                li.txtId.Text = Convert.ToString(id);
                return;
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gvInsumos.DataSource = new ne_insumos().insumos_sel();
        }
    }
}
