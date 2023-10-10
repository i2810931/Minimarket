using Minimarket.Datos;
using MInimarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Negocio
{
    public class N_Marcas
    {
        public static DataTable ListadoMarcas()
        {
            D_Marcas marcas = new D_Marcas();
            return marcas.ListadoMarcas();
        }
        public static string Guardar_Marcas(int nOpcion, E_Marca oMa)
        {
            D_Marcas marcas = new D_Marcas();
            return marcas.GuardarMarca(nOpcion, oMa);
        }

        
    }
}
