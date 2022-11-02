using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class DealerBilling : System.Web.UI.Page
    {
      
        BSClass objBs = new BSClass();
        DataTable dt = new DataTable();
        public static int SubcatID;
        DataTable dCrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                dt.Columns.Add("CatID");
                dt.Columns.Add("SubCatID");
               
                dt.Columns.Add("category");
                dt.Columns.Add("item");
                dt.Columns.Add("Rate");
                dt.Columns.Add("OrderQty");              
                dt.Columns.Add("Basic Price");
                dt.Columns.Add("Margin");
                dt.Columns.Add("Sales Exempted");
                dt.Columns.Add("Sales @ 5%");
                dt.Columns.Add("VAT 5%");
                dt.Columns.Add("Total Sales");
               

                ViewState["Datatable"] = dt;

                DataSet dStore = objBs.selectcategorymaster();
                ddlCategory.DataSource = dStore.Tables[0];
                ddlCategory.DataTextField = "Category";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select Category");


                DataSet dealet = objBs.DealerList();
                ddlStore.DataSource = dealet.Tables[0];
                ddlStore.DataTextField = "VendorName";
                ddlStore.DataValueField = "VendorCode";
                ddlStore.DataBind();
                ddlStore.Items.Insert(0, "Select Dealer");


                DataSet dReq = objBs.maxDealersalesNo();

                if (dReq.Tables[0].Rows.Count > 0)
                {
                    if (dReq.Tables[0].Rows[0]["BillNo"].ToString() != "")
                    {
                        txtReqNo.Text = dReq.Tables[0].Rows[0]["BillNo"].ToString();
                    }

                    else
                    {
                        txtReqNo.Text = "1";
                    }
                }

                txtdate.Text = DateTime.Now.ToString();



            }
        }

        protected void ddlcat_selectedindexchanged(object s, EventArgs e)
        {
            if (ddlStore.SelectedItem.Text == "Select Dealer")
            {
                err.InnerText = "Select a dealer";
            }
            else
            {
                err.InnerText = "";
                DataSet dDef = objBs.selectcategorydecription_Dealer(Convert.ToInt32(ddlCategory.SelectedValue));
                ddlitem.DataTextField = "Definition";
                ddlitem.DataValueField = "categoryuserid";
                ddlitem.DataSource = dDef.Tables[0];
                ddlitem.DataBind();
                ddlitem.Items.Insert(0, "select");
                ddlitem.Focus();
            }
           
        }

        protected void ddlitem_selectedindexchanged(object s, EventArgs e)
        {
            DataSet dDef = objBs.SelectDefinition_Dealet(Convert.ToInt32(ddlitem.SelectedValue));

            if(ddlStore.SelectedItem.Text.Contains("Amma"))
            txtrate.Text = Convert.ToDecimal( dDef.Tables[0].Rows[0]["User1"]).ToString("f2");                
            else
            txtrate.Text = Convert.ToDecimal( dDef.Tables[0].Rows[0]["User2"]).ToString("f2");
        }

        protected void check(object s, EventArgs e)
        {
            if (ddlStore.SelectedItem.Text == "Select Dealer")
            {
                ddlCategory.Enabled = false;
            }
            else
            {
                ddlCategory.Enabled = true;
            }

        }

        protected void txtqtytextchanged(object s, EventArgs e)
        { string  dis="";
        if (ddlStore.SelectedItem.Text.Contains("Pothys"))
            dis = "0.23";
        else if (ddlStore.SelectedItem.Text.Contains("Amma"))
            dis = "0.20";
        else
            dis = ".20";

            decimal dRate = 0; decimal dQty = 0;
            if (txtrate.Text != "")           
            {
                dRate =Convert.ToDecimal(txtrate.Text);
            }

            if (txtOrderQty.Text != "")
            {
                dQty = Convert.ToDecimal(txtOrderQty.Text);
            }


            

           

            if(ddlitem.SelectedItem.Text.Contains("BR")==true)
            {
                txtbasic.Text = (dRate * dQty).ToString("f2");

                decimal margin = Convert.ToDecimal(txtbasic.Text) * Convert.ToDecimal(dis);

                txtmargin.Text = margin.ToString("f2");
                decimal exemp=Convert.ToDecimal(txtbasic.Text)-Convert.ToDecimal(txtmargin.Text);
                txtexempted.Text=exemp.ToString("f2");
                txtNet.Text="0";
                txtvat.Text="0";

                decimal total = Convert.ToDecimal(txtexempted.Text) + Convert.ToDecimal(txtNet.Text) + Convert.ToDecimal(txtvat.Text);

                txttotal.Text = total.ToString("f2");
            }
            else
            {
                txtbasic.Text = (dRate * dQty).ToString("f2");

                decimal dbas = (Convert.ToDecimal(txtbasic.Text) / 105) * 100;
                txtbasic.Text = dbas.ToString("f2");
                decimal margin = dbas * Convert.ToDecimal(dis);

                txtmargin.Text = margin.ToString("f2");
                decimal exemp = Convert.ToDecimal(txtbasic.Text) - Convert.ToDecimal(txtmargin.Text);
                txtexempted.Text = "0";;
                txtNet.Text = exemp.ToString("f2");

                decimal Vat = Convert.ToDecimal(txtNet.Text) * Convert.ToDecimal(0.05);

                txtvat.Text = Vat.ToString("f2");
               

                decimal total = Convert.ToDecimal(txtexempted.Text) + Convert.ToDecimal(txtNet.Text) + Convert.ToDecimal(txtvat.Text);

                txttotal.Text = total.ToString("f2");
            }
        }
        protected void add_click(object s, EventArgs e)
        {
            dCrt = (DataTable)ViewState["Datatable"];
            if (dCrt.Rows.Count == 0)
            {
                DataRow dr = dCrt.NewRow();
                dr["CatID"] = ddlCategory.SelectedValue;
                dr["SubCatID"] = ddlitem.SelectedValue;
               
                dr["Category"] = ddlCategory.SelectedItem.Text;
                dr["item"] = ddlitem.SelectedItem.Text;
                dr["Rate"] = txtrate.Text;
                dr["OrderQty"] = txtOrderQty.Text;
                dr["Basic Price"] = txtbasic.Text;
                dr["Margin"] = txtmargin.Text;
                dr["Sales Exempted"] = txtexempted.Text;
                dr["Sales @ 5%"] = txtNet.Text;
                dr["VAT 5%"] = txtvat.Text;
                dr["Total Sales"] = txttotal.Text;
                dCrt.Rows.Add(dr);




            }
            else
            {
                DataRow dr = dCrt.NewRow();
                dr["CatID"] = ddlCategory.SelectedValue;
                dr["SubCatID"] = ddlitem.SelectedValue;
                dr["Rate"] = txtrate.Text;
                dr["Category"] = ddlCategory.SelectedItem.Text;
                dr["item"] = ddlitem.SelectedItem.Text;
                dr["OrderQty"] = txtOrderQty.Text;
                dr["Basic Price"] = txtbasic.Text;
                dr["Margin"] = txtmargin.Text;
                dr["Sales Exempted"] = txtexempted.Text;
                dr["Sales @ 5%"] = txtNet.Text;
                dr["VAT 5%"] = txtvat.Text;
                dr["Total Sales"] = txttotal.Text;
                dCrt.Rows.Add(dr);


            }
            ViewState["Firstrow"] = dCrt;
            gvItems.DataSource = dCrt;
            gvItems.DataBind();
            decimal a = 0; decimal b = 0;decimal c=0;decimal d=0;
            foreach (DataRow drr in dCrt.Rows)
            {
                a +=Convert.ToDecimal( drr["Sales Exempted"].ToString());
                b += Convert.ToDecimal(drr["Sales @ 5%"].ToString());
                c += Convert.ToDecimal(drr["VAT 5%"].ToString());
                d += Convert.ToDecimal(drr["Total Sales"].ToString());
            }

            txtexpTotal.Text = a.ToString("f2");
            txtNetTotal.Text = b.ToString("f2");
            txtvattotal.Text = c.ToString("f2");
            txtgrandtotal.Text = d.ToString("f2");
            txtbasic.Text = "";
            txtrate.Text = "";
            txtexempted.Text = "";
            txtmargin.Text = "";
            txtvat.Text = "";
            txtNet.Text = "";
            txttotal.Text = "";
            txtOrderQty.Text = "";
            ddlCategory.Focus();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dat = ViewState["Firstrow"] as DataTable;
            dat.Rows[index].Delete();
            ViewState["Firstrow"] = dat;
            ViewState["Datatable"] = dat;
            gvItems.DataSource = dat;
            gvItems.DataBind();

            dCrt = dat;

            decimal a = 0; decimal b = 0; decimal c = 0; decimal d = 0;
            foreach (DataRow drr in dCrt.Rows)
            {
                a += Convert.ToDecimal(drr["Sales Exempted"].ToString());
                b += Convert.ToDecimal(drr["Sales @ 5%"].ToString());
                c += Convert.ToDecimal(drr["VAT 5%"].ToString());
                d += Convert.ToDecimal(drr["Total Sales"].ToString());
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[5].Text;
                foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           


            //  DataTable dCrt = (DataTable)ViewState["Firstrow"];
            if (txtRequestBy.Text.Trim() != "")
            {

                if (gvItems.Rows.Count > 0)
                {
                    DataSet dReq = objBs.maxDealersalesNo();
                    if (dReq.Tables[0].Rows.Count > 0)
                    {
                        if (dReq.Tables[0].Rows[0]["BillNo"].ToString() != "")
                        {
                            txtReqNo.Text = dReq.Tables[0].Rows[0]["BillNo"].ToString();
                        }

                        else
                        {
                            txtReqNo.Text = "1";
                        }
                    }
                  int dealersales = objBs.DealerSales(Convert.ToInt32(txtReqNo.Text), txtdate.Text, Convert.ToInt32(ddlStore.SelectedValue), Convert.ToDouble(txtexpTotal.Text), Convert.ToDouble(txtNetTotal.Text), Convert.ToDouble(txtvattotal.Text), Convert.ToDouble(txtgrandtotal.Text), txtRequestBy.Text);
                    for (int i = 0; i < gvItems.Rows.Count; i++)
                    {

                       
                        int icat = Convert.ToInt32(gvItems.Rows[i].Cells[1].Text);
                        int subcatid = Convert.ToInt32(gvItems.Rows[i].Cells[2].Text);

                        double rate = Convert.ToDouble(gvItems.Rows[i].Cells[5].Text);
                        double qty = Convert.ToDouble(gvItems.Rows[i].Cells[6].Text);
                        double basic = Convert.ToDouble(gvItems.Rows[i].Cells[7].Text);
                        double margin = Convert.ToDouble(gvItems.Rows[i].Cells[8].Text);
                        double exem = Convert.ToDouble(gvItems.Rows[i].Cells[9].Text);
                        double Net = Convert.ToDouble(gvItems.Rows[i].Cells[10].Text);
                        double Vat = Convert.ToDouble(gvItems.Rows[i].Cells[11].Text);
                        double Tot = Convert.ToDouble(gvItems.Rows[i].Cells[12].Text);



                       int Trans = objBs.TransDealerSales(Convert.ToInt32(txtReqNo.Text), icat, subcatid, rate, qty, basic, margin, exem, Net, Vat, Tot);

                    }


                  string URL= "AmmaNana.aspx?BillNo=" + txtReqNo.Text;

                  ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + URL + "');", true);
                    

                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Add Item to the list');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Enter Invoice Made by Name');", true);
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");

        }


        protected void ddlchanged(object sender, EventArgs e)
        {
            if (ddlStore.SelectedItem.Text.Contains("Pothys"))
            {

                DataSet dReq = objBs.maxDealersalesNo();

                if (dReq.Tables[0].Rows.Count > 0)
                {
                    if (dReq.Tables[0].Rows[0]["BillNo"].ToString() != "")
                    {
                        txtReqNo.Text ="POT "+ dReq.Tables[0].Rows[0]["BillNo"].ToString();
                    }

                    else
                    {
                        txtReqNo.Text = "POT "+"1";
                    }
                }
            }

            else
            {
                DataSet dReq = objBs.maxDealersalesNo();

                if (dReq.Tables[0].Rows.Count > 0)
                {
                    if (dReq.Tables[0].Rows[0]["BillNo"].ToString() != "")
                    {
                        txtReqNo.Text = "AN " + dReq.Tables[0].Rows[0]["BillNo"].ToString();
                    }

                    else
                    {
                        txtReqNo.Text = "AN " + "1";
                    }
                }
            }

        }
    }
}