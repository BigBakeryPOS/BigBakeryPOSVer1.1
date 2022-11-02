using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;


namespace Billing.Production
{
    public partial class Response : System.Web.UI.Page
    {
        KitchenClass objbs = new KitchenClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();

           
            if (!IsPostBack)
            {
                DataSet ingrid = objbs.get_ingredients();
                Ingredientdrid.DataSource = ingrid;
                Ingredientdrid.DataBind();
                // Ingredientdrid.HeaderRow.Visible = false;
                Ingredientdrid.Columns[0].ItemStyle.Width = 292;
                Ingredientdrid.Columns[1].ItemStyle.Width = 292;
                Ingredientdrid.Columns[2].ItemStyle.Width = 292;
                Ingredientdrid.Columns[3].ItemStyle.Width = 292;
                //Ingredientdrid.Columns[4].ItemStyle.Width = 290;

                DataSet dreceipegrid = objbs.ReceipegridBind(Convert.ToInt32(lblUserID.Text));
                gvReceipe.DataSource = dreceipegrid.Tables[0];
                gvReceipe.DataBind();
            }
            }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
        }

        protected void Add1_Click(object sender, EventArgs e)
        {
            int insert = objbs.insert_ingredients(txtingre.Text, txtsupplier.Text, Convert.ToDouble(txtcost.Text),Convert.ToDouble(txtkgbox.Text));

        }

        protected void Add2_Click(object sender, EventArgs e)
        {
            int save = objbs.insert_receipeName(txtreceipename.Text, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(0), Convert.ToString(ddltype.SelectedItem.Text));

            Response.Redirect("Recipe.aspx?ID=" + save);
        }

        protected void gvReceipe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                txtreceipename.Text = "0";
            }
            else if (e.CommandName == "editrow")
            {
                DataSet dRec = objbs.getReceipe(Convert.ToInt32(lblUserID.Text),Convert.ToInt32(e.CommandArgument.ToString()));

                if (dRec.Tables[0].Rows.Count > 0)
                {
                    txtreceipename.Text = dRec.Tables[0].Rows[0]["ReceipeName"].ToString();
                }
            }
        }
    }
}