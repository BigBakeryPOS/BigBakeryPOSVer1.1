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
namespace Billing.Accountsbootstrap
{
    public partial class StockTransfer : System.Web.UI.Page
    {

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    lblUser.Text = Session["UserName"].ToString();
        //    lblUserID.Text = Session["UserID"].ToString();
        //    sTableName = Session["User"].ToString();
        //    if (!IsPostBack)
        //    {
        //        DataSet dStore = objbs.GetStores();
        //        ddlStore.DataSource=dStore.Tables[0];
        //        ddlStore.DataTextField = "Branch";
        //        ddlStore.DataValueField = "UserID";
        //        ddlStore.DataBind();
        //        ddlStore.Items.Insert(0, "Select Store");
        //    }
        //}


        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //}
        string sTableName = "";
        BSClass objBs = new BSClass();
        DataTable dt = new DataTable();
        public static int SubcatID;
        DataTable dCrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();


            if (!Page.IsPostBack)
            {
                dt.Columns.Add("CatID");
                dt.Columns.Add("SubCatID");
                dt.Columns.Add("StockID");
                dt.Columns.Add("category");
                dt.Columns.Add("item");
                dt.Columns.Add("OrderQty");

                ViewState["Datatable"] = dt;

                //DataSet dStore = objBs.GetStores(Convert.ToInt32(lblUserID.Text), sTableName);
                //ddlStore.DataSource = dStore.Tables[0];
                //ddlStore.DataTextField = "Branch";
                //ddlStore.DataValueField = "UserID";
                //ddlStore.DataBind();
                //ddlStore.Items.Insert(0, "Select Store");
                for (int i = 0; i < ddlStore.Items.Count; i++)
                {
                    if (sTableName.ToLower() == "co1" || sTableName.ToLower() == "co2" || sTableName.ToLower() == "co3" || sTableName.ToLower() == "co4" || sTableName.ToLower() == "co5" )
                    {
                        if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co6") == true)
                            ddlStore.Items[i].Enabled = false;
                        if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co7") == true)
                            ddlStore.Items[i].Enabled = false;
                    }
                    if (sTableName.ToLower() == "co6" || sTableName.ToLower() == "co7")
                    {
                        if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co1") == true)
                            ddlStore.Items[i].Enabled = false;
                        else if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co2") == true)
                            ddlStore.Items[i].Enabled = false;
                        else if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co3") == true)
                            ddlStore.Items[i].Enabled = false;
                        else if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co4") == true)
                            ddlStore.Items[i].Enabled = false;
                        else if (ddlStore.Items[i].Value.ToLower().ToString().Contains("co5") == true)
                            ddlStore.Items[i].Enabled = false;

                    }



                }

                DataSet dReq = objBs.StockReqNo(Convert.ToInt32(lblUserID.Text));

                if (dReq.Tables[0].Rows.Count > 0)
                {
                    if (dReq.Tables[0].Rows[0]["ReqNo"].ToString() != "")
                    {
                        txtReqNo.Text = dReq.Tables[0].Rows[0]["ReqNo"].ToString();
                    }

                    else
                    {
                        txtReqNo.Text = "1";
                    }
                }

                txtdate.Text = DateTime.Now.ToString();



            }


        }









        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dstock = objBs.GetStoresStock((ddlStore.SelectedValue));

            if (dstock.Tables[0].Rows.Count > 0)
            {
                DataSet dsCategory = new DataSet();
                dsCategory = objBs.selectCAT();
                ddlCategory.DataTextField = "category";
                ddlCategory.DataValueField = "categoryid";
                ddlCategory.DataSource = dsCategory.Tables[0];
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "select");


            }
        }

        protected void ddlcat_selectedindexchanged(object s, EventArgs e)
        {
            DataSet dDef = objBs.selectStockdecription(Convert.ToInt32(ddlCategory.SelectedValue), ddlStore.SelectedValue);
            ddlitem.DataTextField = "item";
            ddlitem.DataValueField = "stockid";
            ddlitem.DataSource = dDef.Tables[0];
            ddlitem.DataBind();
            ddlitem.Items.Insert(0, "select");
            ddlitem.Focus();
        }
        protected void dditem_selectedindexchanged(object s, EventArgs e)
        {
            DataSet dget = objBs.GetStoreStockDetails(Convert.ToInt32(ddlitem.SelectedValue), ddlStore.SelectedValue);
            if (dget.Tables[0].Rows.Count > 0)
            {
                txtAvlQty.Text = Convert.ToDecimal(dget.Tables[0].Rows[0]["Available_Qty"].ToString()).ToString("f0");
                SubcatID = Convert.ToInt32(dget.Tables[0].Rows[0]["subcategoryid"].ToString());
            }

            txtOrderQty.Focus();
        }

        protected void add_click(object s, EventArgs e)
        {
            int avl = Convert.ToInt32(txtAvlQty.Text);
            int Req = Convert.ToInt32(txtOrderQty.Text);

            if (Req > avl)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Not Allowed');", true);
                txtOrderQty.Text = "0";
            }
            else
            {
                dCrt = (DataTable)ViewState["Datatable"];
                if (dCrt.Rows.Count == 0)
                {
                    DataRow dr = dCrt.NewRow();
                    dr["CatID"] = ddlCategory.SelectedValue;
                    dr["SubCatID"] = SubcatID;
                    dr["StockID"] = ddlitem.SelectedValue;
                    dr["Category"] = ddlCategory.SelectedItem.Text;
                    dr["item"] = ddlitem.SelectedItem.Text;
                    dr["OrderQty"] = txtOrderQty.Text;
                    dCrt.Rows.Add(dr);




                }
                else
                {
                    DataRow dr = dCrt.NewRow();
                    dr["CatID"] = ddlCategory.SelectedValue;
                    dr["SubCatID"] = SubcatID;
                    dr["StockID"] = ddlitem.SelectedValue;
                    dr["Category"] = ddlCategory.SelectedItem.Text;
                    dr["item"] = ddlitem.SelectedItem.Text;
                    dr["OrderQty"] = txtOrderQty.Text;
                    dCrt.Rows.Add(dr);


                }
                ViewState["Firstrow"] = dCrt;
                gvItems.DataSource = dCrt;
                gvItems.DataBind();

                txtAvlQty.Text = "";
                txtOrderQty.Text = "";
                ddlCategory.Focus();
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dat = ViewState["Firstrow"] as DataTable;
            dat.Rows[index].Delete();
            ViewState["Firstrow"] = dat;
            ViewState["Datatable"] = dat;
            gvItems.DataSource = dat;
            gvItems.DataBind();

            dCrt = dat;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[5].Text;
                foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int iStockSuccess = 0;
            string body = string.Empty;
            string content = string.Empty;
            

            //  DataTable dCrt = (DataTable)ViewState["Firstrow"];
            if (txtRequestBy.Text.Trim() != "")
            {

                if (gvItems.Rows.Count > 0)
                {
                    for (int i = 0; i < gvItems.Rows.Count; i++)
                    {
                        int icat = Convert.ToInt32(gvItems.Rows[i].Cells[1].Text);
                        int idef = Convert.ToInt32(gvItems.Rows[i].Cells[2].Text); ;
                        double dQty = Convert.ToInt32(gvItems.Rows[i].Cells[6].Text); ;
                        int stockid = Convert.ToInt32(gvItems.Rows[i].Cells[3].Text); ;

                       
                        iStockSuccess = objBs.StockTransfer(Convert.ToInt32(txtReqNo.Text), txtdate.Text, sTableName, (ddlStore.SelectedValue), icat, idef, (dQty), txtRequestBy.Text, stockid);





                      



                       

                    }
                    //using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/breadlist.htm")))
                    //{
                    //    body = reader.ReadToEnd();
                    //}
                    //SendEmail(sender, e);

                    Response.Redirect("StockTransfer.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Add Item to the list');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Enter Request by Name');", true);
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");

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
                //mailMessage.CC.Add(new MailAddress(cc));
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
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/breadlist.htm")))
            {
                body = reader.ReadToEnd();
            }



            if (gvItems.Rows.Count > 0)
            {
                for (int i = 0; i < gvItems.Rows.Count; i++)
                {

                    double dQty = Convert.ToInt32(gvItems.Rows[i].Cells[6].Text); ;


                    string Item = gvItems.Rows[i].Cells[5].Text;






                    content = content + "<tr><td> " + Item + "</td><td> " + dQty + "</td></tr>";



                    

                }

                body = body.Replace("{lblTotal_Exp}", content);





               
            }
            return body;
        }


        protected void SendEmail(object sender, EventArgs e)
        {



            string Bread = this.BreadList(" ",
       "  ",
       "",
       " ");





            {
                this.SendBreadList("blaackforestreports@gmail.com", "", "InterBranch Stock Request(" + DateTime.Now.ToString() + ") -From Store: " + lblUser.Text + "  To Store " + ddlStore.SelectedItem.Text + " ReQuest by" + txtRequestBy.Text + "", Bread);

                //this.SendHtmlFormattedEmail("pratheep.kumar@gmail.com", "harishbabu.jg@gmail.com", "Daily Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", body);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);
            }
        }

     



    }
}
