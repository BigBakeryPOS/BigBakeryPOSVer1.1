using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class Price__Master : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            ds = objBs.Price_Master();
            gvcust.DataSource = ds;
            gvcust.DataBind();
        }

      
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

            ds = objBs.Price_Master();
            gvcust.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gvcust.DataSource = dvEmployee;
            gvcust.DataBind();

        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("customerupdate.aspx?iCusID=" + e.CommandArgument.ToString());

                }
            }
        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            GridView gvcust = new GridView();
            gvcust.DataSource = objBs.Price_Master();
            gvcust.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=PriceMaster.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gvcust.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            ds = objBs.SearchItem_PriceMaster(txtser.Text);
                gvcust.DataSource=ds;
            gvcust.DataBind();
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ds = objBs.Price_Master();
            gvcust.DataSource = ds;
            gvcust.DataBind();
        }
    }
}