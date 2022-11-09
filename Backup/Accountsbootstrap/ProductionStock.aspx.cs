using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class ProductionStock : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {
                DataSet dReqNo = objbs.getProductionStock(sTableName);
                txtpono.Text = dReqNo.Tables[0].Rows[0]["ProdNO"].ToString();
                txtpodate.Text = DateTime.Now.ToString();



                var tab = new[] { tab0, tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab16, tab17, tab18, tab19, tab20 };
                var itm = new[] { lblitem, lblitem1, lblitem2, lblitem3, lblitem4, lblitem5, lblitem6, lblitem7, lblitem8, lblitem9, lblitem10, lblitem11, lblitem12, lblitem13, lblitem14, lblitem15, lblitem16, lblitem17, lblitem18, lblitem19, lblitem20 };
                var Grid = new[] { gvGateaux, gvSnacks, gvPuddings, gvBeverages, gvSweets, gvcandles, gvMousse, gvCookies, gvcheese, gvStores, gvBday, gvbread, gvSponges, gvReadySp, gvRmCake, gvIce, gv16, gv17, gv18, gv19, gv20 };
                DataSet dcat = objbs.selectCAT();

                int count = dcat.Tables[0].Rows.Count;
                if (count >= 20)
                {
                    count = 20;
                }

                for (int i = 0; i < count; i++)
                {
                    tab[i].Style.Add("visibility", "visible");
                    itm[i].InnerText = dcat.Tables[0].Rows[i]["category"].ToString();

                    DataSet dGateaux = objbs.getItemsnewitems(int.Parse(dcat.Tables[0].Rows[i]["categoryid"].ToString()), sCode);
                    Grid[i].DataSource = dGateaux;
                    Grid[i].DataBind();


                    foreach (GridViewRow gr in Grid[i].Rows)
                    {

                        #region

                        int itemid = Convert.ToInt32(gr.Cells[3].Text);
                        DataSet dCategory = objbs.getUOM();

                        DataSet dsUnit = objbs.GetCategoryDetails_ById(itemid);
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");


                        DropDownList Units = (DropDownList)gr.FindControl("ddUnits");
                        if (dCategory.Tables[0].Rows.Count > 0)
                        {
                            Units.DataSource = dCategory.Tables[0];
                            Units.DataTextField = "UOM";
                            Units.DataValueField = "UOMID";
                            Units.DataBind();
                            Units.Items.Insert(0, "Select");
                            if (dsUnit.Tables[0].Rows.Count > 0)
                            {
                                Units.SelectedValue = dsUnit.Tables[0].Rows[0]["Unit"].ToString();
                            }
                        }

                        Units.SelectedValue = gr.Cells[5].Text;

                        #endregion
                    }
                }
            }
        }



        protected void btsAVE_Click(object sender, EventArgs e)
        {

            if (txtOrderBy.Text == "" || txtOrderBy.Text == "0")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('Updated By');", true);
                return;
            }



            #region Check Receipe
            var GridCheck = new[] { gvGateaux, gvSnacks, gvPuddings, gvBeverages, gvSweets, gvcandles, gvMousse, gvCookies, gvcheese, gvStores, gvBday, gvbread, gvSponges, gvReadySp, gvRmCake, gvIce, gv16, gv17, gv18, gv19, gv20 };
            for (int i = 0; i < 20; i++)
            {
                foreach (GridViewRow gr in GridCheck[i].Rows)
                {
                    TextBox txtQty = (TextBox)gr.FindControl("txtQty");

                    if (txtQty.Text != "0" && txtQty.Text != "")
                    {

                        string Item = gr.Cells[1].Text;
                        int iSubCatID = Convert.ToInt32(gr.Cells[3].Text);


                        DataSet ds = objbs.Checkreceipe(iSubCatID);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('" + Item + " Was Does Not Set in Receipe.');", true);
                            return;
                        }


                    }

                }
            }
            #endregion


            DateTime Date = Convert.ToDateTime(txtpodate.Text);
            string sDate = Date.ToString("yyyy-MM-dd hh:mm tt");
            DataSet dReqNo = objbs.getProductionStock(sTableName);
            txtpono.Text = dReqNo.Tables[0].Rows[0]["ProdNO"].ToString();

            int isave = objbs.ProductionStock(txtpono.Text, sDate, "Production Stock", sTableName, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text);

            var Grid = new[] { gvGateaux, gvSnacks, gvPuddings, gvBeverages, gvSweets, gvcandles, gvMousse, gvCookies, gvcheese, gvStores, gvBday, gvbread, gvSponges, gvReadySp, gvRmCake, gvIce, gv16, gv17, gv18, gv19, gv20 };
            for (int i = 0; i < 20; i++)
            {
                foreach (GridViewRow gr in Grid[i].Rows)
                {
                    TextBox txtQty = (TextBox)gr.FindControl("txtQty");

                    if (txtQty.Text != "0" && txtQty.Text != "")
                    {
                        int iCatID = Convert.ToInt32(gr.Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gr.Cells[3].Text);

                        decimal TotQty = Convert.ToDecimal(txtQty.Text);

                        int iSAve = objbs.TransProductionStock(sTableName, txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty));

                    }

                }
            }

            Response.Redirect("productionstock.aspx");
        }
    }
}