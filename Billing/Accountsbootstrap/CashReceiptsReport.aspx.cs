using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class CashReceiptsReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = "";
        double ttlNetAmount = 0; double ttlCloseDiscount = 0; 

        double netTotal = 0;
        double NetAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                DataSet ds1 = objbs.getrecptnumber(sTableName);
               
                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                DataSet dspaymode = objbs.getpaymoderecNew();               
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlpay.DataSource = dspaymode.Tables[0];
                    ddlpay.DataTextField = "PayMode";
                    ddlpay.DataValueField = "PayModeId";
                    ddlpay.DataBind();
                    ddlpay.Items.Insert(0, "All");

                }
                DataSet dss = new DataSet();
                dss = objbs.getcustomer();
                if (dss.Tables[0].Rows.Count > 0)
                {                  
                    ddlcustomerrep.DataSource = dss.Tables[0];
                    ddlcustomerrep.DataTextField = "CustomerName";
                    ddlcustomerrep.DataValueField = "LedgerID";
                    ddlcustomerrep.DataBind();
                    ddlcustomerrep.Items.Insert(0, "All");
                }                
            }

        }           

        protected void gvreceiptamt_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ttlNetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                ttlCloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[6].Text = "Total :";
                e.Row.Cells[7].Text = ttlNetAmount.ToString("f2");
                e.Row.Cells[8].Text = ttlCloseDiscount.ToString("f2");
            }

        }
      

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "print")
            {

                string yourUrl = "CashReceipt.aspx?ReceiptID=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

            }
        }  

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = new DataSet();
            if (ddltype.SelectedValue == "1")
            {
                 ds = objbs.getreceiptrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlpay.SelectedValue, lblreceipttype.Text);
            }
            else
            {
                 ds = objbs.getreceiptrecorddetail(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlpay.SelectedValue, lblreceipttype.Text);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = null;
                gridview.DataBind();
            }


            gridview.Caption = "Receipt Report";

            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=ReceiptReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }

        protected void btnsearch_OnClick(object sender, EventArgs e)
        {
            //DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
            //DateTime sTo = Convert.ToDateTime(txttodate.Text);

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = new DataSet();
            if (ddltype.SelectedValue == "1")
            {
                 ds = objbs.getreceiptrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlpay.SelectedValue, lblreceipttype.Text);
            }
            else
            {
                ds = objbs.getreceiptrecorddetail(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlpay.SelectedValue, lblreceipttype.Text);
            }

           
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvreceiptamt.DataSource = ds;
                gvreceiptamt.DataBind();
            }
            else
            {
                gvreceiptamt.DataSource = null;
                gvreceiptamt.DataBind();
            }
        }



        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        private void clearall()
        {
            //txtname.Text = "";
            //txtmobile.Text = "";
            //txtemail.Text = "";
            //txtaddress.Text = "";
            //txtdob.Text = "";

        }
        protected void txtpaid_changed(object sender, EventArgs e)
        {
            //Label txttrans = (Label)gv.Rows[vLoop].FindControl("lbltrans");
            //string id = txttrans.Text;
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;

            Label txt = (Label)currentRow.FindControl("lbltrans");
            string id = txt.Text;

        }
        protected void gv_selectedindex(object sender, EventArgs e)
        {

            //if (gv.SelectedDataKey.Value != null && gv.SelectedDataKey.Value.ToString() != "")
            //    id = Convert.ToInt32(gv.SelectedDataKey.Value.ToString());
            //{
            //    DataSet dedit = new DataSet();

            //    dedit = objbs.selectcustomer(id);
            //    if (dedit.Tables[0].Rows.Count > 0)
            //    {
            //        ddlcontacttype.SelectedValue = dedit.Tables[0].Rows[0]["contacttypeid"].ToString();
            //        txtid.Text = dedit.Tables[0].Rows[0]["id"].ToString();
            //        txtname.Text = dedit.Tables[0].Rows[0]["Customername"].ToString();
            //        txtmobile.Text = dedit.Tables[0].Rows[0]["Mobile"].ToString();
            //        txtaddress.Text = dedit.Tables[0].Rows[0]["address"].ToString();
            //        txtemail.Text = dedit.Tables[0].Rows[0]["Email"].ToString();
            //        txtdob.Text = dedit.Tables[0].Rows[0]["dob"].ToString();
            //        btnSubmit.Text = "Update";
            //    }


            //}
        }

    }
}