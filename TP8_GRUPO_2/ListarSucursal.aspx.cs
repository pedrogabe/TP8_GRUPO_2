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
                DataTable tabla = new DataTable();
                tabla = NegocioSucursal.MostrarTablaSucursales(id,x);

                if (tabla == null)
                    { throw new Exception("DB"); }
                else if(tabla.Rows.Count==0)
                    { lblError.Text = "El ID ingresado no existe"; lblError.Visible = true; }

                gvSucursales.DataSource = tabla;
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