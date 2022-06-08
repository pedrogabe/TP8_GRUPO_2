using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;
namespace TP5_GRUPO_2
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Llenar dropdownlist de provincias
            if (!IsPostBack) FillDDlProvincias();
            // Reset labels y textboxes
            lblError.Visible = lblConfirmar.Visible = false;
            lblError.Text = "";
        }

        protected void FillDDlProvincias()
        {
            try
            {
                // Seleccionar del database la tabla de provincias
                var dt = NegocioProvincia.SeleccionarTablaProvincias();
                if (dt == null) throw new Exception("DB");

                ddlProvinciaS.DataValueField = "ID_PROVINCIA";
                ddlProvinciaS.DataTextField = "DESCRIPCIONPROVINCIA";
                ddlProvinciaS.DataSource = dt;
                ddlProvinciaS.DataBind();

            }
            catch(Exception ex)
            {
                lblError.Text += "Error al obtener listado de provincias.";
                lblError.Visible = true;
            }
        }

        protected bool ValidForm()
        {
            return
                rfvDescripcion.IsValid &&
                rfvDireccion.IsValid &&
                rfvNombre.IsValid;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar mediante controles
            if(ValidForm())
            {
                Sucursal suc = new Sucursal();
                suc.setNombreSucursal(txtNombre.Text);
                suc.setDescripcionSucursal(txtDescripcion.Text);
                suc.setProvinciaSucursal(ProvinciaSeleccionada());
                suc.setDireccionSucursal(txtDireccion.Text);

                // Validar operación exitosa
                if (NegocioSucursal.AgregarTablaSucursales(suc))
                {
                    // Reiniciar campos
                    txtNombre.Text = txtDescripcion.Text = txtDireccion.Text = "";
                    ddlProvinciaS.SelectedIndex = 0;
                    // Colocar cursor en campo "Nombre"
                    txtNombre.Focus();
                    lblConfirmar.Text = "La sucursal se ha agregado con éxito";
                    lblConfirmar.Visible = true;
                }
                else
                {
                    lblError.Text += "Error al guardar la sucursal.";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text += "Formulario incompleto.";
                lblError.Visible = true;
            }
        }

        protected Provincia ProvinciaSeleccionada()
        {
            return new Provincia
            (
                Convert.ToInt32(ddlProvinciaS.SelectedValue),
                ddlProvinciaS.SelectedItem.Text
            );
        }
    }
    
}