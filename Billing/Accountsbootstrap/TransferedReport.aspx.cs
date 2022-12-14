using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.IO;
namespace Billing
{
    public partial class TransferedReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();

            if (!IsPostBack)
            {
                txtfromdate.Text = DateTime.Now.ToShortDateString();
                txttoDate.Text = DateTime.Now.ToShortDateString();

                if (sTableName == "admin")
                {
                    ddlBranch.Visible = true;
                }
                else
                {
                    ddlBranch.Visible = false;
                }
            }
        }

        protected void btnser_Click(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                DataSet ds = objBs.TransferInter(txtfromdate.Text, txttoDate.Text, ddlBranch.SelectedValue);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds.Tables[0];
                    gv.DataBind();
                }
            }
            else
            {
                DataSet ds = objBs.TransferInter(txtfromdate.Text, txttoDate.Text, sTableName);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds.Tables[0];
                    gv.DataBind();
                }

            }
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
          GridView gridview = new GridView();
          if (sTableName == "admin")
          {
              DataSet ds = objBs.TransferInter(txtfromdate.Text, txttoDate.Text, ddlBranch.SelectedValue);

              if (ds.Tables[0].Rows.Count > 0)
              {
                  gridview.DataSource = ds.Tables[0];
                  gridview.DataBind();
              }
          }
          else
          {
              DataSet ds = objBs.TransferInter(txtfromdate.Text, txttoDate.Text, sTableName);

              if (ds.Tables[0].Rows.Count > 0)
              {
                  gridview.DataSource = ds.Tables[0];
                  gridview.DataBind();
              }

          }
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=StockTransfer.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }
    }
}