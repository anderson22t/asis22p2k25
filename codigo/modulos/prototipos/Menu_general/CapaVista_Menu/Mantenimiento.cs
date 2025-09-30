using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_Menu;
using CapaControlador_Seguridad;

namespace CapaVista_Menu
{
    public partial class Mantenimiento : Form
    {
        ControladorBodega controlador = new ControladorBodega();
        Controlador cn = new Controlador();
        string codigo = "";
        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void dgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvMantenimiento.Rows[e.RowIndex];
                string sCodigo = filaSeleccionada.Cells["codigo_bodega"].Value?.ToString();
                string sNombre = filaSeleccionada.Cells["nombre_bodega"].Value?.ToString();
                string sEstatus = filaSeleccionada.Cells["estatus_bodega"].Value?.ToString();
                codigo = sCodigo;
                txtCodigo.Text = sCodigo;
                txtNombre.Text = sNombre;
                txtEstatus.Text = sEstatus;
            }
        }

        private void ActualizarGrid()
        {
            DataTable datos = controlador.ObtenerDatos();
            dgvMantenimiento.DataSource = controlador.ObtenerDatos();

            if (dgvMantenimiento.Columns.Count > 0)
            {
                dgvMantenimiento.Columns["codigo_bodega"].HeaderText = "Codigo";
                dgvMantenimiento.Columns["nombre_bodega"].HeaderText = "Nombre";
                dgvMantenimiento.Columns["estatus_bodega"].HeaderText = "Estatus";
            }   
            dgvMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimiento.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMantenimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimiento.AllowUserToAddRows = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string estatus = txtEstatus.Text;

            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(estatus))
            {
                MessageBox.Show("Debe llenar todos los campos");
                return;
            }
            else
            {
                controlador.GuardarBodega(codigo, nombre, estatus);
                cn.RegistrarAccion(1, 100, "Guardar", true);
                
                MessageBox.Show("Bodega registrada",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                ActualizarGrid();
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtEstatus.Text = "";
            }
        }

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void eliminarRegistro()
        {
            controlador.Eliminar(codigo);
            ActualizarGrid();
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtEstatus.Text = "";
            codigo = "";    
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Seleccione primero la fila de la bodega a eliminar.");
                return;
            }
            else
            {
                // Inicio de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 23/09/2025
                DialogResult resultado = MessageBox.Show(
                    "¿Seguro que desea eliminar este registro?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    eliminarRegistro();
                }
                // Fin de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 23/09/2025
            }
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string estatus = txtEstatus.Text;

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Seleccione primero la fila de la bodega a modificar.");
                return;
            }
        }
    }
}
