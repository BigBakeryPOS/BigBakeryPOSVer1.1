using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Billing.Accountsbootstrap
{
    public partial class OnlineBillEntry : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        string cust = "";
        string sTableName = "";
        string Rate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            //DataSet ds = objbs.iplist();
            //gvip.DataSource = ds.Tables[0];
            //gvip.DataBind();
            if (!IsPostBack)
            {

                txtorderdate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                txtdeliverydate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");

                DataSet dsbranch = objbs.getbranchFilling_New("0", "Y");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpbranch.DataSource = dsbranch.Tables[0];
                    drpbranch.DataTextField = "BranchArea";
                    drpbranch.DataValueField = "BranchCode";
                    drpbranch.DataBind();
                    drpbranch.Items.Insert(0, "Select Branch");
                }

                DataSet getsalestype = objbs.GetSalesTypeForSales_normal("N");
                if (getsalestype.Tables[0].Rows.Count > 0)
                {
                    drpsalestype.DataSource = getsalestype.Tables[0];
                    drpsalestype.DataTextField = "PaymentType";
                    drpsalestype.DataValueField = "SalesTypeID";
                    drpsalestype.DataBind();
                }

                drpsalestype_selectedindex(sender, e);

                DataSet getallitembind = objbs.GetNewSelectDistinctItems_online("N", Convert.ToInt32(lblUserID.Text));
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.DataSource = getallitembind.Tables[0];
                    drpitemsearch.DataTextField = "Definition";
                    drpitemsearch.DataValueField = "valuee";
                    drpitemsearch.DataBind();
                    drpitemsearch.Items.Insert(0, "Select Item");

                }

                if (dt.Columns.Count > 0)
                {
                    gvlist.DataSource = dt;
                    gvlist.DataBind();
                }
                else
                {
                    DataColumn col = new DataColumn("Sno", typeof(int));
                    dt.Columns.Add(col);
                    //dt.Columns.Add("Sno");
                    dt.Columns.Add("CategoryID");
                    dt.Columns.Add("CategoryUserID");
                    dt.Columns.Add("Stockid");
                    dt.Columns.Add("Definition");
                    dt.Columns.Add("Available_QTY");
                    dt.Columns.Add("TAX");
                    dt.Columns.Add("margin");
                    dt.Columns.Add("paygate");
                    dt.Columns.Add("margintax");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("Rate");
                    dt.Columns.Add("OriRate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("Disamt");
                    dt.Columns.Add("cattype");
                    dt.Columns.Add("combo");
                    dt.Columns.Add("ShwQty");
                    dt.Columns.Add("CQty");
                    dt.Columns.Add("HQty");
                    ViewState["dt"] = dt;
                    gvlist.DataSource = dt;
                    gvlist.DataBind();

                }

                DataSet ds = objbs.getonlinenumberdetails();
                gvip.DataSource = ds.Tables[0];
                gvip.DataBind();
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }

        protected void gst_changed(object sender, EventArgs e)
        {
            txtdiscou_TextChanged(sender, e);
            txtgstper.Focus();
        }

        protected void Qty_chnaged(object sender, EventArgs e)
        {

            if (drpitemsearch.SelectedValue == "Select Item")
            {
                drpitemsearch.Focus();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Item.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {
                if (txtmanualqty.Text == "0" || txtmanualqty.Text == "")
                {
                    txtmanualqty.Focus();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Qty.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                else
                {
                    UpdatePanel3.Update();
                    decimal Shwqty = 0;
                    int comboo = 0;
                    decimal Qty = 0;
                    decimal HQty = 0;
                    decimal GST = 0;
                    decimal iQty = 0;
                    decimal SQty = 0;
                    string sItem = "";
                    decimal dCalTotal = 0;
                    decimal dRate = 0, dAmount = 0, dAvlQty = 0;
                    int iSubCatID = 0;
                    int CatID = 0;
                    int stockID = 0;
                    string sTempSession = "";

                    string margin = "0";
                    string margingst = "0";
                    string paymsntgateway = "0";

                    // tblBill.Visible = true;
                    dt = (DataTable)ViewState["dt"];
                    //dtt = (DataTable)ViewState["dtt"];
                    DataSet dCat = new DataSet();
                    //  Button btn = (Button)sender;

                    string[] commandArgs = drpitemsearch.SelectedValue.Split(new char[] { ',' });
                    string categoryuserid = commandArgs[0];
                    string cattype = commandArgs[1];


                    // dCat = objbs.GetStockDetails(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName);
                    if (cattype == "N")
                    {
                        dCat = objbs.GetStockDetails_online(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName);
                    }
                    else if (cattype == "C")
                    {
                        //  dCat = objbs.GetStockDetailscombo(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName);
                    }

                    if (dCat.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                        {

                            sItem = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                            comboo = Convert.ToInt32(dCat.Tables[0].Rows[i]["comboo"]);
                            dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate"].ToString());
                            CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                            iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString());
                            stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryUserid"].ToString());
                            dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                            GST = Convert.ToDecimal(dCat.Tables[0].Rows[i]["GST"].ToString());
                            Shwqty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["QTY"].ToString());
                            DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[0]["Expirydate"].ToString());
                            string lblisinclusiverate = "N";
                            if (lblisinclusiverate == "Y")
                            {
                                DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "' AND combo='" + comboo + "'");
                                if (rows.Length > 0)
                                {



                                    decimal Dtax = (dRate * GST) / 100;

                                    decimal drateee = dRate + Dtax;

                                    decimal commamnt = (drateee * Convert.ToDecimal(0)) / 100;

                                    decimal commperamnt = (commamnt * Convert.ToDecimal(0)) / 100;

                                    decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                    {
                                        Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                                        HQty = Convert.ToInt32(rows[0]["HQty"].ToString());
                                        Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                    }
                                    // if ((dAvlQty + HQty) >= Qty)
                                    {
                                        rows[0]["Qty"] = Qty.ToString("0");

                                        rows[0]["Rate"] = Convert.ToDecimal(dRate).ToString("f2"); 
                                        decimal amt = Convert.ToDecimal(Qty) * DRATE;
                                        rows[0]["Amount"] = amt.ToString("f2");
                                    }
                                    // rows[0]["RecQty"] = recQty.ToString();
                                }
                                else
                                {
                                    Qty = 0; int totcnt = 0;
                                    int countt = dt.Rows.Count;
                                    totcnt = countt + 1;
                                    DataRow dr = dt.NewRow();
                                    //Qty = Qty + 1;
                                    Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                    decimal amt = 0;

                                    decimal Dtax = (dRate * GST) / 100;

                                    decimal drateee = dRate + Dtax;

                                    decimal commamnt = (drateee * Convert.ToDecimal(0)) / 100;

                                    decimal commperamnt = (commamnt * Convert.ToDecimal(0)) / 100;

                                    decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                    dr["Sno"] = totcnt;
                                    dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                    dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                    dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                    dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                    dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("f0");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                    dr["Qty"] = Qty.ToString("0");
                                    dr["Rate"] = Convert.ToDecimal(DRATE).ToString("0.00");
                                    dr["Tax"] = Convert.ToDecimal(0);

                                    {
                                        amt = Convert.ToDecimal(Qty) * DRATE;
                                    }
                                    dr["Amount"] = amt.ToString("f2");
                                    dr["Orirate"] = dRate.ToString();
                                    //  if (dAvlQty >= Qty)
                                    {

                                        dt.Rows.Add(dr);
                                    }

                                    ViewState["dt"] = dt;
                                    txtmanualslno.Text = (totcnt + 1).ToString();
                                }
                            }
                            else
                            {




                                decimal Sqtyy = 0;

                                {

                                    DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'  AND combo='" + comboo + "'");
                                    if (rows.Length > 0)
                                    {

                                        {
                                            Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                            HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                            Sqtyy = Convert.ToDecimal(rows[0]["ShwQty"].ToString());
                                            if (cattype == "N")
                                            {
                                                //  Qty = Qty + 1;
                                                Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                Sqtyy = Sqtyy + Shwqty;
                                            }
                                            else if (cattype == "C")
                                            {
                                                //Qty = Qty + 1;
                                                Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                Sqtyy = Sqtyy + Shwqty;
                                            }
                                        }
                                        // if ((dAvlQty + HQty) >= Qty)
                                        {
                                            rows[0]["Qty"] = Qty.ToString("0");
                                            rows[0]["ShwQty"] = Sqtyy.ToString("0");
                                            rows[0]["Rate"] = Convert.ToDecimal(dRate).ToString("f2"); 
                                            decimal amt = Convert.ToDecimal(Qty) * dRate;
                                            rows[0]["Amount"] = amt.ToString("f2");
                                        }
                                        //else
                                        //{
                                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Item Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                        //    txtmanualqty.Focus();
                                        //    return;
                                        //}


                                    }
                                    else
                                    {
                                        Qty = 0; int totcnt = 0;
                                        int countt = dt.Rows.Count;
                                        totcnt = countt + 1;
                                        DataRow dr = dt.NewRow();
                                        Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        decimal amt = 0;

                                        dr["Sno"] = totcnt;
                                        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                        dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                        dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                        dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("f0");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                        dr["Qty"] = Qty.ToString("0");
                                        dr["ShwQty"] = Shwqty.ToString("0");
                                        dr["Rate"] = Convert.ToDecimal(dRate).ToString("f2");
                                        dr["Tax"] = Convert.ToDecimal(GST);
                                        dr["cattype"] = cattype;
                                        dr["combo"] = comboo;
                                        dr["Cqty"] = Shwqty.ToString("0");
                                        if (dr["Hqty"].ToString() == "0" || dr["Hqty"].ToString() == "")
                                        {
                                            dr["Hqty"] = "0";
                                        }
                                        else
                                        {

                                        }
                                        {
                                            amt = Convert.ToDecimal(Qty) * dRate;
                                        }
                                        dr["Amount"] = amt.ToString("f2");
                                        dr["Orirate"] = dRate.ToString();
                                        //   if (dAvlQty >= Qty)
                                        {

                                            dt.Rows.Add(dr);
                                        }
                                        //else
                                        //{
                                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Item Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                        //    txtmanualqty.Focus();
                                        //    return;
                                        //}

                                        ViewState["dt"] = dt;
                                        txtmanualslno.Text = (totcnt + 1).ToString();
                                    }
                                }

                                DataView dvEmp = dt.DefaultView;
                                dvEmp.Sort = "Sno Desc";
                                gvlist.DataSource = dvEmp;
                                gvlist.DataBind();
                                // getdisablecolumn();
                            }
                            txtdiscou_TextChanged(sender, e);
                        }
                    }


                    drpitemsearch.Focus();
                    txtmanualqty.Text = "";
                    txtrate.Text = "";


                }

            }
            txtmanualslno.Focus();

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
            txtmanualqty.Text = "";
            txtrate.Text = "";
            DataSet getallitembind = objbs.GetNewSelectDistinctItems_online("N", Convert.ToInt32(lblUserID.Text));
            if (getallitembind.Tables[0].Rows.Count > 0)
            {
                drpitemsearch.DataSource = getallitembind.Tables[0];
                drpitemsearch.DataTextField = "Definition";
                drpitemsearch.DataValueField = "valuee";
                drpitemsearch.DataBind();
                drpitemsearch.Items.Insert(0, "Select Item");

            }

        }

        protected void txtqty_chnaged(object sender, EventArgs e)
        {
            decimal Qty = 0;
            decimal GST = 0;
            decimal iQty = 0;
            string sItem = "";
            decimal dCalTotal = 0;
            decimal dRate = 0, dAmount = 0, dAvlQty = 0;
            int iSubCatID = 0;
            int CatID = 0;
            int stockID = 0;
            string sTempSession = "";

            string margin = "0";
            string margingst = "0";
            string paymsntgateway = "0";

            // tblBill.Visible = true;

            TextBox ddl = (TextBox)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label ddlcategory1 = (Label)row.FindControl("CategoryUserid");
            Label StockID = (Label)row.FindControl("StockID");
            TextBox defini = (TextBox)row.FindControl("Definition");
            Label lblcattype = (Label)row.FindControl("lblcattype");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("Rate");

            if (txtQty.Text == "")
                txtQty.Text = "0";


            dt = (DataTable)ViewState["dt"];
            DataSet dCat = new DataSet();
            //dCat = objbs.GetStockDetails(Convert.ToInt32(StockID.Text), Convert.ToInt32(lblUserID.Text), sTableName);
            dCat = objbs.GetStockDetails_online(Convert.ToInt32(ddlcategory1.Text), Convert.ToInt32(lblUserID.Text), sTableName);

            if (dCat.Tables[0].Rows.Count > 0)
            {
                sItem = dCat.Tables[0].Rows[0]["Definition"].ToString();

                dRate = Convert.ToDecimal(Rate.Text);
                CatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryID"].ToString());
                iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["StockID"].ToString());
                stockID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryUserid"].ToString());
                dAvlQty = Convert.ToDecimal(0);


                {

                    DataRow[] rows = dt.Select("Definition='" + defini.Text + "' AND CategoryUserid='" + ddlcategory1.Text + "' and cattype='" + lblcattype.Text + "'");
                    if (rows.Length > 0)
                    {

                        {
                            Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                            if (lblcattype.Text == "N")
                            {
                                Qty = Convert.ToDecimal(txtQty.Text);

                            }
                        }
                        //  if (dAvlQty >= Qty)
                        {

                            rows[0]["Qty"] = Qty.ToString("0");
                            rows[0]["ShwQty"] = Qty.ToString("0");

                            decimal amt = Convert.ToDecimal(Qty) * dRate;
                            rows[0]["Amount"] = amt.ToString("f2");
                        }

                    }
                }

                gvlist.DataSource = dt;
                gvlist.DataBind();
                //getdisablecolumn();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Something Went Wrong Please Process Button Type Billing.Thank You!!!');", true);
                return;
            }

            
            txtdiscou_TextChanged(sender, e);

        }

        protected void txtdiscou_TextChanged(object sender, EventArgs e)
        {

            if (ViewState["Total"] != null)
            {
                string a = ViewState["Total"].ToString();
                string b = ViewState["GTotal"].ToString();

            }
            decimal Oritotal = 0;
            decimal total = 0;
            decimal total1 = 0;
            decimal getGST = 0;
            decimal disco = 0;
            decimal disTotal = 0;
            double r = 0;
            decimal grandtotal = 0;
            decimal cgstot = 0;
            decimal sgstot = 0;
            decimal distot = 0;
            decimal Tot = 0;
            decimal dis = 0;
            decimal TQty = 0;
            // decimal Discamt = 0;



            dt = (DataTable)ViewState["dt"];

            foreach (DataRow dr in dt.Rows)
            {
                decimal Discamt = 0;
                if (dr["Disamt"].ToString() != "")
                {
                    disco += Convert.ToDecimal(dr["Disamt"]);
                }
                decimal tooo = Convert.ToDecimal(dr["Amount"]);
                decimal tooo1 = Convert.ToDecimal(dr["Amount"]);
                decimal tQty1 = Convert.ToDecimal(dr["Qty"]);

                total += Convert.ToDecimal(dr["Amount"]);
                total1 += Convert.ToDecimal(dr["Amount"]);
                TQty += tQty1;

                //if (dr["Discount"].ToString() == "True")
                //{
                //    disTotal += Convert.ToDecimal(dr["Amount"]);
                //    decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                //    Tot = Convert.ToDecimal(ttoo);
                //    dis = Convert.ToDecimal(txtDiscount.Text) / 100;
                //    Discamt = Tot * dis;
                //}

                disTotal += Convert.ToDecimal(dr["Amount"]);
                decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                Tot = Convert.ToDecimal(ttoo);
                dis = Convert.ToDecimal(0) / 100;

                Discamt = Tot * dis;
                dr["Disamt"] = Discamt;

                string lbldisco ="0";

                // if (lblisinclusiverate.Text == "N")
                {
                    lbldisco = Convert.ToDecimal(Discamt).ToString("f2");
                    distot += Convert.ToDecimal(Discamt);
                }
                // else
                {
                    //     distot = Convert.ToDecimal(lbldisco.Text);
                }

                tooo = tooo1 - Discamt;

                string GSt = (dr["Tax"]).ToString();
                string amountt = (dr["Tax"]).ToString();
                decimal gsthaf1 = Convert.ToDecimal(GSt) / 2;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gsthaf1)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;


                decimal oringstamount1 = (Convert.ToDecimal(tooo1) * Convert.ToDecimal(gsthaf1)) / 100;
                decimal Oritot = oringstamount1 + oringstamount1 + tooo1;


                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;
                Oritotal = Oritotal + Oritot;
            }



            txtamount.Text = total.ToString();
          //  lbloritot.Text = Oritotal.ToString();
            txtgrandamount.Text = grandtotal.ToString();
            //lbldisco = distot.ToString("0.00");



            //lblcgst.Text = (cgstot).ToString("0.00");
            //lblsgst.Text = (sgstot).ToString("0.00");
            txtgstamnt.Text = (cgstot + sgstot).ToString("0.00");
            // decimal Grand = grandtotal + Packing;
            decimal Packing = Convert.ToDecimal(0);
            decimal Delivery = Convert.ToDecimal(0);
            decimal Grand1 = 0;
           
            {


                Grand1 = (grandtotal + Packing + Delivery);
            }

            txtgrandamount.Text = (Grand1).ToString("0.00");
            decimal grandtot = Grand1;
            Grand1 = Math.Round(grandtot, 0);
            if (grandtot > Grand1)
            {
                lblRound.Text = (grandtot - Grand1).ToString("0.00");
            }
            else
            {
                lblRound.Text = (Grand1 - grandtot).ToString("0.00");
            }

            txtgrandamount.Text = (Grand1).ToString("0.00");



            txtgstamnt.Text = (cgstot + sgstot).ToString("0.00");



            
            txtgrandamount.Text = (Grand1).ToString("0.00");
            //lblsubttl.Text = (Grand1).ToString("0.00");
            //lbldisplay.InnerText = Grand1.ToString("0.00");
            txttotqty.Text = TQty.ToString("0.00");

           
        }

        //protected void txtdiscou_TextChanged(object sender, EventArgs e)
        //{

        //    if (ViewState["Total"] != null)
        //    {
        //        string a = ViewState["Total"].ToString();
        //        string b = ViewState["GTotal"].ToString();

        //    }
        //    decimal Oritotal = 0;
        //    decimal total = 0;
        //    decimal total1 = 0;
        //    decimal getGST = 0;
        //    decimal disco = 0;
        //    decimal disTotal = 0;
        //    double r = 0;
        //    decimal grandtotal = 0;
        //    decimal cgstot = 0;
        //    decimal sgstot = 0;
        //    decimal distot = 0;
        //    decimal Tot = 0;
        //    decimal dis = 0;
        //    decimal TQty = 0;
        //    // decimal Discamt = 0;



        //    dt = (DataTable)ViewState["dt"];

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        // decimal Discamt = 0;
        //        if (dr["Disamt"].ToString() != "")
        //        {
        //            disco += Convert.ToDecimal(dr["Disamt"]);
        //        }
        //        decimal tooo = Convert.ToDecimal(dr["Amount"]);
        //        decimal tooo1 = Convert.ToDecimal(dr["Amount"]);
        //        decimal tQty1 = Convert.ToDecimal(dr["Qty"]);

        //        total += Convert.ToDecimal(dr["Amount"]);
        //        total1 += Convert.ToDecimal(dr["Amount"]);
        //        TQty += tQty1;

        //        //if (dr["Discount"].ToString() == "True")
        //        //{
        //        //    disTotal += Convert.ToDecimal(dr["Amount"]);
        //        //    decimal ttoo = Convert.ToDecimal(dr["Amount"]);
        //        //    Tot = Convert.ToDecimal(ttoo);
        //        //    dis = Convert.ToDecimal(txtDiscount.Text) / 100;
        //        //    Discamt = Tot * dis;
        //        //}

        //        disTotal += Convert.ToDecimal(dr["Amount"]);
        //        decimal ttoo = Convert.ToDecimal(dr["Amount"]);
        //        Tot = Convert.ToDecimal(ttoo);
        //        // dis = Convert.ToDecimal(txtDiscount.Text) / 100;

        //        // Discamt = Tot * dis;
        //        dr["Disamt"] = "0";



        //        // if (lblisinclusiverate.Text == "N")
        //        {
        //            // lbldisco.Text = Convert.ToDecimal(Discamt).ToString("f2");
        //            //  distot += Convert.ToDecimal(Discamt);
        //        }
        //        // else
        //        {
        //            //     distot = Convert.ToDecimal(lbldisco.Text);
        //        }

        //        tooo = tooo1;

        //        string GSt = (0).ToString();
        //        string amountt = (0).ToString();
        //        decimal gsthaf1 = Convert.ToDecimal(GSt) / 2;

        //        decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gsthaf1)) / 100;
        //        decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;


        //        decimal oringstamount1 = (Convert.ToDecimal(tooo1) * Convert.ToDecimal(gsthaf1)) / 100;
        //        decimal Oritot = oringstamount1 + oringstamount1 + tooo1;


        //        decimal gstamt1 = ngstamount1;
        //        decimal cgstamt1 = ngstamount1;
        //        cgstot = cgstot + cgstamt1;
        //        sgstot = sgstot + gstamt1;
        //        grandtotal = grandtotal + dTotal1;
        //        Oritotal = Oritotal + Oritot;
        //    }



        //    // lbltotal.Text = total.ToString();
        //    //lbloritot.Text = Oritotal.ToString();
        //    txtamount.Text = total.ToString();
        //    // lbldisco.Text = distot.ToString("0.00");



        //    // lblcgst.Text = (cgstot).ToString("0.00");
        //    //  lblsgst.Text = (sgstot).ToString("0.00");
        //    // decimal Grand = grandtotal + Packing;
        //    if (txtdeliverycharge.Text == "")
        //        txtdeliverycharge.Text = "0";
        //    if (txtdiscount.Text == "")
        //        txtdiscount.Text = "0";

        //    decimal discount = Convert.ToDecimal(txtdiscount.Text);
        //    decimal Packing = Convert.ToDecimal(0);
        //    decimal Delivery = Convert.ToDecimal(txtdeliverycharge.Text);
        //    decimal Grand1 = 0;
        //    //if (lblisinclusiverate.Text == "Y")
        //    //{
        //    //    Grand1 = (grandtotal + Packing + Delivery - Convert.ToDecimal(lbldisco.Text));
        //    //}
        //    //else
        //    {


        //        Grand1 = (grandtotal + Packing + Delivery - discount);
        //    }

        //    // txtamount.Text = (Grand1).ToString("0.00");
        //    decimal grandtot = Grand1;
        //    Grand1 = Math.Round(grandtot, 0);
        //    if (grandtot > Grand1)
        //    {
        //        lblRound.Text = (grandtot - Grand1).ToString("0.00");
        //    }
        //    else
        //    {
        //        lblRound.Text = (Grand1 - grandtot).ToString("0.00");
        //    }

        //    txtgrandamount.Text = (Grand1).ToString("0.00");

        //    // calculate overall TAX 28/02/2022 by jothi

        //    if (txtgstper.Text == "")
        //        txtgstper.Text = "0";


        //    decimal gstper = Convert.ToDecimal(txtgstper.Text);

        //    decimal txamnt = (Grand1 * gstper) / 100;
        //    txtgstamnt.Text = txamnt.ToString();







        //    // txtTax.Text = (cgstot + sgstot).ToString("0.00");



        //    //lbltotal.Text = Convert.ToString(Grand1);
        //    txtgrandamount.Text = (Grand1 + txamnt).ToString("0.00");
        //    //  lblsubttl.Text = (Grand1).ToString("0.00");
        //    //  lbldisplay.InnerText = Grand1.ToString("0.00");
        //    txttotqty.Text = TQty.ToString("0.00");
        //}


        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = gvlist.Rows[index];
            dt = (DataTable)ViewState["dt"];
            Label Item = (Label)gvRow.FindControl("CategoryUserid");
            Label lblcattype = (Label)gvRow.FindControl("lblcattype");
            Label lblcombo = (Label)gvRow.FindControl("lblcombo");
            TextBox ShwQty = (TextBox)gvRow.FindControl("txtshwqty");
            TextBox txtcqty = (TextBox)gvRow.FindControl("txtcqty");

            if (e.CommandName == "minus")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (lblcattype.Text == "N")
                    {
                        if (dr["CategoryUserid"].ToString() == Item.Text && lblcattype.Text == dr["cattype"].ToString())
                        {
                            decimal qty = Convert.ToDecimal(dr["Qty"].ToString());
                            decimal shwqty = Convert.ToInt32(dr["ShwQty"].ToString());
                            //  int minQty = Convert.ToInt32(dr["recQty"].ToString());
                            decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                            decimal cqty = Convert.ToDecimal(dr["cQty"].ToString());
                            decimal amt = 0;
                            //  int final = qty - minQty;
                            decimal shwfinal = qty - 1;
                            decimal shwqtyy = shwqty - cqty;
                            dr["Qty"] = shwfinal.ToString();
                            dr["ShwQty"] = shwqtyy.ToString();

                            amt = shwfinal * rate;
                            dr["Amount"] = amt.ToString("f2");
                            if (dr["Qty"].ToString() == "0" && lblcattype.Text == dr["cattype"].ToString())
                            {
                                dt.Rows.Remove(dr);
                            }
                            ViewState["dt"] = dt;

                            break;
                        }
                    }
                    else if (lblcattype.Text == "C")
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (lblcombo.Text == dt.Rows[i]["combo"].ToString())
                            {
                                //dt.Rows.RemoveAt(i);
                                decimal qty = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                                decimal shwqty = Convert.ToDecimal(dt.Rows[i]["ShwQty"].ToString());
                                decimal cqty = Convert.ToDecimal(dt.Rows[i]["Cqty"].ToString());
                                decimal rate = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                                decimal amt = 0;
                                //  int final = qty - minQty;
                                decimal shwfinal = qty - 1;
                                decimal shqtyy = cqty * 1;

                                decimal shqtyy1 = shwqty - shqtyy;

                                dt.Rows[i]["Qty"] = shwfinal.ToString();
                                dt.Rows[i]["ShwQty"] = shqtyy1.ToString();
                                amt = shwfinal * rate;
                                dt.Rows[i]["Amount"] = amt.ToString("f2");
                                if (dt.Rows[i]["Qty"].ToString() == "0" || dt.Rows[i]["Qty"].ToString() == "0.0000")
                                {
                                    //dt.Rows.Remove(dt[i]);
                                    //  dt.Rows.Remove(dt.Rows[i]);
                                }

                            }
                        }
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                            if (dt.Rows[i]["Qty"].ToString() == "0" || dt.Rows[i]["Qty"].ToString() == "0.0000")
                                dt.Rows.RemoveAt(i);

                        ViewState["dt"] = dt;
                        break;
                    }
                }




            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (lblcattype.Text == "N")
                    {
                        if (dr["CategoryUserid"].ToString() == Item.Text && lblcattype.Text == dr["cattype"].ToString())
                        {
                            dt.Rows.Remove(dr);
                            ViewState["dt"] = dt;
                            break;
                        }
                    }
                    else if (lblcattype.Text == "C")
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {


                            for (int ii = dt.Rows.Count - 1; ii >= 0; ii--)
                                if (lblcombo.Text == dt.Rows[ii]["combo"].ToString())
                                    dt.Rows.RemoveAt(ii);

                        }
                        ViewState["dt"] = dt;
                        break;
                    }
                }



            }

            //  UpdatePanel.Update();

            DataView dvEmp = dt.DefaultView;
            dvEmp.Sort = "Sno Desc";
            gvlist.DataSource = dvEmp;
            gvlist.DataBind();
            //getdisablecolumn();
            //txtdiscou_TextChanged(sender, e);
            //if (Convert.ToDouble(lbloritot.Text) < Convert.ToDouble(lblmaxdiscount.Text))
            //{
            //    chkdisc.Checked = false;
            //    disc_checkedchanged(sender, e);

            //}
        }

        protected void drpsalestype_selectedindex(object sender, EventArgs e)
        {



            DataSet paymode = objbs.PaymodevaluesNew(drpsalestype.SelectedValue);
            if (paymode.Tables[0].Rows.Count > 0)
            {
                drpPayment.DataSource = paymode.Tables[0];
                drpPayment.DataTextField = "PayMode";
                drpPayment.DataValueField = "Value";
                drpPayment.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                return;
            }



        }




        protected void addclick(object sender, EventArgs e)
        {

            if (txtordernumber.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Online ORder number.Please Check it Again.Thank You!!!');", true);
                return;
            }

            int cntt = gvlist.Rows.Count;

            if (cntt == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item.Thank You!!!');", true);
                return;
            }

            if (btnadd.Text == "Save")
            {
                // check duplicate Order Number
                DataSet dorder = objbs.checkduplicatenumberlive(drpsalestype.SelectedValue, txtordernumber.Text);
                if (dorder.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Order No.,Already Exists.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;
                }


                DataSet getsalestypeamargin = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);
                if (getsalestypeamargin.Tables[0].Rows.Count > 0)
                {
                    lblordercount.Text = getsalestypeamargin.Tables[0].Rows[0]["OrderCount"].ToString();
                    lblordertype.Text = getsalestypeamargin.Tables[0].Rows[0]["OrderType"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Online Type Mismatched.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;

                }
                //if (lblisnormal.Text == "N")
                //{
                int lnght = txtordernumber.Text.Length;

                if (lnght.ToString() == lblordercount.Text)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Order No Count.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;
                }


                Regex r = new Regex("[ ^ 0-9]");

                if (lblordertype.Text == "1")
                {

                    bool containsInt = txtordernumber.Text.All(char.IsDigit);
                    if (containsInt == true)
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check and Type Order No.Thank You!!!');", true);
                        txtordernumber.Focus();
                        return;
                    }
                }
                //}
                // insert query
                int onlineno = objbs.insertOnline_Order(drpsalestype.SelectedValue, txtordernumber.Text, drpbranch.SelectedValue, txtentryby.Text, "AGN ORD", drpPayment.SelectedValue, txtsendername.Text, txtsenderno.Text, txtreceivername.Text, txtreceiverno.Text, txtorderdate.Text, txtdeliverydate.Text, txtamount.Text, txttotqty.Text, txtdiscount.Text, txtdeliverycharge.Text, txtgrandamount.Text, txtactamount.Text,txtgstper.Text,txtgstamnt.Text);


                int isalesid = Convert.ToInt32(onlineno);

                dt = (DataTable)ViewState["dt"];
                for (int i = 0; i < gvlist.Rows.Count; i++)
                {

                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");

                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");

                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");

                    int iStatus1 = objbs.insertTransOnline_Order(isalesid.ToString(), catid.Text, CategoryUserid.Text, rate.Text, txtgrandamount.Text, Amt.Text, Qty.Text, drpbranch.SelectedValue);

                }







            }
            else
            {
                // check duplicate Order Number
                DataSet dorder = objbs.checkduplicatenumberlive_update(drpsalestype.SelectedValue, txtordernumber.Text, lblonlinenumberid.Text);
                if (dorder.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Order No.,Already Exists.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;
                }

                DataSet getsalestypeamargin = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);
                if (getsalestypeamargin.Tables[0].Rows.Count > 0)
                {
                    lblordercount.Text = getsalestypeamargin.Tables[0].Rows[0]["OrderCount"].ToString();
                    lblordertype.Text = getsalestypeamargin.Tables[0].Rows[0]["OrderType"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Online Type Mismatched.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;

                }

                int lnght = txtordernumber.Text.Length;

                if (lnght.ToString() == lblordercount.Text)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Order No Count.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;
                }


                Regex r = new Regex("[ ^ 0-9]");

                if (lblordertype.Text == "1")
                {

                    bool containsInt = txtordernumber.Text.All(char.IsDigit);
                    if (containsInt == true)
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check and Type Order No.Thank You!!!');", true);
                        txtordernumber.Focus();
                        return;
                    }
                }

                // check status for hold and status
                DataSet dststus = objbs.checkonlinestatus_updatecheck(lblonlinenumberid.Text, "Hstatus", "N");
                if (dststus.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('ORder number Processed Not Allow To change.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;
                }


                DataSet dststus1 = objbs.checkonlinestatus_updatecheck(lblonlinenumberid.Text, "status", "N");
                if (dststus1.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('ORder number Processed Not Allow To change.Thank You!!!');", true);
                    txtordernumber.Focus();
                    return;
                }

                // Update ONline Edit
                int update = objbs.UpdateOnline_order(lblonlinenumberid.Text, drpsalestype.SelectedValue, txtordernumber.Text, drpbranch.SelectedValue, txtentryby.Text,
                    drpPayment.SelectedValue, txtsendername.Text, txtsenderno.Text, txtreceivername.Text, txtreceiverno.Text, txtorderdate.Text, txtdeliverydate.Text,
                    txtamount.Text, txttotqty.Text, txtdiscount.Text, txtdeliverycharge.Text, txtgrandamount.Text, txtactamount.Text, txtgstper.Text, txtgstamnt.Text);


                // insert trans item 

                //Delete transitem 
                int idelete = objbs.Deletetransitem(lblonlinenumberid.Text);

                // insert item 
                int isalesid = Convert.ToInt32(lblonlinenumberid.Text);

                dt = (DataTable)ViewState["dt"];
                for (int i = 0; i < gvlist.Rows.Count; i++)
                {

                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");

                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");

                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");

                    int iStatus1 = objbs.insertTransOnline_Order_update(isalesid.ToString(), catid.Text, CategoryUserid.Text, rate.Text, txtgrandamount.Text, Amt.Text, Qty.Text, drpbranch.SelectedValue);

                }
            }
            Response.Redirect("OnlineBillEntry.aspx");
        }

        protected void gvcat_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status"));

                if (Status == "Y")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Green;
                }
                else
                {

                    var start = DateTime.Now;
                    var oldDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "EntryDate"));

                    if ((start - oldDate).TotalMinutes >= 10)
                    {
                        //20 minutes were passed from start  
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                    }
                }
            }
        }

        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edits")
            {
                DataSet dsbranch = objbs.getbranchFilling_New("0", "Y");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpbranch.DataSource = dsbranch.Tables[0];
                    drpbranch.DataTextField = "BranchArea";
                    drpbranch.DataValueField = "BranchCode";
                    drpbranch.DataBind();
                    drpbranch.Items.Insert(0, "Select Branch");
                }

                DataSet getsalestype = objbs.GetSalesTypeForSales_normal("N");
                if (getsalestype.Tables[0].Rows.Count > 0)
                {
                    drpsalestype.DataSource = getsalestype.Tables[0];
                    drpsalestype.DataTextField = "PaymentType";
                    drpsalestype.DataValueField = "SalesTypeID";
                    drpsalestype.DataBind();
                }

                string iCat = e.CommandArgument.ToString();
                DataSet ds = objbs.onlineordernumber_update(iCat);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnadd.Text = "Update";

                    lblonlinenumberid.Text = ds.Tables[0].Rows[0]["OnlineID"].ToString();
                    drpsalestype.SelectedValue = ds.Tables[0].Rows[0]["OnlineType"].ToString();
                    txtordernumber.Text = ds.Tables[0].Rows[0]["OnlineNumber"].ToString();

                    drpbranch.SelectedValue = ds.Tables[0].Rows[0]["BranchCode"].ToString();
                    txtentryby.Text = ds.Tables[0].Rows[0]["EntryBy"].ToString();


                    //new entry

                    txtsendername.Text = ds.Tables[0].Rows[0]["Sendername"].ToString();
                    txtsenderno.Text = ds.Tables[0].Rows[0]["SenderNo"].ToString();
                    txtreceivername.Text = ds.Tables[0].Rows[0]["ReceiverName"].ToString();
                    txtreceiverno.Text = ds.Tables[0].Rows[0]["ReceiverNo"].ToString();
                    txtorderdate.Text = ds.Tables[0].Rows[0]["OrderDate"].ToString();
                    txtdeliverydate.Text = ds.Tables[0].Rows[0]["DeliveryDate"].ToString();



                    txtgrandamount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                    txtamount.Text = ds.Tables[0].Rows[0]["NetAmount"].ToString();
                    txtdiscount.Text = ds.Tables[0].Rows[0]["Discountamount"].ToString();
                    txtdeliverycharge.Text = ds.Tables[0].Rows[0]["Deliverycharge"].ToString();
                    txttotqty.Text = ds.Tables[0].Rows[0]["TotalQty"].ToString();
                    txtactamount.Text = ds.Tables[0].Rows[0]["ActualtotalAmount"].ToString();

                    txtgstper.Text = ds.Tables[0].Rows[0]["Gstper"].ToString();
                    txtgstamnt.Text = ds.Tables[0].Rows[0]["gstamount"].ToString();

                    Refersh();




                    // load item 

                    #region LOAD ITEM 
                    {
                        UpdatePanel3.Update();
                        decimal Shwqty = 0;
                        int comboo = 0;
                        decimal Qty = 0;
                        decimal HQty = 0;
                        decimal GST = 0;
                        decimal iQty = 0;
                        decimal SQty = 0;
                        string sItem = "";
                        decimal dCalTotal = 0;
                        decimal dRate = 0, dAmount = 0, dAvlQty = 0;
                        int iSubCatID = 0;
                        int CatID = 0;
                        int stockID = 0;
                        string sTempSession = "";

                        decimal SaleQty = 0;

                        string margin = "0";
                        string margingst = "0";
                        string paymsntgateway = "0";

                        // tblBill.Visible = true;
                        dt = (DataTable)ViewState["dt"];
                        //dtt = (DataTable)ViewState["dtt"];
                        DataSet dCat = new DataSet();
                        //  Button btn = (Button)sender;

                        //string[] commandArgs = drpitemsearch.SelectedValue.Split(new char[] { ',' });
                        //string categoryuserid = commandArgs[0];
                        string cattype = "N";


                        // dCat = objbs.GetStockDetails(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName);
                        if (cattype == "N")
                        {
                            dCat = objbs.gettransonlieitem(iCat);
                        }
                        else if (cattype == "C")
                        {
                            //  dCat = objbs.GetStockDetailscombo(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName);
                        }

                        if (dCat.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                            {

                                sItem = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                comboo = Convert.ToInt32(dCat.Tables[0].Rows[i]["comboo"]);
                                dRate =Convert.ToDecimal(dCat.Tables[0].Rows[i]["unitprice"].ToString());
                                CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                                iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString());
                                stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryUserid"].ToString());
                                dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                                GST = 0; //Convert.ToDecimal(dCat.Tables[0].Rows[i]["GST"].ToString());
                                Shwqty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["QTY"].ToString());
                                SaleQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Quantity"].ToString());
                                DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[0]["Expirydate"].ToString());
                                string lblisinclusiverate = "N";
                                if (lblisinclusiverate == "Y")
                                {
                                    DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "' AND combo='" + comboo + "'");
                                    if (rows.Length > 0)
                                    {



                                        decimal Dtax = (dRate * GST) / 100;

                                        decimal drateee = dRate + Dtax;

                                        decimal commamnt = (drateee * Convert.ToDecimal(0)) / 100;

                                        decimal commperamnt = (commamnt * Convert.ToDecimal(0)) / 100;

                                        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                        {
                                            Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                                            HQty = Convert.ToInt32(rows[0]["HQty"].ToString());
                                            Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        }
                                        // if ((dAvlQty + HQty) >= Qty)
                                        {
                                            rows[0]["Qty"] = Qty.ToString("0");


                                            decimal amt = Convert.ToDecimal(Qty) * DRATE;
                                            rows[0]["Amount"] = amt.ToString("f2");
                                        }
                                        // rows[0]["RecQty"] = recQty.ToString();
                                    }
                                    else
                                    {
                                        Qty = 0; int totcnt = 0;
                                        int countt = dt.Rows.Count;
                                        totcnt = countt + 1;
                                        DataRow dr = dt.NewRow();
                                        //Qty = Qty + 1;
                                       // Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        Qty = SaleQty;
                                        decimal amt = 0;

                                        decimal Dtax = (dRate * GST) / 100;

                                        decimal drateee = dRate + Dtax;

                                        decimal commamnt = (drateee * Convert.ToDecimal(0)) / 100;

                                        decimal commperamnt = (commamnt * Convert.ToDecimal(0)) / 100;

                                        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                        dr["Sno"] = totcnt;
                                        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                        dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                        dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                        dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("f0");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                        dr["Qty"] = Qty.ToString("0");
                                        dr["Rate"] = Convert.ToDecimal(DRATE).ToString("0.00");
                                        dr["Tax"] = Convert.ToDecimal(0);

                                        {
                                            amt = Convert.ToDecimal(Qty) * DRATE;
                                        }
                                        dr["Amount"] = amt.ToString("f2");
                                        dr["Orirate"] = dRate.ToString();
                                        //  if (dAvlQty >= Qty)
                                        {

                                            dt.Rows.Add(dr);
                                        }

                                        ViewState["dt"] = dt;
                                        txtmanualslno.Text = (totcnt + 1).ToString();
                                    }
                                }
                                else
                                {




                                    decimal Sqtyy = 0;

                                    {

                                        DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'  AND combo='" + comboo + "'");
                                        if (rows.Length > 0)
                                        {

                                            {
                                                Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                                HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                                Sqtyy = Convert.ToDecimal(rows[0]["ShwQty"].ToString());
                                                if (cattype == "N")
                                                {
                                                    //  Qty = Qty + 1;
                                                   // Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                    Qty = SaleQty;
                                                    Sqtyy = Sqtyy + Shwqty;
                                                }
                                                else if (cattype == "C")
                                                {
                                                    //Qty = Qty + 1;
                                                   // Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                    Qty = SaleQty;
                                                    Sqtyy = Sqtyy + Shwqty;
                                                }
                                            }
                                            // if ((dAvlQty + HQty) >= Qty)
                                            {
                                                rows[0]["Qty"] = Qty.ToString("0");
                                                rows[0]["ShwQty"] = Sqtyy.ToString("0");
                                                decimal amt = Convert.ToDecimal(Qty) * dRate;
                                                rows[0]["Amount"] = amt.ToString("f2");
                                            }
                                           


                                        }
                                        else
                                        {
                                            Qty = 0; int totcnt = 0;
                                            int countt = dt.Rows.Count;
                                            totcnt = countt + 1;
                                            DataRow dr = dt.NewRow();
                                            //Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                            Qty = SaleQty;
                                            decimal amt = 0;

                                            dr["Sno"] = totcnt;
                                            dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                            dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                            dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                            dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                            dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("f0");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                            dr["Qty"] = Qty.ToString("0");
                                            dr["ShwQty"] = Shwqty.ToString("0");
                                            dr["Rate"] = Convert.ToDecimal(dRate).ToString("f2");
                                            dr["Tax"] = Convert.ToDecimal(GST);
                                            dr["cattype"] = cattype;
                                            dr["combo"] = comboo;
                                            dr["Cqty"] = Shwqty.ToString("0");
                                            if (dr["Hqty"].ToString() == "0" || dr["Hqty"].ToString() == "")
                                            {
                                                dr["Hqty"] = "0";
                                            }
                                            else
                                            {

                                            }
                                            {
                                                amt = Convert.ToDecimal(Qty) * dRate;
                                            }
                                            dr["Amount"] = amt.ToString("f2");
                                            dr["Orirate"] = dRate.ToString();
                                            //   if (dAvlQty >= Qty)
                                            {

                                                dt.Rows.Add(dr);
                                            }
                                            

                                            ViewState["dt"] = dt;
                                            txtmanualslno.Text = (totcnt + 1).ToString();
                                        }
                                    }

                                    DataView dvEmp = dt.DefaultView;
                                    dvEmp.Sort = "Sno Desc";
                                    gvlist.DataSource = dvEmp;
                                    gvlist.DataBind();
                                    
                                }
                                txtdiscou_TextChanged(sender, e);
                            }
                        }


                        drpitemsearch.Focus();
                        txtmanualqty.Text = "";
                        txtrate.Text = "";


                    }

                    #endregion

                    // 


                }
            }
            else if (e.CommandName == "cancels")
            {
                if (txtRef.Text != "")
                {
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Thank You " + dch.Tables[0].Rows[0]["Name"].ToString() + ".');", true);
                    // Get Online Number

                    DataSet Dsonline = objbs.getorderonline(e.CommandArgument.ToString());
                    if (Dsonline.Tables[0].Rows.Count > 0)
                    {


                        // Cancel Order

                        int isscancel = objbs.OnlineManualCancel(e.CommandArgument.ToString(), ddlmainreason.SelectedItem.Text, txtRef.Text);
                        DataSet ds = objbs.getonlinenumberdetails();
                        gvip.DataSource = ds.Tables[0];
                        gvip.DataBind();
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Thank You Online Entry Cancel Successfully.Thank You!!!.');", true);


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Online Bill cannot be cancelled.Please Contact Administrator.Thank You!!!.');", true);
                        return;
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Online Bill cannot be cancelled Without Notes.');", true);
                }
            }
        }

        void Refersh()
        {
            gvlist.DataSource = null;
            gvlist.DataBind();

            dt.Rows.Clear();
            ViewState["dt"] = dt;
            if (dt.Columns.Count > 0)
            {
            }
            else
            {
                DataColumn col = new DataColumn("Sno", typeof(int));
                dt.Columns.Add(col);
                //dt.Columns.Add("Sno");
                dt.Columns.Add("CategoryID");
                dt.Columns.Add("CategoryUserID");
                dt.Columns.Add("Stockid");
                dt.Columns.Add("Definition");
                dt.Columns.Add("Available_QTY");
                dt.Columns.Add("TAX");
                dt.Columns.Add("margin");
                dt.Columns.Add("paygate");
                dt.Columns.Add("margintax");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Rate");
                dt.Columns.Add("OriRate");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Disamt");
                dt.Columns.Add("cattype");
                dt.Columns.Add("combo");
                dt.Columns.Add("ShwQty");
                dt.Columns.Add("cQty");
                dt.Columns.Add("HQty");
                ViewState["dt"] = dt;
            }
        }
    }
}