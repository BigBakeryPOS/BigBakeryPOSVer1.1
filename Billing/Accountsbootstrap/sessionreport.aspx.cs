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
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class sessionreport : System.Web.UI.Page
    {
        string sTableName = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";
        string Empid = "";
        string dt = "";

        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string lblUser = Request.Cookies["userInfo"]["UserName"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            DataSet dsPlaceName = objbs.GetPlacename(lblUser, Password);
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();

            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {

                DataSet dsreason = new DataSet();
                dsreason = objbs.getsessionmode();
                drpsessiontype.DataTextField = "sessionname";
                drpsessiontype.DataValueField = "sessionmode";
                drpsessiontype.DataSource = dsreason.Tables[0];
                drpsessiontype.DataBind();
                drpsessiontype.Items.Insert(0, "Select Type");


                DataSet getdenomination = objbs.getdenominationmaster(lbldefaultcur.Text);
                if (getdenomination.Tables[0].Rows.Count > 0)
                {
                    griddenomination.DataSource = getdenomination.Tables[0];
                    griddenomination.DataBind();
                }

                dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                DataSet getsessiondetails = objbs.gridsessiondetails(sTableName,dt);
                if (getsessiondetails.Tables[0].Rows.Count > 0)
                {
                    griddetails.DataSource = getsessiondetails.Tables[0];
                    griddetails.DataBind();
                }

            }


        }

        protected void gvorderToday_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            double ttot =0;
            if (e.CommandName == "Print")
            {
                deno.Visible = true;
                //Response.Redirect("Print.aspx?OrderNo=" + e.CommandArgument.ToString());
                DataSet getdenomination = objbs.gridcashsessionForid(sTableName, e.CommandArgument.ToString());
                if (getdenomination.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = getdenomination.Tables[0];
                    GridView1.DataBind();
                    for (int i = 0; i < getdenomination.Tables[0].Rows.Count; i++)
                    {
                         ttot += Convert.ToDouble(getdenomination.Tables[0].Rows[i]["Total"]);

                       
                    }
                     lblDenototal.Text = (ttot).ToString("0.00");
                    string caption = "<h4><b>Cash Session Close Details" + "</br>" +"Session Name:"+getdenomination.Tables[0].Rows[0]["sessionname"].ToString() + "</br>"+ "Close Date :" + Convert.ToDateTime(getdenomination.Tables[0].Rows[0]["cashdate"]).ToString("MM/dd/yyyy hh:MM:tt") + "</br>" +  "</b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                    GridView1.Caption = caption;

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
                    //Response.Redirect("Sessionreport.aspx");
                }
                else
                {
                    lblDenototal.Text = "0";
                }
            }
            else if (e.CommandName == "Del")
            {

                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "SessionClosingReportDel");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Delete This Session.Thank you!!!.');", true);
                    return;
                }


                int iss = objbs.gridcashdeleteforid(sTableName, e.CommandArgument.ToString());
                Response.Redirect("Sessionreport.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }




            if (drpsessiontype.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }
            else
            {
                DataSet checksessionmode = objbs.getsessionmode(drpsessiontype.SelectedValue);
                if (checksessionmode.Tables[0].Rows.Count > 0)
                {
                    string timesave = checksessionmode.Tables[0].Rows[0]["Savetime"].ToString();
                    if (timesave == "1")
                    {

                        //check count for selected session

                        DataSet dcheck = objbs.checkcountforsession(sTableName);
                        if (dcheck.Tables[0].Rows.Count > 0)
                        {
                            string getsavetime = dcheck.Tables[0].Rows.Count.ToString();

                            if (timesave == "1")
                            {
                                if (timesave == getsavetime)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Session Type Exists Not Allow To Save Another Time.Thank You!!!');", true);
                                    return;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Session Type Exists Not Allow To Save Another Time.Thank You!!!');", true);
                                    return;

                                }
                            }

                        }
                        else
                        {

                        }
                    }
                    else if(timesave=="2")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To Save This Session Mode Type.Thank You!!!');", true);
                        return;
                    }
                    


                }

            }

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

            if (lblgrandtotal.Text == "0.00" || lblgrandtotal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
                return;
            }


            int iss = objbs.cashsessionEntry(drpsessiontype.SelectedValue, lblgrandtotal.Text, sTableName, txtnotes.Text);
            for (int i = 0; i < griddenomination.Rows.Count; i++)
            {
                Label lblDenominationid = (Label)griddenomination.Rows[i].FindControl("lblDenominationid");
                Label lblname = (Label)griddenomination.Rows[i].FindControl("lblname");
                Label lblvalue = (Label)griddenomination.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)griddenomination.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)griddenomination.Rows[i].FindControl("lbltotal");


                int isss = objbs.TranscashsessionEntry(lblname.Text,lblDenominationid.Text,lblvalue.Text,lbltotal.Text,sTableName,lblnos.Text);

            }

            Response.Redirect("Sessionreport.aspx");

        }
        protected void btncalc_Click(object sender, EventArgs e)
        {
            if (drpsessiontype.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }
            double tot =0;
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //DataSet ds = objbs.SessionlistReport(sTableName, date.Text);
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    gvlist.DataSource = null;
            //    gvlist.DataBind();
            //    string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + " For " + Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy") + " </b></h4> ";
            //    gvlist.Caption = caption;
            //    gvlist.DataSource = ds.Tables[0];
            //    gvlist.DataBind();
            //    decimal Total = 0;
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        Total += decimal.Parse(dr["cash"].ToString());
            //    }

            //    lbltotl.Text = Total.ToString("f2");
            //}

        }


        protected void btnPrintFromCodeBehind_Click(object sender, EventArgs e)
        {
            //  string Branch = "";
            //  if (sTableName == "CO1")
            //      Branch = "Kk nagar";
            //else if (sTableName == "CO2")
            //      Branch = "Byepass";
            //  else if (sTableName == "CO3")
            //      Branch = "BB kulam";
            //  else if (sTableName == "CO4")
            //      Branch = "Narayanapuram";
            //  else if (sTableName == "CO5")
            //      Branch = "Palayankottal";
            //  else if (sTableName == "CO6")
            //      Branch = "Maduravayol";
            //  else if (sTableName == "CO7")
            //      Branch = "Purasawalkam";


            //  else if (sTableName == "CO8")
            //      Branch = "Chennai";

            //  else if (sTableName == "CO9")
            //      Branch = "Thirunelveli";

            //  else if (sTableName == "CO10")
            //      Branch = "Periyar";
            //  else if (sTableName == "CO11")
            //      Branch = "Palayam";
            try
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
                //string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + " For " + Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy") + " </b></h4> ";
                //gvlist.Caption = caption;
                //  gvstock.Caption = Branch+" Printed On : "+ DateTime.Now.ToString("dd/MM/yyyy hh:mm:tt");
            }
            catch { }
        }


    }
}