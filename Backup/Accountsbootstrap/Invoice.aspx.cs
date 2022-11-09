using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using System.Configuration;
namespace Billing.Accountsbootstrap
{
    public partial class Invoice : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
            }

           
        }

        protected void gvOrder_DataBound(object sender, EventArgs e)
        {
           
        }
        private ArrayList GetDummyData()
        {
            ArrayList arr = new ArrayList();
            //arr.Add(new ListItem("Item1", "1"));
            //arr.Add(new ListItem("Item2", "2"));
            //arr.Add(new ListItem("Item3", "3"));
            //arr.Add(new ListItem("Item4", "4"));
            //arr.Add(new ListItem("Item5", "5"));
            return arr;
        }

        private void FillDropDownList(DropDownList ddl)
        {
            if (!IsPostBack)
            {
                ArrayList arr = GetDummyData();
                foreach (ListItem item in arr)
                {
                    ddl.Items.Add(item);
                }
            }
        }
        private void SetInitialRow()
        {
           
                DataTable dt = new DataTable();
                DataRow dr = null;

                //Define the Columns
                dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("Column1", typeof(string)));
                dt.Columns.Add(new DataColumn("Column2", typeof(string)));
                dt.Columns.Add(new DataColumn("Column3", typeof(string)));
                dt.Columns.Add(new DataColumn("Column4", typeof(string)));
                dt.Columns.Add(new DataColumn("Column5", typeof(string)));

                //Add a Dummy Data on Initial Load
                dr = dt.NewRow();
                dr["RowNumber"] = 1;
                dt.Rows.Add(dr);

                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dt;
                //Bind the DataTable to the Grid
                gvOrder.DataSource = dt;
                gvOrder.DataBind();

                //Extract and Fill the DropDownList with Data
                DropDownList ddlCategory = (DropDownList)gvOrder.Rows[0].Cells[1].FindControl("ddlCategory");
                //DropDownList ddl2 = (DropDownList)gvOrder.Rows[0].Cells[2].FindControl("DropDownList2");
                //DropDownList ddl3 = (DropDownList)gvOrder.Rows[0].Cells[3].FindControl("DropDownList3");
                FillDropDownList(ddlCategory);
                //FillDropDownList(ddl2);
                //FillDropDownList(ddl3);
            
        }
        protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
                DataSet dsCategory = objBs.selectcategorymaster();
                //else
                //    dsCategory = objBs.selectcategorymaster_Dealer("tblStock_" + sTableName);


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlCategory = (DropDownList)(e.Row.FindControl("ddlCategory") as DropDownList);
                    ddlCategory.DataSource = dsCategory.Tables[0];
                    ddlCategory.DataTextField = "category";
                    ddlCategory.DataValueField = "categoryid";
                    ddlCategory.DataBind();

                    DataSet dDef = objBs.selectcategoryalldecription();
                    DropDownList Def = (DropDownList)e.Row.FindControl("ddlItem");

                    Def.DataSource = dDef.Tables[0];
                    Def.DataTextField = "Definition";
                    Def.DataValueField = "categoryuserid";
                    Def.DataBind();
                }
            
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCategort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddlCategory.SelectedValue), "");
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                DropDownList Def = (DropDownList)row.FindControl("ddlItem");

                Def.DataSource = dsCategory.Tables[0];
                Def.DataTextField = "Definition";
                Def.DataValueField = "categoryuserid";
                Def.DataBind();


            }
        }
        private void AddNewRowToGrid()
        {
           
                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["CurrentTable"] = dtCurrentTable;

                        for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                        {
                            //extract the TextBox values
                            DropDownList ddCategory = (DropDownList)gvOrder.Rows[i].Cells[1].FindControl("ddlCategory");
                            DropDownList ddlDef = (DropDownList)gvOrder.Rows[i].Cells[2].FindControl("ddlItem");
                            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddCategory.SelectedValue), "");
                            if (dsCategory.Tables[0].Rows.Count > 0)
                            {
                                //DropDownList ddldef = (DropDownList)gvOrder.Rows[i].FindControl("ddlItem");

                                ddlDef.DataSource = dsCategory.Tables[0];
                                ddlDef.DataTextField = "Definition";
                                ddlDef.DataValueField = "categoryuserid";
                                ddlDef.DataBind();


                            }
                           
                            TextBox Qty = (TextBox)gvOrder.Rows[i].Cells[3].FindControl("txtQty");
                            TextBox Rate = (TextBox)gvOrder.Rows[i].Cells[4].FindControl("txtRate");
                            TextBox Amount = (TextBox)gvOrder.Rows[i].Cells[5].FindControl("txtAmount");


                            dtCurrentTable.Rows[i]["Column1"] = ddCategory.Text;
                            dtCurrentTable.Rows[i]["Column2"] = ddlDef.Text;
                            dtCurrentTable.Rows[i]["Column3"] = Qty.Text;
                            dtCurrentTable.Rows[i]["Column4"] = Rate.Text;
                            dtCurrentTable.Rows[i]["Column5"] = Amount.Text;

                            //rowIndex++;
                        }


                        gvOrder.DataSource = dtCurrentTable;
                        gvOrder.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                //Set Previous Data on Postbacks
                SetPreviousData();
            
        }
        private void SetPreviousData()
        {
            
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count - 1; i++)
                        {
                            DropDownList ddCategory = (DropDownList)gvOrder.Rows[i].Cells[1].FindControl("ddlCategory");
                            DropDownList ddlDef = (DropDownList)gvOrder.Rows[i].Cells[2].FindControl("ddlItem");
                            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddCategory.SelectedValue), "");
                            if (dsCategory.Tables[0].Rows.Count > 0)
                            {
                                //DropDownList ddldef = (DropDownList)gvOrder.Rows[i].FindControl("ddlItem");

                                ddlDef.DataSource = dsCategory.Tables[0];
                                ddlDef.DataTextField = "Definition";
                                ddlDef.DataValueField = "categoryuserid";
                                ddlDef.DataBind();


                            }
                            TextBox Qty = (TextBox)gvOrder.Rows[i].Cells[3].FindControl("txtQty");
                            TextBox Rate = (TextBox)gvOrder.Rows[i].Cells[4].FindControl("txtRate");
                            TextBox Amount = (TextBox)gvOrder.Rows[i].Cells[5].FindControl("txtAmount");

                            ddCategory.SelectedValue = dt.Rows[i]["Column1"].ToString();
                            ddlDef.SelectedValue = dt.Rows[i]["Column2"].ToString();
                            Qty.Text = dt.Rows[i]["Column3"].ToString();
                            Rate.Text = dt.Rows[i]["Column4"].ToString();
                            Amount.Text = dt.Rows[i]["Column5"].ToString();

                            //rowIndex++;
                        }
                    }
                }
            
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
          
                AddNewRowToGrid();
           
        }

        protected void gvOrder_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
           
        }

        protected void gvOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
                    gvOrder.DataSource = dt;
                    gvOrder.DataBind();

                    for (int i = 0; i < gvOrder.Rows.Count - 1; i++)
                    {
                        gvOrder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvOrder.Rows.Count; i++)
            {
                DropDownList ddcategory = (DropDownList)gvOrder.Rows[i].FindControl("ddlCategory");
                int icat = Convert.ToInt32(  ddcategory.SelectedValue);
                
                DropDownList ddldef = (DropDownList)gvOrder.Rows[i].FindControl("ddlItem");
                int idef = Convert.ToInt32(ddldef.SelectedValue);

                TextBox Qty = (TextBox)gvOrder.Rows[i].FindControl("txtQty");
                decimal dQty = Convert.ToDecimal(Qty.Text);

                TextBox Rate = (TextBox)gvOrder.Rows[i].FindControl("txtRate");
                double DRate = Convert.ToDouble(Rate.Text);

                TextBox Amount = (TextBox)gvOrder.Rows[i].FindControl("txtAmount");
                double dAmount = Convert.ToDouble(Amount.Text);


                int isave = objBs.testsales(icat, dQty, DRate, dAmount, idef);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (txtBillno.Text != "")
            {
                for (int i = 0; i < gvOrder.Rows.Count; i++)
                {
                    DropDownList ddcategory = (DropDownList)gvOrder.Rows[i].FindControl("ddlCategory");
                    DropDownList ddldef = (DropDownList)gvOrder.Rows[i].FindControl("ddlItem");                  
                    TextBox Qty = (TextBox)gvOrder.Rows[i].FindControl("txtQty");                  
                    TextBox Rate = (TextBox)gvOrder.Rows[i].FindControl("txtRate");
                    TextBox Amount = (TextBox)gvOrder.Rows[i].FindControl("txtAmount");
                     DataSet dVal = objBs.BindGrid(Convert.ToInt32(txtBillno.Text));
                    if (dVal.Tables[0].Rows.Count > 0)
                    {


                        ddcategory.SelectedValue = dVal.Tables[0].Rows[0]["CategoryID"].ToString();
                        DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddcategory.SelectedValue), "");
                        if (dsCategory.Tables[0].Rows.Count > 0)
                        {
                            //DropDownList ddldef = (DropDownList)gvOrder.Rows[i].FindControl("ddlItem");

                            ddldef.DataSource = dsCategory.Tables[0];
                            ddldef.DataTextField = "Definition";
                            ddldef.DataValueField = "categoryuserid";
                            ddldef.DataBind();


                        }
                        ddldef.SelectedValue = dVal.Tables[0].Rows[0]["SubCategoryID"].ToString(); 
                        Qty.Text=dVal.Tables[0].Rows[0]["Quantity"].ToString(); ;
                        Rate.Text=dVal.Tables[0].Rows[0]["UnitPrice"].ToString(); ;
                        Amount.Text = dVal.Tables[0].Rows[0]["Amount"].ToString(); 





                    }
                }

            }
        }

       
    }
}