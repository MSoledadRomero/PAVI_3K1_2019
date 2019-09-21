using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerProyecto
{
    public partial class frmLogin : Form
    {
        string usuario = "admin";
        string clave = "1234";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string msj = "";

            //if (this.txtUsuario.Text == "")
            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar Usuario...");
                txtUsuario.Focus();
                return;
            }
            if (this.txtClave.Text==string.Empty)
            {
                MessageBox.Show("Debe ingresar Clave...");
                txtClave.Focus();
                return;
            }

            // Validar Usuario...

            if (this.txtUsuario.Text == this.usuario &&
                this.txtClave.Text == this.clave)
                msj = "Usuario Valido!!!";
            else
                msj = "Usuario invalido!!!";

            MessageBox.Show(msj,"Logueando",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
    }
}
