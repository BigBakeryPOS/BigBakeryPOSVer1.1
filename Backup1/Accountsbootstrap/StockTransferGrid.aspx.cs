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
namespace Billing.Accountsbootstrap
{
    public partial class StockTransferGrid : System.Web.UI.Page
    {
        BSClass obj = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = obj.RequestFromStore(sTableName);
            gridview.DataSource = ds;
            gridview.DataBind();
        }

      

        protected void page_change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = obj.RequestFromStore(sTableName);
            gridview.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gridview.DataSource = dvEmployee;
            gridview.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            int iCount = gridview.Rows.Count;
            if (txtsentby.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter Name');", true);
            }
            else
            {
                for (int i = 0; i < iCount; i++)
                {
                    int StockID = Convert.ToInt32(gridview.Rows[i].Cells[4].Text.ToString());
                    string From = (gridview.Rows[i].Cells[5].Text.ToString());
                    int SubCatID = Convert.ToInt32(gridview.Rows[i].Cells[3].Text.ToString());
                    int CatID = Convert.ToInt32(gridview.Rows[i].Cells[6].Text.ToString());
                    int ReqQty = Convert.ToInt32(gridview.Rows[i].Cells[7].Text.ToString());
                    int ReqNo = Convert.ToInt32(gridview.Rows[i].Cells[0].Text.ToString());

                    DataSet dStkQty = obj.CheckStockQty(Convert.ToInt32(StockID), sTableName);//Sub
                    DataSet dStkQtyFrom = obj.CheckStockQty(Convert.ToInt32(SubCatID), (From)); //ADD

                    if (dStkQty.Tables[0].Rows.Count > 0)
                    {
                        decimal dAvlQty = Convert.ToDecimal(dStkQty.Tables[0].Rows[0]["Available_QTY"].ToString());
                        decimal ReqstQty = Convert.ToDecimal(ReqQty);

                        decimal Bal = dAvlQty - ReqstQty;

                        int isub = obj.SubStockQty(Convert.ToInt32(SubCatID), Convert.ToInt32(StockID), Bal, sTableName,ReqNo.ToString());

                    }

                    //if (dStkQtyFrom.Tables[0].Rows.Count > 0)
                    //{
                    //    decimal dAvlQty = Convert.ToDecimal(dStkQty.Tables[0].Rows[0]["Available_QTY"].ToString());
                    //    decimal ReqstQty = Convert.ToDecimal(ReqQty);

                    //    decimal Bal = dAvlQty + ReqstQty;

                    //    int Add = obj.ADDStockQty(Convert.ToInt32(SubCatID), Bal, From);

                    //}

                    //else
                    //{
                    int iRtn = obj.stockinserfromstore(From, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(CatID), Convert.ToInt32(SubCatID), Convert.ToDouble(ReqQty), Convert.ToDouble(ReqQty), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), (DateTime.Now.ToString()), 0);
                    //}
                    int iUpdateReq = obj.UpdateStockReq(Convert.ToInt32(ReqNo), Convert.ToInt32(SubCatID), Convert.ToInt32(StockID),txtsentby.Text);


                }
                Response.Redirect("StockTransferGrid.aspx");
            }
        }

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                if (txtsentby.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter Name');", true);
                }
                else
                {
                    string[] arg = new string[6];
                    arg = e.CommandArgument.ToString().Split(';');
                    string ReqNo = arg[0];
                    string SubCatID = arg[1];
                    string StockID = arg[2];
                    string From = arg[3];
                    string ReqQty = arg[4];
                    string CatID = arg[5];

                    DataSet dStkQty = obj.CheckStockQty(Convert.ToInt32(StockID), sTableName);//Sub
                    DataSet dStkQtyFrom = obj.CheckStockQty(Convert.ToInt32(SubCatID), (From)); //ADD

                    if (dStkQty.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(dStkQty.Tables[0].Rows[0]["Available_QTY"]) > 0)
                        {
                            decimal dAvlQty = Convert.ToDecimal(dStkQty.Tables[0].Rows[0]["Available_QTY"].ToString());
                            decimal ReqstQty = Convert.ToDecimal(ReqQty);

                            decimal Bal = dAvlQty - ReqstQty;

                            int isub = obj.SubStockQty(Convert.ToInt32(SubCatID), Convert.ToInt32(StockID), Bal, sTableName, ReqNo);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('ஸ்டாக் இல்லை');", true);
                        }
                       

                    }

                    ////if (dStkQtyFrom.Tables[0].Rows.Count > 0)
                    ////{
                    //    decimal dAvlQty = Convert.ToDecimal(dStkQty.Tables[0].Rows[0]["Available_QTY"].ToString());
                    //    decimal ReqstQty = Convert.ToDecimal(ReqQty);

                    //    decimal Bal = dAvlQty + ReqstQty;

                    //    int Add = obj.ADDStockQty(Convert.ToInt32(SubCatID), Bal, (From) );

                    //}

                    //else
                    //{
                    int iRtn = obj.stockinserfromstore(From, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(CatID), Convert.ToInt32(SubCatID), Convert.ToDouble(ReqQty), Convert.ToDouble(ReqQty), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), (DateTime.Now.ToString()), 0);
                    //}
                    int iUpdateReq = obj.UpdateStockReq(Convert.ToInt32(ReqNo), Convert.ToInt32(SubCatID), Convert.ToInt32(StockID),txtsentby.Text);

                    Response.Redirect("StockTransferGrid.aspx");

                }
            }
        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in gridview.Rows)
            {
                int StockID = Convert.ToInt32(row.Cells[4].Text);

                DataSet dStkQty = obj.CheckStockQty(Convert.ToInt32(StockID), sTableName);//Sub

                if (dStkQty.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dStkQty.Tables[0].Rows[0]["Available_QTY"]) > 0)
                    {
                        
                    }
                    else
                    {
                        LinkButton link = (LinkButton)row.FindControl("btnaccept");

                        link.Enabled = false;
                    }

                }
                else
                {
                    LinkButton link = (LinkButton)row.FindControl("btnaccept");

                   link.Enabled = false;
                }
            }
        }
    }
}