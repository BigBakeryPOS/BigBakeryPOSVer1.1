using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;

namespace Billing.Production
{

    public partial class Recipe : System.Web.UI.Page
    {
      
        KitchenClass objbs = new KitchenClass();
        protected void Page_Load(object sender, EventArgs e)
        {   lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            int id =Convert.ToInt32(Request.QueryString.Get("Id"));
            if (!IsPostBack)
            {
                DataSet ds = objbs.get_ingredients();
                ddlingredients.DataSource = ds.Tables[0];
                ddlingredients.DataTextField = "IngredientName";
                ddlingredients.DataValueField = "IngridID";
                ddlingredients.DataBind();


                DataSet dRec = objbs.getReceipe(Convert.ToInt32(lblUserID.Text), id);

                if (dRec.Tables[0].Rows.Count > 0)
                {
                    txtrecipe.Text = dRec.Tables[0].Rows[0]["ReceipeName"].ToString();
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

        }
        private void FirstGridViewRow()
        {
            DataTable dtreceipt = new DataTable();
            DataRow dr = dtreceipt.NewRow();
            dtreceipt.Columns.Add("IngredientName");
            dtreceipt.Columns.Add("Basic recipe in kg");
            dtreceipt.Columns.Add("Coefficients");
            dtreceipt.Columns.Add("Edit");

            double kg = Convert.ToDouble(txtkg.Text) * Convert.ToDouble(txtcoefficient.Text);
            dr["IngredientName"] = ddlingredients.SelectedItem.Text;
            dr["Basic recipe in kg"] = kg;
            dr["Coefficients"] = txtcoefficient.Text;
          

            dtreceipt.Rows.Add(dr);

            ViewState["rview"] = dtreceipt;

            
            recipegrid.DataSource = dtreceipt;
            recipegrid.DataBind();

            foreach (GridViewRow row in recipegrid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = new CheckBox();


                    row.Cells[3].Controls.Add(cb);
                    cb.Controls.Add(recipegrid);
                }

            }
            //  gv.Columns[1].HeaderText = header;


           
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // DataTable dttbltransPO = (DataTable)ViewState["tbltransPO"];



            if (ViewState["rview"] != null)
            {
                DataTable dttbltransPO = (DataTable)ViewState["rview"];
                DataRow drCurrentRow = null;
                if (dttbltransPO.Rows.Count > 0)
                {
                    
                       
                        drCurrentRow = dttbltransPO.NewRow();


                        double kg = Convert.ToDouble(txtkg.Text) * Convert.ToDouble(txtcoefficient.Text);
                        drCurrentRow["IngredientName"] = ddlingredients.SelectedItem.Text;
                        drCurrentRow["Basic recipe in kg"] = kg;
                        drCurrentRow["Coefficients"] = txtcoefficient.Text;
                        
                       
                    dttbltransPO.Rows.Add(drCurrentRow);
                    ViewState["rview"] = dttbltransPO;

                    recipegrid.DataSource = dttbltransPO;
                    recipegrid.DataBind();
                    ViewState["rview"] = dttbltransPO;

                    
                    // txn.Focus;
                }
            }
              

               
                  
                    //DataRow dr = dtreceipt.NewRow();
                    //dr["IngredientName"] = ddlingredients.Text;
                    //double kg = Convert.ToDouble(txtkg.Text) * Convert.ToDouble(txtcoefficient.Text);
                    //dr["Basic recipe in kg"] = kg;
                    //dr["Coefficients"] = txtcoefficient.Text;

                    //dtreceipt.Rows.Add(dr);

                    //recipegrid.DataSource = dtreceipt;
                    //recipegrid.DataBind();
                   
                

                else
                {
                    FirstGridViewRow();

                        //dtreceipt.Columns.Add("IngredientName");
                        //dtreceipt.Columns.Add("Basic recipe in kg");
                        //dtreceipt.Columns.Add("Coefficients");

                        //DataRow dr = dtreceipt.NewRow();
                        //dr["IngredientName"] = ddlingredients.SelectedItem.Text;
                        //double kg = Convert.ToDouble(txtkg.Text) * Convert.ToDouble(txtcoefficient.Text);
                        //dr["Basic recipe in kg"] = kg;
                        //dr["Coefficients"] = txtcoefficient.Text;


                        //dtreceipt.Rows.Add(dr);

                        //recipegrid.DataSource = dtreceipt;
                        //recipegrid.DataBind();
                        //ViewState["Grid"] = dtreceipt;

                    }




          
                }
        }

        }
   

