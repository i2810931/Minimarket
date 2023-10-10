using MInimarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Datos
{
    public class D_Marcas
    {
        public DataTable ListadoMarcas()
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlDataAdapter adapter = new SqlDataAdapter(@"select codigo_ma, descripcion_ma from TB_MARCAS
	            where estado=1 and upper(trim(cast(codigo_ma as char))+trim(descripcion_ma)) like '%';", SqlCon);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GuardarMarca(int nOpcion, E_Marca oMa)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try

            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_Guardar_Ma", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nOpcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("nCodigo_Ma", SqlDbType.Int).Value = oMa.Codigo_Marca;
                comando.Parameters.Add("Descripcion_Ma", SqlDbType.VarChar).Value = oMa.Descripcion_Marca;
                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar dato";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
    }
}
