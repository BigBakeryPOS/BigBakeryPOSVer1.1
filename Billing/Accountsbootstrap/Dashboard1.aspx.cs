using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        DataSet tbllogin = new DataSet();
        
        DBAccess DBAccess = new DBAccess();
        string Sort_Direction = "Category ASC";
        string sTableName = "";
        string superadmin = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            this.ClientTarget = "uplevel";
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
            //    DataSet dsPONo = null;// objBs.getPurchaseOrderReportPONo();
            //    if (dsPONo.Tables[0].Rows.Count > 0)
            //    {
            //        chkPONo.DataSource = dsPONo.Tables[0];
            //        chkPONo.DataTextField = "FullPONo";
            //        chkPONo.DataValueField = "POId";
            //        chkPONo.DataBind();

            //    }

                string FromDate = System.DateTime.Today.ToString("yyyy-MM-dd hh:mm tt");
                string ToDate = System.DateTime.Today.ToString("yyyy-MM-dd hh:mm tt");
                
                DataSet dsTodays =objBs.GetDash_sales (sTableName,FromDate,ToDate);
            //    DataSet dsNewCustomer = null;// objBs.GetTodaysBuyer();

            //   int Todays = Convert.ToInt32(dsTodays.Tables[0].Rows[0]["Todays"].ToString());
            //    double SalesAmount = Convert.ToDouble(dsTodays.Tables[0].Rows[0]["Amount"]);
            //    int LastOrderNo = Convert.ToInt32(dsTodays.Tables[0].Rows[0]["BuyerOrderId"].ToString());
            //    int NewCustomer = Convert.ToInt32(dsNewCustomer.Tables[0].Rows[0]["ledgerid"].ToString());

                txtTodaysOrder.Text =" 0";// Convert.ToString(Todays);
                txtSalesAmount.Text = "0";// Convert.ToDouble(SalesAmount).ToString("f2");
                txtLastOrderNo.Text = "0";// Convert.ToString(LastOrderNo);
                txtNewCustomer.Text = "0";// Convert.ToString(NewCustomer);

            //    BindData();
            //    PoPendingBindData();
            //    TopCostingBindData();
            //    StockBindData();
            //    RequirementBindData();
            //    BindDataBuyerSummery();
            //    BindDataCurrentFab();
            //    BindDataShipmentdet();
            }


        }

        protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {


            DataSet dsTopBuyer = null;// objBs.GetTopBuyer(drpYearCode.SelectedValue);
            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsTopBuyer.Tables[0].Rows.Count; i++)
            {

                string BuyerCode = dsTopBuyer.Tables[0].Rows[i]["BuyerCodeID"].ToString();
                string CurrencyName = dsTopBuyer.Tables[0].Rows[i]["CurrencyName"].ToString();
                string CompanyCode = dsTopBuyer.Tables[0].Rows[i]["CompanyCode"].ToString();
                string CompanyName = dsTopBuyer.Tables[0].Rows[i]["CompanyName"].ToString();
                string Amount = Convert.ToDouble(dsTopBuyer.Tables[0].Rows[i]["Amount"]).ToString("f2");
                string MobileNo = dsTopBuyer.Tables[0].Rows[i]["MobileNo"].ToString();
                string PhoneNo = dsTopBuyer.Tables[0].Rows[i]["PhoneNo"].ToString();
                string Area = dsTopBuyer.Tables[0].Rows[i]["Area"].ToString();
                string Email = dsTopBuyer.Tables[0].Rows[i]["Email"].ToString();
                string ContactPerson = dsTopBuyer.Tables[0].Rows[i]["ContacrPerson"].ToString();


                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + BuyerCode + "</td>" +
                                    "			    		<td>" + CompanyCode + "</td>" +
                                      "			    		<td>" + CompanyName + "</td>" +
                                         "			    	<td>" + CurrencyName + "</td>" +
                                       "			    	<td>" + Amount + "</td>" +
                                         "                  <td>" + MobileNo + "</td>" +
                                           "                <td>" + PhoneNo + "</td>" +
                                             "              <td>" + Area + "</td>" +
                                               "            <td>" + Email + "</td>" +
                                                 "          <td>" + ContactPerson + "</td>" +


                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            txtVillageSplitUp.Text = spList.ToString();
            #endregion
        }
       

        private void BindDataBuyerSummery()
        {
            DataSet dsBuyerSummery = null;// objBs.BindDataBuyerSummery();

            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsBuyerSummery.Tables[0].Rows.Count; i++)
            {

                string BuyerName = dsBuyerSummery.Tables[0].Rows[i]["BuyerName"].ToString();
                string ExcNo = dsBuyerSummery.Tables[0].Rows[i]["ExcNo"].ToString();
                string StyleNo = dsBuyerSummery.Tables[0].Rows[i]["StyleNo"].ToString();
                string Description = dsBuyerSummery.Tables[0].Rows[i]["Description"].ToString();
               
                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + BuyerName + "</td>" +
                                    "			    		<td>" + ExcNo + "</td>" +
                                      "			    		<td>" + StyleNo + "</td>" +
                                       "			    		<td>" + Description + "</td>" +
                                        

                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblBuyerSummary.Text = spList.ToString();
            #endregion
        }

      

        private void BindDataCurrentFab()
        {
            DataSet dsCurrentFab = null;// objBs.BindDataCurrentFab();


            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsCurrentFab.Tables[0].Rows.Count; i++)
            {
                string purchasefortype = dsCurrentFab.Tables[0].Rows[i]["purchasefortype"].ToString();
                string Item = dsCurrentFab.Tables[0].Rows[i]["Item"].ToString();

                string date = dsCurrentFab.Tables[0].Rows[i]["ShipmentDate"].ToString();
                string ShipmentDate = Convert.ToDateTime(date).ToString("dd/MM/yyyy");

                string date1 = dsCurrentFab.Tables[0].Rows[i]["OrderDate"].ToString();
                string OrderDate = Convert.ToDateTime(date1).ToString("dd/MM/yyyy");

                string date2 = dsCurrentFab.Tables[0].Rows[i]["DeliveryDate"].ToString();
                string DeliveryDate = Convert.ToDateTime(date2).ToString("dd/MM/yyyy");

                string Qty = dsCurrentFab.Tables[0].Rows[i]["Qty"].ToString();
                string RecQty = dsCurrentFab.Tables[0].Rows[i]["RecQty"].ToString();
                string BalQty = dsCurrentFab.Tables[0].Rows[i]["BalQty"].ToString();
              




                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + purchasefortype + "</td>" +
                                    "			    		<td>" + Item + "</td>" +
                                      "			    		<td>" + ShipmentDate + "</td>" +
                                       "			    		<td>" + OrderDate + "</td>" +
                                        "			    		<td>" + DeliveryDate + "</td>" +
                                         "			    		<td>" + Qty + "</td>" +
                                          "			    		<td>" + RecQty + "</td>" +
                                           "			    		<td>" + BalQty + "</td>" +
                                         

                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblCurrentFabric.Text = spList.ToString();
            #endregion
            
        }

        

        private void BindDataShipmentdet()
        {
            DataSet dsShipmentdet = null; // objBs.BindDataShipmentdet();


            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsShipmentdet.Tables[0].Rows.Count; i++)
            {
                string ExcNo = dsShipmentdet.Tables[0].Rows[i]["ExcNo"].ToString();
                string StyleNo = dsShipmentdet.Tables[0].Rows[i]["StyleNo"].ToString();
                string ItemDescription = dsShipmentdet.Tables[0].Rows[i]["ItemDescription"].ToString();

                string date = dsShipmentdet.Tables[0].Rows[i]["ShipmentDate"].ToString();
                string ShipmentDate = Convert.ToDateTime(date).ToString("dd/MM/yyyy");
                string Color = dsShipmentdet.Tables[0].Rows[i]["Color"].ToString();
                string Qty = dsShipmentdet.Tables[0].Rows[i]["Qty"].ToString();
                string size = dsShipmentdet.Tables[0].Rows[i]["size"].ToString();





                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + ExcNo + "</td>" +
                                    "			    		<td>" + StyleNo + "</td>" +
                                      "			    		<td>" + ItemDescription + "</td>" +
                                       "			    		<td>" + ShipmentDate + "</td>" +
                                        "			    		<td>" + Color + "</td>" +
                                         "			    		<td>" + Qty + "</td>" +
                                          "			    		<td>" + size + "</td>" +
                                    

                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblBuyerOrder.Text = spList.ToString();
            #endregion
        }

        
 

        protected void PoPendingBindData()
        {

            string ItemPOId = "";
            string IsFirst = "Yes";
            foreach (ListItem listItem in chkPONo.Items)
            {
                #region
                if (chkPONo.SelectedIndex < 0)
                {
                    if (IsFirst == "Yes")
                    {
                        ItemPOId = listItem.Value;
                        IsFirst = "No";
                    }
                    else
                    {
                        ItemPOId = ItemPOId + "," + listItem.Value;
                    }
                }
                else
                {
                    if (listItem.Selected)
                    {
                        if (IsFirst == "Yes")
                        {
                            ItemPOId = listItem.Value;
                            IsFirst = "No";
                        }
                        else
                        {
                            ItemPOId = ItemPOId + "," + listItem.Value;
                        }
                    }
                }
                #endregion
            }


            DataSet dsStyles = null;// objBs.GetPendingPO("All", ">", ItemPOId, "All");

          
            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsStyles.Tables[0].Rows.Count; i++)
            {
                string date = dsStyles.Tables[0].Rows[i]["OrderDate"].ToString();
                string OrderDate = Convert.ToDateTime(date).ToString("dd/MM/yyyy");                
                string FULLPONO = dsStyles.Tables[0].Rows[i]["FULLPONO"].ToString();
                string PARTY = dsStyles.Tables[0].Rows[i]["PARTY"].ToString();
                string PURCHASEFORTYPE = dsStyles.Tables[0].Rows[i]["PURCHASEFORTYPE"].ToString();
                string QTY = Convert.ToDouble(dsStyles.Tables[0].Rows[i]["QTY"]).ToString("f2");
                string RECQTY = Convert.ToDouble(dsStyles.Tables[0].Rows[i]["RECQTY"]).ToString("f2");
                string BALQTY = Convert.ToDouble(dsStyles.Tables[0].Rows[i]["BALQTY"]).ToString("f2");
                string UNITS = dsStyles.Tables[0].Rows[i]["UNITS"].ToString();
                string COMPANYCODE = dsStyles.Tables[0].Rows[i]["COMPANYCODE"].ToString();




                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + OrderDate + "</td>" +
                                    "			    		<td>" + FULLPONO + "</td>" +
                                      "			    		<td>" + PARTY + "</td>" +
                                       "			    		<td>" + PURCHASEFORTYPE + "</td>" +
                                        "			    		<td>" + QTY + "</td>" +
                                         "			    		<td>" + RECQTY + "</td>" +
                                          "			    		<td>" + BALQTY + "</td>" +
                                           "			    		<td>" + UNITS + "</td>" +
                                            "			    		<td>" + COMPANYCODE + "</td>" +

                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblPoPending.Text = spList.ToString();
            #endregion

        }

        protected void TopCostingBindData()
        {


            DataSet dsTopCosting = null;// objBs.GetTopCosting();

            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsTopCosting.Tables[0].Rows.Count; i++)
            {

                string StyleNo = dsTopCosting.Tables[0].Rows[i]["StyleNo"].ToString();
                string BuyerCodeId = dsTopCosting.Tables[0].Rows[i]["BuyerCodeId"].ToString();
                string Description = dsTopCosting.Tables[0].Rows[i]["Description"].ToString();
                string FabricationCost = Convert.ToDouble(dsTopCosting.Tables[0].Rows[i]["FabricationCost"]).ToString("f2");
                string FinishingandPackingCost = Convert.ToDouble(dsTopCosting.Tables[0].Rows[i]["FinishingandPackingCost"]).ToString("f2");
                string ItemPrdCost = Convert.ToDouble(dsTopCosting.Tables[0].Rows[i]["ItemPrdCost"]).ToString("f2");
                string CurrencyName = dsTopCosting.Tables[0].Rows[i]["CurrencyName"].ToString();
                 




                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + StyleNo + "</td>" +
                                    "			    		<td>" + BuyerCodeId + "</td>" +
                                      "			    		<td>" + Description + "</td>" +
                                       "			    		<td>" + FabricationCost + "</td>" +
                                        "			    		<td>" + FinishingandPackingCost + "</td>" +
                                         "			    		<td>" + ItemPrdCost + "</td>" +
                                          "			    		<td>" + CurrencyName + "</td>" +
                                         
                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblCosting.Text = spList.ToString();
            #endregion

        }

        protected void StockBindData()
        {
            DataSet dsStock = null;// objBs.GetStockDetils();
            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsStock.Tables[0].Rows.Count; i++)
            {

                string ItemId = dsStock.Tables[0].Rows[i]["ItemId"].ToString();
                string Description = dsStock.Tables[0].Rows[i]["Description"].ToString();
                string Qty = Convert.ToDouble(dsStock.Tables[0].Rows[i]["Qty"]).ToString("f2");




                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + ItemId + "</td>" +
                                    "			    		<td>" + Description + "</td>" +
                                      "			    		<td>" + Qty + "</td>" +

                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblStockDetails.Text = spList.ToString();
            #endregion
        }

        protected void RequirementBindData()
        {
            DataSet dsRequirement = null;// objBs.GetRequirementDetils();


            #region Table
            StringBuilder spList = new StringBuilder();


            for (int i = 0; i < dsRequirement.Tables[0].Rows.Count; i++)
            {

                string RequirementId = dsRequirement.Tables[0].Rows[i]["RequirementId"].ToString();
                string ItemGroupCode = dsRequirement.Tables[0].Rows[i]["ItemGroupCode"].ToString();
                string Itemgroupname = dsRequirement.Tables[0].Rows[i]["Itemgroupname"].ToString();
                string Color = dsRequirement.Tables[0].Rows[i]["Color"].ToString();
                string SampleQty = dsRequirement.Tables[0].Rows[i]["SampleQty"].ToString();
                string ProductionQty = dsRequirement.Tables[0].Rows[i]["ProductionQty"].ToString();
                string Units = dsRequirement.Tables[0].Rows[i]["Units"].ToString();



                spList.Append("			    	   <tr >" +
                  "  <td  style='display:none'>" +
                                           " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                "<input type='checkbox' class='checkboxes' value='1' />" +
                                                "<span></span>" +
                                            "</label>" +
                                       " </td>" +

                                      "                     <td>" + RequirementId + "</td>" +
                                    "			    		<td>" + ItemGroupCode + "</td>" +
                                      "			    		<td>" + Itemgroupname + "</td>" +
                                       "			    		<td>" + Color + "</td>" +
                                         "                     <td>" + SampleQty + "</td>" +
                                           "                     <td>" + ProductionQty + "</td>" +
                                             "                     <td>" + Units + "</td>" +



                                "			    	</tr>");




            }


            //IDTotal.Visible = true;
            lblRequirement.Text = spList.ToString();
            #endregion

            //if (dsRequirement.Tables[0].Rows.Count > 0)
            //{
            //    gvRequirement.DataSource = dsRequirement;
            //    gvRequirement.DataBind();
            //}
            //else
            //{
            //    gvRequirement.DataSource = null;
            //    gvRequirement.DataBind();
            //}
        }
    }
}