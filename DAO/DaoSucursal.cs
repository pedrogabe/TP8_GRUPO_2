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

        public static DataTable getTablaSucursalIndividual(String id)
        {
            DataTable tabla = DB.ObtenerTabla("Sucursal", "Select Id_Sucursal, NombreSucursal, DescripcionSucursal, DescripcionProvincia, DireccionSucursal from Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal=Provincia.Id_Provincia WHERE Id_Sucursal="+id);
            return tabla;
        }
    }
}
