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
                if (!Int32.TryParse(id, out int idNumber)) return null;
                return DaoSucursal.getTablaSucursalIndividual(idNumber);
            }

        }

        public static bool AgregarTablaSucursales(Sucursal suc)
        {
            //Retornar operación exitosa (se afectaron filas)
            return (DaoSucursal.AgregarSucursal(suc) ?? 0) > 0;
        }

        public static int? elimSucursal(string id)
        {
            if (!Int32.TryParse(id, out int idNumber)) return null;
            return DaoSucursal.EliminarSucursal(idNumber);
        }

    }
}
