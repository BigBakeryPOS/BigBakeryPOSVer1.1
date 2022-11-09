using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class customerKotReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string Password = "";
        string BranchNAme = "";
        string StoreName = "";

        double GTax = 0;
        double GNetAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);
            Label123.Text = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Session["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Session["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString() ;
                txtfromdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Today.ToString("yyyy-MM-dd");


                if (sadmin == "1")
                {
                    ddlBranch.Enabled = true;
                    DataSet dsbranchto = objbs.Branchto();
                    ddlBranch.DataSource = dsbranchto.Tables[0];
                    ddlBranch.DataTextField = "branchcode";
                    ddlBranch.DataValueField = "Userid";
                    ddlBranch.DataBind();
                    //  ddlBranch.Items.Insert(0, "All");
                }
                else
                {
                    DataSet dsbranch = new DataSet();
                    string stable = "tblSales_" + sTableName + "";
                    dsbranch = objbs.Branchfrom(lblUserID.Text);
                    ddlBranch.DataSource = dsbranch.Tables[0];
                    ddlBranch.DataTextField = "branchcode";
                    ddlBranch.DataValueField = "Userid";
                    ddlBranch.DataBind();
                    ddlBranch.Enabled = false;
                }

                if (sTableName == "admin")
                {
                    ddlBranch.Enabled = true;
                    txtfromdate.Enabled = true;
                    txttodate.Enabled = true;
                }
                else
                {
                    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];

                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);

                        DataSet dcustbranch = objbs.customerkotreport(brach, sFrom, sTo);
                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {

                            gvCustsales.DataSource = dcustbranch.Tables[0];
                            gvCustsales.DataBind();

                            Label123.Text = Convert.ToString(dsbranch1.Tables[0].Rows[0]["Place"]);
                        }
                        else
                        {
                            gvCustsales.DataSource = null;
                            gvCustsales.DataBind();
                        }

                        decimal dtotal = 0;
                        decimal ddiscamnt = 0;
                        decimal dtotalamt = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[2].Text);
                            ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[3].Text);
                            dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[4].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();

                        decimal dtotalamntt = ddiscamnt;
                        disc.InnerText = dtotalamntt.ToString();

                        decimal gndtot = dtotalamt;
                        gndtotal.InnerText = string.Format("{0:N2}", gndtot);
                    }
                }

                lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales KOt Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

            }
        }
        protected void btnall_Click(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);


            {

                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drptype.SelectedValue;

                    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales KOt Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = objbs.customerkotreport(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                    }

                    decimal dtotal = 0;
                    decimal ddiscamnt = 0;
                    decimal dtotalamt = 0;
                    for (int i = 0; i < gvCustsales.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[2].Text);
                        ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[3].Text);
                        dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[4].Text);
                    }

                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();

                    decimal dtotalamntt = ddiscamnt;
                    disc.InnerText = dtotalamntt.ToString();

                    decimal gndtot = dtotalamt;
                    gndtotal.InnerText = string.Format("{0:N2}", gndtot);

                }


            }


        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            GridView gridview = new GridView();
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            string name = string.Empty;

            gridview.Caption = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales KOt Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");

            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];



            }
            if (sTableName == "admin")
            {
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drptype.SelectedValue;
                dt = objbs.customerkotreport(brach, sFrom, sTo);
                gridview.DataSource = dt;
                gridview.DataBind();
            }

            else
            {
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drptype.SelectedValue;
                dt = objbs.customerkotreport(brach, sFrom, sTo);
                gridview.DataSource = dt;
                gridview.DataBind();
            }

            string filename = "kotsalesreport.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.Caption = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales KOt Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            dgGrid.HeaderStyle.Font.Bold = true;
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            string name = string.Empty;

            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double Tax = 0;
                double NetAmount = 0;

                Tax = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GTax = GTax + Tax;
                GNetAmount = GNetAmount + NetAmount;

                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objbs.customerkotreportdetails(groupID, brach);
                   
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
                        amount1 = amount1 + amount;
                        gv.DataBind();


                    }
                    
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;


                decimal dtotal = 0;
                decimal ddiscamnt = 0;
                decimal dtotalamt = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[2].Text);
                    ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[3].Text);
                    dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[4].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();

                decimal dtotalamntt = ddiscamnt;
                disc.InnerText = dtotalamntt.ToString();

                decimal gndtot = dtotalamt;
                gndtotal.InnerText = string.Format("{0:N2}", gndtot);


                //gndtotal.InnerText = ((GTax + GNetAmount) - Convert.ToDouble(dtotalamntt)).ToString("f2");

                //double finaltot = 0;
                //double roundoff1 = Convert.ToDouble(gndtotal.InnerText) - Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                //if (roundoff1 >= 0.5)
                //{
                //    finaltot = Math.Round(Convert.ToDouble(gndtotal.InnerText), MidpointRounding.AwayFromZero);
                //}
                //else
                //{
                //    finaltot = Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                //}

               
            }

        }

        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {

            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txtfromdate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;

                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txtfromdate.Text = "";
                }
            }
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);


            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drptype.SelectedValue;

                DataSet dcustbranch = objbs.CustomerHoldSalesBranchpaymode(brach, sFrom, sTo, paymode);
                // DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                }

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();

                decimal dtotal = 0;
                decimal ddiscamnt = 0;
                decimal dtotalamt = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[4].Text);
                    ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[5].Text);
                    dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                decimal dtotalamntt = ddiscamnt;
                disc.InnerText = dtotalamntt.ToString();
                decimal gndtot = dtotalamt;
                gndtotal.InnerText = gndtot.ToString();
                //  btnall_Click( sender, Even e)
                double finaltot = 0;
                double roundoff1 = Convert.ToDouble(gndtotal.InnerText) - Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                if (roundoff1 >= 0.5)
                {
                    finaltot = Math.Round(Convert.ToDouble(gndtotal.InnerText), MidpointRounding.AwayFromZero);
                }
                else
                {
                    finaltot = Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                }

                gndtotal.InnerText = string.Format("{0:N2}", finaltot);
                // tot = Convert.ToDouble(Total);
            }

        }

       

        protected void btnViewAll_Click(object sender, EventArgs e)
        {

        }

      

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];
                string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO7")
                {
                    Label123.Text = "Purasavakkam";
                }
                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                if (sTableName == "admin")
                {
                    DataSet dCustReport = objbs.CustomerSalesAdmin();
                    gvCustsales.PageIndex = e.NewPageIndex;
                    gvCustsales.DataSource = dCustReport.Tables[0];
                    gvCustsales.DataBind();
                }
                else
                {
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drptype.SelectedValue;

                    DataSet ds = objbs.CustomerHoldSalesBranchpaymode(brach, sFrom, sTo, paymode);
                    //   DataSet ds = objbs.CustomerSalesBranch(sTableName, sFrom, sTo);
                    gvCustsales.PageIndex = e.NewPageIndex;

                    gvCustsales.DataSource = ds.Tables[0];
                    gvCustsales.DataBind();
                }

                decimal dtotal = 0;
                decimal ddiscamnt = 0;
                decimal dtotalamt = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
                    dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                decimal dtotalamntt = ddiscamnt;
                disc.InnerText = dtotalamntt.ToString();
                decimal gndtot = dtotalamt;
                gndtotal.InnerText = gndtot.ToString();

            }


        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];
                string name = string.Empty;


                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drptype.SelectedValue;

                DataSet dcustbranch = objbs.CustomerHoldSalesBranchpaymode(brach, sFrom, sTo, paymode);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {

                }

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();


                decimal dtotal = 0;
                decimal ddiscamnt = 0;
                decimal dtotalamt = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
                    dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                decimal dtotalamntt = ddiscamnt;
                disc.InnerText = dtotalamntt.ToString();
                decimal gndtot = dtotalamt;
                gndtotal.InnerText = gndtot.ToString();
                //  btnall_Click( sender, Even e)

                //tot = Convert.ToDouble(Total);



            }
        }

       

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {

            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {


            lblCaption.Text = "Store :" + BranchNAme + " Customer Sales Hold/Kot Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }
    }
}