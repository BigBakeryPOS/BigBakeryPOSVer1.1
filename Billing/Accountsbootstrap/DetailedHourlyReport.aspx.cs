using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BusinessLayer;
using System.IO;
using System.Security.Cryptography;

namespace Billing.Accountsbootstrap
{
    public partial class DetailedHourlyReport : System.Web.UI.Page
    {
        string sTablename = string.Empty;
        BSClass Objbs = new BSClass();
        bool value;
        string AllBranchAccess = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTablename = Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            //if (sTablename == "admin")
            //{
            //    txtFrom.Enabled = true;
            //    txtTo.Enabled = true;
            //}

            //else
            //{
            //    admin.Visible = false;
            //}
            if (!IsPostBack)
            {

                txtFrom.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txtTo.Text = DateTime.Today.ToString("yyyy-MM-dd");
                
                txtFrom.Enabled = true;
                txtTo.Enabled = true;

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = Objbs.GetBranch_New("All");
                else
                    dsbranch = Objbs.GetBranch_New(sTablename);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "Select Branch");
                else
                    ddlBranch.Enabled = false;
              
            }
           
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (sTablename == "admin")
            //{
            //   if (radiomode.SelectedValue == "Every Hour")
            //        value = true;
            //    else
            //        value = false;
            //    DataSet das = Objbs.getTime(value);
            //    //gvReport.DataSource = das;
            //    //gvReport.DataBind();
            //    string sdate = "";
            //    DataTable dat = new DataTable();
            //    dat.Columns.Add("Time");
            //    //dat.Columns.Add(sdate);
            //    DataRow dr, dr1;
            //    DataSet ds = Objbs.allDate(txtFrom.Text, txtTo.Text);
            //    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            //    {
            //        DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[z]["Dates"].ToString());
            //        sdate = date.ToString("yyyy-MM-dd");
            //        // dr1 = dat.NewRow();
            //        dat.Columns.Add(date.ToString("dd/MM/yy"));
            //    }

            //    for (int x = 0; x < das.Tables[0].Rows.Count; x++)
            //    {
            //        string times = das.Tables[0].Rows[x]["Time"].ToString();

            //        string[] split = times.Split('-');

            //        string from = split[0];
            //        string To = split[1];

            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            dr = dat.NewRow();
            //            dr["Time"] = das.Tables[0].Rows[x]["Time"].ToString();
            //            //dat.Columns.Add("Date");


            //            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            //            {
            //                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[j]["Dates"].ToString());
            //                sdate = date.ToString("yyyy-MM-dd");
            //                //  dat.Columns.Add(sdate);
            //                //  dat.Columns.Add(sdate);


            //                DataSet dx = Objbs.getAmt(from, To, sdate, ddlBranch.SelectedValue);
            //                if (dx.Tables[0].Rows[0]["Total"].ToString() != "")
            //                {
            //                    decimal dAmt = Convert.ToDecimal(dx.Tables[0].Rows[0]["Total"].ToString());

            //                    dr[date.ToString("dd/MM/yy")] = dAmt.ToString("f2");
            //                    // gvReport.Rows[count].Cells[1].Text=gvReport.Rows[count].Cells[1].Text.Replace(dAmt.ToString("f2"), "");
            //                }

            //                else
            //                {
            //                    dr[date.ToString("dd/MM/yy")] = "0.00";
            //                    // gvReport.Rows[count].Cells[1].Text = gvReport.Rows[count].Cells[1].Text.Replace("0.00", "");
            //                }


            //            }
            //            dat.Rows.Add(dr);
            //        }
            //    }


            //    gvReport.DataSource = dat;
            //    gvReport.DataBind();
            //}
                    
            
            //else
            {
                if (radiomode.SelectedValue == "Every Hour")
                    value = true;
                else
                    value = false;
                DataSet das = Objbs.getTime(value);
                //gvReport.DataSource = das;
                //gvReport.DataBind();
                string sdate = "";
                DataTable dat = new DataTable();
                dat.Columns.Add("Time");
                //dat.Columns.Add(sdate);
                DataRow dr, dr1;
                DataSet ds = Objbs.allDate(txtFrom.Text, txtTo.Text);
                for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
                {
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[z]["Dates"].ToString());
                    sdate = date.ToString("yyyy-MM-dd");
                    // dr1 = dat.NewRow();
                    dat.Columns.Add(date.ToString("dd/MM/yy"));
                }

                for (int x = 0; x < das.Tables[0].Rows.Count; x++)
                {
                    string times = das.Tables[0].Rows[x]["Time"].ToString();

                    string[] split = times.Split('-');

                    string from = split[0];
                    string To = split[1];

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dr = dat.NewRow();
                        dr["Time"] = das.Tables[0].Rows[x]["Time"].ToString();
                        //dat.Columns.Add("Date");


                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[j]["Dates"].ToString());
                            sdate = date.ToString("yyyy-MM-dd");
                            //  dat.Columns.Add(sdate);
                            //  dat.Columns.Add(sdate);


                            DataSet dx = Objbs.getAmt(from, To, sdate, ddlBranch.SelectedValue);
                            if (dx.Tables[0].Rows[0]["Total"].ToString() != "")
                            {
                                decimal dAmt = Convert.ToDecimal(dx.Tables[0].Rows[0]["Total"].ToString());

                                dr[date.ToString("dd/MM/yy")] = dAmt.ToString("f2");
                                // gvReport.Rows[count].Cells[1].Text=gvReport.Rows[count].Cells[1].Text.Replace(dAmt.ToString("f2"), "");
                            }

                            else
                            {
                                dr[date.ToString("dd/MM/yy")] = "0.00";
                                // gvReport.Rows[count].Cells[1].Text = gvReport.Rows[count].Cells[1].Text.Replace("0.00", "");
                            }


                        }
                        dat.Rows.Add(dr);
                    }
                }


                gvReport.DataSource = dat;
                gvReport.DataBind();
                gvReport.Caption = ddlBranch.SelectedItem.Text + " " + radiomode.SelectedItem.Text + " Sales Detailed Report from " + txtFrom.Text + " to " + txtTo.Text;
            }
            }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();
            //if (sTablename == "admin")
            //{
            //    if (radiomode.SelectedValue == "Every Hour")
            //        value = true;
            //    else
            //        value = false;
            //    DataSet das = Objbs.getTime(value);
            //    //gvReport.DataSource = das;
            //    //gvReport.DataBind();
            //    string sdate = "";
            //    DataTable dat = new DataTable();
            //    dat.Columns.Add("Time");
            //    //dat.Columns.Add(sdate);
            //    DataRow dr, dr1;
            //    DataSet ds = Objbs.allDate(txtFrom.Text, txtTo.Text);
            //    for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            //    {
            //        DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[z]["Dates"].ToString());
            //        sdate = date.ToString("yyyy-MM-dd");
            //        // dr1 = dat.NewRow();
            //        dat.Columns.Add(date.ToString("dd/MM/yy"));
            //    }

            //    for (int x = 0; x < das.Tables[0].Rows.Count; x++)
            //    {
            //        string times = das.Tables[0].Rows[x]["Time"].ToString();

            //        string[] split = times.Split('-');

            //        string from = split[0];
            //        string To = split[1];

            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            dr = dat.NewRow();
            //            dr["Time"] = das.Tables[0].Rows[x]["Time"].ToString();
            //            //dat.Columns.Add("Date");


            //            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            //            {
            //                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[j]["Dates"].ToString());
            //                sdate = date.ToString("yyyy-MM-dd");
            //                //  dat.Columns.Add(sdate);
            //                //  dat.Columns.Add(sdate);


            //                DataSet dx = Objbs.getAmt(from, To, sdate, ddlBranch.SelectedValue);
            //                if (dx.Tables[0].Rows[0]["Total"].ToString() != "")
            //                {
            //                    decimal dAmt = Convert.ToDecimal(dx.Tables[0].Rows[0]["Total"].ToString());

            //                    dr[date.ToString("dd/MM/yy")] = dAmt.ToString("f2");
            //                    // gvReport.Rows[count].Cells[1].Text=gvReport.Rows[count].Cells[1].Text.Replace(dAmt.ToString("f2"), "");
            //                }

            //                else
            //                {
            //                    dr[date.ToString("dd/MM/yy")] = "0.00";
            //                    // gvReport.Rows[count].Cells[1].Text = gvReport.Rows[count].Cells[1].Text.Replace("0.00", "");
            //                }


            //            }
            //            dat.Rows.Add(dr);
            //        }
            //    }
            //    gridview.DataSource = dat;
            //    gridview.DataBind();
            //}

            //else
            {
                if (radiomode.SelectedValue == "Every Hour")
                    value = true;
                else
                    value = false;
                DataSet das = Objbs.getTime(value);
                //gvReport.DataSource = das;
                //gvReport.DataBind();
                string sdate = "";
                DataTable dat = new DataTable();
                dat.Columns.Add("Time");
                //dat.Columns.Add(sdate);
                DataRow dr, dr1;
                DataSet ds = Objbs.allDate(txtFrom.Text, txtTo.Text);
                for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
                {
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[z]["Dates"].ToString());
                    sdate = date.ToString("yyyy-MM-dd");
                    // dr1 = dat.NewRow();
                    dat.Columns.Add(date.ToString("dd/MM/yy"));
                }

                for (int x = 0; x < das.Tables[0].Rows.Count; x++)
                {
                    string times = das.Tables[0].Rows[x]["Time"].ToString();

                    string[] split = times.Split('-');

                    string from = split[0];
                    string To = split[1];

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dr = dat.NewRow();
                        dr["Time"] = das.Tables[0].Rows[x]["Time"].ToString();
                        //dat.Columns.Add("Date");


                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[j]["Dates"].ToString());
                            sdate = date.ToString("yyyy-MM-dd");
                            //  dat.Columns.Add(sdate);
                            //  dat.Columns.Add(sdate);


                            DataSet dx = Objbs.getAmt(from, To, sdate, ddlBranch.SelectedValue);
                            if (dx.Tables[0].Rows[0]["Total"].ToString() != "")
                            {
                                decimal dAmt = Convert.ToDecimal(dx.Tables[0].Rows[0]["Total"].ToString());

                                dr[date.ToString("dd/MM/yy")] = dAmt.ToString("f2");
                                // gvReport.Rows[count].Cells[1].Text=gvReport.Rows[count].Cells[1].Text.Replace(dAmt.ToString("f2"), "");
                            }

                            else
                            {
                                dr[date.ToString("dd/MM/yy")] = "0.00";
                                // gvReport.Rows[count].Cells[1].Text = gvReport.Rows[count].Cells[1].Text.Replace("0.00", "");
                            }


                        }
                        dat.Rows.Add(dr);
                    }
                }

                gridview.DataSource = dat;
                gridview.DataBind();
                gridview.Caption = ddlBranch.SelectedItem.Text + " " + radiomode.SelectedItem.Text + " Sales Detailed Report from " + txtFrom.Text + " to " + txtTo.Text;
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
        }
    }
