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
    public partial class OnlineOrderScreen : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string stable = "";
        string BillNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //   stable=Session["User"].ToString();;
            if (Session["User"] != null)
                stable = Session["User"].ToString();
            else
                Response.Redirect("login_branch.aspx");
            if (!IsPostBack)
            {
                lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataSet ds = objbs.kotlistDisplay(stable);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    datkot.DataSource = ds.Tables[0];
                    datkot.DataBind();
                }

                foreach (DataListItem item in datkot.Items)
                {
                    Label lblonlineid = (Label)item.FindControl("lblonlineid");
                    BillNo = lblonlineid.Text;

                    DataSet dsitem = objbs.kotlistitems(stable, lblonlineid.Text);
                    if (dsitem.Tables[0].Rows.Count > 0)
                    {

                        GridView gv = (GridView)item.FindControl("gvitems");
                        gv.DataSource = dsitem.Tables[0];
                        gv.DataBind();
                        foreach (GridViewRow Row in gv.Rows)
                        {
                            DateTime Itemtime = Convert.ToDateTime(Row.Cells[2].Text);
                            DateTime Nw = DateTime.Now;

                            string itemid = Convert.ToString(Row.Cells[3].Text);
                            string qty = Convert.ToString(Row.Cells[1].Text);

                            // getstock 
                            DataSet getstock = objbs.chkGtock(Convert.ToInt32(itemid), stable);
                            if (getstock.Tables[0].Rows.Count > 0)
                            {
                                Row.Cells[4].Text = Convert.ToDouble(getstock.Tables[0].Rows[0]["Available_QTY"]).ToString("0");
                            }
                            else
                            {
                                Row.Cells[4].Text = "0";
                                
                            }

                            if (Convert.ToDouble(Row.Cells[4].Text) <= Convert.ToDouble(qty))
                            {
                                Row.Cells[4].BackColor = System.Drawing.Color.Red;
                                Row.Cells[4].Font.Bold = true;
                                Row.Cells[4].ForeColor = System.Drawing.Color.White;
                            }
                           // var start = DateTime.Now;
                          //  var oldDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "EntryDate"));

                            var totmin = (Nw - Itemtime).TotalMinutes;

                            if ((Nw - Itemtime).TotalMinutes <= 10)
                            {
                                //20 minutes were passed from start  
                                //e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                                Row.BackColor = System.Drawing.Color.White;
                            }
                            else if ((Nw - Itemtime).TotalMinutes <= 20)
                            {
                                //20 minutes were passed from start  
                                //e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                                //Row.BackColor = System.Drawing.Color.White;
                                Row.BackColor = System.Drawing.Color.LightYellow;
                            }
                            else
                            {
                                Row.BackColor = System.Drawing.Color.Red;
                            }

                            //if (DateTime.Parse(Nw.ToString("hh:mm")).TimeOfDay >= DateTime.Parse(Itemtime.AddMinutes(5).ToString("hh:mm")).TimeOfDay)
                            //{
                                
                            //}

                            //else if (DateTime.Parse(Nw.ToString("hh:mm")).TimeOfDay >= DateTime.Parse(Itemtime.AddMinutes(20).ToString("hh:mm")).TimeOfDay)
                            //{
                                
                            //}

                            //else if (DateTime.Parse(Nw.ToString("hh:mm")).TimeOfDay >= DateTime.Parse(Itemtime.AddMinutes(30).ToString("hh:mm")).TimeOfDay)
                            //{
                                
                            //}
                            //else
                            //{
                            //    Row.BackColor = System.Drawing.Color.Red;
                            //}

                        }

                    }
                }


            }


        }
        void Colchange(Object sender, GridViewRowEventArgs e)
        {
            DateTime Itemtime = Convert.ToDateTime(e.Row.Cells[1].Text);
            DateTime Nw = DateTime.Now;


        }
        protected void btncomplete(object sender, EventArgs e)
        {
            Button bill = (sender as Button);

            string[] arg = new string[3];
            arg = bill.CommandArgument.ToString().Split(',');
            string onlineid = arg[0];
            string PaymentType = arg[1];
            string OnlineNumber = arg[2];

            Response.Redirect("onlineorderpos.aspx?Ref=" + OnlineNumber + "&id=" + onlineid + "&type=" + PaymentType);


            //objbs.kitchenkotcomplete(stable, bill.CommandArgument);
            //Response.Redirect("KitchenOrders.aspx");
        }

        protected void btn_print(object sender, EventArgs e)
        {
            //Button bill = (sender as Button);

            //string yourUrl = "KOT.aspx?Mode=Sales&iSalesID=" + bill.CommandArgument;
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
        }
    }
}