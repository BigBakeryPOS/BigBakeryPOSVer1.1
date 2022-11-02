using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;
using BusinessLayer;
using System.Linq;

namespace Billing.Accountsbootstrap
{
    public partial class POForm : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grvPODetails.Visible = true;
                gvEditPODet.Visible = false;
            DataSet ds = objBs.pono();
            if (ds.Tables[0].Rows.Count > 0)
            {
                // int iBillNo = ds.Tables[0].Rows[0]["billno"].ToString();
                if (ds.Tables[0].Rows[0]["pono"].ToString() == "")
                    txtpono.Text = "1";
                else
                    txtpono.Text = ds.Tables[0].Rows[0]["pono"].ToString();

                txtpodate.Text = DateTime.Today.ToString("dd/MM/yyyy");


            }
           
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                DataSet dsRegistration = objBs.selectregformdet(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]));
                //lblcompanyname.Text = dsRegistration.Tables[0].Rows[0]["CompanyName"].ToString();
                //lbltinno.Text = dsRegistration.Tables[0].Rows[0]["TinNo"].ToString();
                FirstGridViewRow();


                string iPo = Request.QueryString.Get("iPo");

                if (iPo != null)
                {
                    grvPODetails.Visible = false;
                    gvEditPODet.Visible = true;
                    DataSet ds1 = objBs.GetPOUpdateQry(iPo);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        int i = 0;
                        btnSave.Text = "Exit";
                        txtcompanyname.Text = ds1.Tables[0].Rows[0]["CompanyName"].ToString();
                        txttoaddr.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        txtpodate.Text = ds1.Tables[0].Rows[0]["PODate"].ToString();
                        txtpono.Text = ds1.Tables[0].Rows[0]["pono"].ToString();
                        txttinno.Text = ds1.Tables[0].Rows[0]["TinNo"].ToString();
                        txttotal.Text = ds1.Tables[0].Rows[0]["TotalAmount"].ToString();
                        //TextBox txtitemnames = (TextBox)grvPODetails.Rows[i].Cells[1].FindControl("txtitemname");
                        //TextBox txtpoQtys = (TextBox)grvPODetails.Rows[i].Cells[2].FindControl("txtpoQty");
                        //TextBox txtrateQtys = (TextBox)grvPODetails.Rows[i].Cells[3].FindControl("txtrateQty");
                        //TextBox txtdiss = (TextBox)grvPODetails.Rows[i].Cells[4].FindControl("txtdis");
                        //TextBox txtdisamts = (TextBox)grvPODetails.Rows[i].Cells[5].FindControl("txtdisamt");
                        //TextBox txtamts = (TextBox)grvPODetails.Rows[i].Cells[6].FindControl("txtamt");
                        DataSet dsPODet = objBs.GetPODetUpdateQry(iPo);
                        if (dsPODet.Tables[0].Rows.Count > 0)
                        {

                            gvEditPODet.DataSource = dsPODet;
                            gvEditPODet.DataBind();
                        }
                    }

                }

            }
        }
        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
            dr["Col5"] = string.Empty;
            dr["Col6"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["tbltransPO"] = dt;


            grvPODetails.DataSource = dt;
            grvPODetails.DataBind();


            TextBox txn = (TextBox)grvPODetails.Rows[0].Cells[1].FindControl("txtitemname");
            txn.Focus();
            Button btnAdd = (Button)grvPODetails.FooterRow.Cells[6].FindControl("ButtonAdd");
            Page.Form.DefaultFocus = btnAdd.ClientID;

        }
        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["tbltransPO"] != null)
            {
                DataTable dttbltransPO = (DataTable)ViewState["tbltransPO"];
                DataRow drCurrentRow = null;
                if (dttbltransPO.Rows.Count > 0)
                {
                    for (int i = 1; i <= dttbltransPO.Rows.Count; i++)
                    {
                        TextBox txtitemname = (TextBox)grvPODetails.Rows[rowIndex].Cells[1].FindControl("txtitemname");
                        TextBox txtpoQty = (TextBox)grvPODetails.Rows[rowIndex].Cells[2].FindControl("txtpoQty");
                        TextBox txtrateQty = (TextBox)grvPODetails.Rows[rowIndex].Cells[3].FindControl("txtrateQty");
                        TextBox txtdis = (TextBox)grvPODetails.Rows[rowIndex].Cells[4].FindControl("txtdis");
                        TextBox txtdisamt = (TextBox)grvPODetails.Rows[rowIndex].Cells[5].FindControl("txtdisamt");
                        TextBox txtamt = (TextBox)grvPODetails.Rows[rowIndex].Cells[6].FindControl("txtamt");
                        drCurrentRow = dttbltransPO.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dttbltransPO.Rows[i - 1]["Col1"] = txtitemname.Text;
                        dttbltransPO.Rows[i - 1]["Col2"] = txtpoQty.Text;
                        dttbltransPO.Rows[i - 1]["Col3"] = txtrateQty.Text;
                        dttbltransPO.Rows[i - 1]["Col4"] = txtdis.Text;
                        dttbltransPO.Rows[i - 1]["Col5"] = txtdisamt.Text;
                        dttbltransPO.Rows[i - 1]["Col6"] = txtamt.Text;
                        rowIndex++;
                    }
                    dttbltransPO.Rows.Add(drCurrentRow);
                    ViewState["tbltransPO"] = dttbltransPO;

                    grvPODetails.DataSource = dttbltransPO;
                    grvPODetails.DataBind();

                    TextBox txn = (TextBox)grvPODetails.Rows[rowIndex].Cells[1].FindControl("txtitemname");
                    txn.Focus();
                    // txn.Focus;
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
            if (ViewState["tbltransPO"] != null)
            {
                DataTable dt = (DataTable)ViewState["tbltransPO"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtitemname = (TextBox)grvPODetails.Rows[rowIndex].Cells[1].FindControl("txtitemname");
                        TextBox txtpoQty = (TextBox)grvPODetails.Rows[rowIndex].Cells[2].FindControl("txtpoQty");
                        TextBox txtrateQty = (TextBox)grvPODetails.Rows[rowIndex].Cells[3].FindControl("txtrateQty");
                        TextBox txtdis = (TextBox)grvPODetails.Rows[rowIndex].Cells[4].FindControl("txtdis");
                        TextBox txtdisamt = (TextBox)grvPODetails.Rows[rowIndex].Cells[5].FindControl("txtdisamt");
                        TextBox txtamt = (TextBox)grvPODetails.Rows[rowIndex].Cells[6].FindControl("txtamt");

                        // drCurrentRow["RowNumber"] = i + 1;

                        grvPODetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                        txtitemname.Text = dt.Rows[i]["Col1"].ToString();
                        txtpoQty.Text = dt.Rows[i]["Col2"].ToString();
                        txtrateQty.Text = dt.Rows[i]["Col3"].ToString();
                        txtdis.Text = dt.Rows[i]["Col4"].ToString();
                        txtdisamt.Text = dt.Rows[i]["Col5"].ToString();
                        txtamt.Text = dt.Rows[i]["Col6"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        protected void grvPODetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["tbltransPO"] != null)
            {
                DataTable dt = (DataTable)ViewState["tbltransPO"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["tbltransPO"] = dt;
                    grvPODetails.DataSource = dt;
                    grvPODetails.DataBind();

                    for (int i = 0; i < grvPODetails.Rows.Count - 1; i++)
                    {
                        grvPODetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }


        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["tbltransPO"] != null)
            {
                DataTable dttbltransPO = (DataTable)ViewState["tbltransPO"];
                DataRow drCurrentRow = null;
                if (dttbltransPO.Rows.Count > 0)
                {
                    for (int i = 1; i <= dttbltransPO.Rows.Count; i++)
                    {

                        TextBox txtitemname = (TextBox)grvPODetails.Rows[rowIndex].Cells[1].FindControl("txtitemname");
                        TextBox txtpoQty = (TextBox)grvPODetails.Rows[rowIndex].Cells[2].FindControl("txtpoQty");
                        TextBox txtrateQty = (TextBox)grvPODetails.Rows[rowIndex].Cells[3].FindControl("txtrateQty");
                        TextBox txtdis = (TextBox)grvPODetails.Rows[rowIndex].Cells[4].FindControl("txtdis");
                        TextBox txtdisamt = (TextBox)grvPODetails.Rows[rowIndex].Cells[5].FindControl("txtdisamt");
                        TextBox txtamt = (TextBox)grvPODetails.Rows[rowIndex].Cells[6].FindControl("txtamt");
                        drCurrentRow = dttbltransPO.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dttbltransPO.Rows[i - 1]["Col1"] = txtitemname.Text;
                        dttbltransPO.Rows[i - 1]["Col2"] = txtpoQty.Text;
                        dttbltransPO.Rows[i - 1]["Col3"] = txtrateQty.Text;
                        dttbltransPO.Rows[i - 1]["Col4"] = txtdis.Text;
                        dttbltransPO.Rows[i - 1]["Col5"] = txtdisamt.Text;
                        dttbltransPO.Rows[i - 1]["Col6"] = txtamt.Text;

                        rowIndex++;
                    }

                    ViewState["tbltransPO"] = dttbltransPO;
                  
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int iStatus = 0;
                int iDet = 0;

                SetRowData();
                // DataSet ipoid = objBs.POId();
                iStatus = objBs.InsertPOdatas(txtcompanyname.Text, txttoaddr.Text, txttinno.Text, txtpodate.Text, Convert.ToInt32(txttotal.Text), Convert.ToInt32(txtpono.Text));

                DataTable table = ViewState["tbltransPO"] as DataTable;

                if (table != null)
                {
                    for (int i = 0; i < grvPODetails.Rows.Count; i++)
                    {
                        TextBox txtitemnames = (TextBox)grvPODetails.Rows[i].Cells[1].FindControl("txtitemname");
                        TextBox txtpoQtys = (TextBox)grvPODetails.Rows[i].Cells[2].FindControl("txtpoQty");
                        TextBox txtrateQtys = (TextBox)grvPODetails.Rows[i].Cells[3].FindControl("txtrateQty");
                        TextBox txtdiss = (TextBox)grvPODetails.Rows[i].Cells[4].FindControl("txtdis");
                        TextBox txtdisamts = (TextBox)grvPODetails.Rows[i].Cells[5].FindControl("txtdisamt");
                        TextBox txtamts = (TextBox)grvPODetails.Rows[i].Cells[6].FindControl("txtamt");


                        iDet = objBs.InsertPODet(Convert.ToInt32(txtpono.Text), txtitemnames.Text, txtpoQtys.Text, txtrateQtys.Text, txtdiss.Text, txtdisamts.Text, txtamts.Text);



                        Response.Redirect("POGrid.aspx");

                    }
                }
            }
            else
            {
                Response.Redirect("POGrid.aspx");
            }

        }
 

           
      

        


        protected void txtdisamt_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
           
            decimal dAmt = 0;
            //float Ipercent = 0;
           
            for ( i = 0; i < grvPODetails.Rows.Count ; i++)
            {
                TextBox txtpoQty = (TextBox)grvPODetails.Rows[i].Cells[2].FindControl("txtpoQty");
                TextBox txtrateQty = (TextBox)grvPODetails.Rows[i].Cells[3].FindControl("txtrateQty");
                TextBox txtdis = (TextBox)grvPODetails.Rows[i].Cells[4].FindControl("txtdis");
                TextBox txtdisamt = (TextBox)grvPODetails.Rows[i].Cells[5].FindControl("txtdisamt");
                TextBox txtamt = (TextBox)grvPODetails.Rows[i].Cells[6].FindControl("txtamt");

                int IQty = Convert.ToInt32(txtpoQty.Text);
                int IRate = Convert.ToInt32(txtrateQty.Text);
                int IDiscamt = Convert.ToInt32(txtdisamt.Text);


                Decimal ICalc = 0;

                ICalc = IQty * IRate - IDiscamt;
                
                //Ipercent = (100 / Convert.ToInt32(IDiscamt));

               // dAmt += ICalc;
                txtamt.Text = Convert.ToString(ICalc);
                dAmt += ICalc;
                txttotal.Text =Convert.ToString( dAmt);
            }
           
        }

        protected void grvPODetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}