using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Diagnostics;

namespace Billing.Accountsbootstrap
{
    public partial class RestaurantSalesKot : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {
                //DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                //gvsales.DataSource = ds;
                //gvsales.DataBind();



                DataSet gettablename = objBs.selecttablemaster();
                datkot.DataSource = gettablename;
                datkot.DataBind();

                DataSet getdlTableName = objBs.selectTname(Convert.ToInt32(lblUserID.Text), sTableName);
                foreach (DataListItem li in datkot.Items)
                {
                    Button txt = (Button)li.FindControl("Button2");

                    foreach (DataRow dr in getdlTableName.Tables[0].Rows)
                    {
                        if (dr["Tableno"].ToString().Trim() == txt.Text)
                        {
                            txt.BackColor = System.Drawing.Color.Green;
                        }
                    }
                }




            }
        }

        protected void btlprintClear(object sender, EventArgs e)
        {
            int isucess = objBs.salescancelprint(sTableName);
            Response.Redirect("RestaurantSalesKot.aspx");

        }
        protected void KotBIll(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1all.Rows.Count; i++)
            {
                double qty = 0;
                string kotno = GridView1all.Rows[i].Cells[0].Text;
                string Qty = GridView1all.Rows[i].Cells[3].Text;
                Label categoryuser = (Label)GridView1all.Rows[i].FindControl("lblcategoryuserid");
                Label kotid = (Label)GridView1all.Rows[i].FindControl("lblkotid");
                Label lblAQty = (Label)GridView1all.Rows[i].FindControl("lblAQty");
                CheckBox checkboxx = (CheckBox)GridView1all.Rows[i].FindControl("chkcancell");
                qty = Convert.ToDouble(lblAQty.Text) - Convert.ToDouble(Qty);

                if (qty > 0)
                {

                    if (checkboxx.Checked == true)
                    {

                        int iscess = objBs.updatenewkotcancel(kotid.Text, kotno, sTableName, qty.ToString(), "2", categoryuser.Text, Qty);
                    }
                    else
                    {
                        int iscess = objBs.updatenewkotcancel(kotid.Text, kotno, sTableName, qty.ToString(), "0", categoryuser.Text, Qty);
                    }


                }

            }
            Response.Redirect("RestaurantSalesKot.aspx");
        }


        protected void GridView1all_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = GridView1all.Rows[index];
            dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];
            string kotno = GridView1all.Rows[index].Cells[0].Text;
            Label categoryuser = (Label)GridView1all.Rows[index].FindControl("lblcategoryuserid");
            CheckBox checkboxx = (CheckBox)GridView1all.Rows[index].FindControl("chkcancell");
            if (e.CommandName == "minus")
            {
                foreach (DataRow dr in dtt.Rows)
                {
                    if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text && dr["Kotno"].ToString().Trim() == kotno)
                    {
                        int qty = Convert.ToInt32(dr["Qty"].ToString());


                        decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                        decimal amt = 0;
                        int final = qty - 1;
                        bool negative = final < 0;
                        if (negative == true)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Qty Exceed.Not Allow To Minus Value');", true);
                            break;
                        }

                        dr["Qty"] = final.ToString();

                        amt = final * rate;
                        dr["Amount"] = amt.ToString("f2");
                        if (dr["Qty"].ToString() == "0")
                        {
                            // dtt.Rows.Remove(dr);
                            checkboxx.Checked = true;
                            dr["check"] = checkboxx.Checked;
                            // dr["check"] = true;
                        }


                        ViewState["dt"] = dt;

                        ViewState["Newdt"] = dtt;

                        break;
                    }
                }


                // Total();

            }



            GridView1all.DataSource = dtt;
            GridView1all.DataBind();

        }

        protected void dlst_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (radtypestatus.SelectedValue == "1")
            {

            }
            else
            {

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button Button = sender as Button;
            if (radtypestatus.SelectedValue == "1")
            {
                mp1.Hide();

                if (Button.BackColor == System.Drawing.Color.Orange)
                    Response.Redirect("newpos.aspx?Ref=" + Button.Text + "&id=" + Button.CommandArgument);
                else

                    Response.Redirect("newpos.aspx?Ref=" + Button.Text + "&id=" + Button.CommandArgument);
            }
            else
            {

                mp1.Show();

                if (radtypestatus.SelectedValue == "1")
                {
                    mp1.Hide();
                }
                else
                {
                    mp1.Show();

                    dt.Columns.Add("CategoryID");
                    dt.Columns.Add("CategoryUserID");
                    dt.Columns.Add("Definition");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("AQty");
                    dt.Columns.Add("gst");
                    dt.Columns.Add("Rate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("KotNo");
                    dt.Columns.Add("Kotid");
                    dt.Columns.Add("Print");

                    dtt.Columns.Add("CategoryID");
                    dtt.Columns.Add("CategoryUserID");
                    dtt.Columns.Add("Definition");
                    dtt.Columns.Add("Qty");
                    dtt.Columns.Add("AQty");
                    dtt.Columns.Add("gst");
                    dtt.Columns.Add("Rate");
                    dtt.Columns.Add("Amount");
                    dtt.Columns.Add("KotNo");
                    dtt.Columns.Add("Kotid");
                    dtt.Columns.Add("Print");
                    var column = new DataColumn("check", typeof(bool));
                    column.DefaultValue = false;
                    dtt.Columns.Add(column);
                    // dr[""] = true;

                    ViewState["dt"] = dt;
                    ViewState["Newdt"] = dtt;

                    DataSet dCheck = new DataSet();

                    dCheck = objBs.NHoldedKOT(int.Parse(Button.CommandArgument), sTableName, "");
                    if (dCheck.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr1 = null;
                        for (int i = 0; i < dCheck.Tables[0].Rows.Count; i++)
                        {
                            decimal dStock = 0;// Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                            string sTock = dStock.ToString("f1");


                            dr1 = dtt.NewRow();
                            dr1["Definition"] = dCheck.Tables[0].Rows[i]["Definition"].ToString(); //+ " (" + sTock + ")";
                            dr1["Qty"] = dCheck.Tables[0].Rows[i]["Quantity"].ToString();
                            dr1["AQty"] = dCheck.Tables[0].Rows[i]["Quantity"].ToString();
                            dr1["gst"] = dCheck.Tables[0].Rows[i]["GST"].ToString();
                            dr1["Rate"] = Convert.ToDouble(dCheck.Tables[0].Rows[i]["unitprice"]).ToString("0.00");
                            dr1["Amount"] = Convert.ToDouble(dCheck.Tables[0].Rows[i]["Amount"]).ToString("0.00");
                            dr1["KotNo"] = dCheck.Tables[0].Rows[i]["KotNo"].ToString();
                            dr1["CategoryUserID"] = dCheck.Tables[0].Rows[i]["CategoryUserID"].ToString();
                            dr1["CategoryID"] = dCheck.Tables[0].Rows[i]["categoryid"].ToString();
                            dr1["Print"] = dCheck.Tables[0].Rows[i]["Billprint"].ToString();
                            dr1["gst"] = dCheck.Tables[0].Rows[i]["gst"].ToString();
                            dr1["Kotno"] = dCheck.Tables[0].Rows[i]["Kotno"].ToString();
                            dr1["Kotid"] = dCheck.Tables[0].Rows[i]["Kotid"].ToString();
                            dr1["check"] = false;
                            //dr1["Print"] = "1";
                            dtt.Rows.Add(dr1);




                        }


                        ViewState["Newdt"] = dtt;
                        GridView1all.DataSource = dtt;
                        GridView1all.DataBind();
                    }


                    // mp1.Show();
                }
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("newbutton.aspx");
            //System.Diagnostics.ProcessStartInfo startInfo;

            //Process p = new Process();

            //startInfo = new System.Diagnostics.ProcessStartInfo(@"E:\magil hotel\magilam\magilam\bin\Debug\magilam.exe");
            //p.StartInfo = startInfo;

            //p.Start();


        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            //DataSet ds = objBs.CustomerSalesGird123(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblRestaurantsales_" + sTableName);
            //gvsales.PageIndex = e.NewPageIndex;
            //gvsales.DataSource = ds;
            //gvsales.DataBind();


        }
        protected void refresh_Click(object sender, EventArgs e)
        {


            //lblUser.Text = Session["UserName"].ToString();
            //lblUserID.Text = Session["UserID"].ToString();
            //sTableName = Session["User"].ToString();
            //DataSet ds = objBs.CustomerSalesGird123(Convert.ToInt32(Session["UserID"].ToString()), "tblRestaurantsales_" + sTableName);
            //gvsales.DataSource = ds;
            //gvsales.DataBind();
            //gvCustsales.Visible = false;

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            //string sCustomer = ddlcustomername.SelectedValue;
            //string[] sFull = sCustomer.Split('-');
            //string sCustomerName = sFull[0].ToString();
            //string sArea = sFull[1].ToString();

            //DataSet ds = objBs.CustomerSalesGirdnamearea(Convert.ToInt32(ddlbillno.SelectedValue));
            ////DataSet ds = objBs.CustomerSalesGirdbillNo(ddlbillno.SelectedValue);
            //gvsales.DataSource = ds;
            //gvsales.DataBind();




        }




        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("cashsales.aspx?iSalesID=" + e.CommandArgument.ToString());
            //    }
            //}

            //else if (e.CommandName == "cancel")
            //{
            //    refre.Visible = true;
            //    if (txtRef.Text != "")
            //    {
            //        if (objBs.CheckIfnormalsales((Convert.ToInt32(e.CommandArgument)), sTableName))
            //        {
            //            int iscuss = objBs.normalsalescancel(sTableName, (Convert.ToInt32(e.CommandArgument)), txtRef.Text);
            //            Response.Redirect("salesgrid.aspx");
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);

            //            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill cannot be cancelled Without Ref No.');", true);

            //        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            //    }

            //    //int iSucess = objBs.deletesalesgrid(e.CommandArgument.ToString());

            //}

            //else if (e.CommandName == "view")
            //{
            //    DataSet ds = new DataSet();

            //    ds = objBs.SelectedSales(sTableName, Convert.ToInt32(e.CommandArgument));
            //    gvCustsales.DataSource = ds.Tables[0];
            //    gvCustsales.DataBind();

            //}

            //else if (e.CommandName == "print")
            //{
            //    // Response.Redirect("SalesPrint.aspx?iSalesID=" + e.CommandArgument.ToString());
            //    string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + e.CommandArgument.ToString();
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            //}
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvsales.EditIndex = -1;
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.DataSource = ds; //a dataset in my case

            //Bind data to the GridView control.
            gvsales.DataBind();
        }

        protected void txtAutoName_TextChanged(object sender, EventArgs e)
        {
            if (txtAutoName.Text == "")
            {
                //DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Session["UserID"].ToString()), "tblSales_" + sTableName);
                //gvsales.DataSource = ds;
                //gvsales.DataBind();
                //gvCustsales.Visible = false;

            }
            else
            {
                DataSet ds = objBs.autoFilterSalesGrid(Convert.ToInt32(txtAutoName.Text), sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                    gvCustsales.Visible = true;


                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }
            }
        }



        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objBs.CustomerSalesdetailed(groupID, sTableName,"");
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
                        amount1 = amount1 + amount;
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
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                //e.Row.Cells[0].Text = "Total";

                //e.Row.Cells[7].Text = amount1.ToString("N2");
                //e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

            }

        }

        protected void datkot_ItemDataBound(object sender, DataListItemEventArgs e)
        {


        }



    }
}