using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
using System.Globalization;
using System.Net.Mail;

namespace Billing.Accountsbootstrap
{
    public partial class CostingReport : System.Web.UI.Page
    {

        string sTableName = "";
        BSClass objbs = new BSClass();
        string branchcode = string.Empty;
        double RecQty = 0; double Price = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            branchcode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();



            string time = DateTime.Now.ToString();

            DateTime dat = DateTime.Parse(time);
            var hour = dat.ToString("HH");
            var min = dat.ToString("mm");
            var current = hour + "." + min;





            if (!IsPostBack)
            {

                DataSet dscategory = objbs.categorymasterN();
                if (dscategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataSource = dscategory.Tables[0];
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                }

                DataSet dsitems = objbs.getCatIDprod();
                if (dsitems.Tables[0].Rows.Count > 0)
                {
                    ddlitem.DataTextField = "Definition";
                    ddlitem.DataValueField = "CategoryUserID";
                    ddlitem.DataSource = dsitems.Tables[0];
                    ddlitem.DataBind();
                    ddlitem.Items.Insert(0, "All");
                }


                DataSet dsitem = objbs.getitemdeails();
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    gvitems.DataSource = dsitem;
                    gvitems.DataBind();

                }
                else
                {
                    gvitems.DataSource = null;
                    gvitems.DataBind();
                }

            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);

        }
    


        public void ddlcategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            DataSet dsitem = objbs.getitemdeailsValues(ddlcategory.SelectedValue, ddlitem.SelectedValue);
            if (dsitem.Tables[0].Rows.Count > 0)
            {
                gvitems.DataSource = dsitem;
                gvitems.DataBind();

            }
            else
            {
                gvitems.DataSource = null;
                gvitems.DataBind();
            }
        }
        public void ddlitem_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsitem = objbs.getitemdeailsValues(ddlcategory.SelectedValue, ddlitem.SelectedValue);
            if (dsitem.Tables[0].Rows.Count > 0)
            {
                gvitems.DataSource = dsitem;
                gvitems.DataBind();

            }
            else
            {
                gvitems.DataSource = null;
                gvitems.DataBind();
            }
        }


        public void gvitemcost_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "RecQty") != "")
                {
                    RecQty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RecQty"));
                }
                Price += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Price"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total :-";
                e.Row.Cells[1].Text = RecQty.ToString("f2");
                e.Row.Cells[4].Text = Price.ToString("f2");

                RecQty = 0; Price = 0;
            }

        }

        public void txtTotalQty_OnTextChanged(object sender, EventArgs e)
        {

          
            for (int j = 0; j < gvitems.Rows.Count; j++)
            {

                HiddenField hideCategoryUserID = (HiddenField)gvitems.Rows[j].FindControl("hideCategoryUserID");
                int rowIndex = Convert.ToInt32(hideCategoryUserID.Value);

                GridView gv = (GridView)gvitems.Rows[j].FindControl("gvitemcost");

                TextBox txtTotalQty = (TextBox)gvitems.Rows[j].FindControl("txtTotalQty");
                TextBox txtmisc = (TextBox)gvitems.Rows[j].FindControl("txtmisc");


                if (txtTotalQty.Text == "")
                    txtTotalQty.Text = "0";
                if (txtmisc.Text == "")
                    txtmisc.Text = "0";


                if (txtPreparedQty.Text == "" || txtPreparedQty.Text == "0")
                {

                }
                else
                {
                    txtTotalQty.Text = txtPreparedQty.Text;
                }
                if (txtMiscAmount.Text == "" || txtMiscAmount.Text == "0")
                {

                }
                else
                {
                    txtmisc.Text = txtMiscAmount.Text;
                }

                DataSet ds = objbs.getsemiitemdeails(rowIndex,"Prod");
                DataSet dsfab = new DataSet();
                DataTable dtfab = new DataTable();
                DataColumn dcfab = new DataColumn();

                dcfab = new DataColumn("IngredientName");
                dtfab.Columns.Add(dcfab);
                dcfab = new DataColumn("RecQty");
                dtfab.Columns.Add(dcfab);
                dcfab = new DataColumn("UOM");
                dtfab.Columns.Add(dcfab);
                dcfab = new DataColumn("Rate");
                dtfab.Columns.Add(dcfab);
                dcfab = new DataColumn("Price");
                dtfab.Columns.Add(dcfab);
                dsfab.Tables.Add(dtfab);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    double ttlCutMeter = 0;
                    double ttlEndBit = 0;
                    double ttlMasterMeter = 0;

                    DataRow drfab = dsfab.Tables[0].NewRow();
                    drfab["IngredientName"] = ds.Tables[0].Rows[i]["IngredientName"].ToString();


                    double TotalQty = ((Convert.ToDouble(ds.Tables[0].Rows[i]["RecQty"].ToString()) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalQty"].ToString())) * Convert.ToDouble(txtTotalQty.Text));

                    drfab["RecQty"] = TotalQty.ToString("f2");  //ds.Tables[0].Rows[i]["RecQty"].ToString();
                    drfab["UOM"] = ds.Tables[0].Rows[i]["UOM"].ToString();
                    drfab["Rate"] = ds.Tables[0].Rows[i]["Rate"].ToString();
                    drfab["Price"] = Convert.ToDouble(TotalQty) * Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"].ToString());
                    dsfab.Tables[0].Rows.Add(drfab);

                }

                DataRow drfab1 = dsfab.Tables[0].NewRow();
                drfab1["IngredientName"] = "Misc.";
                drfab1["RecQty"] = "";
                drfab1["UOM"] = "";
                drfab1["Rate"] = "";
                drfab1["Price"] = Convert.ToDouble(txtmisc.Text).ToString("f2");
                dsfab.Tables[0].Rows.Add(drfab1);

                gv.DataSource = dsfab;
                gv.DataBind();
            }

        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvitemcost") as GridView;
                GridView gvGroup = (GridView)sender;

                TextBox txtmisc = e.Row.FindControl("txtmisc") as TextBox;
                if (txtmisc.Text == "")
                    txtmisc.Text = "0";

                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objbs.getsemiitemdeails(groupID,"Prod");


                    DataSet dsfab = new DataSet();
                    DataTable dtfab = new DataTable();
                    DataColumn dcfab = new DataColumn();

                    dcfab = new DataColumn("IngredientName");
                    dtfab.Columns.Add(dcfab);
                    dcfab = new DataColumn("RecQty");
                    dtfab.Columns.Add(dcfab);
                    dcfab = new DataColumn("UOM");
                    dtfab.Columns.Add(dcfab);
                    dcfab = new DataColumn("Rate");
                    dtfab.Columns.Add(dcfab);
                    dcfab = new DataColumn("Price");
                    dtfab.Columns.Add(dcfab);
                    dsfab.Tables.Add(dtfab);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                      
                        DataRow drfab = dsfab.Tables[0].NewRow();
                        drfab["IngredientName"] = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                        drfab["RecQty"] = Convert.ToDouble(ds.Tables[0].Rows[i]["RecQty"]).ToString("f2");
                        drfab["UOM"] = ds.Tables[0].Rows[i]["UOM"].ToString();
                        drfab["Rate"] = ds.Tables[0].Rows[i]["Rate"].ToString();
                        drfab["Price"] = Convert.ToDouble(ds.Tables[0].Rows[i]["RecQty"].ToString()) * Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"].ToString());
                        dsfab.Tables[0].Rows.Add(drfab);

                    }

                    DataRow drfab1 = dsfab.Tables[0].NewRow();
                    drfab1["IngredientName"] = "Misc.";
                    drfab1["RecQty"] = "";
                    drfab1["UOM"] = "";
                    drfab1["Rate"] = "";
                    drfab1["Price"] = Convert.ToDouble(txtmisc.Text).ToString("f2");
                    dsfab.Tables[0].Rows.Add(drfab1);

                    gv.DataSource = dsfab;
                    gv.DataBind();
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {



            }

        }


    }
}