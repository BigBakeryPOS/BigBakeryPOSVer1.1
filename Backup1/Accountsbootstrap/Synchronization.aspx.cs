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
using System.Configuration;
using System.Data.SqlClient;


namespace Billing.Accountsbootstrap
{
    public partial class Synchronization : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        DBAccess DBAccess = new DBAccess();
        string Sort_Direction = "Category ASC";
        string sTableName = "";
        string superadmin = "";

        private string connnectionString;
        private string connnectionStringMain;

        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                Type_chnaged(sender, e);
            }
        }


        protected void Type_chnaged(object sender, EventArgs e)
        {

            if (drptype.SelectedValue == "1")
            {
                Div2.Visible = false;
                grdlist.Visible = false;
            }
            else
            {
                Div2.Visible = true;
                grdlist.Visible = true;
            }

        }


        protected void chkitem(object sender, EventArgs e)
        {

            if (chkgetitem.Checked == true)
            {

                if (drptype.SelectedValue == "1")
                {
                    Div2.Visible = false;
                    grdlist.Visible = false;
                }
                else
                {
                    Div2.Visible = true;
                    grdlist.Visible = true;
                    gridview2.Visible = false;
                    DataSet dgetcategry = objBs.getcategoryLiveeSync(txtdate.Text);
                    if (dgetcategry.Tables[0].Rows.Count > 0)
                    {
                        gridview.DataSource = dgetcategry.Tables[0];
                        gridview.DataBind();
                        gridview2.Visible = false;

                    }
                    else
                    {
                        gridview.DataSource = null;
                        gridview.DataBind();
                        gridview2.Visible = false;
                    }

                    DataSet dgetitem = objBs.getItemLiveeSync(txtdate.Text);
                    if (dgetitem.Tables[0].Rows.Count > 0)
                    {
                        gridview1.DataSource = dgetitem.Tables[0];
                        gridview1.DataBind();
                        gridview2.Visible = false;
                    }
                    else
                    {
                        gridview1.DataSource = null;
                        gridview1.DataBind();
                        gridview2.Visible = false;
                    }

                    DataSet dsgrid = objBs.gridstoresettingHistory(txtdate.Text);
                    if (dsgrid.Tables[0].Rows.Count > 0)
                    {
                        gridview2.Visible = true;
                        gridview2.DataSource = dsgrid;
                        gridview2.DataBind();
                    }
                    else
                    {
                        gridview2.Visible = true;
                        gridview2.DataSource = null;
                        gridview2.DataBind();
                    }
                }
            }
            else
            {
                gridview.DataSource = null;
                gridview.DataBind();

                gridview1.DataSource = null;
                gridview1.DataBind();

                gridview2.DataSource = null;
                gridview2.DataBind();


            }

        }


        protected void btnsyncinguom_OnClick(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!');window.location ='synchronization.aspx';", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                return;

            }

            int isysc = objBs.InsertSync(txtempname.Text, "UOM Master", drptype.SelectedItem.Text, "BNCH");

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            // SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tbluom", destination);
            //  SqlCommand cmdbranch = new SqlCommand("truncate table tbluom", destination);



            // Open source and destination connections.
            //   source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();


            // Close objects
            //bulkData.Close();
            destination.Close();
            //source.Close();

            DataSet dservercat = objBs.getUOMdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int uomid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["uomid"]);

                    string UOM = (dservercat.Tables[0].Rows[i]["uom"]).ToString();

                    string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();

                    int iids = objBs.syncinsertuom(uomid, UOM, IsActive);
                }
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }


        protected void Branch_Sync(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }

            int isysc = objBs.InsertSync(txtempname.Text, "Branch Master", drptype.SelectedItem.Text, "BNCH");

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            // SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tblbranch", destination);
            //  SqlCommand cmdbranch = new SqlCommand("truncate table tbluom", destination);



            // Open source and destination connections.
            //   source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();


            // Close objects
            //bulkData.Close();
            destination.Close();
            //source.Close();

            DataSet dservercat = objBs.getbranchdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int BranchId = Convert.ToInt32(dservercat.Tables[0].Rows[i]["BranchId"]);

                    string BranchName = (dservercat.Tables[0].Rows[i]["BranchName"]).ToString();

                    string ContactName = (dservercat.Tables[0].Rows[i]["ContactName"]).ToString();

                    string Country = (dservercat.Tables[0].Rows[i]["Country"]).ToString();
                    string State = (dservercat.Tables[0].Rows[i]["State"]).ToString();
                    string City = (dservercat.Tables[0].Rows[i]["City"]).ToString();
                    string Address = (dservercat.Tables[0].Rows[i]["Address"]).ToString();
                    string MobileNo = (dservercat.Tables[0].Rows[i]["MobileNo"]).ToString();
                    string LandLine = (dservercat.Tables[0].Rows[i]["LandLine"]).ToString();
                    string Email = (dservercat.Tables[0].Rows[i]["Email"]).ToString();
                    string Currency = (dservercat.Tables[0].Rows[i]["Currency"]).ToString();
                    string LOGO = (dservercat.Tables[0].Rows[i]["LOGO"]).ToString();
                    string BranchCode = (dservercat.Tables[0].Rows[i]["BranchCode"]).ToString();
                    string BranchArea = (dservercat.Tables[0].Rows[i]["BranchArea"]).ToString();
                    string GSTIN = (dservercat.Tables[0].Rows[i]["GSTIN"]).ToString();
                    string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                    string BranchType = (dservercat.Tables[0].Rows[i]["BranchType"]).ToString();
                    string Pincode = (dservercat.Tables[0].Rows[i]["Pincode"]).ToString();
                    string BranchOwnType = (dservercat.Tables[0].Rows[i]["BranchOwnType"]).ToString();

                    string FranchiseeName = (dservercat.Tables[0].Rows[i]["FranchiseeName"]).ToString();
                    string OnlineSalesActive = (dservercat.Tables[0].Rows[i]["OnlineSalesActive"]).ToString();
                    string Pemail = (dservercat.Tables[0].Rows[i]["Pemail"]).ToString();
                    string Iemail = (dservercat.Tables[0].Rows[i]["Iemail"]).ToString();
                    string Oemail = (dservercat.Tables[0].Rows[i]["Oemail"]).ToString();
                    string Mtype = (dservercat.Tables[0].Rows[i]["Mtype"]).ToString();

                    string Printtype = (dservercat.Tables[0].Rows[i]["Printtype"]).ToString();

                    string OnlineCakeSync = (dservercat.Tables[0].Rows[i]["OnlineCakeSync"]).ToString();

                    string dipatchdirectly = (dservercat.Tables[0].Rows[i]["dipatchdirectly"]).ToString();
                    string Fssaino = (dservercat.Tables[0].Rows[i]["Fssaino"]).ToString();
                    string onlinepos = (dservercat.Tables[0].Rows[i]["onlinepos"]).ToString();

                   string PrintOption= (dservercat.Tables[0].Rows[i]["PrintOption"]).ToString();
                   string StockOption = (dservercat.Tables[0].Rows[i]["StockOption"]).ToString();
                   string Imagepath = (dservercat.Tables[0].Rows[i]["Imagepath"]).ToString();
                   string Username = (dservercat.Tables[0].Rows[i]["Username"]).ToString();
                   string Password = (dservercat.Tables[0].Rows[i]["Password"]).ToString();
                   string BillCode = (dservercat.Tables[0].Rows[i]["BillCode"]).ToString();
                   string BillGenerateSetting = (dservercat.Tables[0].Rows[i]["BillGenerateSetting"]).ToString();
                   string Billtaxsplitupshown = (dservercat.Tables[0].Rows[i]["Billtaxsplitupshown"]).ToString();
                   string BillPrintLogo = (dservercat.Tables[0].Rows[i]["BillPrintLogo"]).ToString();
                   string BigVersion = (dservercat.Tables[0].Rows[i]["BigVersion"]).ToString();
                   string TaxSetting = (dservercat.Tables[0].Rows[i]["TaxSetting"]).ToString();
                   string Ratesetting = (dservercat.Tables[0].Rows[i]["Ratesetting"]).ToString();
                   string Qtysetting = (dservercat.Tables[0].Rows[i]["Qtysetting"]).ToString();
                   string possalessetting = (dservercat.Tables[0].Rows[i]["possalessetting"]).ToString();
                   string RoundoffSetting = (dservercat.Tables[0].Rows[i]["RoundoffSetting"]).ToString();


                   int iids = objBs.syncinsertbranch(BranchId, BranchName, ContactName, Country, State, City, Address, MobileNo, LandLine, Email, Currency, LOGO, BranchCode, BranchArea, GSTIN, IsActive, BranchType, Pincode, BranchOwnType, FranchiseeName, OnlineSalesActive, Pemail, Iemail, Oemail, Mtype, Printtype, OnlineCakeSync, dipatchdirectly, Fssaino, onlinepos, PrintOption, StockOption, Imagepath, Username, Password, BillCode, BillGenerateSetting, Billtaxsplitupshown, BillPrintLogo, BigVersion, TaxSetting, Ratesetting, Qtysetting, possalessetting, RoundoffSetting);
                }
            }
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }


        protected void BranchSetting_sync(object sender, EventArgs e)
        {


            if (txtempname.Text == "")
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!');window.location ='synchronization.aspx';", true);
                return;

            }

            int isysc = objBs.InsertSync(txtempname.Text, "Branch Production Setting", drptype.SelectedItem.Text, "BNCH");

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            // SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tblbranchsetting", destination);
            //  SqlCommand cmdbranch = new SqlCommand("truncate table tbluom", destination);



            // Open source and destination connections.
            //   source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();


            // Close objects
            //bulkData.Close();
            destination.Close();
            //source.Close();

            DataSet dservercat = objBs.getbranchsettingdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int Settingid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["Settingid"]);
                    string BranchNo = (dservercat.Tables[0].Rows[i]["BranchNo"]).ToString();
                    string BranchId = (dservercat.Tables[0].Rows[i]["BranchId"]).ToString();
                    string BranchCode = (dservercat.Tables[0].Rows[i]["BranchCode"]).ToString();
                    string ProductionId = (dservercat.Tables[0].Rows[i]["ProductionId"]).ToString();
                    string Productioncode = (dservercat.Tables[0].Rows[i]["Productioncode"]).ToString();
                    string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                    string Narration = (dservercat.Tables[0].Rows[i]["Narration"]).ToString();


                    string IcingId = (dservercat.Tables[0].Rows[i]["IcingId"]).ToString();
                    string IcingCode = (dservercat.Tables[0].Rows[i]["IcingCode"]).ToString();


                    int iids = objBs.syncinsertbranchsetting(Settingid, BranchNo, BranchId, BranchCode, ProductionId, Productioncode, IsActive, Narration, IcingId, IcingCode);
                }
            }
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }


        protected void InterBranch_sync(object sender, EventArgs e)
        {


            if (txtempname.Text == "")
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }

            int isysc = objBs.InsertSync(txtempname.Text, "Inter Branch Setting", drptype.SelectedItem.Text, "BNCH");

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            // SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmdinter = new SqlCommand("truncate table tblinterbranchsetting", destination);
            SqlCommand cmdtransinter = new SqlCommand("truncate table tbltransinterbranchsetting", destination);



            // Open source and destination connections.
            //   source.Open();
            destination.Open();
            cmdinter.ExecuteNonQuery();
            cmdtransinter.ExecuteNonQuery();


            // Close objects
            //bulkData.Close();
            destination.Close();
            //source.Close();

            DataSet dservercat = objBs.getInterbranchsettingdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int Interid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["Interid"]);
                    string Branchid = (dservercat.Tables[0].Rows[i]["Branchid"]).ToString();
                    string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                    string BranchName = (dservercat.Tables[0].Rows[i]["BranchName"]).ToString();
                    string BranchCode = (dservercat.Tables[0].Rows[i]["BranchCode"]).ToString();

                    int iids = objBs.syncinsertinterbranchsetting(Interid, Branchid, IsActive, BranchName, BranchCode);

                }
            }

            // TRans Table
            DataSet dservercattrans = objBs.gettransInterbranchsettingdatafromsever("Live");
            if (dservercattrans.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercattrans.Tables[0].Rows.Count; i++)
                {

                    int Transid = Convert.ToInt32(dservercattrans.Tables[0].Rows[i]["Transid"]);
                    string InterBranchid = (dservercattrans.Tables[0].Rows[i]["InterBranchid"]).ToString();
                    string Interid = (dservercattrans.Tables[0].Rows[i]["Interid"]).ToString();
                    string BranchName = (dservercattrans.Tables[0].Rows[i]["BranchName"]).ToString();
                    string BranchCode = (dservercattrans.Tables[0].Rows[i]["BranchCode"]).ToString();

                    int iids = objBs.syncinsertTransinterbranchsetting(Transid, InterBranchid, Interid, BranchName, BranchCode);
                }
            }


            // syncinsertTransinterbranchsetting
            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }


        protected void SalesType_Sync(object sender, EventArgs e)
        {


            //if (txtempname.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
            //    return;

            //}

            //int isysc = objBs.InsertSync(txtempname.Text, "SALES TYPE Setting", drptype.SelectedItem.Text, "BNCH");

            //connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            //connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            //// SqlConnection source = new SqlConnection(connnectionStringMain);

            //SqlConnection destination = new SqlConnection(connnectionString);


            //SqlCommand cmdinter = new SqlCommand("truncate table tblsalestype", destination);
            //SqlCommand cmdtransinter = new SqlCommand("truncate table tbltranssalestype", destination);



            //// Open source and destination connections.
            ////   source.Open();
            //destination.Open();
            //cmdinter.ExecuteNonQuery();
            //cmdtransinter.ExecuteNonQuery();


            //// Close objects
            ////bulkData.Close();
            //destination.Close();
            ////source.Close();

            //DataSet dservercat = objBs.getsalestypeliveserver("Live");
            //if (dservercat.Tables[0].Rows.Count > 0)
            //{

            //    for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
            //    {

            //        int SalesTypeID = Convert.ToInt32(dservercat.Tables[0].Rows[i]["SalesTypeID"]);
            //        string PaymentType = (dservercat.Tables[0].Rows[i]["PaymentType"]).ToString();
            //        string Margin = (dservercat.Tables[0].Rows[i]["Margin"]).ToString();
            //        string GST = (dservercat.Tables[0].Rows[i]["GST"]).ToString();
            //        string PaymentGatway = (dservercat.Tables[0].Rows[i]["PaymentGatway"]).ToString();


            //        string Total = (dservercat.Tables[0].Rows[i]["Total"]).ToString();

            //        string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();

            //        string IsNormal = (dservercat.Tables[0].Rows[i]["IsNormal"]).ToString();

            //        string Isdiscount = (dservercat.Tables[0].Rows[i]["Isdiscount"]).ToString();

            //        string IsInclusiveRate = (dservercat.Tables[0].Rows[i]["IsInclusiveRate"]).ToString();


            //        string OtherDisc = (dservercat.Tables[0].Rows[i]["OtherDisc"]).ToString();

            //        string OrderCount = (dservercat.Tables[0].Rows[i]["OrderCount"]).ToString();

            //        string OrderType = (dservercat.Tables[0].Rows[i]["OrderType"]).ToString();


            //        string Attenderid = (dservercat.Tables[0].Rows[i]["Attenderid"]).ToString();

            //        string attenderpwd = (dservercat.Tables[0].Rows[i]["attenderpwd"]).ToString();



            //        int iids = objBs.syncinsertinterbranchsetting(Interid, Branchid, IsActive, BranchName, BranchCode);

            //    }
            //}

            //// TRans Table
            //DataSet dservercattrans = objBs.gettransInterbranchsettingdatafromsever("Live");
            //if (dservercattrans.Tables[0].Rows.Count > 0)
            //{

            //    for (int i = 0; i < dservercattrans.Tables[0].Rows.Count; i++)
            //    {

            //        int Transid = Convert.ToInt32(dservercattrans.Tables[0].Rows[i]["Transid"]);
            //        string InterBranchid = (dservercattrans.Tables[0].Rows[i]["InterBranchid"]).ToString();
            //        string Interid = (dservercattrans.Tables[0].Rows[i]["Interid"]).ToString();
            //        string BranchName = (dservercattrans.Tables[0].Rows[i]["BranchName"]).ToString();
            //        string BranchCode = (dservercattrans.Tables[0].Rows[i]["BranchCode"]).ToString();

            //        int iids = objBs.syncinsertTransinterbranchsetting(Transid, InterBranchid, Interid, BranchName, BranchCode);
            //    }
            //}


            // syncinsertTransinterbranchsetting
            //      ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('IS IN PROCESS.Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('IS IN PROCESS.Thank You!!!.');window.location ='synchronization.aspx';", true);
        }


        protected void btnsyncingclick_OnClick(object sender, EventArgs e)
        {
            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tblIngridentscategory", destination);
            SqlCommand cmdbranch = new SqlCommand("truncate table tblIngridents", destination);



            // Open source and destination connections.
            source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();
            cmdbranch.ExecuteNonQuery();




            // Select data from Products table
            //  cmditem = new SqlCommand("SELECT * FROM tblIngridentscategory", source);
            //  cmdbranch = new SqlCommand("SELECT * FROM tblIngridents", source);



            //// Create SqlBulkCopy
            //SqlBulkCopy bulkData = new SqlBulkCopy(destination);

            //// Execute reader
            //SqlDataReader reader = cmditem.ExecuteReader();
            //bulkData.DestinationTableName = "tblIngridentscategory";
            //bulkData.WriteToServer(reader);
            //reader.Close();




            //SqlDataReader readerbranch = cmdbranch.ExecuteReader();
            //bulkData.DestinationTableName = "tblIngridents";
            //bulkData.WriteToServer(readerbranch);
            //readerbranch.Close();

            // Close objects
            //  bulkData.Close();
            destination.Close();
            source.Close();

            // GET ALL ING CATEGORY FROM SERVER

            int isysc = objBs.InsertSync(txtempname.Text, "ING.Category/ING", drptype.SelectedItem.Text, "BNCH");

            DataSet dservercat = objBs.getIngcategorygetdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int IngCatID = Convert.ToInt32(dservercat.Tables[0].Rows[i]["IngCatID"]);
                    string IngreCategory = (dservercat.Tables[0].Rows[i]["IngreCategory"]).ToString();
                    string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();




                    int iids = objBs.syncinsertIngcategory(IngCatID, IngreCategory, IsActive);

                }
            }

            // GET INGREDENTS
            DataSet dservering = objBs.getIngdatafromsever("Live");
            if (dservering.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservering.Tables[0].Rows.Count; i++)
                {

                    int IngridID = Convert.ToInt32(dservering.Tables[0].Rows[i]["IngridID"]);
                    string IngredientName = (dservering.Tables[0].Rows[i]["IngredientName"]).ToString();
                    string SupplierName = (dservering.Tables[0].Rows[i]["SupplierName"]).ToString();

                    string Costperkg = (dservering.Tables[0].Rows[i]["Costperkg"]).ToString();
                    string Quantity = (dservering.Tables[0].Rows[i]["Quantity"]).ToString();
                    string UserID = (dservering.Tables[0].Rows[i]["UserID"]).ToString();
                    string Units = (dservering.Tables[0].Rows[i]["Units"]).ToString();
                    string IngCatID = (dservering.Tables[0].Rows[i]["IngCatID"]).ToString();
                    string IsActive = (dservering.Tables[0].Rows[i]["IsActive"]).ToString();
                    string IngredientCode = (dservering.Tables[0].Rows[i]["IngredientCode"]).ToString();
                    string IsAllow = (dservering.Tables[0].Rows[i]["IsAllow"]).ToString();
                    string TaxId = (dservering.Tables[0].Rows[i]["TaxId"]).ToString();
                    string TaxValue = (dservering.Tables[0].Rows[i]["TaxValue"]).ToString();
                    string HsnCode = (dservering.Tables[0].Rows[i]["HsnCode"]).ToString();
                    
                    int iids = objBs.syncinsertIng(IngridID, IngredientName, SupplierName, Costperkg, Quantity, UserID, Units, IngCatID, IsActive, IngredientCode, IsAllow, TaxId, TaxValue, HsnCode);

                }
            }

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);

           ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Both Ing.Category and  Ingredients Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }


        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name!');window.location ='synchronization.aspx';", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Sync date.Thank You!');window.location ='synchronization.aspx';", true);
                    //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
                    return;
                }

            }


            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
            //return;

            if (drptype.SelectedValue == "1")
            {

                connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
                connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



                SqlConnection source = new SqlConnection(connnectionStringMain);

                SqlConnection destination = new SqlConnection(connnectionString);


                //SqlCommand cmditem = new SqlCommand("truncate table tblCategory", destination);
                SqlCommand cmdbranch = new SqlCommand("truncate table tblMargin", destination);



                //// Open source and destination connections.
                source.Open();
                destination.Open();
                //cmditem.ExecuteNonQuery();
                cmdbranch.ExecuteNonQuery();




                //// Select data from Products table
                //cmditem = new SqlCommand("SELECT * FROM tblcategory", source);
                cmdbranch = new SqlCommand("SELECT * FROM tblMargin", source);





                //// Create SqlBulkCopy
                SqlBulkCopy bulkData = new SqlBulkCopy(destination);

                //// Execute reader
                //SqlDataReader reader = cmditem.ExecuteReader();
                //bulkData.DestinationTableName = "tblcategory";
                //bulkData.WriteToServer(reader);
                //reader.Close();




                SqlDataReader readerbranch = cmdbranch.ExecuteReader();
                bulkData.DestinationTableName = "tblMargin";
                bulkData.WriteToServer(readerbranch);
                readerbranch.Close();

                //// Close objects
                bulkData.Close();
                destination.Close();
                source.Close();


                // GET ALL CATEGORY FROM SERVER

                int isysc = objBs.InsertSync(txtempname.Text, "Category", drptype.SelectedItem.Text, "BNCH");

                DataSet dservercat = objBs.getcategorygetdatafromsever("Live");
                if (dservercat.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                    {

                        int catid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["catid"]);
                        string Categoryid = (dservercat.Tables[0].Rows[i]["Categoryid"]).ToString();
                        string Category = (dservercat.Tables[0].Rows[i]["Category"]).ToString();
                        string CategoryCode = (dservercat.Tables[0].Rows[i]["CategoryCode"]).ToString();
                        string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                        string IsLiveKitchen = (dservercat.Tables[0].Rows[i]["IsLiveKitchen"]).ToString();
                        string ProductionType = (dservercat.Tables[0].Rows[i]["ProductionType"]).ToString();
                        string Request = (dservercat.Tables[0].Rows[i]["Request"]).ToString();

                        string poduction = (dservercat.Tables[0].Rows[i]["poduction"]).ToString();
                        string PrintCategory = (dservercat.Tables[0].Rows[i]["PrintCategory"]).ToString();
                        string ManualGrn = (dservercat.Tables[0].Rows[i]["ManualGrn"]).ToString();
                        string CatType = (dservercat.Tables[0].Rows[i]["CatType"]).ToString();


                        // GET LOCAL TBLCATEGORY DATA

                        DataSet dsLocalcat = objBs.getcategorygetdatafromlocal(catid.ToString());
                        if (dsLocalcat.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            if (drptype.SelectedValue == "1")
                            {
                                int iids = objBs.syncinsertcategory(catid, Categoryid, Category, CategoryCode, IsActive, IsLiveKitchen, ProductionType, Request, poduction, PrintCategory, ManualGrn, CatType);
                            }

                            // INSERT NEW 
                        }
                    }

                }
                else
                {
                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                    return;
                }
            }
            else
            {

                connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
                connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



                SqlConnection source = new SqlConnection(connnectionStringMain);

                SqlConnection destination = new SqlConnection(connnectionString);


                //SqlCommand cmditem = new SqlCommand("truncate table tblCategory", destination);
                SqlCommand cmdbranch = new SqlCommand("truncate table tblMargin", destination);



                //// Open source and destination connections.
                source.Open();
                destination.Open();
                //cmditem.ExecuteNonQuery();
                cmdbranch.ExecuteNonQuery();




                //// Select data from Products table
                //cmditem = new SqlCommand("SELECT * FROM tblcategory", source);
                cmdbranch = new SqlCommand("SELECT * FROM tblMargin", source);





                //// Create SqlBulkCopy
                SqlBulkCopy bulkData = new SqlBulkCopy(destination);

                //// Execute reader
                //SqlDataReader reader = cmditem.ExecuteReader();
                //bulkData.DestinationTableName = "tblcategory";
                //bulkData.WriteToServer(reader);
                //reader.Close();




                SqlDataReader readerbranch = cmdbranch.ExecuteReader();
                bulkData.DestinationTableName = "tblMargin";
                bulkData.WriteToServer(readerbranch);
                readerbranch.Close();

                //// Close objects
                bulkData.Close();
                destination.Close();
                source.Close();



                int isysc = objBs.InsertSync(txtempname.Text, "Category", drptype.SelectedItem.Text, "BNCH");

                DataSet dservercat = objBs.getcategorygethistorydatafromsever("Live", txtdate.Text);
                if (dservercat.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                    {

                        // int catid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["catid"]);
                        string Categoryid = (dservercat.Tables[0].Rows[i]["Categoryid"]).ToString();
                        string Category = (dservercat.Tables[0].Rows[i]["Category"]).ToString();
                        string CategoryCode = (dservercat.Tables[0].Rows[i]["CategoryCode"]).ToString();
                        string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                        string IsLiveKitchen = (dservercat.Tables[0].Rows[i]["IsLiveKitchen"]).ToString();
                        string ProductionType = (dservercat.Tables[0].Rows[i]["ProductionType"]).ToString();
                        string Request = (dservercat.Tables[0].Rows[i]["Request"]).ToString();

                        string poduction = (dservercat.Tables[0].Rows[i]["poduction"]).ToString();
                        string PrintCategory = (dservercat.Tables[0].Rows[i]["PrintCategory"]).ToString();
                        string ManualGrn = (dservercat.Tables[0].Rows[i]["ManualGrn"]).ToString();
                        string CatType = (dservercat.Tables[0].Rows[i]["CatType"]).ToString();


                        // GET LOCAL TBLCATEGORY DATA

                        DataSet dsLocalcat = objBs.getcategorygethistorydatafromlocal(Categoryid.ToString());
                        if (dsLocalcat.Tables[0].Rows.Count > 0)
                        {
                            string LCLcatid = (dsLocalcat.Tables[0].Rows[0]["Categoryid"]).ToString();

                            // INSERT LIVE CATEGORY

                            if (Categoryid == LCLcatid)
                            {
                                if (drptype.SelectedValue == "2")
                                {
                                    // UPDATE ALL COLUMN NAME
                                    int isuc = objBs.syncupdatecategory(Categoryid, Category, CategoryCode, IsActive, IsLiveKitchen, ProductionType, Request, poduction, PrintCategory, ManualGrn, CatType);
                                }

                            }
                        }
                    }
                }

            }


            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);

        }

        protected void btnsstsiclick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Sync date.Thank You!!!.');window.location ='synchronization.aspx';", true);

                    return;
                }

            }


            //check this is production or normal store
            DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
            if (dcheck.Tables[0].Rows.Count > 0)
            {
                int isysc = objBs.InsertSync(txtempname.Text, "Shop To Store Item Screen", drptype.SelectedItem.Text, "BNCH");

                // GET ITEM FORM LIVE SERVER
                // GET ALL CATEGORY FROM SERVER

                if (drptype.SelectedValue == "1")
                {

                    DataSet dservercat = objBs.getstoretoshopitemfromserver("Live");
                    if (dservercat.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                        {

                            int StoreSettingId = Convert.ToInt32(dservercat.Tables[0].Rows[i]["StoreSettingId"]);
                            string Ingid = (dservercat.Tables[0].Rows[i]["Ingid"]).ToString();
                            string Categoryuserid = (dservercat.Tables[0].Rows[i]["Categoryuserid"]).ToString();
                            string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                            string Empname = (dservercat.Tables[0].Rows[i]["Empname"]).ToString();

                            // GET LOCAL TBLCATEGORYUSER DATA

                            DataSet dsLocalcat = objBs.getstoretoshopitemgetdatafromlocal(StoreSettingId.ToString());
                            if (dsLocalcat.Tables[0].Rows.Count > 0)
                            {

                            }
                            else
                            {
                                if (drptype.SelectedValue == "1")
                                {
                                    int iids = objBs.syncinsertstoretishopitem(StoreSettingId, Ingid, Categoryuserid, IsActive, Empname);
                                }
                            }
                        }

                    }
                    else
                    {
                        //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');window.location ='synchronization.aspx';", true);
                        return;
                    }

                }
                else
                {
                    DataSet dservercat = objBs.getstoretoshopitemgetdatahistoryfromsever("Live", txtdate.Text);
                    if (dservercat.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                        {

                            int StoreSettingId = Convert.ToInt32(dservercat.Tables[0].Rows[i]["StoreSettingId"]);
                            string Ingid = (dservercat.Tables[0].Rows[i]["Ingid"]).ToString();
                            string Categoryuserid = (dservercat.Tables[0].Rows[i]["Categoryuserid"]).ToString();
                            string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                            string Empname = (dservercat.Tables[0].Rows[i]["Empname"]).ToString();


                            // GET LOCAL TBLCATEGORYUSER DATA

                            DataSet dsLocalcat = objBs.getstoretoshopitemgetdatafromlocal(StoreSettingId.ToString());
                            if (dsLocalcat.Tables[0].Rows.Count > 0)
                            {
                                int LCLitemid = Convert.ToInt32(dsLocalcat.Tables[0].Rows[0]["StoreSettingId"]);



                                // INSERT LIVE CATEGORY
                                if (StoreSettingId == LCLitemid)
                                {
                                    if (drptype.SelectedValue == "2")
                                    {
                                        // UPDATE ALL COLUMN NAME
                                        int isuc = objBs.syncupdatestoretoshopitemNEW(StoreSettingId, Ingid, Categoryuserid, IsActive, Empname);
                                    }

                                }
                            }

                        }

                    }
                }



                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
            }
            else
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Store To Shop Items.Please Contact Administrator.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Store To Shop Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                return;
            }

        }

        protected void btnsyncclick_HSNCODE(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!');window.location ='synchronization.aspx';", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get HSNCODE Items For this Selected Type.Please Contact Administrator.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get HSNCODE Items For this Selected Type.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                return;
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
            //return;



            //check this is production or normal store
            DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
            if (dcheck.Tables[0].Rows.Count > 0)
            {
                //   int iscuss = objBs.insertallbranchitem();

                //   connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
                //   connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;


                //   // FOR ITEM 
                //   // Create source connection
                //   SqlConnection source = new SqlConnection(connnectionStringMain);
                //   // Create destination connection
                //   SqlConnection destination = new SqlConnection(connnectionString);

                //   // Clean up destination table. Your destination database must have the 
                //   // table with schema which you are copying data to. 
                //   // Before executing this code, you must create a table BulkDataTable 
                //   // in your database where you are trying to copy data to.

                //   // SqlCommand cmditem = new SqlCommand("truncate table tblcategoryuser", destination);
                ////   SqlCommand cmdbranch = new SqlCommand("truncate table tblcategoryuserbranch", destination);
                //  // SqlCommand cmdspongue = new SqlCommand("truncate table tblcategoryusersponge", destination);


                //   // Open source and destination connections.
                //   source.Open();
                //   destination.Open();
                //   // cmditem.ExecuteNonQuery();
                //   //cmdbranch.ExecuteNonQuery();
                //   //cmdspongue.ExecuteNonQuery();



                //   // Select data from Products table
                //   //  cmditem = new SqlCommand("SELECT * FROM tblcategoryuser", source);
                // //  cmdbranch = new SqlCommand("SELECT * FROM tblcategoryuserbranch", source);
                // //  cmdspongue = new SqlCommand("SELECT * FROM tblcategoryusersponge", source);


                //   // Create SqlBulkCopy
                ////   SqlBulkCopy bulkData = new SqlBulkCopy(destination);

                //   // Execute reader
                //   //  SqlDataReader reader = cmditem.ExecuteReader();
                //   // bulkData.DestinationTableName = "tblcategoryuser";
                //   // bulkData.WriteToServer(reader);
                //   //  reader.Close();




                //   //SqlDataReader readerbranch = cmdbranch.ExecuteReader();
                //   //bulkData.DestinationTableName = "tblcategoryuserbranch";
                //   //bulkData.WriteToServer(readerbranch);
                //   //readerbranch.Close();


                //   //SqlDataReader readerspongue = cmdspongue.ExecuteReader();
                //   //bulkData.DestinationTableName = "tblcategoryusersponge";
                //   //bulkData.WriteToServer(readerspongue);



                //   // Close objects
                ////   bulkData.Close();
                //   destination.Close();
                //   source.Close();


                int isysc = objBs.InsertSync(txtempname.Text, "Item HSNCODE Screen", drptype.SelectedItem.Text, "BNCH");

                // GET ITEM FORM LIVE SERVER
                // GET ALL CATEGORY FROM SERVER

                if (drptype.SelectedValue == "1")
                {

                    DataSet dservercat = objBs.getitemgetdatafromsever("Live");
                    if (dservercat.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                        {

                            int ItemID = Convert.ToInt32(dservercat.Tables[0].Rows[i]["ItemID"]);
                            string HSNCode = (dservercat.Tables[0].Rows[i]["HSNCode"]).ToString();
                            // GET LOCAL TBLCATEGORYUSER DATA

                            int iStatus = objBs.InsertitemforHSNCODE(ItemID.ToString(), HSNCode, "0", "0", "1");
                        }

                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                        return;
                    }

                }

                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
            }
            else
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                return;
            }
        }


        protected void onlinepos_sync(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!');window.location ='synchronization.aspx';", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get HSNCODE Items For this Selected Type.Please Contact Administrator.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Online Sales Items For this Selected Type.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                return;
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
            //return;



            //check this is production or normal store
            DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
            if (dcheck.Tables[0].Rows.Count > 0)
            {
               


                int isysc = objBs.InsertSync(txtempname.Text, "Item Online Type Screen", drptype.SelectedItem.Text, "BNCH");

                // GET ITEM FORM LIVE SERVER
                // GET ALL CATEGORY FROM SERVER

                if (drptype.SelectedValue == "1")
                {

                    DataSet dservercat = objBs.getitemgetdatafromsever("Live");
                    if (dservercat.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                        {

                            int ItemID = Convert.ToInt32(dservercat.Tables[0].Rows[i]["ItemID"]);
                            string DisplayOnline = (dservercat.Tables[0].Rows[i]["DisplayOnline"]).ToString();
                            // GET LOCAL TBLCATEGORYUSER DATA

                            int iStatus = objBs.InsertitemforONLINE(ItemID.ToString(),DisplayOnline);
                        }

                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                        return;
                    }

                }

                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
            }
            else
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                return;
            }
        }






        protected void btnsyncclick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!');window.location ='synchronization.aspx';", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Sync date.Thank You!');window.location ='synchronization.aspx';", true);
                    return;
                }

            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
            //return;



            //check this is production or normal store
            DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
            if (dcheck.Tables[0].Rows.Count > 0)
            {
                //   int iscuss = objBs.insertallbranchitem();

                connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
                connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;


                // FOR ITEM 
                // Create source connection
                SqlConnection source = new SqlConnection(connnectionStringMain);
                // Create destination connection
                SqlConnection destination = new SqlConnection(connnectionString);

                // Clean up destination table. Your destination database must have the 
                // table with schema which you are copying data to. 
                // Before executing this code, you must create a table BulkDataTable 
                // in your database where you are trying to copy data to.

                // SqlCommand cmditem = new SqlCommand("truncate table tblcategoryuser", destination);
                SqlCommand cmdbranch = new SqlCommand("truncate table tblcategoryuserbranch", destination);
                SqlCommand cmdspongue = new SqlCommand("truncate table tblcategoryusersponge", destination);


                // Open source and destination connections.
                source.Open();
                destination.Open();
                // cmditem.ExecuteNonQuery();
                cmdbranch.ExecuteNonQuery();
                cmdspongue.ExecuteNonQuery();



                // Select data from Products table
                //  cmditem = new SqlCommand("SELECT * FROM tblcategoryuser", source);
                cmdbranch = new SqlCommand("SELECT * FROM tblcategoryuserbranch", source);
                cmdspongue = new SqlCommand("SELECT * FROM tblcategoryusersponge", source);


                // Create SqlBulkCopy
                SqlBulkCopy bulkData = new SqlBulkCopy(destination);

                // Execute reader
                //  SqlDataReader reader = cmditem.ExecuteReader();
                // bulkData.DestinationTableName = "tblcategoryuser";
                // bulkData.WriteToServer(reader);
                //  reader.Close();




                SqlDataReader readerbranch = cmdbranch.ExecuteReader();
                bulkData.DestinationTableName = "tblcategoryuserbranch";
                bulkData.WriteToServer(readerbranch);
                readerbranch.Close();


                SqlDataReader readerspongue = cmdspongue.ExecuteReader();
                bulkData.DestinationTableName = "tblcategoryusersponge";
                bulkData.WriteToServer(readerspongue);



                // Close objects
                bulkData.Close();
                destination.Close();
                source.Close();


                int isysc = objBs.InsertSync(txtempname.Text, "Item Screen", drptype.SelectedItem.Text, "BNCH");

                // GET ITEM FORM LIVE SERVER
                // GET ALL CATEGORY FROM SERVER

                if (drptype.SelectedValue == "1")
                {

                    DataSet dservercat = objBs.getitemgetdatafromsever("Live");
                    if (dservercat.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                        {

                            int ItemID = Convert.ToInt32(dservercat.Tables[0].Rows[i]["ItemID"]);
                            string CategoryID = (dservercat.Tables[0].Rows[i]["CategoryID"]).ToString();
                            string Definition = (dservercat.Tables[0].Rows[i]["Definition"]).ToString();
                            string IsDelete = (dservercat.Tables[0].Rows[i]["IsDelete"]).ToString();
                            string Serial_No = (dservercat.Tables[0].Rows[i]["Serial_No"]).ToString();
                            string Serial = (dservercat.Tables[0].Rows[i]["Serial"]).ToString();
                            string Size = (dservercat.Tables[0].Rows[i]["Size"]).ToString();
                            string isChecked = (dservercat.Tables[0].Rows[i]["isChecked"]).ToString();

                            string Tax = (dservercat.Tables[0].Rows[i]["Tax"]).ToString();
                            string Rate = (dservercat.Tables[0].Rows[i]["Rate"]).ToString();
                            string CategoryUserID = (dservercat.Tables[0].Rows[i]["CategoryUserID"]).ToString();

                            string GST = (dservercat.Tables[0].Rows[i]["GST"]).ToString();
                            string TaxVal = (dservercat.Tables[0].Rows[i]["TaxVal"]).ToString();
                            string unit = (dservercat.Tables[0].Rows[i]["unit"]).ToString();
                            string empcode = (dservercat.Tables[0].Rows[i]["empcode"]).ToString();
                            string MinimumStock = (dservercat.Tables[0].Rows[i]["MinimumStock"]).ToString();
                            string DisplayOnline = (dservercat.Tables[0].Rows[i]["DisplayOnline"]).ToString();
                            string ImageUpload = (dservercat.Tables[0].Rows[i]["ImageUpload"]).ToString();
                            string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                            string HSNCode = (dservercat.Tables[0].Rows[i]["HSNCode"]).ToString();
                            string Printitem = (dservercat.Tables[0].Rows[i]["Printitem"]).ToString();
                            string foodtype = (dservercat.Tables[0].Rows[i]["Foodtype"]).ToString();

                            string Barcode = (dservercat.Tables[0].Rows[i]["Barcode"]).ToString();
                            string Mrp = (dservercat.Tables[0].Rows[i]["Mrp"]).ToString();
                            string Pagepath = (dservercat.Tables[0].Rows[i]["Pagepath"]).ToString();
                            string Description = (dservercat.Tables[0].Rows[i]["Description"]).ToString();
                            string ratetype = (dservercat.Tables[0].Rows[i]["ratetype"]).ToString();

                            






                            // GET LOCAL TBLCATEGORYUSER DATA

                            DataSet dsLocalcat = objBs.getitemgetdatafromlocal(ItemID.ToString());
                            if (dsLocalcat.Tables[0].Rows.Count > 0)
                            {
                                //int LCLitemid = Convert.ToInt32(dsLocalcat.Tables[0].Rows[0]["itemid"]);



                                //// INSERT LIVE CATEGORY
                                //if (ItemID == LCLitemid)
                                //{
                                //    if (drptype.SelectedValue == "2")
                                //    {
                                //        // UPDATE ALL COLUMN NAME
                                //        int isuc = objBs.syncupdateitem(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Size, isChecked, Tax, Rate, CategoryUserID, GST, TaxVal, unit, empcode, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype);
                                //    }

                                //}
                            }
                            else
                            {
                                if (drptype.SelectedValue == "1")
                                {
                                    int iids = objBs.syncinsertitem(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Size, isChecked, Tax, Rate, CategoryUserID, GST, TaxVal, unit, empcode, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype,Barcode,Mrp,Pagepath,Description,ratetype);
                                }
                            }
                        }

                    }
                    else
                    {
                        //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                        return;
                    }

                }
                else
                {
                    DataSet dservercat = objBs.getitemgetdatahistoryfromsever("Live", txtdate.Text);
                    if (dservercat.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                        {

                            int ItemID = Convert.ToInt32(dservercat.Tables[0].Rows[i]["ItemID"]);
                            string CategoryID = (dservercat.Tables[0].Rows[i]["CategoryID"]).ToString();
                            string Definition = (dservercat.Tables[0].Rows[i]["Definition"]).ToString();
                            string IsDelete = (dservercat.Tables[0].Rows[i]["IsDelete"]).ToString();
                            string Serial_No = (dservercat.Tables[0].Rows[i]["Serial_No"]).ToString();
                            string Serial = (dservercat.Tables[0].Rows[i]["Serial"]).ToString();
                            // string Size = (dservercat.Tables[0].Rows[i]["Size"]).ToString();
                            //string isChecked = (dservercat.Tables[0].Rows[i]["isChecked"]).ToString();

                            string Tax = (dservercat.Tables[0].Rows[i]["Tax"]).ToString();
                            string Rate = (dservercat.Tables[0].Rows[i]["Rate"]).ToString();
                            string CategoryUserID = (dservercat.Tables[0].Rows[i]["CategoryUserID"]).ToString();

                            string GST = (dservercat.Tables[0].Rows[i]["GST"]).ToString();
                            string TaxVal = (dservercat.Tables[0].Rows[i]["TaxVal"]).ToString();
                            string unit = (dservercat.Tables[0].Rows[i]["unit"]).ToString();
                            // string empcode = (dservercat.Tables[0].Rows[i]["empcode"]).ToString();
                            string MinimumStock = (dservercat.Tables[0].Rows[i]["MinimumStock"]).ToString();
                            string DisplayOnline = (dservercat.Tables[0].Rows[i]["DisplayOnline"]).ToString();
                            string ImageUpload = (dservercat.Tables[0].Rows[i]["ImageUpload"]).ToString();
                            string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();
                            string HSNCode = (dservercat.Tables[0].Rows[i]["HSNCode"]).ToString();
                            string Printitem = (dservercat.Tables[0].Rows[i]["Printitem"]).ToString();
                            string foodtype = (dservercat.Tables[0].Rows[i]["Foodtype"]).ToString();

                            string Barcode = (dservercat.Tables[0].Rows[i]["Barcode"]).ToString();
                            string Mrp = (dservercat.Tables[0].Rows[i]["Mrp"]).ToString();
                            string Pagepath = (dservercat.Tables[0].Rows[i]["Pagepath"]).ToString();
                            string Description = (dservercat.Tables[0].Rows[i]["Description"]).ToString();
                            string ratetype = (dservercat.Tables[0].Rows[i]["ratetype"]).ToString();


                            // GET LOCAL TBLCATEGORYUSER DATA

                            DataSet dsLocalcat = objBs.getitemgetdatafromlocal(ItemID.ToString());
                            if (dsLocalcat.Tables[0].Rows.Count > 0)
                            {
                                int LCLitemid = Convert.ToInt32(dsLocalcat.Tables[0].Rows[0]["itemid"]);



                                // INSERT LIVE CATEGORY
                                if (ItemID == LCLitemid)
                                {
                                    if (drptype.SelectedValue == "2")
                                    {
                                        // UPDATE ALL COLUMN NAME
                                        int isuc = objBs.syncupdateitemNEW(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Tax, Rate, CategoryUserID, GST, TaxVal, unit, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype, Barcode, Mrp, Pagepath, Description, ratetype);
                                    }

                                }
                            }

                        }

                    }
                }



                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
            }
            else
            {
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!');window.location ='synchronization.aspx';", true);
                return;
            }
        }

        protected void btnstocksyncclick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Push Stock Items.Please Contact Administrator.Thank You!!!.');", true);
            return;

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            SqlConnection source = new SqlConnection(connnectionString);
            SqlConnection destination = new SqlConnection(connnectionStringMain);



            SqlCommand cmditem = new SqlCommand("truncate table tblStock_" + sTableName + "", destination);


            source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();

            cmditem = new SqlCommand("SELECT * FROM tblStock_" + sTableName + "", source);




            SqlBulkCopy bulkData = new SqlBulkCopy(destination);


            SqlDataReader reader = cmditem.ExecuteReader();
            bulkData.DestinationTableName = "tblStock_" + sTableName + "";
            bulkData.WriteToServer(reader);
            reader.Close();

            bulkData.Close();
            destination.Close();
            source.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }

        protected void btnsalessyn_OnClick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Entery your Name!');window.location ='synchronization.aspx';", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Sync date.Thank You!!!.');window.location ='synchronization.aspx';", true);
                    return;
                }

            }



            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);

            source.Open();
            destination.Open();
            //// Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);




            // GET ALL SAles FROM Local
            # region "GetSalesFromLocal"

            int isysc = objBs.InsertSync(txtempname.Text, "Sales", drptype.SelectedItem.Text, "BNCH");

            DataSet dservercat = objBs.getsalesgetdatafromLocal("Local", sTableName);
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int Salesid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["Salesid"]);
                    string UserID = (dservercat.Tables[0].Rows[i]["UserID"]).ToString();
                    string BillNo = (dservercat.Tables[0].Rows[i]["BillNo"]).ToString();
                    string BillDate = Convert.ToDateTime(dservercat.Tables[0].Rows[i]["BillDate"]).ToString("yyyy-MM-dd hh:mm tt");

                    string Total = (dservercat.Tables[0].Rows[i]["Total"]).ToString();
                    string Tax = (dservercat.Tables[0].Rows[i]["Tax"]).ToString();
                    string NetAmount = (dservercat.Tables[0].Rows[i]["NetAmount"]).ToString();

                    string Discount = (dservercat.Tables[0].Rows[i]["Discount"]).ToString();
                    string iEdit = (dservercat.Tables[0].Rows[i]["iEdit"]).ToString();
                    string ContactTypeID = (dservercat.Tables[0].Rows[i]["ContactTypeID"]).ToString();
                    string Advance = (dservercat.Tables[0].Rows[i]["Advance"]).ToString();

                    string OrderNo = (dservercat.Tables[0].Rows[i]["OrderNo"]).ToString();
                    string Messege = (dservercat.Tables[0].Rows[i]["Messege"]).ToString();
                    string DeliveryDate = Convert.ToDateTime(dservercat.Tables[0].Rows[i]["DeliveryDate"]).ToString("yyyy-MM-dd");
                    string DeilveryTime = (dservercat.Tables[0].Rows[i]["DeilveryTime"]).ToString();
                    string OrderTakenBy = (dservercat.Tables[0].Rows[i]["OrderTakenBy"]).ToString();
                    string Notes = (dservercat.Tables[0].Rows[i]["Notes"]).ToString();
                    string iPayMode = (dservercat.Tables[0].Rows[i]["iPayMode"]).ToString();
                    string cancelstatus = (dservercat.Tables[0].Rows[i]["cancelstatus"]).ToString();
                    string Canceltine = string.Empty;
                    if (cancelstatus == "No")
                    {
                        Canceltine = (dservercat.Tables[0].Rows[i]["Canceltine"]).ToString();
                    }
                    else
                    {
                        Canceltine = Convert.ToDateTime(dservercat.Tables[0].Rows[i]["Canceltine"]).ToString("yyyy-MM-dd hh:mm tt");
                    }

                    string cashpaid = (dservercat.Tables[0].Rows[i]["cashpaid"]).ToString();
                    string Balance = (dservercat.Tables[0].Rows[i]["Balance"]).ToString();
                    string Reference = (dservercat.Tables[0].Rows[i]["Reference"]).ToString();
                    string IsTransfer = (dservercat.Tables[0].Rows[i]["IsTransfer"]).ToString();

                    string Provider = (dservercat.Tables[0].Rows[i]["Provider"]).ToString();
                    string Approved = (dservercat.Tables[0].Rows[i]["Approved"]).ToString();
                    string Attender = (dservercat.Tables[0].Rows[i]["Attender"]).ToString();
                    string Biller = (dservercat.Tables[0].Rows[i]["Biller"]).ToString();
                    string cashier = (dservercat.Tables[0].Rows[i]["cashier"]).ToString();
                    string Reason = (dservercat.Tables[0].Rows[i]["Reason"]).ToString();

                    string CGST = (dservercat.Tables[0].Rows[i]["CGST"]).ToString();

                    string SGST = (dservercat.Tables[0].Rows[i]["SGST"]).ToString();
                    string STotal = (dservercat.Tables[0].Rows[i]["STotal"]).ToString();
                    string IsLiveTransfer = (dservercat.Tables[0].Rows[i]["IsLiveTransfer"]).ToString();
                    string IsAccountsBill = (dservercat.Tables[0].Rows[i]["IsAccountsBill"]).ToString();


                    string Roundoff = (dservercat.Tables[0].Rows[i]["Roundoff"]).ToString();
                    string Saletypemargin = (dservercat.Tables[0].Rows[i]["Saletypemargin"]).ToString();
                    string GstMargin = (dservercat.Tables[0].Rows[i]["GstMargin"]).ToString();
                    string Gateway = (dservercat.Tables[0].Rows[i]["Gateway"]).ToString();
                    string salestype = (dservercat.Tables[0].Rows[i]["salestype"]).ToString();
                    string IsNormal = (dservercat.Tables[0].Rows[i]["IsNormal"]).ToString();
                    string SalesOrder = (dservercat.Tables[0].Rows[i]["SalesOrder"]).ToString();
                    string KOTTbleNo = (dservercat.Tables[0].Rows[i]["KOTTbleNo"]).ToString();

                    string Isprint = (dservercat.Tables[0].Rows[i]["Isprint"]).ToString();
                    string discper = (dservercat.Tables[0].Rows[i]["discper"]).ToString();
                    string ApprovedId = (dservercat.Tables[0].Rows[i]["ApprovedId"]).ToString();
                    string OnlineAmount = (dservercat.Tables[0].Rows[i]["OnlineAmount"]).ToString();

                    string OldCustomerId = (dservercat.Tables[0].Rows[i]["CustomerID"]).ToString();
                    string MobileNo = (dservercat.Tables[0].Rows[i]["MobileNo"]).ToString();
                    string CustomerName = (dservercat.Tables[0].Rows[i]["CustomerName"]).ToString();
                    string iCustid = "";

                    #region
                    DataSet dCustid = objBs.GerCustID_Live(MobileNo);
                    if (dCustid.Tables[0].Rows.Count > 0)
                    {
                        iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
                    }
                    else
                    {
                        int iStatus = objBs.Insertcust_Live(CustomerName, MobileNo, "", "Yes", lblUserID.Text);

                        dCustid = objBs.GerCustID_Live(MobileNo);
                        iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();

                    }

                    string CustomerID = iCustid;
                    #endregion


                    int iids = objBs.syncinsertSales(Salesid, sTableName, UserID, BillNo, BillDate, CustomerID, Total, Tax, NetAmount, Discount, iEdit, ContactTypeID, Advance, OrderNo, Messege, DeliveryDate, DeilveryTime, OrderTakenBy, Notes, iPayMode, cancelstatus, cashpaid, Balance, Reference, IsTransfer, Provider, Approved, Attender, Biller, cashier, Reason, Canceltine, CGST, SGST, STotal, IsLiveTransfer, IsAccountsBill, Roundoff, Saletypemargin, GstMargin, Gateway, salestype, IsNormal, SalesOrder, KOTTbleNo, Isprint, discper, ApprovedId, OnlineAmount, CustomerName, MobileNo, OldCustomerId);

                }
            }
            #endregion

            #region "TransSAles"
            // INSERT NEW 
            int isysc1 = objBs.InsertSync(txtempname.Text, "Trans Sales", drptype.SelectedItem.Text, "BNCH");

            DataSet dserver = objBs.getTranssalesgetdatafromLocal("Local", sTableName);
            if (dserver.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dserver.Tables[0].Rows.Count; i++)
                {

                    int TransSalesID = Convert.ToInt32(dserver.Tables[0].Rows[i]["TransSalesID"]);
                    string SalesID = (dserver.Tables[0].Rows[i]["SalesID"]).ToString();
                    string CategoryID = (dserver.Tables[0].Rows[i]["CategoryID"]).ToString();
                    string UnitPrice = (dserver.Tables[0].Rows[i]["UnitPrice"]).ToString();
                    string Amount = (dserver.Tables[0].Rows[i]["Amount"]).ToString();
                    string SubCategoryID = (dserver.Tables[0].Rows[i]["SubCategoryID"]).ToString();
                    string Disc = (dserver.Tables[0].Rows[i]["Disc"]).ToString();
                    string Quantity = (dserver.Tables[0].Rows[i]["Quantity"]).ToString();
                    string StockId = (dserver.Tables[0].Rows[i]["StockId"]).ToString();
                    string IsTransfer = (dserver.Tables[0].Rows[i]["IsTransfer"]).ToString();
                    string Tax = (dserver.Tables[0].Rows[i]["Tax"]).ToString();
                    string Margin = (dserver.Tables[0].Rows[i]["Margin"]).ToString();
                    string IsNormal = (dserver.Tables[0].Rows[i]["IsNormal"]).ToString();
                    string Kotid = (dserver.Tables[0].Rows[i]["Kotid"]).ToString();
                    string Salesuniqueid = (dserver.Tables[0].Rows[i]["Salesuniqueid"]).ToString();
                    string SalesEntryDate = Convert.ToDateTime(dserver.Tables[0].Rows[i]["SalesEntryDate"]).ToString("yyyy-MM-dd hh:mm tt");
                    string Shwqty = (dserver.Tables[0].Rows[i]["Shwqty"]).ToString();
                    string Cattype = (dserver.Tables[0].Rows[i]["Cattype"]).ToString();
                    string Iscombo = (dserver.Tables[0].Rows[i]["Iscombo"]).ToString();
                    string Cqty = (dserver.Tables[0].Rows[i]["Cqty"]).ToString();

                    int iids = objBs.syncinsertTransSales(sTableName, TransSalesID, SalesID, CategoryID, UnitPrice, Amount, SubCategoryID, Disc, Quantity, StockId, IsTransfer, Tax, Margin, IsNormal, Kotid, Salesuniqueid, SalesEntryDate, Shwqty, Cattype, Iscombo, Cqty);
                }
            }

            #endregion

            bulkData.Close();
            source.Close();
            destination.Close();


            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);

        }



        protected void btnordersyn_OnClick(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Push Order Bill.Please Contact Administrator.Thank You!!!.');", true);
            return;


            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionString);
            SqlConnection destination = new SqlConnection(connnectionStringMain);


            source.Open();
            destination.Open();

            SqlCommand cmdsales = new SqlCommand("Select * from tblOrder_" + sTableName + " where isnull(IsTransfer,0)=0", source);
            SqlCommand cmdtranssales = new SqlCommand("Select * from tblTransOrder_" + sTableName + " where isnull(IsTransfer,0)=0", source);


            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            SqlBulkCopy bulkDataUpdate = new SqlBulkCopy(source);

            SqlDataReader reader = cmdsales.ExecuteReader();
            bulkData.DestinationTableName = "tblOrder_" + sTableName + "";
            bulkData.WriteToServer(reader);
            reader.Close();


            int iSuccess = 0;
            string sQry = "Update tblOrder_" + sTableName + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);

            SqlDataReader reader1 = cmdtranssales.ExecuteReader();
            bulkData.DestinationTableName = "tblTransOrder_" + sTableName + "";
            bulkData.WriteToServer(reader1);
            reader1.Close();

            sQry = "Update tblTransOrder_" + sTableName + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);



            bulkData.Close();
            source.Close();
            destination.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }


        protected void btnordersyn_OnClick1(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Entery your Name!');window.location ='synchronization.aspx';", true);
                return;

            }


            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionStringMain);
            SqlConnection destination = new SqlConnection(connnectionString);

            source.Open();
            destination.Open();
            //// Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);


            // GET ALL Order FROM Local
            # region "GetOrderFromLocal"

            System.Threading.Thread.Sleep(2000);

            int isysc = objBs.InsertSync(txtempname.Text, "Order", drptype.SelectedItem.Text, "BNCH");

            DataSet dserverorder = objBs.getOrdergetdatafromLocal("Local", sTableName);
            if (dserverorder.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dserverorder.Tables[0].Rows.Count; i++)
                {


                    int OrderID = Convert.ToInt32(dserverorder.Tables[0].Rows[i]["OrderID"]);
                    string BillNo = (dserverorder.Tables[0].Rows[i]["BillNo"]).ToString();
                    string OrderNo = (dserverorder.Tables[0].Rows[i]["OrderNo"]).ToString();
                    string OrderDate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["OrderDate"]).ToString("yyyy-MM-dd hh:mm tt");
                    string DeliveryDate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["DeliveryDate"]).ToString("yyyy-MM-dd hh:mm tt");
                    string Total = (dserverorder.Tables[0].Rows[i]["Total"]).ToString();
                    string NetAmount = (dserverorder.Tables[0].Rows[i]["NetAmount"]).ToString();
                    string AdvanceDate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["AdvanceDate"]).ToString("yyyy-MM-dd hh:mm tt");
                    string Advance = (dserverorder.Tables[0].Rows[i]["Advance"]).ToString();

                    string ContactID = (dserverorder.Tables[0].Rows[i]["ContactID"]).ToString();
                    string Messege = (dserverorder.Tables[0].Rows[i]["Messege"]).ToString();
                    string OrderTakenBy = (dserverorder.Tables[0].Rows[i]["OrderTakenBy"]).ToString();

                    string DeliveryTime = (dserverorder.Tables[0].Rows[i]["DeliveryTime"]).ToString();
                    string isCancel = (dserverorder.Tables[0].Rows[i]["isCancel"]).ToString();
                    string ipaymode = (dserverorder.Tables[0].Rows[i]["ipaymode"]).ToString();
                    string BookNo = (dserverorder.Tables[0].Rows[i]["BookNo"]).ToString();
                    string IsTransfer = (dserverorder.Tables[0].Rows[i]["IsTransfer"]).ToString();
                    string PayType = (dserverorder.Tables[0].Rows[i]["PayType"]).ToString();
                    string Place = (dserverorder.Tables[0].Rows[i]["Place"]).ToString();
                    string Paybill = (dserverorder.Tables[0].Rows[i]["Paybill"]).ToString();
                    string Cancelled = (dserverorder.Tables[0].Rows[i]["Cancelled"]).ToString();
                    string CGST = (dserverorder.Tables[0].Rows[i]["CGST"]).ToString();
                    string SGST = (dserverorder.Tables[0].Rows[i]["SGST"]).ToString();
                    string STotal = (dserverorder.Tables[0].Rows[i]["STotal"]).ToString();
                    string OrderTime = (dserverorder.Tables[0].Rows[i]["OrderTime"]).ToString();

                    string CancelDate = "";
                    if (dserverorder.Tables[0].Rows[i]["CancelDate"].ToString() == "")
                        CancelDate = "";
                    else
                        CancelDate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["CancelDate"]).ToString("yyyy-MM-dd hh:mm tt");

                    string OrderType = (dserverorder.Tables[0].Rows[i]["OrderType"]).ToString();
                    string PickUpLocation = (dserverorder.Tables[0].Rows[i]["PickUpLocation"]).ToString();
                    string DeliveryCharge = (dserverorder.Tables[0].Rows[i]["DeliveryCharge"]).ToString();

                    string BalanceDate = "";
                    if (dserverorder.Tables[0].Rows[i]["BalanceDate"].ToString() == "")
                        BalanceDate = "";
                    else
                        BalanceDate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["BalanceDate"]).ToString("yyyy-MM-dd hh:mm tt");

                    string Balance = (dserverorder.Tables[0].Rows[i]["Balance"]).ToString();
                    string BalancePaid = (dserverorder.Tables[0].Rows[i]["BalancePaid"]).ToString();
                    string Ceremonies = (dserverorder.Tables[0].Rows[i]["Ceremonies"]).ToString();
                    string Status = (dserverorder.Tables[0].Rows[i]["Status"]).ToString();
                    string DiscountPer = (dserverorder.Tables[0].Rows[i]["DiscountPer"]).ToString();

                    string DiscountAmount = (dserverorder.Tables[0].Rows[i]["DiscountAmount"]).ToString();

                    string ActualAdvanceDate = "";
                    if (dserverorder.Tables[0].Rows[i]["ActualAdvanceDate"].ToString() == "")
                        ActualAdvanceDate = "";
                    else
                        ActualAdvanceDate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["ActualAdvanceDate"]).ToString("yyyy-MM-dd hh:mm tt");

                    string RefundAmount = (dserverorder.Tables[0].Rows[i]["RefundAmount"]).ToString();
                    string IsNormal = (dserverorder.Tables[0].Rows[i]["IsNormal"]).ToString();
                    string DeliveryStatus = (dserverorder.Tables[0].Rows[i]["DeliveryStatus"]).ToString();
                    string DeliveryBy = (dserverorder.Tables[0].Rows[i]["DeliveryBy"]).ToString();
                    string PendingMsg = (dserverorder.Tables[0].Rows[i]["PendingMsg"]).ToString();
                    string PendingEntryBY = (dserverorder.Tables[0].Rows[i]["PendingEntryBY"]).ToString();
                    string DiscEmp = (dserverorder.Tables[0].Rows[i]["DiscEmp"]).ToString();

                    string FullBookNo = (dserverorder.Tables[0].Rows[i]["FullBookNo"]).ToString();
                    string Pbranch = (dserverorder.Tables[0].Rows[i]["Pbranch"]).ToString();
                    string Issync = (dserverorder.Tables[0].Rows[i]["Issync"]).ToString();
                    string OnlineSync = (dserverorder.Tables[0].Rows[i]["OnlineSync"]).ToString();
                    string onlinecomment = (dserverorder.Tables[0].Rows[i]["onlinecomment"]).ToString();

                    string Onlinesyncdate = string.Empty;
                    if (dserverorder.Tables[0].Rows[i]["Onlinesyncdate"].ToString() == "")
                        Onlinesyncdate = "";
                    else
                        Onlinesyncdate = Convert.ToDateTime(dserverorder.Tables[0].Rows[i]["Onlinesyncdate"]).ToString("yyyy-MM-dd hh:mm tt");

                    string OldCustomerId = (dserverorder.Tables[0].Rows[i]["CustomerID"]).ToString();
                    string MobileNo = (dserverorder.Tables[0].Rows[i]["MobileNo"]).ToString();
                    string CustomerName = (dserverorder.Tables[0].Rows[i]["CustomerName"]).ToString();
                    string iCustid = "";

                    #region
                    DataSet dCustid = objBs.GerCustID_Live(MobileNo);
                    if (dCustid.Tables[0].Rows.Count > 0)
                    {
                        iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
                    }
                    else
                    {
                        int iStatus = objBs.Insertcust_Live(CustomerName, MobileNo, "", "Yes", lblUserID.Text);

                        dCustid = objBs.GerCustID_Live(MobileNo);
                        iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();

                    }

                    string CustomerID = iCustid;
                    #endregion

                    int iids = objBs.syncinsertOrder(sTableName, OrderID, BillNo, OrderNo, OrderDate, DeliveryDate, Total, NetAmount, AdvanceDate, Advance, CustomerID, ContactID, Messege, OrderTakenBy, DeliveryTime, isCancel, ipaymode, BookNo, IsTransfer, PayType, Place, Paybill, Cancelled, CGST, SGST, STotal, OrderTime, CancelDate, OrderType, PickUpLocation, DeliveryCharge, BalanceDate, Balance, BalancePaid, Ceremonies, Status, DiscountPer, DiscountAmount, ActualAdvanceDate, RefundAmount, IsNormal, DeliveryStatus, DeliveryBy, PendingMsg, PendingEntryBY, DiscEmp, FullBookNo, Pbranch, Issync, OnlineSync, onlinecomment, Onlinesyncdate, CustomerName, MobileNo, OldCustomerId);
                }
            }

            #endregion



            //Get TransOrder From Local
            # region "GetTransOrderFromLocal"

            int isysc1 = objBs.InsertSync(txtempname.Text, "Trans Order", drptype.SelectedItem.Text, "BNCH");

            DataSet dserverTransorder = objBs.getTransOrdergetdatafromLocal("Local", sTableName);
            if (dserverTransorder.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dserverTransorder.Tables[0].Rows.Count; i++)
                {
                    int TransID = Convert.ToInt32(dserverTransorder.Tables[0].Rows[i]["TransID"]);
                    string BillNo = (dserverTransorder.Tables[0].Rows[i]["BillNo"]).ToString();
                    string CategoryID = (dserverTransorder.Tables[0].Rows[i]["CategoryID"]).ToString();
                    string SubcategoryID = (dserverTransorder.Tables[0].Rows[i]["SubcategoryID"]).ToString();
                    string Qty = (dserverTransorder.Tables[0].Rows[i]["Qty"]).ToString();
                    string Rate = (dserverTransorder.Tables[0].Rows[i]["Rate"]).ToString();
                    string Amount = (dserverTransorder.Tables[0].Rows[i]["Amount"]).ToString();
                    string StockId = (dserverTransorder.Tables[0].Rows[i]["StockId"]).ToString();

                    string IsTransfer = (dserverTransorder.Tables[0].Rows[i]["IsTransfer"]).ToString();
                    string Gst = (dserverTransorder.Tables[0].Rows[i]["Gst"]).ToString();
                    string IsNormal = (dserverTransorder.Tables[0].Rows[i]["IsNormal"]).ToString();
                    string Disc = (dserverTransorder.Tables[0].Rows[i]["Disc"]).ToString();
                    string modelno = (dserverTransorder.Tables[0].Rows[i]["modelno"]).ToString();
                    string Modelimgpath = (dserverTransorder.Tables[0].Rows[i]["Modelimgpath"]).ToString();
                    string OnlineSync = (dserverTransorder.Tables[0].Rows[i]["OnlineSync"]).ToString();
                    string onlinecomment = (dserverTransorder.Tables[0].Rows[i]["onlinecomment"]).ToString();
                    string Onlinesyncdate = "";
                    if (dserverTransorder.Tables[0].Rows[i]["Onlinesyncdate"].ToString() == "")
                        Onlinesyncdate = "";
                    else
                        Onlinesyncdate = Convert.ToDateTime(dserverTransorder.Tables[0].Rows[i]["Onlinesyncdate"]).ToString("yyyy-MM-dd hh:mm tt");

                    int iids = objBs.syncinsertTransOrder(sTableName, TransID, BillNo, CategoryID, SubcategoryID, Qty, Rate, Amount, StockId, IsTransfer, Gst, IsNormal, Disc, modelno, Modelimgpath, OnlineSync, onlinecomment, Onlinesyncdate);
                }
            }

            #endregion


            //Get TransOrderAmount From Local
            # region "GetTransOrderAmountFromLocal"

            isysc1 = objBs.InsertSync(txtempname.Text, "Trans Order Amount", drptype.SelectedItem.Text, "BNCH");

            DataSet dserverTransorderamt = objBs.getTransOrderAmountgetdatafromLocal("Local", sTableName);
            if (dserverTransorderamt.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dserverTransorderamt.Tables[0].Rows.Count; i++)
                {

                    int TransorderId = Convert.ToInt32(dserverTransorderamt.Tables[0].Rows[i]["TransorderId"]);
                    string BIllno = (dserverTransorderamt.Tables[0].Rows[i]["BIllno"]).ToString();
                    string OrderNO = (dserverTransorderamt.Tables[0].Rows[i]["OrderNO"]).ToString();
                    string Amount = (dserverTransorderamt.Tables[0].Rows[i]["Amount"]).ToString();
                    string Type = (dserverTransorderamt.Tables[0].Rows[i]["Type"]).ToString();
                    string BookNo = (dserverTransorderamt.Tables[0].Rows[i]["BookNo"]).ToString();
                    string Discamount = (dserverTransorderamt.Tables[0].Rows[i]["Discamount"]).ToString();
                    string DiscPer = (dserverTransorderamt.Tables[0].Rows[i]["DiscPer"]).ToString();

                    string Billdate = "";
                    if (dserverTransorderamt.Tables[0].Rows[i]["Billdate"].ToString() == "")
                        Billdate = "";
                    else
                        Billdate = Convert.ToDateTime(dserverTransorderamt.Tables[0].Rows[i]["Billdate"]).ToString("yyyy-MM-dd hh:mm tt");

                    string PayMode = (dserverTransorderamt.Tables[0].Rows[i]["PayMode"]).ToString();
                    string EntryBy = (dserverTransorderamt.Tables[0].Rows[i]["EntryBy"]).ToString();

                    int iids = objBs.syncinsertTransOrderAmount(sTableName, TransorderId, BIllno, OrderNO, Amount, Type, BookNo, Billdate, PayMode, EntryBy,DiscPer,Discamount);

                }
            }

            #endregion
            bulkData.Close();
            source.Close();
            destination.Close();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
            //Response.Redirect("synchronization.aspx");

        }

        protected void btnpaymentsyn_onclick(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }


            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionStringMain);
            SqlConnection destination = new SqlConnection(connnectionString);

            source.Open();
            destination.Open();
            //// Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);


            // GET ALL Paymen FROM Local
            # region "GetPaymentFromLocal"

            int isysc = objBs.InsertSync(txtempname.Text, "Payment", drptype.SelectedItem.Text, "BNCH");

            DataSet dserverPayment = objBs.getPaymentgetdatafromLocal("Local", sTableName);
            if (dserverPayment.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dserverPayment.Tables[0].Rows.Count; i++)
                {


                    int PaymentEntryID = Convert.ToInt32(dserverPayment.Tables[0].Rows[i]["PaymentEntryID"]);
                    string Date = Convert.ToDateTime(dserverPayment.Tables[0].Rows[i]["Date"]).ToString("yyyy-MM-dd hh:mm tt");
                    string LedgerID = (dserverPayment.Tables[0].Rows[i]["LedgerID"]).ToString();
                    string Description = (dserverPayment.Tables[0].Rows[i]["Description"]).ToString();
                    string Amount = (dserverPayment.Tables[0].Rows[i]["Amount"]).ToString();
                    string inSales = (dserverPayment.Tables[0].Rows[i]["inSales"]).ToString();
                    string orderNo = (dserverPayment.Tables[0].Rows[i]["orderNo"]).ToString();
                    string PayMode = (dserverPayment.Tables[0].Rows[i]["PayMode"]).ToString();

                    int iids = objBs.syncinsertPayment(sTableName, PaymentEntryID, Date, LedgerID, Description, Amount, inSales, orderNo, PayMode);

                }
            }

            #endregion
            bulkData.Close();
            source.Close();
            destination.Close();

            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);

        }

        protected void btnGRNsyn_onclick(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }


            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionStringMain);
            SqlConnection destination = new SqlConnection(connnectionString);

            source.Open();
            destination.Open();
            //// Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);


            // GET ALL Paymen FROM Local
            # region "GetGRNFromLocal"

            int isysc = objBs.InsertSync(txtempname.Text, "GRN", drptype.SelectedItem.Text, "BNCH");

            DataSet dservergrn = objBs.getGRNgetdatafromLocal("Local", sTableName);
            if (dservergrn.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservergrn.Tables[0].Rows.Count; i++)
                {


                    int ID = Convert.ToInt32(dservergrn.Tables[0].Rows[i]["ID"]);


                    string CategoryID = (dservergrn.Tables[0].Rows[i]["CategoryID"]).ToString();
                    string CategoryUserID = (dservergrn.Tables[0].Rows[i]["CategoryUserID"]).ToString();
                    string GRN_Qty = (dservergrn.Tables[0].Rows[i]["GRN_Qty"]).ToString();
                    string Date = Convert.ToDateTime(dservergrn.Tables[0].Rows[i]["Date"]).ToString("yyyy-MM-dd hh:mm tt");
                    string UserID = (dservergrn.Tables[0].Rows[i]["UserID"]).ToString();
                    string GRNNo = (dservergrn.Tables[0].Rows[i]["GRNNo"]).ToString();
                    string Name = (dservergrn.Tables[0].Rows[i]["Name"]).ToString();
                    string DayGRN = (dservergrn.Tables[0].Rows[i]["DayGRN"]).ToString();
                    string GRNTime = (dservergrn.Tables[0].Rows[i]["GRNTime"]).ToString();
                    string Type = (dservergrn.Tables[0].Rows[i]["Type"]).ToString();
                    string RequestNo = (dservergrn.Tables[0].Rows[i]["RequestNo"]).ToString();
                    string Dc_No = (dservergrn.Tables[0].Rows[i]["Dc_No"]).ToString();
                    string FromBranchCode = (dservergrn.Tables[0].Rows[i]["FromBranchCode"]).ToString();
                    string FromBranchOwnType = (dservergrn.Tables[0].Rows[i]["FromBranchOwnType"]).ToString();
                    string IsTransfer = (dservergrn.Tables[0].Rows[i]["IsTransfer"]).ToString();

                    int iids = objBs.syncinsertGrn(sTableName, ID, CategoryID, CategoryUserID, GRN_Qty, Date, UserID, GRNNo, Name, DayGRN, GRNTime, Type, RequestNo, Dc_No, FromBranchCode, FromBranchOwnType, IsTransfer);

                }
            }

            #endregion
            bulkData.Close();
            source.Close();
            destination.Close();

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }

        protected void btnReturnsyn_onclick(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }


            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionStringMain);
            SqlConnection destination = new SqlConnection(connnectionString);

            source.Open();
            destination.Open();
            //// Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);


            // GET ALL Return FROM Local
            # region "GetReturnFromLocal"

            int isysc = objBs.InsertSync(txtempname.Text, "Return", drptype.SelectedItem.Text, "BNCH");

            DataSet dserverrtn = objBs.geReturngetdatafromLocal("Local", sTableName);
            if (dserverrtn.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dserverrtn.Tables[0].Rows.Count; i++)
                {


                    int RetID = Convert.ToInt32(dserverrtn.Tables[0].Rows[i]["RetID"]);
                    string UserID = (dserverrtn.Tables[0].Rows[i]["UserID"]).ToString();
                    string RetNo = (dserverrtn.Tables[0].Rows[i]["RetNo"]).ToString();
                    string RetDate = Convert.ToDateTime(dserverrtn.Tables[0].Rows[i]["RetDate"]).ToString("yyyy-MM-dd hh:mm tt");
                    string CustomerID = (dserverrtn.Tables[0].Rows[i]["CustomerID"]).ToString();
                    string Total = (dserverrtn.Tables[0].Rows[i]["Total"]).ToString();
                    string Tax = (dserverrtn.Tables[0].Rows[i]["Tax"]).ToString();
                    string NetAmount = (dserverrtn.Tables[0].Rows[i]["NetAmount"]).ToString();
                    string Discount = (dserverrtn.Tables[0].Rows[i]["Discount"]).ToString();
                    string iEdit = (dserverrtn.Tables[0].Rows[i]["iEdit"]).ToString();
                    string Advance = (dserverrtn.Tables[0].Rows[i]["Advance"]).ToString();
                    string iPayMode = (dserverrtn.Tables[0].Rows[i]["iPayMode"]).ToString();
                    string cancelstatus = (dserverrtn.Tables[0].Rows[i]["cancelstatus"]).ToString();
                    string Name = (dserverrtn.Tables[0].Rows[i]["Name"]).ToString();
                    string Reasonsid = (dserverrtn.Tables[0].Rows[i]["Reasonsid"]).ToString();
                    string SaveDateTime = Convert.ToDateTime(dserverrtn.Tables[0].Rows[i]["SaveDateTime"]).ToString("yyyy-MM-dd hh:mm tt");
                    string Notes = (dserverrtn.Tables[0].Rows[i]["Notes"]).ToString();
                    string IsTransfer = (dserverrtn.Tables[0].Rows[i]["IsTransfer"]).ToString();

                    int iids = objBs.syncinsertReturn(sTableName, RetID, UserID, RetNo, RetDate, CustomerID, Total, Tax, NetAmount, Discount, iEdit, Advance, iPayMode, cancelstatus, Name, Reasonsid, SaveDateTime, Notes);

                }
            }

            #endregion


            // GET ALL Trans Return FROM Local
            # region "GetTransReturnFromLocal"

            isysc = objBs.InsertSync(txtempname.Text, " Trans Return", drptype.SelectedItem.Text, "BNCH");

            DataSet dservertrans = objBs.geTransReturngetdatafromLocal("Local", sTableName);
            if (dservertrans.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservertrans.Tables[0].Rows.Count; i++)
                {

                    int TransRetID = Convert.ToInt32(dservertrans.Tables[0].Rows[i]["TransRetID"]);
                    string RetNo = (dservertrans.Tables[0].Rows[i]["RetNo"]).ToString();
                    string CategoryID = (dservertrans.Tables[0].Rows[i]["CategoryID"]).ToString();
                    string UnitPrice = (dservertrans.Tables[0].Rows[i]["UnitPrice"]).ToString();
                    string Amount = (dservertrans.Tables[0].Rows[i]["Amount"]).ToString();
                    string SubCategoryID = (dservertrans.Tables[0].Rows[i]["SubCategoryID"]).ToString();
                    string Disc = (dservertrans.Tables[0].Rows[i]["Disc"]).ToString();
                    string Quantity = (dservertrans.Tables[0].Rows[i]["Quantity"]).ToString();
                    string StockId = (dservertrans.Tables[0].Rows[i]["StockId"]).ToString();
                    string Istransfer = (dservertrans.Tables[0].Rows[i]["Istransfer"]).ToString();

                    int iids = objBs.syncinsertTransReturn(sTableName, TransRetID, RetNo, CategoryID, UnitPrice, Amount, SubCategoryID, Disc, Quantity, StockId, Istransfer);

                }
            }

            #endregion








            bulkData.Close();
            source.Close();
            destination.Close();

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }

        protected void ReqStockSetting_sync(object sender, EventArgs e)
        {


            if (txtempname.Text == "")
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Your Name.Thank You!!!.');window.location ='synchronization.aspx';", true);
                return;

            }

            int isysc = objBs.InsertSync(txtempname.Text, "Request Stock Setting", drptype.SelectedItem.Text, "BNCH");

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;


            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmdinter = new SqlCommand("truncate table tblRequestStockSettingsMaster", destination);
            SqlCommand cmdtransinter = new SqlCommand("truncate table tbltransRequestStockSettings", destination);



            // Open source and destination connections.
            //   source.Open();
            destination.Open();
            cmdinter.ExecuteNonQuery();
            cmdtransinter.ExecuteNonQuery();


            // Close objects
            //bulkData.Close();
            destination.Close();
            //source.Close();

            DataSet dservercat = objBs.getReqStockdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int RequestStockId = Convert.ToInt32(dservercat.Tables[0].Rows[i]["RequestStockId"]);
                    DateTime Fromtime = Convert.ToDateTime(dservercat.Tables[0].Rows[i]["Fromtime"]);
                    DateTime Totime = Convert.ToDateTime(dservercat.Tables[0].Rows[i]["Totime"]);
                    string Delaydays = (dservercat.Tables[0].Rows[i]["Delaydays"]).ToString();


                    int iids = objBs.syncinsertReqStocksetting(RequestStockId, Fromtime, Totime, Delaydays);

                }
            }

            // TRans Table
            DataSet dservercattrans = objBs.getTransReqStockdatafromsever("Live");
            if (dservercattrans.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercattrans.Tables[0].Rows.Count; i++)
                {

                    int TransRequestStockSettingsId = Convert.ToInt32(dservercattrans.Tables[0].Rows[i]["TransRequestStockSettingsId"]);
                    string RequestStockSettingsId = (dservercattrans.Tables[0].Rows[i]["RequestStockSettingsId"]).ToString();
                    string CategoryId = (dservercattrans.Tables[0].Rows[i]["CategoryId"]).ToString();

                    int iids = objBs.syncinsertTransReqStocksetting(TransRequestStockSettingsId, RequestStockSettingsId, CategoryId);
                }
            }


            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Synced Successfully');window.location ='synchronization.aspx';", true);
        }


    }
}
