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
    public partial class GRNReport : System.Web.UI.Page
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

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet dsCategory = objBs.selectcategorymaster();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select Category");
                }
                txtFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //DateTime.Now.AddDays(7)
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                Btn_Search(sender, e);
              
            }
        }

        protected void Btn_Search(object sender, EventArgs e)
        {
            

            caption.InnerText = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

         
        

                DataSet dStockReport = objBs.GRN(txtFrom.Text,txttodate.Text, sCode, Convert.ToInt32(lblUserID.Text));
                DataSet dSalesQty = objBs.DailySalesQty(sTableName, txttodate.Text, txtFrom.Text);
                string Caption = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");
                GVStockAlert.DataSource = Caption;
                GVStockAlert.DataSource = dStockReport.Tables[0];
                GVStockAlert.DataBind();

                lblprintcaptionn.Text = caption.ToString();
                
                GridView2.DataSource = dStockReport.Tables[0];
                GridView2.DataBind();

                gvsales.DataSource = dSalesQty.Tables[0];
                gvsales.DataBind();

                DataSet inter = objBs.InterbranchGRN(txttodate.Text, txtFrom.Text, sTableName);
                GridView1.DataSource = inter.Tables[0];
                GridView1.DataBind();
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue), sTableName);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                ddlSubCategory.DataSource = dsCategory.Tables[0];
                ddlSubCategory.DataTextField = "Definition";
                ddlSubCategory.DataValueField = "categoryuserid";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, "Select Description");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedItem.Text != "Select Description")
            {
                if (sTableName == "admin")
                {
                    caption.InnerText = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

                    
                    DataSet dStockReport = objBs.GRNSearch(txtFrom.Text, txttodate.Text, sCode, Convert.ToInt32(ddlBranch.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue));

                    DataSet dSalesQty = objBs.SalesQtysearch(sTableName, txtFrom.Text, Convert.ToInt32(ddlSubCategory.SelectedValue), txttodate.Text);
                    string Caption = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");
                    GVStockAlert.DataSource = Caption;
                    GVStockAlert.DataSource = dStockReport.Tables[0];
                    GVStockAlert.DataBind();

                    gvsales.DataSource = dSalesQty.Tables[0];
                    gvsales.DataBind();


                }
                else
                {
                    caption.InnerText = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

                    DataSet dStockReport = objBs.GRNSearch(txtFrom.Text,txttodate.Text, sCode, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(ddlSubCategory.SelectedValue));
                    DataSet dSalesQty = objBs.SalesQtysearch(sTableName, txtFrom.Text, Convert.ToInt32(ddlSubCategory.SelectedValue), txttodate.Text);
                    string Caption = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");
                    GVStockAlert.DataSource = Caption;
                    GVStockAlert.DataSource = dStockReport.Tables[0];
                    GVStockAlert.DataBind();

                    gvsales.DataSource = dSalesQty.Tables[0];
                    gvsales.DataBind();


                    DataSet inter = objBs.InterbranchGRNCat(txttodate.Text, txtFrom.Text, sTableName, Convert.ToInt32(ddlSubCategory.SelectedValue));
                    GridView1.DataSource = inter.Tables[0];
                    GridView1.DataBind();
                }
            }
            else
            {
                if (sTableName == "admin")

                {
                    caption.InnerText = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

                    
                    DataSet dStockReport = objBs.GRNSearchcategory(txtFrom.Text, txttodate.Text, sCode, Convert.ToInt32(ddlBranch.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue));

                    DataSet dSalesQty = objBs.SalesQtysearchcat(sTableName, txtFrom.Text, Convert.ToInt32(ddlcategory.SelectedValue), txttodate.Text);
                    string Caption = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");
                    GVStockAlert.DataSource = Caption;
                    GVStockAlert.DataSource = dStockReport.Tables[0];
                    GVStockAlert.DataBind();

                    gvsales.DataSource = dSalesQty.Tables[0];
                    gvsales.DataBind();


                }
                else
                {
                    caption.InnerText = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

                    DataSet dStockReport = objBs.GRNSearchcategory(txtFrom.Text, txttodate.Text, sCode, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(ddlcategory.SelectedValue));
                    DataSet dSalesQty = objBs.SalesQtysearchcat(sTableName, txtFrom.Text, Convert.ToInt32(ddlcategory.SelectedValue), txttodate.Text);
                    string Caption = "Store :  " + BranchNAme + " " + StoreName + "  Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");
                    GVStockAlert.DataSource = Caption;
                    GVStockAlert.DataSource = dStockReport.Tables[0];
                    GVStockAlert.DataBind();

                    gvsales.DataSource = dSalesQty.Tables[0];
                    gvsales.DataBind();


                    DataSet inter = objBs.InterbranchGRNCat(txttodate.Text, txtFrom.Text, sTableName, Convert.ToInt32(ddlcategory.SelectedValue));
                    GridView1.DataSource = inter.Tables[0];
                    GridView1.DataBind();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Branch = "";
            

            caption.InnerText = BranchNAme + " Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("dd/MM/yyyy");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }

        protected void PrintGRN_Search(object sender, EventArgs e)
        {
            string Branch = "";

            Table1.Visible = true;
            lblprintcaptionn.Text = BranchNAme + " Grn Report from " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("dd/MM/yyyy");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid1", "printGrid1();", true);
            //Table1.Visible = false;
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= GRNReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            div1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int grnno = Convert.ToInt32(e.CommandArgument.ToString());

            //DataSet ds = objBs.GRNGRO(grnno);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    gvDetails.DataSource = ds.Tables[0];
            //    gvDetails.DataBind();
            //}
        }

        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txttodate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
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