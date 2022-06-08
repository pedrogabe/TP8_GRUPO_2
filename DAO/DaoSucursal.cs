using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public static class DaoSucursal
    {

        public static DataTable getTablaSucursal()
        {
            DataTable tabla = DB.ObtenerTabla("Sucursal", "Select Id_Sucursal, NombreSucursal, DescripcionSucursal, DescripcionProvincia, DireccionSucursal from Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal=Provincia.Id_Provincia");
            return tabla;
        }

        public static DataTable getTablaSucursalIndividual(int id)
        {
            var paramList = getIdAsParameterCollection(id);
            DataTable tabla = DB.ObtenerTabla("Sucursal", "Select Id_Sucursal, NombreSucursal, DescripcionSucursal, DescripcionProvincia, DireccionSucursal from Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal=Provincia.Id_Provincia WHERE Id_Sucursal=@Id_Sucursal", paramList);

            return tabla;
        }

        public static int? AgregarSucursal(Sucursal suc)
        {
            string query = "INSERT INTO Sucursal " +
                    "(NombreSucursal,DescripcionSucursal,Id_ProvinciaSucursal,DireccionSucursal)" +
                    "values (@NombreSucursal, @DescripcionSucursal, @Id_ProvinciaSucursal, @DireccionSucursal)";
            var paramList = getAllAttributesAsParameterCollection(suc);

            //Retornar cantidad de filas afectadas
            return DB.NonQuery(query, paramList);
        }

        public static int? EliminarSucursal(int id)
        {
            string Consulta = "delete from dbo.Sucursal where dbo.Sucursal.Id_Sucursal = @Id_Sucursal";
            var paramList = getIdAsParameterCollection(id);

            //Retornar cantidad de filas afectadas
            return DB.NonQuery(Consulta, paramList);
        }

        private static List<SqlParameter> getIdAsParameterCollection(int idSucursal)
        {
            var paramList = new List<SqlParameter>();

            paramList.Add( new SqlParameter("@Id_Sucursal", idSucursal) );
            return paramList;
        }

        private static List<SqlParameter> getAllAttributesAsParameterCollection(Sucursal sucursal)
        {
            var paramList = new List<SqlParameter>();

            paramList.Add( new SqlParameter("@NombreSucursal", sucursal.getNombreSucursal()) );
            paramList.Add( new SqlParameter("@DescripcionSucursal", sucursal.getDescripcionSucursal()) );
            paramList.Add( new SqlParameter("@Id_ProvinciaSucursal", sucursal.getid_ProvinciaSucursal()) );
            paramList.Add( new SqlParameter("@DireccionSucursal", sucursal.getDireccionSucursal()) );
            return paramList;
        }
    }
}
