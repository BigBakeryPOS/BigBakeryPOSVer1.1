using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
namespace Billing.Accountsbootstrap
{
    public partial class SalesVatReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        string sTableName = "";
        string AllBranchAccess = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();
            if (!IsPostBack)
            {

              //  txtfromdate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Now.ToString("MM/dd/yyyy");

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objbs.GetBranch_New("All");
                else
                    dsbranch = objbs.GetBranch_New(sTableName);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "Select Branch");
                else
                    ddlBranch.Enabled = false;

                //DataSet ds1 = objbs.salestaxreport(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);
               // DataSet ds2 = objbs.SalesVatReport2(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);
               // DataSet ds3 = objbs.SalesVatReport3(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);


                //DataSet dsdisc = objbs.Salesdiscamt(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);
                //decimal disc = 0;
                //decimal disc1 = 0;

                //for (int i = 0; i < dsdisc.Tables[0].Rows.Count; i++)
                //{
                //    disc = disc + Convert.ToDecimal(dsdisc.Tables[0].Rows[i]["discount"].ToString());
                //}

                //lbldiscsmt.Text = disc.ToString("f2");

                ////////lbltotalamtzero.Text = ds1.Tables[0].Rows[0]["Amount"].ToString();
                ////////lblvatamtzero.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();

                ////////lbltotalamtfive.Text = ds2.Tables[0].Rows[0]["Amount"].ToString();
                ////////lblvatamtfive.Text = ds2.Tables[0].Rows[0]["Vat"].ToString();

                ////////lbltotalamteighteen.Text = ds3.Tables[0].Rows[0]["Amount"].ToString();
                ////////lblvatamteighteen.Text = ds3.Tables[0].Rows[0]["Vat"].ToString();

                //lbltotalamtzero.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Amount"]).ToString("f2");
                //lblvatamtzero.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Vat"]).ToString("f2");

                //lbltotalamtfive.Text = Convert.ToDecimal(ds2.Tables[0].Rows[0]["Amount"]).ToString("f2");
                //lblvatamtfive.Text = Convert.ToDecimal(ds2.Tables[0].Rows[0]["Vat"]).ToString("f2");

                //lbltotalamteighteen.Text = Convert.ToDecimal(ds3.Tables[0].Rows[0]["Amount"]).ToString("f2");
                //lblvatamteighteen.Text = Convert.ToDecimal(ds3.Tables[0].Rows[0]["Vat"]).ToString("f2");

                //lblfinaltotal.Text = ((Convert.ToDecimal(lbltotalamtzero.Text) + Convert.ToDecimal(lblvatamtzero.Text) + Convert.ToDecimal(lbltotalamtfive.Text) + Convert.ToDecimal(lblvatamtfive.Text) + Convert.ToDecimal(lbltotalamteighteen.Text) + Convert.ToDecimal(lblvatamteighteen.Text)) - Convert.ToDecimal(lbldiscsmt.Text)).ToString();
                ////Roundoff
                //double finaltot = 0;
                //double roundoff1 = Convert.ToDouble(lblfinaltotal.Text) - Math.Floor(Convert.ToDouble(lblfinaltotal.Text));
                //if (roundoff1 >= 0.5)
                //{
                //    finaltot = Math.Round(Convert.ToDouble(lblfinaltotal.Text), MidpointRounding.AwayFromZero);
                //}
                //else
                //{
                //    finaltot = Math.Floor(Convert.ToDouble(lblfinaltotal.Text));
                //}

                //lblfinaltotal.Text = string.Format("{0:N2}", finaltot);

                //////double na0 = 0;
                //////double nva0 = 0;

                //////double na5 = 0;
                //////double nva5 = 0;

                //////double na18 = 0;
                //////double nva18 = 0;
                ////////Roundoff
                //////double roundoff1 = Convert.ToDouble(lbltotalamtzero.Text) - Math.Floor(Convert.ToDouble(lbltotalamtzero.Text));
                //////if (roundoff1 >= 0.5)
                //////{
                //////    na0 = Math.Round(Convert.ToDouble(lbltotalamtzero.Text), MidpointRounding.AwayFromZero);
                //////}
                //////else
                //////{
                //////    na0 = Math.Floor(Convert.ToDouble(lbltotalamtzero.Text));
                //////}

                //////lbltotalamtzero.Text = string.Format("{0:N2}", na0);

                //////double roundoff2 = Convert.ToDouble(lblvatamtzero.Text) - Math.Floor(Convert.ToDouble(lblvatamtzero.Text));
                //////if (roundoff2 >= 0.5)
                //////{
                //////    nva0 = Math.Round(Convert.ToDouble(lblvatamtzero.Text), MidpointRounding.AwayFromZero);
                //////}
                //////else
                //////{
                //////    nva0 = Math.Floor(Convert.ToDouble(lblvatamtzero.Text));
                //////}

                //////lblvatamtzero.Text = string.Format("{0:N2}", nva0);


                //////double roundoff3 = Convert.ToDouble(lbltotalamtfive.Text) - Math.Floor(Convert.ToDouble(lbltotalamtfive.Text));
                //////if (roundoff3 >= 0.5)
                //////{
                //////    na5 = Math.Round(Convert.ToDouble(lbltotalamtfive.Text), MidpointRounding.AwayFromZero);
                //////}
                //////else
                //////{
                //////    na5 = Math.Floor(Convert.ToDouble(lbltotalamtfive.Text));
                //////}

                //////lbltotalamtfive.Text = string.Format("{0:N2}", na5);


                //////double roundoff4 = Convert.ToDouble(lblvatamtfive.Text) - Math.Floor(Convert.ToDouble(lblvatamtfive.Text));
                //////if (roundoff4 >= 0.5)
                //////{
                //////    nva5 = Math.Round(Convert.ToDouble(lblvatamtfive.Text), MidpointRounding.AwayFromZero);
                //////}
                //////else
                //////{
                //////    nva5 = Math.Floor(Convert.ToDouble(lblvatamtfive.Text));
                //////}

                //////lblvatamtfive.Text = string.Format("{0:N2}", nva5);


                //////double roundoff5 = Convert.ToDouble(lbltotalamteighteen.Text) - Math.Floor(Convert.ToDouble(lbltotalamteighteen.Text));
                //////if (roundoff5 >= 0.5)
                //////{
                //////    na18 = Math.Round(Convert.ToDouble(lbltotalamteighteen.Text), MidpointRounding.AwayFromZero);
                //////}
                //////else
                //////{
                //////    na18 = Math.Floor(Convert.ToDouble(lbltotalamteighteen.Text));
                //////}

                //////lbltotalamteighteen.Text = string.Format("{0:N2}", na18);


                //////double roundoff6 = Convert.ToDouble(lblvatamteighteen.Text) - Math.Floor(Convert.ToDouble(lblvatamteighteen.Text));
                //////if (roundoff6 >= 0.5)
                //////{
                //////    nva18 = Math.Round(Convert.ToDouble(lblvatamteighteen.Text), MidpointRounding.AwayFromZero);
                //////}
                //////else
                //////{
                //////    nva18 = Math.Floor(Convert.ToDouble(lblvatamteighteen.Text));
                //////}

                //////lblvatamteighteen.Text = string.Format("{0:N2}", nva18);
            }


        }
        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrintSalesVat.aspx?iSalesDate=" + txttodate.Text.ToString());
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {


            DataSet ds1 = objbs.salestaxreport(Convert.ToInt32(lblUserID.Text), ddlBranch.SelectedValue, txttodate.Text);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds1;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = null;
                gridview.DataBind();
            }

            //DataSet ds1 = objbs.SalesVatReport1(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);
            //DataSet ds2 = objbs.SalesVatReport2(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);
            //DataSet ds3 = objbs.SalesVatReport3(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);

            //DataSet dsdisc = objbs.Salesdiscamt(Convert.ToInt32(lblUserID.Text), sTableName, txttodate.Text);
            //decimal disc = 0;

            //for (int i = 0; i < dsdisc.Tables[0].Rows.Count; i++)
            //{
            //    disc = disc + Convert.ToDecimal(dsdisc.Tables[0].Rows[i]["discount"].ToString());
            //}

            //lbldiscsmt.Text = disc.ToString("f2");

            //lbltotalamtzero.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Amount"]).ToString("f2");
            //lblvatamtzero.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Vat"]).ToString("f2");

            //lbltotalamtfive.Text = Convert.ToDecimal(ds2.Tables[0].Rows[0]["Amount"]).ToString("f2");
            //lblvatamtfive.Text = Convert.ToDecimal(ds2.Tables[0].Rows[0]["Vat"]).ToString("f2");

            //lbltotalamteighteen.Text =Convert.ToDecimal( ds3.Tables[0].Rows[0]["Amount"]).ToString("f2");
            //lblvatamteighteen.Text = Convert.ToDecimal(ds3.Tables[0].Rows[0]["Vat"]).ToString("f2");

            //lblfinaltotal.Text = ((Convert.ToDecimal(lbltotalamtzero.Text) + Convert.ToDecimal(lblvatamtzero.Text) + Convert.ToDecimal(lbltotalamtfive.Text) + Convert.ToDecimal(lblvatamtfive.Text) + Convert.ToDecimal(lbltotalamteighteen.Text) + Convert.ToDecimal(lblvatamteighteen.Text)) - Convert.ToDecimal(lbldiscsmt.Text)).ToString();
            ////Roundoff
            //double finaltot = 0;
            //double roundoff1 = Convert.ToDouble(lblfinaltotal.Text) - Math.Floor(Convert.ToDouble(lblfinaltotal.Text));
            //if (roundoff1 >= 0.5)
            //{
            //    finaltot = Math.Round(Convert.ToDouble(lblfinaltotal.Text), MidpointRounding.AwayFromZero);
            //}
            //else
            //{
            //    finaltot = Math.Floor(Convert.ToDouble(lblfinaltotal.Text));
            //}

            //lblfinaltotal.Text = string.Format("{0:N2}", finaltot);

            //////double na0 = 0;
            //////double nva0 = 0;

            //////double na5 = 0;
            //////double nva5 = 0;

            //////double na18 = 0;
            //////double nva18 = 0;
            ////////Roundoff
            //////double roundoff1 = Convert.ToDouble(lbltotalamtzero.Text) - Math.Floor(Convert.ToDouble(lbltotalamtzero.Text));
            //////if (roundoff1 >= 0.5)
            //////{
            //////    na0 = Math.Round(Convert.ToDouble(lbltotalamtzero.Text), MidpointRounding.AwayFromZero);
            //////}
            //////else
            //////{
            //////    na0 = Math.Floor(Convert.ToDouble(lbltotalamtzero.Text));
            //////}

            //////lbltotalamtzero.Text = string.Format("{0:N2}", na0);

            //////double roundoff2 = Convert.ToDouble(lblvatamtzero.Text) - Math.Floor(Convert.ToDouble(lblvatamtzero.Text));
            //////if (roundoff2 >= 0.5)
            //////{
            //////    nva0 = Math.Round(Convert.ToDouble(lblvatamtzero.Text), MidpointRounding.AwayFromZero);
            //////}
            //////else
            //////{
            //////    nva0 = Math.Floor(Convert.ToDouble(lblvatamtzero.Text));
            //////}

            //////lblvatamtzero.Text = string.Format("{0:N2}", nva0);


            //////double roundoff3 = Convert.ToDouble(lbltotalamtfive.Text) - Math.Floor(Convert.ToDouble(lbltotalamtfive.Text));
            //////if (roundoff3 >= 0.5)
            //////{
            //////    na5 = Math.Round(Convert.ToDouble(lbltotalamtfive.Text), MidpointRounding.AwayFromZero);
            //////}
            //////else
            //////{
            //////    na5 = Math.Floor(Convert.ToDouble(lbltotalamtfive.Text));
            //////}

            //////lbltotalamtfive.Text = string.Format("{0:N2}", na5);


            //////double roundoff4 = Convert.ToDouble(lblvatamtfive.Text) - Math.Floor(Convert.ToDouble(lblvatamtfive.Text));
            //////if (roundoff4 >= 0.5)
            //////{
            //////    nva5 = Math.Round(Convert.ToDouble(lblvatamtfive.Text), MidpointRounding.AwayFromZero);
            //////}
            //////else
            //////{
            //////    nva5 = Math.Floor(Convert.ToDouble(lblvatamtfive.Text));
            //////}

            //////lblvatamtfive.Text = string.Format("{0:N2}", nva5);


            //////double roundoff5 = Convert.ToDouble(lbltotalamteighteen.Text) - Math.Floor(Convert.ToDouble(lbltotalamteighteen.Text));
            //////if (roundoff5 >= 0.5)
            //////{
            //////    na18 = Math.Round(Convert.ToDouble(lbltotalamteighteen.Text), MidpointRounding.AwayFromZero);
            //////}
            //////else
            //////{
            //////    na18 = Math.Floor(Convert.ToDouble(lbltotalamteighteen.Text));
            //////}

            //////lbltotalamteighteen.Text = string.Format("{0:N2}", na18);


            //////double roundoff6 = Convert.ToDouble(lblvatamteighteen.Text) - Math.Floor(Convert.ToDouble(lblvatamteighteen.Text));
            //////if (roundoff6 >= 0.5)
            //////{
            //////    nva18 = Math.Round(Convert.ToDouble(lblvatamteighteen.Text), MidpointRounding.AwayFromZero);
            //////}
            //////else
            //////{
            //////    nva18 = Math.Floor(Convert.ToDouble(lblvatamteighteen.Text));
            //////}

            //////lblvatamteighteen.Text = string.Format("{0:N2}", nva18);
            //gvPurchaseEntry.DataSource = ds;
            //gvPurchaseEntry.DataBind();
        }

        //protected void gvPurchaseEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    DataSet ds = objbs.PurchaseReqGridBranchreports(Convert.ToInt32(lblUserID.Text), sCode, txtfromdate.Text, txttodate.Text);
        //    gvPurchaseEntry.PageIndex = e.NewPageIndex;
        //    gvPurchaseEntry.DataSource = ds;
        //    gvPurchaseEntry.DataBind();
        //}
        ////protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        ////{
        ////    if (e.Row.RowType == DataControlRowType.DataRow)
        ////    {
        ////        GridView gv = e.Row.FindControl("gvdetails") as GridView;
        ////        GridView gvGroup = (GridView)sender;
        ////        if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
        ////        {
        ////            int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
        ////            DataSet ds = objbs.Report_StockReqDetails(groupID, sCode);

        ////            if (ds.Tables[0].Rows.Count > 0)
        ////            {
        ////                gv.DataSource = ds;
        ////                gv.DataBind();
        ////            }

        ////        }

        ////    }
        ////}


    }
}