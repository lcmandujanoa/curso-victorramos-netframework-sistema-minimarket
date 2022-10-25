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
    public class N_Entrada_Productos
    {
        public static DataTable Listado_ep(string cTexto)
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Listado_ep(cTexto);
        }
        public static DataTable Listado_detalle_ep(int nCodigo_ep)
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Listado_detalle_ep(nCodigo_ep);
        }

        public static string Guardar_ep(E_Entrada_Productos oEp, DataTable dTabla)
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Guardar_ep(oEp, dTabla);
        }

        public static string Eliminar_ep(int Codigo_ep)
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Eliminar_ep(Codigo_ep);
        }

        public static DataTable Listado_tde_ep()
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Listado_tde_ep();
        }

        public static DataTable Listado_al_ep()
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Listado_al_ep();
        }

        public static DataTable Listado_pv_ep(string cTexto)
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Listado_pv_ep(cTexto);
        }

        public static DataTable Listado_pr_ep(string cTexto)
        {
            D_Entrada_Productos Datos = new D_Entrada_Productos();
            return Datos.Listado_pr_ep(cTexto);
        }
    }
}
