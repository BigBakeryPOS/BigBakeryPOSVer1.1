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
using FreeTextBoxControls;
using DocumentFormat.OpenXml.VariantTypes;

namespace Billing.Accountsbootstrap
{
    public partial class BillSetting : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        string isadmin = string.Empty;
        string Notpaid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            isadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();

            DataSet checknotpaid = objBs.NotpadiBillexisitsOrNot(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            if (checknotpaid.Tables[0].Rows.Count > 0)
            {
                Notpaid = "Yes";
            }
            else
            {
                Notpaid = "No";
            }
            if (!IsPostBack)
            {
                FirstGridViewRow();
                btnnew_Click1(sender, e);
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                if (isadmin == "1")
                {
                    txtFromDate.Enabled = true;
                }
                else
                {
                    txtFromDate.Enabled = false;
                }




                DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }

                DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gridcash.DataSource = dscash;
                gridcash.DataBind();


                DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gridcard.DataSource = dscard;
                gridcard.DataBind();

            }
        }

        protected void Bill_chnage(object sender, EventArgs e)
        {
            DataSet ds = objBs.CustomerSalesGirdNewbillsetting_search(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, "No", txtAutoName.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvsales.DataSource = ds;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }
        }

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mpayment")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string salesid = commandArgs[0];
                string billno = commandArgs[1];
                string Amount = commandArgs[2];

                lblsalesid.Text = salesid;
                lbllbillno.Text = billno;
                lblamount.Text = Amount;



                // getold payment details
                DataSet getoldpayment = objBs.getsales_transamount(sTableName, lblsalesid.Text);
                if (getoldpayment.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = getoldpayment;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

                mpe.Show();
            }
        }

        protected void Yes_click(object sender, EventArgs e)
        {
            if (lblsalesid.Text != "0")
            {
                //lblamount
                double tot = 0;
                for (int vLoop = 0; vLoop < gvpayment.Rows.Count; vLoop++)
                {
                    DropDownList drppayment = (DropDownList)gvpayment.Rows[vLoop].FindControl("drppayment");
                    TextBox txtamount = (TextBox)gvpayment.Rows[vLoop].FindControl("txtamount");

                    if (drppayment.SelectedValue == "Select Paymode")
                    {
                        if (txtamount.Text == "0")
                        {

                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Paymode.Thank You!!!.');", true);
                            //drppayment.Focus();
                            //mpe.Show();
                            //return;
                        }
                    }
                    else
                    {
                        if (txtamount.Text == "")
                            txtamount.Text = "0";
                        //int iinsert = objBs.iupdatetranssalesamount("tblTranssalesAmount_" + sTableName + "", salesid, billno, Billdate, SalesTypeid, drppayment.SelectedValue, txtamount.Text, BillerId, Attenderid, lblmulticheck.Text, Currency);
                        tot += Convert.ToDouble(txtamount.Text);


                    }


                }
                if (tot == Convert.ToDouble(lblamount.Text))
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Given Amount Not Matched .Thank You!!!.');", true);
                    mpe.Show();
                    return;
                }
                DataSet getsales = objBs.getsales_payment(sTableName, (lblsalesid.Text));
                if (getsales.Tables[0].Rows.Count > 0)
                {
                    string salesid = getsales.Tables[0].Rows[0]["salesid"].ToString();
                    string billno = getsales.Tables[0].Rows[0]["billno"].ToString();
                    string ipaymode = getsales.Tables[0].Rows[0]["ipaymode"].ToString();

                    string Billdate = Convert.ToDateTime(getsales.Tables[0].Rows[0]["Billdate"]).ToString("yyyy-MM-dd hh:mm tt");
                    string SalesTypeid = getsales.Tables[0].Rows[0]["SalesType"].ToString();
                    string Amount = getsales.Tables[0].Rows[0]["total"].ToString();
                    string BillerId = getsales.Tables[0].Rows[0]["BillerId"].ToString();
                    string Attenderid = getsales.Tables[0].Rows[0]["Attender"].ToString();
                    //string SalesPaymodeid = getsales.Tables[0].Rows[0]["SalesPaymodeid"].ToString();
                    string Currency = getsales.Tables[0].Rows[0]["Currencytype"].ToString();



                    // Update salesid
                    int iupdate = objBs.iupdatesales(sTableName, lblmulticheck.Text, salesid, billno);

                    //Insert transamountsales
                    for (int vLoop = 0; vLoop < gvpayment.Rows.Count; vLoop++)
                    {
                        DropDownList drppayment = (DropDownList)gvpayment.Rows[vLoop].FindControl("drppayment");
                        TextBox txtamount = (TextBox)gvpayment.Rows[vLoop].FindControl("txtamount");

                        if (drppayment.SelectedValue == "Select Paymode")
                        {
                            if (txtamount.Text == "0")
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Paymode.Thank You!!!.');", true);
                                drppayment.Focus();
                                mpe.Show();
                                return;
                            }
                        }
                        else
                        {
                            int iinsert = objBs.iupdatetranssalesamount("tblTranssalesAmount_" + sTableName + "", salesid, billno, Billdate, SalesTypeid, drppayment.SelectedValue, txtamount.Text, BillerId, Attenderid, lblmulticheck.Text, Currency);
                        }
                    }


                }

                DataSet checknotpaid = objBs.NotpadiBillexisitsOrNot(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                if (checknotpaid.Tables[0].Rows.Count > 0)
                {
                    Notpaid = "Yes";
                }
                else
                {
                    Notpaid = "No";
                }

                DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }

                DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gridcash.DataSource = dscash;
                gridcash.DataBind();


                DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gridcard.DataSource = dscard;
                gridcard.DataBind();

            }
        }

        protected void radselect_All(object sender, EventArgs e)
        {
            for (int i = 0; i < gvsales.Rows.Count; i++)
            {
                RadioButtonList radbtn = (RadioButtonList)gvsales.Rows[i].FindControl("lblradtype");

                if (allradselect.SelectedValue == "1")
                {
                    radbtn.SelectedValue = "1";
                }
                else
                {
                    radbtn.SelectedValue = "4";
                }
            }

            DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcard.DataSource = dscard;
            gridcard.DataBind();
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

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }

        protected void refresh_Click(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.DataSource = ds;
            gvsales.DataBind();
            //gvCustsales.Visible = false;

        }
        protected void process_Click(object sender, EventArgs e)
        {

            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objBs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }

            int isucess = 0;
            for (int i = 0; i < gvsales.Rows.Count; i++)
            {
                RadioButtonList radbtn = (RadioButtonList)gvsales.Rows[i].FindControl("lblradtype");
                Label lblsalesid = (Label)gvsales.Rows[i].FindControl("lblsalesid");
                Label lblipaymode = (Label)gvsales.Rows[i].FindControl("lblipaymode");

                if (lblipaymode.Text == "20")
                {

                }
                else
                {

                    string salesid = lblsalesid.Text;
                    if (radbtn.SelectedIndex >= 0)
                    {
                        if (radbtn.SelectedValue == "1")
                        {
                            isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);

                        }
                        else if (radbtn.SelectedValue == "4")
                        {
                            isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                        }
                        else if (radbtn.SelectedValue == "10")
                        {
                            isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                        }
                        else if (radbtn.SelectedValue == "17")
                        {
                            isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                        }
                        else
                        {
                            isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                        }
                    }
                }

            }

            DataSet checknotpaid = objBs.NotpadiBillexisitsOrNot(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            if (checknotpaid.Tables[0].Rows.Count > 0)
            {
                Notpaid = "Yes";
            }
            else
            {
                Notpaid = "No";
            }

            DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvsales.DataSource = ds;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }

            DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcard.DataSource = dscard;
            gridcard.DataBind();

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvsales.DataSource = ds;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }

            DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcard.DataSource = dscard;
            gridcard.DataBind();



        }






        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void txtAutoName_TextChanged(object sender, EventArgs e)
        {

        }



        public void gvsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Get the value of column from the DataKeys using the RowIndex.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(gvsales.DataKeys[e.Row.RowIndex].Values[0]);
                string salestypeid = gvsales.DataKeys[e.Row.RowIndex].Values[1].ToString();
                RadioButtonList lblradtype = ((RadioButtonList)e.Row.FindControl("lblradtype"));
                // Get paymode

                DataSet paymode = objBs.PaymodevaluesNew(salestypeid);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    lblradtype.DataSource = paymode.Tables[0];
                    lblradtype.DataTextField = "PayMode";
                    lblradtype.DataValueField = "Value";
                    lblradtype.DataBind();
                }
                else
                {

                }




            }
        }


        #region DYNAMIC GRID

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Payment", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));

            dr = dt.NewRow();

            dr["Payment"] = string.Empty;
            dr["Amount"] = string.Empty;


            dt.Rows.Add(dr);



            ViewState["CurrentTable"] = dt;
            gvpayment.DataSource = dt;
            gvpayment.DataBind();



        }

        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                        DropDownList drppayment = (DropDownList)gvpayment.Rows[rowIndex].Cells[1].FindControl("drppayment");
                        TextBox txtamount = (TextBox)gvpayment.Rows[rowIndex].Cells[3].FindControl("txtamount");




                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["Payment"] = drppayment.SelectedValue;

                        dtCurrentTable.Rows[i - 1]["Amount"] = txtamount.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvpayment.DataSource = dtCurrentTable;
                    gvpayment.DataBind();


                }



            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList drppayment = (DropDownList)gvpayment.Rows[rowIndex].Cells[1].FindControl("drppayment");

                        TextBox txtamount = (TextBox)gvpayment.Rows[rowIndex].Cells[3].FindControl("txtamount");


                        if (dt.Rows[i]["amount"].ToString() != "")
                        {

                            drppayment.SelectedValue = dt.Rows[i]["Payment"].ToString();
                            txtamount.Text = dt.Rows[i]["amount"].ToString();


                            rowIndex++;
                        }

                    }
                }
            }
        }

        protected void gridorder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gvpayment.DataSource = dt;
                    gvpayment.DataBind();

                    SetPreviousData();

                }
                else
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gvpayment.DataSource = dt;
                    gvpayment.DataBind();

                    FirstGridViewRow();
                    SetPreviousData();
                }
            }
            mpe.Show();
        }

        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList drppayment = (DropDownList)gvpayment.Rows[rowIndex].Cells[1].FindControl("drppayment");

                        TextBox txtamount = (TextBox)gvpayment.Rows[rowIndex].Cells[3].FindControl("txtamount");


                        drCurrentRow = dtCurrentTable.NewRow();


                        dtCurrentTable.Rows[i - 1]["Payment"] = drppayment.SelectedValue;



                        dtCurrentTable.Rows[i - 1]["Amount"] = txtamount.Text;

                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;

                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void btnnew_Click1(object sender, EventArgs e)
        {


            #region
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            //for (int vLoop = 0; vLoop < gvpayment.Rows.Count; vLoop++)
            //{
            //    DropDownList txti = (DropDownList)gvpayment.Rows[vLoop].FindControl("drppayment");


            //    itemc = txti.Text;


            //    if ((itemc == null) || (itemc == ""))
            //    {
            //    }
            //    else
            //    {
            //        for (int vLoop1 = 0; vLoop1 < gvpayment.Rows.Count; vLoop1++)
            //        {
            //            DropDownList txt1 = (DropDownList)gvpayment.Rows[vLoop1].FindControl("drppayment");
            //            if (txt1.Text == "")
            //            {
            //            }
            //            else
            //            {

            //                if (ii == iq)
            //                {
            //                }
            //                else
            //                {
            //                    if (itemc == txt1.Text)
            //                    {
            //                        itemcd = txti.SelectedItem.Text;
            //                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);

            //                        txt1.Focus();

            //                        return;

            //                    }
            //                }
            //                ii = ii + 1;
            //            }
            //        }
            //    }
            //    iq = iq + 1;
            //    ii = 1;

            //    txti.Focus();
            //}


            #endregion

            {
                int j = 0;
                while (j < Convert.ToInt16(1))
                {
                    int rowIndex = 0;

                    if (ViewState["CurrentTable"] != null)
                    {
                        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        DataRow drCurrentRow = null;
                        if (dtCurrentTable.Rows.Count > 0)
                        {
                            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                            {
                                //extract the TextBox values
                                DropDownList drppayment = (DropDownList)gvpayment.Rows[rowIndex].Cells[1].FindControl("drppayment");
                                TextBox txtamount = (TextBox)gvpayment.Rows[rowIndex].Cells[2].FindControl("txtamount");


                                drCurrentRow = dtCurrentTable.NewRow();
                                // drCurrentRow["RowNumber"] = i + 1;

                                dtCurrentTable.Rows[i - 1]["Payment"] = drppayment.SelectedValue;
                                dtCurrentTable.Rows[i - 1]["Amount"] = txtamount.Text;


                                rowIndex++;
                            }
                            dtCurrentTable.Rows.Add(drCurrentRow);
                            ViewState["CurrentTable"] = dtCurrentTable;

                            gvpayment.DataSource = dtCurrentTable;
                            gvpayment.DataBind();
                        }
                    }
                    else
                    {
                        Response.Write("ViewState is null");
                    }

                    //Set Previous Data on Postbacks
                    SetPreviousData();
                    j++;
                }
            }
            AddNewRow();
            //mpe.Show();
        }
        protected void btnnew_Click(object sender, EventArgs e)
        {


            #region
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            //for (int vLoop = 0; vLoop < gvpayment.Rows.Count; vLoop++)
            //{
            //    DropDownList txti = (DropDownList)gvpayment.Rows[vLoop].FindControl("drppayment");


            //    itemc = txti.Text;


            //    if ((itemc == null) || (itemc == ""))
            //    {
            //    }
            //    else
            //    {
            //        for (int vLoop1 = 0; vLoop1 < gvpayment.Rows.Count; vLoop1++)
            //        {
            //            DropDownList txt1 = (DropDownList)gvpayment.Rows[vLoop1].FindControl("drppayment");
            //            if (txt1.Text == "")
            //            {
            //            }
            //            else
            //            {

            //                if (ii == iq)
            //                {
            //                }
            //                else
            //                {
            //                    if (itemc == txt1.Text)
            //                    {
            //                        itemcd = txti.SelectedItem.Text;
            //                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);

            //                        txt1.Focus();

            //                        return;

            //                    }
            //                }
            //                ii = ii + 1;
            //            }
            //        }
            //    }
            //    iq = iq + 1;
            //    ii = 1;

            //    txti.Focus();
            //}


            #endregion

            //{
            //    int j = 0;
            //    while (j < Convert.ToInt16(4))
            //    {
            //        int rowIndex = 0;

            //        if (ViewState["CurrentTable"] != null)
            //        {
            //            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            //            DataRow drCurrentRow = null;
            //            if (dtCurrentTable.Rows.Count > 0)
            //            {
            //                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            //                {
            //                    //extract the TextBox values
            //                    DropDownList drppayment = (DropDownList)gvpayment.Rows[rowIndex].Cells[1].FindControl("drppayment");
            //                    TextBox txtamount = (TextBox)gvpayment.Rows[rowIndex].Cells[2].FindControl("txtamount");


            //                    drCurrentRow = dtCurrentTable.NewRow();
            //                   // drCurrentRow["RowNumber"] = i + 1;

            //                    dtCurrentTable.Rows[i - 1]["Payment"] = drppayment.SelectedValue;
            //                    dtCurrentTable.Rows[i - 1]["Amount"] = txtamount.Text;


            //                    rowIndex++;
            //                }
            //                dtCurrentTable.Rows.Add(drCurrentRow);
            //                ViewState["CurrentTable"] = dtCurrentTable;

            //                gvpayment.DataSource = dtCurrentTable;
            //                gvpayment.DataBind();
            //            }
            //        }
            //        else
            //        {
            //            Response.Write("ViewState is null");
            //        }

            //        //Set Previous Data on Postbacks
            //        SetPreviousData();
            //        j++;
            //    }
            //}
            AddNewRow();
            mpe.Show();
        }

        protected void gridorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {




            DataSet dsorderuom = objBs.Get_salespaymode();

            //  DataSet dunitsval = new DataSet();
            // DataSet dunits = kbs.UNITS();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region


                DropDownList drppayment = (DropDownList)(e.Row.FindControl("drppayment") as DropDownList);
                if (dsorderuom.Tables[0].Rows.Count > 0)
                {
                    drppayment.DataSource = dsorderuom.Tables[0];
                    drppayment.DataTextField = "paymode";
                    drppayment.DataValueField = "value";
                    drppayment.DataBind();
                    drppayment.Items.Insert(0, "Select Paymode");
                }




                #endregion
            }
        }


        #endregion


    }
}