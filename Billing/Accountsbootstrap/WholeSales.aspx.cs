using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Globalization;
using System.Drawing;


namespace Billing.Accountsbootstrap
{
    public partial class WholeSales : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();

        string sTableName = "";
        string IsSuperAdmin = "";
        string Logintypeid = "";
        string iSalesID = "";
        string iOrderID = "";
        string BranchCode = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            IsSuperAdmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            Logintypeid = Session["LoginTypeId"].ToString();
            BranchCode= Session["BranchCode"].ToString();
            if (!IsPostBack)
            {
                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                #region

                DataSet dssalesNo = objbs.getcrsalesno(sTableName);
                txtbillno.Text = dssalesNo.Tables[0].Rows[0]["BillNo"].ToString();

                DataSet dsstkoption = objbs.GetStockOption(sTableName);
                stockoption.Text = dsstkoption.Tables[0].Rows[0]["Stockoption"].ToString();


                DataSet dsdcNo = objbs.getsalesdcno(sTableName);
                txtdcno.Text = dsdcNo.Tables[0].Rows[0]["DCNo"].ToString();


                DataSet dspaymode = objbs.getpaymode();
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlPayMode.DataSource = dspaymode.Tables[0];
                    ddlPayMode.DataTextField = "PayMode";
                    ddlPayMode.DataValueField = "PayModeId";
                    ddlPayMode.DataBind();
                    
                    if (IsSuperAdmin == "1")
                    {
                        ddlPayMode.Items.Insert(0, "Payment");
                        ddlPayMode.SelectedValue = "2";
                    }
                    else
                    {
                        ddlPayMode.SelectedValue = "2";
                        ddlPayMode.Enabled = false;
                    }
                }


                DataSet dsCustomer = objbs.getgridforcustsale();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dsCustomer.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "LedgerID";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "Select Dealer");

                }
                else
                {
                    ddlcustomer.Items.Insert(0, "Select Dealer");
                }

               

                DataSet dsitem = objbs.selectpacktype_wholesales();
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    drppacktype.DataSource = dsitem.Tables[0];
                    drppacktype.DataTextField = "UOM";
                    drppacktype.DataValueField = "UOMID";
                    drppacktype.DataBind();
                    drppacktype.Items.Insert(0, "Select PackType");
                }
                else
                {
                    drppacktype.Items.Insert(0, "Select PackType");
                }

                #endregion


                ddlitem.Focus();


                iSalesID = Request.QueryString.Get("iSalesID");
                if (iSalesID != null)
                {
                    if (IsSuperAdmin != "1")
                    {
                        btncalc.Enabled = true;
                       // btncalc.Enabled = false;
                    }

                    #region Edit

                    DataSet ds1 = objbs.GetSalesEdit("tblWholesales_" + sTableName, iSalesID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Update";

                    //    txtbillno.Enabled = false;
                        txtbillno.Text = ds1.Tables[0].Rows[0]["BillNo"].ToString();
                        txtdate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["BillDate"]).ToString("dd/MM/yyyy hh:mm tt");

                        txtdcno.Text = ds1.Tables[0].Rows[0]["DCNo"].ToString();
                        txtdcno.Enabled = false;

                        txtorderno.Text = ds1.Tables[0].Rows[0]["OrderNo"].ToString();
                        txtorderno.Enabled = false;

                        ddlcustomer.SelectedValue = ds1.Tables[0].Rows[0]["Customername"].ToString();
                        ddlcustomer.Enabled = false;

                        txtmbl.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();
                        txtAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        ddlPayMode.SelectedValue = ds1.Tables[0].Rows[0]["PayMode"].ToString();
                        ddlPayMode.Enabled = false;                       

                        rdbtype.SelectedValue = ds1.Tables[0].Rows[0]["DiscType"].ToString();

                        txtgrandamount.Text = ds1.Tables[0].Rows[0]["Amount"].ToString();
                        txtTaxamt.Text = ds1.Tables[0].Rows[0]["Tax"].ToString();
                        txtdiscamt.Text = ds1.Tables[0].Rows[0]["Disc"].ToString();

                        txttdiscper.Text = ds1.Tables[0].Rows[0]["DiscPer"].ToString();
                        txttdiscamt.Text = ds1.Tables[0].Rows[0]["DiscAmount"].ToString();


                        txtDeliverCharge.Text = ds1.Tables[0].Rows[0]["DeliveryVal"].ToString();
                        txtgrandtotal.Text = ds1.Tables[0].Rows[0]["GrandTotal"].ToString();

                        lbldisplay.InnerText = ds1.Tables[0].Rows[0]["GrandTotal"].ToString();
                        lbltotalitems.InnerText = ds1.Tables[0].Rows[0]["TotalItems"].ToString();

                        txtNarrations.Text = ds1.Tables[0].Rows[0]["Narration"].ToString();
                        txtVehicleNo.Text = ds1.Tables[0].Rows[0]["VehicleNo"].ToString();

                        ddlcustomer_OnSelectedIndexChanged(sender, e);

                        DataSet ds2 = objbs.GetTransSalesEditNew("tblTransWholeSales_" + sTableName, iSalesID,sTableName);
                        {
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                int Tpo = ds2.Tables[0].Rows.Count;


                                DataTable dttt;
                                DataRow drNew;
                                DataColumn dct;
                                DataSet dstd = new DataSet();
                                dttt = new DataTable();


                                dct = new DataColumn("Type");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Item");
                                dttt.Columns.Add(dct);
                                dct = new DataColumn("OQty");
                                dttt.Columns.Add(dct);
                                dct = new DataColumn("BQty");
                                dttt.Columns.Add(dct);
                                dct = new DataColumn("SQty");
                                dttt.Columns.Add(dct);


                                dct = new DataColumn("Rate");
                                dttt.Columns.Add(dct);
                                dct = new DataColumn("Tax");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("TaxAmount");
                                dttt.Columns.Add(dct);
                                dct = new DataColumn("Amount");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Stock");
                                dttt.Columns.Add(dct);
                                dct = new DataColumn("PackType");
                                  dttt.Columns.Add(dct);
                                dct = new DataColumn("MRP");
                                dttt.Columns.Add(dct);

                                dstd.Tables.Add(dttt);

                                foreach (DataRow dr in ds2.Tables[0].Rows)
                                {


                                    drNew = dttt.NewRow();

                                    drNew["Type"] = dr["Type"];

                                    drNew["Item"] = dr["Item"];
                                    drNew["OQty"] = "0";
                                    drNew["BQty"] = dr["Qty"];
                                    drNew["SQty"] = dr["Qty"];


                                    drNew["Rate"] = dr["Rate"];
                                    drNew["Tax"] = dr["Tax"];

                                    drNew["TaxAmount"] = (((Convert.ToDouble(dr["Qty"]) * Convert.ToDouble(dr["Rate"])) * Convert.ToDouble(dr["Tax"])) / 100).ToString("f2");
                                    drNew["Amount"] = ((Convert.ToDouble(dr["Qty"]) * Convert.ToDouble(dr["Rate"])) + (((Convert.ToDouble(dr["Qty"]) * Convert.ToDouble(dr["Rate"])) * Convert.ToDouble(dr["Tax"])) / 100)).ToString("f2");

                                    //drNew["TaxAmount"] = dr["TaxAmount"];
                                    //drNew["Amount"] = dr["Amount"];
                                    DataSet dsitem1 = objbs.selectitemsval_wholesales(sTableName, Convert.ToInt32(dr["Item"].ToString()), Logintypeid, Convert.ToInt16(ddlcustomer.SelectedValue));
                                    if (dsitem1.Tables[0].Rows.Count > 0)
                                    {
                                        drNew["Stock"] = Convert.ToDouble(dsitem1.Tables[0].Rows[0]["Available_QTY"]).ToString("f2");
                                    }
                                    //    if (Logintypeid == "3")
                                    //{
                                    //    drNew["Stock"] = dr["Prod_Qty"];
                                    //}
                                    //else
                                    //{
                                    //    drNew["Stock"] = dr["Prod_Qty"];
                                    //}


                                    

                                    drNew["PackType"] = dr["PackType"];
                                    drNew["MRP"] = dr["MRP"] ;

                                    dstd.Tables[0].Rows.Add(drNew);
                                }

                                ViewState["CurrentTable1"] = dttt;

                                GridView2.DataSource = dstd;
                                GridView2.DataBind();


                                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                                {
                                    HiddenField hdtype = (HiddenField)GridView2.Rows[vLoop].FindControl("hdtype");

                                    DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");
                                    TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                                    TextBox txtBQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtBQty");
                                    TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");

                                    TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                                    TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");

                                    TextBox txtTaxamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtTaxamount");
                                    TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtAmount");

                                    TextBox txtStock = (TextBox)GridView2.Rows[vLoop].FindControl("txtStock");

                                    DropDownList drpPackType = (DropDownList)GridView2.Rows[vLoop].FindControl("drpPackType");
                                    TextBox txtMRP = (TextBox)GridView2.Rows[vLoop].FindControl("txtMRP");

                                    hdtype.Value = dstd.Tables[0].Rows[vLoop]["Type"].ToString();

                                    drpItem.SelectedValue = dstd.Tables[0].Rows[vLoop]["Item"].ToString();
                                    txtQty.Text = dstd.Tables[0].Rows[vLoop]["OQty"].ToString();
                                    txtBQty.Text = dstd.Tables[0].Rows[vLoop]["BQty"].ToString();
                                    txtSQty.Text = dstd.Tables[0].Rows[vLoop]["SQty"].ToString();

                                    txtRate.Text = dstd.Tables[0].Rows[vLoop]["Rate"].ToString();
                                    txtTax.Text = dstd.Tables[0].Rows[vLoop]["Tax"].ToString();

                                    txtTaxamount.Text = dstd.Tables[0].Rows[vLoop]["TaxAmount"].ToString(); Math.Round(Convert.ToDouble(txtgrandtotal.Text), MidpointRounding.AwayFromZero);
                                    txtAmount.Text = dstd.Tables[0].Rows[vLoop]["Amount"].ToString();

                                    txtStock.Text = dstd.Tables[0].Rows[vLoop]["Stock"].ToString();
                                    drpPackType.SelectedValue = dstd.Tables[0].Rows[vLoop]["PackType"].ToString();
                                    txtMRP.Text = dstd.Tables[0].Rows[vLoop]["MRP"].ToString();
                                }
                            }
                        }
                    }
                    #endregion
                }

                iOrderID = Request.QueryString.Get("iOrderID");
                if (iOrderID != null)
                {
                    if (IsSuperAdmin != "1")
                    {
                        btncalc.Enabled = false;
                    }

                    #region Order

                    DataSet ds1 = objbs.GetOrderSalesView(iOrderID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Save";

                        txtorderno.Text = ds1.Tables[0].Rows[0]["OrderID"].ToString();
                        txtorderno.Enabled = false;
                        ddlcustomer.SelectedValue = ds1.Tables[0].Rows[0]["LedgerID"].ToString();
                        ddlcustomer.Enabled = false;
                        txtmbl.Text = ds1.Tables[0].Rows[0]["Mobileno"].ToString();
                        txtgrandamount.Text = ds1.Tables[0].Rows[0]["GrandTotal"].ToString();
                        txtgrandtotal.Text = ds1.Tables[0].Rows[0]["GrandTotal"].ToString();
                        lbldisplay.InnerText = ds1.Tables[0].Rows[0]["GrandTotal"].ToString();
                        lbltotalitems.InnerText = ds1.Tables[0].Rows[0]["TotalQty"].ToString();


                        DataSet ds2 = objbs.GetOrderTransSalesView(iOrderID);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            #region

                            int Tpo = ds2.Tables[0].Rows.Count;


                            DataTable dttt;
                            DataRow drNew;
                            DataColumn dct;
                            DataSet dstd = new DataSet();
                            dttt = new DataTable();

                            dct = new DataColumn("Type");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Item");
                            dttt.Columns.Add(dct);
                            dct = new DataColumn("OQty");
                            dttt.Columns.Add(dct);
                            dct = new DataColumn("BQty");
                            dttt.Columns.Add(dct);
                            dct = new DataColumn("SQty");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Rate");
                            dttt.Columns.Add(dct);
                            dct = new DataColumn("Tax");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("TaxAmount");
                            dttt.Columns.Add(dct);
                            dct = new DataColumn("Amount");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Stock");
                              dttt.Columns.Add(dct);
                            dct = new DataColumn("PackType");
                              dttt.Columns.Add(dct);
                            dct = new DataColumn("MRP");

                            dttt.Columns.Add(dct);
                            dstd.Tables.Add(dttt);

                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                drNew = dttt.NewRow();

                                drNew["Type"] = "O";

                                drNew["Item"] = dr["Productid"];
                                drNew["OQty"] = Convert.ToDouble(dr["Qty"]);
                                drNew["BQty"] = "0";

                                double BQty = Convert.ToDouble(dr["Qty"]) - (Convert.ToDouble(dr["CancelQty"]) + Convert.ToDouble(dr["SalesQty"]));
                                if (BQty > 0)
                                {
                                    drNew["SQty"] = BQty;
                                }
                                else
                                {
                                    drNew["SQty"] = 0;
                                }

                                drNew["Rate"] = Convert.ToString(Convert.ToDouble(dr["Rate"]));
                                drNew["Tax"] = dr["TaxPercentage"];

                                drNew["TaxAmount"] = Convert.ToString(Convert.ToDouble(dr["TaxAmount"]));
                                drNew["Amount"] = Convert.ToString(Convert.ToDouble(dr["Amount"]));

                                drNew["Stock"] = Convert.ToString(Convert.ToDouble(dr["Prod_Qty"]));

                                drNew["PackType"] = dr["PackType"];
                                drNew["MRP"] = dr["MRP"];


                                dstd.Tables[0].Rows.Add(drNew);

                            }

                            ViewState["CurrentTable1"] = dttt;

                            GridView2.DataSource = dstd;
                            GridView2.DataBind();


                            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                            {
                                HiddenField hdtype = (HiddenField)GridView2.Rows[vLoop].FindControl("hdtype");

                                DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");
                                TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                                TextBox txtBQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtBQty");
                                TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");

                                TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                                TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");

                                TextBox txtTaxamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtTaxamount");
                                TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtAmount");

                                TextBox txtStock = (TextBox)GridView2.Rows[vLoop].FindControl("txtStock");

                                hdtype.Value = dstd.Tables[0].Rows[vLoop]["Type"].ToString();

                                drpItem.SelectedValue = dstd.Tables[0].Rows[vLoop]["Item"].ToString();
                                txtQty.Text = dstd.Tables[0].Rows[vLoop]["OQty"].ToString();
                                txtBQty.Text = dstd.Tables[0].Rows[vLoop]["BQty"].ToString();
                                txtSQty.Text = dstd.Tables[0].Rows[vLoop]["SQty"].ToString();

                                txtRate.Text = dstd.Tables[0].Rows[vLoop]["Rate"].ToString();
                                txtTax.Text = dstd.Tables[0].Rows[vLoop]["Tax"].ToString();

                                txtTaxamount.Text = dstd.Tables[0].Rows[vLoop]["TaxAmount"].ToString();
                                txtAmount.Text = dstd.Tables[0].Rows[vLoop]["Amount"].ToString();

                                txtStock.Text = dstd.Tables[0].Rows[vLoop]["Stock"].ToString();

                                DropDownList drpPackType = (DropDownList)GridView2.Rows[vLoop].FindControl("drpPackType");
                                TextBox txtMRP = (TextBox)GridView2.Rows[vLoop].FindControl("txtMRP");
                                drpPackType.SelectedValue = dstd.Tables[0].Rows[vLoop]["PackType"].ToString();

                                if (txtStock.Text == "")
                                    txtStock.Text = "0";
                                if (Convert.ToDouble(txtStock.Text) <= 0)
                                {
                                    GridView2.Rows[vLoop].BackColor = Color.Red;
                                }

                            }

                            #endregion
                        }
                        else
                        {
                            btncalc.Enabled = true;
                        }



                    }
                    #endregion
                }

                Calculation();

            }


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
            txtsno.Focus();
        }


        protected void rbdsalestype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.DataSource = null;
            GridView2.DataBind();

            //txtcgst.Text = "0";
            //txtsgst.Text = "0";
            //txtigst.Text = "0";
            //txtigst.Text = "0";

            //FirstGridViewRow1();
        }

        protected void ddlcustomer_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dscust = objbs.getiCatvalues1(ddlcustomer.SelectedValue);
            if (dscust.Tables[0].Rows.Count > 0)
            {
                txtmbl.Text = dscust.Tables[0].Rows[0]["MobileNo"].ToString();
                txtAddress.Text = dscust.Tables[0].Rows[0]["Address"].ToString();
            }
            else
            {
                txtmbl.Text = "";
                txtAddress.Text = "";
            }


            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet dsitem = objbs.selectitems_wholesales(sTableName,Convert.ToInt16( ddlcustomer.SelectedValue));
            if (dsitem.Tables[0].Rows.Count > 0)
            {
                ddlitem.DataSource = dsitem.Tables[0];
                ddlitem.DataTextField = "BIngredientName";
                ddlitem.DataValueField = "IngredientId";
                ddlitem.DataBind();
                ddlitem.Items.Insert(0, "Select Item");
            }
            else
            {
                ddlitem.Items.Insert(0, "Select Item");
            }
        }
        protected void btnrefresh_OnClick(object sender, EventArgs e)
        {
        //    DataSet dsitem = objbs.selectitems_wholesales(sTableName);
        //    if (dsitem.Tables[0].Rows.Count > 0)
        //    {
        //        ddlitem.DataSource = dsitem.Tables[0];
        //        ddlitem.DataTextField = "Definition";
        //        ddlitem.DataValueField = "CategoryUserID";
        //        ddlitem.DataBind();
        //        ddlitem.Items.Insert(0, "Select Item");
        //    }
        //    else
        //    {
        //        ddlitem.Items.Insert(0, "Select Item");
        //    }
        }

        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HiddenField hdtype = (HiddenField)GridView2.Rows[rowIndex].Cells[2].FindControl("hdtype");

                        DropDownList drpItem = (DropDownList)GridView2.Rows[rowIndex].Cells[2].FindControl("drpItem");
                        TextBox txtQty = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtQty");
                        TextBox txtBQty = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtBQty");
                        TextBox txtSQty = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtSQty");
                        TextBox txtRate = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtTax = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtTax");

                        TextBox txtTaxamount =
                        (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtTaxamount");
                        TextBox txtAmount =
                         (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtAmount");

                        TextBox txtStock =
                     (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtStock");

                        hdtype.Value = dt.Rows[i]["Type"].ToString();

                        drpItem.SelectedValue = dt.Rows[i]["Item"].ToString();
                        txtQty.Text = dt.Rows[i]["OQty"].ToString();
                        txtBQty.Text = dt.Rows[i]["BQty"].ToString();
                        txtSQty.Text = dt.Rows[i]["SQty"].ToString();

                        txtRate.Text = dt.Rows[i]["Rate"].ToString();
                        txtTax.Text = dt.Rows[i]["Tax"].ToString();

                        txtTaxamount.Text = dt.Rows[i]["TaxAmount"].ToString();
                        txtAmount.Text = dt.Rows[i]["Amount"].ToString();

                        txtStock.Text = dt.Rows[i]["Stock"].ToString();

                        txtSQty.Focus();
                        rowIndex++;

                    }
                }
            }
        }

        protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Itemidsplict = ddlitem.SelectedValue.Split('/');

            DataSet dsitem = objbs.selectitemsval_wholesales(sTableName, Convert.ToInt32(Itemidsplict[0].ToString()), Logintypeid,Convert.ToInt16(ddlcustomer.SelectedValue));
            if (dsitem.Tables[0].Rows.Count > 0)
            {
                txtstock.Text = Convert.ToDouble(dsitem.Tables[0].Rows[0]["Available_QTY"]).ToString("f2");

                if ((dsitem.Tables[0].Rows[0]["MRP"] == null) || (dsitem.Tables[0].Rows[0]["MRP"] == "") || (dsitem.Tables[0].Rows[0]["MRP"] == System.DBNull.Value))
                    txtMRP.Text = "0";
                else
                txtMRP.Text = Convert.ToDouble(dsitem.Tables[0].Rows[0]["MRP"]).ToString("f2");
                
                //string[] Rate = ddlitem.SelectedItem.Text.Split('/');
                //txtrate.Text = Rate[1].ToString();

                txttax.Text = Convert.ToDouble(dsitem.Tables[0].Rows[0]["Tax"]).ToString("f2");


                double val = Convert.ToDouble(txttax.Text) + 100;
                val = (Convert.ToDouble(txtMRP.Text) / val) * 100;
                txtqty.Focus();
            }
            else
            {
                txtstock.Text = "0";
                txttax.Text = "0";
                txtqty.Text = "0";
            }
            if ((stockoption.Text == "1") && (txtstock.Text == "0"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Stock is Empty');", true);
                ddlitem.SelectedIndex = 0;
                ddlitem.Focus();
                return;
            }
            DataSet dsitem1 = objbs.selectitemsRate_wholesales((ddlitem.SelectedValue), (ddlcustomer.SelectedValue));
            if (dsitem1.Tables[0].Rows.Count > 0)
            {
                if ((dsitem1.Tables[0].Rows[0]["MRP"] == null) || (dsitem1.Tables[0].Rows[0]["MRP"] == "") || dsitem1.Tables[0].Rows[0]["MRP"] == System.DBNull.Value)
                    txtrate.Text = "0";
                else
                    txtrate.Text = Convert.ToDouble(dsitem1.Tables[0].Rows[0]["MRP"]).ToString("f2");
                double val1 = Convert.ToDouble(txttax.Text) + 100;
                val1 = (Convert.ToDouble(txtMRP.Text) / val1) * 100;
            }
            else
            {
                txtrate.Text = "0";
            }
        }

        protected void drppacktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Itemidsplict = ddlitem.SelectedValue.Split('/');

            DataSet dsitem = objbs.selectitemsval_wholesales(sTableName, Convert.ToInt32(Itemidsplict[0].ToString()), Logintypeid,Convert.ToInt16(ddlcustomer.SelectedValue));
            //  DataSet dsitem = objbs.selectitemsval(sTableName, Convert.ToInt32(ddlitem.SelectedValue), Logintypeid);
            if (dsitem.Tables[0].Rows.Count > 0)
            {
                txtstock.Text = Convert.ToDouble(dsitem.Tables[0].Rows[0]["Available_QTY"]).ToString("f2");
                txtMRP.Text = Convert.ToDouble(dsitem.Tables[0].Rows[0]["MRP"]).ToString("f2");

                //string[] Rate = ddlitem.SelectedItem.Text.Split('/');

                //txtrate.Text = Rate[1].ToString();
                txttax.Text = Convert.ToDouble(dsitem.Tables[0].Rows[0]["Tax"]).ToString("f2");

            }

            txtqty.Focus();
        }


        protected void btngvadd_Click(object sender, EventArgs e)
        {
            #region Validation

            if (txtrate.Text == "")
                txtrate.Text = "0";

            if ((ddlitem.Text == "0") || (ddlitem.Text == "") || (ddlitem.Text == "Select Item"))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Itetm')", true);
                ddlitem.Focus();
                return;
            }

            if (drppacktype.SelectedValue == "0" || drppacktype.SelectedValue == "" || drppacktype.SelectedValue == "Select PackType")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select PackType.');", true);
                drppacktype.Focus();
                return;
            }


            if ((txtqty.Text == "0") || (txtqty.Text == "") || (txtqty.Text == "Rate"))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty')", true);
                txtqty.Focus();
                return;
            }
            if (Convert.ToDouble(txtrate.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Rate.')", true);
                txtrate.Focus();
                return;
            }
            if (Convert.ToDouble(txtstock.Text) < Convert.ToDouble(txtqty.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Check Qty.');", true);
                txtqty.Focus();
                return;
            }

            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");

                string[] Itemidsplict1 = ddlitem.SelectedValue.Split('/');

                if (Itemidsplict1[0].ToString() == drpItem.SelectedValue)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('" + drpItem.SelectedItem.Text + " already Exists.');", true);
                    txtsno.Focus();
                    return;
                }

            }

            #endregion

            ////// txtbxqty_OnTextChanged(sender, e);

            DataTable dtddd = new DataTable();
            DataTable dttt;
            DataRow drNew;
            DataColumn dct;
            DataSet dstd = new DataSet();
            dttt = new DataTable();

            #region

            dct = new DataColumn("Type");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Item");
            dttt.Columns.Add(dct);
            dct = new DataColumn("OQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("BQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("SQty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Rate");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Tax");
            dttt.Columns.Add(dct);

            dct = new DataColumn("TaxAmount");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Amount");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Stock");
            dttt.Columns.Add(dct);

            dct = new DataColumn("PackType");
            dttt.Columns.Add(dct);

            dct = new DataColumn("MRP");
            dttt.Columns.Add(dct);



            dstd.Tables.Add(dttt);

            string[] Itemidsplict = ddlitem.SelectedValue.Split('/');
            string[] PackIdsplit = drppacktype.SelectedValue.Split('/');

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];


                drNew = dttt.NewRow();
                drNew["Type"] = "N";

                drNew["Item"] = Itemidsplict[0].ToString();
                drNew["OQty"] = "0";
                drNew["BQty"] = "0";
                drNew["SQty"] = txtqty.Text;

                drNew["Rate"] = txtrate.Text;
                drNew["Tax"] = txttax.Text;

                drNew["TaxAmount"] = ((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttax.Text)) / 100;
                drNew["Amount"] = ((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) + (((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttax.Text)) / 100));

                drNew["Stock"] = txtstock.Text;


                drNew["PackType"] = PackIdsplit[0].ToString();
                drNew["MRP"] = txtMRP.Text;

                dstd.Tables[0].Rows.Add(drNew);
                dtddd = dstd.Tables[0];

                dtddd.Merge(dt);
            }
            else
            {

                drNew = dttt.NewRow();
                drNew["Type"] = "N";

                drNew["Item"] = Itemidsplict[0].ToString();
                drNew["OQty"] = "0";
                drNew["BQty"] = "0";
                drNew["SQty"] = txtqty.Text;

                drNew["Rate"] = txtrate.Text;
                drNew["Tax"] = txttax.Text;

                drNew["TaxAmount"] = ((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttax.Text)) / 100;
                drNew["Amount"] = ((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) + (((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttax.Text)) / 100));

                drNew["Stock"] = txtstock.Text;
                drNew["PackType"] = PackIdsplit[0].ToString();
                drNew["MRP"] = txtMRP.Text;

                dstd.Tables[0].Rows.Add(drNew);
                dtddd = dstd.Tables[0];
            }

            ViewState["CurrentTable1"] = dtddd;

            GridView2.DataSource = dtddd;
            GridView2.DataBind();

            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                #region

                HiddenField hdtype = (HiddenField)GridView2.Rows[vLoop].FindControl("hdtype");

                DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");
                DropDownList drpPackType = (DropDownList)GridView2.Rows[vLoop].FindControl("drpPackType");

                TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                TextBox txtBQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtBQty");
                TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");

                TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");

                TextBox txtTaxamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtTaxamount");
                TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtAmount");

                TextBox txtstock1 = (TextBox)GridView2.Rows[vLoop].FindControl("txtStock");

                hdtype.Value = dstd.Tables[0].Rows[vLoop]["Type"].ToString();
                drpItem.SelectedValue = dstd.Tables[0].Rows[vLoop]["Item"].ToString();
                txtQty.Text = dstd.Tables[0].Rows[vLoop]["OQty"].ToString();
                txtBQty.Text = dstd.Tables[0].Rows[vLoop]["BQty"].ToString();
                txtSQty.Text = dstd.Tables[0].Rows[vLoop]["SQty"].ToString();

                txtRate.Text = dstd.Tables[0].Rows[vLoop]["Rate"].ToString();
                txtTax.Text = dstd.Tables[0].Rows[vLoop]["Tax"].ToString();

                txtTaxamount.Text = dstd.Tables[0].Rows[vLoop]["TaxAmount"].ToString();

                txtAmount.Text = dstd.Tables[0].Rows[vLoop]["Amount"].ToString();
                double Amount = Math.Round(Convert.ToDouble(txtAmount.Text), MidpointRounding.AwayFromZero);
                txtAmount.Text = Amount.ToString("f2");


                txtstock1.Text = dstd.Tables[0].Rows[vLoop]["Stock"].ToString();


                drpPackType.SelectedValue = dstd.Tables[0].Rows[vLoop]["PackType"].ToString();
                txtMRP.Text = dstd.Tables[0].Rows[vLoop]["MRP"].ToString();


                #endregion
            }

            #endregion

            Calculation();

            ddlitem.SelectedIndex = 0;
            txtqty.Text = "0";
            txtrate.Text = "0";
            txttax.Text = "0";
            txtstock.Text = "0";
            txtMRP.Text = "0";
            drppacktype.SelectedIndex = 0;
        }

        protected void GridView2_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var drpItem = (DropDownList)e.Row.FindControl("drpItem");
                var drppacktype = (DropDownList)e.Row.FindControl("drpPackType");

                if (iOrderID == null || iOrderID == "")
                {
                    if (btnadd.Text == "Save")
                    {
                        //dst = objbs.selectitems1(sTableName);selectitems

                        dst = objbs.selectitems_wholesales(sTableName,Convert.ToInt16(ddlcustomer.SelectedValue));
                    }
                    else
                    {
                        //dst = objbs.selectitemsupdate(sTableName);

                        dst = objbs.selectitems_wholesales(sTableName, Convert.ToInt16(ddlcustomer.SelectedValue));
                    }
                }
                else
                {
                    // = objbs.selectitemsupdate(sTableName);

                    dst = objbs.selectitems_wholesales(sTableName, Convert.ToInt16(ddlcustomer.SelectedValue));
                }

                //drpItem.DataSource = dst;
                //drpItem.DataTextField = "IngredientId";
                //drpItem.DataValueField = "CategoryUserID";
                //drpItem.DataBind();
                //drpItem.Items.Insert(0, "Select Item");

                sTableName = Request.Cookies["userInfo"]["User"].ToString();
                DataSet dlitem = objbs.selectitems_wholesales(sTableName, Convert.ToInt16(ddlcustomer.SelectedValue));
                if (dlitem.Tables[0].Rows.Count > 0)
                {
                    drpItem.DataSource = dlitem.Tables[0];
                    drpItem.DataTextField = "BIngredientName";
                    drpItem.DataValueField = "IngredientId";
                    drpItem.DataBind();
                    drpItem.Items.Insert(0, "Select Item");
                }
                else
                {
                    drpItem.Items.Insert(0, "Select Item");
                }

                DataSet dsitem = objbs.selectpacktype_wholesales();
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    drppacktype.DataSource = dsitem.Tables[0];
                    drppacktype.DataTextField = "UOM";
                    drppacktype.DataValueField = "UOMID";
                    drppacktype.DataBind();
                    drppacktype.Items.Insert(0, "Select PackType");
                }
                else
                {
                    drppacktype.Items.Insert(0, "Select PackType");
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }

        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    SetPreviousData1();

                    for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                    {
                        TextBox txtqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");
                        TextBox txtrate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                        TextBox txtdiscontamt = (TextBox)GridView2.Rows[vLoop].FindControl("txttdiscamt");
                        TextBox txttax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");
                        TextBox txtDelcrg = (TextBox)GridView2.Rows[vLoop].FindControl("txtDCharge");
                        TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtAmount");

                        DropDownList drpItem1 = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");

                        if ((txtrate.Text == "0") || (txtrate.Text == "") || (txtrate.Text == "Rate"))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Rate')", true);
                            ddlitem.Focus();
                            return;
                        }
                        if ((txtqty.Text == "0") || (txtqty.Text == ""))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty in Item " + drpItem1.SelectedItem.Text + "')", true);
                            ddlitem.Focus();
                            return;
                        }
                    }

                }
                else if (dt.Rows.Count == 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    SetPreviousData1();
                }

                Calculation();

            }
        }

        protected void txtSQty_OnTextChanged(object sender, EventArgs e)
        {
            TextBox ddl = (TextBox)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            TextBox txtqty = (TextBox)row.FindControl("txtSQty");
            TextBox txtrate = (TextBox)row.FindControl("txtrate");
            TextBox txttax = (TextBox)row.FindControl("txttax");

            TextBox txtTaxamount = (TextBox)row.FindControl("txtTaxamount");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

            txtTaxamount.Text = (((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttax.Text)) / 100).ToString("f2");
            txtAmount.Text = ((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) + (((Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttax.Text)) / 100)).ToString("f2");

            Calculation();
        }


        protected void txtqty_OnTextChanged(object sender, EventArgs e)
        {
            //TextBox txtbox1 = (TextBox)sender;
            //GridViewRow row = (GridViewRow)txtbox1.NamingContainer;

            //TextBox txtMRP = (TextBox)row.FindControl("txtMRP");
            //TextBox txttax = (TextBox)row.FindControl("txttax");


            double val = Convert.ToDouble(txttax.Text) + 100;
            val = (Convert.ToDouble(txtMRP.Text) / val) * 100;

            txtrate.Text = val.ToString("f2");
        }

        protected void txttdiscper_OnTextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            #region Validation

        



            if (ddlcustomer.SelectedValue == "0" || ddlcustomer.SelectedValue == "" || ddlcustomer.SelectedValue == "Select Dealer")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Customer.');", true);
                ddlcustomer.Focus();
                return;
            }
            if (ddlPayMode.SelectedValue == "0" || ddlPayMode.SelectedValue == "" || ddlPayMode.SelectedValue == "Payment")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select PayMode.');", true);
                ddlPayMode.Focus();
                return;
            }
            if ((txtdcno.Text == "0") || (txtdcno.Text == ""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter DC.No.');", true);
                ddlPayMode.Focus();
                return;
            }

            if (GridView2.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Entry Items.');", true);
                return;
            }

            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");
                TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");
                TextBox txtBQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtBQty");

             //   if (drpItem.SelectedValue == "Select Item" || drpItem.SelectedValue == "" || drpItem.SelectedValue == "0")
             //   {
             //       ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Items.');", true);
             //       drpItem.Focus();
             //       return;
             //   }
             //   else
               // {
                    //if (btnadd.Text == "Save")
                    //{
                    //    DataSet dsdupds = objbs.CheckStock(sTableName, Convert.ToInt32(drpItem.SelectedValue), Convert.ToDouble(txtSQty.Text));
                    //    if (dsdupds.Tables[0].Rows.Count == 0)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Stock was Low in Item " + drpItem.SelectedItem.Text + " ');", true);
                    //        txtSQty.Focus();
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    double CHKQty = Convert.ToDouble(txtSQty.Text) - Convert.ToDouble(txtBQty.Text);

                    //    DataSet dsdupds = objbs.CheckStock(sTableName, Convert.ToInt32(drpItem.SelectedValue), CHKQty);
                    //    if (dsdupds.Tables[0].Rows.Count == 0)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Stock was Low in Item " + drpItem.SelectedItem.Text + " ');", true);
                    //        txtSQty.Focus();
                    //        return;
                    //    }
                    //}

             //   }
            }

            #endregion

            if (txtDeliverCharge.Text == "")
                txtDeliverCharge.Text = "0";

            DateTime date = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);

            if (btnadd.Text == "Save")
            {
                #region

                DataSet dsdcno = objbs.CheckduplicateDC(sTableName, txtbillno.Text);
                if (dsdcno.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Bill.No Already Exists. Please Enter Different Bill No.');", true);
                    txtdcno.Focus();
                    return;
                }

                int salesid = objbs.insertwholesales(sTableName,txtbillno.Text, date, Convert.ToInt32(ddlPayMode.SelectedValue), txtNarrations.Text, Convert.ToInt32(ddlcustomer.SelectedValue), txtmbl.Text, txtAddress.Text, Convert.ToDouble(txtgrandamount.Text), Convert.ToDouble(txtTaxamt.Text), Convert.ToDouble(txtgrandtotal.Text), Convert.ToInt32(0), Convert.ToDouble(txttdiscper.Text), Convert.ToDouble(txttdiscamt.Text), Convert.ToDouble(lbltotalitems.InnerText), txtdcno.Text, Convert.ToDouble(txtdiscamt.Text), Convert.ToInt32(rdbtype.SelectedValue), Convert.ToDouble(txtDeliverCharge.Text), Convert.ToInt32(txtorderno.Text), Convert.ToInt32(lblUserID.Text), Logintypeid, Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtigst.Text), rbdsalestype.SelectedValue, lblPrefix.Text,yearss.Text,txtVehicleNo.Text);

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField hdtype = (HiddenField)GridView2.Rows[vLoop].FindControl("hdtype");
                    DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");

                    TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                    TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");

                    TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                    TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");

                    TextBox txtTaxamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtTaxamount");
                    TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtAmount");


                    TextBox txtMRP = (TextBox)GridView2.Rows[vLoop].FindControl("txtMRP");
                    DropDownList drpPackType = (DropDownList)GridView2.Rows[vLoop].FindControl("drpPackType");

                    if (Convert.ToDouble(txtSQty.Text) > 0)
                    {
                        int transsales = objbs.inserttranswholesales(sTableName, salesid, Convert.ToInt32(drpItem.SelectedValue), Convert.ToDouble(txtSQty.Text), Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtTaxamount.Text), Convert.ToDouble(txtAmount.Text), Convert.ToDouble(txttdiscper.Text), Convert.ToDouble(txttdiscamt.Text), Convert.ToDouble(txtDeliverCharge.Text), "", txtorderno.Text, hdtype.Value, Logintypeid, Convert.ToInt32(drpPackType.SelectedValue), Convert.ToDouble(txtMRP.Text),Logintypeid);
                    }
                }

              //  string yourUrl = "InvoicePrint.aspx?InvoiceId=" + salesid;
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

           //     string yourUrl = "WholeSalesPrintnew.aspx?ISalesId=" + salesid;
             //   ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);



                if (txtorderno.Text == "" || txtorderno.Text == "0")
                {
                    Refersh();
                }
                else
                {
                    Response.Redirect("WholeSalesGrid.aspx");
                }

                #endregion
            }
            if (btnadd.Text == "Update")
            {
                iSalesID = Request.QueryString.Get("iSalesID");

                DataSet dsdcno = objbs.CheckduplicateDC_edit(sTableName, txtbillno.Text, iSalesID);
                if (dsdcno.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Bill.No Already Exists. Please Enter Different Bill No.');", true);
                    txtdcno.Focus();
                    return;
                }

                int salesid = objbs.updatewholesalesnew(iSalesID, lblPrefix.Text, yearss.Text, sTableName, date, Convert.ToInt32(ddlPayMode.SelectedValue), txtNarrations.Text, Convert.ToInt32(ddlcustomer.SelectedValue), txtmbl.Text, txtAddress.Text, Convert.ToDouble(txtgrandamount.Text), Convert.ToDouble(txtTaxamt.Text), Convert.ToDouble(txtgrandtotal.Text), Convert.ToInt32(0), Convert.ToDouble(txttdiscper.Text), Convert.ToDouble(txttdiscamt.Text), Convert.ToDouble(lbltotalitems.InnerText), txtdcno.Text, Convert.ToDouble(txtdiscamt.Text), Convert.ToInt32(rdbtype.SelectedValue), Convert.ToDouble(txtDeliverCharge.Text), txtbillno.Text, Logintypeid, Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtigst.Text), rbdsalestype.SelectedValue, txtVehicleNo.Text);

                #region

                DataSet dsTransSaless = objbs.GetTransSalesEdit("tblTransWholeSales_" + sTableName, salesid);
                if (dsTransSaless.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTransSaless.Tables[0].Rows.Count; i++)
                    {
                        string Type = dsTransSaless.Tables[0].Rows[i]["Type"].ToString();
                        int ddldef = Convert.ToInt32(dsTransSaless.Tables[0].Rows[i]["Item"]);
                        string Amount = Convert.ToString(dsTransSaless.Tables[0].Rows[i]["Amount"]);
                        if (Amount != "")
                        {
                            double qty = Convert.ToDouble(dsTransSaless.Tables[0].Rows[i]["Qty"].ToString());
                            int update = objbs.updateSalesStock1(qty, Convert.ToInt32(ddldef),  sTableName,Logintypeid);

                            if (txtorderno.Text == "")
                                txtorderno.Text = "0";
                            if (Convert.ToInt32(txtorderno.Text) != 0 && Type != "N")
                            {
                                int updateOrderqty = objbs.updateorderqty(Convert.ToInt32(txtorderno.Text), qty, Convert.ToInt32(ddldef));
                            }

                        }
                    }
                }

                int iTransDelete = objbs.DeleteTransSalesNew("tblTransWholeSales_" + sTableName, salesid);

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField hdtype = (HiddenField)GridView2.Rows[vLoop].FindControl("hdtype");
                    DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");

                    TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                    TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");

                    TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                    TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");

                    TextBox txtTaxamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtTaxamount");
                    TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtAmount");
                    TextBox txtMRP = (TextBox)GridView2.Rows[vLoop].FindControl("txtMRP");
                    DropDownList drpPackType = (DropDownList)GridView2.Rows[vLoop].FindControl("drpPackType");


                    if (Convert.ToDouble(txtSQty.Text) > 0)
                    {
                        int transsales = objbs.inserttranswholesales(sTableName, salesid, Convert.ToInt32(drpItem.SelectedValue), Convert.ToDouble(txtSQty.Text), Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtTaxamount.Text), Convert.ToDouble(txtAmount.Text), Convert.ToDouble(txttdiscper.Text), Convert.ToDouble(txttdiscamt.Text), Convert.ToDouble(txtDeliverCharge.Text), "", txtorderno.Text, hdtype.Value, Logintypeid, Convert.ToInt32(drpPackType.SelectedValue), Convert.ToDouble(txtMRP.Text),Logintypeid);
                    }
                }

             //   string yourUrl = "InvoicePrint.aspx?InvoiceId=" + salesid;
              //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);


              //  string yourUrl = "WholeSalesPrintnew.aspx?ISalesId=" + salesid;
               // ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                if (btnadd.Text == "Update")
                {
                    Response.Redirect("WholeSalesGrid.aspx");
                }
                else if (txtorderno.Text == "" || txtorderno.Text == "0")
                {
                    Refersh();
                }
                else
                {
                    Response.Redirect("WholeSalesGrid.aspx");
                }

                #endregion
            }

        }

        private void RateCalculation()
        {

        }
        private void Calculation()
        {
            int SNo = 1;

            double TtlQty = 0;

            double SubTtl = 0;
            double TtlTax = 0;
            double GrandTtl = 0;

            double TtlDiscAmt = 0;

            if (txttdiscper.Text == "")
                txttdiscper.Text = "0";
            if (txtDeliverCharge.Text == "")
                txtDeliverCharge.Text = "0";

            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                DropDownList ddlitem = (DropDownList)GridView2.Rows[vLoop].FindControl("ddlitem");

                TextBox txtSQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtSQty");
                TtlQty += Convert.ToDouble(txtSQty.Text);


                TextBox txtMRP = (TextBox)GridView2.Rows[vLoop].FindControl("txtMRP");
                   
                TextBox txttax = (TextBox)GridView2.Rows[vLoop].FindControl("txttax");
                
                TextBox txtrate = (TextBox)GridView2.Rows[vLoop].FindControl("txtrate");


                

             

                double DiscAmt = ((Convert.ToDouble(txtSQty.Text) * Convert.ToDouble(txtrate.Text)) * Convert.ToDouble(txttdiscper.Text)) / 100;
                TtlDiscAmt += DiscAmt;

                double SunTotal = (Convert.ToDouble(txtSQty.Text) * Convert.ToDouble(txtrate.Text)) - DiscAmt;

                SubTtl += SunTotal;
                TtlTax += (SunTotal * Convert.ToDouble(txttax.Text)) / 100;
                GrandTtl += (SunTotal + ((SunTotal * Convert.ToDouble(txttax.Text)) / 100));

                SNo++;
            }

            txtgrandamount.Text = SubTtl.ToString("f2");
            txtTaxamt.Text = TtlTax.ToString("f2");

            if (rbdsalestype.SelectedValue == "1")
            {
                txtcgst.Text = Convert.ToDouble(Convert.ToDouble(TtlTax) / 2).ToString("f2");
                txtsgst.Text = Convert.ToDouble(Convert.ToDouble(TtlTax) / 2).ToString("f2");
                txtigst.Text = "0";
            }
            else
            {
                txtcgst.Text = "0";
                txtsgst.Text = "0";
                txtigst.Text = TtlTax.ToString("f2");
            }

            txtdiscamt.Text = TtlDiscAmt.ToString("f2");
            txtgrandtotal.Text = (GrandTtl + Convert.ToDouble(txtDeliverCharge.Text)).ToString("f2");

            txttdiscamt.Text = TtlDiscAmt.ToString("f2");

            lbltotalitems.InnerText = TtlQty.ToString("f2");

            double r;
            double roundoff = Convert.ToDouble(txtgrandtotal.Text) - Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            if (roundoff >= 0.5)
            {
                r = Math.Round(Convert.ToDouble(txtgrandtotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            }
            lbldisplay.InnerText = string.Format("{0:N2}", r);

            txtsno.Text = SNo.ToString();
            txtsno.Focus();
        }

        void Refersh()
        {
            #region

            DataSet dssalesNo = objbs.getcrsalesno(sTableName);
            txtbillno.Text = dssalesNo.Tables[0].Rows[0]["BillNo"].ToString();



            DataSet dspaymode = objbs.getpaymode();
            if (dspaymode.Tables[0].Rows.Count > 0)
            {
                ddlPayMode.DataSource = dspaymode.Tables[0];
                ddlPayMode.DataTextField = "PayMode";
                ddlPayMode.DataValueField = "PayModeId";
                ddlPayMode.DataBind();
                ddlPayMode.Items.Insert(0, "Payment");

            }


            DataSet dsCustomer = objbs.getgridforcustsale();
            if (dsCustomer.Tables[0].Rows.Count > 0)
            {
                ddlcustomer.DataSource = dsCustomer.Tables[0];
                ddlcustomer.DataTextField = "CustomerName";
                ddlcustomer.DataValueField = "LedgerID";
                ddlcustomer.DataBind();
                ddlcustomer.Items.Insert(0, "Select Dealer");


            }
            else
            {
                ddlcustomer.Items.Insert(0, "Select Dealer");
            }

            //DataSet dsitem = objbs.selectitems_wholesales(sTableName, Convert.ToInt16(ddlcustomer.SelectedValue));
            //if (dsitem.Tables[0].Rows.Count > 0)
            //{
            //    ddlitem.DataSource = dsitem.Tables[0];
            //    ddlitem.DataTextField = "Definition";
            //    ddlitem.DataValueField = "CategoryUserID";
            //    ddlitem.DataBind();
            //    ddlitem.Items.Insert(0, "Select Item");


            //}
            //else
            //{
            //    ddlitem.Items.Insert(0, "Select Item");
            //}
            #endregion

            ddlitem.SelectedIndex = 0;
            txtqty.Text = "0";
            txtrate.Text = "0";
            txttax.Text = "0";
            txtstock.Text = "0";


            txtgrandamount.Text = "0";
            txtTaxamt.Text = "0";
            txtgrandtotal.Text = "0";

            txtdiscamt.Text = "0";
            lbldisplay.InnerText = "0";

            txttdiscper.Text = "0";
            txttdiscamt.Text = "0";

            GridView2.DataSource = null;
            GridView2.DataBind();

            ViewState["CurrentTable1"] = null;


            txttdiscper.Enabled = false;
            txttdiscamt.Enabled = false;

        }

    }
}