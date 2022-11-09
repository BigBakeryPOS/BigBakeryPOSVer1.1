using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Diagnostics;
using System.Data;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class StockReturnReport : System.Web.UI.Page
    {
        string scode = "";
        string sTableName = "";
        string Label123 = "";
        BSClass objbs = new BSClass();
        string Btype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Extra1.Visible = false;
            Extra2.Visible = false;
            Btype = Request.Cookies["userInfo"]["BType"].ToString();
            
            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet dsreason = new DataSet();
                dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");

                if (sTableName != "admin")
                {
                    admin.Visible = false;
                }
                else
                {
                   
                }
                //if (scode != "NE")
                //{
                //    for (int i = 0; i < drpPayment.Items.Count; i++)
                //    {
                //        if (drpPayment.Items[i].Text.ToLower().Contains("to production"))
                //        {
                //            drpPayment.Items[i].Enabled = false;
                //            break;
                //        }
                //    }
                //}

                txtfromdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txttodate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                if (sTableName == "admin")
                {
                    DataSet dRet = objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
                    gvReturns.DataSource = dRet;
                    gvReturns.DataBind();

                    DataSet dPrint = objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
                    gvPrint.DataSource = dPrint;
                    gvPrint.DataBind();

                    DataSet dRetToal = objbs.ReturnGridSearchTotal(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);

                    if (dRetToal.Tables[0].Rows.Count > 0)
                    {
                        if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                        {
                            decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                            lblTotal.InnerText = total.ToString("f2");
                            Label1.InnerText = total.ToString("f2");
                        }
                    }
                    else
                    {
                        lblTotal.InnerText = "0.00";
                        Label1.InnerText = "0.00";
                    }
                }
                else
                {
                    admin.Visible = false;
                    DataSet dRet = objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                    gvReturns.DataSource = dRet;
                    gvReturns.DataBind();

                    DataSet dPrint = objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                    gvPrint.DataSource = dPrint;
                    gvPrint.DataBind();

                    DataSet dRetToal = objbs.ReturnGridSearchTotal(sTableName, txtfromdate.Text, txttodate.Text);

                    if (dRetToal.Tables[0].Rows.Count > 0)
                    {
                        if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                        {
                            decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                            lblTotal.InnerText = total.ToString("f2");
                            Label1.InnerText = total.ToString("f2");
                        }
                    }
                    else
                    {
                        lblTotal.InnerText = "0.00";
                        Label1.InnerText = "0.00";
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

             if (sTableName == "CO1")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO2")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO3")
            {
                Label123 = "Shiva Delights";
            }
            else if (sTableName == "CO4")
            {
                Label123 = "Fig and honey";
            }
            else if (sTableName == "CO5")
            {
                Label123 = "Blaack Forest Bakery Services";
            }

            else if (sTableName == "CO6")
            {
                Label123 = "Maduravayol";
            }

            else if (sTableName == "CO6")
            {
                Label123 = "purasavakkam";
            }



             else if (sTableName == "CO8")
             {
                 Label123 = "Blaack Forest Bakery Services";
             }

             else if (sTableName == "CO9")
             {
                 Label123 = "Blaack Forest Bakery Services";
             }

             else if (sTableName == "CO10")
             {
                 Label123 = "Blaack Forest Bakery Services";
             }

             else if (sTableName == "CO11")
             {
                 Label123 = "Blaack Forest Bakery Services";
             }
             lblresult.Text = Label123 + " Stock  Return Report  Generated From  " + txtfromdate.Text + " To  " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");   //+ DateTime.Now.ToString();

             if (ddlreason.SelectedValue == "All")
            {
                if (sTableName == "admin")
                {
                    DataSet dRet = objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
                    if (dRet.Tables[0].Rows.Count > 0)
                    {
                        gvReturns.DataSource = dRet;
                        gvReturns.DataBind();
                        gvPrint.DataSource = dRet;
                        gvPrint.DataBind();
                    }

                    else
                    {
                        gvReturns.DataSource = null;
                        gvReturns.DataBind();
                        gvPrint.DataSource = null;
                        gvPrint.DataBind();
                    }
                    DataSet dRetToal = objbs.ReturnGridSearchTotal(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);

                    if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                        lblTotal.InnerText = total.ToString("f2");
                        Label1.InnerText = total.ToString("f2");
                    }

                    else
                    {
                        Label1.InnerText = "0.00";
                        lblTotal.InnerText = "0.00";
                    }
                }
                else
                {
                    DataSet dRet = objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                    if (dRet.Tables[0].Rows.Count > 0)
                    {
                        gvReturns.DataSource = dRet;
                        gvReturns.DataBind();
                        gvPrint.DataSource = dRet;
                        gvPrint.DataBind();
                    }

                    else
                    {
                        gvReturns.DataSource = null;
                        gvReturns.DataBind();
                        gvPrint.DataSource = null;
                        gvPrint.DataBind();
                    }
                    DataSet dRetToal = objbs.ReturnGridSearchTotal(sTableName, txtfromdate.Text, txttodate.Text);

                    if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                        lblTotal.InnerText = total.ToString("f2");
                        Label1.InnerText = total.ToString("f2");
                    }

                    else
                    {
                        Label1.InnerText = "0.00";
                        lblTotal.InnerText = "0.00";
                    }
                }
            }

            else
            {
                if (sTableName == "admin")
                {
                    DataSet dRet = objbs.ReturnGridSearchReason(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                    if (dRet.Tables[0].Rows.Count > 0)
                    {
                        gvReturns.DataSource = dRet;
                        gvReturns.DataBind();
                        gvPrint.DataSource = dRet;
                        gvPrint.DataBind();
                    }

                    else
                    {
                        gvReturns.DataSource = null;
                        gvReturns.DataBind();
                        gvPrint.DataSource = null;
                        gvPrint.DataBind();
                    }
                    DataSet dRetToal = objbs.ReturnGridSearchTotalReason(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));

                    if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                        lblTotal.InnerText = total.ToString("f2");
                        Label1.InnerText = total.ToString("f2");
                    }

                    else
                    {
                        lblTotal.InnerText = "0.00";
                        Label1.InnerText = "0.00";
                    }
                }
                else
                {
                    DataSet dRet = objbs.ReturnGridSearchReason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                    if (dRet.Tables[0].Rows.Count > 0)
                    {
                        gvReturns.DataSource = dRet;
                        gvReturns.DataBind();
                        gvPrint.DataSource = dRet;
                        gvPrint.DataBind();
                    }

                    else
                    {
                        gvReturns.DataSource = null;
                        gvReturns.DataBind();
                        gvPrint.DataSource = null;
                        gvPrint.DataBind();
                    }
                    DataSet dRetToal = objbs.ReturnGridSearchTotalReason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));

                    if (dRetToal.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        decimal total = Convert.ToDecimal(dRetToal.Tables[0].Rows[0]["Total"].ToString());
                        lblTotal.InnerText = total.ToString("f2");
                        Label1.InnerText = total.ToString("f2");
                    }

                    else
                    {
                        lblTotal.InnerText = "0.00";
                        Label1.InnerText = "0.00";
                    }
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Extra1.Visible = true;
            Extra2.Visible = true;
            try
            {
                string Branch = "";
                if (sTableName == "CO1")
                    Branch = "Kk nagar";
                else if (sTableName == "CO2")
                    Branch = "Byepass";
                else if (sTableName == "CO3")
                    Branch = "BB kulam";
                else if (sTableName == "CO4")
                    Branch = "Narayanapuram";
                else if (sTableName == "CO5")
                    Branch = "Palayankottal";
                else if (sTableName == "CO6")
                    Branch = "Maduravayol";
                else if (sTableName == "CO7")
                    Branch = "Purasavakkam";

                else if (sTableName == "CO8")
                    Branch = "Chennai pothys";

                else if (sTableName == "CO9")
                    Branch = "Thirunelveli";

                else if (sTableName == "CO10")
                    Branch = "Periyar";
                else if (sTableName == "CO11")
                    Branch = "Palayam";
               // gvReturns.Caption =Branch+" Returned Items "+ DateTime.Now.ToString();
                gvReturns.Caption = Branch + " Stock  Return Report  Generated From  " + txtfromdate.Text + " To  " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");   //+ DateTime.Now.ToString();

                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
            catch {
               
            }

           
        }

        protected void btnExp_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();
            if (sTableName == "admin")
            {
                gridview.DataSource = objbs.ReturnGridSearchReason(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                gridview.DataBind();
            }

            else
            {

                gridview.DataSource = objbs.ReturnGridSearchReason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                gridview.DataBind();
            }
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

        protected void btnExp_Click1(object sender, EventArgs e)
        {



            if (sTableName == "CO1")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO2")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO3")
            {
                Label123 = "Shiva Delights";
            }
            else if (sTableName == "CO4")
            {
                Label123 = "Fig and honey";
            }
            else if (sTableName == "CO5")
            {
                Label123 = "Blaack Forest Bakery Services";
            }

            else if (sTableName == "CO6")
            {
                Label123 = "Maduravayol";
            }

            else if (sTableName == "CO6")
            {
                Label123 = "purasavakkam";
            }


            else if (sTableName == "CO8")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO9")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO10")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO11")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            GridView gridview = new GridView();
            if (ddlreason.SelectedValue == "All")
            {
                if (sTableName == "admin")
                {
                    //updated 22/10/21
                    DataSet ds = objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ds.Tables[0].Rows[i]["DATEPART"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATEPART"]).ToString("dd/MMM/yyyy");
                            ds.Tables[0].Rows[i]["ReturnDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["ReturnDate"]).ToString("dd/MMM/yyyy");

                        }
                    }
                    gridview.DataSource = ds;// objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
                    gridview.DataBind();

                   // gridview.DataSource = objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
                  //  gridview.DataBind();
                    //end update
                }
                else
                {
                    //updated 22/10/21
                    DataSet ds = objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ds.Tables[0].Rows[i]["DATEPART"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATEPART"]).ToString("dd/MMM/yyyy");
                            ds.Tables[0].Rows[i]["ReturnDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["ReturnDate"]).ToString("dd/MMM/yyyy");

                        }
                    }

                    gridview.DataSource = ds;// objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                    gridview.DataBind();

                  //  gridview.DataSource = objbs.ReturnGridSearch(sTableName, txtfromdate.Text, txttodate.Text);
                   // gridview.DataBind();

                    //end update
                }
            }

            else
            {
                if (sTableName == "admin")
                {
                    gridview.DataSource = objbs.ReturnGridSearchReason(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                    gridview.DataBind();
                }
                else
                {
                    gridview.DataSource = objbs.ReturnGridSearchReason(sTableName, txtfromdate.Text, txttodate.Text, Convert.ToInt32(ddlreason.SelectedValue));
                    gridview.DataBind();
                }
            }
            gridview.Caption = Label123 + " Stock  Return Report  Generated From  " + txtfromdate.Text + " To  " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");   //+ DateTime.Now.ToString();
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
                DateTime date = Convert.ToDateTime(txttodate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var days = date.Day;
                var toda = Toady.Day;

                if ((toda - days) <= 2)
                {

                }

                else
                {
                    txttodate.Text = "";
                }
            }
        }
    }
}