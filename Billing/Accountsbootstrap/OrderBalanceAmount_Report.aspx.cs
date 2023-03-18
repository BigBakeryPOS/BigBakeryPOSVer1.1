using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;


namespace Billing.Accountsbootstrap
{
    public partial class OrderBalanceAmount_Report : System.Web.UI.Page
    {


        BSClass objbs = new BSClass();

        string sTableName = "";
        string AllBranchAccess = "0";
        string Store = "";

        decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
             sTableName = Request.Cookies["userInfo"]["User"].ToString();
             AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();
            Store = Request.Cookies["userInfo"]["Store"].ToString();
             if (!IsPostBack)
             {

                 txtfromdate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                 DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                 DataSet dsbranch;
                 if (AllBranchAccess == "True")
                     dsbranch = objbs.GetBranch_New("All");
                 else
                     dsbranch = objbs.GetBranch_New(sTableName);

                 ddlBranch.DataSource = dsbranch;
                 ddlBranch.DataTextField = "BranchName";
                 ddlBranch.DataValueField = "Branchcode";
                 ddlBranch.DataBind();
                 if (AllBranchAccess == "True")
                     ddlBranch.Items.Insert(0, "All");
                 else
                     ddlBranch.Enabled = false;

                  DataSet dsgrid = new DataSet();
                DataSet ds = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {

                        dsgrid = objbs.Report_OrderBalanceAmount(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom);
                        ds.Merge(dsgrid);


                    }
                }
                else
                {
                    ds = objbs.Report_OrderBalanceAmount(ddlBranch.SelectedValue, sFrom);
                }


                  
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     gvReport.DataSource = ds;
                     gvReport.DataBind();
                     gvReport.Caption = ddlBranch.SelectedItem.Text +" Order Balance Details on  " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") ;
                 }
                 else
                 {
                     gvReport.DataSource = null;
                     gvReport.DataBind();
                     divtot.Visible = false;
                     Lbltotal.Text = "0.0";
                 }

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

        protected void btnser_Click(object sender, EventArgs e)
        {

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

              DataSet dsgrid = new DataSet();
                DataSet ds = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.Report_OrderBalanceAmount(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom);
                        ds.Merge(dsgrid);
                    }
                }
                else
                {
                    ds = objbs.Report_OrderBalanceAmount(ddlBranch.SelectedValue, sFrom);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvReport.DataSource = ds;
                    gvReport.DataBind();
                    gvReport.Caption = ddlBranch.SelectedItem.Text + " Order Balance Details on  " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy");

            }
                else
                {
                    gvReport.DataSource = null;
                    gvReport.DataBind();
                    divtot.Visible = false;
                    Lbltotal.Text = "0.0";
                }
          }


        protected void gvreport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Balance"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = String.Format("{0:n}", Total);

                divtot.Visible = true;

                Lbltotal.Text = String.Format("{0:n}", Total);
            }
        }


    }
}