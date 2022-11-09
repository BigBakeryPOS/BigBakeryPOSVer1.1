using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class ItemReturngrid : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        string scode = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";
        double grandtot = 0;
        string Btype = "";


        string Label123 = "";
        string ratesetting = "";
        string qtysetting = "";
        string currency = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();
            Btype = Request.Cookies["userInfo"]["BType"].ToString();

            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            currency = Request.Cookies["userInfo"]["Currency"].ToString();

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);

            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();


            if (!IsPostBack)
            {

                DataSet dsreason = new DataSet();
                dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");

             
                txtfromdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DataSet dRet = objbs.ReturnGridSearchDetailsnew(sTableName, txtfromdate.Text, txttodate.Text);
                string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                gvReturnss.Caption = caption;
                gvReturnss.DataSource = dRet;
                gvReturnss.DataBind();

                //DataSet dRetToal = objbs.ReturnGridSearchTotal(sTableName, txtfromdate.Text, txttodate.Text);

                //if (dRetToal.Tables[0].Rows.Count > 0)
                //{
                //    if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                //    {
                //        decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                //        lblTotal.InnerText = total.ToString("f2");
                //    }
                //}
                //else
                //{
                //    lblTotal.InnerText = "0.00";

                //}
            }
        }

        protected void gvreturn_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double total = Convert.ToDouble( Convert.ToDouble(e.Row.Cells[2].Text).ToString(""+ratesetting+""));
                e.Row.Cells[2].Text = Convert.ToDouble(total).ToString("" + ratesetting + "");
                grandtot += total;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total:";
                e.Row.Cells[2].Text = grandtot.ToString(""+ratesetting+"");
            }

        }

        protected void gvReturnsItem_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double Qty = Convert.ToDouble(Convert.ToDouble(e.Row.Cells[4].Text).ToString("" + qtysetting + ""));
                e.Row.Cells[4].Text = Convert.ToDouble(Qty).ToString("" + qtysetting + "");
                double total = Convert.ToDouble( Convert.ToDouble(e.Row.Cells[5].Text).ToString(""+ratesetting+""));
                e.Row.Cells[5].Text = Convert.ToDouble(total).ToString("" + ratesetting + "");
                grandtot += total;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total:";
                e.Row.Cells[5].Text = grandtot.ToString(""+ratesetting+"");
            }

        }
        protected void gvReturnss_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                DataSet ds = objbs.ReturnGridSearchbyidprint(sTableName, e.CommandArgument.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvReturnsItem.DataSource = ds;
                    gvReturnsItem.DataBind();

                    string caption = "<h4><b>Item Stock Return Details" + "</br>" + "Branch Name : " + BranchNAme + "</br>" + "Return Date :" + ds.Tables[0].Rows[0]["ReturnDate"].ToString() + "</br>" + "Return No :" + ds.Tables[0].Rows[0]["RetNo"].ToString() + "</br>" + "Entry BY :" + ds.Tables[0].Rows[0]["name"].ToString() + "</br>" + "Detailed Notes :" + ds.Tables[0].Rows[0]["notes"].ToString() + "</b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                    gvReturnsItem.Caption = caption;
                }
                else
                {
                    gvReturnsItem.DataSource =null;
                    gvReturnsItem.DataBind();

                }
            }

            if (e.CommandName == "Print")
            {

                DataSet ds = objbs.ReturnGridSearchbyidprint(sTableName,e.CommandArgument.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvReturnsItem.DataSource = ds;
                    gvReturnsItem.DataBind();

                    string caption = "<h4><b>Item Stock Return Details" + "</br>" + "Branch Name : " + BranchNAme + "</br>" + "Return Date :" + ds.Tables[0].Rows[0]["ReturnDate"].ToString() + "</br>" + "Return No :" + ds.Tables[0].Rows[0]["RetNo"].ToString() + "</br>" + "Entry BY :" + ds.Tables[0].Rows[0]["name"].ToString() + "</br>" + "Detailed Notes :" + ds.Tables[0].Rows[0]["notes"].ToString() + "</b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                    gvReturnsItem.Caption = caption;
                }
                else
                {
                    gvReturnsItem.DataSource = null;
                    gvReturnsItem.DataBind();

                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            
            if (ddlreason.SelectedValue == "All")
            {
                DataSet dRet = objbs.ReturnGridSearchDetailsnew(sTableName, txtfromdate.Text, txttodate.Text);
                if (dRet.Tables[0].Rows.Count > 0)
                {
                    string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                    gvReturnss.Caption = caption;
                    gvReturnss.DataSource = dRet;
                    gvReturnss.DataBind();

                }

                else
                {
                    gvReturnss.DataSource = null;
                    gvReturnss.DataBind();

                }
                //DataSet dRetToal = objbs.ReturnGridSearchTotal(sTableName, txtfromdate.Text, txttodate.Text);

                //if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                //{
                //    decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                //    lblTotal.InnerText = total.ToString("f2");

                //}

                //else
                //{

                //    lblTotal.InnerText = "0.00";
                //}
            }

            else
            {
                DataSet dRet = objbs.ReturnGridSearchDetailsnewbyreason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                if (dRet.Tables[0].Rows.Count > 0)
                {
                    string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                    gvReturnss.Caption = caption;
                    gvReturnss.DataSource = dRet;
                    gvReturnss.DataBind();
                }

                else
                {
                    gvReturnss.DataSource = null;
                    gvReturnss.DataBind();
                }
                //DataSet dRetToal = objbs.ReturnGridSearchTotalReason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));

                //if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                //{
                //    decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                //    lblTotal.InnerText = total.ToString("f2");
                //}

                //else
                //{
                //    lblTotal.InnerText = "0.00";
                //}
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Btype == "0")
            {
                DataSet checkdayclose = objbs.checkinser_Previousday(sTableName);
                if (checkdayclose.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect("stockreturn.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Return Stock.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
            }
            else
            {
                Response.Redirect("stockreturn.aspx");
            }

            
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {

            //if (sTableName == "CO1")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO2")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO3")
            //{
            //    Label123 = "Shiva Delights";
            //}
            //else if (sTableName == "CO4")
            //{
            //    Label123 = "Fig and honey";
            //}
            //else if (sTableName == "CO5")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}

            //else if (sTableName == "CO6")
            //{
            //    Label123 = "Maduravayol";
            //}

            //else if (sTableName == "CO6")
            //{
            //    Label123 = "purasavakkam";
            //}
            GridView gridview = new GridView();
            if (ddlreason.SelectedValue == "All")
            {
                DataSet dRet = objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                gridview.DataSource = dRet.Tables[0];
                gridview.DataBind();
            }
            else
            {

                gridview.DataSource = objbs.ReturnGridSearchReason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                gridview.DataBind();
            }
            //lblstkreturn.Text = Label123 + " Stock Return Report Generated From Date " + txtfromdate.Text + "To Date " + txttodate.Text + "On" + DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");
           // gridview.Caption = Label123 + " Stock Return Report Generated From  " + txtfromdate.Text + "To  " + txttodate.Text + " On " +  DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            gridview.Caption = "Store :  " + BranchNAme + " " + StoreName + " Stock Return Report Generated From " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=StockReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {
                DateTime date = Convert.ToDateTime(txtfromdate.Text);
                DateTime Toady = DateTime.Now.Date; ;

               // var qqq = Toady - date;
                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) <= Convert.ToDouble(30))
                {

                }

                else
                {
                    txtfromdate.Text = "";
                }
            }
        }
    }
}