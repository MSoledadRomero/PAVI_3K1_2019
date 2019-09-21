using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoBugs.Clases;

namespace ProyectoBugs.Formularios
{
    public partial class frmUsuarios : Form
    {
        Perfil oPerfil = new Perfil();
        Usuario oUsuario = new Usuario();
        bool nuevo = false;
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            //this.cboPerfil.DataSource = oPerfil.recuperarPerfiles();
            //this.cboPerfil.DisplayMember = "n_perfil";
            //this.cboPerfil.ValueMember = "id_perfil";
            this.cargarCombo(cboPerfil, "Perfiles");

            this.grdUsuarios.Rows.Clear();
            this.grdUsuarios.DataSource = oUsuario.recuperarUsuarios();

            this.habilitar(false);

        }
        private void cargarCombo(ComboBox combo,string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = oPerfil.recuperarPerfiles(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.limpiar();
            this.habilitar(true);
            this.txtNombre.Focus();
        }
        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Clear();
            txtPassword.Clear();
            txtEmail.Text = string.Empty;
            cboPerfil.SelectedIndex = -1;
        }
        private void habilitar(bool x)
        {
           // txtId.Enabled = x;
            txtNombre.Enabled = x;
            txtPassword.Enabled = x;
            txtEmail.Enabled = x;
            cboPerfil.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            oUsuario.N_usuario = txtNombre.Text;
            oUsuario.Password = txtPassword.Text;
            oUsuario.Email = txtEmail.Text;
            oUsuario.Id_perfil = Convert.ToInt32(cboPerfil.SelectedValue);

            if (oUsuario.validarDatosUsuario())
            {
                if (this.nuevo == true)
                    oUsuario.grabarUsuario();
                else
                {
                    oUsuario.Id_usuario = int.Parse(txtId.Text);
                    oUsuario.actualizarUsuario();
                }

                this.grdUsuarios.DataSource = oUsuario.recuperarUsuarios();
                MessageBox.Show("El usuario se grabó con éxito!!!");
            }
            
            this.habilitar(false);
            this.nuevo = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.habilitar(false);
            this.nuevo = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            //this.txtId.Enabled = false;
            this.txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(Convert.ToInt32(grdUsuarios.CurrentRow.Cells[0].Value));
        }
        private void actualizarCampos(int id)
        {
            DataTable tabla = new DataTable();
            tabla=oUsuario.recuperarUsuarioID(id);
            txtId.Text = tabla.Rows[0]["id_usuario"].ToString();
            txtNombre.Text = tabla.Rows[0]["n_usuario"].ToString();
            txtPassword.Text = tabla.Rows[0]["password"].ToString();
            txtEmail.Text = tabla.Rows[0]["email"].ToString();
            cboPerfil.SelectedValue = tabla.Rows[0]["id_perfil"];
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de eliminar el usuario "+ txtNombre.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                oUsuario.Id_usuario = int.Parse(txtId.Text);
                oUsuario.eliminarUsuario();
                this.grdUsuarios.DataSource = oUsuario.recuperarUsuarios();
            }
        }

    }
}
