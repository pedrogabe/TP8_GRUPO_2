using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5_GRUPO_2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NonQuery(object sender, EventArgs e)
        {
            lblNonQuery.Text += DB.NonQuery(txt.Text, txtParams.Text.Split(','));
        }

        protected void Query(object sender, EventArgs e)
        {
            var x = DB.Query(txt.Text, txtParams.Text.Split(','));
            if (x == null)
                lblNonQuery.Text += " null";
            else
            {
                gv.DataSource = x;
                gv.DataBind();
            }
        }
    }
}