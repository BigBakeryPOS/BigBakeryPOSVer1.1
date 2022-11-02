using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
namespace HRM
{
    public partial class Leave_Form : System.Web.UI.Page
    {
        HRMclass objbs = new HRMclass();
        DataSet hrm = new DataSet();
        DataSet ds = new DataSet();
        string date_time;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                var hours = Enumerable.Range(00, 24).Select(i => i.ToString("D2"));
                var minutes = Enumerable.Range(00, 60).Select(i => i.ToString("D2"));

                ddlHour.DataSource = hours;

                ddlHour.DataBind();
                ddlMin.DataSource = minutes;

                ddlMin.DataBind();

                int Client_Id = Convert.ToInt32(Session["empid"].ToString());
                if (Client_Id != 0)
                {
                    string Client_Name = Session["UserName"].ToString();
                    if (Client_Id == 7)
                    {

                        txtCode.Enabled = false;
                        txtDate.Enabled = false;
                        txtfromdate.Enabled = false;
                        txttodate.Enabled = false;
                        txtReason.Enabled = false;
                        txtEmpName.Enabled = false;
                        ddlStatus.Enabled = true;
                        btnSubmit.Text = "Update";
                    }
                    txtCode.Text = Convert.ToString(Client_Id);
                    txtEmpName.Text = Client_Name;
                    txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");


                }

                string empcode = (Request.QueryString.Get("Emp_code"));
                if (empcode != "")
                {
                    txtClientId.Text = Convert.ToString(empcode);
                    {
                        ds = objbs.Get_LeaveStatus(empcode);
                        if (ds.Tables[0].Rows.Count > 0)
                        {


                            txtCode.Text = ds.Tables[0].Rows[0]["Emp_code"].ToString();
                            //txtCode.Enabled = false;
                            txtEmpName.Text = ds.Tables[0].Rows[0]["Emp_Name"].ToString();
                            //txtEmpName.Enabled = false;

                            txtfromdate.Text = ds.Tables[0].Rows[0]["FromDate"].ToString();
                            txttodate.Text = ds.Tables[0].Rows[0]["ToDate"].ToString();
                            txtReason.Text = ds.Tables[0].Rows[0]["Leave_Reason"].ToString();
                            ddlStatus.Text = ds.Tables[0].Rows[0]["Leave_Status"].ToString();
                            txtDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();

                        }
                    }
                }
            }
        }


        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            //DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
           // DateTime toDate = DateTime.ParseExact(txttodate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            //DateTime Date = DateTime.ParseExact(txtDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                 if (btnSubmit.Text == "Submit")
                 {
                     DataSet dss = objbs.checkleave(txtDate.Text, txtCode.Text);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "Alread applied a leave today";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Alread applied a leave today!');", true);
                        return;
                    }
                    if (Convert.ToInt32(ddlType.SelectedValue) == 4)
                    {
                        int iSuccess = objbs.insert_leave(txtCode.Text, txtEmpName.Text, txtDate.Text, txtfromdate.Text, txttodate.Text, txtReason.Text, Convert.ToString(ddlStatus.SelectedItem), ddlType.SelectedValue);
                    }
                    else
                    {

                        int iSuccess = objbs.insert_leave(txtCode.Text, txtEmpName.Text, txtDate.Text, txtfromdate.Text, txttodate.Text, txtReason.Text, Convert.ToString(ddlStatus.SelectedItem), ddlType.SelectedValue);
                    }
                    Response.Redirect("Leave_Grid.aspx");
                }

                else
                {
                    int i = objbs.leave_status(ddlStatus.SelectedValue, txtClientId.Text);
                    Response.Redirect("Leave_Grid.aspx");
                }
            
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string meridian;
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (txtfromdate.Text != "")
            {

                if (Convert.ToInt32(ddlType.SelectedValue) == 1)
                {
                    DateTime dt = Convert.ToDateTime(FromDate);
                    txttodate.Text = dt.AddDays(1).ToString("dd/MM/yyyy");
                }
                else if (Convert.ToInt32(ddlType.SelectedValue) == 2)
                {
                    DateTime dt = Convert.ToDateTime(FromDate);
                    txttodate.Text = dt.AddDays(1).ToString("dd/MM/yyyy");
                }
                else if (Convert.ToInt32(ddlType.SelectedValue) == 3)
                {
                    DateTime dt = Convert.ToDateTime(FromDate);
                    txttodate.Text = dt.AddDays(90).ToString("dd/MM/yyyy");
                }
                else
                {

                    if (ddlHour.SelectedValue != "00" || ddlMin.SelectedValue != "00")
                    {
                        txttodate.Text = "";
                        if (Convert.ToInt32(ddlHour.SelectedValue) < 12)
                            meridian = "AM";
                        else
                            meridian = "PM";
                        date_time = txtfromdate.Text + " " + ddlHour.SelectedValue + ":" + ddlMin.SelectedValue + ":" + "00" + " " + meridian;
                        lblFromdateTime.Text = date_time;

                       // DateTime datetme = DateTime.ParseExact(date_time, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime dt = Convert.ToDateTime(Convert.ToDateTime(date_time));
                        txttodate.Text = dt.AddHours(2).ToString();

                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Click Refresh and Select From Time";
                    }
                }
            }
            else
            {

                lblError.Visible = true;
                lblError.Text = "Click Refresh and Select From Date";
            }
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Leave_Form.aspx");
        }
    }
}