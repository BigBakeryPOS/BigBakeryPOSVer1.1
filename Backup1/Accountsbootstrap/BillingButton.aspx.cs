using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
namespace Billing.Accountsbootstrap
{
    public partial class BillingButton : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        private Button BtnServices;
        private Button btnItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                ViewState.Add("falg", true);
                ViewState.Add("falg2", true);
                if (ViewState["falg"] != null)
                {
                    Create();
                }
           
            //if (!IsPostBack)
            //{

            //    DataSet dCat = objbs.selectCAT();

            //    int icount = dCat.Tables[0].Rows.Count;

            //    for (int i = 0; i < icount; i++)
            //    {
            //        string sName = dCat.Tables[0].Rows[i]["Cat"].ToString();
            //        string id = dCat.Tables[0].Rows[i]["categoryid"].ToString();
            //        Button btn = new Button();
            //        btn.Text = sName;
            //        btn.ID = id;
            //        btn.BackColor = System.Drawing.Color.Yellow;
            //        btn.ForeColor = System.Drawing.Color.Black;
            //        panel.Controls.Add(btn);
            //        btn.Click += new EventHandler(btn_Click1);
            //        panel.Visible = true;

            //        Button cmd = new Button();
            //        cmd.Text = "Click Me";
            //        panel.Controls.Add(cmd);

            //        cmd.Click += new EventHandler(Dynamic_Method);

            //    }


            //}
        }

        protected void gvGateaux_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnCat = (Button)(e.Row.FindControl("btnCat") as Button);

            btnCat.ID = "lnkView";
            btnCat.Text = "View";
        }

        void Create()
        {
            DataSet dCat = objbs.selectCAT();

            int icount = dCat.Tables[0].Rows.Count;

            for (int i = 0; i < icount; i++)
            {
                string sName = dCat.Tables[0].Rows[i]["Cat"].ToString();
                string id = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                BtnServices = new Button();
                BtnServices.ID = id;
                BtnServices.Text = sName;
                BtnServices.BackColor = System.Drawing.Color.Yellow;
                BtnServices.ForeColor = System.Drawing.Color.Black;
                BtnServices.Click += new EventHandler(BtnServices_Click);
                BtnServices.Command += new CommandEventHandler(BtnServices_Command);
                td1.Controls.Add(BtnServices);
              




               
            }
        }
     
      


        void BtnServices_Click(object sender, EventArgs e)
        {
            Response.Write("hi");
            Button Button = sender as Button;
            DataSet dsCategory = objbs.SelectItems(Convert.ToInt32(Button.ID), Convert.ToInt32(lblUserID.Text), sTableName);
            int icount = dsCategory.Tables[0].Rows.Count;

            for (int i = 0; i < icount; i++)
            {
                string sName = dsCategory.Tables[0].Rows[i]["Definition"].ToString();
                string sStock = dsCategory.Tables[0].Rows[i]["Available_QTY"].ToString();
                string id = dsCategory.Tables[0].Rows[i]["SubCategoryID"].ToString();
                double DRate = Convert.ToDouble(dsCategory.Tables[0].Rows[i]["Rate"].ToString());
                btnItems = new Button();
                btnItems.ID = id;
                btnItems.Text = sName + "--" + sStock;
                btnItems.BackColor = System.Drawing.Color.Yellow;
                btnItems.ForeColor = System.Drawing.Color.Black;
                btnItems.Click += new EventHandler(BtnServices_Click1);
              //  btnItems.Command += new CommandEventHandler(BtnServices_Command);
                td1.Controls.Add(btnItems);

            }
        }

        void BtnServices_Command(object sender, CommandEventArgs e)
        {
            Table tbldynamic = new Table();
                // Response.Write("hi");
                Button Button = sender as Button;
                DataSet dsCategory = objbs.SelectItems(Convert.ToInt32(Button.ID), Convert.ToInt32(lblUserID.Text), sTableName);
                int icount = dsCategory.Tables[0].Rows.Count;

                for (int i = 0; i < icount; i++)
                {
                    TableCell tc = new TableCell();
                    TableRow tr = new TableRow();
                    string sName = dsCategory.Tables[0].Rows[i]["Definition"].ToString();
                    string sStock = dsCategory.Tables[0].Rows[i]["Available_QTY"].ToString();
                    string id = dsCategory.Tables[0].Rows[i]["SubCategoryID"].ToString();
                    double DRate = Convert.ToDouble(dsCategory.Tables[0].Rows[i]["Rate"].ToString());
                    btnItems = new Button();
                    btnItems.ID = id;
                    btnItems.Text = sName + "--" + sStock;
                    btnItems.BackColor = System.Drawing.Color.Yellow;
                    btnItems.ForeColor = System.Drawing.Color.Black;
                    btnItems.Click += new EventHandler(BtnServices_Click1);
                    tc.Controls.Add(btnItems);
                    tr.Cells.Add(tc);
                    tbldynamic.Rows.Add(tr);
                    //  btnItems.Command += new CommandEventHandler(BtnServices_Command);
                    panel.Controls.Add(tbldynamic);

                    
                   
                }

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "You have clicked" + Button.Text, "Func()", true);
        }
      
        void BtnServices_Click1(object sender, EventArgs e)
        {
            Response.Write("hi");
            Button Button = sender as Button;
            DataSet dsCategory = objbs.SelectItems(Convert.ToInt32(Button.ID), Convert.ToInt32(lblUserID.Text),sTableName);


        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.selectCAT();
           
                Button btnCat = (Button)(e.Row.FindControl("btnCat") as Button);

                btnCat.ID = "lnkView";
                btnCat.Text = "View";
                // btnCat.Click += ViewDetails;
                // btnCat.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
                //  e.Row.Cells[2].Controls.Add(btnCat);

           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

       
    }

  
}

