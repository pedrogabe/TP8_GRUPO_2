using System;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace DAO
{
    public static class DB
    {
        private static string connString = "Data Source=localhost\\sqlexpress; Initial Catalog=BDSucursales; Integrated Security=True";
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }

        private static SqlDataAdapter GetAdapter(String consultaSql,SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private static SqlCommand GetCommandNon(in string query, Sucursal suc)
        {
            var cmd = new SqlCommand(query, GetConnection());
            
            if(suc.getid_ProvinciaSucursal()==0)
                {AddparametersDelete(ref cmd, suc);}
            else
                { AddParameters(ref cmd, suc); }
            return cmd;
        }

        private static SqlCommand GetCommandQuery(in string query)
        {
            var cmd = new SqlCommand(query, GetConnection());
            return cmd;
        }

        public static void AddParameters(ref SqlCommand cmd, Sucursal suc)
        {
            cmd.Parameters.AddWithValue("@NombreSucursal", suc.getNombreSucursal());
            cmd.Parameters.AddWithValue("@DescripcionSucursal", suc.getDescripcionSucursal());
            cmd.Parameters.AddWithValue("@Id_ProvinciaSucursal", suc.getid_ProvinciaSucursal());
            cmd.Parameters.AddWithValue("@DireccionSucursal", suc.getDireccionSucursal());
        }

        public static void AddparametersDelete(ref SqlCommand cmd, Sucursal suc)
        {
            SqlParameter parameter = new SqlParameter();
            parameter = cmd.Parameters.Add("@Id_Sucursal", SqlDbType.Int);
            parameter.Value = suc.getid_Sucursal();
        }

        /// <summary> 
        /// Ejecuta consultas en la base de datos.
        /// </summary>
        /// <param name="query">Consulta a la base de datos</param>
        /// <param name="parameters">Valores de los parámetros</param>
        /// <returns>DataSet con los resultados de la consulta o null falla la operación.</returns>
        public static DataSet Query(string query)
        {
            try
            {
                var cmd = GetCommandQuery(query);
                var adapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Ejecuta operaciones en la base de datos que no sean de selección.
        /// </summary>
        /// <param name="query">Consulta a la base de datos</param>
        /// <param name="parameters">Valores de los parámetros</param>
        /// <returns>Cantidad de filas afectadas o null si falla la operación</returns>
        public static int? NonQuery(string query, Sucursal suc)
        {
            try
            {
                var cmd = GetCommandNon(query, suc);
                cmd.Connection.Open();
                int affected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return affected;                
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = GetConnection();
            SqlDataAdapter adp = GetAdapter(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }
    }
}