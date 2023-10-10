using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MInimarket.Entidades;
using Minimarket.Datos;


namespace Minimarket.Negocio
{
    public class N_Categorias
    {
        public static DataTable Listado_ca(string cTexto)
        {
            D_Categoria Datos = new D_Categoria();
            return Datos.Listado_ca(cTexto);
        }

        public static string Guardar_ca(int nOpcion, E_Categorias oCa)
        {
            D_Categoria datos = new D_Categoria();
            return datos.Guardar_ca(nOpcion,oCa);
        }

        public static string Eliminar_ca(int Codigo_ca)
        {
            D_Categoria datos = new D_Categoria();
            return datos.Eliminar_ca(Codigo_ca);
        }
    }
}
