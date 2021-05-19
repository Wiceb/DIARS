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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usu, contra;
            usu = txtUsuario.Text;
            contra = txtContraseña.Text;
            MenuPrincipal mp = new MenuPrincipal();
            if (new ne_usuario().validar_usuario(usu, contra))
            {
                if(new ne_usuario().val_tipo_us(usu, contra) != "Administrador")
                {
                    this.Hide();
                    //MenuPrincipal m = new MenuPrincipal();
                    mp.opcRegUs.Visible = false;
                    mp.opcAdmin.Visible = false;
                    mp.Show();
                }
                else
                {
                    this.Hide();
                    //MenuPrincipal mp = new MenuPrincipal();
                    mp.Show();
                }
                mp.lblUsu.Text = new ne_usuario().nombre_usuarios(usu,contra);
            }
            else
            {
                erro1.SetError(txtContraseña, "Contraseña incorrecta");
            }
        }
    }
}
