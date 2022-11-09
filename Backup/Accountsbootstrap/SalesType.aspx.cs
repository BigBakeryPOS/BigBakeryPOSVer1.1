using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
namespace Billing.Accountsbootstrap
{
    public partial class SalesType : System.Web.UI.Page
    {
        BSClass kbs = new BSClass();
        BSClass objBs = new BSClass();
        string idEdit = "";
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            idEdit = Request.QueryString.Get("ID");
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {


                DataSet paymode = objBs.Paymodevalues(sTableName);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    {
                        chkpaylist.DataSource = paymode.Tables[0];
                        chkpaylist.DataTextField = "PayMode";
                        chkpaylist.DataValueField = "Value";
                        chkpaylist.DataBind();

                    }
                }

                // bind billtype


                DataSet getbilltype = objBs.getbilltypemaster();
                if (getbilltype.Tables[0].Rows.Count > 0)
                {
                    {
                        drpbilltype.DataSource = getbilltype.Tables[0];
                        drpbilltype.DataTextField = "BilltypeName";
                        drpbilltype.DataValueField = "Billtype";
                        drpbilltype.DataBind();
                        drpbilltype.Items.Insert(0, "Select Bill Type");

                    }
                }


                if (idEdit != "")
                {
                    DataSet dget = kbs.EditSalesType(Convert.ToInt32(idEdit), Convert.ToInt32(lblUserID.Text));
                    if (dget.Tables[0].Rows.Count > 0)
                    {
                        txtpaytype.Text = dget.Tables[0].Rows[0]["PaymentType"].ToString();
                        txtmargin.Text = dget.Tables[0].Rows[0]["Margin"].ToString();
                        txtGST.Text = dget.Tables[0].Rows[0]["GST"].ToString();
                        txtPayGatway.Text = dget.Tables[0].Rows[0]["PaymentGatway"].ToString();
                        txtTotal.Text = dget.Tables[0].Rows[0]["Total"].ToString();
                        txtordercount.Text = dget.Tables[0].Rows[0]["OrderCount"].ToString();
                        drpordertype.SelectedValue = dget.Tables[0].Rows[0]["OrderType"].ToString();

                        drpbilltype.SelectedValue = dget.Tables[0].Rows[0]["billtype"].ToString();

                        if (dget.Tables[0].Rows[0]["IsActive"].ToString().Trim() == "YES")
                        {
                            ddIsActive.SelectedValue = "YES";// dget.Tables[0].Rows[0]["IsActive"].ToString();
                        }
                        else
                        {
                            ddIsActive.SelectedValue = "NO";
                        }

                        if (dget.Tables[0].Rows[0]["IsNormal"].ToString().Trim() == "Y")
                        {
                            chknormalbill.Checked = true;
                        }
                        else
                        {
                            chknormalbill.Checked = false;
                        }
                        if (dget.Tables[0].Rows[0]["Isdiscount"].ToString().Trim() == "Y")
                        {
                            chkdiscountchk.Checked = true;
                            divchk.Visible = true;
                            DataSet getAttender = objBs.getdiscattender("2");
                            if (getAttender.Tables[0].Rows.Count > 0)
                            {
                                drpdiscattender.DataSource = getAttender.Tables[0];
                                drpdiscattender.DataTextField = "AttenderName";
                                drpdiscattender.DataValueField = "AttenderId";
                                drpdiscattender.DataBind();
                                drpdiscattender.Items.Insert(0, "Select Attender");

                            }

                            drpdiscattender.SelectedValue = dget.Tables[0].Rows[0]["Attenderid"].ToString();

                            DataSet ddiscchk = objBs.Editdisctype(Convert.ToInt32(drpdiscattender.SelectedValue));
                            if (ddiscchk.Tables[0].Rows.Count > 0)
                            {
                                drpdiscpper.DataSource = ddiscchk.Tables[0];
                                drpdiscpper.DataTextField = "Discper";
                                drpdiscpper.DataValueField = "Discid";
                                drpdiscpper.DataBind();
                                drpdiscpper.Items.Insert(0, "Select Disc");
                            }

                            drpdiscpper.SelectedValue = dget.Tables[0].Rows[0]["Discid"].ToString();

                            DataSet ds = objBs.getupdateattendermaster(drpdiscattender.SelectedValue);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lblpassword.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
                            }


                        }
                        else
                        {
                            chkdiscountchk.Checked = false;
                            divchk.Visible = false;
                            drpdiscattender.Items.Clear();
                            drpdiscattender.ClearSelection();
                            drpdiscattender.Items.Insert(0, "Select Attender");
                            lblpassword.Text = "";

                            drpdiscpper.Items.Clear();
                            drpdiscpper.ClearSelection();
                            drpdiscpper.Items.Insert(0, "Select Disc");
                        }

                        if (dget.Tables[0].Rows[0]["IsInclusiveRate"].ToString().Trim() == "Y")
                        {
                            chkinclusiverate.Checked = true;
                        }
                        else
                        {
                            chkinclusiverate.Checked = false;
                        }



                        btnSubmit.Text = "Update";

                        DataSet dsize = objBs.EditSalesmodeType(Convert.ToInt32(idEdit));

                        if ((dsize.Tables[0].Rows.Count > 0))
                        {
                            //Select the checkboxlist items those values are true in database
                            //Loop through the DataTable
                            for (int i = 0; i <= dsize.Tables[0].Rows.Count - 1; i++)
                            {
                                //You need to change this as per your DB Design
                                string size = dsize.Tables[0].Rows[i]["value"].ToString();
                                {
                                    //Find the checkbox list items using FindByValue and select it.
                                    chkpaylist.Items.FindByValue(dsize.Tables[0].Rows[i]["value"].ToString()).Selected = true;
                                }

                            }
                        }


                    }
                }
                DataSet ingrid = kbs.GetSalesType();
                Ingredientdrid.DataSource = ingrid;
                Ingredientdrid.DataBind();

            }

        }

        protected void attender_discChnaged(object sender, EventArgs e)
        {
            if (drpdiscattender.SelectedValue == "Select Attender")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Valid Attender Name.');", true);
                return;
            }
            else
            {
                DataSet ddiscchk = objBs.Editdisctype(Convert.ToInt32(drpdiscattender.SelectedValue));
                if (ddiscchk.Tables[0].Rows.Count > 0)
                {
                    drpdiscpper.DataSource = ddiscchk.Tables[0];
                    drpdiscpper.DataTextField = "Discper";
                    drpdiscpper.DataValueField = "Discid";
                    drpdiscpper.DataBind();
                    drpdiscpper.Items.Insert(0, "Select Disc");
                }
                DataSet ds = objBs.getupdateattendermaster(drpdiscattender.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpassword.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
                }
            }
        }

        protected void chk_discountcnaged1(object sender, EventArgs e)
        {
            if (chkoveralldiscount.Checked == true)
            {
                chkdiscountchk.Checked = false;
            }


        }

        protected void chk_discountcnaged(object sender, EventArgs e)
        {

            if (chkdiscountchk.Checked == true)
            {
                chkoveralldiscount.Checked = false;
            }


            divchk.Visible = false;
            if (chkoveralldiscount.Checked == true)
            {
                divchk.Visible = true;
                DataSet getAttender = objBs.getdiscattender("2");
                if (getAttender.Tables[0].Rows.Count > 0)
                {
                    drpdiscattender.DataSource = getAttender.Tables[0];
                    drpdiscattender.DataTextField = "AttenderName";
                    drpdiscattender.DataValueField = "AttenderId";
                    drpdiscattender.DataBind();
                    drpdiscattender.Items.Insert(0, "Select Attender");

                }
            }
            else
            {
                divchk.Visible = false;
                drpdiscattender.Items.Clear();
                drpdiscattender.ClearSelection();
                drpdiscattender.Items.Insert(0, "Select Attender");
                lblpassword.Text = "";

                drpdiscpper.Items.Clear();
                drpdiscpper.ClearSelection();
                drpdiscpper.Items.Insert(0, "Select Disc");

            }
        }

        protected void Totcalcmar(object sender, EventArgs e)
        {
            double margin = 0;
            double gst = 0;
            double patgatway = 0;

            if (txtmargin.Text == "")
            {
                margin = 0;
            }
            else
            {
                margin = Convert.ToDouble(txtmargin.Text);

            }

            if (txtGST.Text == "")
            {
                gst = 0;
            }
            else
            {
                gst = Convert.ToDouble(txtGST.Text);
            }

            if (txtPayGatway.Text == "")
            {
                patgatway = 0;
            }
            else
            {
                patgatway = Convert.ToDouble(txtPayGatway.Text);
            }
            txtPayGatway.Focus();

            txtTotal.Text = Convert.ToString(margin + gst + patgatway);
        }

        protected void Totcalc(object sender, EventArgs e)
        {
            double margin = 0;
            double gst = 0;
            double patgatway = 0;

            if (txtmargin.Text == "")
            {
                margin = 0;
            }
            else
            {
                margin = Convert.ToDouble(txtmargin.Text);

            }

            if (txtGST.Text == "")
            {
                gst = 0;
            }
            else
            {
                gst = Convert.ToDouble(txtGST.Text);
            }

            if (txtPayGatway.Text == "")
            {
                patgatway = 0;
            }
            else
            {
                patgatway = Convert.ToDouble(txtPayGatway.Text);
            }

            txtTotal.Text = Convert.ToString(margin + gst + patgatway);
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string isnormalbill = string.Empty;
            string isDiscountbill = string.Empty;
            string isinclusiverate = string.Empty;


            int attenderid = 0;
            string attednerpassword = string.Empty;

            int discountid = 0;
            double discvalue = 0;


            if (drpbilltype.SelectedValue == "Select Bill Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Bill Type');", true);
                return;
            }

            if (txtpaytype.Text.Trim() == "" || txtpaytype.Text.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Payment Type');", true);
                return;
            }
            else if (txtmargin.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Margin');", true);
                return;
            }
            else if (txtGST.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter GST');", true);
                return;
            }
            else if (txtPayGatway.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Payment Gateway');", true);
                return;
            }
            else if (txtTotal.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Total');", true);
                return;
            }
            if (chknormalbill.Checked == true)
            {
                isnormalbill = "Y";
                if (txtordercount.Text == "")
                    txtordercount.Text = "0";
            }
            else
            {
                isnormalbill = "N";
                if (txtordercount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Mention Order Number Count.Thank You!!!');", true);
                    return;
                }


            }
            if (chkoveralldiscount.Checked == true)
            {
                isDiscountbill = "Y";

                if (drpdiscattender.SelectedValue == "Select Attender")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Valid Attender Name.');", true);
                    return;
                }
                else
                {
                    attenderid = Convert.ToInt32(drpdiscattender.SelectedValue);
                    attednerpassword = lblpassword.Text;
                }

                if (drpdiscpper.SelectedValue == "Select Disc")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Valid Discount Percentage.');", true);
                    return;
                }
                else
                {
                    discountid = Convert.ToInt32(drpdiscpper.SelectedValue);
                    discvalue = Convert.ToDouble(drpdiscpper.SelectedItem.Text);
                }

            }
            else
            {
                isDiscountbill = "N";
                attenderid = 0;
                discountid = 0;
                attednerpassword = "0";
                discvalue = 0;

            }

            if (chkinclusiverate.Checked == true)
            {
                isinclusiverate = "Y";
            }
            else
            {
                isinclusiverate = "N";
            }



            if (btnSubmit.Text == "Save")
            {
                #region

                DataSet dsSalesType = kbs.searchSalesType(txtpaytype.Text);
                if (dsSalesType != null)
                {
                    if (dsSalesType.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Payment Type has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {
                        if (chkpaylist.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Atleast One Payment Mode.Thank You!!!');", true);
                            return;
                        }
                        else
                        {

                        }




                        int insert = kbs.insert_SalesType(txtpaytype.Text, txtmargin.Text, txtGST.Text, txtPayGatway.Text, txtTotal.Text, "YES", isnormalbill, isDiscountbill, isinclusiverate, txtordercount.Text, drpordertype.SelectedValue, attenderid, attednerpassword, discountid, discvalue, drpbilltype.SelectedValue);

                        foreach (ListItem listItem in chkpaylist.Items)
                        {
                            if (listItem.Text != "All")
                            {
                                if (listItem.Selected)
                                {
                                    int idd = kbs.insert_TransSalesType(listItem.Value);
                                }
                            }
                        }
                        Response.Redirect("../Accountsbootstrap/SalesType.aspx");
                    }
                }
                else
                {

                    if (chkpaylist.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Atleast One Payment Mode.Thank You!!!');", true);
                        return;
                    }
                    else
                    {

                    }

                    int insert = kbs.insert_SalesType(txtpaytype.Text, txtmargin.Text, txtGST.Text, txtPayGatway.Text, txtTotal.Text, "YES", isnormalbill, isDiscountbill, isinclusiverate, txtordercount.Text, drpordertype.SelectedValue, attenderid, attednerpassword, discountid, discvalue,drpbilltype.SelectedValue);

                    foreach (ListItem listItem in chkpaylist.Items)
                    {
                        if (listItem.Text != "All")
                        {
                            if (listItem.Selected)
                            {
                                int idd = kbs.insert_TransSalesType(listItem.Value);
                            }
                        }
                    }

                    Response.Redirect("../Accountsbootstrap/SalesType.aspx");
                }
                #endregion
            }
            else
            {

                if (chkpaylist.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Atleast One Payment Mode.Thank You!!!');", true);
                    return;
                }
                else
                {

                }

                #region
                //DataSet dsCategory = kbs.searchIngredientforupdate(txtingre.Text, Convert.ToInt32(idEdit));
                DataSet dsCategory = kbs.searchSalesTypeforupdate(txtpaytype.Text, Convert.ToInt32(idEdit));
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Payment Type has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        int idelete = objBs.Ideletetranssalestype(idEdit);


                        int update = kbs.update_salestype(txtpaytype.Text, txtmargin.Text, txtGST.Text, txtPayGatway.Text, txtTotal.Text, ddIsActive.SelectedItem.Text, Convert.ToInt32(idEdit), isnormalbill, isDiscountbill, isinclusiverate, txtordercount.Text, drpordertype.SelectedValue, attenderid, attednerpassword, discountid, discvalue,drpbilltype.SelectedValue);

                        foreach (ListItem listItem in chkpaylist.Items)
                        {
                            if (listItem.Text != "All")
                            {
                                if (listItem.Selected)
                                {
                                    int idd = kbs.insert_TransSalesTypeUpdate(listItem.Value, idEdit);
                                }
                            }
                        }

                        Response.Redirect("../Accountsbootstrap/SalesType.aspx");
                    }
                }
                else
                {
                    //int insert = kbs.insert_ingredients(txtingre.Text, Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, txtQuantity.Text, Convert.ToInt32(ddlIngreCategory.SelectedValue), txtingreCode.Text);
                    Response.Redirect("SalesType.aspx");
                }

                #endregion
            }

        }

        protected void Ingredientdrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            idEdit = e.CommandArgument.ToString();
            Session["ID"] = e.CommandArgument.ToString();
            if (e.CommandName == "et")
            {

                Response.Redirect("SalesType.aspx?ID=" + e.CommandArgument.ToString());

            }
            else
            {

                int delete = kbs.deletesalestype(Convert.ToInt32(idEdit));
                Response.Redirect("SalesType.aspx");
            }


        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            txtpaytype.Text = "";
            txtmargin.Text = "";
            txtGST.Text = "0";
            txtPayGatway.Text = "";
            txtTotal.Text = "0";
            btnSubmit.Text = "Save";
            ddIsActive.SelectedValue = "YES";
            txtpaytype.Focus();

        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataSet ingrid = kbs.GetSalesType();
            Ingredientdrid.DataSource = ingrid;
            Ingredientdrid.DataBind();
        }

    }
}