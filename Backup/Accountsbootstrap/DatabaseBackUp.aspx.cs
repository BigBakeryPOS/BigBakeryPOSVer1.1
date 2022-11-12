using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using Microsoft.Office.Core;
using System.Drawing;


namespace Billing.Accountsbootstrap
{
    public partial class DatabaseBackUp : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = string.Empty;
        string DataBaseName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //sTableName = Session["User"].ToString();
            //DataBaseName = Session["DataBaseName"].ToString();
        }


        protected void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {

                tblmessage.Visible = true;

                string Dateandtime = DateTime.Now.ToString("dd/MM/yyyy hh-mm tt").Replace("/", "-");

                string Databasename = ConfigurationManager.AppSettings["DBB"].ToString();
                string backupDIR = ConfigurationManager.AppSettings["DRV"].ToString();

              //  string Databasename = "BFTWNRD2";
               // string backupDIR = "E:\\OneDrive\\DBBackup";

                string BackupName = Databasename + "_" + Dateandtime + ".bak";

                if (!System.IO.Directory.Exists(backupDIR))
                {
                    System.IO.Directory.CreateDirectory(backupDIR);
                }

                int isucess = objbs.Backup_Database(backupDIR, Databasename, BackupName);
                lblError.Text = "Backup database successfully";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error Occured During DB backup process !<br>" + ex.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/DatabaseBackUp.aspx");
        }

    }
}