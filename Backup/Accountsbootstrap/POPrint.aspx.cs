using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;
using BusinessLayer;
using System.Linq;


namespace Billing
{
    public partial class POPrint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double Qty = 0; double Rate = 0; double Tax = 0; double Amount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string iPo = Request.QueryString.Get("OrderNo");
            string Type = Request.QueryString.Get("Type");

            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (iPo != null)
            {
                if (Type == "Order")
                {

                    lblpotype.Text = "Purchase Order";
                    #region

                    type.Visible = false;
                  
                    DataSet ds1 = objBs.GetPoprint(sTableName, Convert.ToInt32(iPo));

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lblcompanyname.Text = ds1.Tables[0].Rows[0]["LedgerName"].ToString();
                        lbltoaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        lblarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        lblcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                        lblpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();

                        lblpodate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["OrderDate"]).ToString("dd/MM/yyyy");
                        lblpono.Text = ds1.Tables[0].Rows[0]["OrderNo"].ToString();
                        lblpaymode.Text = ds1.Tables[0].Rows[0]["Paymode1"].ToString();

                        lblsubtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["SubTotal"]).ToString("f2");
                        lblcgst.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["CGST"]).ToString("f2");
                        lblsgst.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["SGST"]).ToString("f2");
                        lbligst.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["IGST"]).ToString("f2");
                        lbltotalamt.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Total"]).ToString("f2");

                        DataSet dsPODet = objBs.GettransPoprint(sTableName, Convert.ToInt32(ds1.Tables[0].Rows[0]["purchaseorderID"].ToString()));
                        if (dsPODet.Tables[0].Rows.Count > 0)
                        {
                            gridprint.Columns[6].Visible = false;

                            gridprint.DataSource = dsPODet;
                            gridprint.DataBind();
                        }
                    }
                    #endregion
                }
                else
                {
                    #region

                    lblpotype.Text = "Purchase";
                    type.Visible = true;

                    DataSet ds1 = objBs.GetPurchaseprint(sTableName, Convert.ToInt32(iPo));

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lblcompanyname.Text = ds1.Tables[0].Rows[0]["LedgerName"].ToString();
                        lbltoaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        lblarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        lblcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                        lblpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();

                        lblpodate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["BillDate"]).ToString("dd/MM/yyyy");
                        lblpono.Text = ds1.Tables[0].Rows[0]["BillNo"].ToString();
                        lblpaymode.Text = ds1.Tables[0].Rows[0]["Paymode1"].ToString();

                       
                        lblpurchasetype.Text = ds1.Tables[0].Rows[0]["BillingType"].ToString();

                        lblsubtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["SubTotal"]).ToString("f2");
                        lblcgst.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["CGST"]).ToString("f2");
                        lblsgst.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["SGST"]).ToString("f2");
                        lbligst.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["IGST"]).ToString("f2");
                        lbltotalamt.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Total"]).ToString("f2");

                        DataSet dsPODet = objBs.GettransPpurchaseprint(sTableName, Convert.ToInt32(iPo));
                        if (dsPODet.Tables[0].Rows.Count > 0)
                        {
                            gridprint.DataSource = dsPODet;
                            gridprint.DataBind();
                        }
                    }
                    #endregion
                }
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            string Type = Request.QueryString.Get("Type");
            if (Type == "Order")
            {
                Response.Redirect("Purchase_OrderGrid.aspx");
            }
            else
            {
                Response.Redirect("Purchase_invGrid.aspx");
            }


           
        }

        protected void gridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                 Qty +=Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                 Rate += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate"));
                 Tax += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
                 Amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total:-";
                e.Row.Cells[2].Text=Qty.ToString("f2");
                e.Row.Cells[3].Text = Rate.ToString("f2");
                e.Row.Cells[4].Text = Tax.ToString("f2");
                e.Row.Cells[5].Text = Amount.ToString("f2");

            }
        }
    }
}