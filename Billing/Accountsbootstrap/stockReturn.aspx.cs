using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net.NetworkInformation;
namespace Billing.Accountsbootstrap
{
    public partial class stockReturn : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        DataTable dt = new DataTable();
        public static int SubcatID;
        DataTable dCrt;
        string sCode = "";
        string StockOption = "Nil";
        string Btype = "";
        string ratesetting = "";
        string qtysetting = "";
        string currency = "";
        //string StockOption = "Nil";
        System.Globalization.CultureInfo Cul = new System.Globalization.CultureInfo("en-GB", true);
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Btype = Request.Cookies["userInfo"]["BType"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();

            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            currency = Request.Cookies["userInfo"]["Currency"].ToString();

            if (!IsPostBack)
            {
                ddlsubreasons.Items.Insert(0, "Select SubReasons");
                if (sTableName == "admin")
                {
                    admin.Visible = true;
                }
                else
                {
                    admin.Visible = false;
                }

                dt.Columns.Add("Group");
                dt.Columns.Add("Item");
                dt.Columns.Add("ExistQty");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Rate");
                dt.Columns.Add("Amount");
                dt.Columns.Add("CatID");
                dt.Columns.Add("SubCatID");
                dt.Columns.Add("stockid");


                ViewState["Datatable"] = dt;

                DataSet dsreason = new DataSet();
                dsreason = objBs.GetReturnResaon(Btype);
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "Select Reason");


                DataSet dsCategory = new DataSet();
                dsCategory = objBs.selectCAT();
                ddlCategory.DataTextField = "Printcategory";
                ddlCategory.DataValueField = "categoryid";
                ddlCategory.DataSource = dsCategory.Tables[0];
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "select");

                txtsdate1.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm tt");

                DataSet dsBill = new DataSet();
                if (sTableName == "admin")
                    dsBill = objBs.ReturnNo("tblReturn_" + ddlBranch.SelectedValue);
                else
                    dsBill = objBs.ReturnNo("tblReturn_" + sTableName);
                if (dsBill.Tables[0].Rows.Count > 0)
                {
                    if (dsBill.Tables[0].Rows[0]["Retno"].ToString() == "")
                        txtbillno.Text = "1";
                    else
                        txtbillno.Text = dsBill.Tables[0].Rows[0]["Retno"].ToString();

                }

                // Checking InterNet
                #region Check Internet Connection

                if (objBs.IsConnectedToInternet())
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No InterNet Access.');", true);
                    btnSave.Enabled = false;
                    return;
                }

                #endregion
            }





        }



        protected void ddlcat_selectedindexchanged(object s, EventArgs e)
        {
            DataSet dsCategory = new DataSet();
            //if (sTableName == "admin")
            //{
            //    dsCategory = objBs.SelectItems(Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(lblUserID.Text), ddlBranch.SelectedValue);
            //}
            //else
            {
                dsCategory = objBs.SelectItems_Return(Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName,Btype);
            }
            ddlitem.DataTextField = "PrintItem";
            ddlitem.DataValueField = "stockid";
            ddlitem.DataSource = dsCategory.Tables[0];
            ddlitem.DataBind();
            ddlitem.Items.Insert(0, "select");
            ddlitem.Focus();
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ItemReturngrid.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string requestentrytime = System.DateTime.Now.ToString("hh:mm tt");

            string datetmenow = DateTime.Now.ToString("MM-dd-yyyy HH:mm tt");
            DateTime datenow = DateTime.ParseExact(datetmenow, "MM-dd-yyyy HH:mm tt", CultureInfo.InstalledUICulture);

            if (Btype == "0")
            {

                DataSet checkdenomaiantiondone = objBs.checkdenomination_Previousday(sTableName);
                if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
            }

            if (ddlreason.SelectedValue == "Select Reason")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Reasons .');", true);
                return;
            }

            if (ddlsubreasons.SelectedValue == "0" || ddlsubreasons.SelectedValue == "" || ddlsubreasons.SelectedValue == "Select SubReasons")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select SubReasons .');", true);
                return;
            }

            if (txtnotes.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter detailed Notes.Thank You!!! .');", true);
                return;
            }

            if (sTableName == "admin")
            {
                if (txtreturningPerson.Text.Trim() != "")
                {
                    int iStockSuccess = 0;
                    int OrderBillProd = 0;
                    DataTable table = ViewState["Datatable"] as DataTable;

                    string Productioncode = "";
                    DataSet dsbp = objBs.getbranchproduction(ddlBranch.SelectedValue);
                    if (dsbp.Tables[0].Rows.Count > 0)
                    {
                        Productioncode = dsbp.Tables[0].Rows[0]["Productioncode"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Plz Check Branch Production Code.');", true);
                        return;
                    }


                    //Local 
                    int OrderBill = objBs.InsertReturn("tblReturn_" + ddlBranch.SelectedValue, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtsdate1.Text, Convert.ToInt32("1"), Convert.ToDouble(total.Text), Convert.ToDouble(total.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt16(ddlreason.SelectedValue), txtreturningPerson.Text, Convert.ToInt16(ddlsubreasons.SelectedValue), requestentrytime, txtnotes.Text);

                    if (Btype == "0")
                    {

                        //Server
                        OrderBillProd = objBs.InsertReturnProd("tblReturnProd_" + Productioncode, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtsdate1.Text, Convert.ToInt32("1"), Convert.ToDouble(total.Text), Convert.ToDouble(total.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt16(ddlreason.SelectedValue), txtreturningPerson.Text, Convert.ToInt16(ddlsubreasons.SelectedValue), requestentrytime, txtnotes.Text, ddlBranch.SelectedValue, OrderBill);
                    }

                    if (table != null)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            int stockid = Convert.ToInt32(dr["stockid"].ToString());
                            int catid = Convert.ToInt32(dr["CatID"].ToString());
                            int subcatid = Convert.ToInt32(dr["SubCatID"].ToString());
                            double dQty = Convert.ToDouble(dr["Qty"].ToString());
                            double DRate = Convert.ToDouble(dr["Rate"].ToString());
                            double Amount = Convert.ToDouble(dr["Amount"].ToString());

                            int isalesid = Convert.ToInt32(txtbillno.Text);
                            //Local
                            int iStatus1 = objBs.insertTransReturn("tbltransReturn_" + ddlBranch.SelectedValue, OrderBill, catid, dQty, DRate, Amount, subcatid, stockid);

                            if (Btype == "0")
                            {
                                //Server
                                int iStatusProd1 = objBs.insertTransReturnProd("tbltransReturnProd_" + Productioncode, OrderBillProd, catid, dQty, DRate, Amount, subcatid, stockid);
                            }

                            iStockSuccess = UpdateStockAvailable(catid, subcatid, Convert.ToDecimal(dQty), DateTime.Now.ToShortDateString(), Convert.ToString(stockid), OrderBill.ToString());

                        }
                    }
                    Response.Redirect("Home_Page.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Your Name.');", true);
                }
            }
            else
            {
                //if (txtreturningPerson.Text.Trim().Contains("mani") || txtreturningPerson.Text.Trim().Contains("KR"))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Name is Blocked.');", true);
                //}
                //else
                {
                    if (txtreturningPerson.Text.Trim() != "")
                    {
                        int iStockSuccess = 0;
                        int OrderBillProd = 0;
                        DataTable table = ViewState["Datatable"] as DataTable;

                        string Productioncode = "";
                        if (Btype == "0")
                        {
                            DataSet dsbp = objBs.getbranchproduction(sTableName);
                            if (dsbp.Tables[0].Rows.Count > 0)
                            {
                                Productioncode = dsbp.Tables[0].Rows[0]["Productioncode"].ToString();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Plz Check Branch Production Code.');", true);
                                return;
                            }
                        }
                        else if (Btype == "2")
                        {
                            Productioncode = sTableName;
                        }

                        //Local
                        int OrderBill = objBs.InsertReturn("tblReturn_" + sTableName, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtsdate1.Text, Convert.ToInt32("1"), Convert.ToDouble(total.Text), Convert.ToDouble(total.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt16(ddlreason.SelectedValue), txtreturningPerson.Text, Convert.ToInt16(ddlsubreasons.SelectedValue), requestentrytime, txtnotes.Text);

                        if (Btype == "0")
                        {
                            //Server
                            OrderBillProd = objBs.InsertReturnBilling("tblReturnProd_" + Productioncode, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtsdate1.Text, Convert.ToInt32("1"), Convert.ToDouble(total.Text), Convert.ToDouble(total.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt16(ddlreason.SelectedValue), txtreturningPerson.Text, Convert.ToInt16(ddlsubreasons.SelectedValue), requestentrytime, txtnotes.Text, sTableName, OrderBill);
                        }

                        else
                        {
                            //Saved in Production side database.
                            OrderBillProd = objBs.InsertReturnProd("tblReturnProd_" + Productioncode, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtsdate1.Text, Convert.ToInt32("1"), Convert.ToDouble(total.Text), Convert.ToDouble(total.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt16(ddlreason.SelectedValue), txtreturningPerson.Text, Convert.ToInt16(ddlsubreasons.SelectedValue), requestentrytime, txtnotes.Text, sTableName, OrderBill);
                        }

                        if (table != null)
                        {
                            foreach (DataRow dr in table.Rows)
                            {


                                int stockid = Convert.ToInt32(dr["stockid"].ToString());
                                int catid = Convert.ToInt32(dr["CatID"].ToString());
                                int subcatid = Convert.ToInt32(dr["SubCatID"].ToString());
                                double dQty = Convert.ToDouble(dr["Qty"].ToString());
                                double DRate = Convert.ToDouble(dr["Rate"].ToString());
                                double Amount = Convert.ToDouble(dr["Amount"].ToString());

                                int isalesid = Convert.ToInt32(txtbillno.Text);// objBs.SalesId("tblSales_" + sTableName);

                                //Local
                                int iStatus1 = objBs.insertTransReturn("tbltransReturn_" + sTableName, OrderBill, catid, dQty, DRate, Amount, subcatid, stockid);
                                if (Btype == "0")
                                {
                                    //Server
                                    int iStatus1Prod = objBs.insertTransReturnBilling("tbltransReturnProd_" + Productioncode, OrderBillProd, catid, dQty, DRate, Amount, subcatid, stockid);
                                }

                                else
                                {
                                    //Server
                                    int iStatus1Prod = objBs.insertTransReturnProd("tbltransReturnProd_" + Productioncode, OrderBillProd, catid, dQty, DRate, Amount, subcatid, stockid);
                                }

                                iStockSuccess = UpdateStockAvailable(catid, subcatid, Convert.ToDecimal(dQty), DateTime.Now.ToShortDateString(), Convert.ToString(stockid), OrderBill.ToString());





                            }
                        }
                        //  SendEmail(sender, e);
                        Response.Redirect("ItemReturngrid.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Your Name.');", true);
                    }

                }
            }
        }

        private void SendBreadList(string recepientEmail, string cc, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                mailMessage.CC.Add(new MailAddress(cc));
                //mailMessage.CC.Add(new MailAddress(a));
                //mailMessage.CC.Add(new MailAddress(b));
                //mailMessage.CC.Add(new MailAddress(c));
                //mailMessage.CC.Add(new MailAddress(d));

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
                NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
                smtp.Send(mailMessage);
            }
        }

        private string BreadList(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            string content = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/Damage.htm")))
            {
                body = reader.ReadToEnd();
            }

            DataTable table = ViewState["Datatable"] as DataTable;

            if (table != null)
            {
                foreach (DataRow dr in table.Rows)
                {


                    content = content + "<tr><td> " + dr["Item"].ToString() + "</td><td> " + dr["Qty"].ToString() + "</td><td>" + ddlreason.SelectedItem.Text + "</td></tr>";
                }
            }



            body = body.Replace("{lblTotal_Exp}", content);





            return body;
        }




        protected void SendEmail(object sender, EventArgs e)
        {



            string Bread = this.BreadList(" ",
       "  ",
       "",
       " ");

            if (sCode == "NE")
            {
                this.SendBreadList("bfpalayankottai@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(txtsdate1.Text).ToString("dd-MM-yyyy") + ") - Store: " + "Nellai" + " ", Bread);
            }
            if (sCode == "KK")
            {
                this.SendBreadList("bfkknagaar@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(txtsdate1.Text).ToString("dd-MM-yyyy") + ") - Store: " + "Kk nagar" + " ", Bread);
            }
            if (sCode == "NP")
            {
                this.SendBreadList("bfnpuram@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(txtsdate1.Text).ToString("dd-MM-yyyy") + ") - Store: " + "Narayanapuram" + " ", Bread);
            }
            if (sCode == "BY")
            {
                this.SendBreadList("bfbypass@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(txtsdate1.Text).ToString("dd-MM-yyyy") + ") - Store: " + "Byepass" + " ", Bread);
            }
            if (sCode == "BB")
            {
                this.SendBreadList("bfbbkulam@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(txtsdate1.Text).ToString("dd-MM-yyyy") + ") - Store: " + "BB Kulam" + " ", Bread);
            }






            //this.SendHtmlFormattedEmail("pratheep.kumar@gmail.com", "harishbabu.jg@gmail.com", "Daily Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", body);


        }

        private int UpdateStockAvailable(int iCat, int iSubCat, decimal iQty, string sDate, string iStockID, string ireturnid)
        {
            decimal iAQty = 0;

            int iSuccess = 0;
            if (Btype == "0")
            {

                if (sTableName == "admin")
                {
                    DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), ddlBranch.SelectedValue,StockOption);
                    if (dsStock.Tables[0].Rows.Count > 0)
                    {
                        iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                    }
                    decimal iRemQty = iAQty - iQty;
                    iSuccess = objBs.updateSalesStock(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), ddlBranch.SelectedValue, "-", "Stock Return", iQty.ToString(), ireturnid, StockOption);
                }
                else
                {
                    DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName,StockOption);
                    if (dsStock.Tables[0].Rows.Count > 0)
                    {
                        iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                    }
                    decimal iRemQty = iAQty - iQty;
                    iSuccess = objBs.updateSalesStock(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, "-", "Stock Return", iQty.ToString(), ireturnid, StockOption);
                }
            }
            else if (Btype == "2")
            {
                DataSet dsStock = objBs.GetStockDetails_Return(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName,Btype);
                if (dsStock.Tables[0].Rows.Count > 0)
                {
                    iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                }
                decimal iRemQty = iAQty - iQty;
                iSuccess = objBs.updateSalesStock_ProdReturn(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, "-", "Stock Return", iQty.ToString(), ireturnid);
            }

            return iSuccess;
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dat = ViewState["Datatable"] as DataTable;
            dat.Rows[index].Delete();

            ViewState["Datatable"] = dat;
            gvItems.DataSource = dat;
            gvItems.DataBind();

            dCrt = dat;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string item = e.Row.Cells[5].Text;
            //    foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
            //    {
            //        if (button.CommandName == "Delete")
            //        {
            //            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
            //        }
            //    }
            //}
        }
        protected void dditem_selectedindexchanged(object sender, EventArgs e)
        {
            DataSet dsStock = new DataSet();
            //if (sTableName == "admin")
            //    dsStock = objBs.GetStockDetails(Convert.ToInt32(ddlitem.SelectedValue), Convert.ToInt32(lblUserID.Text), ddlBranch.SelectedValue);
            //else
            dsStock = objBs.GetStockDetails_Return(Convert.ToInt32(ddlitem.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName,Btype);

            if (dsStock.Tables[0].Rows.Count > 0)
            {
                lblSubcatid.Text = dsStock.Tables[0].Rows[0]["categoryuserid"].ToString();
                lblcatid.Text = dsStock.Tables[0].Rows[0]["CategoryID"].ToString();
                Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Rate"].ToString());
                txtRate.Text = Decimal.Round(Irate, 2).ToString(""+ratesetting+"");
                txtretQty.Focus();
                decimal sQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());
                txtAvalQty.Text = sQty.ToString("" + qtysetting + "");
                // Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());

                // txtRate.Text = Decimal.Round(Irate, 2).ToString("f2");



            }
        }

        protected void drpPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            ds = objBs.GetEubReasons(Convert.ToInt32(ddlreason.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsubreasons.DataSource = ds.Tables[0];
                ddlsubreasons.DataTextField = "SubReasons";
                ddlsubreasons.DataValueField = "id";
                ddlsubreasons.DataBind();
                ddlsubreasons.Items.Insert(0, "Select SubReasons");
            }
            else
            {
                ddlsubreasons.DataSource = null;
                ddlsubreasons.DataBind();
                ddlsubreasons.Items.Insert(0, "Select SubReasons");
            }
        }

        protected void txtretQty_TextChanged(object sender, EventArgs e)
        {

            if (txtretQty.Text == "0")
                txtretQty.Text = "0";
            if (txtRate.Text == "0")
                txtRate.Text = "0";
            if (txtAmount.Text == "0")
                txtAmount.Text = "0";
            if (txtretQty.Text == "0")
                txtretQty.Text = "0";

            decimal dQty = Convert.ToDecimal(txtretQty.Text);


            decimal DRate = Convert.ToDecimal(txtRate.Text);


            decimal dAmount = 0;


            decimal dEQty = Convert.ToDecimal(txtAvalQty.Text);

            if (dQty > dEQty)
            {
                lblError.Visible = true;
                lblError.Text = "Check Stock Qty";
                lblError.ForeColor = System.Drawing.Color.Red;
                btnSave.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Avaliable Stock.Thank You!!!');", true);
                return;
            }
            else
            {
                lblError.Visible = false;
                btnSave.Enabled = true;
                dAmount = dQty * DRate;
                txtAmount.Text = dAmount.ToString("" + ratesetting + "");
                decimal dAmt = 0; decimal dTotal = 0;


                img.Focus();

                //if (Amount.Text != "")
                //{
                //    AddNewRow();
                //}
            }
          //  upanel.Update();
        }

        protected void add_click(object sender, ImageClickEventArgs e)
        {
            if (txtretQty.Text == "")
                txtretQty.Text = "0";
            if (txtRate.Text == "")
                txtRate.Text = "0";
            if (txtAvalQty.Text == "")
                txtAvalQty.Text = "0";
            if (txtAmount.Text == "")
                txtAmount.Text = "0";

            if (Convert.ToDouble(txtretQty.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Return Qty.');", true);
                txtretQty.Focus();
                return;
            }
            if (Convert.ToDouble(txtRate.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Rate.');", true);
                txtRate.Focus();
                return;
            }
            if (Convert.ToDouble(txtAmount.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Amount.');", true);
                txtAmount.Focus();
                return;
            }

            decimal dQty = Convert.ToDecimal(Convert.ToDecimal(txtretQty.Text).ToString("" + qtysetting + ""));// Convert.ToDecimal(txtretQty.Text);


            decimal DRate = Convert.ToDecimal(txtRate.Text);


            decimal dAmount = 0;


            decimal dEQty = Convert.ToDecimal( Convert.ToDecimal(txtAvalQty.Text).ToString(""+qtysetting+""));

            if (dQty > dEQty)
            {
                lblError.Visible = true;
                lblError.Text = "Check Stock Qty";
                lblError.ForeColor = System.Drawing.Color.Red;
                btnSave.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Avaliable Stock.Thank You!!!');", true);
                return;
            }

            for (int ii = 0; ii < gvItems.Rows.Count; ii++)
            {
                Label lblSubCatID = (Label)gvItems.Rows[ii].FindControl("lblSubCatID");

                if (lblSubCatID.Text == lblSubcatid.Text)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check This Item.This Item Already Added in Below Stock.Thank You!!!');", true);
                    return;
                }

            }


            if (sTableName == "admin")
            {
                decimal dAmt = 0; decimal dTotal = 0;
                dCrt = (DataTable)ViewState["Datatable"];
                if (dCrt.Rows.Count == 0)
                {
                    DataRow dr = dCrt.NewRow();


                    dr["CatID"] = ddlCategory.SelectedValue;
                    dr["SubCatID"] = lblSubcatid.Text;

                    dr["Group"] = ddlCategory.SelectedItem.Text;
                    dr["item"] = ddlitem.SelectedItem.Text;
                    dr["ExistQty"] = Convert.ToDouble(txtAvalQty.Text).ToString("" + qtysetting + "");

                    dr["Qty"] =  Convert.ToDouble(txtretQty.Text).ToString("" + qtysetting + "");
                    dr["Rate"] = txtRate.Text;
                    dr["Amount"] = txtAmount.Text;
                    dr["stockid"] = ddlitem.SelectedValue;
                    dCrt.Rows.Add(dr);




                }
                else
                {
                    DataRow dr = dCrt.NewRow();
                    dr["CatID"] = ddlCategory.SelectedValue;
                    dr["SubCatID"] = lblSubcatid.Text;

                    dr["Group"] = ddlCategory.SelectedItem.Text;
                    dr["item"] = ddlitem.SelectedItem.Text;
                    dr["ExistQty"] = Convert.ToDouble(txtAvalQty.Text).ToString("" + qtysetting + "");

                    dr["Qty"] = Convert.ToDouble(txtretQty.Text).ToString("" + qtysetting + "");
                    dr["Rate"] = txtRate.Text;
                    dr["Amount"] = txtAmount.Text;
                    dr["stockid"] = ddlitem.SelectedValue;
                    dCrt.Rows.Add(dr);


                }
                ViewState["Datatable"] = dCrt;
                gvItems.DataSource = dCrt;
                gvItems.DataBind();




                for (int i = 0; i < gvItems.Rows.Count; i++)
                {


                    if (txtAmount.Text != "")
                    {
                        dAmt += Convert.ToDecimal(gvItems.Rows[i].Cells[7].Text);
                    }

                }
                dTotal = dAmt;

                total.Text = dTotal.ToString("" + ratesetting + "");

                txtAmount.Text = "";
                txtretQty.Text = "";
                txtRate.Text = "";
                txtAvalQty.Text = "";
            }
            else
            {



                if (txtreturningPerson.Text.Trim().Contains("mani"))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Name is Blocked.');", true);
                }
                else
                {

                    decimal dAmt = 0; decimal dTotal = 0;
                    dCrt = (DataTable)ViewState["Datatable"];
                    if (dCrt.Rows.Count == 0)
                    {
                        DataRow dr = dCrt.NewRow();


                        dr["CatID"] = ddlCategory.SelectedValue;
                        dr["SubCatID"] = lblSubcatid.Text;

                        dr["Group"] = ddlCategory.SelectedItem.Text;
                        dr["item"] = ddlitem.SelectedItem.Text;
                        dr["ExistQty"] = Convert.ToDouble(txtAvalQty.Text).ToString("" + qtysetting + "");

                        dr["Qty"] = Convert.ToDouble(txtretQty.Text).ToString("" + qtysetting + "");
                        dr["Rate"] = txtRate.Text;
                        dr["Amount"] = txtAmount.Text;
                        dr["stockid"] = ddlitem.SelectedValue;
                        dCrt.Rows.Add(dr);




                    }
                    else
                    {
                        DataRow dr = dCrt.NewRow();
                        dr["CatID"] = ddlCategory.SelectedValue;
                        dr["SubCatID"] = lblSubcatid.Text;

                        dr["Group"] = ddlCategory.SelectedItem.Text;
                        dr["item"] = ddlitem.SelectedItem.Text;
                        dr["ExistQty"] = Convert.ToDouble(txtAvalQty.Text).ToString("" + qtysetting + "");

                        dr["Qty"] = Convert.ToDouble(txtretQty.Text).ToString("" + qtysetting + "");
                        dr["Rate"] = txtRate.Text;
                        dr["Amount"] = txtAmount.Text;
                        dr["stockid"] = ddlitem.SelectedValue;
                        dCrt.Rows.Add(dr);


                    }
                    ViewState["Datatable"] = dCrt;
                    gvItems.DataSource = dCrt;
                    gvItems.DataBind();




                    for (int i = 0; i < gvItems.Rows.Count; i++)
                    {


                        if (txtAmount.Text != "")
                        {
                            dAmt += Convert.ToDecimal(gvItems.Rows[i].Cells[7].Text);
                        }

                    }
                    dTotal = dAmt;

                    total.Text = dTotal.ToString(""+ratesetting+"");

                    txtAmount.Text = "";
                    txtretQty.Text = "";
                    txtRate.Text = "";
                    txtAvalQty.Text = "";
                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsBill = new DataSet();
            if (sTableName == "admin")
                dsBill = objBs.ReturnNo("tblReturn_" + ddlBranch.SelectedValue);
            else
                dsBill = objBs.ReturnNo("tblReturn_" + sTableName);
            if (dsBill.Tables[0].Rows.Count > 0)
            {
                // int iBillNo = ds.Tables[0].Rows[0]["billno"].ToString();
                if (dsBill.Tables[0].Rows[0]["Retno"].ToString() == "")
                    txtbillno.Text = "1";
                else
                    txtbillno.Text = dsBill.Tables[0].Rows[0]["Retno"].ToString();



                //btnadd.Text = "Save";
            }
        }

    }
}