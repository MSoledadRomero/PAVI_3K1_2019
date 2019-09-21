using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoLogin.Clases
{
    class Usuario
    {
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
           
            Datos oBD = new Datos();
            tabla = oBD.consultar(consultaSQL);

            if (tabla.Rows.Count > 0)
                return Convert.ToInt32(tabla.Rows[0][0]);
            else
                return 0;
        }
    }
}
