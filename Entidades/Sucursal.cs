using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sucursal
    {
        // PARTE PRIVATE
        private int id_Sucursal;
        private String NombreSucursal;
        private String DescripcionSucursal;
        private int id_HorarioSucursal;
        private Provincia ProvinciaSucursal;
        private String DireccionSucursal;
        private String URL_DireccionSucursal;
        private String DescripcionProvincia_Sucursal;
        public Sucursal()
        {

        }
        // PARTE PUBLIC
        //PARTE sets()
        public void setid_Sucursal(int isu) { id_Sucursal = isu; }
        public void setNombreSucursal(String ns) { NombreSucursal = ns; }
        public void setDescripcionSucursal(String ds) { DescripcionSucursal = ds; }
        public void setid_HorarioSucursal(int hs) { id_HorarioSucursal = hs; }
        public void setProvinciaSucursal(Provincia ps) { ProvinciaSucursal = ps; }
        public void setDireccionSucursal(String dirs) { DireccionSucursal = dirs; }
        public void setURL_DireccionSucursal(String uds) { URL_DireccionSucursal = uds; }
        public void setDescripcionProvincia_Sucursal(String dps) { DescripcionProvincia_Sucursal = dps; }
        //PARTE gets()
        public int getid_Sucursal() { return id_Sucursal; }
        public String getNombreSucursal() { return NombreSucursal; }
        public String getDescripcionSucursal() { return DescripcionSucursal; }
        public int getid_HorarioSucursal() { return id_HorarioSucursal; }
        public Provincia getProvinciaSucursal() { return ProvinciaSucursal; }
        public int getid_ProvinciaSucursal() { return ProvinciaSucursal.Id; }
        public String getDireccionSucursal() { return DireccionSucursal; }
        public String getURL_DireccionSucursal() { return URL_DireccionSucursal; }
        public String getDescripcionProvincia_Sucursal() { return DescripcionProvincia_Sucursal; }
    }
}
