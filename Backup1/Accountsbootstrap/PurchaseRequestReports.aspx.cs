using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
namespace Billing.Accountsbootstrap
{
    public partial class PurchaseRequestReports : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtfromdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }


        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txtfromdate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txtfromdate.Text = "";
                }
            }
        }
        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseRequestReports.aspx");
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
           DataSet ds = objbs.PurchaseReqGridBranchreports(Convert.ToInt32(lblUserID.Text), sCode, txtfromdate.Text, txttodate.Text);

          
            gvPurchaseEntry.DataSource = ds;
            gvPurchaseEntry.DataBind();
        }

        //protected void gvPurchaseEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    DataSet ds = objbs.PurchaseReqGridBranchreports(Convert.ToInt32(lblUserID.Text), sCode, txtfromdate.Text, txttodate.Text);
        //    gvPurchaseEntry.PageIndex = e.NewPageIndex;
        //    gvPurchaseEntry.DataSource = ds;
        //    gvPurchaseEntry.DataBind();
        //}
        protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvdetails") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objbs.Report_StockReqDetails(groupID, sCode);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        gv.DataBind();
                    }

               }

            }
        }

       
    }
}