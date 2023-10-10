using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MInimarket.Entidades;
using Minimarket.Negocio;


namespace MInimarket.presentacion
{
    public partial class frm_Categorias : Form
    {
        public frm_Categorias()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int Codigo_ca = 0;
        int EstadoGuarda = 0;

        #endregion
        #region "Mis metodos"
        private void Formato_ca()
        {
            dgv_principal.Columns[0].Width = 100;
            dgv_principal.Columns[0].HeaderText = "CODIGO";
            dgv_principal.Columns[1].Width = 300;
            dgv_principal.Columns[1].HeaderText = "CATEGORIA";
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.btn_nuevo.Enabled = lEstado;
            this.btn_actualizar.Enabled = lEstado;
            this.btn_eliminar.Enabled = lEstado;
            this.btn_reporte.Enabled = lEstado;
            this.btn_salir.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.btn_cancelar.Visible = lEstado;
            this.btn_guardar.Visible = lEstado;
            this.btn_retornar.Visible = !lEstado;
        }


        private void Selecciona_Item()
        {
            //valida si el datagrid tiene informacion
            if (string.IsNullOrEmpty(Convert.ToString(dgv_principal.CurrentRow.Cells["cod_categ"].Value)))
                //el nombre de la columna a travez del data source adquiere el nombre del campo, cod_categ
            {
                MessageBox.Show("No se tiene informaciòn para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ca = Convert.ToInt32(dgv_principal.CurrentRow.Cells["cod_categ"].Value);
                txt_Descripcion.Text = Convert.ToString(dgv_principal.CurrentRow.Cells["descripcion_ca"].Value);
            }
           
        }
        //METODO PARA TRAER INFORMACION

        private void Listado_ca(string cTexto)
        {
            try
            {
                dgv_principal.DataSource = N_Categorias.Listado_ca(cTexto);
                this.Formato_ca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        private void frm_Categorias_Load(object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_Descripcion.Text == string.Empty) 
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else// se procede a registrar la informacion
            {
                E_Categorias oCa = new E_Categorias();
                string rpta = "";
                oCa.Codigo_cat = this.Codigo_ca;
                oCa.Descripcion_cat = txt_Descripcion.Text.Trim();
                rpta = N_Categorias.Guardar_ca(EstadoGuarda,oCa);
                if (rpta =="OK")
                {
                    this.Listado_ca("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoGuarda = 0;//no hay accion
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    txt_Descripcion.Text = "";
                    txt_Descripcion.ReadOnly = true;
                    tbp_principal.SelectedIndex = 0;
                    this.Codigo_ca = 0;
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 1;//Nuevo registro
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            txt_Descripcion.Text = "";
            txt_Descripcion.ReadOnly = false;
            tbp_principal.SelectedIndex = 1;
            txt_Descripcion.Focus();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 2;//actualiza registro
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Selecciona_Item();           
            tbp_principal.SelectedIndex = 1;
            txt_Descripcion.ReadOnly = false;
            txt_Descripcion.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 0;
            this.Codigo_ca = 0;
            txt_Descripcion.Text = "";
            txt_Descripcion.ReadOnly = true;
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            tbp_principal.SelectedIndex = 0;
        }

        private void dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_Item();
            tbp_principal.SelectedIndex = 1;
            this.Estado_Botonesprocesos(false);

        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            tbp_principal.SelectedIndex = 0;
            this.Codigo_ca = 0;
        }

        private void dgv_principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item();
            this.Estado_Botonesprocesos(false);
            tbp_principal.SelectedIndex = 1;

        }


        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_principal.CurrentRow.Cells["cod_categ"].Value)))
            //el nombre de la columna a travez del data source adquiere el nombre del campo, cod_categ
            {
                MessageBox.Show("No se tiene informaciòn para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Estas seguro de eliminar el registro seleccionado", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion ==DialogResult.Yes)
                {
                    string rpta = "";
                    this.Codigo_ca = Convert.ToInt32(dgv_principal.CurrentRow.Cells["cod_categ"].Value);
                    rpta = N_Categorias.Eliminar_ca(this.Codigo_ca);
                    if (rpta.Equals("OK"))
                    {
                        this.Listado_ca("%");
                        this.Codigo_ca = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ca(txt_buscar.Text.Trim());
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
