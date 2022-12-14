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

namespace Billing.Accountsbootstrap
{
    public partial class InterStoreGoodReceivedNote : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sBranch = "";
        string scode = "";
        string reqNo = "";
        string dcNo = "";
        string UserVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            UserVal = Request.Cookies["userInfo"]["UserVal"].ToString();

            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Make Any Stock Received.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion


            if (!IsPostBack)
            {

                string PReqNo = Request.QueryString.Get("PReqNo");
                string BReqNo = Request.QueryString.Get("BReqNo");
                string DcNo = Request.QueryString.Get("DcNo");
                string ToCode = Request.QueryString.Get("ToCode");

                DataSet ds = objbs.InterGoodReceived_Store(DcNo, scode, ToCode);
                if (ds.Tables.Count > 0)
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

        protected void check_Qty(object sender, EventArgs e)
        {
            for (int i = 0; i < gvPurchase.Rows.Count; i++)
            {

                Label lblitemname = (Label)gvPurchase.Rows[i].FindControl("lblitemname");

                Label txtSentQty = (Label)gvPurchase.Rows[i].FindControl("txtSentQty");

                TextBox txtrecqty = (TextBox)gvPurchase.Rows[i].FindControl("txtWeight");
                TextBox txtdmgqty = (TextBox)gvPurchase.Rows[i].FindControl("txtdmgqty");
                TextBox txtmissqty = (TextBox)gvPurchase.Rows[i].FindControl("txtmissqty");

                if (txtrecqty.Text == "")
                    txtrecqty.Text = "0";

                if (txtdmgqty.Text == "")
                    txtdmgqty.Text = "0";

                if (txtmissqty.Text == "")
                    txtmissqty.Text = "0";


                double totqty = Convert.ToDouble(txtrecqty.Text) + Convert.ToDouble(txtdmgqty.Text) + Convert.ToDouble(txtmissqty.Text);

                TextBox txtfinalqty = (TextBox)gvPurchase.Rows[i].FindControl("txtfinalqty");


                txtfinalqty.Text = totqty.ToString();


                if (txtSentQty.Text != txtfinalqty.Text)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Receive Qty Equal To Final Qty." + lblitemname.Text + ".Thank You!!!.');", true);
                    return;
                }

            }
        }


        protected void btnvalue_Click(object sender, EventArgs e)
        {

            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Make Any Stock Received.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion


            for (int i = 0; i < gvPurchase.Rows.Count; i++)
            {

                Label lblitemname = (Label)gvPurchase.Rows[i].FindControl("lblitemname");

                Label txtSentQty = (Label)gvPurchase.Rows[i].FindControl("txtSentQty");

                TextBox txtrecqty = (TextBox)gvPurchase.Rows[i].FindControl("txtWeight");
                TextBox txtdmgqty = (TextBox)gvPurchase.Rows[i].FindControl("txtdmgqty");
                TextBox txtmissqty = (TextBox)gvPurchase.Rows[i].FindControl("txtmissqty");

                if (txtrecqty.Text == "")
                    txtrecqty.Text = "0";

                if (txtdmgqty.Text == "")
                    txtdmgqty.Text = "0";

                if (txtmissqty.Text == "")
                    txtmissqty.Text = "0";

                double totqty = Convert.ToDouble(txtrecqty.Text) + Convert.ToDouble(txtdmgqty.Text) + Convert.ToDouble(txtmissqty.Text);

                TextBox txtfinalqty = (TextBox)gvPurchase.Rows[i].FindControl("txtfinalqty");


                txtfinalqty.Text = totqty.ToString();


                if (txtSentQty.Text != txtfinalqty.Text)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Receive Qty Equal To Final Qty." + lblitemname.Text + ".Thank You!!!.');", true);
                    return;
                }

            }



            btnvalue.Enabled = false;
            string PReqNo = Request.QueryString.Get("PReqNo");
            string BReqNo = Request.QueryString.Get("BReqNo");
            string DcNo = Request.QueryString.Get("DCNo");
            string ToCode = Request.QueryString.Get("ToCode");

            int RecID = objbs.InterInserRecQty_Store(sTableName, PReqNo, lblUserID.Text, BReqNo, DcNo, txtRemarks.Text);

            for (int i = 0; i < gvPurchase.Rows.Count; i++)
            {
                #region

                HiddenField catID = (HiddenField)gvPurchase.Rows[i].FindControl("Hiddenfield");
                int iCatID = Convert.ToInt32(catID.Value);
                HiddenField subcatID = (HiddenField)gvPurchase.Rows[i].FindControl("Hiddenfield1");
                int iSubCatID = Convert.ToInt32(subcatID.Value);


                Label txtOrderQty = (Label)gvPurchase.Rows[i].FindControl("txtOrderQty");
                double dOrderQty = Convert.ToDouble(txtOrderQty.Text);

                Label txtSentQty = (Label)gvPurchase.Rows[i].FindControl("txtSentQty");
                double ReceivedQty = Convert.ToDouble(txtSentQty.Text);


                DateTime ExpDate = DateTime.Now;


                TextBox txtWeight = (TextBox)gvPurchase.Rows[i].FindControl("txtWeight");

                TextBox txtdmgqty = (TextBox)gvPurchase.Rows[i].FindControl("txtdmgqty");

                TextBox txtmissqty = (TextBox)gvPurchase.Rows[i].FindControl("txtmissqty");

                DataSet dQty = objbs.GetPurchaseStok_Store(iSubCatID, Convert.ToInt32(UserVal), sTableName);
                if (dQty.Tables[0].Rows.Count > 0)
                {
                    #region Update Stock

                    string sExpiry = DateTime.Now.ToShortDateString();

                    int itemID = Convert.ToInt32(dQty.Tables[0].Rows[0]["IngredientID"].ToString());
                    int stockid = Convert.ToInt32(dQty.Tables[0].Rows[0]["StockID"].ToString());

                    objbs.InterUpdatePurchaseStokNew_Store(Convert.ToDouble(txtWeight.Text), iSubCatID, Convert.ToInt32(UserVal), sExpiry, sTableName, stockid, RecID.ToString());
                    objbs.InterUpdatereqPurchaseStock_Store(Convert.ToDouble(txtWeight.Text), sTableName, BReqNo, itemID);

                    #endregion

                }
                else
                {
                    int iRtn = objbs.InterInserDirectGrn_Store(sTableName, Convert.ToInt32(UserVal), iCatID, iSubCatID, ReceivedQty, Convert.ToDouble(txtWeight.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), (ExpDate), 0, DcNo);

                    DataSet dsQty = objbs.GetPurchaseStok_Store(iSubCatID, Convert.ToInt32(UserVal), sTableName);
                    if (dsQty.Tables[0].Rows.Count > 0)
                    {
                        #region Insert Stock

                        string sExpiry = DateTime.Now.ToShortDateString();

                        int itemID = Convert.ToInt32(dsQty.Tables[0].Rows[0]["IngredientID"].ToString());
                        int stockid = Convert.ToInt32(dsQty.Tables[0].Rows[0]["stockid"].ToString());


                        objbs.InterUpdatereqPurchaseStock_Store(Convert.ToDouble(txtWeight.Text), sTableName, BReqNo, itemID);

                        #endregion
                    }


                }

                objbs.InterInsertransRecQty_Store(sTableName, RecID, iCatID, iSubCatID, dOrderQty, Convert.ToDouble(txtWeight.Text), DcNo, Convert.ToDouble(txtdmgqty.Text), Convert.ToDouble(txtmissqty.Text), lblUserID.Text, BReqNo, ToCode, lblUser.Text);

                objbs.InterupdateRecQty_store(ToCode, DcNo, iSubCatID, Convert.ToDouble(txtdmgqty.Text), Convert.ToDouble(txtmissqty.Text), txtRemarks.Text);

                #endregion
            }
            Response.Redirect("InterStoreGoodsReceivedGrid.aspx");
        }
    }
}