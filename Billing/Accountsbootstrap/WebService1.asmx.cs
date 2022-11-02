using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using BusinessLayer;
using System.Data.SqlClient;
namespace Billing.Accountsbootstrap
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
       
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public string[] AutoCompleteAjaxRequest(string prefixText, int count)
        {
            List<string> ajaxDataCollection = new List<string>();
            DataTable _objdt = new DataTable();
            _objdt = GetDataFromDataBase(prefixText);
            if (_objdt.Rows.Count > 0)
            {
                for (int i = 0; i < _objdt.Rows.Count; i++)
                {
                    ajaxDataCollection.Add(_objdt.Rows[i]["CustomerName"].ToString());
                }
            }
            return ajaxDataCollection.ToArray();
        }
         [WebMethod]
        public DataTable GetDataFromDataBase(string prefixText)
        {
            string connectionstring = "add name=Server connectionString=Data Source=server;Initial Catalog=BlackForestProd;User ID=sa;Password=P@ss123 providerName=System.Data.SqlClient";
            DataTable _objdt = new DataTable();
            string querystring ="select * from tblCustomer where CustomerName  like '%" + prefixText + "%';";
            SqlConnection _objcon = new SqlConnection(connectionstring);
            SqlDataAdapter _objda = new SqlDataAdapter(querystring, _objcon);
            _objcon.Open();
            _objda.Fill(_objdt);
            return _objdt;
        }
    }
}
