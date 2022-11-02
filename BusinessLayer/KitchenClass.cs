using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using CommonLayer;
using System.Data;
namespace BusinessLayer
{
   public class KitchenClass
    {
           #region User Defined Objects
        DBAccess dbObj = null;
        #endregion

        #region Constructors
        public KitchenClass()
        {
            dbObj = new DBAccess();
        }
        #endregion
        #region Production
        public int insert_ingredients(string ingridname, string suppliername, double cost, double qty)
        {
            int i = 0;
            string sqry = "insert into tblIngridents  (IngredientName,SupplierName,Costperkg,Quantity) values('" + ingridname + "','" + suppliername + "','" + cost + "','" + qty + "')";
            i = dbObj.InlineExecuteNonQuery(sqry);
            return i;
        }

        public DataSet get_ingredients()
        {
            DataSet ds = new DataSet();
            string sqry = "Select * from tblIngridents";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

    

        public int insert_receipeName(string receipename, int user, int delete,string type)
        {
            int i = 0;
            string sqry = "insert into tblReceipe (ReceipeName,UserID,isDelete,Type) values('" + receipename + "'," + user + "," + delete + ",'"+type+"')";
            i = dbObj.InlineExecuteNonQuery(sqry);

            string qr = "select max(ReceipeID) as ID from tblReceipe where userid=" + user + "";
            DataSet ds = dbObj.InlineExecuteDataSet(qr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                i =Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());

            }
            return i;
        }

        public DataSet getReceipe(int userid, int Id)
        {
            DataSet ds = new DataSet();
            string qr = "select * from tblReceipe where userid=" + userid + " and ReceipeID=" + Id + "";
             ds = dbObj.InlineExecuteDataSet(qr);
             return ds;
        }

        public DataSet ReceipegridBind(int userid)
        {
            DataSet ds = new DataSet();
            string qr = "select * from tblReceipe where userid=" + userid + "";
            ds = dbObj.InlineExecuteDataSet(qr);
            return ds;
        }
        #endregion

    }
}
