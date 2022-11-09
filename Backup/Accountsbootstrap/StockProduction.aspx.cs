using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Text;
namespace Billing
{  
    public partial class StockProduction : System.Web.UI.Page
    {string sTableName = "";
        BSClass objBs = new BSClass();
        DataTable dt= new DataTable();
        public static int SubcatID;
        DataTable dCrt;
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (!IsPostBack)
            {
               

                dt.Columns.Add("CatID");
                dt.Columns.Add("SubCatID");
                
                dt.Columns.Add("category");
                dt.Columns.Add("item");
                dt.Columns.Add("OrderQty");

                ViewState["Datatable"] = dt;

                //DataSet dStore = objBs.GetStores(Convert.ToInt32(lblUserID.Text), sTableName);
                //ddlStore.DataSource = dStore.Tables[0];
                //ddlStore.DataTextField = "Branch";
                //ddlStore.DataValueField = "UserID";
                //ddlStore.DataBind();
                //ddlStore.Items.Insert(0, "Select Store");

                DataSet dsCategory = new DataSet();
                dsCategory = objBs.selectCAT();
                ddlCategory.DataTextField = "category";
                ddlCategory.DataValueField = "categoryid";
                ddlCategory.DataSource = dsCategory.Tables[0];
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "select");



                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //string script = "$(document).ready(function () { $('[id*=btnadd]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);



                DataSet dReqNo = objBs.ReqNo(Convert.ToInt32(lblUserID.Text), sCode);
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
                
                //else
                //{
                //     dReqNo = objbs.GetMaxProdNo2();
                //}
               
                txtdate.Text = DateTime.Now.ToString();

                DataSet dsCustomer = objBs.GetVendorName();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlStore.DataSource = dsCustomer.Tables[0];
                    ddlStore.DataTextField = "CustomerName";
                    ddlStore.DataValueField = "CustomerID";
                    ddlStore.DataBind();
                    ddlStore.SelectedValue = "308";
                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                }
                DataSet dsAddress = objBs.GetAddress(Convert.ToInt32(308));
                if (dsAddress.Tables[0].Rows.Count > 0)
                {
                    //txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
                }



            }



        }
        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dstock = objBs.GetStoresStock((ddlStore.SelectedValue));

            if (dstock.Tables[0].Rows.Count > 0)
            {
                


            }
        }

        protected void ddlcat_selectedindexchanged(object s, EventArgs e)
        {
            DataSet dDef = objBs.selectcategorydecription(Convert.ToInt32(ddlCategory.SelectedValue), sTableName);
            ddlitem.DataTextField = "Definition";
            ddlitem.DataValueField = "categoryuserid";
            ddlitem.DataSource = dDef.Tables[0];
            ddlitem.DataBind();
            ddlitem.Items.Insert(0, "select");
            ddlitem.Focus();
        }
        protected void dditem_selectedindexchanged(object s, EventArgs e)
        {
            

            txtOrderQty.Focus();
        }

        protected void add_click(object s, EventArgs e)
        {
            dCrt = (DataTable)ViewState["Datatable"];
            if (dCrt.Rows.Count == 0)
            {
                DataRow dr = dCrt.NewRow();
                dr["CatID"] = ddlCategory.SelectedValue;
                dr["SubCatID"] = ddlitem.SelectedValue;
               
                dr["Category"] = ddlCategory.SelectedItem.Text;
                dr["item"] = ddlitem.SelectedItem.Text;
                dr["OrderQty"] = txtOrderQty.Text;
                dCrt.Rows.Add(dr);




            }
            else
            {
                DataRow dr = dCrt.NewRow();
                dr["CatID"] = ddlCategory.SelectedValue;
                dr["SubCatID"] = ddlitem.SelectedValue;
               
                dr["Category"] = ddlCategory.SelectedItem.Text;
                dr["item"] = ddlitem.SelectedItem.Text;
                dr["OrderQty"] = txtOrderQty.Text;
                dCrt.Rows.Add(dr);


            }
            ViewState["Firstrow"] = dCrt;
            gvItems.DataSource = dCrt;
            gvItems.DataBind();

           
            txtOrderQty.Text = "";
            ddlCategory.Focus();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dat = ViewState["Firstrow"] as DataTable;
            dat.Rows[index].Delete();
            ViewState["Firstrow"] = dat;
            ViewState["Datatable"] = dat;
            gvItems.DataSource = dat;
            gvItems.DataBind();

            dCrt = dat;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[5].Text;
                foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "confitm('Request will Be sent');", true);

            int iStockSuccess = 0;

            DateTime Date = Convert.ToDateTime(txtdate.Text);
            string sDate = Date.ToString("yyyy-MM-dd h:mm tt");
            if (txtOrderBy.Text == "")
                txtOrderBy.Text = "No Name";
            int isave = objBs.insertPurchaseReq(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sCode);
            //  DataTable dCrt = (DataTable)ViewState["Firstrow"];

            if (gvItems.Rows.Count > 0)
            {
                for (int i = 0; i < gvItems.Rows.Count; i++)
                {
                    string sUnits = "Nos";
                    int iCatID = Convert.ToInt32(gvItems.Rows[i].Cells[1].Text);
                    int iSubCatID = Convert.ToInt32(gvItems.Rows[i].Cells[2].Text);


                    decimal dExtQty = Convert.ToDecimal(gvItems.Rows[i].Cells[5].Text);

                    int iSAve = objBs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dExtQty), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");



                }


                Response.Redirect("PurchaseRequestGrid.aspx");





            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Add Item to the list');", true);
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");

        }
    }
}