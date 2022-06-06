using System;
using Entidades;
using DAO;
using System.Data;

namespace Negocio
{
    public static class NegocioSucursal
    {
        public static DataTable MostrarTablaSucursales(string id = "", bool x = true)
        {

            if (id == "" && !x)
            {
                return DaoSucursal.getTablaSucursal();
            }
            else
            {
                return DaoSucursal.getTablaSucursalIndividual(id);
            }

        }

        public static int AgregarTablaSucursales(params object[]items)
        {
            string query = "INSERT INTO Sucursal " +
                    "(NombreSucursal,DescripcionSucursal,Id_ProvinciaSucursal,DireccionSucursal)" +
                    "values (@0, @1, @2, @3)";
            //Retornar cantidad de filas afectadas
            return DB.NonQuery(query, items) ?? 0;
        }

        public static int? elimSucursal(string id)
        {
            int? affected;
            string Consulta;
            Consulta = "delete from dbo.Sucursal where dbo.Sucursal.Id_Sucursal =" + id;
            affected = DB.NonQuery(Consulta);
            return affected;
        }

        public static DataSet SeleccionarTablaProvincias()
        {
            return DB.Query("SELECT ID_PROVINCIA, DESCRIPCIONPROVINCIA FROM PROVINCIA");
        }


    }
}
