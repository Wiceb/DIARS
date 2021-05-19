using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Polleria
{
    public partial class Info_Venta : Form
    {
        public Info_Venta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Venta v = new Venta();
            v.Id_venta = txtID.Text;
            v.Cliente = txtCliente.Text;
            v.Met_pago = cmbPago.Text;
            v.Vale = txtVale.Text;
            v.Fecha_emision = dtFecha.Value;
            if (validar_campos() == false)
            {
                if (new ne_ventas().ventas_udp(v))
                {
                    MessageBox.Show("Se modificó la venta con éxito");
                }
            }
            
            else
            {
                MessageBox.Show("No se modificó la venta");
                validar_campos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (validar_campos()==false)
            {
                if (new ne_ventas().ventas_del(txtID.Text))
                {
                    MessageBox.Show("Se eliminó correctamente la venta");

                }
            }
            else
            {
                MessageBox.Show("Existe campos sin datos");
                validar_campos();
            }
          
           
        }
        private bool validar_campos()
        {
            bool resp = true;
            int cont = 0;
            if (txtID.Text == string.Empty)
            {
                ePro.SetError(txtID, "Campo vacío");
                cont++;
            }
            if (txtCliente.Text == string.Empty)
            {
                ePro.SetError(txtCliente, "Campo vacío");
                cont++;
            }
            if (txtVendedor.Text == string.Empty)
            {
                ePro.SetError(txtVendedor, "Campo vacío");
                cont++;
            }
            if (cmbPago.Text==string.Empty)
            {
                ePro.SetError(cmbPago, "Campo vacío");
                cont++;
            }
            if (dtFecha.Text == string.Empty)
            {
                ePro.SetError(dtFecha, "Campo vacío");
                cont++;
            }
            if (cont > 0)
            {
                resp= true;
            }
            else if(cont==0)
            {
                resp= false;
            }
            return resp;
        }
    }
}
