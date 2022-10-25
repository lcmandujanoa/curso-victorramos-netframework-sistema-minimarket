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
    public class N_Clientes
    {
        public static DataTable Listado_cl(string cTexto)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_cl(cTexto);
        }

        public static string Guardar_cl(int nOpcion, E_Clientes oCl)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Guardar_cl(nOpcion, oCl);
        }

        public static string Eliminar_cl(int Codigo_cl)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Eliminar_cl(Codigo_cl);
        }

        public static DataTable Listado_tdpc_cl()
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_tdpc_cl();
        }

        public static DataTable Listado_sx_cl()
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_sx_cl();
        }

        public static DataTable Listado_ru_cl(string cTexto)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_ru_cl(cTexto);
        }
        public static DataTable Listado_di_cl(string cTexto)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_di_cl(cTexto);
        }
    }
}
