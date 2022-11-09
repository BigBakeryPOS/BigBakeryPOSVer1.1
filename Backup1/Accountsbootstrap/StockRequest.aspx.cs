using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class StockRequest : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string scode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
           
            if (!IsPostBack)
            {
                FirstGridViewRow();
                DataSet dReqNo = objBs.ReqNo(Convert.ToInt32(lblUserID.Text),scode);
                if (dReqNo.Tables[0].Rows.Count > 0)
                {
                    if (dReqNo.Tables[0].Rows[0]["RequestNo"].ToString() != "")
                    {
                        txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();
                    }
                    else
                    {
                        txtpono.Text = "1";
                    }
                }
                else
                {
                    txtpono.Text = "1";
                }
                txtpodate.Text = DateTime.Now.ToShortDateString();

                DataSet dsCustomer = objBs.GetVendorName();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlvendor.DataSource = dsCustomer.Tables[0];
                    ddlvendor.DataTextField = "CustomerName";
                    ddlvendor.DataValueField = "CustomerID";
                    ddlvendor.DataBind();
                    ddlvendor.Items.Insert(0, "Select Vendor");
                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                }
               

            }
        }
        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gvcustomerorder.DataSource = dt;
                    gvcustomerorder.DataBind();

                    for (int i = 0; i < gvcustomerorder.Rows.Count - 1; i++)
                    {
                        gvcustomerorder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            {
                SetRowData();
                DataTable table = ViewState["CurrentTable"] as DataTable;

                if (table != null)
                {
                    int isave = objBs.insertPurchaseReq(Convert.ToInt32(ddlvendor.SelectedValue), txtpono.Text, txtpodate.Text, "Requset Sent", 0, sTableName,  0, Convert.ToInt32(lblUserID.Text),"",scode);

                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                        if (txtQty.Text != "0")
                        {
                            DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlCategory");
                            DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                           
                            TextBox tt = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlUnits");
                            string sUnits = dd.SelectedItem.Text;
                           // int iSAve = objBs.insertTransPurchaseReq(txtpono.Text, Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlDef), Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text),0,scode);
                        }
                    }
                }
            }
        }
        protected void btnnew_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }


        protected void ddlvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsAddress = objBs.GetAddress(Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsAddress.Tables[0].Rows.Count > 0)
            {
                txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
                //DropDownList ddl = (DropDownList)sender;
                //GridViewRow row = (GridViewRow)ddl.NamingContainer;
                //DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
                //ddlCategory.Focus();
            }
        }
        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("sno", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            
            dr = dt.NewRow();
            dr["sno"] = 1;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
           
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;


            gvcustomerorder.DataSource = dt;
            gvcustomerorder.DataBind();


            //TextBox txn = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtName");
            //txn.Focus();
            //Button btnAdd = (Button)grvStudentDetails.FooterRow.Cells[5].FindControl("ButtonAdd");
            //Page.Form.DefaultFocus = btnAdd.ClientID;

        }
        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");

                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("ddlUnits");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Col1"] = ddlCategory.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = ddlDef.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = ddlunits.Text;
                       
                        rowIndex++;
                        ddlCategory.Focus();
                        ddlCategory.Enabled = true;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvcustomerorder.DataSource = dtCurrentTable;
                    gvcustomerorder.DataBind();

                    //TextBox txn = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                    //txn.Focus();
                    //// txn.Focus;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("ddlUnits");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Col1"] = ddlCategory.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = ddlDef.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = ddlunits.Text;
                        
                        rowIndex++;
                        ddlCategory.Focus();
                        ddlCategory.Enabled = true;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void ddlCategort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");

            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddlCategory.SelectedValue), sTableName);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                DropDownList Def = (DropDownList)row.FindControl("ddlDef");
                //Label lblCatID = (Label)row.FindControl("catid");
                //lblCatID.Text = dsCategory.Tables[0].Rows[0]["CategoryID"].ToString();
                Def.DataSource = dsCategory.Tables[0];
                Def.DataTextField = "Definition";
                Def.DataValueField = "categoryuserid";
                Def.DataBind();

                ddlCategory.Focus();
            }
           update.Update();
           
            
        }

        protected void ddlDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");

            DropDownList Def = (DropDownList)row.FindControl("ddlDef");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            DataSet dsCategory = objBs.getCatID(Convert.ToInt32(Def.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {

                Label lblCatID = (Label)row.FindControl("catid1");
                lblCatID.Text = dsCategory.Tables[0].Rows[0]["CategoryID"].ToString();


                Def.Focus();
            }

           
           update.Update();
        }

        protected void gvcustomerorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objBs.selectcategorymaster();
            //else
            //    dsCategory = objBs.selectcategorymaster_Dealer("tblStock_" + sTableName);


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCategory = (DropDownList)(e.Row.FindControl("ddlCategory") as DropDownList);
                ddlCategory.Focus();
                ddlCategory.Enabled = true;
                ddlCategory.DataSource = dsCategory.Tables[0];
                ddlCategory.DataTextField = "category";
                ddlCategory.DataValueField = "categoryid";
                ddlCategory.DataBind();

                DataSet dDef = objBs.selectcategoryalldecription();
                DropDownList Def = (DropDownList)e.Row.FindControl("ddlDef");

                Def.DataSource = dDef.Tables[0];
                Def.DataTextField = "Definition";
                Def.DataValueField = "categoryuserid";
                Def.DataBind();
            }

        }

        protected void txtdefCatID_TextChanged(object sender, EventArgs e)
        {



            //TextBox txt = (TextBox)sender;
            //GridViewRow row = (GridViewRow)txt.NamingContainer;
            //TextBox Qty = (TextBox)row.FindControl("txtQty");
            //decimal dQty = Convert.ToDecimal(Qty.Text);

            //TextBox Rate = (TextBox)row.FindControl("txtRate");
            //decimal DRate = Convert.ToDecimal(Rate.Text);

            //TextBox Amount = (TextBox)row.FindControl("txtAmount");
            //decimal dAmount = 0;

            //dAmount = dQty * DRate;
            //Amount.Text = dAmount.ToString("f2");
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlCategory");

                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("ddlDef");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("ddlUnits");
                        // drCurrentRow["RowNumber"] = i + 1;

                        gvcustomerorder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                        ddlCategory.Text = dt.Rows[i]["Col1"].ToString();
                        ddlDef.Text = dt.Rows[i]["Col2"].ToString();
                        txtQty.Text = dt.Rows[i]["Col3"].ToString();

                        ddlunits.Text = dt.Rows[i]["Col4"].ToString();
                        rowIndex++;
                        ddlCategory.Focus();
                        ddlCategory.Enabled = true;
                    }
                }
            }
        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {
             SetRowData();
                DataTable table = ViewState["CurrentTable"] as DataTable;

                if (table != null)
                {
                    if (ddlvendor.Text == "Select Vendor")
                    {
                        Error.InnerText = "Select Vendor";
                    }
                    else
                    {
                        DateTime Date = Convert.ToDateTime(txtpodate.Text);
                        string sDate = Date.ToString("yyyy-MM-dd");
                        int isave = objBs.insertPurchaseReq(Convert.ToInt32(ddlvendor.SelectedValue), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text),"",scode);

                        for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                        {
                            TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            if (txtQty.Text != "0")
                            {
                                DropDownList ddlCategory = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlCategory");
                                DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");

                                TextBox tt = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                                decimal dTextBox = Convert.ToDecimal(tt.Text);
                                DropDownList dd = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlUnits");
                                string sUnits = dd.SelectedItem.Text;
                                //int iSAve = objBs.insertTransPurchaseReq(txtpono.Text, Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlDef.SelectedValue), Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0,scode);
                            }
                        }
                        Response.Redirect("PurchaseRequestGrid.aspx");
                    }
                }

                
            }

     
        }
    }
