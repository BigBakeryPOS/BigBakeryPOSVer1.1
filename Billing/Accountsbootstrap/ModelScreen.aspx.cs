using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;

namespace Billing.Accountsbootstrap
{
    public partial class ModelScreen : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;
        int id = 0;
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"]["User"].ToString() != null)
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();


            if (!IsPostBack)
            {



                ds = objbs.Get_model();
                gv.DataSource = ds;
                gv.DataBind();

            }




        }

        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {
            if (fp_Upload.HasFile)
            {
                string fileName = Path.GetFileName(fp_Upload.PostedFile.FileName);
                fp_Upload.PostedFile.SaveAs(Server.MapPath("~/Model/") + fileName);
                lblFile_Path.Text = "~/Model/" + fp_Upload.PostedFile.FileName;
                img_Photo.ImageUrl = "~/Model/" + fp_Upload.PostedFile.FileName;
            }
        }




        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.Get_model();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("ModelScreen.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtmodelCode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Model Code.Thank You!!!');", true);
                return;
            }
            if (txtmodelname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Model Name.Thank You!!!');", true);
                return;
            }
            if (lblFile_Path.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Upload Image.Thank You!!!');", true);
                return;
            }



            if (btnSubmit.Text == "Save")
            {
                DataSet ds_ModelNAme = objbs.Model_srchgrid(txtmodelname.Text, "ModelName");
                if (ds_ModelNAme.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Model Name has already Exists. please enter a new one');", true);
                    return;
                }

                DataSet dsCategory = objbs.Model_srchgrid(txtmodelCode.Text, "ModelCode");


                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Model Code has already Exists. please enter a new one');", true);
                    return;


                }

                //if (btnSubmit.Text == "Save")
                {
                    int iinsert = objbs.Insert_ModelCake(txtmodelCode.Text, txtmodelname.Text, lblFile_Path.Text);
                    Response.Redirect("../Accountsbootstrap/ModelScreen.aspx");
                }
            }
            else
            {



                DataSet dsCategory = objbs.Model_Serach_Update(Convert.ToInt32(txtid.Text), txtmodelCode.Text, "ModelCode");
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Model Code has already Exists. please enter a new one');", true);
                    return;
                }

                DataSet dsCategory1 = objbs.Model_Serach_Update(Convert.ToInt32(txtid.Text), txtmodelname.Text, "ModelName");
                if (dsCategory1.Tables[0].Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Model Name has already Exists. please enter a new one');", true);
                    return;
                }
                

                //else
                {
                    int iUpdateStatus = objbs.update_Model_Master(Convert.ToInt32(txtid.Text), txtmodelCode.Text, txtmodelname.Text, lblFile_Path.Text);
                    Response.Redirect("../Accountsbootstrap/ModelScreen.aspx");
                }

            }





        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            txtmodelCode.Text = "";
            txtmodelname.Text = "";
            ddlIsActive.ClearSelection();
            btnSubmit.Text = "Save";
            txtmodelCode.Focus();

        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DataSet dedit = new DataSet();

                    dedit = objbs.EDIT_Model(Convert.ToInt32(e.CommandArgument));
                    if (dedit.Tables[0].Rows.Count > 0)
                    {


                        txtmodelCode.Text = dedit.Tables[0].Rows[0]["ModelCode"].ToString();
                        txtmodelname.Text = dedit.Tables[0].Rows[0]["ModelName"].ToString();
                        txtid.Text = dedit.Tables[0].Rows[0]["Modelid"].ToString();

                        lblFile_Path.Text = ds.Tables[0].Rows[0]["ModelImage"].ToString();
                        img_Photo.ImageUrl = ds.Tables[0].Rows[0]["ModelImage"].ToString();

                        btnSubmit.Text = "Update";
                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                //if (e.CommandArgument.ToString() != "")
                //{
                //    objbs.deleteuom(e.CommandArgument.ToString());
                //    Response.Redirect("Uom.aspx");
                //}
            }



        }


    }
}