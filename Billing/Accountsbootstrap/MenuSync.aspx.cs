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
    public partial class MenuSync : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        DBAccess DBAccess = new DBAccess();
        string Sort_Direction = "Category ASC";
        string sTableName = "";
        string superadmin = "";
        string IsmasterLock = "N";

        private string connnectionString;
        private string connnectionStringMain;

        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            IsmasterLock = Request.Cookies["userInfo"]["IsmasterLock"].ToString();
            if (IsmasterLock == "Y")
            {
                if (!IsPostBack)
                {
                    Type_chnaged(sender, e);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Make Sure This Production Have This Screen Or Not.Thank You!!!.');window.location ='login1.aspx';", true);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
        }

        protected void btnsyncingtax_OnClick(object sender, EventArgs e)
        {
            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            // SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tbltax", destination);
            //  SqlCommand cmdbranch = new SqlCommand("truncate table tbluom", destination);



            // Open source and destination connections.
            //   source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();


            // Close objects
            //bulkData.Close();
            destination.Close();
            //source.Close();

            DataSet dservercat = objBs.getTAXdatafromsever("Live");
            if (dservercat.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dservercat.Tables[0].Rows.Count; i++)
                {

                    int taxid = Convert.ToInt32(dservercat.Tables[0].Rows[i]["taxid"]);

                    string taxname = (dservercat.Tables[0].Rows[i]["taxname"]).ToString();

                    string IsActive = (dservercat.Tables[0].Rows[i]["IsActive"]).ToString();

                    int iids = objBs.syncinserttax(taxid, taxname, IsActive);
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
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
            cmditem = new SqlCommand("SELECT * FROM tblIngridentscategory", source);
            cmdbranch = new SqlCommand("SELECT * FROM tblIngridents", source);



            // Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);

            // Execute reader
            SqlDataReader reader = cmditem.ExecuteReader();
            bulkData.DestinationTableName = "tblIngridentscategory";
            bulkData.WriteToServer(reader);
            reader.Close();




            SqlDataReader readerbranch = cmdbranch.ExecuteReader();
            bulkData.DestinationTableName = "tblIngridents";
            bulkData.WriteToServer(readerbranch);
            readerbranch.Close();

            // Close objects
            bulkData.Close();
            destination.Close();
            source.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
        }


        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
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

                int isysc = objBs.InsertSync(txtempname.Text, "Category", drptype.SelectedItem.Text,"Prod");

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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
                    return;
                }
            }
            else
            {
                int isysc = objBs.InsertSync(txtempname.Text, "Category", drptype.SelectedItem.Text, "Prod");

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


            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }

        protected void btnsstsiclick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
                    return;
                }

            }


            //check this is production or normal store
            DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
            if (dcheck.Tables[0].Rows.Count > 0)
            {
                int isysc = objBs.InsertSync(txtempname.Text, "Shop To Store Item Screen", drptype.SelectedItem.Text, "Prod");

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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
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



                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Store To Shop Items.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

        }
        protected void btnsyncclick(object sender, EventArgs e)
        {
            if (txtempname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your Name.Thank You!!!.');", true);
                return;

            }

            if (drptype.SelectedValue == "2")
            {

                if (txtdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Sync date.Thank You!!!.');", true);
                    return;
                }

            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
            //return;



            //check this is production or normal store
            //DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
           // if (dcheck.Tables[0].Rows.Count > 0)
            if(IsmasterLock == "Y")
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


                int isysc = objBs.InsertSync(txtempname.Text, "Item Screen", drptype.SelectedItem.Text, "Prod");

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


                            string QtyType = (dservercat.Tables[0].Rows[i]["QtyType"]).ToString();
                            string defaultcurrencyid = (dservercat.Tables[0].Rows[i]["defaultcurrencyid"]).ToString();

                            string Rate1 = (dservercat.Tables[0].Rows[i]["Rate1"]).ToString();
                            string MRP1 = (dservercat.Tables[0].Rows[i]["MRP1"]).ToString();

                            string Rate2 = (dservercat.Tables[0].Rows[i]["Rate2"]).ToString();
                            string MRP2 = (dservercat.Tables[0].Rows[i]["MRP2"]).ToString();


                            string Rate3 = (dservercat.Tables[0].Rows[i]["Rate3"]).ToString();
                            string MRP3 = (dservercat.Tables[0].Rows[i]["MRP3"]).ToString();

                            string Rate4 = (dservercat.Tables[0].Rows[i]["Rate4"]).ToString();
                            string MRP4 = (dservercat.Tables[0].Rows[i]["MRP4"]).ToString();

                            string Rate5 = (dservercat.Tables[0].Rows[i]["Rate5"]).ToString();
                            string MRP5 = (dservercat.Tables[0].Rows[i]["MRP5"]).ToString();


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
                                    //  int iids = objBs.syncinsertitem(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Size, isChecked, Tax, Rate, CategoryUserID, GST, TaxVal, unit, empcode, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype, Barcode, Mrp, Pagepath, Description, ratetype);
                                    int iids = objBs.syncinsertitem(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Size, isChecked, Tax, Rate, CategoryUserID, GST, TaxVal, unit, empcode, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype, Barcode, Mrp, Pagepath, Description, ratetype, QtyType, defaultcurrencyid, Rate1, MRP1, Rate2, MRP2, Rate3, MRP3, Rate4, MRP4, Rate5, MRP5);
                                }
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Category Items.Please Contact Administrator.Thank You!!!.');", true);
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


                            string QtyType = (dservercat.Tables[0].Rows[i]["QtyType"]).ToString();
                            string defaultcurrencyid = (dservercat.Tables[0].Rows[i]["defaultcurrencyid"]).ToString();

                            string Rate1 = (dservercat.Tables[0].Rows[i]["Rate1"]).ToString();
                            string MRP1 = (dservercat.Tables[0].Rows[i]["MRP1"]).ToString();

                            string Rate2 = (dservercat.Tables[0].Rows[i]["Rate2"]).ToString();
                            string MRP2 = (dservercat.Tables[0].Rows[i]["MRP2"]).ToString();


                            string Rate3 = (dservercat.Tables[0].Rows[i]["Rate3"]).ToString();
                            string MRP3 = (dservercat.Tables[0].Rows[i]["MRP3"]).ToString();

                            string Rate4 = (dservercat.Tables[0].Rows[i]["Rate4"]).ToString();
                            string MRP4 = (dservercat.Tables[0].Rows[i]["MRP4"]).ToString();

                            string Rate5 = (dservercat.Tables[0].Rows[i]["Rate5"]).ToString();
                            string MRP5 = (dservercat.Tables[0].Rows[i]["MRP5"]).ToString();


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
                                        //  int isuc = objBs.syncupdateitemNEW(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Tax, Rate, CategoryUserID, GST, TaxVal, unit, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype, Barcode, Mrp, Pagepath, Description, ratetype);
                                        int isuc = objBs.syncupdateitemNEW(ItemID, CategoryID, Definition, IsDelete, Serial_No, Serial, Tax, Rate, CategoryUserID, GST, TaxVal, unit, MinimumStock, DisplayOnline, ImageUpload, IsActive, HSNCode, Printitem, foodtype, Barcode, Mrp, Pagepath, Description, ratetype, QtyType, Rate1, MRP1, Rate2, MRP2, Rate3, MRP3, Rate4, MRP4, Rate5, MRP5);
                                    }

                                }
                            }

                        }

                    }
                }



                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);
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
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Push Sales Bill.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionString);
            SqlConnection destination = new SqlConnection(connnectionStringMain);


            source.Open();
            destination.Open();

            SqlCommand cmdsales = new SqlCommand("Select * from tblsales_" + sTableName + " where isnull(IsTransfer,0)=0", source);
            SqlCommand cmdtranssales = new SqlCommand("Select * from tblTranssales_" + sTableName + " where isnull(IsTransfer,0)=0", source);


            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            SqlBulkCopy bulkDataUpdate = new SqlBulkCopy(source);

            SqlDataReader reader = cmdsales.ExecuteReader();
            bulkData.DestinationTableName = "tblsales_" + sTableName + "";
            bulkData.WriteToServer(reader);
            reader.Close();


            int iSuccess = 0;
            string sQry = "Update tblsales_" + sTableName + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);

            SqlDataReader reader1 = cmdtranssales.ExecuteReader();
            bulkData.DestinationTableName = "tblTranssales_" + sTableName + "";
            bulkData.WriteToServer(reader1);
            reader1.Close();

            sQry = "Update tblTranssales_" + sTableName + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);



            bulkData.Close();
            source.Close();
            destination.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


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
    }
}
