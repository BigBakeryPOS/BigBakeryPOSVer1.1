using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class StockDeatailedReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sCode = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);

            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (sTableName != "admin")
            {
                admin.Visible = false;
            }
            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet dsCategory = objBs.selectcategorymasterforproductionentry();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    chkcategorylist.DataSource = dsCategory.Tables[0];
                    chkcategorylist.DataTextField = "category";
                    chkcategorylist.DataValueField = "categoryid";
                    chkcategorylist.DataBind();
                }

                txtFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cond1 = "";

            if (chkcategorylist.SelectedIndex >= 0)
            {
                foreach (ListItem listItem in chkcategorylist.Items)
                {
                    if (listItem.Text != "All")
                    {
                        if (listItem.Selected)
                        {
                            cond1 += " cu.Categoryid='" + listItem.Value + "' ,";
                        }
                    }
                }
                cond1 = cond1.TrimEnd(',');
                cond1 = cond1.Replace(",", "or");


                DataTable dt = objBs.dElobratedClosingStock(ddlBranch.SelectedValue, Convert.ToInt32(lblUserID.Text), txtFrom.Text, sCode, cond1, ddlstcktype.SelectedValue, ddlclosingstocktype.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    GVStockAlert.DataSource = dt;
                    GVStockAlert.DataBind();

                    for (int i = 0; i < GVStockAlert.Rows.Count; i++)
                    {
                        #region
                        if (ddldisplaytype.SelectedValue == "1")
                        {
                            Label lblopstockrate = (Label)GVStockAlert.Rows[i].FindControl("lblopstockrate");
                            Label lblgrnstockrate = (Label)GVStockAlert.Rows[i].FindControl("lblgrnstockrate");
                            Label lblgrnstockrateP = (Label)GVStockAlert.Rows[i].FindControl("lblgrnstockrateP");
                            Label lblgrnstockrateM = (Label)GVStockAlert.Rows[i].FindControl("lblgrnstockrateM");
                            Label lblsalestockrate = (Label)GVStockAlert.Rows[i].FindControl("lblsalestockrate");
                            Label lblreturnstockrate = (Label)GVStockAlert.Rows[i].FindControl("lblreturnstockrate");
                            Label lblavlstockrate = (Label)GVStockAlert.Rows[i].FindControl("lblavlstockrate");
                            Label lblstockratePM = (Label)GVStockAlert.Rows[i].FindControl("lblstockratePM");

                            lblopstockrate.Visible = false;
                            lblgrnstockrate.Visible = false;
                            lblgrnstockrateP.Visible = false;
                            lblgrnstockrateM.Visible = false;
                            lblsalestockrate.Visible = false;
                            lblreturnstockrate.Visible = false;
                            lblavlstockrate.Visible = false;
                            lblstockratePM.Visible = false;
                        }
                        else if (ddldisplaytype.SelectedValue == "2")
                        {
                            Label lblopstock = (Label)GVStockAlert.Rows[i].FindControl("lblopstock");
                            Label lblgrnstock = (Label)GVStockAlert.Rows[i].FindControl("lblgrnstock");
                            Label lblgrnstockP = (Label)GVStockAlert.Rows[i].FindControl("lblgrnstockP");
                            Label lblgrnstockM = (Label)GVStockAlert.Rows[i].FindControl("lblgrnstockM");
                            Label lblsalestock = (Label)GVStockAlert.Rows[i].FindControl("lblsalestock");
                            Label lblreturnstock = (Label)GVStockAlert.Rows[i].FindControl("lblreturnstock");
                            Label lblavlstock = (Label)GVStockAlert.Rows[i].FindControl("lblavlstock");
                            Label lblstockPM = (Label)GVStockAlert.Rows[i].FindControl("lblstockPM");

                            lblopstock.Visible = false;
                            lblgrnstock.Visible = false;
                            lblgrnstockP.Visible = false;
                            lblgrnstockM.Visible = false;
                            lblsalestock.Visible = false;
                            lblreturnstock.Visible = false;
                            lblavlstock.Visible = false;
                            lblstockPM.Visible = false;
                        }
                        #endregion
                    }
                }
                else
                {
                    GVStockAlert.DataSource = null;
                    GVStockAlert.DataBind();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Atleast One Category.Thank You!!!');", true);
                return;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            caption.InnerText = StoreName+ " "+ BranchNAme + " Stock Detailed Report from " + Convert.ToDateTime(txtFrom.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("dd/MM/yyyy");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= StockDeatailedReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            div2.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    }
}