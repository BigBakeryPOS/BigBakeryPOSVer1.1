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
using System.Configuration;
using System.Data.SqlClient;

namespace Billing
{
    public partial class SalesGrid : System.Web.UI.Page
    {

        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        string superadmin = "";
        DBAccess DBAccess = new DBAccess();
        private string connnectionString;
        private string connnectionStringMain;
        string OnliOrder = "N";
        string MOnliOrder = "N";
        string BranchID = "";
        string fssaino = "Nil";

        string taxsetting = "";
        string ratesetting = "";
        string qtysetting = "";
        string currency = "";



        string PrintOption = "Nil";
        string StockOption = "Nil";

        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            OnliOrder = Request.Cookies["userInfo"]["LOnlSale"].ToString();
            MOnliOrder = Request.Cookies["userInfo"]["MOnlSale"].ToString();
            BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();
            fssaino = Request.Cookies["userInfo"]["fssaino"].ToString();

            PrintOption = Request.Cookies["userInfo"]["PrintOption"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();

            taxsetting = Request.Cookies["userInfo"]["TaxSetting"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            currency = Request.Cookies["userInfo"]["Currency"].ToString();

            DataSet dchk = objBs.checkmailID(Convert.ToInt32(lblUserID.Text));
            if (dchk.Tables[0].Rows[0]["status"].ToString() == "Windows")
            {
                Response.Redirect("Home_Page.aspx");
            }

            if (!IsPostBack)
            {
                DataSet ds = objBs.CustomerSalesGirdNew(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();
                //if (sTableName.ToString().ToLower() == "co6" || sTableName.ToString().ToLower() == "co7")
                //{
                //    gvsales.Columns[5].Visible = true;
                //    gvsales.Columns[6].Visible = true;
                //}
                //else
                //{
                //    gvsales.Columns[5].Visible = false;
                //    gvsales.Columns[6].Visible = false;
                //}

                DataSet dsCategory = objBs.selectbillno(sTableName);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlbillno.DataSource = dsCategory.Tables[0];
                    ddlbillno.DataTextField = "Customer";
                    ddlbillno.DataValueField = "CustomerID";
                    ddlbillno.DataBind();
                    ddlbillno.Items.Insert(0, "Select You Contact");


                }

                DataSet dsCategory1 = objBs.CustomerNameID(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()));
                if (dsCategory1.Tables[0].Rows.Count > 0)
                {
                    ddlcustomername.DataSource = dsCategory1.Tables[0];
                    ddlcustomername.DataTextField = "Area";

                    //ddlcustomername.DataValueField = "CustomerID";
                    ddlcustomername.DataBind();
                    ddlcustomername.Items.Insert(0, "Select Customer Name and Area");


                }


            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("newbutton.aspx");
            //System.Diagnostics.ProcessStartInfo startInfo;

            //Process p = new Process();

            //startInfo = new System.Diagnostics.ProcessStartInfo(@"E:\magil hotel\magilam\magilam\bin\Debug\magilam.exe");
            //p.StartInfo = startInfo;

            //p.Start();


        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.PageIndex = e.NewPageIndex;
            gvsales.DataSource = ds;
            gvsales.DataBind();


        }
        protected void refresh_Click(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.DataSource = ds;
            gvsales.DataBind();
            gvCustsales.Visible = false;
            //if (sTableName.ToString().ToLower() == "co6" || sTableName.ToString().ToLower() == "co7")
            //{
            //    gvsales.Columns[5].Visible = true;
            //    gvsales.Columns[6].Visible = true;
            //}
            //else
            //{
            //    gvsales.Columns[5].Visible = false;
            //    gvsales.Columns[6].Visible = false;
            //}

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            //string sCustomer = ddlcustomername.SelectedValue;
            //string[] sFull = sCustomer.Split('-');
            //string sCustomerName = sFull[0].ToString();
            //string sArea = sFull[1].ToString();

            DataSet ds = objBs.CustomerSalesGirdnamearea(Convert.ToInt32(ddlbillno.SelectedValue), sTableName);
            //DataSet ds = objBs.CustomerSalesGirdbillNo(ddlbillno.SelectedValue);
            gvsales.DataSource = ds;
            gvsales.DataBind();




        }


        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbltax = ((Label)e.Row.FindControl("lbltax"));
                Label lblnetamount = ((Label)e.Row.FindControl("lblnetamount"));
                Label lbltotalamount = ((Label)e.Row.FindControl("lbltotalamount"));

                lbltax.Text = Convert.ToDouble(lbltax.Text).ToString("" + ratesetting + "");
                lblnetamount.Text = Convert.ToDouble(lblnetamount.Text).ToString("" + ratesetting + "");
                lbltotalamount.Text = "" + currency + " " + Convert.ToDouble(lbltotalamount.Text).ToString("" + ratesetting + "");
            }
            //////if (e.Row.RowType == DataControlRowType.DataRow)
            //////{
            //////    if (superadmin == "1")
            //////    {
            //////        ((LinkButton)e.Row.FindControl("btndelete")).Visible = true;
            //////        ((Image)e.Row.FindControl("Image1")).Visible = false;

            //////    }
            //////    else
            //////    {
            //////        ((LinkButton)e.Row.FindControl("btndelete")).Visible = false;
            //////        ((Image)e.Row.FindControl("Image1")).Visible = true;

            //////    }

            //////}
            //////else
            //////{
            //////    //((Image)e.Row.FindControl("imdedit")).Visible = false;
            //////    //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;

            //////    //((Image)e.Row.FindControl("Image1")).Visible = false;
            //////    //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;
            //////}

        }
        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("cashsales.aspx?iSalesID=" + e.CommandArgument.ToString());
                }
            }
            else if (e.CommandName == "cancel")
            {

                refre.Visible = true;
                if (txtRef.Text != "")
                {


                    DataSet dch = objBs.checkingRights(txtRef.Text);
                    if (dch.Tables[0].Rows.Count > 0)
                    {
                        if (objBs.CheckIfnormalsales((Convert.ToInt32(e.CommandArgument)), sTableName))
                        {
                            int iscuss = objBs.normalsalescancel(sTableName, (Convert.ToInt32(e.CommandArgument)), txtRef.Text, sTableName, dlReason.SelectedItem.Text, OnliOrder, MOnliOrder, BranchID, ddlmainreason.SelectedItem.Text);
                            DataSet ds = objBs.CustomerSalesGirdNew(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                            gvsales.DataSource = ds;
                            gvsales.DataBind();
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Thank You " + dch.Tables[0].Rows[0]["Name"].ToString() + ".');", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);

                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter a valid MobileNo.');", true);

                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill cannot be cancelled Without Ref No.');", true);

                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                }

                //int iSucess = objBs.deletesalesgrid(e.CommandArgument.ToString());

            }
            else if (e.CommandName == "view")
            {
                DataSet ds = new DataSet();

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string billno = commandArgs[0];
                string salestypeid = commandArgs[1];

                ds = objBs.SelectedSales(sTableName, Convert.ToInt32(billno));
                gvCustsales.DataSource = ds.Tables[0];
                gvCustsales.DataBind();

            }

            else if (e.CommandName == "print")
            {
                // Response.Redirect("SalesPrint.aspx?iSalesID=" + e.CommandArgument.ToString());
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string billno = commandArgs[0];
                string salestypeid = commandArgs[1];

                string yourUrl = "";

                if (PrintOption == "1")
                {
                    yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + salestypeid + "&iSalesID=" + billno + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();
                }

                if (PrintOption == "2")
                {
                    yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + salestypeid + "&iSalesID=" + billno + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();
                }
                // string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            }
            else if (e.CommandName == "kotprint")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string billno = commandArgs[0];
                string salestypeid = commandArgs[1];


                DataSet ds1 = objBs.PrintingSalesLiveKitchen1(Convert.ToInt32(billno), sTableName, salestypeid);
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + billno + "&Type=" + salestypeid.ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString();


                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                }

            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvsales.EditIndex = -1;
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.DataSource = ds; //a dataset in my case

            //Bind data to the GridView control.
            gvsales.DataBind();
        }

        protected void txtAutoName_TextChanged(object sender, EventArgs e)
        {
            if (txtAutoName.Text == "")
            {
                DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();
                gvCustsales.Visible = false;

            }
            else
            {
                DataSet ds = objBs.autoFilterSalesGrid(Convert.ToInt32(txtAutoName.Text), sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                    gvCustsales.Visible = true;


                }
            }
        }

        protected void generate(object sender, EventArgs e)
        {
        }


        protected void cancel(object sender, EventArgs e)
        {
        }
        public void gvlialedger(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblQuantity = ((Label)e.Row.FindControl("lblQuantity"));
                Label lblUnitPrice = ((Label)e.Row.FindControl("lblUnitPrice"));
                Label lblAmount = ((Label)e.Row.FindControl("lblAmount"));
                //Label lblTotal = ((Label)e.Row.FindControl("lblTotal"));

                lblQuantity.Text = Convert.ToDouble(lblQuantity.Text).ToString("" + qtysetting + "");
                lblUnitPrice.Text = Convert.ToDouble(lblUnitPrice.Text).ToString("" + ratesetting + "");
                lblAmount.Text = Convert.ToDouble(lblAmount.Text).ToString("" + ratesetting + "");
               // lblTotal.Text = "" + currency + " " + Convert.ToDouble(lblTotal.Text).ToString("" + ratesetting + "");
            }
        }
        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    // int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Values[0]);
                    string salestype = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    DataSet ds = objBs.CustomerSalesdetailed(groupID, sTableName, salestype);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
                        amount1 = amount1 + amount;
                        gv.DataBind();
                    }
                    //}
                }

                //
                Label lblNetAmount = ((Label)e.Row.FindControl("lblNetAmount"));
                Label lblDiscount = ((Label)e.Row.FindControl("lblDiscount"));
                Label lbltax = ((Label)e.Row.FindControl("lbltax"));
                Label lblTotal = ((Label)e.Row.FindControl("lblTotal"));

                lblNetAmount.Text = Convert.ToDouble(lblNetAmount.Text).ToString("" + ratesetting + "");
                lblDiscount.Text = Convert.ToDouble(lblDiscount.Text).ToString("" + ratesetting + "");
                lbltax.Text = Convert.ToDouble(lbltax.Text).ToString("" + ratesetting + "");
                lblTotal.Text = "" + currency + " " + Convert.ToDouble(lblTotal.Text).ToString("" + ratesetting + "");
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                //e.Row.Cells[0].Text = "Total";

                //e.Row.Cells[7].Text = amount1.ToString("N2");
                //e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

            }

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionString);
            SqlConnection destination = new SqlConnection(connnectionStringMain);


            source.Open();
            destination.Open();

            SqlCommand cmdsales = new SqlCommand("Select * from tblsales_" + sTableName + " where isnull(IsTransfer,0)=0", source);
            SqlCommand cmdtranssales = new SqlCommand("Select * from tblTranssales_" + sTableName + " where isnull(IsTransfer,0)=0", source);


            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            SqlBulkCopy bulkDataUpdate = new SqlBulkCopy(source);

            SqlDataReader reader = cmdsales.ExecuteReader();
            bulkData.DestinationTableName = "tblsales_" + sTableName + "";
            bulkData.WriteToServer(reader);
            reader.Close();


            int iSuccess = 0;
            string sQry = "Update tblsales_" + sTableName + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);

            SqlDataReader reader1 = cmdtranssales.ExecuteReader();
            bulkData.DestinationTableName = "tblTranssales_" + sTableName + "";
            bulkData.WriteToServer(reader1);
            reader1.Close();

            sQry = "Update tblTranssales_" + sTableName + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);



            bulkData.Close();
            source.Close();
            destination.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }

    }
}