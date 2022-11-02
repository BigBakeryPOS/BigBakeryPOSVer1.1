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
    public partial class PhysicalStockEntry : System.Web.UI.Page
    {
        BSClass ks = new BSClass();
        DataTable dd = new DataTable();
        string sCode = "";
        class textcolumn : ITemplate
        {
            public void InstantiateIn(System.Web.UI.Control container)
            {
                TextBox link = new TextBox();
                link.ID = "textbox";
                container.Controls.Add(link);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            if (!IsPostBack)
            {
               // string[] Shopnames = ConfigurationManager.AppSettings["Production1"].ToString().Split(',');

                DataSet ds = ks.RawmatlSenttoProduction(sCode);

                gvtransfer.DataSource = ds.Tables[0];
                gvtransfer.DataBind();

            }
        }

        protected void Async_Upload_File(object sender, EventArgs e)
        {
        }


        protected void Upload_File(object sender, EventArgs e)
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

                    string MinimumQty = dr["Qty"].ToString();
                    

                    if (MinimumQty.Replace(" ", "") == "")
                    {

                    }
                    else
                    {
                        
                        if ((Convert.ToString(dr["Items"]) == null) || (Convert.ToString(dr["Items"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check Items  in  " + CategoryName + " ');", true);
                            return;
                        }
                       
                        if ((Convert.ToString(dr["Qty"]) == null) || (Convert.ToString(dr["Qty"]) == ""))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Plz Check MinimumQty in  " + CategoryName + "');", true);
                            return;
                        }
                       
                    }
                    #endregion
                }


                DataTable dtt = new DataTable();
                DataRow dr1 = null;
                dtt.Columns.Add(new DataColumn("Item", typeof(string)));
                dtt.Columns.Add(new DataColumn("Qty", typeof(string)));

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                   
                    string Items = ds.Tables[0].Rows[j]["Items"].ToString();

                   
                    string Qty = ds.Tables[0].Rows[j]["Qty"].ToString();


                    if (Qty.Replace(" ", "") == "")
                    {

                    }
                    else
                    {
                        #region Item

                        DataSet getrawitem = ks.getrawitemneeded(Items);
                        if (getrawitem.Tables[0].Rows.Count > 0)
                        {

                            string id = getrawitem.Tables[0].Rows[0]["IngridID"].ToString();

                            string uom = getrawitem.Tables[0].Rows[0]["units"].ToString();

                            ks.InsertphysicalDatas(Convert.ToInt32(id), DateTime.Today.Date.ToString(), Convert.ToDouble(Qty), Convert.ToDouble(Qty), sCode, uom, "0",lblUserID.Text,"0");
                        }
                        else
                        {
                            dr1 = dtt.NewRow();
                            dr1["Item"] = Items;
                            dr1["Qty"] = Qty;
                            dtt.Rows.Add(dr1);
                        }



                        #endregion

                    }

                    
                }
                gridmissitem.DataSource = dtt;
                gridmissitem.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Ingredients Opening Stock Uploaded Successfully');", true);
                con.Close();

                #endregion
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please upload Xls file.It Cannot be empty.');", true);

            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow Gr in gvtransfer.Rows)
            {
                string id = Gr.Cells[0].Text;
                string OpStk = Gr.Cells[3].Text;
                

                TextBox txtphy = (TextBox)Gr.Cells[4].FindControl("txtphystock");
                Label lbluomid = (Label)Gr.Cells[4].FindControl("lbluomid");
                TextBox txtexpireddate = (TextBox)Gr.Cells[4].FindControl("txtexpireddate");
                TextBox txtrate = (TextBox)Gr.Cells[4].FindControl("txtrate");


                if (txtphy.Text.Trim() == "")
                    txtphy.Text = "0";
                if (txtrate.Text.Trim() == "")
                    txtrate.Text = "0";

                if (txtphy.Text != "0")
                {
                    ks.InsertphysicalDatas(Convert.ToInt32(id), DateTime.Today.Date.ToString(), Convert.ToDouble(OpStk), Convert.ToDouble(txtphy.Text), sCode, lbluomid.Text, txtexpireddate.Text, lblUserID.Text, txtrate.Text);
                }

                if (txtrate.Text != "0")
                {
                    ks.InsertphysicalDatas_Rate(Convert.ToInt32(id), DateTime.Today.Date.ToString(), Convert.ToDouble(OpStk), Convert.ToDouble(txtphy.Text), sCode, lbluomid.Text, txtexpireddate.Text, lblUserID.Text, txtrate.Text);
                }

                if (txtrate.Text != "0")
                {
                }
                //if (txtphy.Text != "0")
                //{
                //    ks.InsertphysicalDatas(Convert.ToInt32(id), DateTime.Today.Date.ToString(), Convert.ToDouble(OpStk), Convert.ToDouble(txtphy.Text), sCode, lbluomid.Text, txtexpireddate.Text,lblUserID.Text);
                //}
            }

            Response.Redirect("PhysicalStockEntry.aspx");
        }
    }
}