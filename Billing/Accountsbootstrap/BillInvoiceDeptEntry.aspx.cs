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
    public partial class BillInvoiceDeptEntry : System.Web.UI.Page
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
                DataSet dDcNo = objbs.getmaxinvoiceno_Dept((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["invno"].ToString();
                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
               // txtgrndate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet dsbranch = objbs.getDepartment_New(sTableName,"N");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpdepartment.DataSource = dsbranch.Tables[0];
                    drpdepartment.DataTextField = "Deptname";
                    drpdepartment.DataValueField = "DeptID";
                    drpdepartment.DataBind();
                    drpdepartment.Items.Insert(0, "Select Department");

                }
            }
        }

        protected void dept_chnaged(object sender, EventArgs e)
        {
            chkpono.ClearSelection();
            gridsummary.DataSource = null;
            gridsummary.DataBind();

            if (drpdepartment.SelectedValue == "Select Department")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Selected Department is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {
                if (drpdepartment.SelectedValue != "" && drpdepartment.SelectedValue != "0" && drpdepartment.SelectedValue != "Select Department")
                {
                  //  frmdate = DateTime.Parse(txtgrndate.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    DataSet dspo = objbs.PurchaseReqGridDetailsStore_Dept(sTableName,drpdepartment.SelectedValue);
                    if (dspo.Tables[0].Rows.Count > 0)
                    {
                        chkpono.DataSource = dspo.Tables[0];
                        chkpono.DataTextField = "requestno";
                        chkpono.DataValueField = "P_ID";
                        chkpono.DataBind();
                    }
                    else
                    {
                        chkpono.Items.Clear();
                    }
                }
            }
        }

        

       


        protected void Process_Click(object sender, EventArgs e)
        {


           



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
            DataSet dss = objbs.igetbillentrysummary_Dept((cond1), sTableName);
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
            


        }

        protected void btnexecuteraw_OnClick(object sender, EventArgs e)
        {
            

        }
       

        protected void Save_click(object sender, EventArgs e)
        {

            //if (ddlbranch.SelectedValue == "Select Branch")
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Branch.Thank You!!!');", true);
            //    return;
            //}

            if (txtcustomerdetails.Text == "")
            {
                txtcustomerdetails.Text = drpdepartment.SelectedItem.Text;
            }

            if (chkpono.SelectedIndex >= 0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Valid DC.No.Thank You!!!');", true);
                return;
            }

            for (int vLoop = 0; vLoop < gridsummary.Rows.Count; vLoop++)
            {

                Label lblCategoryUserID = (Label)gridsummary.Rows[vLoop].FindControl("lblCategoryUserID");

                Label lblDefinition = (Label)gridsummary.Rows[vLoop].FindControl("lblDefinition");

                


                Label lblqty = (Label)gridsummary.Rows[vLoop].FindControl("lblqty");

                Label lblAvlQty = (Label)gridsummary.Rows[vLoop].FindControl("lblAvlQty");

                TextBox txtsendqty = (TextBox)gridsummary.Rows[vLoop].FindControl("txtsendqty");

                if (txtsendqty.Text == "")
                    txtsendqty.Text = "0";

                DataSet ds = objbs.InserttransrawitemacceptCheck(sCode, lblCategoryUserID.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //if (Convert.ToDouble(lblWantedRaw.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                    if (Convert.ToDouble(txtsendqty.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblDefinition.Text + "(" + ds.Tables[0].Rows[0]["Qty"].ToString() + ")" + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                        return;
                    }
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblDefinition.Text + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                //    return;
                //}
            }

            DateTime invdate = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime grndate = DateTime.ParseExact(txtgrndate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int RequestID = objbs.InsertInvoice_Dept(sTableName, "0", invdate, txtfullbillno.Text, invdate, txtAccepted.Text, txtcgst.Text, txtsgst.Text, txtigst.Text, txtgrandtotal.Text, txtroundoff.Text, txtNarration.Text, "",drpdepartment.SelectedValue,txtcustomerdetails.Text,txtaddress.Text);

            for (int vLoop = 0; vLoop < gridsummary.Rows.Count; vLoop++)
            {


                Label lblrequestid = (Label)gridsummary.Rows[vLoop].FindControl("lbldcno");
                Label lblCategoryUserID = (Label)gridsummary.Rows[vLoop].FindControl("lblCategoryUserID");

                Label lblhsncode = (Label)gridsummary.Rows[vLoop].FindControl("lblhsncode");

                Label lbluom = (Label)gridsummary.Rows[vLoop].FindControl("lbluom");

                Label lblqty = (Label)gridsummary.Rows[vLoop].FindControl("lblqty");

                TextBox txtsendqty = (TextBox)gridsummary.Rows[vLoop].FindControl("txtsendqty");

                TextBox txtrate = (TextBox)gridsummary.Rows[vLoop].FindControl("txtrate");

                TextBox txtTaxVal = (TextBox)gridsummary.Rows[vLoop].FindControl("txtTaxVal");

                TextBox txttax = (TextBox)gridsummary.Rows[vLoop].FindControl("txttax");

                TextBox txttotal = (TextBox)gridsummary.Rows[vLoop].FindControl("txttotal");


                if (txtsendqty.Text != "0")
                {

                    int insertrawitems = objbs.Inserttransinvoice_Dept(RequestID.ToString(), lblCategoryUserID.Text, lblhsncode.Text, lbluom.Text, txtsendqty.Text, txtrate.Text, txtTaxVal.Text, txttax.Text, txttotal.Text, sTableName, lblrequestid.Text);
                    int iupdate1 = objbs.Updatetransfer_PS1Store(Convert.ToInt32(lblCategoryUserID.Text), Convert.ToDouble(txtsendqty.Text), sTableName);
                }
            }

            //foreach (ListItem item in chkpono.Items)
            //{
            //    if (item.Selected)
            //    {
            //        int itransgrnentry = objbs.Inserttransinvoicegrn(RequestID.ToString(), sTableName, item.Value, grndate);

            //    }
            //}

            Response.Redirect("BillInvoiceDeptGrid.aspx");
        }


    }
}
