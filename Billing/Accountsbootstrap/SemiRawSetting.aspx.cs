using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using CommonLayer;
using System.IO;
using System.Data.OleDb;

namespace Billing.Accountsbootstrap
{
    public partial class SemiRawSetting : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string idEdit = "", idView="", Type="";
        string qtysetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.btnPreview1.Click += new System.EventHandler(this.Add_Click);
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            //////DataSet ds = objBs.item1();
            //////if (ds.Tables[0].Rows.Count > 0)
            //////{
            //////    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //////    {
            //////        string Item1 = ds.Tables[0].Rows[i]["Item1"].ToString();
            //////        string Item2 = ds.Tables[0].Rows[i]["Item2"].ToString();

            //////        int uploadlistz = objBs.uploadrecipelist1(Item1, Item2);


            //////    }
            //////}

            idEdit = Request.QueryString.Get("ID");
            idView = Request.QueryString.Get("ID");
            Type = Request.QueryString.Get("Type");
            if (!IsPostBack)
            {
                d1.Visible = true;
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                DataSet dsCategory = objBs.semirawsetting();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = dsCategory.Tables[0];
                    gridview.DataBind();
                }

                DataSet dcat = objBs.getCatIDprod();
                if (dcat.Tables[0].Rows.Count > 0)
                {
                    drpitem.DataSource = dcat.Tables[0];
                    drpitem.DataTextField = "Definition";
                    drpitem.DataValueField = "CategoryUserID";
                    drpitem.DataBind();
                    drpitem.Enabled = true;

                }

                DataSet ingrid = objBs.ingredients();
                if (ingrid.Tables[0].Rows.Count > 0)
                {

                    gridsemiitem.DataSource = ingrid.Tables[0];
                    gridsemiitem.DataBind();
                }

                if (Type == "Edit")
                {
                    if (idEdit != "" || idEdit != null)
                    {
                        d1.Visible = true;
                        DataSet dget = objBs.getrawsettingid(idEdit);
                        if (dget.Tables[0].Rows.Count > 0)
                        {
                            idView = null;
                           // listitem.Visible = true;
                            lblsettingname.Text = dget.Tables[0].Rows[0]["definition"].ToString();
                            lblqty.Text = dget.Tables[0].Rows[0]["totalqty"].ToString();
                            txtprepareqty.Text = dget.Tables[0].Rows[0]["totalqty"].ToString();
                            drpitem.SelectedValue = dget.Tables[0].Rows[0]["categoryuserid"].ToString();
                            txtproductionhours.Text = dget.Tables[0].Rows[0]["prodhours"].ToString();
                            drpitem.Enabled = false;
                            gridview1.DataSource = dget.Tables[0];
                            gridview1.DataBind();

                            for (int i = 0; i < gridsemiitem.Rows.Count; i++)
                            {

                                Label subcatID = (Label)gridsemiitem.Rows[i].FindControl("lblsemiitemid");
                                TextBox txtrecqty = (TextBox)gridsemiitem.Rows[i].FindControl("txtrecqty");
                                CheckBox chklist = (CheckBox)gridsemiitem.Rows[i].FindControl("chklist");

                                for (int j = 0; j < dget.Tables[0].Rows.Count; j++)
                                {
                                    string Semiitemid = dget.Tables[0].Rows[j]["Semiitemid"].ToString();
                                    string recqty = Convert.ToDouble(dget.Tables[0].Rows[j]["RecQty"]).ToString("0.00");
                                    if (subcatID.Text == Semiitemid)
                                    {
                                        txtrecqty.Text = recqty;
                                        chklist.Checked = true;
                                        break;
                                    }
                                }
                            }
                            btnadd.Text = "Change";
                        }
                        else
                        {
                            listitem.Visible = false;
                        }
                    }
                }
                else if (Type == "View")
                {
                    if (idView != "" || idView != null)
                    {
                        d1.Visible = false;
                        DataSet dget = objBs.getrawsettingid(idEdit);
                        if (dget.Tables[0].Rows.Count > 0)
                        {
                            listitem.Visible = true;
                            lblsettingname.Text = dget.Tables[0].Rows[0]["definition"].ToString();
                            lblqty.Text = dget.Tables[0].Rows[0]["totalqty"].ToString();
                            txtprepareqty.Text = dget.Tables[0].Rows[0]["totalqty"].ToString();
                            drpitem.SelectedValue = dget.Tables[0].Rows[0]["categoryuserid"].ToString();
                            txtproductionhours.Text = dget.Tables[0].Rows[0]["prodhours"].ToString();
                            drpitem.Enabled = false;
                            gridview1.DataSource = dget.Tables[0];
                            gridview1.DataBind();


                        }
                        else
                        {
                            listitem.Visible = false;
                        }
                    }
                }
                else
                {
                    d1.Visible = true;
                }


            }
        }

        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {




            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblrecqty = ((Label)e.Row.FindControl("lblrecqty"));
                //Label lblreceived_Qty = ((Label)e.Row.FindControl("lblreceived_Qty"));
                lblrecqty.Text = Convert.ToDouble(lblrecqty.Text).ToString("" + qtysetting + "");
                //lblreceived_Qty.Text = Convert.ToDouble(lblreceived_Qty.Text).ToString("" + qtysetting + "");

            }
        }

        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {

                    {
                        lblerrorr.Visible = false;
                        objBs.deletesemirawlist(e.CommandArgument.ToString());
                        Response.Redirect("semirawsetting.aspx");
                    }
                }
            }

            else if (e.CommandName == "et")
            {

                if (e.CommandArgument.ToString() != "")
                {
                    idEdit = e.CommandArgument.ToString();
                    Response.Redirect("SemiRawsetting.aspx?ID=" + e.CommandArgument.ToString() + "&Type=Edit");
                }
            }
            else if (e.CommandName == "view")
            {

                if (e.CommandArgument.ToString() != "")
                {
                    idEdit = e.CommandArgument.ToString();
                    Response.Redirect("SemiRawsetting.aspx?ID=" + e.CommandArgument.ToString() +"&Type=View");
                }
            }

        }
        protected void Check_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = new DataTable();
            DataColumn dc;
            DataRow dr;

            dc = new DataColumn();
            dc.ColumnName="Itemname";
            dtCheck.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Qty";
            dtCheck.Columns.Add(dc);

            for (int i = 0; i < gridsemiitem.Rows.Count; i++)
            {
                dr = dtCheck.NewRow();
                Label subcatID = (Label)gridsemiitem.Rows[i].FindControl("Label1");
                TextBox txtrecqty = (TextBox)gridsemiitem.Rows[i].FindControl("txtrecqty");
                CheckBox chklist = (CheckBox)gridsemiitem.Rows[i].FindControl("chklist");

                if (chklist.Checked == true)
                {
                    dr["Itemname"]=subcatID.Text;
                      dr["Qty"] = txtrecqty.Text;
                    dtCheck.Rows.Add(dr);
                }
              
            }
            gvCheck.DataSource = dtCheck;
            gvCheck.DataBind();
           // UpdatePanela.Update();
            UpdatePanel2.Update();
            lnkDelete_ModalPopupExtender.Show();

        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = new DataTable();
            DataColumn dc;
            DataRow dr;

            dc = new DataColumn();
            dc.ColumnName = "Itemname";
            dtCheck.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Qty";
            dtCheck.Columns.Add(dc);

            for (int i = 0; i < gridsemiitem.Rows.Count; i++)
            {
                dr = dtCheck.NewRow();
                Label subcatID = (Label)gridsemiitem.Rows[i].FindControl("Label1");
                TextBox txtrecqty = (TextBox)gridsemiitem.Rows[i].FindControl("txtrecqty");
                CheckBox chklist = (CheckBox)gridsemiitem.Rows[i].FindControl("chklist");

                if (chklist.Checked == true)
                {
                    dr["Itemname"] = subcatID.Text;
                    dr["Qty"] = txtrecqty.Text;
                    dtCheck.Rows.Add(dr);
                }

            }

            gvCheck.DataSource = dtCheck;
            gvCheck.DataBind();
            UpdatePanel2.Update();
            lnkDelete_ModalPopupExtender.Show();



        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (btnadd.Text == "Save")
            {
                DataSet dsCategory = objBs.alreadysemisettingexistsornot(drpitem.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "These Item Name has already Excided please enter a new one";

                }
                else
                {
                    int iStatus = objBs.Insertsemisetting(drpitem.SelectedValue, txtprepareqty.Text, txtproductionhours.Text);



                    for (int i = 0; i < gridsemiitem.Rows.Count; i++)
                    {

                        Label subcatID = (Label)gridsemiitem.Rows[i].FindControl("lblsemiitemid");
                        TextBox txtrecqty = (TextBox)gridsemiitem.Rows[i].FindControl("txtrecqty");
                        CheckBox chklist = (CheckBox)gridsemiitem.Rows[i].FindControl("chklist");

                        if (chklist.Checked == true)
                        {
                            objBs.Inserttranssemisetting(subcatID.Text, txtrecqty.Text);
                        }
                    }

                }
            }
            else if (btnadd.Text == "Change")
            {


                // DELETE OLD RAW SETTING

                int j = objBs.deleterawsetting(idEdit);


                int iupdStatus = objBs.updatesemisetting(idEdit, txtprepareqty.Text, txtproductionhours.Text);

                for (int i = 0; i < gridsemiitem.Rows.Count; i++)
                {

                    Label subcatID = (Label)gridsemiitem.Rows[i].FindControl("lblsemiitemid");
                    TextBox txtrecqty = (TextBox)gridsemiitem.Rows[i].FindControl("txtrecqty");
                    CheckBox chklist = (CheckBox)gridsemiitem.Rows[i].FindControl("chklist");

                    if (chklist.Checked == true)
                    {
                        objBs.Inserttranssemisettingforupdate(subcatID.Text, txtrecqty.Text, idEdit);
                    }
                }
            }
            Response.Redirect("../Accountsbootstrap/semirawsetting.aspx");
        }
        protected void Exit_Click(object sender, EventArgs e)
        {

            Response.Redirect("semirawsetting.aspx");

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SemiRawSetting.aspx");
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
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = dtExcelSheetName.Rows[1]["Table_Name"].ToString();
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                dAdapter.Fill(dtExcelRecords);
                DataSet ds = new DataSet();
                ds.Tables.Add(dtExcelRecords);

                #endregion



                if (ds == null)
                {

                }

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    #region

                    if (dr["Item"].ToString().Replace(" ", "") == "" && dr["RawItems"].ToString().Replace(" ", "") == "" && dr["ProductionHours"].ToString().Replace(" ", "") == "" && dr["RawItems"].ToString().Replace(" ", "") == "" && dr["Qty"].ToString().Replace(" ", "") == "")
                    {
                    }
                    else
                    {
                        string CategoryName = dr["Item"].ToString();
                        if (CategoryName != "")
                        {
                            DataSet daitem = objBs.uploadrecipecheckitems(dr["Item"].ToString());
                            if (daitem.Tables[0].Rows.Count > 0)
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert(' " + dr["Item"].ToString() + " ,It was Not in  DataBase');", true);
                                return;
                            }
                        }
                        DataSet dsrawitems = objBs.uploadrecipecheckingre(dr["RawItems"].ToString());
                        if (dsrawitems.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert(' " + dr["RawItems"].ToString() + " ,It was Not in  DataBase');", true);
                            return;
                        }


                        //if ((Convert.ToString(dr["Item"]) == null) || (Convert.ToString(dr["Item"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Item  in  " + CategoryName + " ');", true);
                        //    return;
                        //}
                        if ((Convert.ToString(dr["ProductionHours"]) == null) || (Convert.ToString(dr["ProductionHours"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check ProductionHours  in  " + CategoryName + " ');", true);
                            return;
                        }
                        //if ((Convert.ToString(dr["RecipeQty"]) == null) || (Convert.ToString(dr["RecipeQty"]) == ""))
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check RecipeQty  in  " + CategoryName + " ');", true);
                        //    return;
                        //}

                        if ((Convert.ToString(dr["RawItems"]) == null) || (Convert.ToString(dr["RawItems"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check RawItems in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["Qty"]) == null) || (Convert.ToString(dr["Qty"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Qty in  " + CategoryName + "');", true);
                            return;
                        }


                        #endregion
                    }
                }


                int uploadlistz = objBs.uploadrecipelist2(ds);


                #region

                //////DataTable dttt = new DataTable();
                //////DataRow drNew;
                //////DataColumn dct = new DataColumn();

                //////DataSet dstd = new DataSet();
                //////dttt = new DataTable();
                //////dct = new DataColumn("Item");
                //////dttt.Columns.Add(dct);
                //////dct = new DataColumn("ProductionHours");
                //////dttt.Columns.Add(dct);
                //////dct = new DataColumn("RecipeQty");
                //////dttt.Columns.Add(dct);
                //////dct = new DataColumn("RawItems");
                //////dttt.Columns.Add(dct);
                //////dct = new DataColumn("Qty");
                //////dttt.Columns.Add(dct);
                //////dstd.Tables.Add(dttt);

                //////int Count = ds.Tables[0].Rows.Count;

                //////for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                //////{
                //////    string Item = ds.Tables[0].Rows[j]["Item"].ToString();
                //////    string ProductionHours = ds.Tables[0].Rows[j]["ProductionHours"].ToString();
                //////    string RecipeQty = ds.Tables[0].Rows[j]["RecipeQty"].ToString();
                //////    string RawItems = ds.Tables[0].Rows[j]["RawItems"].ToString();
                //////    string Qty = ds.Tables[0].Rows[j]["Qty"].ToString();



                //////    if (j + 1 == Count)
                //////    {
                //////        drNew = dttt.NewRow();
                //////        drNew["Item"] = Item;
                //////        drNew["ProductionHours"] = ProductionHours;
                //////        drNew["RecipeQty"] = RecipeQty;
                //////        drNew["RawItems"] = RawItems;
                //////        drNew["Qty"] = Qty;
                //////        dstd.Tables[0].Rows.Add(drNew);

                //////        int uploadlist = objBs.uploadrecipelist(dstd);
                //////        dstd = null;
                //////    }
                //////    else
                //////    {
                //////        if (ds.Tables[0].Rows[j]["Item"].ToString() == ds.Tables[0].Rows[j + 1]["Item"].ToString())
                //////        {
                //////            drNew = dttt.NewRow();
                //////            drNew["Item"] = Item;
                //////            drNew["ProductionHours"] = ProductionHours;
                //////            drNew["RecipeQty"] = RecipeQty;
                //////            drNew["RawItems"] = RawItems;
                //////            drNew["Qty"] = Qty;

                //////            dstd.Tables[0].Rows.Add(drNew);

                //////        }
                //////        else
                //////        {
                //////            drNew = dttt.NewRow();
                //////            drNew["Item"] = Item;
                //////            drNew["ProductionHours"] = ProductionHours;
                //////            drNew["RecipeQty"] = RecipeQty;
                //////            drNew["RawItems"] = RawItems;
                //////            drNew["Qty"] = Qty;
                //////            dstd.Tables[0].Rows.Add(drNew);

                //////            int uploadlist = objBs.uploadrecipelist(dstd);

                //////        }

                //////    }



                //////}

                #endregion

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Items Uploaded Successfully');", true);
                con.Close();


            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please upload Xls file.It Cannot be empty.');", true);

            }
        }

    }
}