using Sol_Minimarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Minimarket.Datos
{
    public class D_Salida_Productos
    {
        public DataTable Listado_sp(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_sp", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public DataTable Listado_detalle_sp(int nCodigo_sp)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_Detalle_sp", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_sp", SqlDbType.Int).Value = nCodigo_sp;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public string Guardar_sp(E_Salida_Productos oSp, DataTable dTabla)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Guardar_sp", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_tde", SqlDbType.Int).Value = oSp.Codigo_tde;
                Comando.Parameters.Add("@cNrodocumento_sp", SqlDbType.VarChar).Value = oSp.Nrodocumento_sp;
                Comando.Parameters.Add("@nCodigo_cl", SqlDbType.Int).Value = oSp.Codigo_cl;
                Comando.Parameters.Add("@cNrodocumento_cl", SqlDbType.VarChar).Value = oSp.Nrodocumento_cl;
                Comando.Parameters.Add("@cRazon_social_cl", SqlDbType.VarChar).Value = oSp.Razon_social_cl;
                Comando.Parameters.Add("@fFecha_sp", SqlDbType.Date).Value = oSp.Fecha_sp;
                Comando.Parameters.Add("@cObservacion_sp", SqlDbType.Text).Value = oSp.Observacion_sp;
                Comando.Parameters.Add("@nSubtotal", SqlDbType.Decimal).Value = oSp.Subtotal;
                Comando.Parameters.Add("@nIgv", SqlDbType.Decimal).Value = oSp.Igv;
                Comando.Parameters.Add("@nTotal_importe", SqlDbType.Decimal).Value = oSp.Total_importe;
                Comando.Parameters.Add("@tDetalle", SqlDbType.Structured).Value = dTabla;

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@nCodigo_sp";
                ParCodigo.SqlDbType = SqlDbType.Int;
                ParCodigo.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParCodigo);

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParCodigo.Value);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Eliminar_sp(int Codigo_sp)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Eliminar_sp", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_sp", SqlDbType.Int).Value = Codigo_sp;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public DataTable Listado_tde_sp()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_tde_sp", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public DataTable Listado_cl_sp(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_cl_sp", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public DataTable Listado_pr_sp(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_pr_sp", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }
    }
}
