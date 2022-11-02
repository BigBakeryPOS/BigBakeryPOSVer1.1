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
namespace Billing.Accountsbootstrap
{
    public partial class categorymaster : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
               // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                DataSet dsCategory = objBs.selectcategorymaster();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    //listcategory.Text = dsCategory.Tables[0].Rows[0]["category"].ToString();
                    listcategory.DataSource = dsCategory.Tables[0];
                    listcategory.DataTextField = "category";
                    listcategory.DataValueField = "categoryid";
                    listcategory.DataBind();
                    //listcategory.Items.Insert(0, "Select Category");
                }

                //DataSet dID = objBs.CatID();
                //if(dID.Tables[0].Rows.Count>0)
                //{
                //    lblCatID.InnerText = dID.Tables[0].Rows[0]["CategoryID"].ToString();

                //}
                //else
                //{
                //    lblCatID.InnerText = "0";
                //}

                    
                
                    string iCat = Request.QueryString.Get("iCat");
                
                    if (iCat != "" || iCat != null)
                    {
                        
                        DataSet ds = objBs.getiCatvalues(iCat);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            btnadd.Text = "Update";
                            listcategory.Enabled = false;
                            txtcategoryId.Text = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                            txtcategory.Text = ds.Tables[0].Rows[0]["category"].ToString();
                            txtcatcode.Text = ds.Tables[0].Rows[0]["Categorycode"].ToString();
                        }
                    
                }
            }
       }

        protected void Add_Click(object sender, EventArgs e)
        {

           
                //if (btnadd.Text == "Save")
                //{
                //    DataSet dsCategory = objBs.categorysrchgrid(txtcategory.Text);

                //     DataSet dsCategorycode = objBs.categorycodesrchgrid(txtcatcode.Text);

                //    if (dsCategory.Tables[0].Rows.Count > 0)
                //    {

                //        lblerror.Text = "This Category has already Excided please enter a new one";

                //    }
                //    else if (dsCategorycode.Tables[0].Rows.Count > 0)
                //    {
                //        lblerror.Text = "This Category code has already Excided please enter a new one";
                //    }
                //    else
                //    {
                //        int iStatus = objBs.InsertCategoryLabel(txtcategory.Text,txtcatcode.Text, Convert.ToInt32(lblCatID.InnerText));
                //        Response.Redirect("../Accountsbootstrap/categorygrid.aspx");
                //    }
                //}

                //else
                //{


                //    objBs.updatecategoryMaster(Convert.ToInt32(txtcategoryId.Text), txtcategory.Text,txtcatcode.Text);
                //    Response.Redirect("categoryGrid.aspx");
                //}
            
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
           
                Response.Redirect("categoryGrid.aspx");
            
        }
       

        
    }
}