using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Drawing;
namespace Billing.Accountsbootstrap
{
    public partial class Printing_Report : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = new DataSet();
            if (sTableName == "admin")
            {
                ds = objBs.getstockdetgrid_Print(sTableName);
                gvstock.DataSource = ds;
                gvstock.DataBind();

                decimal dtotal = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(ds.Tables[0].Rows[i]["StockAmount"].ToString());
                }
                lblstocktotalamt.InnerText = string.Format("{0:N2}", dtotal);
            }
            else
            {
                ds = objBs.getstockdetgrid_dealerPrint(sTableName);
                gvstock.DataSource = ds;
                gvstock.DataBind();
            }




            DataSet dlow = objBs.stockcolour(sTableName);

            gvlowstock.DataSource = dlow;

            gvlowstock.DataBind();

        }

        protected void page_change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = new DataSet();
            gvstock.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gvstock.DataSource = dvEmployee;
            gvstock.DataBind();
        }

        protected void gvstock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dlow = objBs.printreport_colour(sTableName);
            if (sTableName != "admin")
            {
                //gvstock.Columns[4].Visible=false;
                gvstock.Columns[5].Visible = false;
            }
            if (dlow.Tables[0].Rows.Count > 0)
            {
                decimal iMinQty = Convert.ToDecimal(dlow.Tables[0].Rows[0]["MinQty"].ToString());
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int dStock = Convert.ToInt32(e.Row.Cells[3].Text);
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        if (dStock <= iMinQty)
                        {
                            cell.BackColor = Color.Yellow;
                        }
                        if (dStock <= 0)
                        {
                            cell.BackColor = Color.Red;
                        }
                    }
                }
            }

        }

        protected void ddlstock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            if (ddlstock.SelectedValue == "1")
            {
                DataSet dzero = objBs.zero_PrintingReport(sTableName);
                gvstock.DataSource = dzero.Tables[0];
                gvstock.DataBind();
            }
            if (ddlstock.SelectedValue == "2")
            {
                DataSet dNegative = objBs.negativeStock();
                gvstock.DataSource = dNegative.Tables[0];
                gvstock.DataBind();
            }
            if (ddlstock.SelectedValue == "3")
            {
                DataSet dMinim = objBs.minStock(sTableName);
                gvstock.DataSource = dMinim.Tables[0];
                gvstock.DataBind();

            }
        }
    }
}