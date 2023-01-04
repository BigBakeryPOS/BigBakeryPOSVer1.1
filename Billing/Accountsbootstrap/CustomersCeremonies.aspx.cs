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
using System.Diagnostics;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class CustomersCeremonies : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;

        double Qty = 0;
        string AllBranchAccess = "0";
        string brach = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName =  Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            if (!IsPostBack)
            {

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objBs.GetBranch_New("All");
                else
                    dsbranch = objBs.GetBranch_New(sTableName);

                ddlbranch.DataSource = dsbranch;
                ddlbranch.DataTextField = "BranchName";
                ddlbranch.DataValueField = "Branchcode";
                ddlbranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlbranch.Items.Insert(0, "All");
                else
                    ddlbranch.Enabled = false;
              


                //DataSet ds = objBs.Getceremoniesordersall(sTableName);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    gvsales.DataSource = ds;
                //    gvsales.DataBind();
                //}
                //else
                //{
                //    gvsales.DataSource = null;
                //    gvsales.DataBind();
                //}
                #region

               // DataSet dsCustomer = objBs.getgridforcustsale();
                DataSet dsCustomer = objBs.getcustomers(sTableName);
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dsCustomer.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "CustomerId";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "All");
                }
              
               
                #endregion

                GridBind();
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }

        protected void search1(object sender, EventArgs e)
        {

            DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet dsgrid = new DataSet();

            if (ddlbranch.SelectedValue == "All")
            {
                DataSet ds = objBs.GetBranch_New("All");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds1 = objBs.Getceremoniesorders(ds.Tables[0].Rows[i]["BranchCode"].ToString(), ddlcustomer.SelectedValue, frmdate, todate);
                    //dsgrid.Tables.Add(ds1.Tables[0]);
                    dsgrid.Merge(ds1);
                }
            }
            else
            {
                dsgrid = objBs.Getceremoniesorders(ddlbranch.SelectedValue, ddlcustomer.SelectedValue, frmdate, todate);
            }


            if (dsgrid.Tables[0].Rows.Count > 0)
            {
                gvsales.DataSource = dsgrid;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }
        }
        //protected void search2(object sender, EventArgs e)
        //{
        //   search(sender, e);
           
        //}
       
        //protected void search(object sender, EventArgs e)
        //{
        //    //DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    //DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    //DataSet ds = objBs.Getceremoniesorders(sTableName, ddlcustomer.SelectedValue, frmdate, todate);
        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //{
        //    //    gvsales.DataSource = ds;
        //    //    gvsales.DataBind();
        //    //}
        //    //else
        //    //{
        //    //    gvsales.DataSource = null;
        //    //    gvsales.DataBind();
        //    //}

        //       DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    DataSet dsgrid = new DataSet();

        //    if (ddlbranch.SelectedValue == "All")
        //    {
        //        DataSet ds = objBs.GetBranch_New("All");

        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            DataSet ds1 = objBs.Getceremoniesorders(ds.Tables[0].Rows[i]["BranchCode"].ToString(), ddlcustomer.SelectedValue, frmdate, todate);
        //            //dsgrid.Tables.Add(ds1.Tables[0]);
        //            dsgrid.Merge(ds1);
        //        }
        //    }
        //    else
        //    {
        //        dsgrid = objBs.Getceremoniesorders(ddlbranch.SelectedValue, ddlcustomer.SelectedValue, frmdate, todate);
        //    }


        //    if (dsgrid.Tables[0].Rows.Count > 0)
        //    {
        //        gvsales.DataSource = dsgrid;
        //        gvsales.DataBind();
        //    }
        //    else
        //    {
        //        gvsales.DataSource = null;
        //        gvsales.DataBind();
        //    }
        //}
        
        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = Qty.ToString("f2");

            }
        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
        GridBind();
    }

        private void GridBind()
        {
            DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet dsgrid = new DataSet();

            if (ddlbranch.SelectedValue == "All")
            {
                DataSet ds = objBs.GetBranch_New("All");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds1 = objBs.Getceremoniesorders(ds.Tables[0].Rows[i]["BranchCode"].ToString(), ddlcustomer.SelectedValue, frmdate, todate);
                    //dsgrid.Tables.Add(ds1.Tables[0]);
                    dsgrid.Merge(ds1);
                }
            }
            else
            {
                dsgrid = objBs.Getceremoniesorders(ddlbranch.SelectedValue, ddlcustomer.SelectedValue, frmdate, todate);
            }


            if (dsgrid.Tables[0].Rows.Count > 0)
            {
                gvsales.DataSource = dsgrid;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }
        }

        protected void ddlcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet dsgrid = new DataSet();

            if (ddlbranch.SelectedValue == "All")
            {
                DataSet ds = objBs.GetBranch_New("All");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataSet ds1 = objBs.Getceremoniesorders(ds.Tables[0].Rows[i]["BranchCode"].ToString(), ddlcustomer.SelectedValue, frmdate, todate);
                    //dsgrid.Tables.Add(ds1.Tables[0]);
                    dsgrid.Merge(ds1);
                }
            }
            else
            {
                dsgrid = objBs.Getceremoniesorders(ddlbranch.SelectedValue, ddlcustomer.SelectedValue, frmdate, todate);
            }


            if (dsgrid.Tables[0].Rows.Count > 0)
            {
                gvsales.DataSource = dsgrid;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }
        }
    }


}