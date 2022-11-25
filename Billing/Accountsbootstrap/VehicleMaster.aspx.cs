using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class VehicleMaster : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;
        int id = 0;
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"].ToString() != null)
                sTableName = Session["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();


            if (!IsPostBack)
            {
                DataSet dacess1 = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "vehiclemaster");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "vehiclemaster");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gv.Columns[5].Visible = true;
                    }
                    else
                    {
                        gv.Columns[5].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gv.Columns[6].Visible = true;
                    }
                    else
                    {
                        gv.Columns[6].Visible = false;
                    }
                }


                txtvehicleno.Text = "";

               ds = objbs.GET_vehicle();
                gv.DataSource = ds;
                gv.DataBind();

            }


            txtvehicleno.Focus();

        }
        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.GET_vehicle();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("vehiclemaster.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtvehicleno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Vehicle Number.Thank You!!!');", true);
                return;
            }
            if (btnSubmit.Text == "Save")
            {
                DataSet dsCategory = objbs.Vehiclesrchgrid(txtvehicleno.Text, 1);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Vehicle Number has already Exists. please enter a new one');", true);
                        return;


                    }
                    else
                    {
                        int iStatus = objbs.Insert_Vehicle(txtvehicleno.Text,drpvehicletype.SelectedValue,txtnotes.Text, ddlIsActive.SelectedValue);
                        Response.Redirect("../Accountsbootstrap/Uom.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.Insert_Vehicle(txtvehicleno.Text, drpvehicletype.SelectedValue, txtnotes.Text, ddlIsActive.SelectedValue);



                    Response.Redirect("../Accountsbootstrap/vehiclemaster.aspx");
                }
            }
            else
            {



                DataSet dsCategory = objbs.Vehiclesrchgridforupdate(Convert.ToInt32(txtid.Text), txtvehicleno.Text);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Vehicle Number has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        objbs.updateVehicleMaster(Convert.ToInt32(txtid.Text), txtvehicleno.Text,drpvehicletype.SelectedValue,txtnotes.Text, ddlIsActive.SelectedValue);
                        Response.Redirect("vehiclemaster.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.Insert_Vehicle(txtvehicleno.Text, drpvehicletype.SelectedValue, txtnotes.Text, ddlIsActive.SelectedValue);
                    Response.Redirect("../Accountsbootstrap/vehiclemaster.aspx");
                }

            }





        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            txtvehicleno.Text = "";
            ddlIsActive.ClearSelection();
            btnSubmit.Text = "Save";
            txtvehicleno.Focus();
            txtnotes.Text = "";

        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DataSet dedit = new DataSet();

                    dedit = objbs.editvehicle(Convert.ToInt32(e.CommandArgument));
                    if (dedit.Tables[0].Rows.Count > 0)
                    {


                        txtvehicleno.Text = dedit.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        txtid.Text = dedit.Tables[0].Rows[0]["VehicleID"].ToString();

                        drpvehicletype.SelectedValue = dedit.Tables[0].Rows[0]["VehicleType"].ToString();
                        txtnotes.Text = dedit.Tables[0].Rows[0]["Notes"].ToString();
                        ddlIsActive.SelectedValue = dedit.Tables[0].Rows[0]["IsActive"].ToString();

                        btnSubmit.Text = "Update";
                        btnSubmit.Visible = true;
                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objbs.deletevehiclenumber(e.CommandArgument.ToString());
                    Response.Redirect("vehiclemaster.aspx");
                }
            }



        }


    }
}