using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class Combo : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        double GETVALUE = 0.00;
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Request.Cookies["userInfo"]["User"] != null)
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            DataSet dacess1 = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "combo");
            if (dacess1.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                {
                    Response.Redirect("Login_branch.aspx");
                }
            }
            if (!IsPostBack)
            {
                DataSet get_types = objbs.get_category("C");
                if (get_types.Tables[0].Rows.Count > 0)
                {
                    drpCategory.DataSource = get_types;
                    drpCategory.DataTextField = "category";
                    drpCategory.DataValueField = "categoryid";
                    drpCategory.DataBind();
                    drpCategory.Items.Insert(0, "Select Category");
                }




                string comboid = Request.QueryString.Get("icomboid");
                if (comboid != null)
                {
                    drpCategory.Enabled = false;
                    //ddlcoating.Visible = true;
                    //txtprice.Visible = true;
                    //txtpurchaseprice.Visible = true;
                    DataSet ds = objbs.get_comboforupdate(comboid);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Update";
                        drpCategory.SelectedValue = ds.Tables[0].Rows[0]["Categoryid"].ToString();
                        txtcomboname.Text = ds.Tables[0].Rows[0]["ComboName"].ToString();
                        getttal.Text = ds.Tables[0].Rows[0]["TotalRate"].ToString();
                        if (ds.Tables[0].Rows[0]["IsDiscount"].ToString() == "False")
                            drpisdiscount.SelectedValue = "0";
                        else
                            drpisdiscount.SelectedValue = "1";

                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();
                        //if (isdelete == "0")
                        //{
                        //    chkisactive.Checked = false;
                        //}
                        //else
                        //{
                        //    chkisactive.Checked = true;
                        //}

                        DataSet ds2 = objbs.gettranscomboupdate(comboid);
                        {
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                int Tpo = ds2.Tables[0].Rows.Count;




                                DataTable dttt;
                                DataRow drNew;
                                DataColumn dct;
                                DataSet dstd = new DataSet();
                                dttt = new DataTable();

                                dct = new DataColumn("OrderNo");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Item");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Qty");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Rate");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("PRate");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Total");
                                dttt.Columns.Add(dct);

                                dct = new DataColumn("Tax");
                                dttt.Columns.Add(dct);

                                dstd.Tables.Add(dttt);

                                foreach (DataRow dr in ds2.Tables[0].Rows)
                                {
                                    drNew = dttt.NewRow();
                                    drNew["OrderNo"] = 1;
                                    drNew["Item"] = dr["Categoryuserid"];
                                    drNew["Qty"] = dr["Qty"];
                                    drNew["Rate"] = dr["Rate"];
                                    drNew["PRate"] = dr["ori"];
                                    drNew["Total"] = dr["TotalAmount"];
                                    drNew["Tax"] = dr["Taxval"];
                                    dstd.Tables[0].Rows.Add(drNew);
                                }

                                ViewState["CurrentTable1"] = dttt;

                                gvcombo.DataSource = dstd;
                                gvcombo.DataBind();


                                for (int i = 0; i < gvcombo.Rows.Count; i++)
                                {
                                    DropDownList drpitem =
                                  (DropDownList)gvcombo.Rows[i].Cells[4].FindControl("drpitem");

                                    DropDownList ddltax =
                                (DropDownList)gvcombo.Rows[i].Cells[4].FindControl("ddltax");

                                    TextBox txtQty = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtqty");
                                    TextBox txtrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtrate");
                                    TextBox txtPrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("Prate");
                                    TextBox txttotal = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txttotalrate");

                                    txtQty.Text = dstd.Tables[0].Rows[i]["Qty"].ToString();
                                    txtrate.Text = dstd.Tables[0].Rows[i]["Rate"].ToString();
                                    txtPrate.Text = dstd.Tables[0].Rows[i]["PRate"].ToString();
                                    txttotal.Text = dstd.Tables[0].Rows[i]["Total"].ToString();
                                    drpitem.SelectedValue = dstd.Tables[0].Rows[i]["Item"].ToString();
                                    ddltax.SelectedValue = dstd.Tables[0].Rows[i]["tax"].ToString();

                                    //i++;



                                }
                            }


                        }




                    }
                    
                }

                   
                else
                {
                    FirstGridViewRow();
                    btnadd.Text = "Save";

                  
                }
            }
        }
        protected void addclick(object sender, EventArgs e)
        {
            double grandtotal = 0.00;
            DataSet duplicate = new DataSet();
            if (getttal.Text == "0.0000")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Rate Required.Thanks You!!!')", true);
                return;
            }
            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {
                DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpItem");
                TextBox txtttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");
                TextBox txtkt = (TextBox)gvcombo.Rows[vLoop].FindControl("txttotalrate");

                if (drpitem.SelectedItem.Text == "Select Item")
                {

                }

                else
                {

                    if (txtttk.Text == "")
                    {
                        txtttk.Text = "0";
                    }

                    if (txttk.Text == "")
                    {
                        txttk.Text = "0";
                    }

                    double iNetAmount = ((Convert.ToDouble(txtttk.Text)) * (Convert.ToDouble(txttk.Text)));


                    //  double total = tx + DiscountAmount;

                    txtkt.Text = string.Format("{0:N2}", iNetAmount);

                    grandtotal = grandtotal + iNetAmount;
                }
                txt1.Text = grandtotal.ToString("N");
            }

            //if (txtmodelno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Model No.Thanks You!!!')", true);
            //    return;

            //}

            //DropDownList ddlcoating = (DropDownList)gvcombo.Rows[vLoop].FindControl("ddlcoating");
            if (drpCategory.SelectedValue == "Select Category")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Category.Thanks You!!!')", true);
                return;
            }
            if (btnadd.Text == "Save")
            {


                int isc = objbs.insertcombo(txtcomboname.Text, txt1.Text, drpCategory.SelectedValue);


                for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
                {
                    DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpItem");
                    TextBox txtttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                    TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");
                    TextBox txtkt = (TextBox)gvcombo.Rows[vLoop].FindControl("txttotalrate");
                    DropDownList ddltax = (DropDownList)gvcombo.Rows[vLoop].FindControl("ddltax");
                    if (drpitem.SelectedItem.Text == "Select Item")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Item.Thanks You!!!')", true);
                        return;
                    }
                    else if (ddltax.SelectedItem.Text == "Select Tax")
                    {

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select tax.Thanks You!!!')", true);
                        return;
                    }
                    else
                    {
                        int itasn = objbs.inserttranscombo(drpitem.SelectedValue, txtttk.Text, txttk.Text, txtkt.Text, drpCategory.SelectedValue, ddltax.SelectedValue, ddltax.SelectedItem.Text);

                    }
                }
                Response.Redirect("ComboGrid.aspx");
            }
            else if (btnadd.Text == "Update")
            {
                string comboid = Request.QueryString.Get("icomboid");

                

                int isc = objbs.updatecombo(txtcomboname.Text, txt1.Text, drpCategory.SelectedValue, comboid, drpisactive.SelectedValue);
                for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
                {
                    DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpItem");
                    TextBox txtttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                    TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");
                    TextBox txtkt = (TextBox)gvcombo.Rows[vLoop].FindControl("txttotalrate");
                    DropDownList ddltax = (DropDownList)gvcombo.Rows[vLoop].FindControl("ddltax");
                    if (drpitem.SelectedItem.Text == "Select Item")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Item.Thanks You!!!')", true);
                        return;
                    }
                    else if (ddltax.SelectedItem.Text == "Select Tax")
                    {

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select tax.Thanks You!!!')", true);
                        return;
                    }
                    else
                    {
                        int itasn = objbs.updatetranscombo(drpitem.SelectedValue, txtttk.Text, txttk.Text, txtkt.Text, drpCategory.SelectedValue, comboid,ddltax.SelectedValue,ddltax.SelectedItem.Text);

                    }
                }
                //  int imsert = objbs.Update_lenssproduct(ddltype.SelectedValue, ddlbrand.SelectedValue, txtmodelno.Text, ddlcategory.SelectedValue, ddlcoating.SelectedValue, txtpowerrange.Text, ddlIsActive.SelectedValue, radstock.SelectedValue, txtproductName.Text, txtcyl.Text, txtaddpower.Text, txttax.Text, "", txtlensid.Text, txtprice.Text, txtpurchaseprice.Text);

                Response.Redirect("ComboGrid.aspx");
            }

        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComboGrid.aspx");
        }



        private void FirstGridViewRow()
        {
            DataTable dtt = new DataTable();
            DataRow dr = null;
            dtt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
            dtt.Columns.Add(new DataColumn("Item", typeof(string)));
            dtt.Columns.Add(new DataColumn("PRate", typeof(string)));
            dtt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dtt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dtt.Columns.Add(new DataColumn("Total", typeof(string)));
            dtt.Columns.Add(new DataColumn("Tax", typeof(string)));

            dr = dtt.NewRow();
            dr["OrderNo"] = string.Empty;
            dr["Item"] = string.Empty;
            dr["qty"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["PRate"] = string.Empty;
            dr["Total"] = string.Empty;
            dr["Tax"] = string.Empty;

            dtt.Rows.Add(dr);

            ViewState["CurrentTable1"] = dtt;

            this.gvcombo.DataSource = dtt;
            this.gvcombo.DataBind();

            DataTable dttt;
            DataRow drNew;
            DataColumn dct;
            DataSet dstd = new DataSet();
            dttt = new DataTable();

            dct = new DataColumn("OrderNo");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Item");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Rate");
            dttt.Columns.Add(dct);

            dct = new DataColumn("PRate");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Total");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Tax");
            dttt.Columns.Add(dct);

            dstd.Tables.Add(dttt);

            drNew = dttt.NewRow();
            drNew["OrderNo"] = 1;
            drNew["Item"] = "";
            drNew["Qty"] = "";
            drNew["Rate"] = "";
            drNew["PRate"] = "";
            drNew["Total"] = "";
            drNew["Tax"] = "";

            dstd.Tables[0].Rows.Add(drNew);

            this.gvcombo.DataSource = dstd;
            this.gvcombo.DataBind();

        }

        protected void ButtonAdd1_Click(object sender, EventArgs e)
        {
            int No = 0;

            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {

                DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpitem");
                TextBox txtrate = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                TextBox txttotal = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");

                if (drpitem.SelectedValue == "Select Item")
                {
                    No = 0;
                    break;
                }
                else
                {
                    No = 1;
                }
            }

            if (No == 1)
            {

                AddNewRow();
            }
            else
            {

            }





        }



        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double gettotal = 0.00;
            DataSet get_coating = objbs.get_item();

            DataSet dstax = objbs.getTAX();

         
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox tot = (TextBox)e.Row.FindControl("txttotalrate");
                if (tot.Text != "")
                {
                    gettotal = gettotal + Convert.ToDouble(tot.Text);
                }



                DropDownList ddlcoating1 = (DropDownList)e.Row.FindControl("drpitem");

                var ddl = (DropDownList)e.Row.FindControl("drpitem");
                ddl.DataSource = get_coating;
                ddl.DataTextField = "Definition";
                ddl.DataValueField = "CategoryUserid";
                ddl.DataBind();
                ddl.Items.Insert(0, "Select Item");




                var ddltax = (DropDownList)e.Row.FindControl("ddltax");
                ddltax.DataSource = dstax;
                ddltax.DataTextField = "TaxName";
                ddltax.DataValueField = "Taxid";
                ddltax.DataBind();
                ddltax.Items.Insert(0, "Select Tax");

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].Text = GETVALUE.ToString("N");
            }

        }

        private void AddNewRow()
        {
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;
            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {
                DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpitem");
                TextBox txtQty = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                TextBox txtrate = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");
                TextBox txtPrate = (TextBox)gvcombo.Rows[vLoop].FindControl("Prate");
                TextBox txttotal = (TextBox)gvcombo.Rows[vLoop].FindControl("txttotalrate");
                DropDownList ddltax = (DropDownList)gvcombo.Rows[vLoop].FindControl("ddltax");

                int col = vLoop + 1;

            }

            int rowIndex = 0;

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList drpitem =
                      (DropDownList)gvcombo.Rows[rowIndex].Cells[4].FindControl("drpitem");

                        TextBox txtQty = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("txtqty");
                        TextBox txtrate = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("txtrate");
                        TextBox txtPrate = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("Prate");
                        TextBox txttotal = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("txttotalrate");

                        DropDownList ddltax =
                    (DropDownList)gvcombo.Rows[rowIndex].Cells[4].FindControl("ddltax");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Orderno"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Item"] = drpitem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtrate.Text;
                        dtCurrentTable.Rows[i - 1]["PRate"] = txtPrate.Text;
                        dtCurrentTable.Rows[i - 1]["Total"] = txttotal.Text;
                        dtCurrentTable.Rows[i - 1]["Tax"] = ddltax.SelectedValue;
                        rowIndex++;


                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable1"] = dtCurrentTable;

                    gvcombo.DataSource = dtCurrentTable;
                    gvcombo.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();

            if (ViewState["CurrentTable1"] != null)
            {
                DataSet ds = new DataSet();
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {

                    ds.Merge(dt);


                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();

                    ViewState["CurrentTable1"] = dt;
                    gvcombo.DataSource = dt;
                    gvcombo.DataBind();

                    SetPreviousData();


                }
                else if (dt.Rows.Count == 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    gvcombo.DataSource = dt;
                    gvcombo.DataBind();

                    SetPreviousData();
                    FirstGridViewRow();
                }
            }

        }


        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList drpitem =
                      (DropDownList)gvcombo.Rows[rowIndex].Cells[4].FindControl("drpitem");

                        TextBox txtQty = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("txtqty");
                        TextBox txtrate = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("txtrate");
                        TextBox txtPrate = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("PRate");
                        TextBox txttotal = (TextBox)gvcombo.Rows[rowIndex].Cells[4].FindControl("txttotalrate");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Orderno"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Item"] = drpitem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtrate.Text;
                        dtCurrentTable.Rows[i - 1]["PRate"] = txtPrate.Text;
                        dtCurrentTable.Rows[i - 1]["Total"] = txttotal.Text;

                        rowIndex++;

                    }

                    ViewState["CurrentTable1"] = dtCurrentTable;
                    gvcombo.DataSource = dtCurrentTable;
                    gvcombo.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList drpitem =
                      (DropDownList)gvcombo.Rows[i].Cells[4].FindControl("drpitem");

                        DropDownList ddltax =
                    (DropDownList)gvcombo.Rows[i].Cells[4].FindControl("ddltax");

                        TextBox txtQty = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtqty");
                        TextBox txtrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtrate");
                        TextBox txtPrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("Prate");
                        TextBox txttotal = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txttotalrate");

                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        txtrate.Text = dt.Rows[i]["Rate"].ToString();
                        txtPrate.Text = dt.Rows[i]["PRate"].ToString();
                        txttotal.Text = dt.Rows[i]["Total"].ToString();
                        drpitem.SelectedValue = dt.Rows[i]["Item"].ToString();
                        ddltax.SelectedValue = dt.Rows[i]["tax"].ToString();

                        rowIndex++;

                        rowIndex++;

                    }
                }
            }
        }
        protected void drpitem_changed(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList drpitem = (DropDownList)row.FindControl("drpitem");
            TextBox txtRate = (TextBox)row.FindControl("PRate");
            DropDownList ddltax = (DropDownList)row.FindControl("ddltax");

            if (drpitem.SelectedItem.Text != "Select Item")
            {
                DataSet dscat = objbs.getitemratee(drpitem.SelectedValue);
                if (dscat.Tables[0].Rows.Count > 0)
                {
                    txtRate.Text = Convert.ToDouble(dscat.Tables[0].Rows[0]["Rate"]).ToString("N");
                   // ddltax.SelectedValue = dscat.Tables[0].Rows[0]["taxval"].ToString();
                }
                //DataSet dsCategory1 = objbs.selectProduct(Convert.ToInt32(Defitem.SelectedValue), sTableName);
            }

        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            double grandtotal = 0;
            double freght = 0;
            double tax = 0;
            double distotal = 0;
            double r = 0.00;

            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {

                DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpItem");
                TextBox txtttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");
                TextBox txtkt = (TextBox)gvcombo.Rows[vLoop].FindControl("txttotalrate");

                if (drpitem.SelectedItem.Text == "Select Item")
                {

                }
                else
                {

                    if (txtttk.Text == "")
                    {
                        txtttk.Text = "0";
                    }

                    if (txttk.Text == "")
                    {
                        txttk.Text = "0";
                    }

                    double iNetAmount = ((Convert.ToDouble(txtttk.Text)) * (Convert.ToDouble(txttk.Text)));


                    //  double total = tx + DiscountAmount;

                    txtkt.Text = string.Format("{0:N2}", iNetAmount);

                    grandtotal = grandtotal + iNetAmount;
                }
            }
            //txtcomboname.Text = grandtotal.ToString();
            //txt1.Text = grandtotal.ToString("N");
            //GETVALUE = grandtotal;
            getttal.Text = grandtotal.ToString("N");
            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {
                // TextBox txtno = (TextBox)gvcombo.Rows[vLoop].FindControl("txtno");
                TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtRate");
                txttk.Focus();
            }
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            double grandtotal = 0;
            double freght = 0;
            double tax = 0;
            double distotal = 0;
            double r = 0.00;

            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {

                DropDownList drpitem = (DropDownList)gvcombo.Rows[vLoop].FindControl("drpItem");
                TextBox txtttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtqty");
                TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtrate");
                TextBox txtkt = (TextBox)gvcombo.Rows[vLoop].FindControl("txttotalrate");

                if (drpitem.SelectedItem.Text == "Select Item")
                {

                }
                else
                {

                    if (txtttk.Text == "")
                    {
                        txtttk.Text = "0";
                    }

                    if (txttk.Text == "")
                    {
                        txttk.Text = "0";
                    }

                    double iNetAmount = ((Convert.ToDouble(txtttk.Text)) * (Convert.ToDouble(txttk.Text)));


                    //  double total = tx + DiscountAmount;

                    txtkt.Text = string.Format("{0:N2}", iNetAmount);

                    grandtotal = grandtotal + iNetAmount;
                }
                txt1.Text = grandtotal.ToString("N");
            }
            getttal.Text = grandtotal.ToString("N");
            for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
            {
                // TextBox txtno = (TextBox)gvcombo.Rows[vLoop].FindControl("txtno");
                TextBox txttk = (TextBox)gvcombo.Rows[vLoop].FindControl("txtRate");
                txttk.Focus();
            }


        }

    }
}