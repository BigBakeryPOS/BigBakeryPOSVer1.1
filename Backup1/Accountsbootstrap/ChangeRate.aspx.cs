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
    public partial class ChangeRate : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Description ASC";
        string Sort_Direction1 = "category ASC";
        string Rate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                Rate = Request.Cookies["userInfo"]["Rate"].ToString();
                DataSet ds1 = objBs.viewDescp_Dealer();
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }
            
        }
        private void BindData()
        {
            DataSet ds1 = objBs.viewDescp_Dealer();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }
        protected void AddNewCustomer(object sender, EventArgs e)
        {
          

        }

        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
           // BindData();
        }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        
        protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
        {


           // string CustomerID = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblItemId")).Text;

            string Categoryuserid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblItemId")).Text;
            string Ammarate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtammaRate")).Text;
            string PothysRate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtpothysRate")).Text;

            objBs.updateDelerRate(Convert.ToDouble(Ammarate), Convert.ToDouble(PothysRate), Convert.ToInt32(Categoryuserid));
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void DeleteCustomer(object sender, EventArgs e)
        {



            
            
           
            LinkButton lnkRemove = (LinkButton)sender;
            objBs.DeleteDelerRate(Convert.ToInt32(lnkRemove.CommandArgument));
            
            BindData();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            BindData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
      
        
        
    }
}