using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class OfferNew : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        double GETVALUE = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int value = 10;
            //txtPCode.Text = String.Format("{0:0000}", value); 

            //btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
            if (Session["User"] != null)
                sTableName = Session["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            if (!IsPostBack)
            {
                fromtime.Visible = false;
                totime.Visible = false;
                BindTime();
                DataSet get_types = objbs.get_category("H");
                if (get_types.Tables[0].Rows.Count > 0)
                {
                    drpCategory.DataSource = get_types;
                    drpCategory.DataTextField = "category";
                    drpCategory.DataValueField = "categoryid";
                    drpCategory.DataBind();
                    drpCategory.Items.Insert(0, "Select Category");
                   // drpCategory.SelectedValue = "18";
                    //drpCategory.Enabled = false;
                }
                 string offerid = Request.QueryString.Get("iofferid");
                 if (offerid != null)
                 {
                     drpCategory.Enabled = false;
                     //ddlcoating.Visible = true;
                     //txtprice.Visible = true;
                     //txtpurchaseprice.Visible = true;
                     DataSet ds = objbs.get_happyhoursforupdateHH(offerid);
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         fromtime.Visible = true;
                         totime.Visible = true;
                         btnadd.Text = "Update";
                         drpCategory.SelectedValue = ds.Tables[0].Rows[0]["Categoryid"].ToString();
                         txtcomboname.Text = ds.Tables[0].Rows[0]["offerName"].ToString();
                         txtfromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["From_time"]).ToString("dd/MM/yyyy");
                         txttodate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["To_time"]).ToString("dd/MM/yyyy");
                     //    DateTime StartTime = DateTime.ParseExact(ds.Tables[0].Rows[0]["fromtime"].ToString(), "HH:mm", null);
                      //   long tim = Convert.ToInt64(ds.Tables[0].Rows[0]["fromtime"]);
                         //TimeSpan timespan = new TimeSpan(long.Parse(ds.Tables[0].Rows[0]["from_time"].ToString()));
                         //DateTime time = DateTime.Today.Add(timespan);
                         //string displayTime = time.ToString("hh:mm tt");
                       //  ddlTimeFrom.SelectedValue = displayTime.ToString();
                         DateTime dateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["From_time"]);
                         string strMinFormat = dateTime.ToString("h:mm tt");//12 hours format
                         ddlTimeFrom.SelectedValue = strMinFormat;

                         DateTime dateTime1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["To_time"]);
                         string strMinFormat1 = dateTime1.ToString("h:mm tt");//12 hours format
                         ddlTimeTo.SelectedValue = strMinFormat1;
                         fromtime.Text = ds.Tables[0].Rows[0]["fromtt"].ToString();
                         totime.Text = ds.Tables[0].Rows[0]["tott"].ToString();
                         getttal.Text = ds.Tables[0].Rows[0]["TotalRate"].ToString();
                         drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();

                         if(ds.Tables[0].Rows[0]["IsDiscount"].ToString() == "False")
                         drpisdiscount.SelectedValue = "0";
                         else
                             drpisdiscount.SelectedValue = "1";
                         DataSet ds2 = objbs.gettranshappyupdate(offerid);
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
                                     dstd.Tables[0].Rows.Add(drNew);
                                 }

                                 ViewState["CurrentTable1"] = dttt;

                                 gvcombo.DataSource = dstd;
                                 gvcombo.DataBind();


                                 for (int i = 0; i < gvcombo.Rows.Count; i++)
                                 {
                                     DropDownList drpitem =
                                   (DropDownList)gvcombo.Rows[i].Cells[4].FindControl("drpitem");

                                     TextBox txtQty = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtqty");
                                     TextBox txtrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtrate");
                                     TextBox txtPrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("Prate");
                                     TextBox txttotal = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txttotalrate");

                                     txtQty.Text = dstd.Tables[0].Rows[i]["Qty"].ToString();
                                     txtrate.Text = dstd.Tables[0].Rows[i]["Rate"].ToString();
                                     txtPrate.Text = dstd.Tables[0].Rows[i]["PRate"].ToString();
                                     txttotal.Text = dstd.Tables[0].Rows[i]["Total"].ToString();
                                     drpitem.SelectedValue = dstd.Tables[0].Rows[i]["Item"].ToString();

                                     //i++;



                                 }
                             }


                         }
                     }
                 }

                     //    DataSet dlens = new DataSet();
                 //    DataSet dlens = objbs.getlensvalues(lensid);
                 //    if (ds.Tables[0].Rows.Count > 0)
                 //    {
                 //        DataTable dttt;
                 //        DataRow drNew;
                 //        DataColumn dct;
                 //        DataSet dstd = new DataSet();
                 //        dttt = new DataTable();


                     //        dct = new DataColumn("Coating");
                 //        dttt.Columns.Add(dct);

                     //        dct = new DataColumn("SellingPrice");
                 //        dttt.Columns.Add(dct);

                     //        dct = new DataColumn("PurchasePrice");
                 //        dttt.Columns.Add(dct);

                     //        dstd.Tables.Add(dttt);

                     //        foreach (DataRow dr in ds.Tables[0].Rows)
                 //        {

                     //            drNew = dttt.NewRow();
                 //            drNew["Coating"] = dr["Coating"];
                 //            drNew["SellingPrice"] = dr["SellingPrice"];
                 //            drNew["PurchasePrice"] = dr["PurchasePrice"];

                     //            dstd.Tables[0].Rows.Add(drNew);
                 //        }

                     //        ViewState["CurrentTable1"] = dttt;

                     //        gvcombo.DataSource = dstd;
                 //        gvcombo.DataBind();

                     //        for (int vLoop = 0; vLoop < gvcombo.Rows.Count; vLoop++)
                 //        {
                 //            TextBox txtpri = (TextBox)gvcombo.Rows[vLoop].FindControl("txtprice");
                 //            TextBox txtpurchasepri = (TextBox)gvcombo.Rows[vLoop].FindControl("txtpurchaseprice");
                 //            DropDownList ddlcoat = (DropDownList)gvcombo.Rows[vLoop].FindControl("ddlcoating");


                     //            DataSet getcoating = objbs.get_Coating(ddlcoating.SelectedValue);
                 //            if (getcoating.Tables[0].Rows.Count > 0)
                 //            {
                 //                ddlcoating.DataSource = getcoating;
                 //                ddlcoating.DataTextField = "Coating";
                 //                ddlcoating.DataValueField = "CoatingID";
                 //                ddlcoating.DataBind();
                 //                ddlcoating.Items.Insert(0, "---Select Coating---");
                 //            }
                 //            ddlcoat.SelectedValue = dstd.Tables[0].Rows[0]["Coating"].ToString();
                 //            txtpri.Text = dstd.Tables[0].Rows[0]["SellingPrice"].ToString();
                 //            txtpurchasepri.Text = dstd.Tables[0].Rows[0]["PurchasePrice"].ToString();
                 //        }
                 //    }
                 //}



                 //}
                 else
                 {
                     FirstGridViewRow();
                     btnadd.Text = "Save";
                     //Div2.Visible = false;
                     //Div3.Visible = false;
                     //Div4.Visible = false;
                 }
            }
        }

        private void BindTime()
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
            //Set 5 minutes interval
            TimeSpan Interval = new TimeSpan(0, 30, 0);
            //To set 1 hour interval
            //TimeSpan Interval = new TimeSpan(1, 0, 0);           
            ddlTimeFrom.Items.Clear();
            ddlTimeTo.Items.Clear();
            while (StartTime <= EndTime)
            {
                ddlTimeFrom.Items.Add(StartTime.ToShortTimeString());
                ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }
            ddlTimeFrom.Items.Insert(0, new ListItem("Select From Time", "0"));
            ddlTimeTo.Items.Insert(0, new ListItem("Select To Time", "0"));
        }
        protected void addclick(object sender, EventArgs e)
        {
            double grandtotal = 0.00;
            DataSet duplicate = new DataSet();

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

            DateTime billldate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan time = Convert.ToDateTime(ddlTimeFrom.SelectedValue).TimeOfDay;

            DateTime fromresult = billldate + time;


            DateTime toodate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan totime = Convert.ToDateTime(ddlTimeTo.SelectedValue).TimeOfDay;

            DateTime toresult = toodate + totime;

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


                int isc = objbs.insertofferHappy(txtcomboname.Text, txt1.Text, drpCategory.SelectedValue, fromresult, toresult, Convert.ToInt32(drpisdiscount.Text), drpisactive.SelectedValue);


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
                        int itasn = objbs.inserttransoffer(drpitem.SelectedValue, txtttk.Text, txttk.Text, txtkt.Text, drpCategory.SelectedValue, Convert.ToInt32(drpisdiscount.Text));

                    }
                }
                Response.Redirect("Offer.aspx");
            }
            else if (btnadd.Text == "Update")
            {
                string offerid = Request.QueryString.Get("iofferid");
                int isc = objbs.updateoffer(txtcomboname.Text, txt1.Text, drpCategory.SelectedValue, fromresult, toresult, offerid, Convert.ToInt32(drpisdiscount.Text),drpisactive.SelectedValue);


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
                        int itasn = objbs.updatetransoffer(drpitem.SelectedValue, txtttk.Text, txttk.Text, txtkt.Text, drpCategory.SelectedValue, offerid, Convert.ToInt32(drpisdiscount.Text));

                    }
                }
                Response.Redirect("Offer.aspx");
                //  int imsert = objbs.Update_lenssproduct(ddltype.SelectedValue, ddlbrand.SelectedValue, txtmodelno.Text, ddlcategory.SelectedValue, ddlcoating.SelectedValue, txtpowerrange.Text, ddlIsActive.SelectedValue, radstock.SelectedValue, txtproductName.Text, txtcyl.Text, txtaddpower.Text, txttax.Text, "", txtlensid.Text, txtprice.Text, txtpurchaseprice.Text);

                Response.Redirect("Offer.aspx");
            }

        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Offer.aspx");
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

            dr = dtt.NewRow();
            dr["OrderNo"] = string.Empty;
            dr["Item"] = string.Empty;
            dr["qty"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["PRate"] = string.Empty;
            dr["Total"] = string.Empty;

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

            dstd.Tables.Add(dttt);

            drNew = dttt.NewRow();
            drNew["OrderNo"] = 1;
            drNew["Item"] = "";
            drNew["Qty"] = "";
            drNew["Rate"] = "";
            drNew["PRate"] = "";
            drNew["Total"] = "";

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
                ddl.DataValueField = "ItemId";
                ddl.DataBind();
                ddl.Items.Insert(0, "Select Item");

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

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Orderno"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Item"] = drpitem.Text;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtrate.Text;
                        dtCurrentTable.Rows[i - 1]["PRate"] = txtPrate.Text;
                        dtCurrentTable.Rows[i - 1]["Total"] = txttotal.Text;
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

                        TextBox txtQty = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtqty");
                        TextBox txtrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txtrate");
                        TextBox txtPrate = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("Prate");
                        TextBox txttotal = (TextBox)gvcombo.Rows[i].Cells[4].FindControl("txttotalrate");

                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        txtrate.Text = dt.Rows[i]["Rate"].ToString();
                        txtPrate.Text = dt.Rows[i]["PRate"].ToString();
                        txttotal.Text = dt.Rows[i]["Total"].ToString();
                        drpitem.SelectedValue = dt.Rows[i]["Item"].ToString();

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

            if (drpitem.SelectedItem.Text != "Select Item")
            {
                DataSet dscat = objbs.getitemratee(drpitem.SelectedValue);
                if (dscat.Tables[0].Rows.Count > 0)
                {
                    txtRate.Text = Convert.ToDouble(dscat.Tables[0].Rows[0]["Rate"]).ToString("N");
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