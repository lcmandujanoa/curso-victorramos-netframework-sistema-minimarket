using Sol_Minimarket.Datos;
using Sol_Minimarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Minimarket.Negocio
{
    public class N_Unidades_Medida
    {
        public static DataTable Listado_um(string cTexto)
        {
            D_Unidades_Medida Datos = new D_Unidades_Medida();
            return Datos.Listado_um(cTexto);
        }

        public static string Guardar_um(int nOpcion, E_Unidades_Medida oUm)
        {
            D_Unidades_Medida Datos = new D_Unidades_Medida();
            return Datos.Guardar_um(nOpcion, oUm);
        }

        public static string Eliminar_um(int Codigo_um)
        {
            D_Unidades_Medida Datos = new D_Unidades_Medida();
            return Datos.Eliminar_um(Codigo_um);
        }
    }
}
