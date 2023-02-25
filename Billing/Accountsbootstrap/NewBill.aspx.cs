using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLayer;
using System.Data;
namespace Billing.Accountsbootstrap
{
    public partial class NewBill : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        string StockOption = "Nil";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();
            if (!Page.IsPostBack)
            {

                FirstGridViewRow();
                DataSet ds = objBs.SalesBillno("tblSales_" + sTableName,"");
                if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                    txtBillNo.Text = "1";
                else
                    txtBillNo.Text = ds.Tables[0].Rows[0]["billno"].ToString();
                txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");


                string OrderNo = Request.QueryString.Get("OrderNo");
                if (OrderNo != "")
                {
                    DataSet dBilling = objBs.CustomerOrderBilling(Convert.ToInt32(OrderNo),sTableName);
                    if (dBilling.Tables[0].Rows.Count > 0)
                    {
                        txtCustomerName.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtmobile.Text = dBilling.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtSubTotal.Text = dBilling.Tables[0].Rows[0]["NetAmount"].ToString();
                        txtAdvance.Text = dBilling.Tables[0].Rows[0]["Advance"].ToString();
                        txttotal.Text = dBilling.Tables[0].Rows[0]["Total"].ToString();
                        int iCount = dBilling.Tables[0].Rows.Count;

                        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        DataRow drCurrentRow = null;

                        for (int i = 0; i < iCount; i++)
                        {

                            TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                            TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            TextBox txtAmt = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                            DropDownList ddlCat = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlCategory");
                            DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");

                            ddlCat.SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString();


                            ddlDef.SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString();


                         decimal Qty   =Convert.ToDecimal( dBilling.Tables[0].Rows[i]["Quantity"].ToString());

                         txtQty.Text = Qty.ToString("f2");
                            txtRate.Text = dBilling.Tables[0].Rows[i]["Unitprice"].ToString();


                            txtAmt.Text = dBilling.Tables[0].Rows[i]["Amount"].ToString();

                            int rowIndex = 0;

                        //    if (ViewState["CurrentTable"] != null)
                        //    {

                        //        if (dtCurrentTable.Rows.Count > 0)
                        //        {
                        //            for (int j = 1; j <= dtCurrentTable.Rows.Count; j++)
                        //            {
                        //                DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        //                DropDownList Def = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        //                TextBox Quantity = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        //                TextBox Rate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        //                TextBox Amount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");

                        //                drCurrentRow = dtCurrentTable.NewRow();
                        //                drCurrentRow["sno"] = j + 1;

                        //                dtCurrentTable.Rows[j - 1]["Product"] = dBilling.Tables[0].Rows[j - 1]["CategoryID"].ToString();
                        //                dtCurrentTable.Rows[j - 1]["Item"] = dBilling.Tables[0].Rows[j - 1]["SubCategoryID"].ToString(); ;
                        //                dtCurrentTable.Rows[j - 1]["Qty"] = dBilling.Tables[0].Rows[j - 1]["Qty"].ToString();
                        //                dtCurrentTable.Rows[j - 1]["Rate"] = dBilling.Tables[0].Rows[j - 1]["Rate"].ToString();
                        //                dtCurrentTable.Rows[j - 1]["Amount"] = dBilling.Tables[0].Rows[j - 1]["Amount"].ToString();

                        //                rowIndex++;

                        //            }
                        //            dtCurrentTable.Rows.Add(drCurrentRow);
                        //            ViewState["CurrentTable"] = dtCurrentTable;

                        //            gvcustomerorder.DataSource = dtCurrentTable;
                        //            gvcustomerorder.DataBind();

                        //            //TextBox txn = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        //            //txn.Focus();
                        //            // txn.Focus;
                        //        }



                        //    }
                        //    else
                        //    {
                        //        Response.Write("ViewState is null");
                        //    }

                        //    if (ViewState["CurrentTable"] != null)
                        //    {
                        //        int Row = 0;
                        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
                        //        if (dt.Rows.Count > 0)
                        //        {
                        //            for (int k = 0; k < dt.Rows.Count - 1; k++)
                        //            {
                        //                DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[Row].Cells[1].FindControl("ddlCategory");

                        //                DropDownList ddDef = (DropDownList)gvcustomerorder.Rows[Row].Cells[2].FindControl("ddlDef");
                        //                TextBox ttQty = (TextBox)gvcustomerorder.Rows[Row].Cells[3].FindControl("txtQty");
                        //                TextBox ttRate = (TextBox)gvcustomerorder.Rows[Row].Cells[4].FindControl("txtRate");
                        //                TextBox ttAmount = (TextBox)gvcustomerorder.Rows[Row].Cells[5].FindControl("txtAmount");

                        //                drCurrentRow["sno"] = i + 1;

                        //                gvcustomerorder.Rows[k].Cells[0].Text = Convert.ToString(k + 1);
                        //                ddlCategory.Text = dt.Rows[k]["Product"].ToString();
                        //                ddDef.Text = dt.Rows[k]["Item"].ToString();
                        //                ttQty.Text = dt.Rows[k]["Qty"].ToString();
                        //                ttRate.Text = dt.Rows[k]["Rate"].ToString();
                        //                ttAmount.Text = dt.Rows[k]["Amount"].ToString();

                        //                rowIndex++;

                        //            }

                        //        }
                        //    }

                        }


                     
                    }
                }

            }
           

        }
        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("sno", typeof(string)));
            dt.Columns.Add(new DataColumn("Product", typeof(string)));
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            dt.Columns.Add(new DataColumn("ExistQty", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("ExpiryDate", typeof(string)));
            dt.Columns.Add(new DataColumn("SubCatID", typeof(string)));
            string OrderNo = Request.QueryString.Get("OrderNo");
            if (OrderNo != null)
            {
                DataSet dBilling = objBs.CustomerOrderBilling(Convert.ToInt32(OrderNo),sTableName);
                if (dBilling.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dBilling.Tables[0].Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr["sno"] = i + 1;
                        dr["Product"] = string.Empty;
                        dr["Item"] = string.Empty;
                        dr["ExistQty"] = string.Empty;
                        dr["Qty"] = string.Empty;
                        dr["Rate"] = string.Empty;
                        dr["Amount"] = string.Empty;
                        dr["ExpiryDate"] = string.Empty;
                        dr["SubCatID"] = string.Empty;
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr["sno"] = 1;
                dr["Product"] = string.Empty;
                dr["Item"] = string.Empty;
                dr["ExistQty"] = string.Empty;
                dr["Qty"] = string.Empty;
                dr["Rate"] = string.Empty;
                dr["Amount"] = string.Empty;
                dr["ExpiryDate"] = string.Empty;
                dr["SubCatID"] = string.Empty;
                dt.Rows.Add(dr);


            }
            ViewState["CurrentTable"] = dt;
            gvcustomerorder.DataSource = dt;
            gvcustomerorder.DataBind();


            //TextBox txn = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtName");
            //txn.Focus();
            //Button btnAdd = (Button)grvStudentDetails.FooterRow.Cells[5].FindControl("ButtonAdd");
            //Page.Form.DefaultFocus = btnAdd.ClientID;

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
                        DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        TextBox txtExistQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtExistQty");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtAmount");
                        Label lblExpiry = (Label)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("lblExpiryDate");
                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("lblDescriptionID");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Product"] = ddlCategory.Text;
                        dtCurrentTable.Rows[i - 1]["Item"] = ddlDef.Text;
                        dtCurrentTable.Rows[i - 1]["ExistQty"] = txtExistQty.Text;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["ExpiryDate"] = lblExpiry.Text;
                        dtCurrentTable.Rows[i - 1]["SubCatID"] = lblSubCat.Text;
                        rowIndex++;
                        ddlCategory.Focus();
                        ddlCategory.Enabled = true;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvcustomerorder.DataSource = dtCurrentTable;
                    gvcustomerorder.DataBind();

                    //TextBox txn = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                    //txn.Focus();
                    //// txn.Focus;
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
                        DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        TextBox txtExistQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtExistQty");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtAmount");
                        Label lblExpiry = (Label)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("lblExpiryDate");
                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("lblDescriptionID");
                        // drCurrentRow["RowNumber"] = i + 1;

                        gvcustomerorder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                        ddlCategory.Text = dt.Rows[i]["Product"].ToString();
                        ddlDef.Text = dt.Rows[i]["Item"].ToString();
                        txtExistQty.Text = dt.Rows[i]["ExistQty"].ToString();
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        txtRate.Text = dt.Rows[i]["Rate"].ToString();
                        txtAmount.Text = dt.Rows[i]["Amount"].ToString();
                        lblExpiry.Text = dt.Rows[i]["ExpiryDate"].ToString();
                        lblSubCat.Text = dt.Rows[i]["SubCatID"].ToString();
                        rowIndex++;
                        ddlCategory.Focus();
                        ddlCategory.Enabled = true;
                    }
                }
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            
        }
        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                    gvcustomerorder.DataSource = dt;
                    gvcustomerorder.DataBind();

                    for (int i = 0; i < gvcustomerorder.Rows.Count - 1; i++)
                    {
                        gvcustomerorder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
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
                        DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        TextBox txtExistQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtExistQty");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtAmount");
                        Label lblExpiry = (Label)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("lblExpiryDate");
                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("lblDescriptionID");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Product"] = ddlCategory.Text;
                        dtCurrentTable.Rows[i - 1]["Item"] = ddlDef.Text;
                        dtCurrentTable.Rows[i - 1]["ExistQty"] = txtExistQty.Text;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["ExpiryDate"] = lblExpiry.Text;
                        dtCurrentTable.Rows[i - 1]["SubCatID"] = lblSubCat.Text;
                        rowIndex++;
                        ddlCategory.Focus();
                        ddlCategory.Enabled = true;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }
        protected void ddlCategort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
            DropDownList ddDef = (DropDownList)row.FindControl("ddlDef");
            DataSet dsCategory = objBs.SelectItems(Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(lblUserID.Text),sTableName);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                DropDownList Def = (DropDownList)row.FindControl("ddlDef");
                //Label lblCatID = (Label)row.FindControl("catid");
                //lblCatID.Text = dsCategory.Tables[0].Rows[0]["CategoryID"].ToString();
                Def.DataSource = dsCategory.Tables[0];
                Def.DataTextField = "Item";
                Def.DataValueField = "StockID";
                Def.DataBind();
                Def.Items.Insert(0, "Select");
                Def.Focus();
                  Label lblDefID = (Label)row.FindControl("lblDescriptionID");
                  lblDefID.Text = dsCategory.Tables[0].Rows[0]["categoryuserid"].ToString();

            }
            else
            {
                ddDef.ClearSelection();
            }
            ddlCategory.Focus();
            ddlCategory.Enabled = true;
        }
        protected void ddlDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
            TextBox txtRate = (TextBox)row.FindControl("txtRate");
            DropDownList Def = (DropDownList)row.FindControl("ddlDef");
            TextBox txtQty = (TextBox)row.FindControl("txtExistQty");
            Label lblExpiry = (Label)row.FindControl("lblExpiryDate");
            DataSet dsCategory = objBs.getCatID(Convert.ToInt32(Def.SelectedValue));
            //if (dsCategory.Tables[0].Rows.Count > 0)
            //{

            //    Label lblCatID = (Label)row.FindControl("catid1");
            //    lblCatID.Text = dsCategory.Tables[0].Rows[0]["CategoryID"].ToString();
            //    Decimal Irate = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Rate"].ToString());
            //    txtRate.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    txtQty.Focus();

            //}
            DataSet dsStock = new DataSet();

            dsStock = objBs.GetStockDetails(Convert.ToInt32(Def.SelectedValue), Convert.ToInt32(lblUserID.Text),sTableName,StockOption);

            if (dsStock.Tables[0].Rows.Count > 0)
            {
                Label lblDefID = (Label)row.FindControl("lblDescriptionID");
                lblDefID.Text = dsStock.Tables[0].Rows[0]["categoryuserid"].ToString();
                Label lblCatID = (Label)row.FindControl("catid1");
                lblCatID.Text = dsStock.Tables[0].Rows[0]["CategoryID"].ToString();
                Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Rate"].ToString());
                txtRate.Text = Decimal.Round(Irate, 2).ToString("f2");
                txtQty.Focus();
                    decimal sQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());
                    txtQty.Text = sQty.ToString("f2");
                    // Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
                    DateTime sDate = Convert.ToDateTime(dsStock.Tables[0].Rows[0]["Expirydate"].ToString());
                    // txtRate.Text = Decimal.Round(Irate, 2).ToString("f2");
                    lblExpiry.Text = sDate.ToShortDateString();
                    DateTime Date = DateTime.Now;
                    string sNow = Date.ToShortDateString();
                    if (lblExpiry.Text == sNow)
                    {
                        lblExpiry.ForeColor = System.Drawing.Color.Red;
                        lblExpiry.Text = lblExpiry.Text + "" + "Expired";
                    }
                
            }
            Def.Focus();
            ddlCategory.Enabled = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string OrderNo = Request.QueryString.Get("OrderNo");
            {
                int iStockSuccess = 0;
                SetRowData();
                DataTable table = ViewState["CurrentTable"] as DataTable;

                if (table != null)
                {
                    string iCustid = "";
                    if (txtmobile.Text != "")
                    {
                        int iSuc = objBs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", "", "", "", Convert.ToInt32(1),"0");
                    }

                    else
                    {
                        txtmobile.Text = "0000000000";
                       
                        
                    }
                    DataSet dCustid = objBs.GerCustID(txtmobile.Text);
                    iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
                    if (OrderNo != null)
                    {
                        DataSet dBilling = objBs.CustomerOrderBilling(Convert.ToInt32(OrderNo), sTableName);
                        if (dBilling.Tables[0].Rows.Count > 0)
                        {
                            string Msg = dBilling.Tables[0].Rows[0]["Messege"].ToString();
                            string Taken = dBilling.Tables[0].Rows[0]["OrderTakenby"].ToString();
                            string delDt = dBilling.Tables[0].Rows[0]["DeliveryDate"].ToString();
                            string delTime = dBilling.Tables[0].Rows[0]["DeilveryTime"].ToString();
                            string Note = dBilling.Tables[0].Rows[0]["Notes"].ToString();

                            //    DataSet dBilling = objBs.CustomerOrderBilling(Convert.ToInt32(OrderNo), sTableName);
                            //    if (dBilling.Tables[0].Rows.Count > 0)
                            //    {
                            //        double advance = Convert.ToDouble(dBilling.Tables[0].Rows[0][""].ToString());
                            //        double dtotal = advance + Convert.ToDouble(txttotal.Text);
                            //        int OrderBill = objBs.insertOrdersales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(OrderNo), "", "", "", "","");
                            //        //int OrderBill = objBs.insertOrdersales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(0), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(OrderNo));
                            //    }
                            //}
                            int OrderBill = objBs.insertOrdersales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txttotal.Text), Convert.ToInt32(OrderNo), Msg, Taken, delDt, delTime,Note,Convert.ToInt16(drpPayment.SelectedValue));
                            //string url = "SalesPrint.aspx?Mode=Order&iSalesID=" + OrderNo;
                            //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
                            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                         
                            Response.Redirect("SalesPrint.aspx?Mode=Order&iSalesID=" + OrderNo);
                        }
                    }

                    else
                    {
                        // int iStat = objBs.insertsales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(0), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text));
                        int OrderBill = objBs.insertOrdersales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtSubTotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(OrderNo), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue));
                        for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                        {
                            TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                            if (Amount.Text != "")
                            {
                                Label lblExpiry = (Label)gvcustomerorder.Rows[i].FindControl("lblExpiryDate");

                                DropDownList ddcategory = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlCategory");
                                int icat = Convert.ToInt32(ddcategory.SelectedValue);
                                ddcategory.Focus();
                                ddcategory.Enabled = true;
                                DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                                int idef = Convert.ToInt32(ddldef.SelectedValue);

                                TextBox Qty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                                double dQty = Convert.ToDouble(Qty.Text);

                                TextBox Rate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                                double DRate = Convert.ToDouble(Rate.Text);


                                double dAmount = Convert.ToDouble(Amount.Text);

                                Label lblDefID = (Label)gvcustomerorder.Rows[i].FindControl("lblDescriptionID");
                                int isalesid = Convert.ToInt32(txtBillNo.Text);// objBs.SalesId("tblSales_" + sTableName);
                                int iStatus1 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddcategory.SelectedValue), dQty, DRate, Convert.ToDouble(0), dAmount, Convert.ToInt32(lblDefID.Text), Convert.ToInt32(ddldef.SelectedValue), 0, "", "", "", Convert.ToDouble(1), "N", "0",Convert.ToDouble(1), Convert.ToDouble(0), Convert.ToDouble(0));
                                DataSet dcheck = objBs.checkCheckBoxCondition(Convert.ToInt32(lblDefID.Text));
                                if (dcheck.Tables[0].Rows.Count > 0)
                                {
                                    //to check printing
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddcategory.SelectedValue), Convert.ToInt32(lblDefID.Text), Convert.ToDecimal(Qty.Text), lblExpiry.Text, ddldef.SelectedValue,isalesid.ToString());
                                }
                                else
                                {
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddcategory.SelectedValue), Convert.ToInt32(lblDefID.Text), Convert.ToDecimal(Qty.Text), lblExpiry.Text, ddldef.SelectedValue,isalesid.ToString());
                                }
                            }
                        }
                        //string url = "SalesPrint.aspx?Mode=Order&iSalesID=" + OrderNo;
                        //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
                        //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                        Response.Redirect("SalesPrint.aspx?Mode=Sales&iSalesID=" + txtBillNo.Text);
                    //    #region Print
                    //     DataSet ds = new DataSet();
              
                    //ds = objBs.PrintingSales(Convert.ToInt32(txtBillNo.Text), sTableName,"Sales");
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    lblcustname.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                    //    lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    //    lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    //    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                    //    lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                    //    decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    //    lblAmount.Text = dAmt.ToString("f2");
                    //    decimal dAvance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Advance"].ToString());
                    //    lbladvance.Text = dAvance.ToString("f2");

                    //    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"].ToString());
                    //    lbltotal.Text = dTotal.ToString("f2");
                    //    gvPrint.DataSource = ds;
                    //    gvPrint.DataBind();
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
                    //}
                    //    #endregion
                        //Response.Write("<script>");
                        //Response.Write("window.open('SalesPrint.aspx?Mode=Sales&iSalesID=; + txtBillNo.Text,'_blank')");
                        //Response.Write("</script>");

                      //  Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("SalesPrint.aspx?Mode=Sales&iSalesID=" + txtBillNo.Text)));
                    }
                    
                }
            }
           
        }
        private int UpdateStockAvailable(int iCat, int iSubCat, decimal iQty,string sDate,string iStockID,string isalesid)
        {
            decimal iAQty = 0;

            int iSuccess = 0;

            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

            }
            decimal iRemQty = iAQty - iQty;
            iSuccess = objBs.updateSalesStock(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text),sTableName,"-","Sales Entry",iQty.ToString(),isalesid,StockOption);


            return iSuccess;
        }
        protected void btnnew_Click(object sender, EventArgs e)
        {
                         
                AddNewRow();
            
        }
        protected void gvcustomerorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = new DataSet();

            string OrderNo = Request.QueryString.Get("OrderNo");
           
                dsCategory = objBs.selectCAT();

            //else
            //    dsCategory = objBs.selectcategorymaster_Dealer("tblStock_" + sTableName);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCategory = (DropDownList)(e.Row.FindControl("ddlCategory") as DropDownList);
                ddlCategory.Focus();
                ddlCategory.Enabled = true;
                ddlCategory.DataSource = dsCategory.Tables[0];
                ddlCategory.DataTextField = "Cat";
                ddlCategory.DataValueField = "categoryid";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select");

                DataSet dDef = objBs.selectcategoryalldecription();
                DropDownList Def = (DropDownList)e.Row.FindControl("ddlDef");

                Def.DataSource = dDef.Tables[0];
                Def.DataTextField = "Item";
                Def.DataValueField = "StockID";
                Def.DataBind();
                #region Databind
              
                if (OrderNo != "")
                {
                    //    DataSet dBilling = objBs.CustomerOrderBilling(Convert.ToInt32(OrderNo), Convert.ToInt32(lblUserID.Text));
                    //    if (dBilling.Tables[0].Rows.Count > 0)
                    //    {



                    //        txtCustomerName.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                    //        txtmobile.Text = dBilling.Tables[0].Rows[0]["PhoneNo"].ToString();
                    //        txtSubTotal.Text = dBilling.Tables[0].Rows[0]["TotalAmount"].ToString();
                    //        txtAdvance.Text = dBilling.Tables[0].Rows[0]["Advance"].ToString();
                    //        txttotal.Text = dBilling.Tables[0].Rows[0]["Balance"].ToString();
                    //        int iCount = dBilling.Tables[0].Rows.Count;

                    //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    //        DataRow drCurrentRow = null;

                    //        for (int i = 0; i < iCount; i++)
                    //        {

                    //            TextBox txtRate = (TextBox)e.Row.FindControl("txtRate");
                    //            TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                    //            TextBox txtAmt = (TextBox)e.Row.FindControl("txtAmount");
                    //            DropDownList ddlCat = (DropDownList)e.Row.FindControl("ddlCategory");
                    //            DropDownList ddlDef = (DropDownList)e.Row.FindControl("ddlDef");

                    //            ddlCat.SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString();


                    //            ddlDef.SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString();


                    //            txtQty.Text = dBilling.Tables[0].Rows[i]["Qty"].ToString();


                    //            txtRate.Text = dBilling.Tables[0].Rows[i]["Rate"].ToString();


                    //            txtAmt.Text = dBilling.Tables[0].Rows[i]["Amount"].ToString();


                    //            if (dtCurrentTable.Rows.Count > 0)
                    //            {
                    //                for (int j = 1; j <= dtCurrentTable.Rows.Count; j++)
                    //                {

                    //                    drCurrentRow = dtCurrentTable.NewRow();
                    //                    drCurrentRow["sno"] = j + 1;

                    //                    dtCurrentTable.Rows[j - 1]["Product"] = ddlCategory.Text;
                    //                    dtCurrentTable.Rows[j - 1]["Item"] = ddlDef.Text;
                    //                    dtCurrentTable.Rows[j - 1]["Qty"] = txtQty.Text;
                    //                    dtCurrentTable.Rows[j - 1]["Rate"] = txtRate.Text;
                    //                    dtCurrentTable.Rows[j - 1]["Amount"] = txtAmt.Text;


                    //                }
                    //                dtCurrentTable.Rows.Add(drCurrentRow);
                    //                ViewState["CurrentTable"] = dtCurrentTable;

                    //                gvcustomerorder.DataSource = dtCurrentTable;
                    //                gvcustomerorder.DataBind();
                    //            }

                    //        }
                    //    }





                    //}



                    // }
                #endregion
                }
            }
        }
        protected void txtdefCatID_TextChanged(object sender, EventArgs e)
        {



            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            TextBox Qty = (TextBox)row.FindControl("txtQty");
            decimal dQty = Convert.ToDecimal(Qty.Text);

            TextBox Rate = (TextBox)row.FindControl("txtRate");
            decimal DRate = Convert.ToDecimal(Rate.Text);

            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            decimal dAmount = 0;

            TextBox EQty = (TextBox)row.FindControl("txtExistQty");
            decimal dEQty = Convert.ToDecimal(EQty.Text);
            
            if (dQty > dEQty)
            {
                lblError.Visible = true;
                lblError.Text = "Check Stock Qty";
                lblError.ForeColor = System.Drawing.Color.Red;
                Button1.Enabled = false;
            }
            else
            {
                lblError.Visible = false;
                Button1.Enabled = true;
                dAmount = dQty * DRate;
                Amount.Text = dAmount.ToString("f2");
                decimal dAmt = 0; decimal dTotal = 0;
                for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                {

                    TextBox tAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                    if (tAmount.Text != "")
                    {
                        dAmt += Convert.ToDecimal(tAmount.Text);
                    }

                }
                dTotal = dAmt;
                txtSubTotal.Text = dTotal.ToString("f2");
                txttotal.Text = dTotal.ToString("f2");
                LinkButton Button = (LinkButton)txt.FindControl("add");
                Button.Focus();
                //if (Amount.Text != "")
                //{
                //    AddNewRow();
                //}
            }
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                decimal dDiscount = Convert.ToDecimal(txtDiscount.Text);
                decimal dSubTotal = Convert.ToDecimal(txtSubTotal.Text);

                decimal dDiscAmt = dSubTotal - ((dDiscount * dSubTotal) / 100);
                txttotal.Text = dDiscAmt.ToString("f2");
            }
        }

        protected void txtAdvance_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                decimal dDiscount = Convert.ToDecimal(txtDiscount.Text);
                decimal dSubTotal = Convert.ToDecimal(txtSubTotal.Text);
                decimal Advance = Convert.ToDecimal(txtAdvance.Text);
                decimal dDiscAmt = dSubTotal - ((dDiscount * dSubTotal) / 100);
                decimal dAmount = dDiscAmt - Advance;
                txttotal.Text = dAmount.ToString("f2");
            }
            else
            {

            }

        }

        protected void gvcustomerorder_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {





            string OrderNo = Request.QueryString.Get("OrderNo");
            if (OrderNo != null)
            {
                DataSet dBilling = objBs.CustomerOrderBilling(Convert.ToInt32(OrderNo), sTableName);
                if (dBilling.Tables[0].Rows.Count > 0)
                {



                    txtCustomerName.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                    txtmobile.Text = dBilling.Tables[0].Rows[0]["PhoneNo"].ToString();
                    txtSubTotal.Text = dBilling.Tables[0].Rows[0]["NetAmount"].ToString();
                    txtAdvance.Text = dBilling.Tables[0].Rows[0]["Advance"].ToString();
                    txttotal.Text = dBilling.Tables[0].Rows[0]["Total"].ToString();
                    int iCount = dBilling.Tables[0].Rows.Count;



                    for (int i = 0; i < iCount; i++)
                    {

                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                        TextBox txtExistQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtExistQty");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                        TextBox txtAmt = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                        DropDownList ddlCat = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlCategory");
                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");

                        ddlCat.SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString();


                        ddlDef.SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString();


                        txtQty.Text = dBilling.Tables[0].Rows[i]["Quantity"].ToString();


                        txtRate.Text = dBilling.Tables[0].Rows[i]["UnitPrice"].ToString();


                        txtAmt.Text = dBilling.Tables[0].Rows[i]["Amount"].ToString();



                    }

                }
            }
        }
    }
}