using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class LedgerMaster : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sLedID = Request.QueryString.Get("iLedID");
                if (sLedID != null)
                {
                    DataSet dsLedger = objbs.SelectLedger(sLedID);
                    if (dsLedger.Tables[0].Rows.Count > 0)
                    {
                        txtledger.Text = dsLedger.Tables[0].Rows[0]["LedgerName"].ToString();
                    }
                }

                DataSet dGroup = objbs.GetGroup();
               
                ddlGroup.DataTextField = "GroupName";
                ddlGroup.DataValueField = "GroupID";
                ddlGroup.DataSource = dGroup.Tables[0];
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, "Select group");
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("LedgerMasterGrid.aspx");
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
             string sLedID = Request.QueryString.Get("iLedID");
             if (sLedID != null)
             {
                 int i = objbs.ledgercr(txtledger.Text,sLedID);
             }
             else
             {
                 int i = objbs.ledgercr(txtledger.Text,Convert.ToInt32(ddlGroup.SelectedValue));
             }
            Response.Redirect("LedgerMasterGrid.aspx");
            
        }
    }
}