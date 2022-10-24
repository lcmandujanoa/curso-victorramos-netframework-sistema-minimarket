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
    public class N_Departamentos
    {
        public static DataTable Listado_de(string cTexto)
        {
            D_Departamentos Datos = new D_Departamentos();
            return Datos.Listado_de(cTexto);
        }

        public static string Guardar_de(int nOpcion, E_Departamentos oDe)
        {
            D_Departamentos Datos = new D_Departamentos();
            return Datos.Guardar_de(nOpcion, oDe);
        }

        public static string Eliminar_de(int Codigo_ru)
        {
            D_Departamentos Datos = new D_Departamentos();
            return Datos.Eliminar_de(Codigo_ru);
        }
    }
}
