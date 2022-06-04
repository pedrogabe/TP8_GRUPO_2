using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using Negocio;

namespace TP5_GRUPO_2
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        public void validar(string id)
        {
            int ? affected = NegocioSucursal.elimSucursal(id);
            if (affected == 0)
            {
                Label1.Text = "ID inexistente";
            }
            else
            {
                if(affected == 1)
                {
                    Label1.Text = "La sucursal ha sido eliminada correctamente";
                }
                else
                {
                    Label1.Text = "Error al eliminar!";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void btnEliminarID_Click(System.Object sender, System.EventArgs e)
        {
            if(PassesValidation())
                validar(txtEliminarID.Text);
        }

        protected bool PassesValidation()
        {
            return rfvEliminar.IsValid &&
                revEliminar.IsValid;
        }
    }
    
}