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

        public static int AgregarTablaSucursales(Sucursal suc)
        {
            string query = "INSERT INTO Sucursal " +
                    "(NombreSucursal,DescripcionSucursal,Id_ProvinciaSucursal,DireccionSucursal)" +
                    "values (@NombreSucursal, @DescripcionSucursal, @Id_ProvinciaSucursal, @DireccionSucursal)";
            //Retornar cantidad de filas afectadas
            return DB.NonQuery(query, suc) ?? 0;
        }

        public static int? elimSucursal(string id)
        {
            Sucursal suc = new Sucursal();
            string Consulta;
            Consulta = "delete from dbo.Sucursal where dbo.Sucursal.Id_Sucursal = @Id_Sucursal";
            suc.setid_ProvinciaSucursal(0);
            suc.setid_Sucursal(Convert.ToInt32(id));
            return DB.NonQuery(Consulta, suc);
        }

        public static DataSet SeleccionarTablaProvincias()
        {
            return DB.Query("SELECT ID_PROVINCIA, DESCRIPCIONPROVINCIA FROM PROVINCIA");
        }


    }
}
