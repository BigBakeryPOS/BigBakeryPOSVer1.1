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
    public partial class Expensegroupreport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            if (!IsPostBack)
            {
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                txtfromdate.Text = firstDay.ToShortDateString();
                txttodate.Text = DateTime.Today.ToShortDateString();

                //DataSet dsbranch = objbs.selectbranchmaster();
                //if (dsbranch.Tables[0].Rows.Count > 0)
                //{
                //    ddlBranch.DataSource = dsbranch.Tables[0];
                //    ddlBranch.DataTextField = "BranchCode";
                //    ddlBranch.DataValueField = "UserID";
                //    ddlBranch.DataBind();
                //   // ddlBranch.Items.Insert(0, "Select Branch");
                //    //ddlcategory.Items.Insert(0, "Select Category");

                //}
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

               
                    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];
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

                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(sTableName, txtfromdate.Text, txttodate.Text);
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);

                        DataSet dcustbranch = objbs.expensegroupreport(brach, sFrom, sTo);
                      //  if (dcustbranch.Tables[0].Rows.Count > 0)
                       // {
                       //     Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                       // }

                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        //decimal dtotal = 0;
                        //for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                        //{
                        //    dtotal += Convert.ToDecimal(dcustbranch.Tables[0].Rows[i]["Netamount"]);
                        //}
                        //decimal Total = dtotal;
                        //lblTotal.InnerText = Total.ToString();
                        //tot = Convert.ToDouble(Total);
                        gvCustsales.DataBind();
                        decimal dtotal = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[2].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();
                        //  btnall_Click( sender, Even e)
                    }



                }
            }
        

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            //if (txtfromdate.Text > txttodate.Text)
            //{

            //}

            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];
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
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);

                DataSet dcustbranch = objbs.expensegroupreport(brach, sFrom, sTo);
                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{
                //    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                //}

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[2].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                // tot = Convert.ToDouble(Total);
            }
         
            //tot = Convert.ToDouble(Total);

            //DataSet dcustbranch = objbs.CustomerSalesBranch(ddlBranch.SelectedValue);
            //gvCustsales.DataSource = dcustbranch.Tables[0];
            //gvCustsales.DataBind();
        }

        protected void btnall_Click(object sender, EventArgs e)
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
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);

                DataSet dcustbranch = objbs.expensegroupreport(brach, sFrom, sTo);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {

                }

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();

                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[2].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                //tot = Convert.ToDouble(Total);



            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            DataSet dCustReport = objbs.CustomerSalesAdmin();
            gvCustsales.DataSource = dCustReport.Tables[0];
            gvCustsales.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();
            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            DateTime sTo = Convert.ToDateTime(txttodate.Text);

            DataSet dcustbranch = objbs.expensegroupreport(sTableName, sFrom, sTo);
            gridview.DataSource = dcustbranch.Tables[0];
            gridview.DataBind();
            gridview.Caption = "Expense Report For " + txtfromdate.Text + " To " + txttodate.Text;
          
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=ExpenseReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

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
                DataSet ds = objbs.expensegroupreport(sTableName, sFrom, sTo);
                gvCustsales.PageIndex = e.NewPageIndex;

                gvCustsales.DataSource = ds.Tables[0];
                gvCustsales.DataBind();
            }
            decimal dtotal = 0;
            for (int i = 0; i < gvCustsales.Rows.Count; i++)
            {
                dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[0].Text);
            }
            decimal Total = dtotal;
            lblTotal.InnerText = Total.ToString();
            //  tot = Convert.ToDouble(Total);





        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
            if (sadmin == "1")
            {

            }
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            string name = string.Empty;



            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];


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
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objbs.expensegroupdetailedreport(groupID, brach, sFrom, sTo);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                     //   double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]);
                     //   amount1 = amount1 + amount;
                        gv.DataBind();
                    }
                    //}
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
              //  e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
               // e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

             //   e.Row.Cells[0].Text = "Total";
                //e.Row.Cells[1].Text = HorizontalAlign.Right;
              //  e.Row.Cells[2].Text = amount1.ToString("N2");
                //  e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

            }

        }
    }
}