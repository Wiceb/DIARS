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
    public partial class Listado_Insumos : Form
    {
        public Listado_Insumos()
        {
            InitializeComponent();
            cmbProveedor.ValueMember = "Idempresa";
            cmbProveedor.DisplayMember = "Empresa";
            cmbProveedor.DataSource = new ne_proveedor().proveedor_sel();
            cmbProveedor.SelectedIndex = -1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            DialogResult obRes;
            obRes = MessageBox.Show("¿Estas seguro de eliminar el insumo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (obRes == DialogResult.Yes)
            {
                if (new ne_insumos().insumo_del(id))
                {
                    this.Close();
                    MessageBox.Show("Se eliminó el insumo");
                }
                Insumos_Registrados obIns = new Insumos_Registrados();
                obIns.gvInsumos.DataSource = new ne_insumos().insumos_sel();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insumos obIns = new Insumos();
            obIns.IdInsumo = Convert.ToInt32(txtId.Text);
            obIns.Fecha_reg = Convert.ToDateTime(txtFecha.Text);
            obIns.Insumo = cmbTipo.Text;
            obIns.Tipo_cant = txtTipo.Text;
            obIns.Cantidad = Convert.ToInt32(txtCantidad.Text);
            obIns.Descripcion = txtDescrip.Text;
            obIns.Idempresa = Convert.ToInt32(cmbProveedor.SelectedValue);

            if(new ne_insumos().insumo_upd(obIns))
            {
                MessageBox.Show("Modificado con éxito");
                Insumos_Registrados i = new Insumos_Registrados();
                i.gvInsumos.DataSource = new ne_insumos().insumos_sel();
                this.Close();
            }
        }
    }
}
