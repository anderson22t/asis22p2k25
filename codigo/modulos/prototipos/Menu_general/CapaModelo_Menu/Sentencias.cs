using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_Menu
{
    public class Sentencias
    {
        Conexion con = new Conexion();

        public void Insertar(string codigo, string nombre, string estatus)
        {
            Conexion cn = new Conexion();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "INSERT INTO bodega (codigo_bodega, nombre_bodega, estatus_bodega) VALUES (?,?,?)";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("codigo",codigo);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("estatus",estatus);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertarBitacora(string codigo, string nombre, string estatus)
        {
            Conexion cn = new Conexion();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "INSERT INTO bodega (codigo_bodega, nombre_bodega, estatus_bodega) VALUES (?,?,?)";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("nombre", nombre);
                cmd.Parameters.AddWithValue("estatus", estatus);
                cmd.ExecuteNonQuery();
            }
        }


        public DataTable ObtenerDatos()
        {
            DataTable tabla = new DataTable();
            try
            {
                Conexion cn = new Conexion();
                using (OdbcConnection con = cn.conexion())
                {
                    string sql = "SELECT codigo_bodega, nombre_bodega, estatus_bodega FROM bodega";
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, con);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                // Aquí mostrara mensaje de error 
                Console.WriteLine("Error al obtener reportes: " + ex.Message);
            }

            return tabla;
        }

        public void Eliminar(string codigo)
        {
            Conexion cn = new Conexion();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "DELETE FROM bodega WHERE codigo_bodega=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
