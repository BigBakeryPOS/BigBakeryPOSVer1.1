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
    public partial class InterStoreStockTransfer : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";

        string BranchCode = "";
        string REQCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnvalue.Click += new System.EventHandler(this.btnvalue_Click);
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {
                string id = Request.QueryString.Get("ReqNo");
                string code = Request.QueryString.Get("bcode");
                string Breqno = Request.QueryString.Get("breqno");
                REQCode = Request.QueryString.Get("REQCode");

                DataSet dDcNo = objbs.getdcnoforinterStorerequest(code, sTableName);
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["DC_No"].ToString();
                txtDCDate.Text = DateTime.Now.ToString();

                DataSet ds = objbs.interStoreReqGridDetails(Convert.ToInt32(id), code, sTableName, Breqno);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DataSet dstd = new DataSet();
                    DataTable dtddd = new DataTable();

                    DataTable dttt;
                    DataRow drNew;
                    DataColumn dct;
                    dttt = new DataTable();

                    dct = new DataColumn("categoryid");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("CategoryUserID");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Category");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Definition");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("StockQty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Order_Qty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("UOM");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Rate");
                    dttt.Columns.Add(dct);
                    dstd.Tables.Add(dttt);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        string Qty = "0";
                        string categoryid = ds.Tables[0].Rows[i]["IngCatID"].ToString();
                        string categoryuserid = ds.Tables[0].Rows[i]["IngridID"].ToString();
                        string category = ds.Tables[0].Rows[i]["IngreCategory"].ToString();
                        string Definition = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                        string Order_Qty = ds.Tables[0].Rows[i]["Order_Qty"].ToString();
                        string UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                        string Rate = ds.Tables[0].Rows[i]["Rate"].ToString();

                        DataSet dstockcheck = objbs.getinterStorereqstock(Convert.ToInt32(categoryuserid), sTableName);
                        if (dstockcheck.Tables[0].Rows.Count > 0)
                        {
                            Qty = dstockcheck.Tables[0].Rows[0]["Available_QTY"].ToString();
                        }

                        drNew = dttt.NewRow();
                        drNew["categoryid"] = categoryid;
                        drNew["CategoryUserID"] = categoryuserid;
                        drNew["Category"] = category;
                        drNew["Definition"] = Definition;
                        drNew["StockQty"] = Qty;
                        drNew["Order_Qty"] = Order_Qty;
                        drNew["UOM"] = UOM;
                        drNew["Rate"] = Rate;


                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];


                    }



                    gvPurchase.DataSource = dtddd;
                    gvPurchase.DataBind();
                }
                else
                {
                    gvPurchase.DataSource = null;
                    gvPurchase.DataBind();
                }


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

            lnkDelete_ModalPopupExtender.Show();

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

            string id = Request.QueryString.Get("ReqNo");
            string TOCode = Request.QueryString.Get("bcode");
            string Breqno = Request.QueryString.Get("breqno");
            REQCode = Request.QueryString.Get("REQCode");

            if (GridView1.Rows.Count == null || GridView1.Rows.Count == 0)
            {
                radbtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Items And Keep in queue.Thank You!!!.');", true);
                return;

            }

            for (int i = 0; i < gvPurchase.Rows.Count; i++)
            {
                #region
                Label lblStockQty = (Label)gvPurchase.Rows[i].FindControl("lblStockQty");
                Label lblOrder_Qty = (Label)gvPurchase.Rows[i].FindControl("lblOrder_Qty");
                Label lblProduct = (Label)gvPurchase.Rows[i].FindControl("lblProduct");
                TextBox txttransferQty = (TextBox)gvPurchase.Rows[i].FindControl("txttransferQty");
                HiddenField HDProductid = (HiddenField)gvPurchase.Rows[i].FindControl("HDProductid");


                if (lblStockQty.Text == "")
                    lblStockQty.Text = "0";
                if (txttransferQty.Text == "")
                    txttransferQty.Text = "0";

                DataSet dss = objbs.interrequestdetailsforitem_store(Breqno, TOCode, sTableName, id, HDProductid.Value, REQCode);
                if (dss.Tables[0].Rows.Count > 0)
                {

                    double Order_Qty = 0;
                    double rec_Qty = 0;

                    double tot_Qty = 0;

                    Order_Qty = Convert.ToDouble(dss.Tables[0].Rows[0]["Order_Qty"]);
                    rec_Qty = Convert.ToDouble(dss.Tables[0].Rows[0]["Received_Qty"]);

                    tot_Qty = Order_Qty - rec_Qty;

                    lblOrder_Qty.Text = tot_Qty.ToString("0.00");

                    DataSet dstockcheck = objbs.getinterStorereqstock(Convert.ToInt32(HDProductid.Value), sTableName);
                    if (dstockcheck.Tables[0].Rows.Count > 0)
                    {
                        lblStockQty.Text = dstockcheck.Tables[0].Rows[0]["Available_QTY"].ToString();
                    }
                    else
                    {
                        lblStockQty.Text = "0";
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Store Qty is Less For that Item " + lblProduct.Text + "');", true);
                        //return;
                    }
                    if (Convert.ToDouble(lblStockQty.Text) < Convert.ToDouble(txttransferQty.Text))
                    {
                        radbtn.Checked = false;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Store Qty " + lblProduct.Text + " is Less than the Your Branch Stock.');", true);
                        return;
                    }
                    else
                    {
                        if (Convert.ToDouble(lblOrder_Qty.Text) < Convert.ToDouble(txttransferQty.Text))
                        {
                            radbtn.Checked = false;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Store Requested " + lblProduct.Text + "  Qty is Less than In Your Branch Stock.');", true);
                            return;
                        }
                    }
                }
                #endregion
            }



            System.Threading.Thread.Sleep(2000);

            int iSave = 0;


            DateTime DcDate = DateTime.Now;
            string sDcDate = DcDate.ToString("yyyy-MM-dd h:mm tt");

            DataSet dDcNo = objbs.getdcnoforinterStorerequest(TOCode, sTableName);
            txtDCNo.Text = dDcNo.Tables[0].Rows[0]["DC_No"].ToString();

            if (txtAccepted.Text != "")
            {

                iSave = objbs.InsertinterGoodsTrasnfer_Store(TOCode, txtDCNo.Text, sDcDate, id, "Goods Sent and waiting For Reply", 0, " ", 0, 0, txtAccepted.Text, sTableName, Breqno, REQCode);

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

                        iSave = objbs.InsertinterTransGoodTrasnfer_Store(txtDCNo.Text, Convert.ToInt32(iCatID), Convert.ToInt32(iSubCatID), Convert.ToDecimal(txtTransfer.Text), sUnits, dOrderQty, (sExpDate), (REQCode), 0, id, sTableName, Breqno);



                        DataSet dQtycheck = objbs.CheckSameQtyininterRequest_Store(sTableName, Convert.ToInt32(id), Convert.ToInt32(iSubCatID));
                        if (dQtycheck.Tables[0].Rows.Count > 0)
                        {
                            iSave = objbs.UpdateintertransferQty_Store(Convert.ToInt32(id), iSubCatID, Convert.ToDecimal(txtTransfer.Text), sTableName);
                        }

                        string fulldet = txtDCNo.Text + '-' + REQCode;

                        int iupdate1 = objbs.Updateintertransfer_Store(Convert.ToInt32(iSubCatID), Convert.ToDouble(txtTransfer.Text), sTableName, fulldet, iCatID.ToString(), lblUserID.Text, lblUser.Text, REQCode);


                    }
                }
                btnvalue.Enabled = true;
                //Response.Redirect("GoodsTransferGrid.aspx");
                Response.Redirect("RequestFromStoreGrid.aspx");


            }
        }





    }
}
