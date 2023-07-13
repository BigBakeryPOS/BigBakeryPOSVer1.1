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
    public partial class DailyProductionReceiveStoreItem : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";

        string strPreviousRowID = string.Empty;

        int intSubTotalIndex = 1;



        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {


                DataSet dDcNo = objbs.getDailyProductionreceivesno((sCode));
                txtReceiveNo.Text = dDcNo.Tables[0].Rows[0]["ReceiveNO"].ToString();
                txtReceiveDAte.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet ds = objbs.GetRequestDailyProd_Item(sCode);
                if (ds.Tables.Count > 0)
                {
                    ddlrequestno.DataSource = ds.Tables[0];
                    ddlrequestno.DataTextField = "RequestNo";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
                else
                {
                    ddlrequestno.Items.Insert(0, "No RequestNo Available");
                }



            }
        }
        protected void ddlrequestno_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvRawRequest.DataSource = null;
            gvRawRequest.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();

            if (ddlrequestno.SelectedValue != "Select RequestNo" && ddlrequestno.SelectedValue != "0" && ddlrequestno.SelectedValue != "")
            {
                DataSet ds1 = objbs.GetRequestDailyProd_ItemByRequestNo(ddlrequestno.SelectedValue, sCode);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtDCNo.Text = ds1.Tables[0].Rows[0]["RequestNo"].ToString();
                    txtDCDate.Text = ds1.Tables[0].Rows[0]["RequestDate"].ToString();
                    txtAccepted.Text = ds1.Tables[0].Rows[0]["Prepared"].ToString();

                }


                #region Summary

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("itemid");
                dtraw.Columns.Add("Definition");
                dtraw.Columns.Add("Qty");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("Batchno");
                dtraw.Columns.Add("expirydate");
                dsraw.Tables.Add(dtraw);


                DataSet dsrawmerge = objbs.ShowDailyProdReceiveDetailsItem("tbldailyproduction_" + sCode, "tbltransdailyproduction_" + sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
                if (dsrawmerge.Tables[0].Rows.Count > 0)
                {
                    #region

                    DataTable dtraws = dsrawmerge.Tables[0];

                    var result1 = from r in dtraws.AsEnumerable()
                                  group r by new { IngredientName = r["Definition"], UOM = r["UOM"], Semiitemid = r["itemid"], batchno = r["batchno"], expirydate =r["expirydate"] } into raw
                                  select new
                                  {
                                      IngredientName = raw.Key.IngredientName,
                                      Semiitemid = raw.Key.Semiitemid,
                                      total = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                      UOM = raw.Key.UOM,
                                      batchno = raw.Key.batchno,
                                      expirydate = raw.Key.expirydate,
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();

                        drraw["itemid"] = g.Semiitemid;
                        drraw["Definition"] = g.IngredientName;
                        drraw["Qty"] = Convert.ToDouble(g.total).ToString("f2");
                        drraw["UOM"] = g.UOM;

                        drraw["Batchno"] = g.batchno;

                        drraw["expirydate"] = Convert.ToDateTime(g.expirydate).ToString("dd/MM/yyyy");

                        dsraw.Tables[0].Rows.Add(drraw);
                    }
                    GridView2.DataSource = dsraw.Tables[0];
                    GridView2.DataBind();

                    #endregion
                }


                #endregion

                //else
                //{
                //    gvRawRequest.DataSource = null;
                //    gvRawRequest.DataBind();
                //}

            }
        }





        protected void btnPrev_Click(object sender, EventArgs e)
        {

            if (ddlrequestno.SelectedValue == "Select RequestNo" || ddlrequestno.SelectedValue == "0" || ddlrequestno.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please  Select Request No.Thank You!!!');", true);
                return;
            }

            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");
                Label lblIngredientName = (Label)GridView2.Rows[vLoop].FindControl("lblIngredientName");


                TextBox txtacceptqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtacceptqty");
                TextBox txtmissingqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtmissingqty");
                TextBox txtdamageqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtdamageqty");

                if (txtacceptqty.Text == "")
                    txtacceptqty.Text = "0";

                if (txtmissingqty.Text == "")
                    txtmissingqty.Text = "0";

                if (txtdamageqty.Text == "")
                    txtdamageqty.Text = "0";


                double totqty = Convert.ToDouble(txtacceptqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtmissingqty.Text);




                if (Convert.ToDouble(lblWantedRaw.Text) != totqty)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Receive Qty Equal To Final Qty." + lblIngredientName.Text + ".Thank You!!!.');", true);
                    return;
                }



            }


            DataSet dDcNo = objbs.getDailyProductionreceivesno((sCode));
            txtReceiveNo.Text = dDcNo.Tables[0].Rows[0]["ReceiveNO"].ToString();

            string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            DateTime Date = Convert.ToDateTime(sDate);

            int ReceiveID = objbs.InsertDailyProductionReceiveItem(sCode, txtReceiveNo.Text, Convert.ToDateTime(txtReceiveDAte.Text), txtReceivePreparedby.Text, lblUserID.Text, Convert.ToInt32(ddlrequestno.SelectedValue));



            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");

                TextBox txtacceptqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtacceptqty");
                TextBox txtmissingqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtmissingqty");
                TextBox txtdamageqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtdamageqty");

                Label lblBatchno = (Label)GridView2.Rows[vLoop].FindControl("lblBatchno");

                Label lblexpirydate = (Label)GridView2.Rows[vLoop].FindControl("lblexpirydate");



                if (txtacceptqty.Text == "")
                    txtacceptqty.Text = "0";

                if (txtmissingqty.Text == "")
                    txtmissingqty.Text = "0";

                if (txtdamageqty.Text == "")
                    txtdamageqty.Text = "0";


                int insertrawitems = objbs.InsertTransDailyProductionReceiveItem(sCode, ReceiveID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(lblWantedRaw.Text), ddlrequestno.SelectedValue, txtdamageqty.Text, txtmissingqty.Text, txtacceptqty.Text, lblUserID.Text, lblBatchno.Text,lblexpirydate.Text);
            }

            int updateRawRequest = objbs.updateDailyProductionStockReceive(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
            Response.Redirect("DailyProdReceiveStoreItemGrid.aspx");
        }


    }
}
