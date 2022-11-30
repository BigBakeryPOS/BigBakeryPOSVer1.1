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
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class BranchDetails : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bind time
                BindTime();


                // Getversion

                DataSet getversion = objBs.GetVersion("S");
                if (getversion.Tables[0].Rows.Count > 0)
                {
                    drpversion.DataSource = getversion.Tables[0];
                    drpversion.DataTextField = "Version";
                    drpversion.DataValueField = "VersionId";
                    drpversion.DataBind();
                    //drpversion.Items.Insert(0, "Select Item");
                    lblcurversion.Text = drpversion.SelectedItem.Text;
                }




                string iCusID = Request.QueryString.Get("iBranch");
                if (iCusID != "" || iCusID != null)
                {

                    DataSet getversionup = objBs.GetVersion("U");
                    if (getversionup.Tables[0].Rows.Count > 0)
                    {
                        drpversion.DataSource = getversionup.Tables[0];
                        drpversion.DataTextField = "Version";
                        drpversion.DataValueField = "VersionId";
                        drpversion.DataBind();
                        //drpversion.Items.Insert(0, "Select Item");
                    }



                    DataSet ds1 = objBs.getbranchdetails(iCusID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Update";
                        // Login want to chnages

                        txtbranchname.Text = ds1.Tables[0].Rows[0]["BranchName"].ToString();
                        txtmobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        txtgstin.Text = ds1.Tables[0].Rows[0]["GSTIN"].ToString();

                        txtbranchid.Text = iCusID;
                        // lblloginid.Text = ds1.Tables[0].Rows[0]["UserID"].ToString();

                        txtcustomername.Text = ds1.Tables[0].Rows[0]["ContactName"].ToString();
                        txtphoneno.Text = ds1.Tables[0].Rows[0]["LandLine"].ToString();
                        txtcountry.Text = ds1.Tables[0].Rows[0]["Country"].ToString();
                        txtstate.Text = ds1.Tables[0].Rows[0]["State"].ToString();
                        txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();

                        txtpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();
                        txtemail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();

                        txtcurrency.Text = ds1.Tables[0].Rows[0]["Currency"].ToString();
                        txtbranchcode.Text = ds1.Tables[0].Rows[0]["BranchCode"].ToString();
                        txtbranchcode.Enabled = false;
                        txtbrancharea.Text = ds1.Tables[0].Rows[0]["BranchArea"].ToString();

                        txtpemail.Text = ds1.Tables[0].Rows[0]["Pemail"].ToString();
                        txtiemail.Text = ds1.Tables[0].Rows[0]["Iemail"].ToString();
                        txtoemail.Text = ds1.Tables[0].Rows[0]["Oemail"].ToString();

                        drpbranchtype.SelectedValue = ds1.Tables[0].Rows[0]["BranchOwnType"].ToString();
                        txtFranchisename.Text = ds1.Tables[0].Rows[0]["FranchiseeName"].ToString();
                        drponlineenabeld.SelectedValue = ds1.Tables[0].Rows[0]["OnlineSalesActive"].ToString();
                        drpproductiontype.SelectedValue = ds1.Tables[0].Rows[0]["Mtype"].ToString();
                        drporderonlinesync.SelectedValue = ds1.Tables[0].Rows[0]["OnlineCakeSync"].ToString();
                        drpprintautoclose.SelectedValue = ds1.Tables[0].Rows[0]["Printtype"].ToString();
                        drpsdispatch.SelectedValue = ds1.Tables[0].Rows[0]["dipatchDirectly"].ToString();
                        txtfssaino.Text = ds1.Tables[0].Rows[0]["Fssaino"].ToString();
                        drponlinepos.SelectedValue = ds1.Tables[0].Rows[0]["onlinepos"].ToString();

                        Rdltype.SelectedValue = ds1.Tables[0].Rows[0]["PrintOption"].ToString();
                        RdlStocktype.SelectedValue = ds1.Tables[0].Rows[0]["StockOption"].ToString();

                        lblFile_Path.Text = ds1.Tables[0].Rows[0]["Imagepath"].ToString();
                        img_Photo.ImageUrl = ds1.Tables[0].Rows[0]["Imagepath"].ToString();

                        txtUsername.Text = ds1.Tables[0].Rows[0]["Username"].ToString();
                        txtPassword.Text = ds1.Tables[0].Rows[0]["Password"].ToString();

                        // txtcurrency.Text = ds1.Tables[0].Rows[0]["Currency"].ToString();

                        //Other Details
                        txtbillgenerateCode.Text = ds1.Tables[0].Rows[0]["BillCode"].ToString();
                        drpbillsetting.SelectedValue = ds1.Tables[0].Rows[0]["BillGenerateSetting"].ToString();
                        drptaxsplitup.SelectedValue = ds1.Tables[0].Rows[0]["Billtaxsplitupshown"].ToString();
                        drpprintlogo.SelectedValue = ds1.Tables[0].Rows[0]["BillPrintLogo"].ToString();
                        drpversion.SelectedValue = ds1.Tables[0].Rows[0]["BigVersion"].ToString();


                        drptaxsetting.SelectedValue = ds1.Tables[0].Rows[0]["TaxSetting"].ToString();
                        drpratesetting.SelectedValue = ds1.Tables[0].Rows[0]["Ratesetting"].ToString();
                        drpqtysetting.SelectedValue = ds1.Tables[0].Rows[0]["Qtysetting"].ToString();
                        drppossalessetting.SelectedValue = ds1.Tables[0].Rows[0]["possalessetting"].ToString();
                        drproundoffsetting.SelectedValue = ds1.Tables[0].Rows[0]["RoundoffSetting"].ToString();



                        drpautoqtysetting.SelectedValue = ds1.Tables[0].Rows[0]["QtyFillSetting"].ToString();
                        drpattednercheck.SelectedValue = ds1.Tables[0].Rows[0]["Posattendercheck"].ToString();
                        drpprintbillsetting.SelectedValue = ds1.Tables[0].Rows[0]["posPrintsetting"].ToString();
                        drporderbooknocheck.SelectedValue = ds1.Tables[0].Rows[0]["OrderBookcheck"].ToString();


                        if (drpversion.SelectedItem.Text == lblcurversion.Text)
                        {
                            lblcurversion.ForeColor = System.Drawing.Color.Green;
                            blink_msg.Visible = false;
                        }
                        else
                        {
                            lblcurversion.ForeColor = System.Drawing.Color.Red;
                            blink_msg.Visible = true;
                        }

                        btnadd.Text = "Update";
                    }

                }
            }

        }

        private void BindTime()
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
            //Set 5 minutes interval
            TimeSpan Interval = new TimeSpan(0, 30, 0);
            //To set 1 hour interval
            //TimeSpan Interval = new TimeSpan(1, 0, 0);           
            ddlTimeFrom.Items.Clear();
          //  ddlTimeTo.Items.Clear();
            while (StartTime <= EndTime)
            {
                ddlTimeFrom.Items.Add(StartTime.ToString("HH:mm tt"));
               // ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }
            ddlTimeFrom.Items.Insert(0, new ListItem("--Select--", "0"));
           // ddlTimeTo.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        //protected void branch_type(object sender, EventArgs e)
        //{
        //    if (drpbranchtype.SelectedValue == "O" || drpbranchtype.SelectedValue == "P")
        //    {
        //        txtFranchisename.Text = txtbranchname.Text;
        //        txtFranchisename.Enabled = false;
        //    }
        //    else
        //    {
        //        txtFranchisename.Enabled = true;

        //    }
        //}

        protected void Add_Click(object sender, EventArgs e)
        {
            string Imagepath = string.Empty;
            string BranchType = "";
            if (drpbranchtype.SelectedValue == "O")
            {
                BranchType = "0";
            }

            if (drpbranchtype.SelectedValue == "P")
            {
                BranchType = "2";
            }

            if (lblFile_Path.Text == "" || lblFile_Path.Text == null)
            {
                Imagepath = "../images/NoImage.png";
            }
            else
            {
                Imagepath = lblFile_Path.Text;
            }
            if (btnadd.Text == "Save")
            {
                int iStatus = objBs.Insertbranch(txtbranchname.Text, txtcustomername.Text, txtcountry.Text, txtstate.Text, txtcity.Text, txtaddress.Text, txtmobileno.Text, txtphoneno.Text, txtemail.Text, txtcurrency.Text, txtbranchcode.Text, txtbrancharea.Text, txtgstin.Text, lblloginid.Text, txtpincode.Text, txtpemail.Text, txtiemail.Text, txtoemail.Text, drpbranchtype.SelectedValue, txtFranchisename.Text, drponlineenabeld.SelectedValue, drpproductiontype.SelectedValue, drpprintautoclose.SelectedValue, drporderonlinesync.SelectedValue, txtfssaino.Text, drponlinepos.SelectedValue, Rdltype.SelectedValue, RdlStocktype.SelectedValue, Imagepath, BranchType, txtUsername.Text, txtPassword.Text, txtbillgenerateCode.Text, drpbillsetting.SelectedValue, drptaxsplitup.SelectedValue, drpprintlogo.SelectedValue, drpversion.SelectedValue, drptaxsetting.SelectedValue, drpratesetting.SelectedValue, drpqtysetting.SelectedValue, drppossalessetting.SelectedValue, drproundoffsetting.SelectedValue, drpautoqtysetting.SelectedValue, drpattednercheck.SelectedValue, drpprintbillsetting.SelectedValue, drporderbooknocheck.SelectedValue);
                Response.Redirect("../Accountsbootstrap/BranchGrid.aspx");
            }

            if (btnadd.Text == "Update")
            {
                string iCusID = Request.QueryString.Get("iBranch");

                //string BranchId,string BranchName,string ContactName,string Country,string State,string City,string Address,string MobileNo,string LandLine,string Email,string Currency,string BranchCode,string BranchArea,string GSTIN,string loginid
                // int iStatus = objBs.Updatebranch(iCusID, txtbranchname.Text, txtcustomername.Text, txtcountry.Text, txtstate.Text, txtcity.Text, txtaddress.Text, txtmobileno.Text, txtphoneno.Text, txtemail.Text, txtcurrency.Text, txtbranchcode.Text, txtbrancharea.Text, txtgstin.Text, lblloginid.Text,txtpincode.Text);
                int iStatus = objBs.Updatebranch(iCusID, txtbranchname.Text, txtcustomername.Text, txtcountry.Text, txtstate.Text, txtcity.Text, txtaddress.Text, txtmobileno.Text, txtphoneno.Text, txtemail.Text, txtcurrency.Text, txtbranchcode.Text, txtbrancharea.Text, txtgstin.Text, lblloginid.Text, txtpincode.Text, txtpemail.Text, txtiemail.Text, txtoemail.Text, drpbranchtype.SelectedValue, txtFranchisename.Text, drponlineenabeld.SelectedValue, drpproductiontype.SelectedValue, drpprintautoclose.SelectedValue, drporderonlinesync.SelectedValue, txtfssaino.Text, drponlinepos.SelectedValue, Rdltype.SelectedValue, RdlStocktype.SelectedValue, Imagepath, txtUsername.Text, txtPassword.Text, txtbillgenerateCode.Text, drpbillsetting.SelectedValue, drptaxsplitup.SelectedValue, drpprintlogo.SelectedValue, drpversion.SelectedValue, drptaxsetting.SelectedValue, drpratesetting.SelectedValue, drpqtysetting.SelectedValue, drppossalessetting.SelectedValue, drproundoffsetting.SelectedValue, drpsdispatch.SelectedValue, drpautoqtysetting.SelectedValue, drpattednercheck.SelectedValue, drpprintbillsetting.SelectedValue, drporderbooknocheck.SelectedValue);
                Response.Redirect("../Accountsbootstrap/login_branch.aspx");
            }

            //string Mode = Request.QueryString.Get("Mode");

            //if (btnadd.Text == "Save")
            //{

            //    DataSet ds = objBs.chkinsertcontact(txtemail.Text, txtmobileno.Text);
            //    if (ds.Tables[0].Rows.Count != 0)
            //    {
            //        lblerror.Text = "Email id or Mobile Number  already exists";
            //    }
            //    else
            //    {
            //        int GroupId = 0;
            //        if (ddlCustomerType.SelectedValue == "1")
            //        {
            //            GroupId = 5;
            //        }
            //        else if (ddlCustomerType.SelectedValue == "6")
            //        {
            //            GroupId = 6;
            //        }

            //        int iStatus = objBs.insertcontact(Convert.ToInt32(lblUserID.Text), txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(ddlCustomerType.SelectedValue), GroupId, txtdisc.Text);
            //        Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
            //    }

            //}
            //else
            //{
            //    DataSet dsmbl = objBs.chkupdatecustomer(txtemail.Text, txtmobileno.Text, txtcuscode.Text);
            //    if (dsmbl.Tables[0].Rows.Count != 0)
            //    {

            //        lblerror.Text = "Email id or Mobile Number  already exists";

            //        return;
            //    }
            //    else
            //    {
            //        int GroupId = 0;
            //        if (ddlCustomerType.SelectedValue == "1")
            //        {
            //            GroupId = 5;
            //        }
            //        else if (ddlCustomerType.SelectedValue == "6")
            //        {
            //            GroupId = 6;
            //        }

            //        int iStatus = objBs.updatecontact(txtcuscode.Text, txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(ddlCustomerType.SelectedValue), GroupId, txtdisc.Text);
            //        Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
            //    }
            //}



        }


        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../Images/") + fileName);
                lblFile_Path.Text = "../Images/" + FileUpload1.PostedFile.FileName;
                img_Photo.ImageUrl = "../Images/" + FileUpload1.PostedFile.FileName;
            }
        }

        protected void btnSample1_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "Application/pdf";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=BlackforestSalesPrint.pdf");
            //Response.TransmitFile(Server.MapPath("../Files/BlackforestSalesPrint.pdf"));
            //Response.End();

            string filePath = "../Files/BlackforestSalesPrint.pdf";
            string URL = ResolveClientUrl(filePath);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "show window",
            "shwwindow('" + URL + "');", true);

        }


        protected void btnSample2_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "Application/pdf";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=SekharSalesPrint.pdf");
            //Response.TransmitFile(Server.MapPath("../Files/SekharSalesPrint.pdf"));
            //Response.End();

            string filePath = "../Files/SekharSalesPrint.pdf";
            string URL = ResolveClientUrl(filePath);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "show window",
            "shwwindow('" + URL + "');", true);
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/BranchGrid.aspx");
        }
    }
}