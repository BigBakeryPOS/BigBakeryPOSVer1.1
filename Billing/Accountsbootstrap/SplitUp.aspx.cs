using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
namespace Billing.Accountsbootstrap
{ 
    public partial class SplitUp : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        string Store="";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Store = Request.Cookies["userInfo"]["Store"].ToString();
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    txtfrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtto.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    ddlBranch.Visible = true;
                }

                else
                {
                    ddlBranch.Visible =  false;
                    txtfrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtto.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    DataSet davv = objbs.AdvancaPayment(sTableName, txtfrom.Text, txtto.Text);
                    gvAvance.DataSource = davv.Tables[0];
                    gvAvance.DataBind();
                    gvAvance.Caption = Store +" All Payment modes"+" From " + txtfrom.Text + " To " + txtto.Text;
                    


                    DataSet dBal = objbs.BalancePayment(sTableName, txtfrom.Text, txtto.Text);
                    gvBalance.DataSource = dBal.Tables[0];
                    gvBalance.DataBind();
                    gvBalance.Caption =Store + " All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;
                    

                    DataSet dFull = objbs.FullPayment(sTableName, txtfrom.Text, txtto.Text);
                    gvFull.DataSource = dFull.Tables[0];
                    gvFull.DataBind();
                    gvFull.Caption =Store + " All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;

                    decimal adv = 0; decimal bal = 0; decimal full = 0;
                    for (int i = 0; i < gvAvance.Rows.Count; i++)
                    {
                        adv += Convert.ToDecimal(gvAvance.Rows[i].Cells[2].Text);
                    }
                    for (int i = 0; i < gvBalance.Rows.Count; i++)
                    {
                        bal += Convert.ToDecimal(gvBalance.Rows[i].Cells[2].Text);
                    }

                    for (int i = 0; i < gvFull.Rows.Count; i++)
                    {
                        full += Convert.ToDecimal(gvFull.Rows[i].Cells[2].Text);
                    }

                    lblAdv.InnerText = adv.ToString("f2");
                    lblBal.InnerText = bal.ToString("f2");
                    lblFull.InnerText = full.ToString("f2");

                    DataTable dt = objbs.OrderPayMode(sTableName, txtfrom.Text, txtto.Text);
                    gvsplit.DataSource = dt;
                    gvsplit.DataBind();
                    gvsplit.Caption = Store +" All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;
                }
               

            }
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txtfrom.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txtfrom.Text = "";
                }
            }
        }

        protected void btnser_Click(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                DataSet davv = objbs.AdvancaPayment(ddlBranch.SelectedValue, txtfrom.Text, txtto.Text);
                gvAvance.DataSource = davv.Tables[0];
                gvAvance.DataBind();
                gvAvance.Caption = ddlBranch.SelectedItem.Text + " All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;


                DataSet dBal = objbs.BalancePayment(ddlBranch.SelectedValue, txtfrom.Text, txtto.Text);
                gvBalance.DataSource = dBal.Tables[0];
                gvBalance.DataBind();
                gvBalance.Caption = ddlBranch.SelectedItem.Text + " All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;


                DataSet dFull = objbs.FullPayment(ddlBranch.SelectedValue, txtfrom.Text, txtto.Text);
                gvFull.DataSource = dFull.Tables[0];
                gvFull.DataBind();
                gvFull.Caption = ddlBranch.SelectedItem.Text + " All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;

                decimal adv = 0; decimal bal = 0; decimal full = 0;
                for (int i = 0; i < gvAvance.Rows.Count; i++)
                {
                    adv += Convert.ToDecimal(gvAvance.Rows[i].Cells[2].Text);
                }
                for (int i = 0; i < gvBalance.Rows.Count; i++)
                {
                    bal += Convert.ToDecimal(gvBalance.Rows[i].Cells[2].Text);
                }

                for (int i = 0; i < gvFull.Rows.Count; i++)
                {
                    full += Convert.ToDecimal(gvFull.Rows[i].Cells[2].Text);
                }

                lblAdv.InnerText = adv.ToString("f2");
                lblBal.InnerText = bal.ToString("f2");
                lblFull.InnerText = full.ToString("f2");



                DataTable dt = objbs.OrderPayMode(ddlBranch.SelectedValue, txtfrom.Text, txtto.Text);
                gvsplit.DataSource = dt;
                gvsplit.DataBind();
                gvsplit.Caption = ddlBranch.SelectedItem.Text + " All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;
            }
            else
            {
                DataSet davv = objbs.AdvancaPayment(sTableName, txtfrom.Text, txtto.Text);
                gvAvance.DataSource = davv.Tables[0];
                gvAvance.DataBind();
                gvAvance.Caption = Store +" All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;


                DataSet dBal = objbs.BalancePayment(sTableName, txtfrom.Text, txtto.Text);
                gvBalance.DataSource = dBal.Tables[0];
                gvBalance.DataBind();
                gvBalance.Caption = Store +" All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;


                DataSet dFull = objbs.FullPayment(sTableName, txtfrom.Text, txtto.Text);
                gvFull.DataSource = dFull.Tables[0];
                gvFull.DataBind();
                gvFull.Caption = Store +" All Payment modes" + " From " + txtfrom.Text + " To " + txtto.Text;

                decimal adv = 0; decimal bal = 0; decimal full = 0;
                for (int i = 0; i < gvAvance.Rows.Count; i++)
                {
                    adv += Convert.ToDecimal(gvAvance.Rows[i].Cells[2].Text);
                }
                for (int i = 0; i < gvBalance.Rows.Count; i++)
                {
                    bal += Convert.ToDecimal(gvBalance.Rows[i].Cells[2].Text);
                }

                for (int i = 0; i < gvFull.Rows.Count; i++)
                {
                    full += Convert.ToDecimal(gvFull.Rows[i].Cells[2].Text);
                }

                lblAdv.InnerText = adv.ToString("f2");
                lblBal.InnerText = bal.ToString("f2");
                lblFull.InnerText = full.ToString("f2");



                DataTable dt = objbs.OrderPayMode(sTableName, txtfrom.Text, txtto.Text);
                gvsplit.DataSource = dt;
                gvsplit.DataBind();
                gvsplit.Caption =Store + " All Payment modes" + " From "  + txtfrom.Text + " To " + txtto.Text;
            }
        }
    }
}