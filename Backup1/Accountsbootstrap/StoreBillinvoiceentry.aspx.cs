using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class StoreBillinvoiceentry : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        DateTime frmdate = new DateTime();

        string strPreviousRowID = string.Empty;

        int intSubTotalIndex = 1;

        System.Globalization.CultureInfo Cul = new System.Globalization.CultureInfo("en-GB", true);

        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {
                DataSet dDcNo = objbs.getmaxinvoiceno_Store((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["invno"].ToString();
                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtgrndate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet dsbranch = objbs.getbranchFilling("0");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    ddlbranch.DataSource = dsbranch.Tables[0];
                    ddlbranch.DataTextField = "BranchArea";
                    ddlbranch.DataValueField = "BranchId";
                    ddlbranch.DataBind();
                    ddlbranch.Items.Insert(0, "Select Branch");

                }
            }
        }

        protected void grn_date(object s, EventArgs e)
        {
            chkpono.ClearSelection();
            gridsummary.DataSource = null;
            gridsummary.DataBind();

            if (txtgrndate.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid date.Thank You!!!');", true);
                return;
            }

            if (ddlbranch.SelectedValue != "" && ddlbranch.SelectedValue != "0" && ddlbranch.SelectedValue != "Select Branch")
            {
                frmdate = DateTime.Parse(txtgrndate.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                DataSet dspo = objbs.GetbranchForGRN_Store(ddlbranch.SelectedValue, frmdate, sTableName);
                if (dspo.Tables[0].Rows.Count > 0)
                {
                    chkpono.DataSource = dspo.Tables[0];
                    chkpono.DataTextField = "DC_NO";
                    chkpono.DataValueField = "P_ID";
                    chkpono.DataBind();
                }
                else
                {
                    chkpono.Items.Clear();
                }
            }
        }

        protected void ddlbranch_OnSelectedIndexChanged(object s, EventArgs e)
        {
            chkpono.ClearSelection();
            gridsummary.DataSource = null;
            gridsummary.DataBind();

            if (txtgrndate.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid date.Thank You!!!');", true);
                return;
            }

            if (ddlbranch.SelectedValue != "" && ddlbranch.SelectedValue != "0" && ddlbranch.SelectedValue != "Select Branch")
            {
                frmdate = DateTime.Parse(txtgrndate.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                DataSet dspo = objbs.GetbranchForGRN_Store(ddlbranch.SelectedValue, frmdate, sTableName);
                if (dspo.Tables[0].Rows.Count > 0)
                {
                    chkpono.DataSource = dspo.Tables[0];
                    chkpono.DataTextField = "DC_NO";
                    chkpono.DataValueField = "P_ID";
                    chkpono.DataBind();
                }
                else
                {
                    chkpono.Items.Clear();
                }
            }
        }


        protected void Process_Click(object sender, EventArgs e)
        {


            //string cond = "";

            //foreach (ListItem listItem in chkpono.Items)
            //{
            //    if (listItem.Text != "All")
            //    {
            //        if (listItem.Selected)
            //        {
            //            cond += " a.P_ID='" + listItem.Value + "' ,";
            //        }
            //    }
            //}
            //cond = cond.TrimEnd(',');
            //cond = cond.Replace(",", "or");

            //DataSet dsmerge = new DataSet();

            //DataSet ds = objbs.igetbillentry((cond), sTableName);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    dsmerge.Merge(ds);
            //}


            //if (dsmerge.Tables.Count > 0)
            //{
            //    if (dsmerge.Tables[0].Rows.Count > 0)
            //    {
            //        ViewState["CurrentTable"] = dsmerge.Tables[0];
            //        gridbinditem.DataSource = dsmerge;
            //        gridbinditem.DataBind();
            //    }
            //    else
            //    {
            //        ViewState["CurrentTable"] = null;
            //        gridbinditem.DataSource = null;
            //        gridbinditem.DataBind();
            //    }
            //}
            //else
            //{
            //    ViewState["CurrentTable"] = null;
            //    gridbinditem.DataSource = null;
            //    gridbinditem.DataBind();
            //}



            DataSet dssummary = new DataSet();

            //foreach (ListItem item in chkpono.Items)
            //{
            //    if (item.Selected)
            //    {

            string cond1 = "";

            foreach (ListItem listItem in chkpono.Items)
            {
                if (listItem.Text != "All")
                {
                    if (listItem.Selected)
                    {
                        cond1 += " a.P_ID='" + listItem.Value + "' ,";
                    }
                }
            }
            cond1 = cond1.TrimEnd(',');
            cond1 = cond1.Replace(",", "or");

            //    }
            //}
            DataSet dss = objbs.igetbillentrysummary_Store((cond1), sTableName);
            if (dss.Tables[0].Rows.Count > 0)
            {
                dssummary.Merge(dss);
            }
            if (dssummary.Tables.Count > 0)
            {
                if (dssummary.Tables[0].Rows.Count > 0)
                {
                    ViewState["CurrentTablesummary"] = dssummary.Tables[0];
                    gridsummary.DataSource = dssummary;
                    gridsummary.DataBind();
                }
                else
                {
                    ViewState["CurrentTablesummary"] = null;
                    gridsummary.DataSource = null;
                    gridsummary.DataBind();
                }
            }
            else
            {
                ViewState["CurrentTablesummary"] = null;
                gridsummary.DataSource = null;
                gridsummary.DataBind();
            }
            GridCalculate(sender, e);
        }

        public void Rate_Click(object s, EventArgs e)
        {
            GridCalculate(s, e);
        }

        public void GridCalculate(object s, EventArgs e)
        {
            #region

            double TtlTax = 0; double TtlAmount = 0;

            for (int vLoop = 0; vLoop < gridsummary.Rows.Count; vLoop++)
            {
                Label lblqty = (Label)gridsummary.Rows[vLoop].FindControl("lblqty");
                TextBox txtrate = (TextBox)gridsummary.Rows[vLoop].FindControl("txtrate");
                TextBox txtGST = (TextBox)gridsummary.Rows[vLoop].FindControl("txtGST");

                TextBox txttotal = (TextBox)gridsummary.Rows[vLoop].FindControl("txttotal");
                TextBox txttax = (TextBox)gridsummary.Rows[vLoop].FindControl("txttax");

                //Label lbltotalamount = (Label)GVoedc.Rows[vLoop].FindControl("lbltotalamount");
                //RadioButtonList rbRemain = (RadioButtonList)GVoedc.Rows[vLoop].FindControl("rbRemain");

                //  if (rbRemain.SelectedValue == "Carry Forward")
                {
                    if (lblqty.Text == "")
                        lblqty.Text = "0";

                    double Amt = Convert.ToDouble(lblqty.Text) * Convert.ToDouble(txtrate.Text);
                    double Tax = Amt * Convert.ToDouble(txtGST.Text) / 100;

                    txtrate.Text = Convert.ToDouble(txtrate.Text).ToString("f2");

                    txttax.Text = Tax.ToString("f2");

                    txttotal.Text = (Amt + Tax).ToString("f2");

                    TtlTax += Tax;
                    TtlAmount += Amt + Tax;
                }
            }

            #region

            //if (drpProvince.SelectedValue == "" || drpProvince.SelectedValue == "0" || drpProvince.SelectedValue == "1" || drpProvince.SelectedValue == "Select Province")
            {
                txtcgst.Text = Convert.ToDouble(TtlTax / 2).ToString("f2");
                txtsgst.Text = Convert.ToDouble(TtlTax / 2).ToString("f2");
                txtigst.Text = Convert.ToDouble(0).ToString("f2");
            }
            //else
            //{
            //    txtcgst.Text = Convert.ToDouble(0).ToString("f2");
            //    txtsgst.Text = Convert.ToDouble(0).ToString("f2");
            //    txtigst.Text = Convert.ToDouble(TtlTax).ToString("f2");
            //}
            #endregion

            #endregion

            txtgrandtotal.Text = TtlAmount.ToString("f2");

            double r = 0;
            double roundoff = Convert.ToDouble(txtgrandtotal.Text) - Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            if (roundoff >= 0.5)
            {
                r = Math.Round(Convert.ToDouble(txtgrandtotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            }
            txtroundoff.Text = string.Format("{0:f2}", r);

        }


        protected void Excess_click(object sender, EventArgs e)
        {
            //for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            //{
            //    double totgnd = 0;

            //    Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
            //    TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");
            //    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

            //    if (txtadjqty.Text == "")
            //        txtadjqty.Text = "0";

            //    txtfinalqty.Text = (Convert.ToDouble(lblQty.Text) - Convert.ToDouble(txtadjqty.Text)).ToString();


            //}


        }

        protected void btnexecuteraw_OnClick(object sender, EventArgs e)
        {
            //for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            //{
            //    Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");
            //    Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
            //    TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");

            //    if (Convert.ToDouble(lblQty.Text) < Convert.ToDouble(txtadjqty.Text))
            //    {
            //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Adj.Qty for " + lblProduct.Text + ".Thank You!!!');", true);
            //        return;
            //    }
            //}



            //#region Summary

            //DataTable dtraw = new DataTable();
            //DataSet dsraw = new DataSet();
            //DataRow drraw;

            //dtraw.Columns.Add("Semiitemid");
            //dtraw.Columns.Add("IngredientName");
            //dtraw.Columns.Add("WantedRaw");
            //dtraw.Columns.Add("UOM");
            //dsraw.Tables.Add(dtraw);

            //DataSet dsrawmerge = new DataSet();

            //for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            //{
            //    HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
            //    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

            //    if (txtfinalqty.Text == "")
            //        txtfinalqty.Text = "0";

            //    DataSet dsrawitems = objbs.Getwantrawnewbyjothi(Convert.ToInt32(productid.Value), Convert.ToDouble(txtfinalqty.Text), sCode);
            //    if (dsrawitems.Tables[0].Rows.Count > 0)
            //    {
            //        dsrawmerge.Merge(dsrawitems);
            //    }

            //}

            //if (dsrawmerge.Tables[0].Rows.Count > 0)
            //{
            //    DataTable dtraws = new DataTable();

            //    dtraws = dsrawmerge.Tables[0];

            //    var result1 = from r in dtraws.AsEnumerable()
            //                  group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
            //                  select new
            //                  {
            //                      Semiitemid = raw.Key.Semiitemid,
            //                      IngredientName = raw.Key.IngredientName,
            //                      total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
            //                      UOM = raw.Key.UOM,
            //                  };


            //    foreach (var g in result1)
            //    {
            //        drraw = dtraw.NewRow();

            //        drraw["Semiitemid"] = g.Semiitemid;
            //        drraw["IngredientName"] = g.IngredientName;
            //        drraw["WantedRaw"] = Convert.ToDouble(g.total).ToString("f2");
            //        drraw["UOM"] = g.UOM;

            //        dsraw.Tables[0].Rows.Add(drraw);
            //    }
            //    GridView2.DataSource = dsraw.Tables[0];
            //    GridView2.DataBind();
            //}


            // #endregion

        }
        protected void Save_click(object sender, EventArgs e)
        {

            if (ddlbranch.SelectedValue == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Branch.Thank You!!!');", true);
                return;
            }

            if (chkpono.SelectedIndex >= 0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Valid DC.No.Thank You!!!');", true);
                return;
            }

            DateTime invdate = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime grndate = DateTime.ParseExact(txtgrndate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int RequestID = objbs.InsertInvoice_Store(sTableName, ddlbranch.SelectedValue, invdate, txtfullbillno.Text, grndate, txtAccepted.Text, txtcgst.Text, txtsgst.Text, txtigst.Text, txtgrandtotal.Text, txtroundoff.Text, txtNarration.Text, txtvehicleno.Text);

            for (int vLoop = 0; vLoop < gridsummary.Rows.Count; vLoop++)
            {

                Label lblCategoryUserID = (Label)gridsummary.Rows[vLoop].FindControl("lblCategoryUserID");

                Label lblhsncode = (Label)gridsummary.Rows[vLoop].FindControl("lblhsncode");

                Label lbluom = (Label)gridsummary.Rows[vLoop].FindControl("lbluom");

                Label lblqty = (Label)gridsummary.Rows[vLoop].FindControl("lblqty");

                TextBox txtrate = (TextBox)gridsummary.Rows[vLoop].FindControl("txtrate");

                TextBox txtTaxVal = (TextBox)gridsummary.Rows[vLoop].FindControl("txtTaxVal");

                TextBox txttax = (TextBox)gridsummary.Rows[vLoop].FindControl("txttax");

                TextBox txttotal = (TextBox)gridsummary.Rows[vLoop].FindControl("txttotal");


                int insertrawitems = objbs.Inserttransinvoice_Store(RequestID.ToString(), lblCategoryUserID.Text, lblhsncode.Text, lbluom.Text, lblqty.Text, txtrate.Text, txtTaxVal.Text, txttax.Text, txttotal.Text, sTableName);
            }

            foreach (ListItem item in chkpono.Items)
            {
                if (item.Selected)
                {
                    int itransgrnentry = objbs.Inserttransinvoicegrn_Store(RequestID.ToString(), sTableName, item.Value, grndate);

                }
            }



            //for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            //{
            //    #region

            //    HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
            //    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");


            //    if (Convert.ToDouble(txtfinalqty.Text) > 0)
            //    {
            //        int MainRequestID = objbs.Inserttransrawreceive(sCode, RequestID, Convert.ToInt32(HDProductid.Value), Convert.ToDouble(txtfinalqty.Text), Convert.ToDouble(0), Convert.ToInt32(ddlrequestno.SelectedValue));
            //    }
            //    #endregion
            //}



            //int updateRawRequest = objbs.updateRawreceive(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
            Response.Redirect("StoreBillInvoiceGrid.aspx");
        }


    }
}
