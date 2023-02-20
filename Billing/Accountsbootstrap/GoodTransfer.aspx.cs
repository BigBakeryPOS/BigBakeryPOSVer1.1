using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class GoodTransfer : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
       
        string BranchCode = "";
        string dispatchdirect = "N";
        string qtysetting = "";
        string ProdStockOption = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnvalue.Click += new System.EventHandler(this.btnvalue_Click);
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();

            dispatchdirect = Request.Cookies["userInfo"]["dispatchdirect"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            ProdStockOption = Request.Cookies["userInfo"]["ProdStockOption"].ToString();


            if (!IsPostBack)
            {
                string id = Request.QueryString.Get("ReqNo");
                string code = Request.QueryString.Get("bcode");
                string Breqno = Request.QueryString.Get("breqno");

                DataSet dDcNo = objbs.getDcNoNew(code, sTableName);
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["DC_No"].ToString();
                txtDCDate.Text = DateTime.Now.ToString();

                DataSet ds = objbs.PurchaseReqGridDetails(Convert.ToInt32(id), code, sTableName,Breqno);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvPurchase.DataSource = ds;
                    gvPurchase.DataBind();
                }
                else
                {
                    gvPurchase.DataSource = null;
                    gvPurchase.DataBind();
                }


            }
        }

        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {




            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblStockQty = ((Label)e.Row.FindControl("lblStockQty"));
                lblStockQty.Text = Convert.ToDouble(lblStockQty.Text).ToString("" + qtysetting + "");

                Label lblOrder_Qty = ((Label)e.Row.FindControl("lblOrder_Qty"));
                lblOrder_Qty.Text = Convert.ToDouble(lblOrder_Qty.Text).ToString("" + qtysetting + "");

            }
        }



        protected void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable dtSnacks = new DataTable();
            dtSnacks.Columns.Add("Item");
            dtSnacks.Columns.Add("Qty");

            foreach (GridViewRow ROw in gvPurchase.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txttransferQty");
                Label lblProduct = (Label)ROw.FindControl("lblProduct");
                if (txtQty.Text != "" || txtQty.Text == "0")
                {
                    DataRow dr = dtSnacks.NewRow();
                    dr["Item"] = lblProduct.Text;
                    dr["Qty"] = txtQty.Text;
                    dtSnacks.Rows.Add(dr);

                }

            }


            GridView1.Caption = "To be Sent";
            GridView1.DataSource = dtSnacks;
            GridView1.DataBind();
            UpdatePanel2.Update();
            lnkDelete_ModalPopupExtender.Show();
            


        }
        protected void btnvalue_Click(object sender, EventArgs e)
        {


            DataTable dtSnacks = new DataTable();
            dtSnacks.Columns.Add("Item");
            dtSnacks.Columns.Add("Qty");


            foreach (GridViewRow ROw in gvPurchase.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txttransferQty");
                Label lblProduct = (Label)ROw.FindControl("lblProduct");

                if (txtQty.Text != "" && txtQty.Text != "0")
                {
                    DataRow dr = dtSnacks.NewRow();

                    dr["Item"] = lblProduct.Text;
                    dr["Qty"] = txtQty.Text;
                    dtSnacks.Rows.Add(dr);

                }

            }


            GridView1.Caption = "To be Sent";
            GridView1.DataSource = dtSnacks;
            GridView1.DataBind();
            UpdatePanel2.Update();
            lnkDelete_ModalPopupExtender.Show();
            

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

            string id = Request.QueryString.Get("ReqNo");
            string code = Request.QueryString.Get("bcode");
            string Breqno = Request.QueryString.Get("breqno");
            if (GridView1.Rows.Count == null || GridView1.Rows.Count == 0)
            {
                
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Items And Keep in queue.Thank You!!!.');", true);
                return;

            }

            for (int i = 0; i < gvPurchase.Rows.Count; i++)
            {
               
                #region
                Label lblStockQty = (Label)gvPurchase.Rows[i].FindControl("lblStockQty");
                Label lblOrder_Qty = (Label)gvPurchase.Rows[i].FindControl("lblOrder_Qty");
                TextBox txttransferQty = (TextBox)gvPurchase.Rows[i].FindControl("txttransferQty");
                HiddenField HDProductid = (HiddenField)gvPurchase.Rows[i].FindControl("HDProductid");

                if (lblStockQty.Text == "")
                    lblStockQty.Text = "0";
                if (txttransferQty.Text == "")
                    txttransferQty.Text = "0";

                // check qty 

                DataSet dss = objbs.chkqtytransfer(HDProductid.Value, Breqno, id, code, sTableName);
                if (dss.Tables[0].Rows.Count > 0)
                {

                    double Order_Qty =0;
                    double rec_Qty =0;

                    double tot_Qty =0;

                    Order_Qty = Convert.ToDouble(dss.Tables[0].Rows[0]["Order_Qty"]);
                    rec_Qty = Convert.ToDouble(dss.Tables[0].Rows[0]["Received_Qty"]);

                    tot_Qty = Order_Qty - rec_Qty;

                    lblOrder_Qty.Text = tot_Qty.ToString("0.00");
                    if (ProdStockOption == "1")
                    {


                        if (Convert.ToDouble(lblStockQty.Text) < Convert.ToDouble(txttransferQty.Text))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Production Qty is Less than the Prod to Stores.');", true);
                            return;
                        }
                        else
                        {
                            if (Convert.ToDouble(lblOrder_Qty.Text) < Convert.ToDouble(txttransferQty.Text))
                            {
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Store Requested  Qty is Less than the Prod to Stores.');", true);
                                return;
                            }
                        }
                    }
                    else if(ProdStockOption == "2")
                    {
                        if (Convert.ToDouble(lblOrder_Qty.Text) < Convert.ToDouble(txttransferQty.Text))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Store Requested  Qty is Less than the Prod to Stores.');", true);
                            return;
                        }
                    }
                }
                #endregion
            }



            System.Threading.Thread.Sleep(2000);
            //string id = Request.QueryString.Get("ReqNo");
            //string code = Request.QueryString.Get("bcode");
            //string Breqno = Request.QueryString.Get("breqno");
            int iSave = 0;

            // get dispatch code
            DataSet getbcode = objbs.getbranchcode(code);
            if (getbcode.Tables[0].Rows.Count > 0)
            {
                dispatchdirect = getbcode.Tables[0].Rows[0]["dipatchDirectly"].ToString();
            }



            DateTime DcDate = DateTime.Now;
            string sDcDate = DcDate.ToString("yyyy-MM-dd h:mm tt");

            DataSet dDcNo = objbs.getDcNoNew(code, sTableName);
            txtDCNo.Text = dDcNo.Tables[0].Rows[0]["DC_No"].ToString();
            string vehicleno = "0";


            if (dispatchdirect == "N")
            {

            }
            else
            {
                vehicleno = "Nil / Direct Transfer";
            }

            if (txtAccepted.Text != "")
            {

                iSave = objbs.InsertGoodTrasnfer(code, txtDCNo.Text, sDcDate, id, "Goods Sent and waiting For Reply", 0, "Production", 0, (code), 0, txtAccepted.Text, sTableName, Breqno, dispatchdirect,vehicleno);
                if (iSave > 0)
                {


                    for (int i = 0; i < gvPurchase.Rows.Count; i++)
                    {
                        HiddenField HDCategoryid = (HiddenField)gvPurchase.Rows[i].FindControl("HDCategoryid");
                        HiddenField HDProductid = (HiddenField)gvPurchase.Rows[i].FindControl("HDProductid");
                        int iCatID = Convert.ToInt32(HDCategoryid.Value);
                        int iSubCatID = Convert.ToInt32(HDProductid.Value);


                        Label lblOrder_Qty = (Label)gvPurchase.Rows[i].FindControl("lblOrder_Qty");
                        decimal dOrderQty = Convert.ToDecimal(lblOrder_Qty.Text);

                        string sExpDate = DateTime.Now.ToShortDateString();

                        string sUnits = "0";
                        TextBox txtTransfer = (TextBox)gvPurchase.Rows[i].FindControl("txttransferQty");


                        if (Convert.ToDouble(txtTransfer.Text) > 0)
                        {

                            iSave = objbs.InsertTransGoodTrasnfer(txtDCNo.Text, Convert.ToInt32(iCatID), Convert.ToInt32(iSubCatID), Convert.ToDecimal(txtTransfer.Text), sUnits, dOrderQty, (sExpDate), (code), 0, id, sTableName, Breqno);



                            DataSet dQtycheck = objbs.CheckSameQtyinRequest(sTableName, Convert.ToInt32(id), Convert.ToInt32(iSubCatID));
                            if (dQtycheck.Tables[0].Rows.Count > 0)
                            {
                                iSave = objbs.UpdatetransferQty(Convert.ToInt32(id), iSubCatID, Convert.ToDouble(txtTransfer.Text), sTableName);
                            }


                            int iupdate1 = objbs.Updatetransfer_PS1(Convert.ToInt32(iSubCatID), Convert.ToDouble(txtTransfer.Text), sTableName);


                        }
                    }
                    btnvalue.Enabled = true;
                    //Response.Redirect("GoodsTransferGrid.aspx");
                    Response.Redirect("OrderFromBranch.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Goods Not Transfer Plz check With Admin Team.');", true);
                    return;

                }

            }
        }





    }
}
