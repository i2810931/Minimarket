using Minimarket.Negocio;
using MInimarket.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MInimarket.presentacion
{
    public partial class frm_Marcas : Form
    {
        public frm_Marcas()
        {
            InitializeComponent();
        }

        #region Variables
        int codigo_marca;
        int estadoInicial=0;
        string rpta = "";
        #endregion

        #region Instancias
        N_Marcas marcas = new N_Marcas();
        #endregion
        private void frm_Marcas_Load(object sender, EventArgs e)
        {
            Listado();
        }

        #region Presentacion
        private void EstadoInicialData()
        {
            dgvMarcas.Columns[0].Width = 100;
            dgvMarcas.Columns[0].HeaderText = "CÓDIGO";
            dgvMarcas.Columns[1].Width = 300;
            dgvMarcas.Columns[1].HeaderText = "MARCA";
        }
        private void EstadoBotones_Principales(bool lEstado)
        {
            this.btnNuevo.Enabled = lEstado;
            this.btnactualizar.Enabled = lEstado;
            this.btnEliminar.Enabled = lEstado;
            this.btnReporte.Enabled = lEstado;
        }

        private void EstadoBotones(bool lEstado)
        {
            this.btnCancelar.Visible = lEstado;
            this.btnGuardar.Visible = lEstado;
            this.btnRetomar.Visible = lEstado;
        }
        #endregion

        private void Listado()
        {
            try
            {
                dgvMarcas.DataSource = N_Marcas.ListadoMarcas();
                this.EstadoInicialData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoInicial = 1;
            this.EstadoBotones_Principales(false);
            this.EstadoBotones(true);
            txtDescripcion.Text = "";
            txtDescripcion.ReadOnly = false;
            tbListado.SelectedIndex = 1;
            txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                E_Marca eMarca = new E_Marca();
                string rpta = "";
                eMarca.Codigo_Marca = this.codigo_marca;
                eMarca.Descripcion_Marca = txtDescripcion.Text.Trim();
                rpta = N_Marcas.Guardar_Marcas(estadoInicial,eMarca);
                if (rpta =="OK")
                {
                    Listado();
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }


    }
}
