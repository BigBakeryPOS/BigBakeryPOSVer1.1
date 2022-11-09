using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Web.UI.HtmlControls;

namespace Billing.Accountsbootstrap
{
    public partial class StockReportsforBoth : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string FirstEntry = "";
        string Label123 = "";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

           
            if (!IsPostBack)
            {

                txtfrmdate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
                     DataSet dsCategory = objBs.selectcategorymaster();
                     if (dsCategory.Tables[0].Rows.Count > 0)
                     {
                         ddlcat.DataSource = dsCategory.Tables[0];
                         ddlcat.DataTextField = "category";
                         ddlcat.DataValueField = "categoryid";
                         ddlcat.DataBind();
                         ddlcat.Items.Insert(0, "All");

                     }

                     gvgrnmp.DataSource = null;
                     gvgrnmp.DataBind();
                     gvreturn.DataSource = null;
                     gvreturn.DataBind();


            }
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
                DateTime date = Convert.ToDateTime(txtfrmdate.Text);
                DateTime Toady =  Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

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
                    txtfrmdate.Text = "";
                }
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {

           // if (ddlcat.SelectedValue != "Select Category")
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

                else if (sTableName == "CO7")
                {
                    Label123 = "purasavakkam";
                }

                else if (sTableName == "CO8")
                {
                    Label123 = "Chennai Pothys";
                }


                else if (sTableName == "CO9")
                {
                    Label123 = "Thirunelveli";
                }


                else if (sTableName == "CO10")
                {
                    Label123 = "Periyar";
                }

                else if (sTableName == "CO11")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }

                lblstkreturn.Text = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");


                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();

                ds = objBs.selectgrnmp111(ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvgrnmp.DataSource = ds;
                    gvgrnmp.DataBind();
                }
                else
                {
                    gvgrnmp.DataSource = null;
                    gvgrnmp.DataBind();
                }

                ds1 = objBs.selectret111(sTableName,ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    gvreturn.DataSource = ds1;
                    gvreturn.DataBind();
                }
                else
                {
                    gvreturn.DataSource = null;
                    gvreturn.DataBind();
                }
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Category')", true);
                
            //    return;
            //}
        }


        protected void btnexcel_Click(object sender, EventArgs e)
        {
            HtmlForm form = new HtmlForm();
            Response.Clear();
            Response.Buffer = true;

            string filename = "Stock Return and GRN(+)(-)_" + DateTime.Now.ToString() + ".xls";


            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            DataSet dstd1 = new DataSet();
            DataSet dstd2 = new DataSet();

            ds = objBs.selectgrnmp111(ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvgrnmp.DataSource = ds;
                gvgrnmp.DataBind();


                    DataTable dttt;
                    DataRow drNew;
                    DataColumn dct;
                    
                    dttt = new DataTable();


                    dct = new DataColumn("Date");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Category");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Product");
                    dttt.Columns.Add(dct);


                    dct = new DataColumn("Quantity");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("TotalAmount");
                    dttt.Columns.Add(dct);

                    
                    dstd1.Tables.Add(dttt);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        drNew = dttt.NewRow();

                        drNew["Date"] = dr["Date"];
                        drNew["Category"] = dr["Category"];
                        drNew["Product"] = dr["Definition"];
                        drNew["Quantity"] = dr["GRN_Qty"];
                        drNew["TotalAmount"] = dr["TotalAmount"];
                       
                        dstd1.Tables[0].Rows.Add(drNew);
                    }

                   // ExportToExcel(filename, dstd1, dstd2);
                
            }
            else
            {
                gvgrnmp.DataSource = null;
                gvgrnmp.DataBind();
            }

            ds1 = objBs.selectret111(sTableName, ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                gvreturn.DataSource = ds1;
                gvreturn.DataBind();



                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
               
                dttt = new DataTable();


                dct = new DataColumn("Date");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Category");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Product");
                dttt.Columns.Add(dct);


                dct = new DataColumn("Quantity");
                dttt.Columns.Add(dct);

                dct = new DataColumn("TotalAmount");
                dttt.Columns.Add(dct);


                dstd2.Tables.Add(dttt);

                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    drNew = dttt.NewRow();

                    drNew["Date"] = dr["RetDate"];
                    drNew["Category"] = dr["Category"];
                    drNew["Product"] = dr["Definition"];
                    drNew["Quantity"] = dr["Quantity"];
                    drNew["TotalAmount"] = dr["TotalAmount"];

                    dstd2.Tables[0].Rows.Add(drNew);
                }

               // ExportToExcel(filename, dstd1, dstd2);
            }
            else
            {
                gvreturn.DataSource = null;
                gvreturn.DataBind();
            }


            ExportToExcel(filename, dstd1, dstd2);
        }

        private void ExportToExcel(string filename, DataSet dt, DataSet dt1)
        {
            //	throw new NotImplementedException();

         //   if (dt.Tables[0].Rows.Count > 0)
            {

                DataGrid dgGridCaption = new DataGrid();
                dgGridCaption.Caption = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                dgGridCaption.DataBind();

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                dgGridCaption.RenderControl(hw);


                GridViewRow gv2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell2 = new TableHeaderCell();
                cell2.Text = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                cell2.Height = 300;
                cell2.Width = 10000;
                gv2.Controls.Add(cell2);
                gv2.RenderControl(hw);

                dgGridCaption.RenderControl(hw);

                if (dt.Tables.Count > 0)
                {
                    if (dt != null)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            DataGrid dgGrid = new DataGrid();
                            dgGrid.DataSource = dt;
                            dgGrid.DataBind();
                            dgGrid.Caption = "GRN (+)(-)";
                            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                            dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                            dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                            dgGrid.FooterStyle.ForeColor = System.Drawing.Color.Red;
                            dgGrid.HeaderStyle.Font.Bold = true;
                            //Get the HTML for the control.
                            dgGrid.RenderControl(hw);
                        }
                    }
                }

                if (dt1.Tables.Count > 0)
                {
                    if (dt1 != null)
                    {
                        if (dt1.Tables[0].Rows.Count > 0)
                        {
                            DataGrid dgGrid1 = new DataGrid();
                            dgGrid1.DataSource = dt1;
                            dgGrid1.Caption = "Stock Return"; 
                            dgGrid1.DataBind();
                            dgGrid1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                            dgGrid1.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                            dgGrid1.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                            dgGrid1.FooterStyle.ForeColor = System.Drawing.Color.Red;
                            dgGrid1.HeaderStyle.Font.Bold = true;
                            //Get the HTML for the control.
                            dgGrid1.RenderControl(hw);
                        }
                    }
                }
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }
    }
}
