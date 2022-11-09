using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;


namespace Billing
{
    public partial class POGrid : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = objBs.GetPODet();
            gridview.DataSource = ds;
            gridview.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("POForm.aspx");
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("POGrid.aspx");
        }
        protected void Btn_Search(object sender, EventArgs e)
        {
            DataSet ds = objBs.CustomerSearch(txtsearch.Text);
            gridview.DataSource = ds;
            gridview.DataBind();

        }

        protected void gvPO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("POForm.aspx?iPo=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "Print")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("POPrint.aspx?iPo=" + e.CommandArgument.ToString());
                }
            }

        }


        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

            DataSet ds = objBs.GetPODet();
            gridview.PageIndex = e.NewPageIndex;
            gridview.DataBind();



        }
    }
}