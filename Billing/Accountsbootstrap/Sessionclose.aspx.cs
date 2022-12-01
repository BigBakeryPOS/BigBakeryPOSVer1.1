using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class Sessionclose : System.Web.UI.Page
    {
        string dt = "";
        string sTableName = "";
        string scode = "";
        BSClass objBs = new BSClass();
        int demonitationid;
        protected void Page_Load(object sender, EventArgs e)
        {



            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblErr.Visible = false;
            Button1.Enabled = false;
            //btndayyclose.Visible = false;


            #region Check Internet Connection
            if (objBs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To do Denomination Close.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion

            if (!IsPostBack)
            {

                DataSet dsreason = new DataSet();
                dsreason = objBs.getsessionmode();
                drpsessiontype.DataTextField = "sessionname";
                drpsessiontype.DataValueField = "sessionmode";
                drpsessiontype.DataSource = dsreason.Tables[0];
                drpsessiontype.DataBind();
                drpsessiontype.Items.Insert(0, "Select Type");
                drpsessiontype.SelectedValue = "2";
                drpsessiontype.Enabled = false;
                drpsessiontype1.DataTextField = "sessionname";
                drpsessiontype1.DataValueField = "sessionmode";
                drpsessiontype1.DataSource = dsreason.Tables[0];
                drpsessiontype1.DataBind();
                drpsessiontype1.Items.Insert(0, "Select Type");
                drpsessiontype1.SelectedValue = "4";
                drpsessiontype1.Enabled = false;



                DataSet getdenominationclose = objBs.getdenominationmaster();
                if (getdenominationclose.Tables[0].Rows.Count > 0)
                {
                  //  gvdenominationcloseing.DataSource = getdenominationclose.Tables[0];
                  //  gvdenominationcloseing.DataBind();

                    gvdenominationoffice.DataSource = getdenominationclose.Tables[0];
                    gvdenominationoffice.DataBind();
                }

                dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                date.Text = dt;
                Button1.Enabled = false;
                //DataSet getdenomination = objBs.getdenominationmaster();
                //if (getdenomination.Tables[0].Rows.Count > 0)
                //{
                //    griddenomination.DataSource = getdenomination.Tables[0];
                //    griddenomination.DataBind();
                //}

                string dtnew = DateTime.Now.ToString("yyyy-MM-dd");


                DataSet getoverallsalesamount = objBs.getoverallentries(sTableName, dtnew);
                if (getoverallsalesamount.Tables[0].Rows.Count > 0)
                {
                    gvdetailed.DataSource = getoverallsalesamount;
                    gvdetailed.DataBind();

                }

                DataSet ds = objBs.check_denomination(sTableName, dt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //btndayyclose.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Cant Update Another Time.Thank You!!!.Kindly Click Direct Day Close Button.');", true);
                    return;
                }
                else
                {
                   // btndayyclose.Visible = false;
                    Button1.Text = "save";
                }
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    //Button1.Text = "Update";

                //    //txt2000s_no.Text = ds.Tables[0].Rows[0]["TwoThousand"].ToString();
                //    //txt200s_no.Text = ds.Tables[0].Rows[0]["Twohundred"].ToString(); 

                //    //txt500s_no.Text = ds.Tables[0].Rows[0]["FiveHundreds"].ToString();
                //    //txt100s_no.Text = ds.Tables[0].Rows[0]["Hundreds"].ToString();
                //    //txt50s_no.Text = ds.Tables[0].Rows[0]["Fiftys"].ToString();
                //    //txt20s_no.Text = ds.Tables[0].Rows[0]["Twentys"].ToString();
                //    //txt10s_no.Text = ds.Tables[0].Rows[0]["Tens"].ToString();
                //    //txt5s_no.Text = ds.Tables[0].Rows[0]["Fives"].ToString();
                //    //txt2s_no.Text = ds.Tables[0].Rows[0]["Twos"].ToString();
                //    //txt1s_no.Text = ds.Tables[0].Rows[0]["ones"].ToString();
                //    //txtcoins_no.Text = ds.Tables[0].Rows[0]["Coins"].ToString();
                //    //lblTotal_Denominations.Text = ds.Tables[0].Rows[0]["Total"].ToString();
                //    //demonitationid = Convert.ToInt32(ds.Tables[0].Rows[0]["Denomination_ID"]);

                //    //btncalc_Click(sender, e);
                //}
                //else
                {

                }
            }

        }

        protected void btncalcc_Click(object sender, EventArgs e)
        {
            if (drpsessiontype.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }

            double tot = 0;
            for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenomin.Text = tot.ToString("0.00");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (drpsessiontype.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }

            double tott = 0;
            for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tott += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenominoffice.Text = tott.ToString("0.00");

            double tot = 0;
            for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenomin.Text = tot.ToString("0.00");


            if (lblgrandtotalDenomin.Text == "0.00" || lblgrandtotalDenomin.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
                return;
            }

            //if (lblgrandtotalDenominoffice.Text == "0.00" || lblgrandtotalDenominoffice.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
            //    return;
            //}


            int iss = objBs.cashsessionEntry(drpsessiontype.SelectedValue, lblgrandtotalDenomin.Text, sTableName, "Closing Petty Cash");
            for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            {
                Label lblDenominationid = (Label)gvdenominationcloseing.Rows[i].FindControl("lblDenominationid");
                Label lblname = (Label)gvdenominationcloseing.Rows[i].FindControl("lblname");
                Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");


                int isss = objBs.TranscashsessionEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

            }


            int isssss = objBs.cashsessionEntry(drpsessiontype1.SelectedValue, lblgrandtotalDenominoffice.Text, sTableName, "Final Cash to Office");
            for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            {
                Label lblDenominationid = (Label)gvdenominationoffice.Rows[i].FindControl("lblDenominationid");
                Label lblname = (Label)gvdenominationoffice.Rows[i].FindControl("lblname");
                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");


                int issss = objBs.TranscashsessionEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

            }

            Button4.Enabled = false;
        }


        protected void btncalccoffice_Click(object sender, EventArgs e)
        {

            btncalc_Click(sender, e);

            if (drpsessiontype1.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }
            // CHECKING AMOUNT VIA FULL DENOMINATION
            for (int i = 0; i < griddenomination.Rows.Count; i++)
            {

                Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");

                for (int ii = 0; ii < gvdenominationoffice.Rows.Count; ii++)
                {

                    Label lblvalue1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lblvalue");
                    TextBox lblnos1 = (TextBox)gvdenominationoffice.Rows[ii].FindControl("lblnos");
                    Label lbltotal1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lbltotal");

                    if (lblnos1.Text == "")
                        lblnos1.Text = "0";
                    if (lblvalue.Text == lblvalue1.Text)
                    {

                        if (Convert.ToInt16(lblnos.Text) >= Convert.ToInt32(lblnos1.Text))
                        {

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure it Correct Denomination in " + lblvalue.Text + ".Thank You!!!');", true);
                            return;
                        }
                    }


                }

            }



            double tot = 0;
            for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenominoffice.Text = tot.ToString("0.00");

            double bal = Convert.ToDouble(lblbalanceamount.Text) - tot;

            lblbalanceamount.Text = bal.ToString("0.00");

            // FILL IN CLOSING DENOMINATION
            double toto = 0;
            for (int i = 0; i < griddenomination.Rows.Count; i++)
            {

                Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");

                for (int ii = 0; ii < gvdenominationoffice.Rows.Count; ii++)
                {

                    Label lblvalue1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lblvalue");
                    TextBox lblnos1 = (TextBox)gvdenominationoffice.Rows[ii].FindControl("lblnos");
                    Label lbltotal1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lbltotal");

                    if (lblnos1.Text == "")
                        lblnos1.Text = "0";
                    if (lblvalue.Text == lblvalue1.Text)
                    {
                        for (int j = 0; j < gvdenominationcloseing.Rows.Count; j++)
                        {

                            int nos = Convert.ToInt32(lblnos.Text) - Convert.ToInt32(lblnos1.Text);

                            Label lblvalue2 = (Label)gvdenominationcloseing.Rows[j].FindControl("lblvalue");
                            if (lblvalue.Text == lblvalue2.Text)
                            {
                                TextBox lblnos2 = (TextBox)gvdenominationcloseing.Rows[j].FindControl("lblnos");
                                Label lbltotal2 = (Label)gvdenominationcloseing.Rows[j].FindControl("lbltotal");

                                lblnos2.Text = nos.ToString();
                                double total = (Convert.ToDouble(lblvalue2.Text) * Convert.ToDouble(lblnos2.Text));
                                toto += total;
                                lbltotal2.Text = total.ToString("0.00");
                            }


                        }

                        lblgrandtotalDenomin.Text = toto.ToString("0.00");

                    }

                }

            }

        }
        protected void Button11office_Click(object sender, EventArgs e)
        {
            if (drpsessiontype1.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }

            double tot = 0;
            for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenominoffice.Text = tot.ToString("0.00");

            if (lblgrandtotalDenominoffice.Text == "0.00" || lblgrandtotalDenominoffice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
                return;
            }


            int iss = objBs.cashsessionEntry(drpsessiontype1.SelectedValue, lblgrandtotalDenominoffice.Text, sTableName, "Cash To Office");
            for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
            {
                Label lblDenominationid = (Label)gvdenominationoffice.Rows[i].FindControl("lblDenominationid");
                Label lblname = (Label)gvdenominationoffice.Rows[i].FindControl("lblname");
                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");


                int isss = objBs.TranscashsessionEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

            }

            Button3.Enabled = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            dt = date.Text;

            DataSet ds = objBs.check_denomination(sTableName, dt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Cant Update Another Time.Thank You!!!');", true);
                return;
            }

            int hours = Convert.ToInt32(chkhour.Text);
            int minu = Convert.ToInt32(chkminu.Text);

            TimeSpan start = new TimeSpan(hours, minu, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now < start))
            {
                //match found
                //  date.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To close.Please Close After 09.30 PM.Thank You!!!');", true);
                return;
            }
            else
            {

            }



            DateTime dat1 = Convert.ToDateTime(date.Text);
            DateTime Toady = DateTime.Now.Date; ;

            var days = dat1.Day;
            var toda = Toady.Day;

            if ((toda - days) == 0)
            {

            }

            else
            {
                date.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To close.Thank You!!!');", true);
                return;
            }


            double toto = 0;
            for (int i = 0; i < griddenomination.Rows.Count; i++)
            {

                Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                toto += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotal.Text = toto.ToString("0.00");

            if (lblgrandtotal.Text == "0.00" || lblgrandtotal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Denomination Amount.Thank You!!!');", true);
                return;
            }


            if (lblgrandtotal.Text == "0")
            {
                lblErr.Visible = true;
                lblErr.Text = "Press Calculate!!";
                return;
            }

            if (drpsessiontype.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }

            double tott = 0;
            for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tott += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenominoffice.Text = tott.ToString("0.00");

            double tot = 0;
            for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenomin.Text = tot.ToString("0.00");


            if (lblgrandtotalDenomin.Text == "0.00" || lblgrandtotalDenomin.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
                return;
            }

            if (lblgrandtotalDenominoffice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
                return;
            }

            if (Button1.Text == "save")
            {
                DataSet checkentry = objBs.checkdenimonationentry(sTableName, dt);
                if (checkentry.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You can Close Only Once in a Day Else Use Session Closing Entry.Thank You!!!');", true);
                    return;
                }
                else
                {


                    int ii = objBs.Denominations(sTableName, dt, Convert.ToDouble(lblgrandtotal.Text), Convert.ToDouble(txtoverallcard.Text), Convert.ToDouble(txtoverallpaytm.Text), Convert.ToDouble(txtcreditamount.Text), Convert.ToDouble(txtoverallphonepe.Text));
                    for (int i = 0; i < griddenomination.Rows.Count; i++)
                    {
                        Label lblDenominationid = (Label)griddenomination.Rows[i].FindControl("lblDenominationid");
                        Label lblname = (Label)griddenomination.Rows[i].FindControl("lblname");
                        Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
                        TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
                        Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");


                        int isss = objBs.TransDenominationEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

                    }

                }

                int iss = objBs.cashsessionEntry(drpsessiontype.SelectedValue, lblgrandtotalDenomin.Text, sTableName, "Closing Petty Cash");
                for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
                {
                    Label lblDenominationid = (Label)gvdenominationcloseing.Rows[i].FindControl("lblDenominationid");
                    Label lblname = (Label)gvdenominationcloseing.Rows[i].FindControl("lblname");
                    Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                    TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                    Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");


                    int isss = objBs.TranscashsessionEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

                }


                int isssss = objBs.cashsessionEntry(drpsessiontype1.SelectedValue, lblgrandtotalDenominoffice.Text, sTableName, "Final Cash to Office");
                for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
                {
                    Label lblDenominationid = (Label)gvdenominationoffice.Rows[i].FindControl("lblDenominationid");
                    Label lblname = (Label)gvdenominationoffice.Rows[i].FindControl("lblname");
                    Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                    TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                    Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");


                    int issss = objBs.TranscashsessionEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

                }

                Response.Redirect("Closing_report.aspx");
            }
            else
            {
                //DataSet ds = objBs.check_denomination(sTableName, dt);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    demonitationid = Convert.ToInt32(ds.Tables[0].Rows[0]["Denomination_ID"]);
                //}

                //int i = objBs.updateDenominations(sTableName, demonitationid, dt, Convert.ToInt32(0), Convert.ToInt32(txt500s_no.Text), Convert.ToInt32(txt100s_no.Text), Convert.ToInt32(txt50s_no.Text), Convert.ToInt32(txt20s_no.Text), Convert.ToInt32(txt10s_no.Text), Convert.ToInt32(txt5s_no.Text), Convert.ToInt32(txt2s_no.Text), Convert.ToInt32(txt1s_no.Text), Convert.ToInt32(txtcoins_no.Text), Convert.ToDecimal(lblTotal_Denominations.Text), Convert.ToInt32(txt2000s_no.Text), Convert.ToInt32(txt200s_no.Text));
                //Response.Redirect("Daily_ViewReport.aspx");

            }
        }

        protected void btncalc_Click(object sender, EventArgs e)
        {


            double tot = 0;
            for (int i = 0; i < griddenomination.Rows.Count; i++)
            {

                Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotal.Text = tot.ToString("0.00");
            lblbalanceamount.Text = tot.ToString("0.00");

            Button1.Enabled = true;
        }

        protected void getoverallcalculation(object sender, EventArgs e)
        {
           // btncalc_Click(sender, e);

            if (drpsessiontype1.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }
            // // CHECKING AMOUNT VIA FULL DENOMINATION
            //for (int i = 0; i < griddenomination.Rows.Count; i++)
            //{

            //    Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
            //    TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
            //    Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");

            //    for (int ii = 0; ii < gvdenominationoffice.Rows.Count; ii++)
            //    {

            //        Label lblvalue1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lblvalue");
            //        TextBox lblnos1 = (TextBox)gvdenominationoffice.Rows[ii].FindControl("lblnos");
            //        Label lbltotal1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lbltotal");

            //        if (lblnos1.Text == "")
            //            lblnos1.Text = "0";
            //        if (lblvalue.Text == lblvalue1.Text)
            //        {

            //            if (Convert.ToInt16(lblnos.Text) >= Convert.ToInt32(lblnos1.Text))
            //            {

            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure it Correct Denomination in " + lblvalue.Text + ".Thank You!!!');", true);
            //                return;
            //            }
            //        }


            //    }

            //}



            double tot = 0;
            for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenominoffice.Text = tot.ToString("0.00");
            Button4.Enabled = true;

          //  double bal = Convert.ToDouble(lblbalanceamount.Text) - tot;

            // lblbalanceamount.Text = bal.ToString("0.00");

            //// FILL IN CLOSING DENOMINATION
            //double toto = 0;
            //for (int i = 0; i < griddenomination.Rows.Count; i++)
            //{

            //    Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
            //    TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
            //    Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");

            //    for (int ii = 0; ii < gvdenominationoffice.Rows.Count; ii++)
            //    {

            //        Label lblvalue1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lblvalue");
            //        TextBox lblnos1 = (TextBox)gvdenominationoffice.Rows[ii].FindControl("lblnos");
            //        Label lbltotal1 = (Label)gvdenominationoffice.Rows[ii].FindControl("lbltotal");

            //        if (lblnos1.Text == "")
            //            lblnos1.Text = "0";
            //        if (lblvalue.Text == lblvalue1.Text)
            //        {
            //            for (int j = 0; j < gvdenominationcloseing.Rows.Count; j++)
            //            {

            //                int nos = Convert.ToInt32(lblnos.Text) - Convert.ToInt32(lblnos1.Text);

            //                Label lblvalue2 = (Label)gvdenominationcloseing.Rows[j].FindControl("lblvalue");
            //                if (lblvalue.Text == lblvalue2.Text)
            //                {
            //                    TextBox lblnos2 = (TextBox)gvdenominationcloseing.Rows[j].FindControl("lblnos");
            //                    Label lbltotal2 = (Label)gvdenominationcloseing.Rows[j].FindControl("lbltotal");

            //                    lblnos2.Text = nos.ToString();
            //                    double total = (Convert.ToDouble(lblvalue2.Text) * Convert.ToDouble(lblnos2.Text));
            //                    toto += total;
            //                    lbltotal2.Text = total.ToString("0.00");
            //                }


            //            }

            //            lblgrandtotalDenomin.Text = toto.ToString("0.00");

            //        }

            //    }

            //}
        }

    }
}