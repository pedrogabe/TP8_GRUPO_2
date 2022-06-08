using System.Data;
using Entidades;

namespace DAO
{
    public static class DaoProvincia
    {
        public static DataTable getTablaProvincias()
        {
            return DB.ObtenerTabla("Provincias","SELECT ID_PROVINCIA, DESCRIPCIONPROVINCIA FROM PROVINCIA");
        }
    }
}
