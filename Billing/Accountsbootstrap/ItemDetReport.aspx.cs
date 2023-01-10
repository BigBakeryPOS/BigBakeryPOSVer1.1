using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class ItemDetReport : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Description ASC";
        string Sort_Direction1 = "category ASC";
        string Rate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                Rate = Request.Cookies["userInfo"]["Rate"].ToString();
                DataSet ds1 = objBs.gridcustomer();
                gridview.DataSource = ds1;
                gridview.DataBind();
            

        }

        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("itempage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue == "1")
            {
                DataSet ds = objBs.categorysrch(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Category!";
                }
            }
            else if (ddlcategory.SelectedValue == "2")
            {
                DataSet ds = objBs.srchbydef(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Description!";
                }


            }
            else
            {
                DataSet ds = objBs.SearchSerial(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Description!";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DescriptionGrid.aspx");
            Response.Redirect("ItemDetReport.aspx");
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds1 = objBs.gridcustomer();
            gridview.DataSource = ds1;
            gridview.DataBind();

            DataSet ds = objBs.gridcustomer();
            gridview.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gridview.DataSource = dvEmployee;
            gridview.DataBind();

        }

        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {
           

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();
            DataSet ds = new DataSet();
            ds = objBs.gridcustomer1();
            gridview.DataSource = ds;
            gridview.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=ItemReport.xls");
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