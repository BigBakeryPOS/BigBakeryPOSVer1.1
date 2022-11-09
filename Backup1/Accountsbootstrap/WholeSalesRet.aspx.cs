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
    public partial class WholeSalesRet : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";

        double Qty = 0; double Rate = 0; double Tax = 0; double TaxAmount = 0; double Amount = 0; double STotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();

            if (!IsPostBack)
            {
                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                #region

                DataSet dssalesNo = objbs.getcrsalesnoret(sTableName);
                txtbillno.Text = dssalesNo.Tables[0].Rows[0]["BillNo"].ToString();





                DataSet dsCustomer = objbs.getgridforcustsale();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dsCustomer.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "LedgerID";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "Select Customer");


                }
                else
                {
                    ddlcustomer.Items.Insert(0, "Select Customer");
                }


                #endregion

                // FirstGridViewRow1();
                ddlitem.Focus();
            }


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
            txtsno.Focus();
        }




        protected void ddlcustomer_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            #region

            chkbillno.Items.Clear();
            txtqty.Text = "0";
            txtrate.Text = "0";
            txttax.Text = "0";
            txttaxamount.Text = "0";
            txtamount.Text = "0";
            txtstock.Text = "0";

            txtgrandamount.Text = "0";
            txtTaxamt.Text = "0";
            txtgrandtotal.Text = "0";

            txtdiscamt.Text = "0";

            GridView2.DataSource = null;
            GridView2.DataBind();

            ViewState["CurrentTable1"] = null;

            #endregion

            if (ddlcustomer.SelectedValue != "Select Customer" && ddlcustomer.SelectedValue != "" && ddlcustomer.SelectedValue != "0")
            {
                DataSet dscust = objbs.selectretsale(sTableName, Convert.ToInt32(ddlcustomer.SelectedValue));
                if (dscust.Tables[0].Rows.Count > 0)
                {
                    txtmbl.Text = dscust.Tables[0].Rows[0]["Mobile"].ToString();
                    chkbillno.DataSource = dscust.Tables[0];
                    chkbillno.DataTextField = "BillNo";
                    chkbillno.DataValueField = "SalesId";
                    chkbillno.DataBind();

                }
                else
                {

                }
            }
        }

        protected void chkinvnochanged(object sender, EventArgs e)
        {
            DataSet dsmerge = new DataSet();

            foreach (ListItem item in chkbillno.Items)
            {
                if (item.Selected)
                {
                    DataSet ds = objbs.selectretsaleret(sTableName, Convert.ToInt32(item.Value));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dsmerge.Merge(ds);
                    }
                }
            }
            if (dsmerge.Tables.Count > 0)
            {
                if (dsmerge.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = dsmerge;
                    GridView2.DataBind();


                    #region

                    DataTable dtddd = new DataTable();
                    DataTable dttt;
                    DataRow drNew;
                    DataColumn dct;
                    DataSet dstd = new DataSet();
                    dttt = new DataTable();

                    dct = new DataColumn("BillNo");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("BillDate");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Item");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Qty");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Rate");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Tax");
                    dttt.Columns.Add(dct);



                    //dct = new DataColumn("UOM");
                    //dttt.Columns.Add(dct);

                    dct = new DataColumn("ID");
                    dttt.Columns.Add(dct);


                    dct = new DataColumn("RetTax");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("RetAmount");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("RetQty");
                    dttt.Columns.Add(dct);

                    dstd.Tables.Add(dttt);

                    foreach (DataRow dr in dsmerge.Tables[0].Rows)
                    {

                        drNew = dttt.NewRow();

                        drNew["BillNo"] = dr["BillNo"];
                        drNew["BillDate"] = dr["BillDate"];

                        drNew["Item"] = dr["Item"];

                        drNew["Qty"] = dr["Qty"];
                        drNew["Rate"] = dr["Rate"];
                        drNew["Tax"] = dr["Tax"];

                        // drNew["UOM"] = dr["UOM"];
                        drNew["ID"] = dr["ID"];

                        drNew["RetTax"] = "0";
                        drNew["RetQty"] = "0";
                        drNew["RetAmount"] = "0";

                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];

                    }

                    ViewState["CurrentTable1"] = dtddd;

                    GridView2.DataSource = dtddd;
                    GridView2.DataBind();

                    for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                    {
                        TextBox txtbillno = (TextBox)GridView2.Rows[vLoop].FindControl("txtbillno");
                        TextBox txtbilldate = (TextBox)GridView2.Rows[vLoop].FindControl("txtbilldate");

                        DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");

                        TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                        TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                        TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");

                        //  TextBox txtuom = (TextBox)GridView2.Rows[vLoop].FindControl("txtuom");

                        TextBox txtreturnqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtreturnqty");
                        TextBox txtrettax = (TextBox)GridView2.Rows[vLoop].FindControl("txtrettax");
                        TextBox txtretamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtretamount");
                        TextBox txtid = (TextBox)GridView2.Rows[vLoop].FindControl("txtid");

                        txtbillno.Text = dstd.Tables[0].Rows[vLoop]["BillNo"].ToString();
                        txtbilldate.Text = dstd.Tables[0].Rows[vLoop]["BillDate"].ToString();

                        drpItem.SelectedValue = dstd.Tables[0].Rows[vLoop]["Item"].ToString();
                        txtQty.Text = dstd.Tables[0].Rows[vLoop]["Qty"].ToString();
                        txtRate.Text = dstd.Tables[0].Rows[vLoop]["Rate"].ToString();
                        txtTax.Text = dstd.Tables[0].Rows[vLoop]["Tax"].ToString();

                        txtreturnqty.Text = dstd.Tables[0].Rows[vLoop]["RetQty"].ToString();
                        txtrettax.Text = dstd.Tables[0].Rows[vLoop]["RetTax"].ToString();

                        txtretamount.Text = dstd.Tables[0].Rows[vLoop]["RetAmount"].ToString();
                        txtid.Text = dstd.Tables[0].Rows[vLoop]["ID"].ToString();
                        // txtuom.Text = dstd.Tables[0].Rows[vLoop]["UOM"].ToString();
                    }

                    #endregion
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }




        }





        protected void GridView2_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var drpItem = (DropDownList)e.Row.FindControl("drpItem");
                dst = objbs.selectitemsgrid_wholesales(sTableName);
                drpItem.DataSource = dst;
                drpItem.DataTextField = "Definition";
                drpItem.DataValueField = "CategoryUserID";
                drpItem.DataBind();
                drpItem.Items.Insert(0, "Select Item");

                //double Qty = 0; double Rate = 0; double Tax = 0; double TaxAmount = 0; double Amount = 0;

                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                //Rate += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate"));
                //Tax += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
                //TaxAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TaxAmount"));
                //Amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                //STotal += (Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty")) * Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate")));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[1].Text = "Total :";
                //e.Row.Cells[2].Text = Qty.ToString();
                //e.Row.Cells[3].Text = Rate.ToString("f2");

                //e.Row.Cells[5].Text = TaxAmount.ToString("f2");
                //e.Row.Cells[6].Text = Amount.ToString("f2");

                //txtgrandamount.Text = STotal.ToString("f2");
                //txtTaxamt.Text = TaxAmount.ToString("f2");
                //// txtdiscamt.Text = TaxAmount.ToString("f2");

                //lbltotalitems.InnerText = Qty.ToString("f2");

                //// txtgrandtotal.Text = STotal.ToString("f2");
                //txtgrandtotal.Text = Amount.ToString("f2");


                //double r;
                //double roundoff = Convert.ToDouble(txtgrandtotal.Text) - Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
                //if (roundoff >= 0.5)
                //{
                //    r = Math.Round(Convert.ToDouble(txtgrandtotal.Text), MidpointRounding.AwayFromZero);
                //}
                //else
                //{
                //    r = Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
                //}
                //lbldisplay.InnerText = string.Format("{0:N2}", r);

                //// txtdiscperc_OnTextChanged(sender, e);
            }

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    SetPreviousData1();


                }

                else if (dt.Rows.Count == 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = null;
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                    SetPreviousData1();


                }

            }
        }

        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox txtbillno =
                         (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtbillno");
                        TextBox txtbilldate =
                         (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtbilldate");



                        DropDownList drpItem =
                       (DropDownList)GridView2.Rows[rowIndex].Cells[2].FindControl("drpItem");

                        TextBox txtQty =
                          (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtQty");
                        TextBox txtRate =
                         (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtTax =
                         (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtTax");


                        TextBox txtreturnqty =
                        (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtreturnqty");
                        //TextBox txtuom =
                        // (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtuom");


                        TextBox txtrettax =
                       (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtrettax");
                        TextBox txtretamount =
                         (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtretamount");
                        TextBox txtid =
                       (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtid");


                        txtbillno.Text = dt.Rows[i]["BillNo"].ToString();
                        txtbilldate.Text = dt.Rows[i]["BillDate"].ToString();

                        drpItem.SelectedValue = dt.Rows[i]["Item"].ToString();
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        txtRate.Text = dt.Rows[i]["Rate"].ToString();
                        txtTax.Text = dt.Rows[i]["Tax"].ToString();

                        txtreturnqty.Text = dt.Rows[i]["RetQty"].ToString();
                       // txtuom.Text = dt.Rows[i]["UOM"].ToString();
                        txtrettax.Text = dt.Rows[i]["RetTax"].ToString();
                        txtretamount.Text = dt.Rows[i]["RetAmount"].ToString();
                        txtid.Text = dt.Rows[i]["ID"].ToString();


                        rowIndex++;

                    }
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {


            #region

            if ((txtnarrations.Text == "0") || (txtnarrations.Text == ""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Narrations. Thank you !!!');", true);
                ddlcustomer.Focus();
                return;
            }

            if ((ddlcustomer.SelectedValue == "0") || (ddlcustomer.SelectedValue == "") || (ddlcustomer.SelectedValue == "Select Customer"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Customer. Thank you !!!');", true);
                ddlcustomer.Focus();
                return;
            }


            if (GridView2.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Entry Items. Thank you !!!');", true);
                return;
            }
            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                DropDownList drpItem = (DropDownList)GridView2.Rows[0].FindControl("drpItem");
                if (drpItem.SelectedValue == "Select Item" || drpItem.SelectedValue == "" || drpItem.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Entry Items. Thank you !!!');", true);
                    return;
                }
            }

            #endregion

            #region
            double TQty = 0; double Ttax = 0; double Tamount = 0; double NETamount = 0;
            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                #region

                TextBox txtqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtreturnqty");
                TextBox txtrate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                TextBox txttax = (TextBox)GridView2.Rows[vLoop].FindControl("txttax");

                TextBox txtrettax = (TextBox)GridView2.Rows[vLoop].FindControl("txtrettax");
                TextBox txtretamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtretamount");

                if (txtqty.Text == "")
                {
                    txtqty.Text = "0";
                }


                TQty += Convert.ToDouble(txtqty.Text);

                double amt = Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text);
                Tamount += amt;

                double taxamt = ((amt * Convert.ToDouble(txttax.Text)) / 100);
                Ttax += taxamt;

                double total = amt + taxamt;
                NETamount += total;

                txtrettax.Text = taxamt.ToString("f2");
                txtretamount.Text = total.ToString("f2");



                #endregion
            }

            #region

            txtgrandamount.Text = Tamount.ToString("f2");
            txtTaxamt.Text = Ttax.ToString("f2");
            txtgrandtotal.Text = NETamount.ToString("f2");


            lbltotalitems.InnerText = TQty.ToString("f2");

            double r;
            double roundoff = Convert.ToDouble(txtgrandtotal.Text) - Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            if (roundoff >= 0.5)
            {
                r = Math.Round(Convert.ToDouble(txtgrandtotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            }
            lbldisplay.InnerText = string.Format("{0:N2}", r);
            #endregion


            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {

                TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtQty");
                TextBox txtreturnqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtreturnqty");
                DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");

                if (Convert.ToDouble(txtQty.Text) < Convert.ToDouble(txtreturnqty.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Check 	Ret.Qty for " + drpItem.SelectedItem.Text+ ". Thank you !!!');", true);
                    return;
                   
                }
            }
            #endregion

            DateTime date = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);

            if (btnadd.Text == "Save")
            {
                int salesid = objbs.insertwholesalesret(sTableName, date, "0", "", ddlcustomer.SelectedValue, txtmbl.Text, "", Convert.ToDouble(txtgrandamount.Text), Convert.ToDouble(txtTaxamt.Text), Convert.ToDouble(txtgrandtotal.Text), Convert.ToInt32(0), "", txtdiscamt.Text, Convert.ToDouble(lbltotalitems.InnerText),txtnarrations.Text);

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {

                    DropDownList drpItem = (DropDownList)GridView2.Rows[vLoop].FindControl("drpItem");
                    TextBox txtQty = (TextBox)GridView2.Rows[vLoop].FindControl("txtreturnqty");
                    TextBox txtRate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                    TextBox txtTax = (TextBox)GridView2.Rows[vLoop].FindControl("txtTax");
                    TextBox txtTaxamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtrettax");
                    TextBox txtAmount = (TextBox)GridView2.Rows[vLoop].FindControl("txtretamount");

                    TextBox txtid = (TextBox)GridView2.Rows[vLoop].FindControl("txtid");

                    int transsales = objbs.inserttranswholesalesret(sTableName, salesid, Convert.ToInt32(drpItem.SelectedValue), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtTaxamount.Text), Convert.ToDouble(txtAmount.Text), Convert.ToInt32(txtid.Text));
                }

                string yourUrl = "WholeSalesReturnPrint.aspx?ISalesId=" + salesid;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                Refersh();

               

            }

        }


        protected void btncalc_OnClick(object sender, EventArgs e)
        {
            double TQty = 0; double Ttax = 0; double Tamount = 0; double NETamount = 0; 
            for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
            {
                #region

                TextBox txtqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtreturnqty");
                TextBox txtrate = (TextBox)GridView2.Rows[vLoop].FindControl("txtRate");
                TextBox txttax = (TextBox)GridView2.Rows[vLoop].FindControl("txttax");

                TextBox txtrettax = (TextBox)GridView2.Rows[vLoop].FindControl("txtrettax");
                TextBox txtretamount = (TextBox)GridView2.Rows[vLoop].FindControl("txtretamount");

                if (txtqty.Text == "")
                {
                    txtqty.Text = "0";
                }


                TQty += Convert.ToDouble(txtqty.Text);

                double amt = Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text);
                Tamount += amt;

                double taxamt = ((amt * Convert.ToDouble(txttax.Text)) / 100);
                Ttax += taxamt;

                double total = amt + taxamt;
                NETamount += total;

                txtrettax.Text = taxamt.ToString("f2");
                txtretamount.Text = total.ToString("f2");

               

                #endregion
            }

            #region

            txtgrandamount.Text = Tamount.ToString("f2");
            txtTaxamt.Text = Ttax.ToString("f2");
            txtgrandtotal.Text = NETamount.ToString("f2");


            lbltotalitems.InnerText = TQty.ToString("f2");

            double r;
            double roundoff = Convert.ToDouble(txtgrandtotal.Text) - Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            if (roundoff >= 0.5)
            {
                r = Math.Round(Convert.ToDouble(txtgrandtotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txtgrandtotal.Text));
            }
            lbldisplay.InnerText = string.Format("{0:N2}", r);
            #endregion


        }
        void Refersh()
        {
            #region

            txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

            DataSet dssalesNo = objbs.getcrsalesnoret(sTableName);
            txtbillno.Text = dssalesNo.Tables[0].Rows[0]["BillNo"].ToString();




            DataSet dsCustomer = objbs.getgridforcustsale();
            if (dsCustomer.Tables[0].Rows.Count > 0)
            {
                ddlcustomer.DataSource = dsCustomer.Tables[0];
                ddlcustomer.DataTextField = "CustomerName";
                ddlcustomer.DataValueField = "LedgerID";
                ddlcustomer.DataBind();
                ddlcustomer.Items.Insert(0, "Select Customer");


            }
            else
            {
                ddlcustomer.Items.Insert(0, "Select Customer");
            }


            #endregion

            chkbillno.Items.Clear();
            ddlcustomer.SelectedIndex = 0;
          //  ddlitem.SelectedIndex = 0;
            txtqty.Text = "0";
            txtrate.Text = "0";
            txttax.Text = "0";
            txttaxamount.Text = "0";
            txtamount.Text = "0";
            txtstock.Text = "0";

            txtgrandamount.Text = "0";
            txtTaxamt.Text = "0";
            txtgrandtotal.Text = "0";

            txtdiscamt.Text = "0";
            lbldisplay.InnerText = "0";

            GridView2.DataSource = null;
            GridView2.DataBind();

            ViewState["CurrentTable1"] = null;

        }

    }
}