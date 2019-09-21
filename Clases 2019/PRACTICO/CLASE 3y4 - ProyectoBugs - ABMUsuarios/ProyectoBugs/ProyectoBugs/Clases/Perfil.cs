using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoBugs.Clases
{
    class Perfil
    {
        Datos oBD = new Datos();

        private int id_Perfil;
        public int Id_Perfil
        {
            get { return id_Perfil; }
            set { id_Perfil = value; }
        }
        private string n_Perfil;
        public string N_Perfil
        {
            get { return n_Perfil; }
            set { n_Perfil = value; }
        }
        public DataTable recuperarPerfiles(string nombreTabla)
        {
            return oBD.consultarTabla(nombreTabla);
        }
    }
}
