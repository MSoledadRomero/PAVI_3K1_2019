using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploLogin
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Validamos que se haya ingresado un usuario
            if ((txtUsuario.Text == ""))
            {
                MessageBox.Show("Se debe ingresar un usuario.");
                return;
            }

            //Validamos que se haya ingresado una contraseña
            if ((txtContrasena.Text == ""))
            {
                MessageBox.Show("Se debe ingresar una contraseña.");
                return;
            }

            //Validamos que las credenciales sean las correctas, caso contrario mostramos un mensaje mediante un MessageBox.
            if (ValidarCredenciales(txtUsuario.Text, txtContrasena.Text))
            {
                MessageBox.Show("Usted a ingresado al sistema.");
                this.Close();
            }
            else
            {
                txtUsuario.Text = "";
                txtContrasena.Text = "";
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos");
            }

        }

        public bool ValidarCredenciales(string pUsuario, string pPassword)
        {
            if (pUsuario == "test" & pPassword == "test")
                return true;
            else
                return false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cerramos la aplicación
            Environment.Exit(0);
        }


    }
}
