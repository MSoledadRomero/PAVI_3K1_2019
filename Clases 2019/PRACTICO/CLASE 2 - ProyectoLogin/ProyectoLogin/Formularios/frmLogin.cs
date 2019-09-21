using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoLogin.Clases;

namespace ProyectoLogin
{
    public partial class frmLogin : Form
    {
        Usuario miUsuario = new Usuario();

        internal Usuario MiUsuario
        {
            get { return miUsuario; }
            set { miUsuario = value; }
        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            //if (this.txtUsuario.Text == "")
            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar Usuario...");
                txtUsuario.Focus();
                return;
            }
            if (this.txtClave.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar Clave...");
                txtClave.Focus();
                return;
            }
            
            miUsuario.N_usuario = txtUsuario.Text;
            miUsuario.Password = txtClave.Text;

            miUsuario.Id_usuario = miUsuario.validarUsuario(miUsuario.N_usuario, miUsuario.Password);

            if (miUsuario.Id_usuario== 0)
            {
                MessageBox.Show("Usuario inválido...","VALIDANDO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtClave.Clear();
                txtUsuario.Focus();
            }
            else
            {
                this.Close();
            }

        }

      
    }
}
