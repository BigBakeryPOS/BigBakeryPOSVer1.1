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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace Billing.Accountsbootstrap
{
    public partial class NewPosbill : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet dCat1 = objbs.SalesCategory();
            if (dCat1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dCat1.Tables[0].Rows.Count; i++)
                {
                    string PrintCategory = dCat1.Tables[0].Rows[i]["PrintCategory"].ToString();
                    string CategoryID = dCat1.Tables[0].Rows[i]["CategoryID"].ToString();

                    HtmlAnchor htmlAnchor = new HtmlAnchor();
                    htmlAnchor.HRef = CategoryID;
                    htmlAnchor.InnerText = PrintCategory;
                    

                    pillstab.Controls.Add(htmlAnchor);
                }
            }
        }
    }
}