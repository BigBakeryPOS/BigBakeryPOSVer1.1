using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class receipt : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sFrom = "";
        string sBranch = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {

                txtbankname.Enabled = false;
                txtrefno.Enabled = false;

                DataSet ds = objBs.Receiptno("tblReceipt_" + sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // int iBillNo = ds.Tables[0].Rows[0]["billno"].ToString();
                    if (ds.Tables[0].Rows[0]["ReceiptNo"].ToString() == "")
                        txtreceiptno.Text = "1";
                    else
                        txtreceiptno.Text = ds.Tables[0].Rows[0]["ReceiptNo"].ToString();

                    txtreceiptdate.Text = DateTime.Today.ToString("dd/MM/yyyy");


                }

                //int iTransSalesId = objBs.TransSalesID("tblTransSales_"+sTableName);
                if (!IsPostBack)
                {
                    lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                    txtreceiptdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    DataSet dsCustomer = objBs.CustomerID(Convert.ToInt32(lblUserID.Text), "tblSales_" + sTableName);
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        ddlcustomerID.DataSource = dsCustomer.Tables[0];
                        ddlcustomerID.DataTextField = "CustomerName";
                        ddlcustomerID.DataValueField = "CustomerID";
                        ddlcustomerID.DataBind();
                        ddlcustomerID.Items.Insert(0, "Select Contact");
                        // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                    }
                }
                //ddlcustomerID.Text = objBs.CustomerID().ToString();
                DataSet d1 = objBs.Getpaymentmode();
                if (d1.Tables[0].Rows.Count > 0)
                {
                    ddmodeofpayment.DataSource = d1.Tables[0];
                    ddmodeofpayment.DataTextField = "Payment_Mode";
                    ddmodeofpayment.DataValueField = "Payment_ID";
                    ddmodeofpayment.DataBind();
                    ddmodeofpayment.Items.Insert(0, "Select Payment Mode");
                }

            }

            string ReceiptID = Request.QueryString.Get("ReceiptID");
            if (ReceiptID != null)
            {
                btnadd.Text = "Cancel";
                DataSet DR = objBs.GetReceiptNo(Convert.ToInt32(ReceiptID), "tblReceipt_" + sTableName);
                if (DR.Tables[0].Rows.Count > 0)
                {
                    txtreceiptno.Text = DR.Tables[0].Rows[0]["ReceiptNo"].ToString();
                    txtreceiptdate.Text = DR.Tables[0].Rows[0]["ReceiptDate"].ToString();
                    ddlcustomerID.SelectedValue = DR.Tables[0].Rows[0]["CustomerID"].ToString();
                    ddmodeofpayment.SelectedValue = DR.Tables[0].Rows[0]["Payment_ID"].ToString();
                    DataSet dsCustDet = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));
                    if (dsCustDet.Tables[0].Rows.Count > 0)
                    {
                        txtcustomername.Text = dsCustDet.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtaddress.Text = dsCustDet.Tables[0].Rows[0]["Address"].ToString();
                        txtcity.Text = dsCustDet.Tables[0].Rows[0]["City"].ToString();
                        txtarea.Text = dsCustDet.Tables[0].Rows[0]["Area"].ToString();
                        txtpincode.Text = dsCustDet.Tables[0].Rows[0]["Pincode"].ToString();
                        txtcuscode.Text = dsCustDet.Tables[0].Rows[0]["CustomerID"].ToString();

                    }

                    DataSet dsbill = objBs.GETBillDet(Convert.ToInt32(ReceiptID), "tblTransReceipt_" + sTableName, "tblSales_" + sTableName);
                    if (dsbill.Tables[0].Rows.Count > 0)
                    {
                        int icount = dsbill.Tables[0].Rows.Count;
                        DataSet dsReceiptDet = objBs.GetReceiptDetails((Convert.ToInt32(ddlcustomerID.SelectedValue)), "tblSales_" + sTableName, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName);
                        if (dsReceiptDet.Tables[0].Rows.Count > 0)
                        {
                            ddbillno1.DataSource = dsReceiptDet.Tables[0];
                            ddbillno1.DataTextField = "BillNo";
                            ddbillno1.DataValueField = "BillNo";
                            ddbillno1.DataBind();
                            ddbillno1.Items.Insert(0, "Select Bill No");

                            ddbillno2.DataSource = dsReceiptDet.Tables[0];
                            ddbillno2.DataTextField = "BillNo";
                            ddbillno2.DataValueField = "BillNo";
                            ddbillno2.DataBind();
                            ddbillno2.Items.Insert(0, "Select Bill No");

                            ddbillno3.DataSource = dsReceiptDet.Tables[0];
                            ddbillno3.DataTextField = "BillNo";
                            ddbillno3.DataValueField = "BillNo";
                            ddbillno3.DataBind();
                            ddbillno3.Items.Insert(0, "Select Bill No");

                            ddbillno4.DataSource = dsReceiptDet.Tables[0];
                            ddbillno4.DataTextField = "BillNo";
                            ddbillno4.DataValueField = "BillNo";
                            ddbillno4.DataBind();
                            ddbillno4.Items.Insert(0, "Select Bill No");

                            // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                        }
                        Decimal Amt = 0, BillAmt = 0, Bal = 0, dNetAmt = 0, dBalCal = 0;

                        if (icount <= 1)
                        {

                            ddbillno1.SelectedValue = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            txtbilldate1.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["NetAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Balance"].ToString());

                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Amount"].ToString());
                            dBalCal = BillAmt - Amt;
                            txtbillamount1.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance1.Text = Decimal.Round(dBalCal, 2).ToString("f2");


                        }

                        else if (icount <= 2)
                        {
                            ddbillno1.SelectedValue = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            txtbilldate1.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Amount"].ToString());
                            txtbillamount1.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance1.Text = Decimal.Round(Bal, 2).ToString("f2");

                            ddbillno2.SelectedValue = dsbill.Tables[0].Rows[1]["BillNo"].ToString();
                            txtbilldate2.Text = dsbill.Tables[0].Rows[1]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["Amount"].ToString());
                            txtbillamount2.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance2.Text = Decimal.Round(Bal, 2).ToString("f2");


                        }

                        else if (icount <= 3)
                        {
                            ddbillno1.SelectedValue = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            txtbilldate1.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Amount"].ToString());
                            txtbillamount1.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance1.Text = Decimal.Round(Bal, 2).ToString("f2");

                            ddbillno2.SelectedValue = dsbill.Tables[0].Rows[1]["BillNo"].ToString();
                            txtbilldate2.Text = dsbill.Tables[0].Rows[1]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["Amount"].ToString());
                            txtbillamount2.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance2.Text = Decimal.Round(Bal, 2).ToString("f2");

                            ddbillno3.SelectedValue = dsbill.Tables[0].Rows[2]["BillNo"].ToString();
                            txtbilldate3.Text = dsbill.Tables[0].Rows[2]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[2]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[2]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[2]["Amount"].ToString());
                            txtbillamount3.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance3.Text = Decimal.Round(Bal, 2).ToString("f2");


                        }

                        else if (icount <= 4)
                        {
                            ddbillno1.SelectedValue = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            txtbilldate1.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[0]["Amount"].ToString());
                            txtbillamount1.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance1.Text = Decimal.Round(Bal, 2).ToString("f2");

                            ddbillno2.SelectedValue = dsbill.Tables[0].Rows[1]["BillNo"].ToString();
                            txtbilldate2.Text = dsbill.Tables[0].Rows[1]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[1]["Amount"].ToString());
                            txtbillamount2.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance2.Text = Decimal.Round(Bal, 2).ToString("f2");

                            ddbillno3.SelectedValue = dsbill.Tables[0].Rows[2]["BillNo"].ToString();
                            txtbilldate3.Text = dsbill.Tables[0].Rows[2]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[2]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[2]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[2]["Amount"].ToString());
                            txtbillamount3.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance3.Text = Decimal.Round(Bal, 2).ToString("f2");

                            ddbillno4.SelectedValue = dsbill.Tables[0].Rows[3]["BillNo"].ToString();
                            txtbilldate4.Text = dsbill.Tables[0].Rows[3]["BillDate"].ToString();
                            BillAmt = Convert.ToDecimal(dsbill.Tables[0].Rows[3]["BillAmount"].ToString());
                            Bal = Convert.ToDecimal(dsbill.Tables[0].Rows[3]["Balance"].ToString());
                            Amt = Convert.ToDecimal(dsbill.Tables[0].Rows[3]["Amount"].ToString());
                            txtbillamount4.Text = Decimal.Round(BillAmt, 2).ToString("f2");
                            txtbalance4.Text = Decimal.Round(Bal, 2).ToString("f2");


                        }
                    }








                }
            }

            

        }
        protected void ddlcustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCustDet = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));
            if (dsCustDet.Tables[0].Rows.Count > 0)
            {
                txtcustomername.Text = dsCustDet.Tables[0].Rows[0]["CustomerName"].ToString();
                txtaddress.Text = dsCustDet.Tables[0].Rows[0]["Address"].ToString();
                txtcity.Text = dsCustDet.Tables[0].Rows[0]["City"].ToString();
                txtarea.Text = dsCustDet.Tables[0].Rows[0]["Area"].ToString();
                txtpincode.Text = dsCustDet.Tables[0].Rows[0]["Pincode"].ToString();
                txtcuscode.Text = dsCustDet.Tables[0].Rows[0]["CustomerID"].ToString();
               
            }



            DataSet dsReceiptDet = objBs.GetReceiptDetails((Convert.ToInt32(ddlcustomerID.SelectedValue)), "tblSales_" + sTableName, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName);
            if (dsReceiptDet.Tables[0].Rows.Count > 0)
            {
                ddbillno1.DataSource = dsReceiptDet.Tables[0];
                ddbillno1.DataTextField = "BillNo";
                ddbillno1.DataValueField = "BillNo";
                ddbillno1.DataBind();
                ddbillno1.Items.Insert(0, "Select Bill No");
                // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

            }

            DataSet dsReceiptDet2 = objBs.GetReceiptDetails((Convert.ToInt32(ddlcustomerID.SelectedValue)), "tblSales_" + sTableName, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName);
            if (dsReceiptDet.Tables[0].Rows.Count > 0)
            {
                ddbillno2.DataSource = dsReceiptDet.Tables[0];
                ddbillno2.DataTextField = "BillNo";
                ddbillno2.DataValueField = "BillNo";
                ddbillno2.DataBind();
                ddbillno2.Items.Insert(0, "Select Bill No");
                // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

            }

            DataSet dsReceiptDet3 = objBs.GetReceiptDetails((Convert.ToInt32(ddlcustomerID.SelectedValue)), "tblSales_" + sTableName, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName);
            if (dsReceiptDet.Tables[0].Rows.Count > 0)
            {
                ddbillno3.DataSource = dsReceiptDet.Tables[0];
                ddbillno3.DataTextField = "BillNo";
                ddbillno3.DataValueField = "BillNo";
                ddbillno3.DataBind();
                ddbillno3.Items.Insert(0, "Select Bill No");
                // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

            }

            DataSet dsReceiptDet4 = objBs.GetReceiptDetails((Convert.ToInt32(ddlcustomerID.SelectedValue)), "tblSales_" + sTableName, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName);
            if (dsReceiptDet.Tables[0].Rows.Count > 0)
            {
                ddbillno4.DataSource = dsReceiptDet.Tables[0];
                ddbillno4.DataTextField = "BillNo";
                ddbillno4.DataValueField = "BillNo";
                ddbillno4.DataBind();
                ddbillno4.Items.Insert(0, "Select Bill No");
                // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

            }
           
            //int isalesid = objBs.SalesId();
            //DataSet dsBillAmount = objBs.GetBillAmount(isalesid);
            //if (dsBillAmount.Tables[0].Rows.Count > 0)
            //{

            //    txtbillamount1.Text = dsBillAmount.Tables[0].Rows[0]["Total"].ToString();

            //}
            


            //DataSet dsOpeningbalance = objBs.GetCustomerAmount(Convert.ToInt32(ddlcustomerID.SelectedValue));
            //if (dsOpeningbalance.Tables[0].Rows.Count > 0)
            //{

            //    txtbillamount1.Text = dsOpeningbalance.Tables[0].Rows[0]["OpeningBalance"].ToString();
            //}
            //int iTransSalesId = objBs.TransSalesID();
            //int isalesid = objBs.SalesId();
            //DataSet dsSalesTotal = objBs.GetSalesTotalAmount(isalesid);
            //if (dsSalesTotal.Tables[0].Rows.Count > 0)
            //{
            //    // txtbalance1.Text=iTransSalesId-
            //    txtbillamount1.Text = dsSalesTotal.Tables[0].Rows[0]["OpeningBalance"].ToString();
            //}

        }

        protected void Add_Click(object sender, EventArgs e)
        {
             sFrom = Request.QueryString.Get("From");
            {
                 sBranch = sFrom + '-' + DateTime.Now.ToString();
            }
            if (btnadd.Text == "Save")
            {
                if (ddlcustomerID.SelectedValue == "Select Customer")
                {

                    lblerrorname.Text = "Please Select Customer Name";
                }
                else

                    if (ddmodeofpayment.SelectedValue == "Select Payment Mode")
                    {

                        lblerror.Text = "Please Select Payment mode";
                    }
                    else

                        if (ddbillno1.SelectedValue == "Select Bill No")
                        {

                            lblerrortable.Text = "Please Select Bill No";
                        }

                        else
                            if (txtamount1.Text == "")
                            {

                                lblerrortable.Text = "Please enter Amount";
                            }

                            else
                            {
                                double dBalance = 0, dTotal = 0;

                                int iStatus = objBs.insertReceipt("tblReceipt_" + sTableName, Convert.ToInt32(lblUserID.Text), txtreceiptno.Text, txtreceiptdate.Text, Convert.ToInt32(ddlcustomerID.SelectedValue), Convert.ToInt32(ddmodeofpayment.SelectedValue), txtbankname.Text, txtrefno.Text, sBranch);
                                int isalesid = objBs.SalesId("tblSales_"+sTableName);
                                int ireceiptid = objBs.ReceiptId("tblReceipt_"+sTableName);





                                if (txtamount1.Text != "")
                                {
                                    Decimal dBal = Convert.ToDecimal(txtbalance1.Text) - Convert.ToDecimal(txtamount1.Text);
                                    int iStatus1 = objBs.insertTransReceipt("tblTransReceipt_" + sTableName, Convert.ToInt32(ddbillno1.SelectedValue), Convert.ToInt32(txtreceiptno.Text), txtbillamount1.Text, string.Format("{0:N2}", dBal), txtamount1.Text);

                                }
                                if (txtamount2.Text != "")
                                {
                                    double dBal2 = Convert.ToDouble(txtbalance2.Text) - Convert.ToDouble(txtamount2.Text);
                                    int iStatus2 = objBs.insertTransReceipt("tblTransReceipt_" + sTableName, Convert.ToInt32(ddbillno2.SelectedValue), Convert.ToInt32(txtreceiptno.Text), txtbillamount2.Text, string.Format("{0:N2}", dBal2), txtamount2.Text);

                                }
                                if (txtamount3.Text != "")
                                {
                                    double dBal3 = Convert.ToDouble(txtbalance3.Text) - Convert.ToDouble(txtamount3.Text);
                                    int iStatus3 = objBs.insertTransReceipt("tblTransReceipt_" + sTableName, Convert.ToInt32(ddbillno3.SelectedValue), Convert.ToInt32(txtreceiptno.Text), txtbillamount3.Text, string.Format("{0:N2}", dBal3), txtamount4.Text);

                                }
                                if (txtamount3.Text != "")
                                {
                                    double dBal4 = Convert.ToDouble(txtbalance4.Text) - Convert.ToDouble(txtamount4.Text);
                                    int iStatus4 = objBs.insertTransReceipt("tblTransReceipt_" + sTableName, Convert.ToInt32(ddbillno4.SelectedValue), Convert.ToInt32(txtreceiptno.Text), txtbillamount4.Text, string.Format("{0:N2}", dBal4), txtamount4.Text);

                                }
                                if (Session["Mode"] == "Switch")
                                {
                                    Session["Mode"] = "";
                                    Session["UserID"] = "";
                                     Session["UserName"] = "";
                                     Response.Redirect("../Accountsbootstrap/login.aspx");
                                }
                                else
                                    Response.Redirect("../Accountsbootstrap/ReceiptGrid.aspx");
                            }
            }
            else
            {
                if (Session["Mode"] == "Switch")
                {
                    Session["Mode"] = "";
                    Session["UserID"] = "";
                    Session["UserName"] = "";
                    Response.Redirect("../Accountsbootstrap/login.aspx");
                }
                else
                Response.Redirect("../Accountsbootstrap/ReceiptGrid.aspx");
            }
        
        }
        protected void txtbalance1_TextChanged(object sender, EventArgs e)
        {
            Decimal iamount = (Convert.ToDecimal( txtbillamount1.Text)) -(Convert.ToDecimal (txtbalance1.Text));
            txtamount1.Text = Decimal.Round(iamount,2).ToString("f2");
            Decimal iGross1 = 0;
            if (txtamount1.Text != "")
                iGross1 = Convert.ToDecimal(txtamount1.Text);

            Decimal iTotalAmount = iGross1;
           // txttotal.Text = Convert.ToString(iTotalAmount);
        }

        protected void ddbillno1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal IbillAmt1 = 0, IBAL1 = 0;
            DataSet dContactType = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));
            if (dContactType.Tables[0].Rows[0]["ContactTypeID"].ToString() == "1")
            {
                DataSet dsCustsalesID = objBs.getCustomerReceipt(Convert.ToInt32(ddbillno1.SelectedValue), "tblSales_" + sTableName);
                if (dsCustsalesID.Tables[0].Rows.Count > 0)
                {
                    // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                    txtbilldate1.Text = dsCustsalesID.Tables[0].Rows[0]["BillDate"].ToString();


                    IbillAmt1 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["BillAmount"].ToString());
                    txtbillamount1.Text = Decimal.Round(IbillAmt1, 2).ToString("f2");
                    txtbillamount1.Enabled = false;
                    //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                    DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno1.SelectedValue)), "tblTransReceipt_" + sTableName);
                    Decimal iBal = 0, iAmount = 0;
                    if (dsRep.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                        {
                            iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                        }
                        iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                        txtbalance1.Text = Decimal.Round((IbillAmt1 - iBal), 2).ToString("f2");
                        txtbalance1.Enabled = false;
                    }
                    else
                    {
                        IBAL1 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                        txtbalance1.Text = Decimal.Round(IBAL1, 2).ToString("f2");

                    }
                }
            }
            else
            {
            DataSet dssalesID = objBs.GetSalesIDReceipt(Convert.ToInt32(ddbillno1.SelectedValue), "tblSales_" + sTableName);
            if (dssalesID.Tables[0].Rows.Count > 0)
            {
                // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                txtbilldate1.Text = dssalesID.Tables[0].Rows[0]["BillDate"].ToString();


                IbillAmt1 = Convert.ToDecimal(dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                txtbillamount1.Text = Decimal.Round(IbillAmt1, 2).ToString("f2");
                txtbillamount1.Enabled = false;
                //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno1.SelectedValue)), "tblTransReceipt_" + sTableName);
                Decimal iBal = 0, iAmount = 0;
                if (dsRep.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                    {
                        iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                    }
                    iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                    txtbalance1.Text = Decimal.Round((IbillAmt1 - iBal), 2).ToString("f2");
                    txtbalance1.Enabled = false;
                }
                else
                {
                    IBAL1 = Convert.ToDecimal(dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                    txtbalance1.Text = Decimal.Round(IBAL1, 2).ToString("f2");

                }


            }

            }

        }
        

        protected void ddmodeofpayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddmodeofpayment.SelectedValue == "1")
            {
                txtbankname.Enabled = false;
                txtrefno.Enabled = false;
            }

            else
            {
                txtbankname.Enabled = true;
                txtrefno.Enabled = true;
            }
        }

        protected void btnop_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/OutstandingPayment.aspx");
        }

        protected void ddbillno2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal IbillAmt2 = 0, IBAL2=0;
            DataSet dContactType = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));
            if (dContactType.Tables[0].Rows[0]["ContactTypeID"].ToString() == "1")
            {
                DataSet dsCustsalesID = objBs.getCustomerReceipt(Convert.ToInt32(ddbillno2.SelectedValue), "tblSales_" + sTableName);
                if (dsCustsalesID.Tables[0].Rows.Count > 0)
                {
                    // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                    txtbilldate1.Text = dsCustsalesID.Tables[0].Rows[0]["BillDate"].ToString();


                    IbillAmt2 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["BillAmount"].ToString());
                    txtbillamount2.Text = Decimal.Round(IbillAmt2, 2).ToString("f2");
                    txtbillamount2.Enabled = false;
                    //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                    DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno2.SelectedValue)), "tblTransReceipt_" + sTableName);
                    Decimal iBal = 0, iAmount = 0;
                    if (dsRep.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                        {
                            iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                        }
                        iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                        txtbalance2.Text = Decimal.Round((IbillAmt2 - iBal), 2).ToString("f2");
                        txtbalance2.Enabled = false;
                    }
                    else
                    {
                        IBAL2 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                        txtbalance2.Text = Decimal.Round(IBAL2, 2).ToString("f2");

                    }
                }
            }
            else
            {
            DataSet dssalesID = objBs.GetSalesIDReceipt(Convert.ToInt32(ddbillno2.SelectedValue),"tblSales_"+sTableName);
            if (dssalesID.Tables[0].Rows.Count > 0)
            {
                // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                txtbilldate2.Text = dssalesID.Tables[0].Rows[0]["BillDate"].ToString();


                IbillAmt2 = Convert.ToDecimal( dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                txtbillamount2.Text = Decimal.Round(IbillAmt2, 2).ToString("f2");
                txtbillamount2.Enabled = false;
                //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno2.SelectedValue)), "tblTransReceipt_" + sTableName);
               Decimal  iBal = 0, iAmount = 0;
                if (dsRep.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                    {
                        iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                    }
                    iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                    txtbalance2.Text = Decimal.Round((IbillAmt2 - iBal), 2).ToString("f2");
                    txtbalance2.Enabled = false;
                }
                else
                {
                    IBAL2 =Convert.ToDecimal( dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                    txtbalance2.Text = Decimal.Round(IBAL2, 2).ToString("f2");

                }
                if (ddbillno2.Text == ddbillno1.Text)
                {
                    txtbillamount2.Enabled = false;
                }
                else
                {
                    txtbillamount2.Enabled = true;
                }
            }
        }}

        protected void ddbillno3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal IbillAmt3 = 0, IBAL3 = 0;
            DataSet dContactType = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));
            if (dContactType.Tables[0].Rows[0]["ContactTypeID"].ToString() == "1")
            {
                DataSet dsCustsalesID = objBs.getCustomerReceipt(Convert.ToInt32(ddbillno3.SelectedValue), "tblSales_" + sTableName);
                if (dsCustsalesID.Tables[0].Rows.Count > 0)
                {
                    // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                    txtbilldate1.Text = dsCustsalesID.Tables[0].Rows[0]["BillDate"].ToString();


                    IbillAmt3 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["BillAmount"].ToString());
                    txtbillamount3.Text = Decimal.Round(IbillAmt3, 2).ToString("f2");
                    txtbillamount3.Enabled = false;
                    //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                    DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno3.SelectedValue)), "tblTransReceipt_" + sTableName);
                    Decimal iBal = 0, iAmount = 0;
                    if (dsRep.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                        {
                            iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                        }
                        iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                        txtbalance3.Text = Decimal.Round((IbillAmt3- iBal), 2).ToString("f2");
                        txtbalance3.Enabled = false;
                    }
                    else
                    {
                        IBAL3 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                        txtbalance3.Text = Decimal.Round(IBAL3, 2).ToString("f2");

                    }
                }
            }
            else
            {
            DataSet dssalesID = objBs.GetSalesIDReceipt(Convert.ToInt32(ddbillno3.SelectedValue), "tblSales_" + sTableName);
            if (dssalesID.Tables[0].Rows.Count > 0)
            {
                // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                txtbilldate3.Text = dssalesID.Tables[0].Rows[0]["BillDate"].ToString();


               IbillAmt3 =Convert.ToDecimal( dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
               txtbillamount3.Text= Decimal.Round(IbillAmt3, 2).ToString("f2");
               txtbillamount3.Enabled = false;
                //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
               DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno3.SelectedValue)), "tblTransReceipt_" + sTableName);
                Decimal iBal = 0, iAmount = 0;
                if (dsRep.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                    {
                        iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                    }
                    iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                    txtbalance3.Text = Decimal.Round((IbillAmt3 - iBal), 2).ToString("f2");
                    txtbalance3.Enabled = false;
                }
                else
                {
                   IBAL3 =Convert.ToDecimal( dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                   txtbalance3.Text = Decimal.Round(IBAL3, 2).ToString("f2");

                }
            
            }
            }
        }
        

        protected void ddbillno4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal IbillAmt4 = 0, IBAL4 = 0;
            DataSet dContactType = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));
            if (dContactType.Tables[0].Rows[0]["ContactTypeID"].ToString() == "1")
            {
                DataSet dsCustsalesID = objBs.getCustomerReceipt(Convert.ToInt32(ddbillno3.SelectedValue), "tblSales_" + sTableName);
                if (dsCustsalesID.Tables[0].Rows.Count > 0)
                {
                    // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                    txtbilldate1.Text = dsCustsalesID.Tables[0].Rows[0]["BillDate"].ToString();


                    IbillAmt4 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["BillAmount"].ToString());
                    txtbillamount4.Text = Decimal.Round(IbillAmt4, 2).ToString("f2");
                    txtbillamount4.Enabled = false;
                    //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                    DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno3.SelectedValue)), "tblTransReceipt_" + sTableName);
                    Decimal iBal = 0, iAmount = 0;
                    if (dsRep.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                        {
                            iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                        }
                        iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                        txtbalance4.Text = Decimal.Round((IbillAmt4 - iBal), 2).ToString("f2");
                        txtbalance4.Enabled = false;
                    }
                    else
                    {
                        IBAL4 = Convert.ToDecimal(dsCustsalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                        txtbalance4.Text = Decimal.Round(IBAL4, 2).ToString("f2");

                    }
                }
            }
            else
            {
            DataSet dssalesID = objBs.GetSalesIDReceipt(Convert.ToInt32(ddbillno4.SelectedValue), "tblSales_" + sTableName);
            if (dssalesID.Tables[0].Rows.Count > 0)
            {
                // ddlbillno.Text = dssalesID.Tables[0].Rows[0]["BillNo"].ToString();
                txtbilldate4.Text = dssalesID.Tables[0].Rows[0]["BillDate"].ToString();


                IbillAmt4 =Convert.ToDecimal( dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                txtbillamount4.Text = Decimal.Round(IbillAmt4, 2).ToString("f2");
                txtbillamount4.Enabled = false;
                //   txtbalance1.Text = dssalesID.Tables[0].Rows[0]["NetAmount"].ToString();
                DataSet dsRep = objBs.GetReceiptAmountDet(Convert.ToInt32((ddbillno4.SelectedValue)), "tblTransReceipt_" + sTableName);
                Decimal iBal = 0, iAmount = 0;
                if (dsRep.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRep.Tables[0].Rows.Count; i++)
                    {
                        iBal += Convert.ToDecimal(dsRep.Tables[0].Rows[i]["Amount"].ToString());
                    }
                    iAmount = Convert.ToDecimal(dsRep.Tables[0].Rows[0]["BillAmount"].ToString());

                    txtbalance4.Text = Decimal.Round((IbillAmt4 - iBal), 2).ToString("f2");
                    txtbalance4.Enabled = false;
                }
                else
                {
                    IBAL4 =Convert.ToDecimal( dssalesID.Tables[0].Rows[0]["NetAmount"].ToString());
                    txtbalance4.Text = Decimal.Round(IBAL4, 2).ToString("f2");
                    

                }

            }
            }
        }

        protected void txtbalance2_TextChanged(object sender, EventArgs e)
        {
            int iamount2 = (Convert.ToInt32(txtbillamount2.Text)) - (Convert.ToInt32(txtbalance2.Text));
            txtamount2.Text = string.Format("{0:N2}", iamount2);
            int iGross2 = 0;
            if (txtamount2.Text != "")
                iGross2 = Convert.ToInt32(txtamount2.Text);

            int iTotalAmount2 = iGross2;
        }

        protected void txtbalance3_TextChanged(object sender, EventArgs e)
        {
            int iamount3 = (Convert.ToInt32(txtbillamount3.Text)) - (Convert.ToInt32(txtbalance3.Text));
            txtamount3.Text = string.Format("{0:N2}", iamount3);
            int iGross3 = 0;
            if (txtamount3.Text != "")
                iGross3 = Convert.ToInt32(txtamount3.Text);

            int iTotalAmount3 = iGross3;

        }

        protected void txtbalance4_TextChanged(object sender, EventArgs e)
        {
            int iamount4 = (Convert.ToInt32(txtbillamount4.Text)) - (Convert.ToInt32(txtbalance4.Text));
            txtamount4.Text = string.Format("{0:N2}", iamount4);
            int iGross4 = 0;
            if (txtamount4.Text != "")
                iGross4 = Convert.ToInt32(txtamount4.Text);

            int iTotalAmount4 = iGross4;

        }






        }
    }
