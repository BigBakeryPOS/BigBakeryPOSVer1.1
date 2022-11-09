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
    public partial class KitchenOrders : System.Web.UI.Page
    {
        BSClass objbs=new BSClass();
        string stable = "";
        string BillNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
         //   stable=Session["User"].ToString();;
            if (Session["User"] != null)
                stable = Session["User"].ToString();
            else
                Response.Redirect("login.aspx");
            if(!IsPostBack)
            {
                lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataSet ds = objbs.kotlistDisplayKT(stable);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    datkot.DataSource = ds.Tables[0];
                    datkot.DataBind();
                }

                foreach (DataListItem item in datkot.Items)
                {
                    Label lblbill = (Label)item.FindControl("lblkotno");
                    BillNo = lblbill.Text;
                    //if ((bool)objbs.isprinted(BillNo, stable))
                    //{
                    //    string yourUrl = "KOT.aspx?Mode=Sales&iSalesID=" + BillNo;
                    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
                    //    objbs.Updateisprinted(stable, BillNo);
                    //}
                    DataSet dsitem = objbs.kotlistitemsKT(stable, lblbill.Text);
                    if (dsitem.Tables[0].Rows.Count > 0)
                    {
                       
                        GridView gv = (GridView)item.FindControl("gvitems");
                        gv.DataSource = dsitem.Tables[0];
                        gv.DataBind();
                        foreach (GridViewRow Row in gv.Rows)
                        {
                            DateTime Itemtime = Convert.ToDateTime(Row.Cells[2].Text);
                            DateTime Nw = DateTime.Now;

                            if (DateTime.Parse(Nw.ToString("hh:mm")).TimeOfDay >= DateTime.Parse(Itemtime.AddMinutes(5).ToString("hh:mm")).TimeOfDay)
                          {
                          Row.BackColor=System.Drawing.Color.White;
                          }

                            if (DateTime.Parse(Nw.ToString("hh:mm")).TimeOfDay >= DateTime.Parse(Itemtime.AddMinutes(10).ToString("hh:mm")).TimeOfDay)
                          {
                          Row.BackColor=System.Drawing.Color.LightYellow;
                          }

                            if (DateTime.Parse(Nw.ToString("hh:mm")).TimeOfDay >= DateTime.Parse(Itemtime.AddMinutes(15).ToString("hh:mm")).TimeOfDay)
                          {
                          Row.BackColor=System.Drawing.Color.Red;
                          }
                           
                        }

                    }
                }

              
            }


        }
        void Colchange(Object sender, GridViewRowEventArgs e)
        {
            DateTime Itemtime =Convert.ToDateTime(e.Row.Cells[1].Text);
            DateTime Nw = DateTime.Now;


        }
        protected void btncomplete(object sender, EventArgs e)
        { 
            Button bill = (sender as Button);

            objbs.kitchenkotcomplete(stable,bill.CommandArgument);
            Response.Redirect("KitchenOrders.aspx");
        }

        protected void btn_print(object sender, EventArgs e)
        {
            Button bill = (sender as Button);

            string yourUrl = "KOT.aspx?Mode=Sales&iSalesID=" + bill.CommandArgument;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
        }
    }
}