using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ProyectoBugs.Clases
{
    class Usuario
    {
        Datos oBD = new Datos();

        int id_usuario;
        string n_usuario;
        string password;
        string email;
        int id_perfil;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Id_perfil
        {
            get { return id_perfil; }
            set { id_perfil = value; }
        }
        public int Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public string N_usuario
        {
            set { n_usuario = value; }
            get { return n_usuario; }
        }
        public int validarUsuario(string nombre,string clave)
        {
            DataTable tabla = new DataTable();
            
            string consultaSQL = "SELECT * FROM Users WHERE n_usuario='" + nombre + "' AND password='" + clave + "'";
           
            tabla = oBD.consultar(consultaSQL);

            if (tabla.Rows.Count > 0)
                return Convert.ToInt32(tabla.Rows[0][0]);
            else
                return 0;
        }
        public DataTable recuperarUsuarios()
        {
            return oBD.consultarTabla("Users");
        }
        public bool validarDatosUsuario()
        {
            if (this.n_usuario =="")
            {
                MessageBox.Show("El usuario está vacío");
                return false;
            }
            if (this.password == "")
            {
                MessageBox.Show("El passwor está vacío");
                return false;
            }
            if (this.email == "")
            {
                MessageBox.Show("El email está vacío");
                return false;
            }
            if (this.id_perfil == -1)
            {
                MessageBox.Show("El perfil está vacío");
                return false;
            }
            return true;
        }
        public void grabarUsuario()
        {
            string sqlInsert = "";

            sqlInsert = @"INSERT INTO users (n_usuario,password, email, id_perfil) VALUES ('" +
                         this.n_usuario + "', '" +
                         this.password + "', '" +
                         this.email + "', " +
                         this.id_perfil.ToString() + ")";
            
            oBD.actualizar(sqlInsert);
        }
        public void actualizarUsuario()
        {
            string sqlUpDate = "";
            sqlUpDate = @"UPDATE users SET n_usuario='" + this.n_usuario + "'," +
                                         "password='" + this.password + "'," +
                                         "email='" + this.email + "'," +
                                         "id_perfil=" + this.id_perfil +
                                  " WHERE id_usuario=" + this.id_usuario;
            oBD.actualizar(sqlUpDate);
        }
        public void eliminarUsuario()
        {
            string sqlDelete = @"DELETE FROM users WHERE id_usuario=" + this.id_usuario;
            oBD.actualizar(sqlDelete);
        }

        public DataTable recuperarUsuarioID(int id)
        {
            return oBD.consultar("SELECT * FROM users WHERE id_usuario=" + id);
        }
    }
}
