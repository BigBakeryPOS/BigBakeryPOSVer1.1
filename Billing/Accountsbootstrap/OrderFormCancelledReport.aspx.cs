using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;



using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class OrderFormCancelledReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string AllBranchAccess = "0";
        string Store = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Store = Request.Cookies["userInfo"]["Store"].ToString();

            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();


            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            if (!IsPostBack)
            {
                txtfromdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DataSet ds = new DataSet();
                string from = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                string TO = Convert.ToDateTime(txttodate.Text).ToString("yyyy-MM-dd");


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
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        //ds = objbs.OrderFormCancel(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), from, TO);
                        //dsgrid.Merge(ds);
                        dsgrid = objbs.OrderFormCancel(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), from, TO);
                        ds.Merge(dsgrid);

                    }
                }
                else
                {
                    ds = objbs.OrderFormCancel(ddlBranch.SelectedValue, from, TO);
                }

                //if (sTableName == "admin")
                //{
                //    ds = objbs.OrderFormCancel(ddlBranch.SelectedValue, from, TO);
                //}
                //else
                //{
                //    ds = objbs.OrderFormCancel(sTableName, from, TO);
                //}

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvOrderForm.DataSource = ds.Tables[0];
                    gvOrderForm.DataBind();
                    gvOrderForm.Caption = Store + " OrderForm Canclled Report from " + txtfromdate.Text + " to " + txttodate.Text;
                }
                else
                {
                    gvOrderForm.DataSource = null;
                    gvOrderForm.DataBind();
                }

                //if (sTableName != "admin")
                //{
                //    admin.Visible = false;

                //}
                //else
                //{

                //}
            }
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet dsgrid = new DataSet();
            string from = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
            string TO = Convert.ToDateTime(txttodate.Text).ToString("yyyy-MM-dd");
            //if (sTableName == "admin")
            //{
            //    ds = objbs.OrderFormCancel(ddlBranch.SelectedValue, from, TO);
            //}
            //else
            //{
            //    ds = objbs.OrderFormCancel(sTableName, from, TO);
            //}
            if (ddlBranch.SelectedValue == "All")
            {
               DataSet ds1 = objbs.GetBranch_New("All");
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dsgrid = objbs.OrderFormCancel(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), from, TO);
                    ds.Merge(dsgrid);

                }
            }
            else
            {
                ds = objbs.OrderFormCancel(ddlBranch.SelectedValue, from, TO);
            }

           
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvOrderForm.DataSource = ds.Tables[0];
                gvOrderForm.DataBind();
                gvOrderForm.Caption = Store + " OrderForm Canclled Report from " + txtfromdate.Text + " to " + txttodate.Text;
            }
            else
            {
                gvOrderForm.DataSource = null;
                gvOrderForm.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet dsgrid = new DataSet();
            string from = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
            string TO = Convert.ToDateTime(txttodate.Text).ToString("yyyy-MM-dd");

            if (ddlBranch.SelectedValue == "All")
            {
                DataSet ds1 = objbs.GetBranch_New("All");
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dsgrid = objbs.OrderFormCancel(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), from, TO);
                    ds.Merge(dsgrid);
                    gvOrderForm.Caption = Store + " OrderForm Cancelled Report from " + txtfromdate.Text + " to " + txttodate.Text;
                }
            }
            else
            {
                ds = objbs.OrderFormCancel(ddlBranch.SelectedValue, from, TO);
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvOrderForm.DataSource = ds.Tables[0];
                gvOrderForm.DataBind();
            }
            else
            {
                gvOrderForm.DataSource = null;
                gvOrderForm.DataBind();
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                //update 22/10/21

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    //  ds.Tables[0].Rows[i]["CancelDate"] = DateTime.ParseExact(ds.Tables[0].Rows[i]["CancelDate"].ToString(), "dd/MMM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                //    // ds.Tables[0].Rows[i]["CancelDate"]= Convert.ToDateTime(ds.Tables[0].Rows[i]["CancelDate"]).ToString("dd/MMM/yyyy hh:mm:ss tt",CultureInfo.InvariantCulture);
                //    // ds.Tables[0].Rows[i]["OrderDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["OrderDate"]).ToString("dd/MMM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                //    // ds.Tables[0].Rows[i]["DeliveryDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeliveryDate"]).ToString("dd/MMM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                //    ds.Tables[0].Rows[i]["OrderDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["OrderDate"]).ToString("dd/MMM/yyyy hh:mm:ss tt");
                //    ds.Tables[0].Rows[i]["DeliveryDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeliveryDate"]).ToString("dd/MMM/yyyy");
                //}
                //end update





                string filename = "OrderForm_Cancel_Report.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = ds;
                dgGrid.DataBind();
                dgGrid.Caption = Store + " OrderForm Cancelled Report from " + txtfromdate.Text + " to " + txttodate.Text;
                dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                dgGrid.HeaderStyle.Font.Bold = true;
                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
            else
            {

            }
        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            //////if (sTableName != "admin")
            //////{
            //////    DateTime date = Convert.ToDateTime(txtfromdate.Text);
            //////    DateTime Toady = DateTime.Now.Date; ;

            //////    var days = date.Day;
            //////    var toda = Toady.Day;

            //////    if ((toda - days) <= 2)
            //////    {

            //////    }

            //////    else
            //////    {
            //////        txtfromdate.Text = "";
            //////    }
            //////}


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
    }
}