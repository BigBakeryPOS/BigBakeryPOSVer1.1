using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;
using DocumentFormat.OpenXml.Vml;

namespace Billing.Accountsbootstrap
{
    public partial class itempage : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string cust = "";
        string sTableName = "";
        string Rate = "";
        string superadmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            //btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            if (sTableName == "admin")
            {

            }
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    //purchase.Visible = true;

                    DataSet dsbranch = objBs.getbranchforhomepage();
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        chkbranch.DataSource = dsbranch.Tables[0];
                        chkbranch.DataTextField = "BranchArea";
                        chkbranch.DataValueField = "BranchCode";
                        chkbranch.DataBind();
                        chkbranch.Enabled = true;
                        txtbranch.Visible = false;

                        for (int i = 0; i < chkbranch.Items.Count; i++)
                        {
                            chkbranch.Items[i].Selected = true;
                        }

                    }
                }

                else
                {
                    DataSet dsbranch = objBs.getbranchcode(sTableName);
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        chkbranch.DataSource = dsbranch.Tables[0];
                        chkbranch.DataTextField = "BranchArea";
                        chkbranch.DataValueField = "BranchCode";
                        chkbranch.DataBind();
                        chkbranch.Enabled = false;
                        chkbranch.SelectedValue = "1";
                        txtbranch.Visible = false;

                        for (int i = 0; i < chkbranch.Items.Count; i++)
                        {
                            chkbranch.Items[i].Selected = true;
                        }
                    }
                }


                DataSet dsuom = objBs.getUOM();

                if (dsuom.Tables[0].Rows.Count > 0)
                {
                    ddluom.DataSource = dsuom.Tables[0];
                    ddluom.DataTextField = "UOM";
                    ddluom.DataValueField = "UOMID";
                    ddluom.DataBind();

                }





                DataSet dssubcategory = objBs.gridSubcategory();
                if (dssubcategory.Tables[0].Rows.Count > 0)
                {
                    chksubcategory.DataSource = dssubcategory.Tables[0];
                    chksubcategory.DataTextField = "SubCategoryName";
                    chksubcategory.DataValueField = "SubId";
                    chksubcategory.DataBind();
                }

                DataSet dstax = objBs.getTAX();

                if (dstax.Tables[0].Rows.Count > 0)
                {
                    ddltax.DataSource = dstax.Tables[0];
                    ddltax.DataTextField = "TaxName";
                    ddltax.DataValueField = "Taxid";
                    ddltax.DataBind();

                }

                DataSet dsCategory = objBs.gridcategory();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "CategoryID";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select Category");
                    //ddlcategory.Items.Insert(0, "Select Category");




                }
                //DataSet dVendor = objBs.getVendors();
                //if (dVendor.Tables[0].Rows.Count > 0)
                //{
                //    ddlvendor.DataSource = dVendor.Tables[0];
                //    ddlvendor.DataTextField = "CustomerName";
                //    ddlvendor.DataValueField = "CustomerID";
                //    ddlvendor.DataBind();
                //    ddlvendor.Items.Insert(0, "Select Vendor");
                //}
                btnadd.Text = "Save";
                mrp_calculation(sender, e);
                cust = Request.QueryString.Get("cust");
                if (cust != "" || cust != null)
                {
                    try
                    {
                        DataSet ds = objBs.getcategoryuserforid(cust);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            btnadd.Text = "Update";
                            ddlcategory.Enabled = false;

                            lblitemid.Text = ds.Tables[0].Rows[0]["itemid"].ToString();
                            ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddltax.SelectedValue = ds.Tables[0].Rows[0]["TaxVal"].ToString();
                            txtdescription.Text = ds.Tables[0].Rows[0]["Definition"].ToString();
                            txtSerialNo.Text = ds.Tables[0].Rows[0]["Serial_No"].ToString();
                            txtSerial.Text = ds.Tables[0].Rows[0]["Serial"].ToString();
                            txtSize.Text = ds.Tables[0].Rows[0]["Size"].ToString();
                            txtRate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                            txtMRPPrice.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                            txtHSNCode.Text = ds.Tables[0].Rows[0]["HSNCode"].ToString();
                            txtprintitemname.Text = ds.Tables[0].Rows[0]["Printitem"].ToString();
                            drpfoodtype.SelectedValue = ds.Tables[0].Rows[0]["FoodType"].ToString();
                            drpratetype.SelectedValue = ds.Tables[0].Rows[0]["ratetype"].ToString();
                            txtBarcode.Text = ds.Tables[0].Rows[0]["barcode"].ToString();
                            txtDetails.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                            radbnsalestype.SelectedValue = ds.Tables[0].Rows[0]["Qtytype"].ToString();

                            //Description
                            mrp_calculation(sender, e);

                            string sValue = ds.Tables[0].Rows[0]["isChecked"].ToString();


                            if (sValue == "1")

                                chkPurchsse.Checked = true;
                            else
                                chkPurchsse.Checked = false;



                            if (ddlcategory.SelectedValue != "Select Category")
                            {
                                DataSet ds1 = objBs.Get_CategoryCode(Convert.ToInt32(ddlcategory.SelectedValue));
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    //txtdescription.Text = ds.Tables[0].Rows[0][0].ToString();
                                    txtcatdescription.Text = ds1.Tables[0].Rows[0]["Categorycode"].ToString();


                                    string inputtext = txtdescription.Text;

                                    if (txtcatdescription.Text != "")
                                    {
                                        string outputtext = inputtext.Replace(txtcatdescription.Text, "");
                                        txtdescription.Text = outputtext;
                                    }
                                    txtdescription.Focus();

                                }
                            }

                            ddluom.SelectedValue = ds.Tables[0].Rows[0]["Unit"].ToString();

                            txtminumumstock.Text = ds.Tables[0].Rows[0]["MinimumStock"].ToString();
                            raddisplay.SelectedValue = ds.Tables[0].Rows[0]["DisplayOnline"].ToString();
                            lblFile_Path.Text = ds.Tables[0].Rows[0]["ImageUpload"].ToString();
                            img_Photo.ImageUrl = ds.Tables[0].Rows[0]["ImageUpload"].ToString();


                            DataSet dgetcategorybranch = objBs.getcategorybranchforid(lblitemid.Text);
                            if (dgetcategorybranch.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i <= dgetcategorybranch.Tables[0].Rows.Count - 1; i++)
                                {
                                    {
                                        //Find the checkbox list items using FindByValue and select it.
                                        chkbranch.Items.FindByValue(dgetcategorybranch.Tables[0].Rows[i]["BranchCode"].ToString()).Selected = true;
                                    }
                                }
                            }

                            DataSet dgetcategroyspongue = objBs.getcategoryspongueforid(lblitemid.Text);
                            if (dgetcategroyspongue.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i <= dgetcategroyspongue.Tables[0].Rows.Count - 1; i++)
                                {
                                    {
                                        //Find the checkbox list items using FindByValue and select it.
                                        chksubcategory.Items.FindByValue(dgetcategroyspongue.Tables[0].Rows[i]["SubCatid"].ToString()).Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Something Went wrong Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }
                }

                //string sPage=Request.QueryString.Get("Page");
                //if (sPage == "refresh")
                //{
                //    Response.Redirect("../Accountsbootstrap/itempage.aspx");
                //}

            }
        }

        protected void mrp_calculation(object sender, EventArgs e)
        {
            const int places = 3;
            double beforeamount = 0;
            double mrp = 0;
            double tax = 0;
            double bA = 0;
            txtMRPPrice.Enabled = false;
            txtRate.Enabled = false;
            if (txtMRPPrice.Text == "")
                txtMRPPrice.Text = "0";

            if (txtRate.Text == "")
                txtRate.Text = "0";

            if (drpratetype.SelectedValue == "1")
            {

                mrp = Convert.ToDouble(txtMRPPrice.Text);
                tax = Convert.ToDouble(ddltax.SelectedItem.Text);
                bA = (mrp / (100 + tax)) * 100;
                // var multiplier = (decimal)Math.Pow(10, places);
                //  decimal result = Math.Truncate( Convert.ToDecimal(bA) * multiplier) / multiplier;
                txtRate.Text = bA.ToString("0.00");
                txtMRPPrice.Enabled = true;
            }
            else if (drpratetype.SelectedValue == "2")
            {
                //  txtRate.Text = txtmrp.Text ;
                txtRate.Enabled = true;
                mrp = Convert.ToDouble(txtRate.Text);

                tax = Convert.ToDouble(ddltax.SelectedItem.Text);

                double totalrate = (mrp * tax) / 100;

                double total = mrp + totalrate;

                //    double result = Math.Truncate(total * 10.000) / 10.000;
                var multiplier = (decimal)Math.Pow(10, places);
                decimal result = Math.Truncate(Convert.ToDecimal(total) * multiplier) / multiplier;

                txtMRPPrice.Text = result.ToString();// Convert.ToDouble(total).ToString("f2");
            }


        }

        protected void MRPPrice1_OnTextChanged(object sender, EventArgs e)
        {
            const int places = 3;
            //double mrp = Convert.ToDouble(txtMRPPrice.Text);

            //double tax = Convert.ToDouble(ddltax.SelectedItem.Text);

            //double totalrate = (mrp * tax) / 100;

            //double total = mrp + totalrate;

            //txtRate.Text = Convert.ToDouble(total).ToString("f2");

            double beforeamount = 0;

            if (txtMRPPrice.Text == "")
                txtMRPPrice.Text = "0";

            double mrp = Convert.ToDouble(txtMRPPrice.Text);
            double tax = Convert.ToDouble(ddltax.SelectedItem.Text);
            double bA = (mrp / (100 + tax)) * 100;

            // double result = Math.Truncate(bA * 10.000) / 10.000;
            var multiplier = (decimal)Math.Pow(10, places);
            decimal result = Math.Truncate(Convert.ToDecimal(bA) * multiplier) / multiplier;
            txtRate.Text = result.ToString();

        }

        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {

            if (fp_Upload.HasFile)
            {
                string fileName = System.IO.Path.GetFileName(fp_Upload.PostedFile.FileName);
                fp_Upload.PostedFile.SaveAs(Server.MapPath("~/Files/") + fileName);
                lblFile_Path.Text = "Files/" + fp_Upload.PostedFile.FileName;
                img_Photo.ImageUrl = "Files/" + fp_Upload.PostedFile.FileName;
            }
        }


        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue != "Select Category")
            {
                DataSet ds = objBs.Get_CategoryCode(Convert.ToInt32(ddlcategory.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtdescription.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtcatdescription.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtdescription.Focus();
                }
            }
        }

        protected void Async_Upload_File(object sender, EventArgs e)
        {
        }


        protected void Upload_File(object sender, EventArgs e)
        {
            int iSuccess = 0;
            string Empcode = lblUserID.Text;// Session["empcode"].ToString();

            try
            {
                string connectionString = "";
                string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=" + "\"";
                char[] specialCharactersArray = specialCharacters.ToCharArray();

                if (FileUpload1.HasFile)
                {
                    #region

                    #region
                    string datett = DateTime.Now.ToString();
                    string dtaa = Convert.ToDateTime(datett).ToString("dd-MM-yyyy-hh-mm-ss");
                    string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName) + dtaa;
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string fileLocation = Server.MapPath("~/App_Data/" + fileName);
                    FileUpload1.SaveAs(fileLocation);
                    if (fileExtension == ".xls")
                    {
                        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (fileExtension == ".xlsx")
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Attach Correct Format file Extension.(.xls or .xlsx)');", true);
                        return;
                    }
                    OleDbConnection con = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                    DataTable dtExcelRecords = new DataTable();
                    con.Open();
                    DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                    cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = cmd;
                    dAdapter.Fill(dtExcelRecords);
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtExcelRecords);

                    #endregion

                    #region Sub Branch
                    //////DataSet ndstt = new DataSet();
                    //////DataTable ndttt = new DataTable();

                    //////DataColumn ndc = new DataColumn("Branchcode");
                    //////ndttt.Columns.Add(ndc);

                    //////ndc = new DataColumn("Branchname");
                    //////ndttt.Columns.Add(ndc);

                    //////ndstt.Tables.Add(ndttt);


                    //////foreach (ListItem listItem in chkbranch.Items)
                    //////{

                    //////    if (listItem.Selected)
                    //////    {
                    //////        DataRow ndrd = ndstt.Tables[0].NewRow();
                    //////        ndrd["Branchcode"] = listItem.Value;
                    //////        ndrd["Branchname"] = listItem.Text;
                    //////        ndstt.Tables[0].Rows.Add(ndrd);
                    //////    }
                    //////}
                    #endregion

                    if (ds == null)
                    {

                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        #region

                        string CategoryName = dr["Item"].ToString();

                        if ((Convert.ToString(dr["Category"]) == null) || (Convert.ToString(dr["Category"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                            return;
                        }

                        if ((Convert.ToString(dr["Item"]) == null) || (Convert.ToString(dr["Item"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Item in  " + CategoryName + "');", true);
                            //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
                            return;
                        }

                        if ((Convert.ToString(dr["Tax"]) == null) || (Convert.ToString(dr["Tax"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Tax in  " + CategoryName + "');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Tax in  " + CategoryName + "');", true);
                            return;
                        }

                        if ((Convert.ToString(dr["Rate"]) == null) || (Convert.ToString(dr["Rate"]) == "") || (Convert.ToString(dr["Rate"]) == "0"))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Rate in  " + CategoryName + "');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Rate in  " + CategoryName + "');", true);
                            return;
                        }

                        if ((Convert.ToString(dr["UOM"]) == null) || (Convert.ToString(dr["UOM"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check UOM in  " + CategoryName + "');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check UOM in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["SerialNo"]) == null) || (Convert.ToString(dr["SerialNo"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check SerialNo in  " + CategoryName + "');", true);
                            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check SerialNo in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["TaxType"]) != "I") && (Convert.ToString(dr["TaxType"]) != "E"))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check TaxType in  " + CategoryName + "  for example: I or E ');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check TaxType in  " + CategoryName + "  for example: I or E ');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["Minimumstock"]) == null) || (Convert.ToString(dr["Minimumstock"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Minimumstock in  " + CategoryName + "');", true);
                            //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Minimumstock in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["WholeSalesRate"]) == null) || (Convert.ToString(dr["WholeSalesRate"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check WholeSalesRate in  " + CategoryName + "');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check WholeSalesRate in  " + CategoryName + "');", true);
                            return;
                        }

                        #endregion
                    }

                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        string Category = ds.Tables[0].Rows[j]["Category"].ToString();
                        string CategoryCode = ds.Tables[0].Rows[j]["CategoryCode"].ToString();
                        string ProductionType = ds.Tables[0].Rows[j]["ProductionType"].ToString();

                        string Item = ds.Tables[0].Rows[j]["Item"].ToString();
                        string SerialNo = ds.Tables[0].Rows[j]["SerialNo"].ToString();
                        string Tax = ds.Tables[0].Rows[j]["Tax"].ToString();
                        string Rate = ds.Tables[0].Rows[j]["Rate"].ToString();
                        string UOM = ds.Tables[0].Rows[j]["UOM"].ToString();
                        string HSNCode = ds.Tables[0].Rows[j]["HSNCode"].ToString();
                        string Foodtype = ds.Tables[0].Rows[j]["Ftype"].ToString();

                        double Minimumstock = 50;// Convert.ToDouble(ds.Tables[0].Rows[j]["Minimumstock"].ToString());
                        double WholeSalesRate = 0;// Convert.ToDouble(ds.Tables[0].Rows[j]["WholeSalesRate"].ToString());

                        #region Tax and UOM
                        int TaxId = 0;
                        DataSet dsTax = objBs.getTAXupload(Tax);
                        if (dsTax.Tables[0].Rows.Count > 0)
                        {
                            TaxId = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This Tax  " + Tax + " was not in Table Plz to Check.');", true);
                            return;
                        }



                        int UOMid = 0;
                        DataSet dsUOM = objBs.getUOMValue(UOM);
                        if (dsUOM.Tables[0].Rows.Count > 0)
                        {
                            UOMid = Convert.ToInt32(dsUOM.Tables[0].Rows[0]["UOMID"].ToString());
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This UOM  " + UOM + " was not in Table Plz to Check.');", true);
                            return;
                        }

                        #endregion

                        #region Category

                        int categoryid = 0;
                        DataSet dsCategory = objBs.categorysrchgridnew(Category);
                        if (dsCategory.Tables[0].Rows.Count > 0)
                        {
                            categoryid = Convert.ToInt32(dsCategory.Tables[0].Rows[0]["categoryid"].ToString());
                        }
                        else
                        {
                            int iStatus = objBs.InsertCatforAll(Category, CategoryCode, ProductionType);
                            DataSet dsCat = objBs.categorysrchgridnew(Category);
                            categoryid = Convert.ToInt32(dsCat.Tables[0].Rows[0]["categoryid"].ToString());
                        }
                        #endregion

                        #region Item
                        DataSet dsitem = objBs.defsrchgrid(Item, categoryid.ToString());
                        if (dsitem.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            int iStatus = objBs.InsertitemforAll(categoryid, Item, Convert.ToDouble(Rate), Convert.ToDouble(Tax), TaxId, UOMid, Empcode, Minimumstock, HSNCode, Foodtype, SerialNo, "", "", "", "");

                            DataSet dss = objBs.GetItemID();

                            int iCategoryID = 0;
                            if (dss.Tables[0].Rows[0]["categoryUserId"].ToString() != "")
                            {
                                iCategoryID = Convert.ToInt32(dss.Tables[0].Rows[0]["categoryUserId"].ToString());
                                iSuccess = objBs.StockOnly(sTableName, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(iCategoryID), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy")), 1, Convert.ToInt32(0), "0");
                            }
                        }

                        ////// int ibrachinsert = objBs.insertbranchitem(ndstt);
                        int ibrachinsert = objBs.insertbranchitemvalues();
                        #endregion

                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Items Uploaded Successfully');", true);
                    con.Close();

                    #endregion
                }
                else
                {

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please upload Xls file.It Cannot be empty.');", true);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            string Empcode = Request.Cookies["userInfo"]["empcode"].ToString();
            string sValue = "";
            if (chkPurchsse.Checked == true)
                sValue = "1";
            else
                sValue = "0";




            if (ddlcategory.SelectedValue == "Select Category")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Category');", true);
                ddluom.Focus();
                return;
            }


            cust = Request.QueryString.Get("cust");
           // if (cust != "" || cust != null)
            {
                DataSet ndstt = new DataSet();
                DataTable ndttt = new DataTable();

                DataColumn ndc = new DataColumn("Branchcode");
                ndttt.Columns.Add(ndc);

                ndc = new DataColumn("Branchname");
                ndttt.Columns.Add(ndc);

                ndstt.Tables.Add(ndttt);


                foreach (ListItem listItem in chkbranch.Items)
                {

                    if (listItem.Selected)
                    {
                        DataRow ndrd = ndstt.Tables[0].NewRow();
                        ndrd["Branchcode"] = listItem.Value;
                        ndrd["Branchname"] = listItem.Text;
                        ndstt.Tables[0].Rows.Add(ndrd);
                    }
                }



                DataSet ndstt1 = new DataSet();
                DataTable ndttt1 = new DataTable();

                DataColumn ndc1 = new DataColumn("subcatid");
                ndttt1.Columns.Add(ndc1);
                ndstt1.Tables.Add(ndttt1);


                foreach (ListItem listItem in chksubcategory.Items)
                {

                    if (listItem.Selected)
                    {
                        DataRow ndrd1 = ndstt1.Tables[0].NewRow();
                        ndrd1["subcatid"] = listItem.Value;
                        ndstt1.Tables[0].Rows.Add(ndrd1);
                    }
                }



                if (btnadd.Text == "Save")
                {

                    if (txtBarcode.Text == "" || txtBarcode.Text == "0")
                    {
                        txtBarcode.Text = txtSerial.Text;
                    }



                    int iSuccess = 0;
                    DataSet ds = objBs.DuplicateItemcheck(txtdescription.Text, ddlcategory.SelectedValue);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        if (lblFile_Path.Text == "")
                            lblFile_Path.Text = "Files/BigLogo.png";

                        string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
   Request.ApplicationPath.TrimEnd('/') + "/";

                        string Pagepath = baseUrl + lblFile_Path.Text;

                        int iStatus = 0;
                        if (sTableName == "admin")
                        {


                            //iStatus = objBs.insertcategory(Convert.ToInt32(ddlcategory.SelectedValue), txtcatdescription.Text, txtdescription.Text, txtSerialNo.Text, txtSerial.Text, txtSize.Text, Convert.ToInt32(1), Convert.ToDouble(ddltax.SelectedItem.Text), Convert.ToDouble(txtRate.Text), "Rate", ddltax.SelectedItem.Text, Convert.ToInt32(ddltax.SelectedValue), Convert.ToInt32(ddluom.SelectedValue), Empcode);
                            iStatus = objBs.insertitem(Convert.ToInt32(ddlcategory.SelectedValue), txtcatdescription.Text, txtdescription.Text, txtSerial.Text, ddltax.SelectedValue, (txtRate.Text), (ddluom.SelectedValue), txtminumumstock.Text, raddisplay.SelectedValue, lblFile_Path.Text, Empcode, ddltax.SelectedItem.Text, ddluom.SelectedItem.Text, txtprintitemname.Text, drpfoodtype.SelectedValue, txtHSNCode.Text, txtMRPPrice.Text, txtBarcode.Text, txtDetails.Text, Pagepath, drpratetype.SelectedValue, radbnsalestype.SelectedValue);
                            int ibrachinsert = objBs.insertbranchitem(ndstt);
                            int isubcatinsert = objBs.insertsubcategoryitem(ndstt1);

                            //DataSet dss = objBs.GetItemID();

                            //int iCategoryID = 0;
                            //if (dss.Tables[0].Rows[0]["categoryUserId"].ToString() != "")
                            //{
                            //    iCategoryID = Convert.ToInt32(dss.Tables[0].Rows[0]["categoryUserId"].ToString());
                            //    iSuccess = objBs.StockOnlyItem(ndstt, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(iCategoryID), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy")), 1, Convert.ToInt32(0), "0");
                            //}

                            Response.Redirect("DescriptionGrid.aspx");
                        }
                        else
                        {
                            //iStatus = objBs.insertcategory(Convert.ToInt32(ddlcategory.SelectedValue), txtcatdescription.Text, txtdescription.Text, txtSerialNo.Text, txtSerial.Text, txtSize.Text, Convert.ToInt32(1), Convert.ToDouble(ddltax.SelectedItem.Text), Convert.ToDouble(txtRate.Text), "Rate", ddltax.SelectedItem.Text, Convert.ToInt32(ddltax.SelectedValue), Convert.ToInt32(ddluom.SelectedValue), Empcode);
                            iStatus = objBs.insertitem(Convert.ToInt32(ddlcategory.SelectedValue), txtcatdescription.Text, txtdescription.Text, txtSerial.Text, ddltax.SelectedValue, (txtRate.Text), (ddluom.SelectedValue), txtminumumstock.Text, raddisplay.SelectedValue, lblFile_Path.Text, Empcode, ddltax.SelectedItem.Text, ddluom.SelectedItem.Text, txtprintitemname.Text, drpfoodtype.SelectedValue, txtHSNCode.Text, txtMRPPrice.Text, txtBarcode.Text, txtDetails.Text, Pagepath, drpratetype.SelectedValue, radbnsalestype.SelectedValue);
                            int ibrachinsert = objBs.insertbranchitem(ndstt);
                            int isubcatinsert = objBs.insertsubcategoryitem(ndstt1);

                            //DataSet dss = objBs.GetItemID();

                            //int iCategoryID = 0;
                            //if (dss.Tables[0].Rows[0]["categoryUserId"].ToString() != "")
                            //{
                            //    iCategoryID = Convert.ToInt32(dss.Tables[0].Rows[0]["categoryUserId"].ToString());
                            //    iSuccess = objBs.StockOnlyItem(ndstt, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(iCategoryID), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy")), 1, Convert.ToInt32(0), "0");
                            //}

                            Response.Redirect("DescriptionGrid.aspx");
                        }
                    }
                    else
                    {
                        lblerror.Text = "These Item has already Exists please enter a new one";

                        //int iStatus = objBs.insertcategory(Convert.ToInt32(ddlcategory.SelectedValue), txtdescription.Text);
                        //Response.Redirect("../Accountsbootstrap/Descriptiongrid.aspx");
                    }
                }
                else
                {

                    if (txtBarcode.Text == "" || txtBarcode.Text == "0")
                    {
                        txtBarcode.Text = txtSerial.Text;
                    }

                    int iss = 0;
                    if (lblFile_Path.Text == "")
                        lblFile_Path.Text = "Files/BigLogo.png";

                    string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
  Request.ApplicationPath.TrimEnd('/') + "/";

                    string Pagepath = baseUrl + lblFile_Path.Text;


                    iss = objBs.deletecatbranch(lblitemid.Text);
                    iss = objBs.deletecatspongue(lblitemid.Text);

                    //  cust = Request.QueryString.Get("cust");
                    if (sTableName == "admin")
                    {
                        objBs.updateitementry(txtcatdescription.Text, txtdescription.Text, cust, txtSerial.Text, ddltax.SelectedValue, ddltax.SelectedItem.Text, Convert.ToDouble(txtRate.Text), ddluom.SelectedValue, ddluom.SelectedItem.Text, txtminumumstock.Text, raddisplay.SelectedValue, lblFile_Path.Text, Empcode, txtprintitemname.Text, drpfoodtype.SelectedValue, superadmin, ddlcategory.SelectedValue, lblitemid.Text, txtHSNCode.Text, txtMRPPrice.Text, txtBarcode.Text, txtDetails.Text, Pagepath, drpratetype.SelectedValue, radbnsalestype.SelectedValue);
                        int ibrachinsert = objBs.updatebranchitem(ndstt, cust);
                        int isubcatinsert = objBs.Updatesubcategoryitem(ndstt1, cust);

                        Response.Redirect("DescriptionGrid.aspx");
                    }
                    else
                    {
                        ///objBs.updateitementry(txtcatdescription.Text, txtdescription.Text, cust, txtSerialNo.Text, txtSerial.Text, txtSize.Text, Convert.ToInt32(sValue), Convert.ToDouble(ddltax.SelectedItem.Text), Convert.ToDouble(txtRate.Text), "Rate", ddltax.SelectedItem.Text, Convert.ToInt32(ddltax.SelectedValue), Convert.ToInt32(ddluom.SelectedValue), Empcode);
                        objBs.updateitementry(txtcatdescription.Text, txtdescription.Text, cust, txtSerial.Text, ddltax.SelectedValue, ddltax.SelectedItem.Text, Convert.ToDouble(txtRate.Text), ddluom.SelectedValue, ddluom.SelectedItem.Text, txtminumumstock.Text, raddisplay.SelectedValue, lblFile_Path.Text, Empcode, txtprintitemname.Text, drpfoodtype.SelectedValue, superadmin, ddlcategory.SelectedValue, lblitemid.Text, txtHSNCode.Text, txtMRPPrice.Text, txtBarcode.Text, txtDetails.Text, Pagepath, drpratetype.SelectedValue, radbnsalestype.SelectedValue);
                        int ibrachinsert = objBs.updatebranchitem(ndstt, cust);
                        int isubcatinsert = objBs.Updatesubcategoryitem(ndstt1, cust);

                        Response.Redirect("DescriptionGrid.aspx");
                    }
                }
            }

            //else
            //{
            //    lblerror.Text = "Please Enter Description";
            //}
            //Response.Redirect("DescriptionGrid.aspx");
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {


            Response.Redirect("DescriptionGrid.aspx");

        }

        protected void newvendor_Click(object sender, EventArgs e)
        {
            string url = "Customermaster.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }

    }
}