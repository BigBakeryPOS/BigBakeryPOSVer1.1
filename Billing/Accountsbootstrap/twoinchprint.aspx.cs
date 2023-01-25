using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using DataLayer;
using System.Xml.Linq;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;

namespace Billing.Accountsbootstrap
{
    public partial class twoinchprint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string StoreNo = "";
        double damt = 0;
        string Printtype = "N";
        string fssaino = "Nil";

        string Country = "Nil";

        string currency = "";
        string taxsplitupsetting = "";
        string taxsetting = "";
        string BillPrintLogo = "";
        string ratesetting = "";
        string qtysetting = "";
        string BillGenerateSetting = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.QueryString.Get("User").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sStore = Request.QueryString.Get("Store").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sAddress = Request.QueryString.Get("Address").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            StoreNo = Request.QueryString.Get("StoreNo").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sTin = Request.QueryString.Get("TIN").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");

            DataSet fillbranchdetails = objBs.getbranchcode(sTableName);
            if (fillbranchdetails.Tables[0].Rows.Count > 0)
            {

                fssaino = fillbranchdetails.Tables[0].Rows[0]["Fssaino"].ToString();
                Printtype = fillbranchdetails.Tables[0].Rows[0]["Printtype"].ToString();
                Country = fillbranchdetails.Tables[0].Rows[0]["Country"].ToString();
                currency = fillbranchdetails.Tables[0].Rows[0]["currency"].ToString();
                taxsetting = fillbranchdetails.Tables[0].Rows[0]["TaxSetting"].ToString();
                taxsplitupsetting = fillbranchdetails.Tables[0].Rows[0]["Billtaxsplitupshown"].ToString();
                BillPrintLogo = fillbranchdetails.Tables[0].Rows[0]["BillPrintLogo"].ToString();
                ratesetting = fillbranchdetails.Tables[0].Rows[0]["Ratesetting"].ToString();
                qtysetting = fillbranchdetails.Tables[0].Rows[0]["Qtysetting"].ToString();
                BillGenerateSetting = fillbranchdetails.Tables[0].Rows[0]["BillGenerateSetting"].ToString();
                fssaino = fillbranchdetails.Tables[0].Rows[0]["Fssaino"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Something Went Wrong in Branch MAster.Thank You!!!');", true);
                return;
            }

            lblstore.Text = sStore;
            lblstoreno.Text = StoreNo;

            lblAddres.Text = sAddress;
            lbltin.Text = sTin;
            lblfssaino.Text = fssaino.ToString();

            int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
            string type = (Request.QueryString.Get("Type")).ToString();
            int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string sMode = Request.QueryString.Get("Mode");

            if (iD > 0)
            {
                DataSet ds = new DataSet();

                ds = objBs.PrintingSales(iD, sTableName, sMode, type.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                    lblbilldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                    string saletypeid = ds.Tables[0].Rows[0]["salestype"].ToString();
                    if (saletypeid == "3" || saletypeid == "4")
                    {
                        tblgrand.Visible = false;
                    }
                    else
                    {
                        tblgrand.Visible = true;
                        lblGrand.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");
                    }

                    lblsalestype.Text = ds.Tables[0].Rows[0]["paymenttype"].ToString();

                    string isnormel = ds.Tables[0].Rows[0]["isnormal"].ToString();

                    if (isnormel == "Y")
                    {
                        lblbillname.Text = "Bill No";
                        lblorderno.Visible = false;
                    }
                    else
                    {
                        lblbillname.Text = "Kot No";
                        lblorderno.Visible = true;
                        lblorderno.Text = ds.Tables[0].Rows[0]["SalesOrder"].ToString();

                    }
                }

                
                //if (saletypeid == "3" || saletypeid == "4")
                //{
                //}

                    DataSet Itembinding = objBs.PrintingSalesNew_twoinchprint(iD, sTableName, sMode, type.ToString());
                if (Itembinding.Tables[0].Rows.Count > 0)
                {


                    //Populating a DataTable from database.
                    DataTable dt = Itembinding.Tables[0];

                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                    //Table start.
                    html.Append("<table border = '1'>");

                    html.Append("<thead>");
                    //Building the Header row.
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");
                    html.Append("</thead>");

                    //Building the Data rows.
                    foreach (DataRow row in dt.Rows)
                    {
                        html.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            html.Append("<td>");
                            html.Append(row[column.ColumnName]);
                            html.Append("</td>");
                        }
                        html.Append("</tr>");
                    }

                    //Table end.
                    html.Append("</table>");

                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                }

            }

        }
    }
}