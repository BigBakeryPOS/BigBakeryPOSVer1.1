using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string fileName = fileupload.FileName;
            fileupload.PostedFile.SaveAs(Server.MapPath("~/images/") + fileName);


            string path = "~/images/" + fileName.Trim();
            txtpath.Text = path;
        }
    }
}