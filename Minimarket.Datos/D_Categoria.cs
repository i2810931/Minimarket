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
    public class D_Categoria
    {
        public DataTable Listado_ca(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable tabla = new DataTable ();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_ca", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                //envia informacion a filtrar(parametro)
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                Resultado = Comando.ExecuteReader();
                tabla.Load(Resultado);
                return tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }


        public string Guardar_ca(int nOpcion, E_Categorias oCa )
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try

            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_Guardar_ca" , SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("nOpcion", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("nCodigo_Ca", SqlDbType.Int).Value = oCa.Codigo_cat;
                comando.Parameters.Add("Descripcion_Ca", SqlDbType.VarChar).Value = oCa.Descripcion_cat;
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


        public string Eliminar_ca(int Codigo_ca)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try

            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_Eliminar_ca", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@codigo_Ca", SqlDbType.Int).Value = Codigo_ca;
                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el dato";

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
