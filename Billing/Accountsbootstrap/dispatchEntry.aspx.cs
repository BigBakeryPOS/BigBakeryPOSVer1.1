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
    public partial class dispatchEntry : System.Web.UI.Page
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

                DataSet dsgrid = objBs.grdidispatchentryload(sTableName);
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                // GET MAX DISPATCH NO

                DataSet getdispatchno = objBs.gridmaxno_dispatch(sTableName);
                if (getdispatchno.Tables[0].Rows.Count > 0)
                {
                    txtdispatchno.Text = getdispatchno.Tables[0].Rows[0]["dispatch"].ToString();
                }

                // get vehicle no
                DataSet dsgetvehicle = objBs.GET_vehicle_load();
                if (dsgetvehicle.Tables[0].Rows.Count > 0)
                {


                    drpvehicleno.DataSource = dsgetvehicle.Tables[0];
                    drpvehicleno.DataTextField = "VehicleNumber";
                    drpvehicleno.DataValueField = "VehicleID";
                    drpvehicleno.DataBind();
                    drpvehicleno.Items.Insert(0, "Select Vehicle");
                }

                DataSet dsloademp = objBs.getallempandsupp("1017");
                if (dsloademp.Tables[0].Rows.Count > 0)
                {


                    drpemployee.DataSource = dsloademp.Tables[0];
                    drpemployee.DataTextField = "customername";
                    drpemployee.DataValueField = "Ledgerid";
                    drpemployee.DataBind();
                    drpemployee.Items.Insert(0, "Select Employee");
                }


                //DataSet dsbranch = objBs.getbranchFilling("0");
                //if (dsbranch.Tables[0].Rows.Count > 0)
                //{
                   

                //    chkinterbranch.DataSource = dsbranch.Tables[0];
                //    chkinterbranch.DataTextField = "BranchArea";
                //    chkinterbranch.DataValueField = "BranchId";
                //    chkinterbranch.DataBind();
                //}

                // Get all goods received no

                DataSet alldispatchno = objBs.getalldispatchno(sTableName);
                if (alldispatchno.Tables[0].Rows.Count > 0)
                {
                    chkgrnno.DataSource = alldispatchno.Tables[0];
                    chkgrnno.DataTextField = "name";
                    chkgrnno.DataValueField = "value";
                    chkgrnno.DataBind();
                }
                else
                {
                    chkgrnno.DataSource = null;
                    chkgrnno.DataBind();
                }


                DataSet alltransircakeorder = objBs.getodersummaryonlytransitdetails(sTableName,"4","All");
                if (alltransircakeorder.Tables.Count > 0)
                {
                    if (alltransircakeorder.Tables[0].Rows.Count > 0)
                    {
                        chkordercake.DataSource = alltransircakeorder.Tables[0];
                        chkordercake.DataTextField = "ordertext";
                        chkordercake.DataValueField = "OrderSummaryId";
                        chkordercake.DataBind();
                    }
                    else
                    {
                        chkordercake.DataSource = null;
                        chkordercake.DataBind();
                    }
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
           
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("dispatchentry.aspx");
        }
        protected void Btn_Search(object sender, EventArgs e)
        {

        }

        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editt")
            {

                string iCat = e.CommandArgument.ToString();

                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Edit Is in Process.Thank You!!!');", true);
                return;

            }
            else if (e.CommandName == "print")
            {

                string yourUrl = "Dispatch_print.aspx?id=" + e.CommandArgument.ToString() + "&goodstype=B";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

            }

            else if (e.CommandName == "printorder")
            {

                string yourUrl = "Dispatch_OrderPrint.aspx?id=" + e.CommandArgument.ToString() + "&goodstype=O";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

            }

            //else if (e.CommandName == "Del")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        objBs.deletebranchsetting(e.CommandArgument.ToString());
            //        Response.Redirect("InterBranchSetting.aspx");
            //    }
            //}

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

            DataSet ds = objBs.grdidispatchentryload(sTableName);

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("dispatchentry.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            #region VALIDATION

            if (drpvehicleno.SelectedValue == "Select Vehicle")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Valid Vehicle No.Thank You!!!');", true);
                return;
            }

            if (drpemployee.SelectedValue == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Valid Employee.Thank You!!!');", true);
                return;
            }

            #endregion


            if (btnSave.Text == "Save")
            {

                if (chkgrnno.SelectedIndex >= 0 || chkordercake.SelectedIndex >=0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Any GRN No / Order No.Thank You!!!');", true);
                    return;
                }
               
                {
                    int iStatus = objBs.Insertdisaptchentry(sTableName, txtdispatchno.Text, drpvehicleno.SelectedValue,drpemployee.SelectedValue);
                    foreach (ListItem item in chkgrnno.Items)
                    {
                        if (item.Selected)
                        {

                            objBs.Inserttransdispatchenntry(sTableName,item.Value,"B",item.Text,lblUser.Text);
                        }
                    }

                    foreach (ListItem item1 in chkordercake.Items)
                    {
                        if (item1.Selected)
                        {

                            objBs.Inserttransdispatchenntry(sTableName, item1.Value, "O", item1.Text,lblUser.Text);
                        }
                    }

                    Response.Redirect("../Accountsbootstrap/dispatchentry.aspx");
                }
            }
            //else
            //{
            //    int iss = 0;
            //    iss = objBs.deleteinterbranch(txtinterid.Text);

            //    foreach (ListItem item in chkinterbranch.Items)
            //    {
            //        if (item.Selected)
            //        {

            //            objBs.Inserttransbranchsetting(item.Value, item.Text, txtinterid.Text);
            //        }
            //    }
            //    Response.Redirect("InterBranchSetting.aspx");
            //}
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}
