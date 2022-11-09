using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace Billing.Accountsbootstrap
{
    public partial class SemiItemMaster : System.Web.UI.Page
    {
        BSClass kbs = new BSClass();
        BSClass objBs = new BSClass();
        string idEdit = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            idEdit = Request.QueryString.Get("ID");
            if (!IsPostBack)
            {

                DataSet dstax = kbs.Tax();
                if (dstax.Tables[0].Rows.Count > 0)
                {
                    ddltax.DataSource = dstax.Tables[0];
                    ddltax.DataTextField = "TaxName";
                    ddltax.DataValueField = "Taxid";
                    ddltax.DataBind();

                }

                DataSet dunits = kbs.getUOM();
                if (dunits.Tables[0].Rows.Count > 0)
                {
                    ddlunits.DataSource = dunits.Tables[0];
                    ddlunits.DataTextField = "UOM";
                    ddlunits.DataValueField = "UOMID";
                    ddlunits.DataBind();

                }

                DataSet getprimary = kbs.getPrimary_UOM();
                if (getprimary.Tables[0].Rows.Count > 0)
                {
                    chkprimaryuom.DataSource = getprimary.Tables[0];
                    chkprimaryuom.DataTextField = "name";
                    chkprimaryuom.DataValueField = "primaryuomid";
                    chkprimaryuom.DataBind();

                }


                DataSet dIngCat = kbs.gridsemicategory();
                if (dIngCat.Tables[0].Rows.Count > 0)
                {
                    ddlsemiIngreCategory.DataSource = dIngCat.Tables[0];
                    ddlsemiIngreCategory.DataTextField = "SemiCategory";
                    ddlsemiIngreCategory.DataValueField = "SemiCatID";
                    ddlsemiIngreCategory.DataBind();
                }


                if (idEdit != "")
                {
                    DataSet dget = kbs.Editsemiitem(Convert.ToInt32(idEdit), Convert.ToInt32(lblUserID.Text));
                    if (dget.Tables[0].Rows.Count > 0)
                    {

                        DataSet getprimary_uom = kbs.getPrimary_UOM();
                        if (getprimary_uom.Tables[0].Rows.Count > 0)
                        {
                            chkprimaryuom.DataSource = getprimary_uom.Tables[0];
                            chkprimaryuom.DataTextField = "name";
                            chkprimaryuom.DataValueField = "primaryuomid";
                            chkprimaryuom.DataBind();

                        }

                        ddlsemiIngreCategory.SelectedValue = Convert.ToInt32(dget.Tables[0].Rows[0]["SemiCatID"]).ToString();
                        txtsemiingre.Text = dget.Tables[0].Rows[0]["SemiIngredientName"].ToString();
                        ddlunits.SelectedValue = dget.Tables[0].Rows[0]["Units"].ToString();
                        txtQuantity.Text = dget.Tables[0].Rows[0]["Quantity"].ToString();
                        txtsemiingreCode.Text = dget.Tables[0].Rows[0]["SemiIngredientCode"].ToString();

                        ddltax.SelectedValue = dget.Tables[0].Rows[0]["TaxId"].ToString();
                        txthsncode.Text = dget.Tables[0].Rows[0]["hsncode"].ToString();

                        string IsAllow = dget.Tables[0].Rows[0]["IsAllow"].ToString();

                        if (IsAllow == "Y")
                        {
                            chkallow.Checked = true;

                        }
                        else
                        {
                            chkallow.Checked = false;
                        }



                        DataSet transprimaryuom = objBs.TransEditsemiitem(Convert.ToInt32(idEdit));
                        if (transprimaryuom.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i <= transprimaryuom.Tables[0].Rows.Count - 1; i++)
                            {
                                {
                                    //Find the checkbox list items using FindByValue and select it.
                                    chkprimaryuom.Items.FindByValue(transprimaryuom.Tables[0].Rows[i]["primaryid"].ToString()).Selected = true;
                                }
                            }
                        }


                        btnSubmit.Text = "Update";

                    }
                }
                DataSet ingrid = kbs.GetSemiIngredient();
                Ingredientdrid.DataSource = ingrid;
                Ingredientdrid.DataBind();


            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string isallow = "";

            if (txtsemiingre.Text.Trim() == "" || txtsemiingre.Text.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Semi Ingredient');", true);
            }
            if (txtsemiingreCode.Text.Trim() == "" || txtsemiingreCode.Text.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Semi IngredientCode');", true);
            }


            if (chkallow.Checked == true)
            {
                isallow = "Y";
            }
            else
            {
                isallow = "N";
            }


            if (btnSubmit.Text == "Save")
            {
                #region

                DataSet dsCategory = kbs.searchsemiIngredient(txtsemiingre.Text, ddlsemiIngreCategory.SelectedValue);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Semi Ingridients has already Exists. please enter a new one');", true);
                        return;


                    }
                    else
                    {
                        int insert = kbs.insert_Semi_ingredients(txtsemiingre.Text, Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, txtQuantity.Text, Convert.ToInt32(ddlsemiIngreCategory.SelectedValue), txtsemiingreCode.Text, isallow, Convert.ToInt32(ddltax.SelectedValue), Convert.ToDouble(ddltax.SelectedItem.Text), txthsncode.Text);

                        foreach (ListItem item in chkprimaryuom.Items)
                        {
                            if (item.Selected)
                            {

                                objBs.trans_inert_semi(txtsemiingre.Text, item.Value);
                            }
                        }

                        Response.Redirect("../Accountsbootstrap/SemiItemMaster.aspx");
                    }


                }
                else
                {

                    int insert = kbs.insert_Semi_ingredients(txtsemiingre.Text, Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, txtQuantity.Text, Convert.ToInt32(ddlsemiIngreCategory.SelectedValue), txtsemiingreCode.Text, isallow, Convert.ToInt32(ddltax.SelectedValue), Convert.ToDouble(ddltax.SelectedItem.Text), txthsncode.Text);
                    foreach (ListItem item in chkprimaryuom.Items)
                    {
                        if (item.Selected)
                        {

                            objBs.trans_inert_semi(txtsemiingre.Text, item.Value);
                        }
                    }
                    Response.Redirect("../Accountsbootstrap/SemiItemMaster.aspx");
                }
                #endregion
            }
            else
            {
                #region

                DataSet dsCategory = kbs.searchSemiIngredientforupdate(txtsemiingre.Text, Convert.ToInt32(idEdit), ddlsemiIngreCategory.SelectedValue);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Semi Item has already Exists. please enter a new one');", true);
                        return;


                    }
                    else
                    {

                        // Delete transPrimary UOM
                        int idlete = objBs.trans_inert_semi(idEdit);


                        int update = kbs.update_Semi_ingredients(txtsemiingre.Text, Convert.ToInt32(idEdit), ddlunits.SelectedValue, txtQuantity.Text, Convert.ToInt32(ddlsemiIngreCategory.SelectedValue), txtsemiingreCode.Text, isallow, Convert.ToInt32(ddltax.SelectedValue), Convert.ToDouble(ddltax.SelectedItem.Text), txthsncode.Text);
                        foreach (ListItem item in chkprimaryuom.Items)
                        {
                            if (item.Selected)
                            {

                                objBs.trans_inert_semi(txtsemiingre.Text, item.Value);
                            }
                        }
                        Response.Redirect("../Accountsbootstrap/SemiItemMaster.aspx");
                    }


                }
                else
                {
                    // Delete transPrimary UOM
                    int idlete = objBs.trans_inert_semi(idEdit);

                    int insert = kbs.update_Semi_ingredients(txtsemiingre.Text, Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, txtQuantity.Text, Convert.ToInt32(ddlsemiIngreCategory.SelectedValue), txtsemiingreCode.Text, isallow, Convert.ToInt32(ddltax.SelectedValue), Convert.ToDouble(ddltax.SelectedItem.Text), txthsncode.Text);
                    foreach (ListItem item in chkprimaryuom.Items)
                    {
                        if (item.Selected)
                        {

                            objBs.trans_inert_semi(txtsemiingre.Text, item.Value);
                        }
                    }
                    Response.Redirect("SemiItemMaster.aspx");
                }

                #endregion
            }

        }

        protected void Ingredientdrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            idEdit = e.CommandArgument.ToString();
            Session["ID"] = e.CommandArgument.ToString();
            if (e.CommandName == "et")
            {

                Response.Redirect("SemiItemMaster.aspx?ID=" + e.CommandArgument.ToString());

            }
            else
            {

                int delete = kbs.delete_Semi_Integr(Convert.ToInt32(idEdit), Convert.ToInt32(lblUserID.Text));
                Response.Redirect("SemiItemMaster.aspx");
            }


        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            txtsemiingre.Text = "";
            txtQuantity.Text = "";

            ddlunits.ClearSelection();
            btnSubmit.Text = "Save";

            txtsemiingre.Focus();

        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataSet ds = kbs.GetSemiIngredient();
            Ingredientdrid.DataSource = ds;
            Ingredientdrid.DataBind();
        }
        protected void Async_Upload_File(object sender, EventArgs e)
        {
        }


        protected void Upload_File(object sender, EventArgs e)
        {
            string Empcode = lblUserID.Text;


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

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    #region

                    string CategoryName = dr["Items"].ToString();

                    string Code = dr["Code"].ToString();
                    string Group = dr["Group"].ToString();
                    string Items = dr["Items"].ToString();
                    string UOM = dr["UOM"].ToString();
                    string MinimumQty = dr["MinimumQty"].ToString();
                    string ISAllow = dr["IsAllow"].ToString();
                    string Tax = dr["Tax"].ToString();
                    string Hsncode = dr["Hsncode"].ToString();

                    if (Code.Replace(" ", "") == "" && Group.Replace(" ", "") == "" && Items.Replace(" ", "") == "" && UOM.Replace(" ", "") == "" && MinimumQty.Replace(" ", "") == "")
                    {

                    }
                    else
                    {
                        if ((Convert.ToString(dr["Code"]) == null) || (Convert.ToString(dr["Code"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Code  in  " + CategoryName + " ');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["Group"]) == null) || (Convert.ToString(dr["Group"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Group  in  " + CategoryName + " ');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["Items"]) == null) || (Convert.ToString(dr["Items"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Items  in  " + CategoryName + " ');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["UOM"]) == null) || (Convert.ToString(dr["UOM"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check UOM in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["MinimumQty"]) == null) || (Convert.ToString(dr["MinimumQty"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check MinimumQty in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["IsAllow"]) == null) || (Convert.ToString(dr["IsAllow"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check IsAllow in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["Tax"]) == null) || (Convert.ToString(dr["Tax"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Enter TAX in  " + CategoryName + "');", true);
                            return;
                        }
                        if ((Convert.ToString(dr["Hsncode"]) == null) || (Convert.ToString(dr["Hsncode"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Enter HSN code in  " + CategoryName + "');", true);
                            return;
                        }
                    }
                    #endregion
                }

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    string Code = ds.Tables[0].Rows[j]["Code"].ToString();
                    string Group = ds.Tables[0].Rows[j]["Group"].ToString();
                    string Items = ds.Tables[0].Rows[j]["Items"].ToString();

                    string UOM = ds.Tables[0].Rows[j]["UOM"].ToString();
                    string MinimumQty = ds.Tables[0].Rows[j]["MinimumQty"].ToString();
                    string ISAllow = ds.Tables[0].Rows[j]["IsAllow"].ToString();

                    string Tax = ds.Tables[0].Rows[j]["Tax"].ToString();
                    string HSncode = ds.Tables[0].Rows[j]["Hsncode"].ToString();

                    if (Code.Replace(" ", "") == "" && Group.Replace(" ", "") == "" && Items.Replace(" ", "") == "" && UOM.Replace(" ", "") == "" && MinimumQty.Replace(" ", "") == "" && Tax.Replace(" ", "") == "" && HSncode.Replace(" ", "") == "")
                    {

                    }
                    else
                    {
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

                        #region Category

                        string singleqt = "'";
                        string doubleqt = "\"";

                        int categoryid = 0;
                        DataSet dsCategory = objBs.categoryfor_Semi_ingredient(Group.Replace(singleqt, doubleqt));
                        if (dsCategory.Tables[0].Rows.Count > 0)
                        {
                            categoryid = Convert.ToInt32(dsCategory.Tables[0].Rows[0]["SemiCatID"].ToString());
                        }
                        else
                        {
                            int iStatus = objBs.Insert_SemiCatforingredient(Group.Replace(singleqt, doubleqt));
                            DataSet dsCat = objBs.categoryfor_Semi_ingredient(Group.Replace(singleqt, doubleqt));
                            categoryid = Convert.ToInt32(dsCat.Tables[0].Rows[0]["SemiCatID"].ToString());
                        }
                        #endregion

                        #region Tax

                        int TaxID = 0;
                        DataSet dsTax = objBs.getTAXupload(Tax.Replace(" ", ""));
                        if (dsTax.Tables[0].Rows.Count > 0)
                        {
                            TaxID = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                        }
                        else
                        {
                            int iStatus = objBs.InsertTax(Tax.Replace(" ", ""), "Yes", "", "");
                            DataSet dsTax1 = objBs.getTAXupload(Tax.Replace(" ", ""));
                            TaxID = Convert.ToInt32(dsTax1.Tables[0].Rows[0]["Taxid"].ToString());
                        }
                        #endregion

                        #region Item

                        DataSet dsitem = objBs.searchsemiIngredient(Items.Replace(singleqt, doubleqt), categoryid.ToString());
                        if (dsitem.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            int insert = kbs.insert_Semi_ingredients(Items.Replace(singleqt, doubleqt), Convert.ToInt32(lblUserID.Text), UOMid.ToString(), MinimumQty, Convert.ToInt32(categoryid), Code, ISAllow, TaxID, Convert.ToDouble(Tax), HSncode);

                        }

                        #endregion

                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Semi Item Uploaded Successfully');", true);
                con.Close();

                #endregion
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please upload Xls file.It Cannot be empty.');", true);

            }
        }

    }
}