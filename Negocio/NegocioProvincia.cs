using System;
using System.Data;
using System.Collections.Generic;
using DAO;
using Entidades;

namespace Negocio
{
    public static class NegocioProvincia
    {
        public static DataTable SeleccionarTablaProvincias()
        {
            return DaoProvincia.getTablaProvincias();
        }
    }
}
