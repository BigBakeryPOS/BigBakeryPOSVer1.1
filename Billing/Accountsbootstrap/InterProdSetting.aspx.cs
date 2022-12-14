using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class InterProdSetting : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Interid ASC";
        string sTableName = "";
        string superadmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.gridinterprodsetting();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                DataSet dsbranch = objBs.getbranchFilling("2");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpstorebranch.DataSource = dsbranch.Tables[0];
                    drpstorebranch.DataTextField = "BranchArea";
                    drpstorebranch.DataValueField = "BranchId";
                    drpstorebranch.DataBind();
                    drpstorebranch.Items.Insert(0, "Select Store");


                    chkinterbranch.DataSource = dsbranch.Tables[0];
                    chkinterbranch.DataTextField = "BranchArea";
                    chkinterbranch.DataValueField = "BranchId";
                    chkinterbranch.DataBind();
                }



            }
        }

        protected void Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            // Response.Redirect("categorymaster.aspx");
        }

        protected void storebranchchange(object sender, EventArgs e)
        {
            DataSet dsbranch = objBs.getbranchFilling("2");
            if (dsbranch.Tables[0].Rows.Count > 0)
            {

                chkinterbranch.DataSource = dsbranch.Tables[0];
                chkinterbranch.DataTextField = "BranchArea";
                chkinterbranch.DataValueField = "BranchId";
                chkinterbranch.DataBind();
            }


            for (int i = 0; i < chkinterbranch.Items.Count; i++)
            {
                if (chkinterbranch.Items[i].Value == drpstorebranch.SelectedValue)
                {
                    chkinterbranch.Items.RemoveAt(i);
                }
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("InterprodSetting.aspx");
        }
        protected void Btn_Search(object sender, EventArgs e)
        {

        }

        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                string iCat = e.CommandArgument.ToString();

                if (iCat != "" || iCat != null)
                {

                    DataSet dsbranch = objBs.getbranchFilling("2");
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        drpstorebranch.DataSource = dsbranch.Tables[0];
                        drpstorebranch.DataTextField = "BranchArea";
                        drpstorebranch.DataValueField = "BranchId";
                        drpstorebranch.DataBind();
                        drpstorebranch.Items.Insert(0, "Select Store");

                        chkinterbranch.DataSource = dsbranch.Tables[0];
                        chkinterbranch.DataTextField = "BranchArea";
                        chkinterbranch.DataValueField = "BranchId";
                        chkinterbranch.DataBind();

                    }




                    DataSet ds = objBs.getupdateinterprodsettingforid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";

                        drpstorebranch.SelectedValue = ds.Tables[0].Rows[0]["Prodid"].ToString();

                        for (int i = 0; i < chkinterbranch.Items.Count; i++)
                        {
                            if (chkinterbranch.Items[i].Value == drpstorebranch.SelectedValue)
                            {
                                chkinterbranch.Items.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            {
                                //Find the checkbox list items using FindByValue and select it.
                                chkinterbranch.Items.FindByValue(ds.Tables[0].Rows[i]["InterBranchid"].ToString()).Selected = true;
                            }
                        }

                        txtinterprodid.Text = ds.Tables[0].Rows[0]["InterProdid"].ToString();
                        drpstorebranch.Enabled = false;
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteinterProdsetting(e.CommandArgument.ToString());
                    Response.Redirect("InterprodSetting.aspx");
                }
            }

        }


        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GVStockAlert_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }



        protected void GVStockAlert_RowDataBound()
        {

        }
        public SortDirection dir
        {

            get
            {

                if (ViewState["dirState"] == null)
                {

                    ViewState["dirState"] = SortDirection.Ascending;

                }

                return (SortDirection)ViewState["dirState"];

            }

            set
            {

                ViewState["dirState"] = value;

            }

        }

        protected void gridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (superadmin == "1" || sTableName == "Pro")
            //    {
            //        ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
            //        ((LinkButton)e.Row.FindControl("btndel")).Enabled = true;

            //        ((Image)e.Row.FindControl("imdedit")).Enabled = true;
            //        ((Image)e.Row.FindControl("Image1")).Enabled = true;
            //    }
            //    else
            //    {
            //        ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
            //        ((LinkButton)e.Row.FindControl("btndel")).Visible = false;

            //        ((Image)e.Row.FindControl("imdedit")).Enabled = false;
            //        ((Image)e.Row.FindControl("Image1")).Visible = false;

            //        ((Image)e.Row.FindControl("imgdisable1321")).Enabled = false;
            //        ((Image)e.Row.FindControl("imgdisable1321")).Visible = true;
            //    }

            //}
            //else
            //{

            //}

        }



        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }

            DataSet ds = objBs.gridinterprodsetting();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterprodSetting.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.duplicateprodintersettingcheck(drpstorebranch.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Inter Prod/Store Setting has already Exists please enter a new one";

                }
                else
                {
                    int iStatus = objBs.InsertinterprodSetting(drpstorebranch.SelectedValue, drpstorebranch.SelectedItem.Text);
                    foreach (ListItem item in chkinterbranch.Items)
                    {
                        if (item.Selected)
                        {

                            objBs.Inserttransprodsetting(item.Value, item.Text, "0");
                        }
                    }

                    Response.Redirect("../Accountsbootstrap/InterprodSetting.aspx");
                }
            }
            else
            {
                int iss = 0;
                iss = objBs.deleteinterbranch(txtinterprodid.Text);

                foreach (ListItem item in chkinterbranch.Items)
                {
                    if (item.Selected)
                    {

                        objBs.Inserttransprodsetting(item.Value, item.Text, txtinterprodid.Text);
                    }
                }
                Response.Redirect("InterProdSetting.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}
