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
    public partial class ReceiptPrint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            string ReceiptID = Request.QueryString.Get("ReceiptID");
            if (ReceiptID != "" || ReceiptID != "")
            {
                DataSet DR = objBs.GetReceiptNo(Convert.ToInt32(ReceiptID), "tblReceipt_" + sTableName);
                if (DR.Tables[0].Rows.Count > 0)
                {
                    lblreceiptno.Text = DR.Tables[0].Rows[0]["ReceiptNo"].ToString();
                    lblreceiptdate.Text = DR.Tables[0].Rows[0]["ReceiptDate"].ToString();
                    lblcustomercode.Text = DR.Tables[0].Rows[0]["CustomerID"].ToString();
                    lblpaymentmode.Text = DR.Tables[0].Rows[0]["Payment_ID"].ToString();
                    DataSet dsCustDet = objBs.GetCustomerDetails(Convert.ToInt32(lblcustomercode.Text));
                    if (dsCustDet.Tables[0].Rows.Count > 0)
                    {
                        lblcustomername.Text = dsCustDet.Tables[0].Rows[0]["CustomerName"].ToString();
                        lbladdress.Text = dsCustDet.Tables[0].Rows[0]["Address"].ToString();
                        lblcity.Text = dsCustDet.Tables[0].Rows[0]["City"].ToString();
                        lblarea.Text = dsCustDet.Tables[0].Rows[0]["Area"].ToString();
                        lblpincode.Text = dsCustDet.Tables[0].Rows[0]["Pincode"].ToString();
                        lblcustomercode.Text = dsCustDet.Tables[0].Rows[0]["CustomerID"].ToString();

                    }
                    Decimal TAmt = 0;
                    DataSet dsbill = objBs.GETBillDet(Convert.ToInt32(ReceiptID), "tblTransReceipt_" + sTableName, "tblSales_" + sTableName);
                    DataSet Damt=objBs.GetRoundAmount(Convert.ToInt32(ReceiptID),sTableName);
                     DataSet DtotRec=objBs.TotalReceiptAmt(Convert.ToInt32(ReceiptID),sTableName);
                    if (dsbill.Tables[0].Rows.Count > 0)
                    {
                        int icount = dsbill.Tables[0].Rows.Count;
                        DataSet dsReceiptDet = objBs.GetReceiptDetails((Convert.ToInt32(lblcustomercode.Text)), "tblSales_" + sTableName, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName);
                        if (dsReceiptDet.Tables[0].Rows.Count > 0)
                        {
                            //lblbillno.DataSource = dsReceiptDet.Tables[0];
                            //lblbillno.DataTextField = "BillNo";
                            //lblbillno.DataValueField = "BillNo";
                            //lblbillno.DataBind();
                            //lblbillno.Items.Insert(0, "Select Bill No");

                            //ddbillno2.DataSource = dsReceiptDet.Tables[0];
                            //ddbillno2.DataTextField = "BillNo";
                            //ddbillno2.DataValueField = "BillNo";
                            //ddbillno2.DataBind();
                            //ddbillno2.Items.Insert(0, "Select Bill No");

                            //ddbillno3.DataSource = dsReceiptDet.Tables[0];
                            //ddbillno3.DataTextField = "BillNo";
                            //ddbillno3.DataValueField = "BillNo";
                            //ddbillno3.DataBind();
                            //ddbillno3.Items.Insert(0, "Select Bill No");

                            //ddbillno4.DataSource = dsReceiptDet.Tables[0];
                            //ddbillno4.DataTextField = "BillNo";
                            //ddbillno4.DataValueField = "BillNo";
                            //ddbillno4.DataBind();
                            //ddbillno4.Items.Insert(0, "Select Bill No");

                            // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                        }
                        if (icount <= 1)
                        {
                            lblbillno.Text = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            lblbilldate.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            lblbillamount.Text = dsbill.Tables[0].Rows[0]["BillAmount"].ToString();
                            lblbalance.Text = dsbill.Tables[0].Rows[0]["Balance"].ToString();
                            lblamount.Text = Damt.Tables[0].Rows[0]["RoundAmount"].ToString();

                        }

                        else if (icount <= 2)
                        {
                            lblbillno.Text = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            lblbilldate.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            lblbillamount.Text = dsbill.Tables[0].Rows[0]["BillAmount"].ToString();
                            lblbalance.Text = dsbill.Tables[0].Rows[0]["Balance"].ToString();
                            lblamount.Text = Damt.Tables[0].Rows[0]["RoundAmount"].ToString();

                            lblbillno1.Text = dsbill.Tables[0].Rows[1]["BillNo"].ToString();
                            lblbilldate1.Text = dsbill.Tables[0].Rows[1]["BillDate"].ToString();
                            lblbillamount1.Text = dsbill.Tables[0].Rows[1]["BillAmount"].ToString();
                            lblbalance1.Text = dsbill.Tables[0].Rows[1]["Balance"].ToString();
                            lblamount1.Text = Damt.Tables[0].Rows[1]["RoundAmount"].ToString();
                        }

                        else if (icount <= 3)
                        {
                            lblbillno.Text = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            lblbilldate.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            lblbillamount.Text = dsbill.Tables[0].Rows[0]["BillAmount"].ToString();
                            lblbalance.Text = dsbill.Tables[0].Rows[0]["Balance"].ToString();
                            lblamount.Text = Damt.Tables[0].Rows[0]["RoundAmount"].ToString();

                            lblbillno1.Text = dsbill.Tables[0].Rows[1]["BillNo"].ToString();
                            lblbilldate1.Text = dsbill.Tables[0].Rows[1]["BillDate"].ToString();
                            lblbillamount1.Text = dsbill.Tables[0].Rows[1]["BillAmount"].ToString();
                            lblbalance1.Text = dsbill.Tables[0].Rows[1]["Balance"].ToString();
                            lblamount1.Text = Damt.Tables[0].Rows[1]["RoundAmount"].ToString();

                            lblbillno2.Text = dsbill.Tables[0].Rows[2]["BillNo"].ToString();
                            lblbilldate2.Text = dsbill.Tables[0].Rows[2]["BillDate"].ToString();
                            lblbillamount2.Text = dsbill.Tables[0].Rows[2]["BillAmount"].ToString();
                            lblbalance2.Text = dsbill.Tables[0].Rows[2]["Balance"].ToString();
                            lblamount2.Text = Damt.Tables[0].Rows[2]["RoundAmount"].ToString();
                        }

                        else if (icount <= 4)
                        {
                            lblbillno.Text = dsbill.Tables[0].Rows[0]["BillNo"].ToString();
                            lblbilldate.Text = dsbill.Tables[0].Rows[0]["BillDate"].ToString();
                            lblbillamount.Text = dsbill.Tables[0].Rows[0]["BillAmount"].ToString();
                            lblbalance.Text = dsbill.Tables[0].Rows[0]["Balance"].ToString();
                            lblamount.Text = Damt.Tables[0].Rows[0]["RoundAmount"].ToString();

                            lblbillno1.Text = dsbill.Tables[0].Rows[1]["BillNo"].ToString();
                            lblbilldate1.Text = dsbill.Tables[0].Rows[1]["BillDate"].ToString();
                            lblbillamount1.Text = dsbill.Tables[0].Rows[1]["BillAmount"].ToString();
                            lblbalance1.Text = dsbill.Tables[0].Rows[1]["Balance"].ToString();
                            lblamount1.Text = Damt.Tables[0].Rows[1]["RoundAmount"].ToString();

                            lblbillno2.Text = dsbill.Tables[0].Rows[2]["BillNo"].ToString();
                            lblbilldate2.Text = dsbill.Tables[0].Rows[2]["BillDate"].ToString();
                            lblbillamount2.Text = dsbill.Tables[0].Rows[2]["BillAmount"].ToString();
                            lblbalance2.Text = dsbill.Tables[0].Rows[2]["Balance"].ToString();
                            lblamount2.Text = Damt.Tables[0].Rows[2]["RoundAmount"].ToString();

                            lblbillno3.Text = dsbill.Tables[0].Rows[3]["BillNo"].ToString();
                            lblbilldate3.Text = dsbill.Tables[0].Rows[3]["BillDate"].ToString();
                            lblbillamount3.Text = dsbill.Tables[0].Rows[3]["BillAmount"].ToString();
                            lblbalance3.Text = dsbill.Tables[0].Rows[3]["Balance"].ToString();
                            lblamount3.Text = Damt.Tables[0].Rows[3]["RoundAmount"].ToString();
                        }
                     
                        TAmt=Convert.ToDecimal( DtotRec.Tables[0].Rows[0]["SumAmount"].ToString());
                        lbltotalamount.InnerText = Decimal.Round(TAmt, 2).ToString("f2");
                        lblamountinwords.InnerText = objBs.changeToWords(lbltotalamount.InnerText,true);
                      
                    }
                }
            }
        }


    }
}
