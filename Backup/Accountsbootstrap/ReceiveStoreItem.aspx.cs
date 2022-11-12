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
    public partial class ReceiveStoreItem : System.Web.UI.Page
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


                DataSet dDcNo = objbs.getreceiveRawMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();
                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet drpdpown = objbs.getreceiveraw(sCode, "'AGN.REQ','DMND.REQ','DIR.REQ'");
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlrequestno.DataSource = drpdpown;
                    ddlrequestno.DataTextField = "RequestNo";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select AcceptedNo");
                }



            }
        }
        protected void ddlrequestno_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvRawRequest.DataSource = null;
            gvRawRequest.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();

            if (ddlrequestno.SelectedValue != "Select AcceptedNo" && ddlrequestno.SelectedValue != "0" && ddlrequestno.SelectedValue != "")
            {
             //   DataSet dDcsreqNo = objbs.getreceiveRawMaterialdetails(sCode, ddlrequestno.SelectedValue);
             //   if (dDcsreqNo.Tables[0].Rows.Count > 0)
                {
                  //  gvRawRequest.DataSource = dDcsreqNo;
                  //  gvRawRequest.DataBind();

                    #region Summary

                    DataTable dtraw = new DataTable();
                    DataSet dsraw = new DataSet();
                    DataRow drraw;

                    dtraw.Columns.Add("Semiitemid");
                    dtraw.Columns.Add("IngredientName");
                    dtraw.Columns.Add("WantedRaw");
                    dtraw.Columns.Add("UOM");
                    dsraw.Tables.Add(dtraw);




                    DataSet dsrawmerge = objbs.Getreceiverawitems(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
                    if (dsrawmerge.Tables[0].Rows.Count > 0)
                    {
                        #region

                        DataTable dtraws = dsrawmerge.Tables[0];

                        var result1 = from r in dtraws.AsEnumerable()
                                      group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                      select new
                                      {
                                          IngredientName = raw.Key.IngredientName,
                                          Semiitemid = raw.Key.Semiitemid,
                                          total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                          UOM = raw.Key.UOM,
                                      };


                        foreach (var g in result1)
                        {
                            drraw = dtraw.NewRow();

                            drraw["Semiitemid"] = g.Semiitemid;
                            drraw["IngredientName"] = g.IngredientName;
                            drraw["WantedRaw"] = Convert.ToDouble(g.total).ToString("f2");
                            drraw["UOM"] = g.UOM;

                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                        GridView2.DataSource = dsraw.Tables[0];
                        GridView2.DataBind();

                        #endregion
                    }


                    #endregion
                }
                //else
                //{
                //    gvRawRequest.DataSource = null;
                //    gvRawRequest.DataBind();
                //}

            }
        }


        protected void Excess_click(object sender, EventArgs e)
        {
            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                double totgnd = 0;

                Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
                TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");
                Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

                if (txtadjqty.Text == "")
                    txtadjqty.Text = "0";

                txtfinalqty.Text = (Convert.ToDouble(lblQty.Text) - Convert.ToDouble(txtadjqty.Text)).ToString();


            }


        }

        protected void btnexecuteraw_OnClick(object sender, EventArgs e)
        {
            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");
                Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
                TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");

                if (Convert.ToDouble(lblQty.Text) < Convert.ToDouble(txtadjqty.Text))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Adj.Qty for " + lblProduct.Text + ".Thank You!!!');", true);
                    return;
                }
            }



            #region Summary

            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;

            dtraw.Columns.Add("Semiitemid");
            dtraw.Columns.Add("IngredientName");
            dtraw.Columns.Add("WantedRaw");
            dtraw.Columns.Add("UOM");
            dsraw.Tables.Add(dtraw);

            DataSet dsrawmerge = new DataSet();

            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

                if (txtfinalqty.Text == "")
                    txtfinalqty.Text = "0";

                DataSet dsrawitems = objbs.Getwantrawnewbyjothi(Convert.ToInt32(productid.Value), Convert.ToDouble(txtfinalqty.Text), sCode);
                if (dsrawitems.Tables[0].Rows.Count > 0)
                {
                    dsrawmerge.Merge(dsrawitems);
                }

            }

            if (dsrawmerge.Tables[0].Rows.Count > 0)
            {
                DataTable dtraws = new DataTable();

                dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtraws.AsEnumerable()
                              group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                              select new
                              {
                                  Semiitemid = raw.Key.Semiitemid,
                                  IngredientName = raw.Key.IngredientName,
                                  total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                  UOM = raw.Key.UOM,
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["Semiitemid"] = g.Semiitemid;
                    drraw["IngredientName"] = g.IngredientName;
                    drraw["WantedRaw"] = Convert.ToDouble(g.total).ToString("f2");
                    drraw["UOM"] = g.UOM;

                    dsraw.Tables[0].Rows.Add(drraw);
                }
                GridView2.DataSource = dsraw.Tables[0];
                GridView2.DataBind();
            }


            #endregion

        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {

            if (ddlrequestno.SelectedValue == "Select AcceptedNo" || ddlrequestno.SelectedValue == "0" || ddlrequestno.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Accepted No.Thank You!!!');", true);
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




                if ( Convert.ToDouble(lblWantedRaw.Text) != totqty)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Receive Qty Equal To Final Qty." + lblIngredientName.Text + ".Thank You!!!.');", true);
                    return;
                }



            }

            //////for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            //////{
            //////    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
            //////    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");
            //////    Label lblIngredientName = (Label)GridView2.Rows[vLoop].FindControl("lblIngredientName");

                

            //////    DataSet ds = objbs.InserttransrawitemacceptCheckproduction(sCode, Semiitemid.Value);
            //////    if (ds.Tables[0].Rows.Count > 0)
            //////    {
            //////        if (Convert.ToDouble(lblWantedRaw.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
            //////        {
            //////            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + "(" + ds.Tables[0].Rows[0]["Qty"].ToString() + ")" + " was not in availabe Stock, plz Check.Thank You!!!');", true);
            //////            return;
            //////        }
            //////    }
            //////    else
            //////    {
            //////        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + " was not in availabe Stock, plz Check.Thank You!!!');", true);
            //////        return;
            //////    }
            //////}


            DataSet dDcNo = objbs.getreceiveRawMaterialsno((sCode));
            txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

            string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            DateTime Date = Convert.ToDateTime(sDate);

            int RequestID = objbs.Insertrawreceive(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(ddlrequestno.SelectedValue));

            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                #region

                HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");


                if (Convert.ToDouble(txtfinalqty.Text) > 0)
                {
                    int MainRequestID = objbs.Inserttransrawreceive(sCode, RequestID, Convert.ToInt32(HDProductid.Value), Convert.ToDouble(txtfinalqty.Text), Convert.ToDouble(0), Convert.ToInt32(ddlrequestno.SelectedValue));
                }
                #endregion
            }

            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");

                TextBox txtacceptqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtacceptqty");
                TextBox txtmissingqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtmissingqty");
                TextBox txtdamageqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtdamageqty");

                if (txtacceptqty.Text == "")
                    txtacceptqty.Text = "0";

                if (txtmissingqty.Text == "")
                    txtmissingqty.Text = "0";

                if (txtdamageqty.Text == "")
                    txtdamageqty.Text = "0";


                int insertrawitems = objbs.Inserttransrawitemreceive(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(lblWantedRaw.Text),ddlrequestno.SelectedValue,txtdamageqty.Text,txtmissingqty.Text);
            }

            int updateRawRequest = objbs.updateRawreceive(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
            Response.Redirect("ReceiveStoreItemGrid.aspx");
        }


    }
}
