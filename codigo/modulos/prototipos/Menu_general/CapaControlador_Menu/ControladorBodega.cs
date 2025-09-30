using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_Menu;
using System.Data;

namespace CapaControlador_Menu
{
    public class ControladorBodega
    {
        Sentencias sentencias = new Sentencias();

        public void GuardarBodega(string codigo, string nombre, string estatus)
        {
            sentencias.Insertar(codigo, nombre, estatus);
        }

        public void Eliminar(string codigo)
        {
            sentencias.Eliminar(codigo);
        }

        public DataTable ObtenerDatos()
        {
            return sentencias.ObtenerDatos();
        }

    }
}
