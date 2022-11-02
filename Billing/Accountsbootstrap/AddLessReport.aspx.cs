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
    public partial class AddLessReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        string AllBranchAccess = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();
            if (!IsPostBack)
            {
                txtFrom.Text = DateTime.Now.ToShortDateString();
                txtto.Text = DateTime.Now.ToShortDateString();

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objbs.GetBranch_New("All");
                else
                    dsbranch = objbs.GetBranch_New(sTableName);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "All");
                else
                    ddlBranch.Enabled = false;

            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("BookNo");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Date");
            dt.Columns.Add("Add");
            dt.Columns.Add("Less");
            dt.Columns.Add("Total");
           // if (sTableName == "admin")
             DataSet dsgrid = new DataSet();
                DataSet ds = new DataSet();
                DataSet dsp = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                     DataSet ds1 = objbs.GetBranch_New("All");
                     for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                     {
                         ds = objbs.Currentlist(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), txtFrom.Text, txtto.Text);
                         dsp.Merge(ds);

                     }
                }
                else
                {
                    dsp = objbs.Currentlist(ddlBranch.SelectedValue, txtFrom.Text, txtto.Text);
                }
        
            {
                

                for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = dsp.Tables[0].Rows[i]["bnch"].ToString();
                    dr["Name"] = dsp.Tables[0].Rows[i]["customername"].ToString();
                    dr["BookNo"] = dsp.Tables[0].Rows[i]["bookno"].ToString();
                    dr["Amount"] = dsp.Tables[0].Rows[i]["netamount"].ToString();

                    DataSet dget = objbs.GetAddlessReport(dsp.Tables[0].Rows[i]["bnch"].ToString(), dsp.Tables[0].Rows[i]["bookno"].ToString(), txtFrom.Text, txtto.Text);
                    DataSet dget2 = objbs.GetAddlessReport2(dsp.Tables[0].Rows[i]["bnch"].ToString(), dsp.Tables[0].Rows[i]["bookno"].ToString(), txtFrom.Text, txtto.Text);
                    if (dget2.Tables[0].Rows.Count > 0)
                    {
                        dr["Date"] = dget2.Tables[0].Rows[0]["Date"].ToString();
                    }
                    else
                    {
                        dr["Date"] = "";
                    }
                   
                        dr["Add"] = dget.Tables[0].Rows[0]["Add"].ToString();
                        dr["Less"] = dget.Tables[0].Rows[0]["Less"].ToString();

                        decimal net = Convert.ToDecimal(dsp.Tables[0].Rows[i]["netamount"].ToString());

                        decimal Add = 0;
                        if (dget.Tables[0].Rows[0]["Add"].ToString() != "")
                            Add = Convert.ToDecimal(dget.Tables[0].Rows[0]["Add"].ToString());

                        decimal Less = 0;

                        if (dget.Tables[0].Rows[0]["Less"].ToString() != "")
                            Less = Convert.ToDecimal(dget.Tables[0].Rows[0]["Less"].ToString());

                        decimal tot = net + Add - Less;
                        dr["Total"] = tot.ToString("f2");

                        if (dr["Add"] != "" && dr["Less"] != "")
                            dt.Rows.Add(dr);
                    
                }



                gvResilt.DataSource = dt;
                gvResilt.DataBind();
            }
            //else
            //{
            //    DataSet dsp = objbs.Currentlist(sTableName,txtFrom.Text,txtto.Text);
               
            //        for (int i=0;i<dsp.Tables[0].Rows.Count;i++)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["Name"] = dsp.Tables[0].Rows[i]["customername"].ToString();
            //        dr["BookNo"] = dsp.Tables[0].Rows[i]["bookno"].ToString();
            //        dr["Amount"] = dsp.Tables[0].Rows[i]["netamount"].ToString();
            //        DataSet dget = objbs.GetAddlessReport(sTableName, dsp.Tables[0].Rows[i]["bookno"].ToString(),txtFrom.Text,txtto.Text);
            //        DataSet dget2 = objbs.GetAddlessReport2(sTableName, dsp.Tables[0].Rows[i]["bookno"].ToString(), txtFrom.Text, txtto.Text);
            //        if (dget2.Tables[0].Rows.Count > 0)
            //        {
            //            dr["Date"] = dget2.Tables[0].Rows[0]["Date"].ToString();
            //        }
            //        else
            //        {
            //            dr["Date"] = "";
            //        }
            //        dr["Add"] = dget.Tables[0].Rows[0]["Add"].ToString();
            //        dr["Less"] = dget.Tables[0].Rows[0]["Less"].ToString();

            //        decimal net=Convert.ToDecimal(dsp.Tables[0].Rows[i]["netamount"].ToString());
                       
            //        decimal Add=0;
            //        if (dget.Tables[0].Rows[0]["Add"].ToString() != "")
            //            Add = Convert.ToDecimal(dget.Tables[0].Rows[0]["Add"].ToString());

            //            decimal Less=0;

            //            if (dget.Tables[0].Rows[0]["Less"].ToString() != "")
            //          Less=  Convert.ToDecimal(dget.Tables[0].Rows[0]["Less"].ToString());

            //            decimal tot = net + Add - Less;
            //            dr["Total"] = tot.ToString("f2");

            //            if (dr["Add"] != "" && dr["Less"] != "")
            //             dt.Rows.Add(dr);
            //        }
                
                

            //    gvResilt.DataSource = dt;
            //    gvResilt.DataBind();
                
            //}
        }
    }
}