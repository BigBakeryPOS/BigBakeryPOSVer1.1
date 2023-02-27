using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Reflection;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;


namespace Billing.Accountsbootstrap
{
    public partial class DescriptionGrid : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Description ASC";
        string Sort_Direction1 = "category ASC";
        string Rate = "";
        string superadmin = "";
        string sTableName = "";
        string taxsetting = "";
        string ratesetting = "";
        private string connnectionString;
        // private string connnectionString2;
        private string connnectionStringMain;
        protected void Page_Load(object sender, EventArgs e)
        {
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            taxsetting = Request.Cookies["userInfo"]["TaxSetting"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            if (!IsPostBack)
            {
                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Item");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Item");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnadd.Visible = true;
                    }
                    else
                    {
                        btnadd.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gridview.Columns[12].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[12].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gridview.Columns[13].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[13].Visible = false;
                    }
                }

                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                Rate = Request.Cookies["userInfo"]["Rate"].ToString();
                DataSet ds1 = objBs.viewDescp(Rate);
                gridview.DataSource = ds1;
                gridview.DataBind();
            }

        }

        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("itempage.aspx?cust=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletedescgrid(e.CommandArgument.ToString());
                    Response.Redirect("DescriptionGrid.aspx");
                }
            }
        }

        protected void gridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (superadmin == "1" || superadmin == "2")
                //{
                //    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
                //    ((LinkButton)e.Row.FindControl("btndel")).Enabled = true;

                //    ((Image)e.Row.FindControl("imdedit")).Enabled = true;
                //    ((Image)e.Row.FindControl("Image1")).Enabled = true;
                //}
                //else
                //{
                //    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
                //    ((LinkButton)e.Row.FindControl("btndel")).Visible = false;

                //    ((Image)e.Row.FindControl("imdedit")).Enabled = false;
                //    ((Image)e.Row.FindControl("Image1")).Visible = false;

                //    ((Image)e.Row.FindControl("imgdisable1321")).Enabled = false;
                //    ((Image)e.Row.FindControl("imgdisable1321")).Visible = true;
                //}


                //
                Label lblcgstvalue = ((Label)e.Row.FindControl("lblcgstvalue"));
                Label lblsgstvalue = ((Label)e.Row.FindControl("lblsgstvalue"));
                Label lbltaxvalue = ((Label)e.Row.FindControl("lbltaxvalue"));
                Label lblrate = ((Label)e.Row.FindControl("lblrate"));
                Label lblbrate1 = ((Label)e.Row.FindControl("lblbrate1"));


                lblcgstvalue.Text = Convert.ToDouble(lblcgstvalue.Text).ToString(""+ratesetting+"");
                lblsgstvalue.Text = Convert.ToDouble(lblsgstvalue.Text).ToString("" + ratesetting + "");
                lbltaxvalue.Text = Convert.ToDouble(lbltaxvalue.Text).ToString("" + ratesetting + "");
                lblrate.Text = Convert.ToDouble(lblrate.Text).ToString("" + ratesetting + "");
                lblbrate1.Text = Convert.ToDouble(lblbrate1.Text).ToString("" + ratesetting + "");


                if(taxsetting == "I")
                {
                    gridview.Columns[7].Visible = true;
                    gridview.Columns[8].Visible = true;
                    gridview.Columns[9].Visible = false;
                }
                else
                {
                    gridview.Columns[7].Visible = false;
                    gridview.Columns[8].Visible = false;
                    gridview.Columns[9].Visible = true;
                }
            }
            else
            {
                //((Image)e.Row.FindControl("imdedit")).Visible = false;
                //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;

                //((Image)e.Row.FindControl("Image1")).Visible = false;
                //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("itempage.aspx");
        }


        protected void btnmakeallbranch_Click(object sender, EventArgs e)
        {
            if (sTableName == "admin" || sTableName == "Admin")
            {
                int iscuss = objBs.insertallbranchitem();
            }
            else
            {

                //check this is production or normal store
                DataSet dcheck = objBs.checkproductionbranch(sTableName);
                if (dcheck.Tables[0].Rows.Count > 0)
                {
                    int iscuss = objBs.insertallbranchitem();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Contact Administrator.Thank You!!!.');", true);

                    return;
                }
            }

        }

        protected void btnsyncclick(object sender, EventArgs e)
        {
            ////check this is production or normal store
            //DataSet dcheck = objBs.checkbranchitemtransfer(sTableName);
            //if (dcheck.Tables[0].Rows.Count > 0)
            //{
            //    //   int iscuss = objBs.insertallbranchitem();

            //    connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            //    connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;


            //    // FOR ITEM 
            //    // Create source connection
            //    SqlConnection source = new SqlConnection(connnectionStringMain);
            //    // Create destination connection
            //    SqlConnection destination = new SqlConnection(connnectionString);

            //    // Clean up destination table. Your destination database must have the 
            //    // table with schema which you are copying data to. 
            //    // Before executing this code, you must create a table BulkDataTable 
            //    // in your database where you are trying to copy data to.

            //    SqlCommand cmditem = new SqlCommand("truncate table tblcategoryuser", destination);
            //    SqlCommand cmdbranch = new SqlCommand("truncate table tblcategoryuserbranch", destination);
            //    SqlCommand cmdspongue = new SqlCommand("truncate table tblcategoryusersponge", destination);


            //    // Open source and destination connections.
            //    source.Open();
            //    destination.Open();
            //    cmditem.ExecuteNonQuery();
            //    cmdbranch.ExecuteNonQuery();
            //    cmdspongue.ExecuteNonQuery();



            //    // Select data from Products table
            //    cmditem = new SqlCommand("SELECT * FROM tblcategoryuser", source);
            //    cmdbranch = new SqlCommand("SELECT * FROM tblcategoryuserbranch", source);
            //    cmdspongue = new SqlCommand("SELECT * FROM tblcategoryusersponge", source);


            //    // Create SqlBulkCopy
            //    SqlBulkCopy bulkData = new SqlBulkCopy(destination);

            //    // Execute reader
            //    SqlDataReader reader = cmditem.ExecuteReader();
            //    bulkData.DestinationTableName = "tblcategoryuser";
            //    bulkData.WriteToServer(reader);
            //    reader.Close();




            //    SqlDataReader readerbranch = cmdbranch.ExecuteReader();
            //    bulkData.DestinationTableName = "tblcategoryuserbranch";
            //    bulkData.WriteToServer(readerbranch);
            //    readerbranch.Close();


            //    SqlDataReader readerspongue = cmdspongue.ExecuteReader();
            //    bulkData.DestinationTableName = "tblcategoryusersponge";
            //    bulkData.WriteToServer(readerspongue);



            //    // Close objects
            //    bulkData.Close();
            //    destination.Close();
            //    source.Close();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Get Production Items.Please Contact Administrator.Thank You!!!.');", true);

            //    return;
            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue == "1")
            {
                DataSet ds = objBs.categorysrch(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Category!";
                }
            }
            else if (ddlcategory.SelectedValue == "2")
            {
                DataSet ds = objBs.srchbydef(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Description!";
                }


            }
            else
            {
                DataSet ds = objBs.SearchSerial(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Description!";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DescriptionGrid.aspx");
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            //DataSet ds1 = objBs.gridcustomer();
            //gridview.DataSource = ds1;
            //gridview.DataBind();

            DataSet ds = objBs.viewDescp(Rate);
            gridview.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gridview.DataSource = dvEmployee;
            gridview.DataBind();

        }

        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
            DataSet ds1 = objBs.gridcustomer();
            DataView dvEmp = ds1.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();

        }


        protected void Async_Upload_File(object sender, EventArgs e)
        {
        }

        protected void Upload_File(object sender, EventArgs e)
        {
            string Empcode = lblUserID.Text;// Session["empcode"].ToString();

            //try
            //{
            string connectionString = "";
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();

            if (FileUpload1.HasFile)
            {
                #region

                #region
                string datett = DateTime.Now.ToString();
                string dtaa = Convert.ToDateTime(datett).ToString("dd-MM-yyyy-hh-mm-ss");
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName) + dtaa;
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
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
                //DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                //cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                //dAdapter.SelectCommand = cmd;
                //dAdapter.Fill(dtExcelRecords);
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dtExcelRecords);
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                DataSet ds = new DataSet();
                string getExcelSheetName = "";
                if (dtExcelSheetName.Rows.Count > 0)
                {
                    string orisheet = "Sheet1$";
                    for (int i = 0; i < dtExcelSheetName.Rows.Count; i++)
                    {
                        string NgetExcelSheetName = dtExcelSheetName.Rows[i]["Table_Name"].ToString();
                        if (orisheet == NgetExcelSheetName)
                        {
                            getExcelSheetName = NgetExcelSheetName;
                        }
                    }
                    cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = cmd;
                    dAdapter.Fill(dtExcelRecords);
                    ds.Tables.Add(dtExcelRecords);
                }

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
                    string ProdType = dr["ProductionType"].ToString();
                    string RateType = dr["RateType"].ToString();
                    string QtyType = dr["QtyType"].ToString();

                    if ((Convert.ToString(dr["Category"]) == null) || (Convert.ToString(dr["Category"]) == ""))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                        return;
                    }
                    //if ((Convert.ToString(dr["CategoryCode"]) == null) || (Convert.ToString(dr["CategoryCode"]) == ""))
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check CategoryCode  in  " + CategoryName + " ');", true);
                    //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                    //    return;
                    //}
                    if ((Convert.ToString(dr["ProductionType"]) == null) || (Convert.ToString(dr["ProductionType"]) == ""))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check ProductionType  in  " + CategoryName + " ');", true);
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                        return;
                    }

                    if ((Convert.ToString(dr["Item"]) == null) || (Convert.ToString(dr["Item"]) == ""))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Item in  " + CategoryName + "');", true);
                        //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
                        return;
                    }

                    if (ProdType == "I" || ProdType == "P" || ProdType == "F")
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Production Type  in " + ProdType + ".It may be P/I/R.Thank You');", true);
                        return;
                    }


                    if (QtyType == "E" || QtyType == "D")
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Qty Type  in " + QtyType + ".It may be E/D.Thank You');", true);
                        return;
                    }


                    if (RateType == "I" || RateType == "E")
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Valid Rate Type  in " + RateType + ".It may be I(inclusive)/E(Exclusive).Thank You');", true);
                        return;
                    }


                    if (ProdType != "I")
                    {
                        //if ((Convert.ToString(dr["HSNCode"]) == null) || (Convert.ToString(dr["HSNCode"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check HSNCode in  " + CategoryName + "');", true);
                        //    //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
                        //    return;
                        //}


                        //if ((Convert.ToString(dr["Rate"]) == null) || (Convert.ToString(dr["Rate"]) == "") || (Convert.ToString(dr["Rate"]) == "0"))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Rate in  " + CategoryName + "');", true);
                        //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Rate in  " + CategoryName + "');", true);
                        //    return;
                        //}

                        if ((Convert.ToString(dr["MRP"]) == null) || (Convert.ToString(dr["MRP"]) == "") || (Convert.ToString(dr["MRP"]) == "0"))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check MRP in  " + CategoryName + "');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Rate in  " + CategoryName + "');", true);
                            return;
                        }

                        if ((Convert.ToString(dr["Tax"]) == null) || (Convert.ToString(dr["Tax"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Tax in  " + CategoryName + "');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Tax in  " + CategoryName + "');", true);
                            return;
                        }
                    }
                    if ((Convert.ToString(dr["UOM"]) == null) || (Convert.ToString(dr["UOM"]) == ""))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check UOM in  " + CategoryName + "');", true);
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check UOM in  " + CategoryName + "');", true);
                        return;
                    }
                    //if ((Convert.ToString(dr["SerialNo"]) == null) || (Convert.ToString(dr["SerialNo"]) == ""))
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check SerialNo in  " + CategoryName + "');", true);
                    //    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check SerialNo in  " + CategoryName + "');", true);
                    //    return;
                    //}
                    //if ((Convert.ToString(dr["TaxType"]) != "I") && (Convert.ToString(dr["TaxType"]) != "E"))
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check TaxType in  " + CategoryName + "  for example: I or E ');", true);
                    //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check TaxType in  " + CategoryName + "  for example: I or E ');", true);
                    //    return;
                    //}
                    //if ((Convert.ToString(dr["Minimumstock"]) == null) || (Convert.ToString(dr["Minimumstock"]) == ""))
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Minimumstock in  " + CategoryName + "');", true);
                    //    //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Minimumstock in  " + CategoryName + "');", true);
                    //    return;
                    //}
                    //if ((Convert.ToString(dr["WholeSalesRate"]) == null) || (Convert.ToString(dr["WholeSalesRate"]) == ""))
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check WholeSalesRate in  " + CategoryName + "');", true);
                    //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check WholeSalesRate in  " + CategoryName + "');", true);
                    //    return;
                    //}

                    #endregion
                }

                for (int jj = 0; jj < ds.Tables[0].Rows.Count; jj++)
                {
                    string BarCode = ds.Tables[0].Rows[jj]["Barcode"].ToString();

                    #region BarCode
                    if (BarCode != "")
                    {
                        DataSet Dbarcode = objBs.CheckBarcode(BarCode);
                        if (Dbarcode.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This BarCode Already Exists.Thank You!!!');", true);
                            return;
                        }
                    }
                    #endregion
                }

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    string Category = ds.Tables[0].Rows[j]["Category"].ToString();
                    string CategoryCode = ds.Tables[0].Rows[j]["CategoryCode"].ToString();
                    string ProductionType = ds.Tables[0].Rows[j]["ProductionType"].ToString();

                    string Item = ds.Tables[0].Rows[j]["Item"].ToString();
                    string HSNCode = ds.Tables[0].Rows[j]["HSNCode"].ToString();
                    string SerialNo = ds.Tables[0].Rows[j]["SerialNo"].ToString();

                    string Rate = ds.Tables[0].Rows[j]["Rate"].ToString();
                    string UOM = ds.Tables[0].Rows[j]["UOM"].ToString();
                    string Tax = ds.Tables[0].Rows[j]["Tax"].ToString();
                    string Foodtype = ds.Tables[0].Rows[j]["Ftype"].ToString();
                    string BarCode = ds.Tables[0].Rows[j]["Barcode"].ToString();
                    string MRP = ds.Tables[0].Rows[j]["MRP"].ToString();

                    string description = ds.Tables[0].Rows[j]["Description"].ToString();
                    string RateType = ds.Tables[0].Rows[j]["RateType"].ToString();
                    string QtyType = ds.Tables[0].Rows[j]["QtyType"].ToString();




                    double mrp = Convert.ToDouble(MRP);
                    double tax = Convert.ToDouble(Tax);
                    double bA = 0;
                    string ORate = Convert.ToDouble((mrp / (100 + tax)) * 100).ToString("0.00");

                    if (RateType == "I")
                    {

                        mrp = Convert.ToDouble(MRP);
                        tax = Convert.ToDouble(Tax);
                        bA = (mrp / (100 + tax)) * 100;
                        ORate = bA.ToString("0.00");
                        
                    }
                    else if (RateType == "E")
                    {

                        mrp = Convert.ToDouble(Rate);

                        tax = Convert.ToDouble(tax);

                        double totalrate = (mrp * tax) / 100;

                        double total = mrp + totalrate;

                        ORate = Rate;
                        if (MRP == "0" || MRP == "")
                        {
                            MRP = Convert.ToDouble(total).ToString("f2");
                        }
                    }



                    //string ORate = Convert.ToDouble((Convert.ToDouble(MRP) / Convert.ToDouble(Tax) + 100) * 100).ToString("0.00");

                    double Minimumstock = 50;// Convert.ToDouble(ds.Tables[0].Rows[j]["Minimumstock"].ToString());
                    double WholeSalesRate = 0;// Convert.ToDouble(ds.Tables[0].Rows[j]["WholeSalesRate"].ToString());

                    #region Tax and UOM
                    //int TaxId = 0;
                    //DataSet dsTax = objBs.getTAXupload(Tax);
                    //if (dsTax.Tables[0].Rows.Count > 0)
                    //{
                    //    TaxId = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This Tax  " + Tax + " was not in Table Plz to Check.');", true);
                    //    return;
                    //}

                    #region Tax

                    int TaxId = 0;
                    DataSet dsTax = objBs.getTAXupload(Tax.Replace(" ", ""));
                    if (dsTax.Tables[0].Rows.Count > 0)
                    {
                        TaxId = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                    }
                    else
                    {
                        int iStatus = objBs.InsertTax(Tax.Replace(" ", ""), "Yes", "", "");
                        DataSet dsTax1 = objBs.getTAXupload(Tax.Replace(" ", ""));
                        TaxId = Convert.ToInt32(dsTax1.Tables[0].Rows[0]["Taxid"].ToString());
                    }

                    #endregion


                    #region  UOM

                    int UOMid = 0;
                    DataSet dsUOM = objBs.getUOMValue(UOM);
                    if (dsUOM.Tables[0].Rows.Count > 0)
                    {
                        UOMid = Convert.ToInt32(dsUOM.Tables[0].Rows[0]["UOMID"].ToString());
                    }
                    else
                    {
                        int iStatus = objBs.InsertUOM(UOM, "Yes", "", "");
                        DataSet dsUOM1 = objBs.getUOMValue(UOM);
                        UOMid = Convert.ToInt32(dsUOM1.Tables[0].Rows[0]["UOMID"].ToString());
                    }

                    #endregion

                    //int UOMid = 0;
                    //DataSet dsUOM = objBs.getUOMValue(UOM);
                    //if (dsUOM.Tables[0].Rows.Count > 0)
                    //{
                    //    UOMid = Convert.ToInt32(dsUOM.Tables[0].Rows[0]["UOMID"].ToString());
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This UOM  " + UOM + " was not in Table Plz to Check.');", true);
                    //    return;
                    //}

                    #endregion

                    #region Category

                    string singleqt = "'";
                    string doubleqt = "\"";

                    int categoryid = 0;
                    DataSet dsCategory = objBs.categorysrchgridnew(Category.Replace(singleqt, doubleqt));
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

                    // Insert MArgin

                    int marginbulk = objBs.InsertBulkmargin(categoryid.ToString());



                    #endregion

                    #region Item
                    DataSet dsitem = objBs.defsrchgrid(Item, categoryid.ToString());
                    if (dsitem.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        int iStatus = objBs.InsertitemforAll(categoryid, Item, Convert.ToDouble(ORate), Convert.ToDouble(Tax), TaxId, UOMid, Empcode, 
                            Minimumstock, HSNCode, Foodtype, BarCode, MRP, SerialNo, description,RateType,QtyType);
                        int ibrachinsert = objBs.insertbranchitemvalues();
                    }

                    ////// int ibrachinsert = objBs.insertbranchitem(ndstt);

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

        protected void Async_Upload_File_Update(object sender, EventArgs e)
        {
        }


        //protected void Upload_File(object sender, EventArgs e)
        //{
        //    string Empcode = lblUserID.Text;// Session["empcode"].ToString();

        //    //try
        //    //{
        //    string connectionString = "";
        //    string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=" + "\"";
        //    char[] specialCharactersArray = specialCharacters.ToCharArray();

        //    if (FileUpload1.HasFile)
        //    {
        //        #region

        //        #region
        //        string datett = DateTime.Now.ToString();
        //        string dtaa = Convert.ToDateTime(datett).ToString("dd-MM-yyyy-hh-mm-ss");
        //        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName) + dtaa;
        //        string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
        //        string fileLocation = Server.MapPath("~/App_Data/" + fileName);
        //        FileUpload1.SaveAs(fileLocation);
        //        if (fileExtension == ".xls")
        //        {
        //            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
        //                fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        //        }
        //        else if (fileExtension == ".xlsx")
        //        {
        //            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
        //                fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Attach Correct Format file Extension.(.xls or .xlsx)');", true);
        //            return;
        //        }
        //        OleDbConnection con = new OleDbConnection(connectionString);
        //        OleDbCommand cmd = new OleDbCommand();
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.Connection = con;
        //        OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
        //        DataTable dtExcelRecords = new DataTable();
        //        con.Open();
        //        DataSet ds = new DataSet();
        //        DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //        string getExcelSheetName = "";
        //        if (dtExcelSheetName.Rows.Count > 0)
        //        {
        //            string orisheet = "Sheet1$";
        //            for (int i = 0; i < dtExcelSheetName.Rows.Count; i++)
        //            {
        //                string NgetExcelSheetName = dtExcelSheetName.Rows[i]["Table_Name"].ToString();
        //                if (orisheet == NgetExcelSheetName)
        //                {
        //                    getExcelSheetName = NgetExcelSheetName;
        //                }
        //            }
        //            cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
        //            dAdapter.SelectCommand = cmd;
        //            dAdapter.Fill(dtExcelRecords);
        //            ds.Tables.Add(dtExcelRecords);
        //        }
        //        //string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
        //        //cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
        //        //dAdapter.SelectCommand = cmd;
        //        //dAdapter.Fill(dtExcelRecords);
        //        //DataSet ds = new DataSet();
        //        //ds.Tables.Add(dtExcelRecords);

        //        #endregion

        //        #region Sub Branch
        //        //////DataSet ndstt = new DataSet();
        //        //////DataTable ndttt = new DataTable();

        //        //////DataColumn ndc = new DataColumn("Branchcode");
        //        //////ndttt.Columns.Add(ndc);

        //        //////ndc = new DataColumn("Branchname");
        //        //////ndttt.Columns.Add(ndc);

        //        //////ndstt.Tables.Add(ndttt);


        //        //////foreach (ListItem listItem in chkbranch.Items)
        //        //////{

        //        //////    if (listItem.Selected)
        //        //////    {
        //        //////        DataRow ndrd = ndstt.Tables[0].NewRow();
        //        //////        ndrd["Branchcode"] = listItem.Value;
        //        //////        ndrd["Branchname"] = listItem.Text;
        //        //////        ndstt.Tables[0].Rows.Add(ndrd);
        //        //////    }
        //        //////}
        //        #endregion

        //        if (ds == null)
        //        {

        //        }

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            #region

        //            string CategoryName = dr["Item"].ToString();
        //            string ProdType = dr["ProductionType"].ToString();

        //            if ((Convert.ToString(dr["Category"]) == null) || (Convert.ToString(dr["Category"]) == ""))
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Category  in  " + CategoryName + " ');", true);
        //                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
        //                return;
        //            }
        //            if ((Convert.ToString(dr["CategoryCode"]) == null) || (Convert.ToString(dr["CategoryCode"]) == ""))
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check CategoryCode  in  " + CategoryName + " ');", true);
        //                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
        //                return;
        //            }
        //            if ((Convert.ToString(dr["ProductionType"]) == null) || (Convert.ToString(dr["ProductionType"]) == ""))
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check ProductionType  in  " + CategoryName + " ');", true);
        //                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
        //                return;
        //            }

        //            if ((Convert.ToString(dr["Item"]) == null) || (Convert.ToString(dr["Item"]) == ""))
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Item in  " + CategoryName + "');", true);
        //                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
        //                return;
        //            }
        //            if (ProdType != "I")
        //            {
        //                if ((Convert.ToString(dr["HSNCode"]) == null) || (Convert.ToString(dr["HSNCode"]) == ""))
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check HSNCode in  " + CategoryName + "');", true);
        //                    //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
        //                    return;
        //                }


        //                if ((Convert.ToString(dr["Rate"]) == null) || (Convert.ToString(dr["Rate"]) == "") || (Convert.ToString(dr["Rate"]) == "0"))
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Rate in  " + CategoryName + "');", true);
        //                    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Rate in  " + CategoryName + "');", true);
        //                    return;
        //                }

        //                if ((Convert.ToString(dr["Tax"]) == null) || (Convert.ToString(dr["Tax"]) == ""))
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Tax in  " + CategoryName + "');", true);
        //                    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Tax in  " + CategoryName + "');", true);
        //                    return;
        //                }
        //            }
        //            if ((Convert.ToString(dr["UOM"]) == null) || (Convert.ToString(dr["UOM"]) == ""))
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check UOM in  " + CategoryName + "');", true);
        //                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check UOM in  " + CategoryName + "');", true);
        //                return;
        //            }
        //            //if ((Convert.ToString(dr["SerialNo"]) == null) || (Convert.ToString(dr["SerialNo"]) == ""))
        //            //{
        //            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check SerialNo in  " + CategoryName + "');", true);
        //            //    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check SerialNo in  " + CategoryName + "');", true);
        //            //    return;
        //            //}
        //            //if ((Convert.ToString(dr["TaxType"]) != "I") && (Convert.ToString(dr["TaxType"]) != "E"))
        //            //{
        //            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check TaxType in  " + CategoryName + "  for example: I or E ');", true);
        //            //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check TaxType in  " + CategoryName + "  for example: I or E ');", true);
        //            //    return;
        //            //}
        //            //if ((Convert.ToString(dr["Minimumstock"]) == null) || (Convert.ToString(dr["Minimumstock"]) == ""))
        //            //{
        //            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Minimumstock in  " + CategoryName + "');", true);
        //            //    //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Minimumstock in  " + CategoryName + "');", true);
        //            //    return;
        //            //}
        //            //if ((Convert.ToString(dr["WholeSalesRate"]) == null) || (Convert.ToString(dr["WholeSalesRate"]) == ""))
        //            //{
        //            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check WholeSalesRate in  " + CategoryName + "');", true);
        //            //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check WholeSalesRate in  " + CategoryName + "');", true);
        //            //    return;
        //            //}

        //            #endregion
        //        }

        //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        //        {
        //            string Category = ds.Tables[0].Rows[j]["Category"].ToString();
        //            string CategoryCode = ds.Tables[0].Rows[j]["CategoryCode"].ToString();
        //            string ProductionType = ds.Tables[0].Rows[j]["ProductionType"].ToString();

        //            string Item = ds.Tables[0].Rows[j]["Item"].ToString();
        //            string HSNCode = ds.Tables[0].Rows[j]["HSNCode"].ToString();
        //            string SerialNo = ds.Tables[0].Rows[j]["SerialNo"].ToString();

        //            string Rate = ds.Tables[0].Rows[j]["Rate"].ToString();
        //            string UOM = ds.Tables[0].Rows[j]["UOM"].ToString();
        //            string Tax = ds.Tables[0].Rows[j]["Tax"].ToString();
        //            string Foodtype = ds.Tables[0].Rows[j]["Ftype"].ToString();

        //            double Minimumstock = 50;// Convert.ToDouble(ds.Tables[0].Rows[j]["Minimumstock"].ToString());
        //            double WholeSalesRate = 0;// Convert.ToDouble(ds.Tables[0].Rows[j]["WholeSalesRate"].ToString());

        //            #region Tax and UOM
        //            int TaxId = 0;
        //            DataSet dsTax = objBs.getTAXupload(Tax);
        //            if (dsTax.Tables[0].Rows.Count > 0)
        //            {
        //                TaxId = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This Tax  " + Tax + " was not in Table Plz to Check.');", true);
        //                return;
        //            }



        //            int UOMid = 0;
        //            DataSet dsUOM = objBs.getUOMValue(UOM);
        //            if (dsUOM.Tables[0].Rows.Count > 0)
        //            {
        //                UOMid = Convert.ToInt32(dsUOM.Tables[0].Rows[0]["UOMID"].ToString());
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This UOM  " + UOM + " was not in Table Plz to Check.');", true);
        //                return;
        //            }

        //            #endregion

        //            #region Category

        //            string singleqt = "'";
        //            string doubleqt = "\"";

        //            int categoryid = 0;
        //            DataSet dsCategory = objBs.categorysrchgridnew(Category.Replace(singleqt, doubleqt));
        //            if (dsCategory.Tables[0].Rows.Count > 0)
        //            {
        //                categoryid = Convert.ToInt32(dsCategory.Tables[0].Rows[0]["categoryid"].ToString());
        //            }
        //            else
        //            {
        //                int iStatus = objBs.InsertCatforAll(Category, CategoryCode, ProductionType);
        //                DataSet dsCat = objBs.categorysrchgridnew(Category);
        //                categoryid = Convert.ToInt32(dsCat.Tables[0].Rows[0]["categoryid"].ToString());
        //            }
        //            #endregion

        //            #region Item
        //            DataSet dsitem = objBs.defsrchgrid(Item, categoryid.ToString());
        //            if (dsitem.Tables[0].Rows.Count > 0)
        //            {

        //            }
        //            else
        //            {
        //                int iStatus = objBs.InsertitemforAll(categoryid, Item, Convert.ToDouble(Rate), Convert.ToDouble(Tax), TaxId, UOMid, Empcode, Minimumstock, HSNCode, Foodtype,SerialNo);
        //                int ibrachinsert = objBs.insertbranchitemvalues();
        //            }

        //            ////// int ibrachinsert = objBs.insertbranchitem(ndstt);

        //            #endregion

        //        }

        //        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Items Uploaded Successfully');", true);
        //        con.Close();

        //        #endregion
        //    }
        //    else
        //    {

        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please upload Xls file.It Cannot be empty.');", true);

        //    }
        //}

        protected void Upload_File_Update(object sender, EventArgs e)
        {
            string Empcode = lblUserID.Text;// Session["empcode"].ToString();

            //try
            //{
            string connectionString = "";
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();

            if (FileUpload2.HasFile)
            {
                #region

                #region
                string datett = DateTime.Now.ToString();
                string dtaa = Convert.ToDateTime(datett).ToString("dd-MM-yyyy-hh-mm-ss");
                string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName) + dtaa;
                string fileExtension = Path.GetExtension(FileUpload2.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/App_Data/" + fileName);
                FileUpload2.SaveAs(fileLocation);
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
                DataSet ds = new DataSet();
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = "";
                if (dtExcelSheetName.Rows.Count > 0)
                {
                    string orisheet = "Sheet1$";
                    for (int i = 0; i < dtExcelSheetName.Rows.Count; i++)
                    {
                        string NgetExcelSheetName = dtExcelSheetName.Rows[i]["Table_Name"].ToString();
                        if (orisheet == NgetExcelSheetName)
                        {
                            getExcelSheetName = NgetExcelSheetName;
                        }
                    }
                    cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = cmd;
                    dAdapter.Fill(dtExcelRecords);
                    ds.Tables.Add(dtExcelRecords);
                }
                //string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                //cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                //dAdapter.SelectCommand = cmd;
                //dAdapter.Fill(dtExcelRecords);
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dtExcelRecords);

                #endregion


                if (ds == null)
                {

                }

                if (btntype.SelectedValue != "3")
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        #region

                        string Itemid = dr["Itemid"].ToString();
                        string GST = dr["GST"].ToString();
                        // string ProdType = dr["ProductionType"].ToString();

                        if ((Convert.ToString(dr["Itemid"]) == null) || (Convert.ToString(dr["Itemid"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Item Id  in  " + Itemid + " ');", true);
                            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                            return;
                        }

                        if (btntype.SelectedValue == "2")
                        {
                            if ((Convert.ToString(dr["GST"]) == null) || (Convert.ToString(dr["GST"]) == ""))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check GST in Item ID  " + Itemid + "');", true);
                                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
                                return;
                            }
                        }

                        //if ((Convert.ToString(dr["CategoryCode"]) == null) || (Convert.ToString(dr["CategoryCode"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check CategoryCode  in  " + CategoryName + " ');", true);
                        //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                        //    return;
                        //}
                        //if ((Convert.ToString(dr["ProductionType"]) == null) || (Convert.ToString(dr["ProductionType"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check ProductionType  in  " + CategoryName + " ');", true);
                        //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Category  in  " + CategoryName + " ');", true);
                        //    return;
                        //}

                        //if ((Convert.ToString(dr["Item"]) == null) || (Convert.ToString(dr["Item"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Item in  " + CategoryName + "');", true);
                        //    //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
                        //    return;
                        //}
                        //  if (ProdType != "I")
                        {
                            if ((Convert.ToString(dr["HSNCode"]) == null) || (Convert.ToString(dr["HSNCode"]) == ""))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check HSNCode in Item ID  " + Itemid + "');", true);
                                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Item in  " + CategoryName + "');", true);
                                return;
                            }


                            //if ((Convert.ToString(dr["Rate"]) == null) || (Convert.ToString(dr["Rate"]) == "") || (Convert.ToString(dr["Rate"]) == "0"))
                            //{
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Rate in  " + CategoryName + "');", true);
                            //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Rate in  " + CategoryName + "');", true);
                            //    return;
                            //}

                            //if ((Convert.ToString(dr["Tax"]) == null) || (Convert.ToString(dr["Tax"]) == ""))
                            //{
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Tax in  " + CategoryName + "');", true);
                            //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check Tax in  " + CategoryName + "');", true);
                            //    return;
                            //}
                        }
                        //if ((Convert.ToString(dr["UOM"]) == null) || (Convert.ToString(dr["UOM"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check UOM in  " + CategoryName + "');", true);
                        //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Check UOM in  " + CategoryName + "');", true);
                        //    return;
                        //}
                        #endregion
                    }
                }
                else
                {

                }

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    //string Category = ds.Tables[0].Rows[j]["Category"].ToString();
                    //string CategoryCode = ds.Tables[0].Rows[j]["CategoryCode"].ToString();
                    //string ProductionType = ds.Tables[0].Rows[j]["ProductionType"].ToString();

                    string Itemid = ds.Tables[0].Rows[j]["CategoryuserID"].ToString();
                    //string HSNCode = ds.Tables[0].Rows[j]["HSNCode"].ToString();
                    string HSNCode = "0";
                    string GST = ds.Tables[0].Rows[j]["GST"].ToString();
                    // string SerialNo = "";//ds.Tables[0].Rows[j]["SerialNo"].ToString();

                    string NetRate = ds.Tables[0].Rows[j]["NetRate"].ToString();
                    //string UOM = ds.Tables[0].Rows[j]["UOM"].ToString();
                    //string Tax = ds.Tables[0].Rows[j]["Tax"].ToString();
                    //string Foodtype = ds.Tables[0].Rows[j]["Ftype"].ToString();

                    //double Minimumstock = 50;// Convert.ToDouble(ds.Tables[0].Rows[j]["Minimumstock"].ToString());
                    //double WholeSalesRate = 0;// Convert.ToDouble(ds.Tables[0].Rows[j]["WholeSalesRate"].ToString());

                    //#region Tax and UOM
                    //int TaxId = 0;
                    //DataSet dsTax = objBs.getTAXupload(Tax);
                    //if (dsTax.Tables[0].Rows.Count > 0)
                    //{
                    //    TaxId = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This Tax  " + Tax + " was not in Table Plz to Check.');", true);
                    //    return;
                    //}



                    //int UOMid = 0;
                    //DataSet dsUOM = objBs.getUOMValue(UOM);
                    //if (dsUOM.Tables[0].Rows.Count > 0)
                    //{
                    //    UOMid = Convert.ToInt32(dsUOM.Tables[0].Rows[0]["UOMID"].ToString());
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This UOM  " + UOM + " was not in Table Plz to Check.');", true);
                    //    return;
                    //}

                    //#endregion

                    //#region Category

                    //string singleqt = "'";
                    //string doubleqt = "\"";

                    //int categoryid = 0;
                    //DataSet dsCategory = objBs.categorysrchgridnew(Category.Replace(singleqt, doubleqt));
                    //if (dsCategory.Tables[0].Rows.Count > 0)
                    //{
                    //    categoryid = Convert.ToInt32(dsCategory.Tables[0].Rows[0]["categoryid"].ToString());
                    //}
                    //else
                    //{
                    //    int iStatus = objBs.InsertCatforAll(Category, CategoryCode, ProductionType);
                    //    DataSet dsCat = objBs.categorysrchgridnew(Category);
                    //    categoryid = Convert.ToInt32(dsCat.Tables[0].Rows[0]["categoryid"].ToString());
                    //}
                    //#endregion

                    #region Item
                    //DataSet dsitem = objBs.defsrchgrid(Item, categoryid.ToString());
                    //if (dsitem.Tables[0].Rows.Count > 0)
                    //{

                    //}
                    //else
                    int TaxId = 0;
                    if(btntype.SelectedValue == "2")
                    {
                       
                        DataSet dsTax = objBs.getTAXupload(GST);
                        if (dsTax.Tables[0].Rows.Count > 0)
                        {
                            TaxId = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('This Tax  " + GST + " was not in Table Plz to Check.');", true);
                            return;
                        }
                    }
                    if(btntype.SelectedValue == "1" || btntype.SelectedValue =="2")
                    {
                        int iStatus = objBs.InsertitemforHSNCODE(Itemid, HSNCode,GST,TaxId.ToString(),btntype.SelectedValue);
                        //int ibrachinsert = objBs.insertbranchitemvalues();
                    }
                    if (btntype.SelectedValue == "3")
                    {

                        int irateupdate = objBs.UpdateitemforRate(Itemid, NetRate);

                    }

                    ////// int ibrachinsert = objBs.insertbranchitem(ndstt);

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
        protected DataTable BindDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryId", typeof(Int32));
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("PrintItemName", typeof(string));
            dt.Columns.Add("SerialNo", typeof(string));
          
            return dt;
        }
       
        protected void btndownload_Click(object sender, EventArgs e)
        {


           //your datatable
            using (XLWorkbook wb = new XLWorkbook())
            {
                DataTable dt1 = BindDatatable();
                wb.Worksheets.Add(dt1);
              
                
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=UploadItems.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

            ////Response.ClearContent();
            ////    Response.Buffer = true;
            ////    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "UploadItems.xls"));
            ////    Response.ContentType = "application/ms-excel";
          
            ////    DataTable dt = BindDatatable();
            ////    string str = string.Empty;
            ////    foreach (DataColumn dtcol in dt.Columns)
            ////   {
            ////        Response.Write(str + Convert.ToString(dtcol));
            ////        str = "\t";
            ////    dtcol.ReadOnly = true;
               
            ////   }
            ////    Response.Write("\n");
          
            ////    foreach (DataRow dr in dt.Rows)
            ////   {
            ////    str = "";
            ////    for (int j = 0; j < dt.Columns.Count; j++)
            ////    {
            ////        Response.Write(str + Convert.ToString(dr[j]));
                   
            ////        str = "\t";
            ////    }
            ////    Response.Write("\n");
            ////}
                
            ////Response.End();
            //this.Application
            //this.Application.Cells.Locked = false;
            //this.Application.get_Range("A1", "C3").Locked = true;
            //Excel.Worksheet Sheet1 = (Excel.Worksheet)this.Application.ActiveSheet;
            //Sheet1.Protect(missing, missing, missing, missing, missing, missing, missing,
            //missing, missing, missing, missing, missing, missing, missing, missing, missing);
        }
    }
}
    