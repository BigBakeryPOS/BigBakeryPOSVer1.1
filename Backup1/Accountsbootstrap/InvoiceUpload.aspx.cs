using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using CommonLayer;
using System.Net.NetworkInformation;
using System.Data.OleDb;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class InvoiceUpload : System.Web.UI.Page
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

                //txtuom.Text = "";

                ds = objbs.getinvoiceupload(sTableName);
                gv.DataSource = ds;
                gv.DataBind();


                /// Bind Supplier
                DataSet dsCustomer = objbs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "Select Supplier");


                }

                DataSet dsprod = objbs.getbranchFilling("2");
                if (dsprod.Tables[0].Rows.Count > 0)
                {
                    DrpProductionBranch.DataSource = dsprod.Tables[0];
                    DrpProductionBranch.DataTextField = "BranchArea";
                    DrpProductionBranch.DataValueField = "BranchId";
                    DrpProductionBranch.DataBind();
                    DrpProductionBranch.Items.Insert(0, "Select Production");

                }

            }


            txtinvoicedate.Focus();

        }

        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {
            if (fp_Upload.HasFile)
            {
                string fileName = Path.GetFileName(fp_Upload.PostedFile.FileName);
                fp_Upload.PostedFile.SaveAs(Server.MapPath("~/Files/") + fileName);
                lblFile_Path.Text = "~/Files/" + fp_Upload.PostedFile.FileName;
                img_Photo.ImageUrl = "~/Files/" + fp_Upload.PostedFile.FileName;
            }
        }


        protected void reset(object sender, EventArgs e)
        {
            //txtsearch.Text = "";
            //ds = objbs.UNITS();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    gv.DataSource = ds;
            //    gv.DataBind();
            //}
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("invoiceupload.aspx");
        }
        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            string FilePath = (sender as LinkButton).CommandName;
            if (FilePath == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Check Data');", true);
                return;

            }
            else
            {
                //   Response.Clear();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
                Response.WriteFile(FilePath);
                Response.End();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fp_Upload.HasFile)
            {
                string fileName = Path.GetFileName(fp_Upload.PostedFile.FileName);
                fp_Upload.PostedFile.SaveAs(Server.MapPath("~/Files/") + fileName);
                lblFile_Path.Text = "~/Files/" + fp_Upload.PostedFile.FileName;
                img_Photo.ImageUrl = "~/Files/" + fp_Upload.PostedFile.FileName;
            }

            if (lblFile_Path.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Upload Invoice Copy.Thank You!!!');", true);
                return;
            }

            if (txtinvoiceno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Invoice No.Thank You!!!');", true);
                return;
            }
            else if (txtinvoicedate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Invoice Date.Thank You!!!');", true);
                return;
            }
            else if (DrpProductionBranch.SelectedValue == "Production")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Production Branch.Thank You!!!');", true);
                return;
            }
            else if (ddlsuplier.SelectedValue == "Select Supplier")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Supplier Name.Thank You!!!');", true);
                return;
            }
            if (btnSubmit.Text == "Save")
            {
                DataSet dsCategory = objbs.invoicealreadyfind(DrpProductionBranch.SelectedValue, ddlsuplier.SelectedValue, txtinvoiceno.Text);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Invoice No has already Exists. please enter a new one');", true);
                        return;


                    }
                    else
                    {


                        DateTime Date = DateTime.ParseExact(txtinvoicedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        int iStatus = objbs.InsertInvoiceUpload(Date,ddlsuplier.SelectedValue,DrpProductionBranch.SelectedValue,txtinvoiceno.Text,lblFile_Path.Text);
                        Response.Redirect("../Accountsbootstrap/invoiceupload.aspx");
                    }
                }
                else
                {
                    DateTime Date = DateTime.ParseExact(txtinvoicedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    int iStatus = objbs.InsertInvoiceUpload(Date, ddlsuplier.SelectedValue, DrpProductionBranch.SelectedValue, txtinvoiceno.Text, lblFile_Path.Text);
                    Response.Redirect("../Accountsbootstrap/invoiceupload.aspx");
                }
            }
            //else
            //{



            //    DataSet dsCategory = objbs.UOMsrchgridforupdate(Convert.ToInt32(txtid.Text), txtuom.Text);
            //    if (dsCategory != null)
            //    {
            //        if (dsCategory.Tables[0].Rows.Count > 0)
            //        {

            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These UOM has already Exists. please enter a new one');", true);
            //            return;
            //        }
            //        else
            //        {

            //            objbs.updateUOMMaster(Convert.ToInt32(txtid.Text), txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text, txtnarration.Text);
            //            Response.Redirect("invoiceupload.aspx");
            //        }
            //    }
            //    else
            //    {
            //        int iStatus = objbs.InsertUOM(txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);
            //        Response.Redirect("../Accountsbootstrap/invoiceupload.aspx");
            //    }

            //}





        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            //clearall();
            Response.Redirect("../Accountsbootstrap/invoiceupload.aspx");
        }
        private void clearall()
        {
            //txtuom.Text = "";
            //ddlIsActive.ClearSelection();
            //btnSubmit.Text = "Save";
            //txtuom.Focus();

        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "EditRow")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        DataSet dedit = new DataSet();

            //        dedit = objbs.editumo(Convert.ToInt32(e.CommandArgument));
            //        if (dedit.Tables[0].Rows.Count > 0)
            //        {


            //            txtuom.Text = dedit.Tables[0].Rows[0]["UOM"].ToString();
            //            txtid.Text = dedit.Tables[0].Rows[0]["Uomid"].ToString();
            //            btnSubmit.Text = "Update";
            //        }

            //    }
            //}
            //else if (e.CommandName == "Del")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        objbs.deleteuom(e.CommandArgument.ToString());
            //        Response.Redirect("Uom.aspx");
            //    }
            //}



        }


    }
}