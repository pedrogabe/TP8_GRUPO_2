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
    public partial class ListarSucursal : System.Web.UI.Page
    {
        private void validar(string id = "", bool x = true) 
        {
            try
            {
                DataSet ds = new DataSet();
                ds = NegocioSucursal.MostrarTablaSucursales(id,x);

                if (ds == null)
                    { throw new Exception("DB"); }
                else if(ds.Tables[0].Rows.Count==0)
                    { lblError.Text = "El ID ingresado no existe"; lblError.Visible = true; }

                gvSucursales.DataSource = ds.Tables[0];
                gvSucursales.DataBind();
            }
            catch(Exception ex) 
            {
                lblError.Text = "Error al obtener listado de sucursales";
                lblError.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible=false;
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {

            validar("", false);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if(ValidForm())
                validar(txtID.Text);
        }

        protected bool ValidForm()
        {
            return
                RFVtxtID.IsValid &&
                REVtxtID.IsValid;
        }
    }
}