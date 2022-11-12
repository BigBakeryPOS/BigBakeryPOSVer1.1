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
    public partial class ElobratedStockReport : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (!IsPostBack)
            {

              
            }
        }

        protected void Btn_Search(object sender, EventArgs e)
        {
            //DataSet dStockReport = objBs.NewStockReport(txttodate.Text, sTableName, Convert.ToInt32(lblUserID.Text));
            //GVStockAlert.DataSource = dStockReport.Tables[0];
            //GVStockAlert.DataBind();


            DataTable dt = new DataTable();
            dt.Columns.Add("categoryuserid");
            dt.Columns.Add("Definition");
            dt.Columns.Add("OpeningStock");
            dt.Columns.Add("SalesQty");
            dt.Columns.Add("GrnQty");
            dt.Columns.Add("CurrentStock");

            DataSet dStock = objBs.OpeningStock(Convert.ToInt32(lblUserID.Text));

            if (dStock.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dStock.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["categoryuserid"] = dStock.Tables[0].Rows[i]["categoryuserid"].ToString();
                    dr["Definition"] = dStock.Tables[0].Rows[i]["Definition"].ToString();
                    dr["OpeningStock"] = dStock.Tables[0].Rows[i]["Qty"].ToString();
                    dt.Rows.Add(dr);
                }

                GVStockAlert.DataSource = dt;
                GVStockAlert.DataBind();

                int count = GVStockAlert.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    DataSet dSales = objBs.SalesQty(sTableName, txttodate.Text);

                    if (dSales.Tables[0].Rows.Count > 0)
                    {
                        int j = dSales.Tables[0].Rows.Count;
                        for (int k = 0; k < j; k++)
                        {

                            if (Convert.ToInt32(GVStockAlert.Rows[i].Cells[0].Text.ToString()) == Convert.ToInt32(dSales.Tables[0].Rows[k]["categoryuserid"].ToString()))
                            {
                                Label lblsales = (Label)GVStockAlert.Rows[i].Cells[3].FindControl("lblsalesQty");
                                lblsales.Text = dSales.Tables[0].Rows[k]["Qty"].ToString();

                            }
                            else
                            {
                               
                            }
                        }

                    }

                }


                int fC = GVStockAlert.Rows.Count;




                for (int i = 0; i < fC; i++)
                {
                    DataSet dGrn = objBs.grnQty(Convert.ToInt32(lblUserID.Text), sCode, txttodate.Text,sTableName);

                    if (dGrn.Tables[0].Rows.Count > 0)
                    {
                        int j = dGrn.Tables[0].Rows.Count;
                        for (int k = 0; k < j; k++)
                        {

                            if (Convert.ToInt32(GVStockAlert.Rows[i].Cells[0].Text.ToString()) == Convert.ToInt32(dGrn.Tables[0].Rows[k]["categoryuserid"].ToString()))
                            {
                                Label lblsales = (Label)GVStockAlert.Rows[i].Cells[4].FindControl("lblGrn");
                                lblsales.Text = dGrn.Tables[0].Rows[k]["Qty"].ToString();

                            }
                            else
                            {

                            }
                        }

                    }

                }

                int Kount = GVStockAlert.Rows.Count;

                for (int i = 0; i < Kount; i++)
                {
                    DataSet dGrn = objBs.Cuurrentstock(Convert.ToInt32(lblUserID.Text),sTableName);

                    if (dGrn.Tables[0].Rows.Count > 0)
                    {
                        int j = dGrn.Tables[0].Rows.Count;
                        for (int k = 0; k < j; k++)
                        {

                            if (Convert.ToInt32(GVStockAlert.Rows[i].Cells[0].Text.ToString()) == Convert.ToInt32(dGrn.Tables[0].Rows[k]["categoryuserid"].ToString()))
                            {
                                Label lblsales = (Label)GVStockAlert.Rows[i].Cells[5].FindControl("lblCurrent");
                                lblsales.Text = dGrn.Tables[0].Rows[k]["Qty"].ToString();

                            }
                            else
                            {

                            }
                        }

                    }

                }
            }

        }
    }
}