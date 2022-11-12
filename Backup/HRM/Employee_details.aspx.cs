using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BusinessLayer;
using CommonLayer;
using DataLayer;
using System.Windows.Forms;

namespace HRM
{
    public partial class Employee_details : System.Web.UI.Page
    {

        HRMclass objbs = new HRMclass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                DataSet ds1 = objbs.SelectMaxId();
                string a = ds1.Tables[0].Rows[0]["Employee_Id"].ToString();
                if (a == "" || a == null)
                {
                    txtemployid.Text = "1";

                }
                else
                {
                    txtemployid.Text = ds1.Tables[0].Rows[0]["Employee_Id"].ToString();
                }


                ds = objbs.Select_service();

                ddlservice.DataSource = ds;
                ddlservice.DataValueField = "ServiceID";
                ddlservice.DataTextField = "Servicename";
                ddlservice.DataBind();
                ddlservice.Items.Insert(0, "Select Service");



                ds = objbs.Branches();
                ddlbranches.DataSource = ds;
                ddlbranches.DataValueField = "BranchID";
                ddlbranches.DataTextField = "Branch";
                ddlbranches.DataBind();
                ddlbranches.Items.Insert(0, "Select Branch");

                ds = objbs.jobtype();
                ddljobtype.DataSource = ds;
                ddljobtype.DataValueField = "jobtypeID";
                ddljobtype.DataTextField = "Jobtype";
                ddljobtype.DataBind();
                ddljobtype.Items.Insert(0, "Select Jobtype");
                



                //txtemployid.Enabled = false;




                string sEmpID = Request.QueryString.Get("Employee_Id");
                if (sEmpID != "")
                {
                    DataSet dsEmp = objbs.GetEmpDet(sEmpID);
                    //if (Employee_Id != null || Employee_Id != null)
                    if (dsEmp.Tables[0].Rows.Count > 0)
                    {
                        btnsubmit.Text = "Update";
                        ds = objbs.desigination1(Convert.ToInt32(dsEmp.Tables[0].Rows[0]["Service"].ToString()));
                     
                        ddldesignation.DataSource = ds;
                        ddldesignation.DataValueField = "DesiginationId";
                        ddldesignation.DataTextField = "DesiginationName";
                        ddldesignation.DataBind();

                        ds = objbs.getbranches(Convert.ToInt32(dsEmp.Tables[0].Rows[0]["Branch"].ToString()));
                     
                        ddlbranches.DataSource = ds;
                        ddlbranches.DataValueField = "BranchID";
                        ddlbranches.DataTextField = "Branch";
                        ddlbranches.DataBind();
                        ds = objbs.getjobtype(Convert.ToInt32(dsEmp.Tables[0].Rows[0]["JobType"].ToString()));

                        ddljobtype.DataSource = ds;
                        ddljobtype.DataValueField = "jobtypeID";
                        ddljobtype.DataTextField = "Jobtype";
                        ddljobtype.DataBind();

                        
                        

                        txtemployid.Text = dsEmp.Tables[0].Rows[0]["Employee_Id"].ToString();
                        txtemploycode.Text = dsEmp.Tables[0].Rows[0]["Emp_code"].ToString();
                        txtname.Text = dsEmp.Tables[0].Rows[0]["Name"].ToString();
                        txtdob.Text = dsEmp.Tables[0].Rows[0]["DOB"].ToString();
                        
                        txtphno.Text = dsEmp.Tables[0].Rows[0]["Phno_No"].ToString();
                        txtemail.Text = dsEmp.Tables[0].Rows[0]["Email_Id"].ToString();
                        txtpwd.Attributes.Add("value", dsEmp.Tables[0].Rows[0]["Pssword"].ToString());
                        //txtpwd.Text = dsEmp.Tables[0].Rows[0]["Pssword"].ToString();
                        ddldesignation.SelectedValue = dsEmp.Tables[0].Rows[0]["Desigination"].ToString();
                        ddlservice.SelectedValue = dsEmp.Tables[0].Rows[0]["Service"].ToString();
                        //txtsalary.Text = dsEmp.Tables[0].Rows[0]["Salary"].ToString();
                        txtDocumentsSubmitted.Text = dsEmp.Tables[0].Rows[0]["Documents_Submitted"].ToString();
                        txtpfno.Text = dsEmp.Tables[0].Rows[0]["PF_NO"].ToString();
                        txtESINO.Text = dsEmp.Tables[0].Rows[0]["ESI_NO"].ToString();
                        txtsalary.Text = dsEmp.Tables[0].Rows[0]["Salary"].ToString();
                        txtannulasal.Text = dsEmp.Tables[0].Rows[0]["AnnualCTC"].ToString();
                        ddlbranches.SelectedValue = dsEmp.Tables[0].Rows[0]["Branch"].ToString();
                        ddljobtype.SelectedValue = dsEmp.Tables[0].Rows[0]["JobType"].ToString();
                        txtdoj.Text = dsEmp.Tables[0].Rows[0]["DOJ"].ToString();
                        txtaddress.Text = dsEmp.Tables[0].Rows[0]["Address"].ToString();
                       // txtpwd.TextMode = TextBoxMode.SingleLine;
                      //  txtpwd.Text = dsEmp.Tables[0].Rows[0]["Pssword"].ToString();

                        ddlStatus.SelectedValue = dsEmp.Tables[0].Rows[0]["Status"].ToString();
                        ttDateofLeaving.Text = dsEmp.Tables[0].Rows[0]["DOL"].ToString();
                    }
                }
                else
                {
                    ds = objbs.SelectMaxId();


                }



            }



        
        }

       

        protected void ddlservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlservice.SelectedValue != "--Select Service--")
            {

                ds = objbs.desigination1(Convert.ToInt32(ddlservice.SelectedValue));
                ddldesignation.DataSource = ds;
                ddldesignation.DataValueField = "DesiginationId";
                ddldesignation.DataTextField = "DesiginationName";
                ddldesignation.DataBind();

            }
        }
      
        protected void ddlbranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlbranches.SelectedItem.Text != "--Select Branch--")
            {

               
            }
        }
        protected void ddljobtype_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            {

                if (ddljobtype.SelectedItem.Text == "Contract")
                {
                    txtcontract.Visible = true;
                    lblcontract.Visible = true;
                    txtcontract.Text = "";
                }
                else
                {
                    txtcontract.Visible = false;
                    lblcontract.Visible = false;
                    txtcontract.Text = "-";
                }

            }
        }
        protected void btnsubmit_Click1(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "SUBMIT")
            {
                if (ddljobtype.SelectedItem.Text == "Contract")
                {
                    if (txtcontract.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Contract Period.');", true);
                        return;
                    }
                   
                   
                }
                int i = objbs.FetchRecords(txtname.Text,Convert.ToDateTime(txtdob.Text).ToString("yyyy-MM-dd"), txtdoj.Text, txtaddress.Text, txtphno.Text, txtemail.Text, txtpwd.Text, Convert.ToInt32(0), Convert.ToInt32(ddlservice.SelectedValue), txtDocumentsSubmitted.Text, txtemploycode.Text, Convert.ToInt32(ddlbranches.SelectedValue), Convert.ToDouble(txtsalary.Text), Convert.ToInt32(txtpfno.Text), Convert.ToInt32(txtESINO.Text), Convert.ToInt32( ddljobtype.SelectedValue), txtcontract.Text,Convert.ToDouble(txtannulasal.Text),Convert.ToInt32( ddlStatus.SelectedValue),ttDateofLeaving.Text);

                int j = objbs.insertDetails2(txtname.Text, txtpwd.Text, Convert.ToInt32(txtemployid.Text), txtname.Text, txtemploycode.Text, ddlservice.SelectedValue);
                                Response.Redirect("Emp_gird.aspx");
                //Response.Redirect("Emp_gird.aspx?id="+txtemployid.Text);
                               
            }
            else
            {
                int i = objbs.hrm(Convert.ToInt32(txtemployid.Text), txtname.Text, txtdob.Text, txtdoj.Text, txtaddress.Text, txtphno.Text, txtemail.Text, txtpwd.Text, Convert.ToInt32(0), Convert.ToInt32(ddlservice.SelectedValue), txtDocumentsSubmitted.Text, txtemploycode.Text,Convert.ToInt32(ddlbranches.SelectedValue), Convert.ToDouble(txtsalary.Text), Convert.ToInt32(txtpfno.Text), Convert.ToInt32(txtESINO.Text),Convert.ToInt32( ddljobtype.SelectedValue), txtcontract.Text, Convert.ToDouble(txtannulasal.Text),Convert.ToInt32( ddlStatus.SelectedValue),ttDateofLeaving.Text);
             
                Response.Redirect("Emp_gird.aspx");
            }
        }

        protected void txtemploycode_TextChanged(object sender, EventArgs e)
        {
            ds = objbs.CheckEmp_code(txtemploycode.Text);
            if ((ds.Tables[0].Rows.Count) > 0)
            {
                lblerror.Text = "Employee Code already Exists";
                btnsubmit.Visible = false;

            }
            else
            {
                lblerror.Text = "";
                btnsubmit.Visible = true;

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_details.aspx");
        }

       
       
        
    }
}