using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Text;
using System.IO;
using System.Configuration;
using System.Data;

using System.Data.SqlClient;
namespace StockTransfer
{
    class Program
    {
        

        //static void Main(string[] args)
        //{

        //    SqlConnection con = new SqlConnection(@"Server=server;Database=BlackForestProd;uid=sa;password=P@ss123");
        //    string sQry = "insert into tblopeningstock_co1(categoryid,subcategoryid,qty,Date) select categoryid,subcategoryid,Available_Qty,GetDate()+1 from tblstock_co1  " +
        //       "insert into tblopeningstock_co2(categoryid,subcategoryid,qty,Date) select categoryid,subcategoryid,Available_Qty,GetDate()+1 from tblstock_co2  " +
        //       "insert into tblopeningstock_co3(categoryid,subcategoryid,qty,Date) select categoryid,subcategoryid,Available_Qty,GetDate()+1 from tblstock_co3  " +
        //       "insert into tblopeningstock_co4(categoryid,subcategoryid,qty,Date) select categoryid,subcategoryid,Available_Qty,GetDate()+1 from tblstock_co4  " +
        //       "insert into tblopeningstock_co5(categoryid,subcategoryid,qty,Date) select categoryid,subcategoryid,Available_Qty,GetDate()+1 from tblstock_co5  " +
        //       "insert into tblopeningstock_co7(categoryid,subcategoryid,qty,Date) select categoryid,subcategoryid,Available_Qty,GetDate()+1 from tblstock_co7  ";


        //    SqlCommand cmd = new SqlCommand(sQry, con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();


           
        //    int ToolId = 0;
           



                  
                
            
        //    //string filepath = "C:/Program Files";
        //    //File.AppendAllText(filepath + "log.txt", sb.ToString());
        //    //sb.Append("Filepath : " + filepath);
        //    //sb.Append("Application End");
        //}
    }
}
