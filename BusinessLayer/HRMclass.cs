using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataLayer;
using CommonLayer;


namespace BusinessLayer
{
    public class HRMclass
    {
        public DataSet checkalreadydateexists(string sAssignId)
        {
            DataSet ds = new DataSet();
            //  string sqry = "SELECT * from tbl_task1 where markdate= CONVERT(date, getdate()) and AssignId='"+ sAssignId +"'";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string sqry = "SELECT * from tbl_task1 where markdate= CONVERT(date,'" + date + "') and AssignId='" + sAssignId + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public int inserttaskstatus(string semp_name, string semp_id, string sdate, string stask, string sStatus, string sComments, string sAssignID, string taskper, string doc, int point)
        {
            string datte = DateTime.Now.ToString("yyyy-MM-dd");
            int itask = 0;
            string sqryyy = "insert into tbltaskstatus(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document,points,markdate) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + stask + "','" + sStatus + "','" + sComments + "','" + sAssignID + "','" + taskper + "','" + doc + "','" + point + "','" + datte + "')";
            itask = dbObj.InlineExecuteNonQuery(sqryyy);
            return itask;
        }
        #region updateAssignmentCmts
        public int updateAssignmentCmts(string sComts, string sAssignId, int calc)
        {
            string datte = DateTime.Now.ToString("yyyy-MM-dd");
            string datte1 = DateTime.Now.ToString("dd/MM/yyyy");
            int itask = 0;
            string sQry = "update tblAssignment set Comments='" + sComts + "',calculate='" + calc + "',markdate='" + datte + "',lastdate='" + datte1 + "'  where TaskAssignmentId='" + sAssignId + "'";
            itask = dbObj.InlineExecuteNonQuery(sQry);
            return itask;
        }
        #endregion
        public DataSet checkcalcupoints(string sAssignId)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tblassignment where TaskAssignmentId='" + sAssignId + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public int UpdateTodaytasknew(string sStatus, string sComts, string sAssignId, string percentage, string doc, int point)
        {
            string datte = DateTime.Now.ToString("yyyy-MM-dd");
            int itask = 0;
            string sQry = "update tbl_task1 set Status='" + sStatus + "',Comments='" + sComts + "',taskpercentage='" + percentage + "',document='" + doc + "',points='" + point + "',markdate='" + datte + "' where AssignId='" + sAssignId + "'";
            itask = dbObj.InlineExecuteNonQuery(sQry);
            return itask;
        }
        public DataSet taskgridviewnew(string sDate, string employee)
        {
            DataSet ds = new DataSet();
            if (employee == "All")
            {
                string gridtask = "select A.*,B.*,c.status from tbl_task1 A,tblAssignment B, tblstatus C where A.AssignId=B.TaskAssignmentId and b.Taskprty=c.statusid and Date<='" + sDate + "' and (B.status='0' or b.status ='2') order by date desc ";
                ds = dbObj.InlineExecuteDataSet(gridtask);
            }
            else
            {
                // string gridtask = "select A.*,B.* from tbl_task1 A,tblAssignment B where A.AssignId=B.TaskAssignmentId and Date<='" + sDate + "' and (B.status='0' or b.status ='2') ";
                string gridtask = "select A.*,B.*,c.status from tbl_task1 A,tblAssignment B, tblstatus C where A.AssignId=B.TaskAssignmentId and b.Taskprty=c.statusid and Date<='" + sDate + "' and (B.status='0' or b.status ='2') and b.employeeid='" + employee + "' order by date desc ";
                ds = dbObj.InlineExecuteDataSet(gridtask);
            }
            return ds;
        }
        public DataSet checkHandelProjectnew(string sDate, string employee)
        {
            DataSet ds = new DataSet();
            if (employee == "All")
            {
                string sqry = "select TaskDate,Task,Name,TaskAssignmentId as assignid,taskenddate,c.status from tblAssignment A,tblEmployeeDetails B , tblstatus c where Taskdate<='" + sDate + "' and A.EmployeeId=B.Employee_Id and a.taskprty =c.statusid and TaskAssignmentId not in (select AssignId from tbl_task1) order by Taskdate desc ";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            else
            {
                string sqry = "select TaskDate,Task,Name,TaskAssignmentId as assignid,taskenddate,c.status from tblAssignment A,tblEmployeeDetails B , tblstatus c where Taskdate<='" + sDate + "' and A.EmployeeId=B.Employee_Id and a.employeeid='" + employee + "' and a.taskprty =c.statusid and TaskAssignmentId not in (select AssignId from tbl_task1) order by Taskdate desc ";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }

            return ds;
        }
        public DataSet checktaskper(int empid)
        {
            DataSet ds = new DataSet();
            string gridtask = "select A.* from tbl_task1 A,tblAssignment B where A.AssignId=B.TaskAssignmentId and a.assignid='" + empid + "' ";
            ds = dbObj.InlineExecuteDataSet(gridtask);
            return ds;
        }
        public DataSet selecttaskdate(int sEmployeeId)
        {
            DataSet ds = new DataSet();
            string getdoc = " select A.Comments,A.TaskAssignmentId,a.TaskDate,A.Task,A.EmployeeId,B.Name,A.Document from tblAssignment A,tblEmployeeDetails B where a.EmployeeId=b.Employee_Id  and a.TaskAssignmentId='" + sEmployeeId + "'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        public DataSet TaskGrid_comp(int eid)
        {
            DataSet ds = new DataSet();
            //  string getdoc = "  select * from tblAssignment where EmployeeId ='"+eid+"' ";
            //  string getdoc = "select case ai.status when  0 then 'InComplete' else 'Completed' end as status1, ai.*,emp.Name from tblAssignment as ai inner join tblEmployeeDetails as emp on emp.Employee_Id=ai.EmployeeId where ai.EmployeeId='" + eid + "'";
            string getdoc = "select case ai.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, ai.*,emp.Name,sat.status as satu from tblAssignment as ai inner join tblEmployeeDetails as emp on emp.Employee_Id=ai.EmployeeId inner join tblstatus as sat on sat.statusid=ai.Taskprty where ai.EmployeeId='" + eid + "' and ai.status='1'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }

        public bool CheckIftaskcompleted(int cat)
        {
            DataSet ds = new DataSet();
            int qty = 0;
            // string sqry = "select * from tblCategory where isdelete=0  ";
            string sqry = "select COUNT(*) from tblAssignment Where status=1 and TaskAssignmentID =" + cat.ToString();

            object qtyObj = dbObj.InlineExecuteScalar(sqry);

            if (qtyObj != null && qtyObj != DBNull.Value)
            {
                qty = (int)qtyObj;

                if (qty > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

        }

        public DataSet getholiday()
        {
            DataSet ds = new DataSet();
            //  string sqry = "SELECT * from tbl_task1 where markdate= CONVERT(date, getdate()) and AssignId='"+ sAssignId +"'";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            //  string sqry = "select * from tbl_Holiday  WHERE (todate BETWEEN '" + date + "' AND '" + date + "') or (FromDate BETWEEN '" + date + "' AND '" + date + "')";
            string sqry = "select * from tbl_Holiday  WHERE (todate >='" + date + "' AND FromDate <='" + date + "')";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Checkoldpassword(string username)
        {
            DataSet ds = new DataSet();
            string sqry = "select Emp_code, Password from Emp_logintbl where UserName='" + username + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;

        }
        public int insert(string username, string password)
        {
            int insert = 0;
            string sqry = "update Emp_logintbl set Password='" + password + "' where Emp_code='" + username + "'";
            insert = dbObj.InlineExecuteNonQuery(sqry);
            return insert;
        }
        public DataSet taskgridviewstatus(int empid)
        {
            DataSet ds = new DataSet();
            string gridtask = "select A.* from tbltaskstatus A,tblAssignment B where A.AssignId=B.TaskAssignmentId  and A.assignid='" + empid + "' order by A.taskid ";
            ds = dbObj.InlineExecuteDataSet(gridtask);
            return ds;
        }
        public DataSet checkcompletedtasknew(string sDate, string employee)
        {
            DataSet ds = new DataSet();
            if (employee == "All")
            {
                // string sqry = "select case a.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, a.*,emp.Name,s.status as prty from tblAssignment as a inner join tblEmployeeDetails as emp on emp.Employee_Id=a.EmployeeId   inner join tblstatus as s on s.statusid=a.taskprty  where  a.taskenddate <='" + sDate + "' and (a.status='1') order by a.taskenddate desc ";
                string sqry = " select A.*,B.*,c.status from tbl_task1 A,tblAssignment B, tblstatus C where A.AssignId=B.TaskAssignmentId and b.Taskprty=c.statusid and Date<='" + sDate + "' and (B.status='1') order by date desc";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            else
            {
                // string sqry = "select case a.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, a.*,emp.Name,s.status as prty from tblAssignment as a inner join tblEmployeeDetails as emp on emp.Employee_Id=a.EmployeeId   inner join tblstatus as s on s.statusid=a.taskprty  where a.employeeid='" + employee + "' and a.taskenddate <='" + sDate + "' and (a.status='1') order by a.taskenddate desc  ";
                string sqry = "select A.*,B.*,c.status from tbl_task1 A,tblAssignment B, tblstatus C where A.AssignId=B.TaskAssignmentId and b.Taskprty=c.statusid and Date<='" + sDate + "' and (B.status='1') and b.employeeid='" + employee + "' order by date desc";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }

            return ds;
        }

        public DataSet checkpendingtasknew(string sDate, string employee)
        {
            DataSet ds = new DataSet();
            if (employee == "All")
            {
                string sqry = "select case a.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, a.*,emp.Name,s.status as prty from tblAssignment as a inner join tblEmployeeDetails as emp on emp.Employee_Id=a.EmployeeId   inner join tblstatus as s on s.statusid=a.taskprty  where  a.taskenddate <='" + sDate + "' and (a.status='0' or a.status ='2') order by a.taskenddate desc ";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            else
            {
                string sqry = "select case a.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, a.*,emp.Name,s.status as prty from tblAssignment as a inner join tblEmployeeDetails as emp on emp.Employee_Id=a.EmployeeId   inner join tblstatus as s on s.statusid=a.taskprty  where a.employeeid='" + employee + "' and a.taskenddate <='" + sDate + "' and (a.status='0' or a.status ='2') order by a.taskenddate desc  ";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }

            return ds;
        }
        #region User Defined Objects
        DBAccess dbObj = null;
        #endregion

        #region Constructors
        public HRMclass()
        {
            dbObj = new DBAccess();
        }
        #endregion
        #region
        #region Holidays
        public int insert_Holiday(string Date, string todate, string leavefor)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_Holiday (FromDate,ToDate,LeaveFor) values(convert(date,'" + Date + "',103),convert(date,'" + todate + "',103),'" + leavefor + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        #endregion
        #region
        public DataSet GridPayrollConfig()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_SalaryConfiguration";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region chkID
        public DataSet chkid()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_compprofile";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;

        }

        #endregion
        #region menucolor
        public DataSet Menucolor1()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_colors";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region chkID1
        public DataSet chkid1()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_compprofile";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;

        }

        #endregion
        #endregion
        #region checkboxpayroll
        public int UpdatePayroll(int ID)
        {
            int iSuccess = 0;
            string sQry = "update tbl_SalaryConfiguration set IsDelete=1 where id='" + ID + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        #region Login
        public DataSet empLogin(string Employee_Name, string Password)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Emp_logintbl where Emp_code ='" + Employee_Name + "'and Password='" + Password + "' ";//@username and Password=@password";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region Client_Login
        public DataSet Client_login(string Cliente_Name, string Password)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_ClientLogin where UserName ='" + Cliente_Name + "'and Password='" + Password + "' ";//@username and Password=@password";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region Hol
        public DataSet get_holiday(string today2)
        {
            DataSet ds = new DataSet();
            string sQry = "select count(*) as Total from tbl_Holiday where FromDate>=(convert(date,'" + today2 + "',103)) ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region dash_empdetails
        public DataSet dash_empdetails(int empid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblEmployeeDetails where Employee_Id='" + empid + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region Client Login
        public DataSet Client_Login(string sUserName, string sPassword)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_ClientLogin where UserName ='" + sUserName + "'and Password='" + sPassword + "' ";//@username and Password=@password";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region dasboard_total
        #region dshboard
        public DataSet dashboard(int empid, string today)
        {
            DataSet ds = new DataSet();
            string sQry = "   select cast(LogIn_DateTime as time) as time from Attendance_tbl where  Employee_Id='" + empid + "' and cast(LogIn_DateTime as date)='" + today + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region getmonth
        public DataSet getmonth(string today)
        {
            DataSet ds = new DataSet();
            string sQry = "select top(1) month(convert(datetime,'" + today + "',103)) as month from tbl_LeaveForm";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region checkleave
        public DataSet checkleave(string today, string empcode)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_LeaveForm where Date='" + today + "' and Emp_code='" + empcode + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region getfutureleave
        public DataSet getfutureleave(string today, int month, string empcode)
        {
            DataSet ds = new DataSet();
            string sQry = "select Fromdate,Leave_Status from tbl_LeaveForm where  Date >='" + today + "' and Emp_code='" + empcode + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #endregion dashboard
        //  public DataSet dashnoard(string employeecode);
        //{
        //    DataSet ds= new DataSet();
        //        string dash="select * from Attendance_tbl where Emp_code='"+employeecode+"' ";
        //        ds = dbObj.InlineExecuteDataSet(dash);
        //        return ds;
        //}
        public DataSet login1(string LogIn_DateTime, int Employee_Id)
        {
            DataSet ds = new DataSet();
            string sQry = "  select * from Attendance_tbl  where convert(nvarchar,convert(datetime,login_DateTime,103),103) =convert(nvarchar,(convert(datetime,'" + LogIn_DateTime + "',103)),103)  and  Employee_Id='" + Employee_Id + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetEmployeee()
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select Employee_Id,Name from tblEmployeeDetails except select Employee_Id,Name from tblEmployeeDetails where Employee_Id='1'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #region login_det
        public DataSet bonuscalac(string empcode)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tblEmployeeDetails where Emp_code='" + empcode + "' ";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region leaveapplied today
        public DataSet lvapptoday(string sdate)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select count(*) as total from tbl_LeaveForm where Date='" + sdate + "' ";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region getempmsg
        public DataSet getempmsg(string today2)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select count(*) as total from Emp_suggestionAll where Date='" + today2 + "' ";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region MR
        public DataSet MR(string sdoj, string doj1, string empcode)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select SUM(MR) as TOT from tbl_SalaryPayable where Month between '" + sdoj + "' and '" + doj1 + "' and Employee_code='" + empcode + "'";

            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region chkjobtype
        public DataSet chkjobtype(string empcode)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tblEmployeeDetails where Emp_code='" + empcode + "' ";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region wrorkdays for bonus
        public DataSet workdays(string empcode)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from Attendance_tbl where Emp_code='" + empcode + "' ";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region Task
        public DataSet TaskPending_emp(string sEmployeeId)
        {
            DataSet ds = new DataSet();
            string getdoc = "select COUNT(*) as count from tbl_task1 where EmployeeID='" + sEmployeeId + "' and Status='Inprogress' or Status='Not Started'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        public DataSet TaskPending()
        {
            DataSet ds = new DataSet();
            string getdoc = "select COUNT(*) as count from tbl_task1 where Status='Inprogress' or Status='Not Started'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #region
        public DataSet gettaskststsus()
        {
            DataSet ds = new DataSet();
            string sQry = "select a.Task,e.Name,s.status from tblAssignment as a inner join tblEmployeeDetails as e on e.Employee_Id=a.EmployeeId inner join tblstatus as s on s.statusid=a.Taskprty";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region
        public DataSet TaskUpdate(string sEmployeeId)
        {
            DataSet ds = new DataSet();
            string getdoc = "  select A.Document,A.Comments,A.status,A.TaskAssignmentId,A.TaskDate,A.Task,B.Name,A.EmployeeId,a.taskenddate,a.taskprty from tblAssignment A,tblEmployeeDetails B where A.EmployeeId=B.Employee_Id and A.TaskAssignmentId='" + sEmployeeId + "'  ";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #endregion

        public DataSet checkHandelProject(string sDate)
        {
            DataSet ds = new DataSet();
            string sqry = "select TaskDate,Task,Name from tblAssignment A,tblEmployeeDetails B where Taskdate='" + sDate + "' and A.EmployeeId=B.Employee_Id and TaskAssignmentId not in (select AssignId from tbl_task1)";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region chkmnth alreast exist
        public DataSet checkmonth(string empcode, string month)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_SalaryPayable where Employee_code='" + empcode + "' and Month='" + Convert.ToDateTime(month) + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion

        public DataSet file_download12(string Feildid)
        {
            DataSet ds = new DataSet();
            string sqry = "  select Document from tbltaskstatus where taskid='" + Feildid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region insert tasktoday
        public int insert_task(string semp_name, string semp_id, string sdate, string stask, string sStatus, string sComments, string sAssignID, string taskper, string doc, int calc)
        {

            string datte = DateTime.Now.ToString("yyyy-MM-dd");

            int itask = 0;
            string sQry = "insert into tbl_task1(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document,points,markdate) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + stask + "','" + sStatus + "','" + sComments + "','" + sAssignID + "','" + taskper + "','" + doc + "','" + calc + "','" + datte + "')";
            // string sQry = "insert into tbl_task1(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + stask + "','" + sStatus + "','" + sComments + "','" + sAssignID + "','" + taskper + "','" + doc + "')";
            itask = dbObj.InlineExecuteNonQuery(sQry);

            string sqryyy = "insert into tbltaskstatus(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document,points,markdate) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + stask + "','" + sStatus + "','" + sComments + "','" + sAssignID + "','" + taskper + "','" + doc + "','" + calc + "','" + datte + "')";
            //  string sqryyy = "insert into tbltaskstatus(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + stask + "','" + sStatus + "','" + sComments + "','" + sAssignID + "','" + taskper + "','" + doc + "')";
            itask = dbObj.InlineExecuteNonQuery(sqryyy);
            //string sqryyy = "insert into tbltaskstatus(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document,points,markdate) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + stask + "','" + sStatus + "','" + sComments + "','" + sAssignID + "','" + taskper + "','" + doc + "','" + calc + "','" + datte + "')";
            //itask = dbObj.InlineExecuteNonQuery(sqryyy);
            return itask;
        }
        #endregion
        #region insert Assignment
        public int insert_Assignment(string sDate, string sTask, string sEmployeeID, int iStaus, string sDoc, string sEnd, string prty, string cmnt, int total, string ssdate)
        {

            int idoc = 0;
            DataSet ds = new DataSet();
            string sts = string.Empty;
            string datte = DateTime.Now.ToString("yyyy-MM-dd");
            string datte1 = DateTime.Now.ToString("dd/MM/yyyy");
            string sQry = "insert into tblAssignment(TaskDate,Task,EmployeeId,Comments,status,Document,taskenddate,taskprty,markdate,calculate,lastdate) values('" + sDate + "','" + sTask + "','" + sEmployeeID + "','" + cmnt + "','" + iStaus + "','" + sDoc + "','" + sEnd + "','" + prty + "','" + ssdate + "','0','" + datte1 + "')";
            idoc = dbObj.InlineExecuteNonQuery(sQry);


            string sqwry = "Select * from tblassignment  where task='" + sTask + "'";
            ds = dbObj.InlineExecuteDataSet(sqwry);

            string tassign = ds.Tables[0].Rows[0]["Taskassignmentid"].ToString();
            string emp = "Admin";

            if (iStaus == 0)
            {
                sts = "Open";
            }
            else if (iStaus == 1)
            {
                sts = "Completed";
            }
            else
            {
                sts = "Reopen";
            }

            string sAtask = "insert into tbltaskstatus(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document,points,markdate) values('" + emp + "','7','" + sDate + "','" + sTask + "','" + sts + "','" + cmnt + "','" + tassign + "','','" + sDoc + "','0','" + ssdate + "')";
            idoc = dbObj.InlineExecuteNonQuery(sAtask);

            return idoc;
        }
        #endregion
        public DataSet taskgridview(string sDate)
        {
            DataSet ds = new DataSet();
            // string gridtask = "select A.*,B.* from tbl_task1 A,tblAssignment B where A.AssignId=B.TaskAssignmentId and Date<='" + sDate + "' and (B.status='0' or b.status ='2') ";
            string gridtask = "select A.*,B.*,c.status from tbl_task1 A,tblAssignment B, tblstatus C where A.AssignId=B.TaskAssignmentId and b.Taskprty=c.statusid and Date<='" + sDate + "' and (B.status='0' or b.status ='2') ";
            ds = dbObj.InlineExecuteDataSet(gridtask);
            return ds;
        }


        public DataSet TaskGrid(string empid)
        {
            DataSet ds = new DataSet();
            // string getdoc = "select A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name from tblAssignment A,tblEmployeeDetails B where A.EmployeeId=B.Employee_Id order by A.TaskDate desc";
            //  string getdoc = "select case a.status when  0 then 'InComplete' else 'Completed' end as status1, A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name,a.Task,a.status,a.taskenddate from tblAssignment A,tblEmployeeDetails B where A.EmployeeId=B.Employee_Id order by A.TaskDate desc";
            if (empid == "All")
            {
                //string getdoc = "select case a.status when  0 then 'InComplete' else 'Completed' end as status1,A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name,a.Task,a.status,a.taskenddate,c.taskpercentage from tblAssignment A,tblEmployeeDetails B,tbltaskstatus  C where A.EmployeeId=B.Employee_Id and a.TaskAssignmentId=c.TaskID order by A.TaskDate desc";
                string getdoc = "select case a.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1,A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name,a.Task,a.status,a.taskenddate,a.taskpercentage from tblAssignment A,tblEmployeeDetails B where A.EmployeeId=B.Employee_Id and a.status<>'1'  order by A.TaskDate desc";

                ds = dbObj.InlineExecuteDataSet(getdoc);
            }
            else
            {
                // string getdoc = "select case a.status when  0 then 'InComplete' else 'Completed' end as status1,A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name,a.Task,a.status,a.taskenddate,c.taskpercentage from tblAssignment A,tblEmployeeDetails B,tbltaskstatus  C where A.EmployeeId=B.Employee_Id and a.TaskAssignmentId=c.TaskID and a.EmployeeId='"+empid+"' order by A.TaskDate desc";
                string getdoc = "select case a.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1,A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name,a.Task,a.status,a.taskenddate,a.taskpercentage from tblAssignment A,tblEmployeeDetails B where A.EmployeeId=B.Employee_Id and a.EmployeeId='" + empid + "' and a.status<>'1'  order by A.TaskDate desc";

                ds = dbObj.InlineExecuteDataSet(getdoc);
            }
            return ds;
        }



        #region insert salarypayable
        public int insert_salarypayable(string empcode, double lta, double mngallw, double bankloan, double salaryadv, double salary, double salarypayable, double esi, double pf, double mr, double conveyance, double specialallowance, double totaldeduc, string month, double bonus, double basic, double hra, double carlease, double grosssal, double proftax, double netpay)
        {

            int idoc = 0;
            string sQry = "insert into tbl_SalaryPayable(Employee_code,LTA,Managementallowance,totaldeductions,Bankloan,salaryadvance,Salary,Salary_Payable,ESI,PF,MR,Conveyance,SpecialAllowance,Month,Bonus,Basic,Hra,carlease,Gross_salary,Proftax,Netpay) values('" + empcode + "','" + lta + "','" + mngallw + "','" + bankloan + "','" + salaryadv + "','" + salary + "','" + salarypayable + "','" + esi + "','" + pf + "','" + mr + "','" + conveyance + "','" + specialallowance + "','" + totaldeduc + "','" + Convert.ToDateTime(month).ToString() + "','" + bonus + "','" + basic + "','" + hra + "','" + carlease + "','" + grosssal + "','" + proftax + "','" + netpay + "')";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region Update salarypayable
        public int Updatesalarypayable(double lta, double mngallw, double bankloan, double salaryadv, double salary, double salarypayable, double esi, double pf, double mr, double conveyance, double specialallowance, double totaldeduc, double bonus, double basic, double hra, double carlease, double grosssal, double proftax, double netpay, string empcode, string month)
        {
            int iSuccess = 0;
            string sQry = "  update tbl_SalaryPayable set   LTA='" + lta + "',Managementallowance='" + mngallw + "',Bankloan='" + bankloan + "',salaryadvance='" + salaryadv + "',Salary='" + salary + "',Salary_Payable='" + salarypayable + "',ESI='" + esi + "',PF='" + pf + "',MR='" + mr + "',Conveyance='" + conveyance + "',SpecialAllowance='" + specialallowance + "',totaldeductions='" + totaldeduc + "',Bonus='" + bonus + "',Basic='" + basic + "',Hra='" + hra + "',carlease='" + carlease + "',Gross_salary='" + grosssal + "',Proftax='" + proftax + "',Netpay='" + netpay + "' where Employee_code='" + empcode + "' and Month='" + Convert.ToDateTime(month).ToString() + "'   ";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        public DataSet logout1(string LogOut_DateTime, int Employee_Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Attendance_tbl  where convert(nvarchar,convert(datetime,LogOut_DateTime,103),103) =convert(nvarchar,(convert(datetime,'" + LogOut_DateTime + "',103)),103) and  Employee_Id='" + Employee_Id + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #region login_det
        public int login_det(int Employee_Id, string Employee_Name, string LogIn_DateTime, string empcode)
        {
            int i = 0;
            string cmd = "insert into Attendance_tbl(Employee_Id,Employee_Name,LogIn_DateTime,Emp_code) values('" + Employee_Id + "','" + Employee_Name + "','" + LogIn_DateTime + "','" + empcode + "')";
            i = dbObj.InlineExecuteNonQuery(cmd);
            return i;
        }
        #endregion
        #region logout_det
        public int logout_det(int Employee_Id, string LogOut_DateTime, string logindate)
        {
            int i = 0;
            string cmd = "update Attendance_tbl set LogOut_DateTime=convert(nvarchar,convert(datetime,'" + LogOut_DateTime + "',103)) where Employee_Id='" + Employee_Id + "' and convert(nvarchar,(convert(datetime,login_DateTime,103)),103)=convert(nvarchar,convert(datetime,'" + logindate + "',103),103)";
            i = dbObj.InlineExecuteNonQuery(cmd);
            return i;
        }
        #endregion
        public DataSet getsaldetails(string emp_code)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_SalaryPayable  where Employee_code='" + emp_code + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getLoginTime(int Employee_Id, string LogIn_DateTime, string LogOut_DateTime)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Attendance_tbl  where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,convert(datetime,'" + LogIn_DateTime + "',103),103) and Employee_Id='" + Employee_Id + "' and LogOut_DateTime=convert(nvarchar,convert(datetime,'" + LogOut_DateTime + "',103))";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getmessage(string Date)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_messages  where   Todate>=convert(datetime,'" + Date + "',103)";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #region admindash leavereq
        public DataSet getLeaves(string status)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_LeaveForm  where  Leave_Status='" + status + "'";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region getlogin
        public DataSet getlogintime()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Attendance_tbl  where convert(date,LogIn_DateTime)=CONVERT(date,getdate())";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        public DataSet getmessage1(string Date)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_messages  where   Todate>=convert(datetime,'" + Date + "',103)";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #region timeDuration
        public int timeDuration(string sTimeDur, int id, string date, string othours)
        {
            int i = 0;
            string cmd = "update Attendance_tbl set Time_Duration='" + sTimeDur + "' , overtimeHours='" + othours + "' where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,convert(datetime,'" + date + "',103),103) and Employee_Id='" + id + "'";

            i = dbObj.InlineExecuteNonQuery(cmd);
            return i;
        }
        public DataSet getempcode(int empid)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from Emp_logintbl where empid='" + empid + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }

        public DataSet gettodate()
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tbl_messages";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #region
        public DataSet getleaveall()
        {
            DataSet ds = new DataSet();
            string leave = "select * from tbl_LeaveForm";
            ds = dbObj.InlineExecuteDataSet(leave);
            return ds;
        }

        #endregion
        #endregion

        #region gridviewhrm
        public DataSet hrmgridview()
        {
            DataSet ds = new DataSet();
            string hrmview = "select e.*,j.Jobtype from tblEmployeeDetails as e inner join tbl_jobtype as j on e.JobType=j.jobtypeID ";
            ds = dbObj.InlineExecuteDataSet(hrmview);
            return ds;
        }
        #endregion
        #region empdetailsall
        public DataSet emp_details(string location)
        {
            DataSet ds = new DataSet();
            string empdetails = "select * from tblEmployeeDetails where location='"+location+"'";
            ds = dbObj.InlineExecuteDataSet(empdetails);
            return ds;
        }
        #endregion
        #region lvform
        public DataSet Leaveform()
        {
            DataSet ds = new DataSet();
            string lvall = "select * from tbl_LeaveForm";
            ds = dbObj.InlineExecuteDataSet(lvall);
            return ds;
        }
        #endregion
        #region attall
        public DataSet attall()
        {
            DataSet ds = new DataSet();
            string lvall = "select * from Attendance_tbl";
            ds = dbObj.InlineExecuteDataSet(lvall);
            return ds;
        }
        #endregion
        #region getindividualpay
        public DataSet getindividualpay(int eid)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tblEmployeeDetails where Employee_Id='" + eid + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region gridviewhrm_emp
        public DataSet gridviewhrm_emp(int eid)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tblEmployeeDetails where Employee_Id='" + eid + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion

        #region lvstatus
        public DataSet lvsatus(int eid, string fromdate, string today)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * tbl_LeaveForm where Emp_code='" + eid + "'and fromdate='" + fromdate + "'>='" + today + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region overtimne
        public DataSet getovertime(string sEmp_name, int iMonth)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select Hours(overtimeHours) from Attendance_tbl where Emp_code='" + sEmp_name + "', Month(LogIn_DateTime)='" + iMonth + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        //#region DaysAttended
        //public DataSet Leave_details(string sEmp_name, int iMonth, int iYear)
        //{
        //    DataSet ds = new DataSet();
        //    string sqry = "select COUNT(*) as Att_Days from Attendance_tbl where  Employee_Name='" + sEmp_name + "' and  Month(LogIn_DateTime)='" + iMonth + "' and year(LogIn_DateTime)='" + iYear + "'";
        //    ds = dbObj.InlineExecuteDataSet(sqry);
        //    return ds;
        //}
        //#endregion
        #region getproject
        public DataSet getproject()
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tbl_project";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion


        #region get logintime

        public DataSet login(int Employee_Id, string Activity_date)
        {
            DataSet ds = new DataSet();
            string sQry = " select * from Attendance where Employee_Id='" + Employee_Id + "' and Activity_date='" + Activity_date + "'";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;

        }
        #endregion

        #region delete grm grid
        public int deletehrm(string employeeid)
        {
            int iSucess = 0;
            string sQry = "delete from tblEmployeeDetails where Employee_Id='" + employeeid + "'";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        #endregion
        #region delete grm grid
        public int deleteempfrmproject(string employeeid)
        {
            int iSucess = 0;
            string sQry = "update  tbl_ProjectMaster set IsDelete='" + 1 + "' where Project_id='" + employeeid + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        #endregion
        #region delete docgrid
        public int deletedoc(string Feildid)
        {
            int iSucess = 0;
            string sQry = "delete from tbl_doc where Feildid='" + Feildid + "'";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        #endregion

        #region Search emp by iod
        public DataSet searchempid(string Employee_Id)
        {
            DataSet ds = new DataSet();
            string sqry = "SELECT * FROM tblEmployeeDetails WHERE Employee_Id = '" + Employee_Id + "'";

            ds = dbObj.InlineExecuteDataSet(sqry);

            return ds;
        }
        #endregion


        #region Search emp by name
        public DataSet searchempname(string Name)
        {
            DataSet ds = new DataSet();
            string sqry = "SELECT * FROM tblEmployeeDetails WHERE Name like'%" + Name + "%'";

            ds = dbObj.InlineExecuteDataSet(sqry);

            return ds;
        }
        #endregion
        #region Select  Max ID
        public DataSet SelectMaxId()
        {
            DataSet ds1 = new DataSet();
            string sQry = "select   max((Employee_Id)+1) as Employee_Id from tblEmployeeDetails";
            ds1 = dbObj.InlineExecuteDataSet(sQry);
            return ds1;
        }

        #endregion

        #region Bint service
        public DataSet Select_service()
        {
            DataSet ds1 = new DataSet();
            string sQry = "select ServiceId,ServiceName from tblService";
            ds1 = dbObj.InlineExecuteDataSet(sQry);
            return ds1;
        }

        #endregion

        #region reg_update
        public DataSet GetEmpDet(string Emp_code)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tblEmployeeDetails where  Employee_Id='" + Emp_code + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion

        #region bint Desigination
        public DataSet desigination1(int ServiceId)
        {
            DataSet ds = new DataSet();

            string sqr = "select DesiginationId,DesiginationName from tblDesigination where ServiceId='" + ServiceId + "'";
            ds = dbObj.InlineExecuteDataSet(sqr);
            return ds;
        }
        #endregion
        #region getBranches_ByID
        public DataSet getbranches(int branchid)
        {
            DataSet ds = new DataSet();

            string sqr = "select Branch,BranchID from tbl_branch where BranchID='" + branchid + "'";
            ds = dbObj.InlineExecuteDataSet(sqr);
            return ds;
        }
        #endregion
        #region getjobtype_ByID
        public DataSet getjobtype(int jobID)
        {
            DataSet ds = new DataSet();

            string sqr = "select Jobtype,jobtypeID from tbl_jobtype where jobtypeID='" + jobID + "'";
            ds = dbObj.InlineExecuteDataSet(sqr);
            return ds;
        }
        #endregion
        #region bint Branches
        public DataSet Branches()
        {
            DataSet ds = new DataSet();

            string sqr = "select * from tbl_branch ";
            ds = dbObj.InlineExecuteDataSet(sqr);
            return ds;
        }
        #endregion
        #region bint jobtype
        public DataSet jobtype()
        {
            DataSet ds = new DataSet();

            string sqr = "select * from tbl_jobtype ";
            ds = dbObj.InlineExecuteDataSet(sqr);
            return ds;
        }
        #endregion

        #region getfutureleave
        public DataSet getfutureleave(DateTime today, int month, string empcode)
        {
            DataSet ds = new DataSet();
            string date = Convert.ToDateTime(today).ToString("yyyy-MM-dd");
            string sQry = "select Fromdate,Leave_Status from tbl_LeaveForm where  Fromdate>=convert(nvarchar,'" + date + "',103) and  month(convert(datetime,Fromdate,103))>='" + month + "'and Emp_code='" + empcode + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region Fetch Records
        public int FetchRecords(string Name, string DOB, string DOJ, string Address, string Phno_No, string Email_Id, string Pssword, int Desigination, int Service, string Documents_Submitted, string Emp_code, int Branch, Double salary, int pfno, int esino, int jobtype, string contractperiod, double annualctc, int Status, string DOL)
        {
            int i = 0;
            string sQry = "insert into tblEmployeeDetails(Name,DOB,DOJ,Address,Phno_No,Email_Id,Pssword,Desigination,Service,Documents_Submitted,Emp_code,Branch,Salary,PF_NO,ESI_NO,JobType,ContractPeriod,AnnualCTC,Status,DOL)values('" + Name + "','" + DOB + "','" + DOJ + "','" + Address + "','" + Phno_No + "','" + Email_Id + "','" + Pssword + "','" + Desigination + "','" + Service + "','" + Documents_Submitted + "','" + Emp_code + "','" + Branch + "','" + salary + "','" + pfno + "','" + esino + "','" + jobtype + "','" + contractperiod + "','" + annualctc + "','" + Status + "','" + DOL + "')";
            i = dbObj.InlineExecuteNonQuery(sQry);
            return i;
        }
        public DataSet TaskPendingcomp()
        {
            DataSet ds = new DataSet();
            //  string getdoc = "select COUNT(*) as count from tbl_task1 where Status='Inprogress' or Status='Not Started'";
            // string getdoc = "select COUNT(*) as count from tblAssignment where Status=0";
                   string getdoc="select COUNT(*) as count from tbl_task1 where  Status='Completed'"; 
          //string getdoc = "select COUNT(*) as count from tblAssignment as a inner join tblEmployeeDetails as e on e.Employee_Id=a.EmployeeId inner join tblstatus as s on s.statusid=a.Taskprty where a.Status='1' ";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #endregion

        #region insertDetails2
        public int insertDetails2(string Employee_Name, string Password, int empid, string sUserName, string Emp_code, string serviceID)
        {
            int iSuccess = 0;
            string sQry = "insert into Emp_logintbl(Employee_Name,Password,empid,UserName,Emp_code,ServiceId) values('" + Employee_Name + "','" + Password + "','" + empid + "','" + sUserName + "','" + Emp_code + "','" + serviceID + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion

        #region update hrm
        public int hrm(int Employee_Id, string Name, string DOB, string DOJ, string Address, string Phno_No, string Email_Id, string Pssword, int Desigination, int Service, string Documents_Submitted, string Emp_code, int Branch, Double salary, int pfno, int esino, int jobtype, string contractperiod, double annualctc, int Status, string DOL)
        {
            int i;
            string hrmupdate = "update tblEmployeeDetails set Name='" + Name + "',DOB='" + DOB + "',DOJ='" + DOJ + "',Address='" + Address + "',Phno_No='" + Phno_No + "',Email_Id='" + Email_Id + "',Pssword='" + Pssword + "',Desigination='" + Desigination + "',Service='" + Service + "',Documents_Submitted='" + Documents_Submitted + "',JobType='" + jobtype + "',ContractPeriod='" + contractperiod + "', Status='" + Status + "', DOL='" + DOL + "' where Employee_Id='" + Employee_Id + "'";
            string login = "update Emp_logintbl set passeord='" + Pssword + "',Emp_code='" + Emp_code + "' where empid='"+Employee_Id+"'";
            i = dbObj.InlineExecuteNonQuery(hrmupdate);
            i = dbObj.InlineExecuteNonQuery(login);
            
            return i;

        }
        #endregion

        public DataSet voucherhid()
        {
            DataSet ds = new DataSet();
            string autoemp1 = "select MAX((Voucher_Id)+1) as voucherhid from tblVoucher1 ";
            ds = dbObj.InlineExecuteDataSet(autoemp1);
            return ds;
        }

        public DataSet GetVouDet(int Voucher_Id)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select * from tblVoucher1 where  Voucher_Id='" + Voucher_Id + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }

        #region voucher register

        public int voucher(string voucher_Date, string Description, string Amount)
        {
            int isucess = 0;
            string voucher = "insert into tblVoucher1 (Date,Description,Amount) values('" + voucher_Date + "','" + Description + "','" + Amount + "')";
            isucess = dbObj.InlineExecuteNonQuery(voucher);
            return isucess;
        }
        #endregion

        #region voucherupdate
        public int VoucHrUpdate(string voucherid1, string voucher_Date, string description, string amount)
        {
            int i;
            string vocUpdate = "update tblVoucher1 set Date='" + voucher_Date + "',Description='" + description + "',Amount='" + amount + "' where Voucher_Id='" + voucherid1 + "'";
            i = dbObj.InlineExecuteNonQuery(vocUpdate);
            return i;

        }

        #endregion

        #region vouchergird1

        public DataSet vouchergird1()
        {
            DataSet ds = new DataSet();
            string voucherhrm = "select Voucher_Id,Date,Description,Amount from tblVoucher1 ";
            ds = dbObj.InlineExecuteDataSet(voucherhrm);
            return ds;
        }
        #endregion



        public DataSet datesearch(string sfrom, string sto)
        {
            DataSet ds = new DataSet();
            string dtconvert = "select * from tblVoucher1 where Date between '" + sfrom + "' and '" + sto + "'";
            //string dtconvert = "select * from tblVoucher1 where convert (Date,date,103) between '" + sfrom + "' and '" + sto + "'";
            ds = dbObj.InlineExecuteDataSet(dtconvert);
            return ds;
        }

        #region Search byemp amount
        public DataSet searchamount(int Amount)
        {

            DataSet ds = new DataSet();
            string sqry = "SELECT * FROM tblVoucher1 WHERE Amount='" + Amount + "'";


            ds = dbObj.InlineExecuteDataSet(sqry);

            return ds;
        }
        #endregion

        public DataSet exportToexcel()
        {
            DataSet ds = new DataSet();
            string sqry = "  select Voucher_Id,Date,Description,Amount from tblVoucher1";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public int VouDel(string voucherid)
        {
            int i = 0;
            string delvoc = "delete from tblVoucher1 where Voucher_Id='" + voucherid + "'";
            i = dbObj.InlineExecuteNonQuery(delvoc);
            return i;
        }

        public DataSet GetAttendance(string sToday, string Employee_Id)
        {
            DataSet ds = new DataSet();
            string sqry = "  select * from Attendance_tbl  where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,(convert(datetime,'" + sToday + "',103)),103) and  Employee_Id='" + Employee_Id + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        public DataSet GetLateAttendance(string sToday)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from Attendance_tbl where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,(convert(datetime,'" + sToday + "',103)),103) and convert(time,login_DateTime,103)>'09:30:00'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Chart_Leaves(string Emp_Code, int iYear)
        {
            DataSet ds = new DataSet();
            string sqry = "select datediff(day,(convert(datetime,Date,103)),(convert(datetime,Fromdate,103)))as datediff, Emp_Name from tbl_LeaveForm where Emp_code='" + Emp_Code + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        // #region chart2
        // public DataSet Chart_employees(string Emp_Code, int month)
        // {
        //     DataSet ds = new DataSet();
        //                 //string sqry = " SELECT distinct(select SUM(Leavedays) FROM tbl_LeaveForm where Month(convert(datetime,Fromdate,103))='" + month + "' and  Emp_code='" + Emp_Code + "' )as LeaveTaken ,(select distinct Emp_Name from tbl_LeaveForm where Emp_code='" + Emp_Code + "')as Employees";
        //     //string sqry = "select  (select   count(*)  from tbl_LeaveForm where Month(convert(datetime,Date,103))='" + month + "')as LeaveTaken ,(select distinct Emp_Name from tbl_LeaveForm where Emp_code='" + Emp_Code + "')as Employees";
        //     ds = dbObj.InlineExecuteDataSet(sqry);
        //     return ds;
        // }
        //#endregion


        public DataSet latattendance(string sToday, string Employee_Id)
        {
            DataSet ds = new DataSet();
            string sqry = "SELECT *  FROM Attendance_tbl where CONVERT(VARCHAR(20),login_DateTime,108)>'09:30:00' and Employee_Id='" + Employee_Id + "' AND convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,(convert(datetime,'" + sToday + "',103)),103)";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet GetLateAttendance1(string sToday)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from Attendance_tbl where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,(convert(datetime,'" + sToday + "',103)),103) and CONVERT(VARCHAR(20),LogOut_DateTime,103)<'6:30:00 PM'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet lattattendance_soon(string sToday, string Employee_Id)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from Attendance_tbl where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,(convert(datetime,'" + sToday + "',103)),103) and CONVERT(time,LogOut_DateTime,103)<'18:30:00 PM' AND Employee_Id='" + Employee_Id + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region Insert Client
        public int insert_Client(string Client_Name, string Contact, string sUserName, string sPassword)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_ClientMaster(Client_Name,Contact_Number,UserName,Password) values('" + Client_Name + "','" + Contact + "','" + sUserName + "','" + sPassword + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion
        #region Update Client
        public int update_Client(string Client_Name, string Contact, string sUserName, string sPassword, int iclientid)
        {
            int iSuccess = 0;
            string sQry = "Update tbl_ClientMaster set Client_Name='" + Client_Name + "',Contact_Number='" + Contact + "',UserName='" + sUserName + "',Password='" + sPassword + "' where Client_Id='" + iclientid + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion
        #region Delete Client
        public int delete_Client(int iclientid)
        {
            int iSuccess = 0;
            string sQry = "delete from tbl_ClientMaster where Client_Id='" + iclientid + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion
        #region Insert ClientLogin
        public int insert_ClientLogin(int iClient_Id, string sUserName, string sPassword)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_ClientLogin(Client_Id,UserName,Password) values('" + iClient_Id + "','" + sUserName + "','" + sPassword + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion


        public int update_ClientLogin(int iClient_Id, string sUserName, string sPassword)
        {
            int iSuccess = 0;
            string sQry = "Update tbl_ClientLogin set UserName='" + sUserName + "',Password='" + sPassword + "' where Client_Id='" + iClient_Id + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        public DataSet GetClientName()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ClientMaster";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetClientName_Max()
        {
            DataSet ds = new DataSet();
            string sqry = "select max(Client_Id)as Client_Id from tbl_ClientMaster";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetProjectName(int iClient_Id)
        {
            DataSet ds = new DataSet();
            string sqry = "select distinct Project_Name, Client_Id from tbl_ProjectMaster where Client_Id='" + iClient_Id + "' and IsDelete='0'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetProjectName_Admin()
        {
            DataSet ds = new DataSet();
            string sqry = "select Project_Name from tbl_ProjectMaster";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Tracker(int reportid)
        {
            DataSet ds = new DataSet();
            string sqry = " select * from tbl_Emp_IssueReport as a inner join tbl_StatusType as b on a.Status=b.Status_Id  where Report_id='" + reportid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Tracker1(int issueid)
        {
            DataSet ds = new DataSet();
            string sqry = " select * from tbl_IssueTracker  as a inner join tbl_StatusType as b on a.Status=b.Status_Id  where Issue_ID='" + issueid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region Insert Project
        public int insert_Project(string sType, string sProject_Name, int iClient_id, string EmployeeName, string subid)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_ProjectMaster(Project_Type,Project_Name,Client_Id,Emp_Name,Subprojectid,IsDelete) values('" + sType + "','" + sProject_Name + "','" + iClient_id + "','" + EmployeeName + "','" + subid + "','0')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion
        #region
        public DataSet get_projectmem(string projectname)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ProjectMaster where Project_Name='" + projectname + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region
        public int insert_data(string projectname, string clientname)
        {
            int i = 0;
            string sqry = "insert into tbl_Subprojects (ProjectName,Clientname) values('" + projectname + "','" + clientname + "')";
            i = dbObj.InlineExecuteNonQuery(sqry);
            return i;
        }
        #endregion
        #region
        public DataSet get_id(string name)
        {
            DataSet ds = new DataSet();
            string sqry = "select SubprojectID from tbl_Subprojects where ProjectName='" + name + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region Insert Issue
        public int insert_Issue(string sIssueType, string sProject_Name, string sClientName, string sPageName, string doc, string sDescription, string sDate, string sStatus, int isdelete)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_IssueTracker(Issue_type,Project_Name,Client_Name,Page_Name,Doccument,Description,Date,Status,IsDelete) values('" + sIssueType + "','" + sProject_Name + "','" + sClientName + "','" + sPageName + "','" + doc + "','" + sDescription + "','" + sDate + "','" + sStatus + "','" + isdelete + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion
        #region update Issue
        public int update_Issues(string sIssueType, string sProject_Name, string sClientName, string sPageName, string doc, string sDescription, string sDate, string sStatus, int isdelete, int issueid)
        {
            int iSuccess = 0;
            string sQry = "update  tbl_IssueTracker set Issue_type='" + sIssueType + "',Project_Name='" + sProject_Name + "',Client_Name='" + sClientName + "',Page_Name='" + sPageName + "',Doccument='" + doc + "',Description='" + sDescription + "',Date='" + sDate + "',Status='" + sStatus + "',IsDelete='" + isdelete + "' where Issue_ID='" + issueid + "' ";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        #region update Issue_emp
        public int update_Issues_employee(string sIssueType, string sProject_Name, string sClientName, string sPageName, string doc, string sDescription, string sDate, string sStatus, string empname, int issueid)
        {
            int iSuccess = 0;
            string sQry = "update  tbl_IssueTracker set Issue_type='" + sIssueType + "',Project_Name='" + sProject_Name + "',Client_Name='" + sClientName + "',Page_Name='" + sPageName + "',Doccument='" + doc + "',Description='" + sDescription + "',Date='" + sDate + "',Status='" + sStatus + "',Emp_name='" + empname + "' where Issue_ID='" + issueid + "' ";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        #region emp_Issuereport
        public int insert_IssueReport(string sIssueType, string sProject_Name, string sClientName, string sPageName, string doc, string sDescription, string sDate, string sStatus, string employenmae, int issdelete, int issue)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_Emp_IssueReport(Issue_type,Project_Name,Client_Name,Page_Name,Doccument,Description,Date,Status,Emp_name,IsDelete,Issue_ID) values('" + sIssueType + "','" + sProject_Name + "','" + sClientName + "','" + sPageName + "','" + doc + "','" + sDescription + "','" + sDate + "','" + sStatus + "','" + employenmae + "', " + issdelete + "," + issue + ")";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        #region
        public DataSet check_clientname(string empname)
        {
            DataSet ds = new DataSet();
            String sqry = "Select * from tbl_ClientMaster where Client_Name='" + empname + "' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region
        public DataSet getststus_id(string status)
        {
            DataSet ds = new DataSet();
            string sqry = "select Status_Id from tbl_StatusType where Status_Type='" + status + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region get_issueid
        public DataSet get_issueid(int reportid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Issue_ID from tbl_Emp_IssueReport where Report_id='" + reportid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        #endregion
        public DataSet GetIssue_FilterbyType(string sIssueType, string clientname)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker where Issue_type='" + sIssueType + "' and Client_Name='" + clientname + "' and IsDelete='1'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_FilterbyType1(string sIssueType, string name)
        {
            DataSet ds = new DataSet();
            //  string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Issue_type='" + sIssueType + "'and IsDelete='1'";
            string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where a.Emp_Name='" + name + "' and  Issue_type='" + sIssueType + "' and b.IsDelete='1' order by Date desc";

            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_FilterbyType_Client(string sIssueType, string sClient_Name)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker where Issue_type='" + sIssueType + "' and Client_Name='" + sClient_Name + "' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Opened()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Status_Type='Opened' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Process()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Status_Type='Processing' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Pending()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Status_Type='Pending' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Closed()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Status_Type='Closed' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_Completed()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Status_Type='Completed' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region getissue_for empprojects
        public DataSet Get_Issuefromclient_opened(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where a.Emp_Name='" + employeename + "' and b.IsDelete='1' and Status_Type='Opened'  order by Date desc";

            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Get_Issuefromclient_Processing(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where a.Emp_Name='" + employeename + "' and b.IsDelete='1' and Status_Type='Processing'  order by Date desc";

            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Get_Issuefromclient_Pending(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where a.Emp_Name='" + employeename + "' and b.IsDelete='1' and Status_Type='Pending'  order by Date desc";

            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Get_Issuefromclient_Completed(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where a.Emp_Name='" + employeename + "' and b.IsDelete='1' and Status_Type='Completed'  order by Date desc";

            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Get_Issuefromclient_Closed(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where a.Emp_Name='" + employeename + "' and b.IsDelete='0' and Status_Type='Closed'  order by Date desc";

            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region get_issuereport
        public DataSet get_issuereport(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ProjectMaster as a inner join tbl_Emp_IssueReport as b on a.Project_Name=b.Project_Name where a.Emp_Name='" + employeename + "' order by b.Date desc";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region get_empissuereport
        public DataSet get_empissuereport(string issueid)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_Emp_IssueReport as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Issue_ID='" + issueid + "'  order by Date desc";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion

        public DataSet empissuereport()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_Emp_IssueReport as a inner join tbl_StatusType as b on a.Status=b.Status_Id order by Date desc";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        //#region get_issuereport
        //public DataSet get_issuereport(string employeename)
        //{
        //    DataSet ds = new DataSet();
        //    string sqry = "select * from tbl_ProjectMaster as a inner join tbl_Emp_IssueReport as b on a.Project_Name=b.Project_Name where a.Emp_Name='" + employeename + "' order by b.Date desc";
        //    ds = dbObj.InlineExecuteDataSet(sqry);
        //    return ds;
        //}
        //#endregion
        #region
        #region
        public DataSet get_issuereport(int issueid)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_Emp_IssueReport where Issue_Id='" + issueid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        public DataSet get_employeenmae(int employeeid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Employee_Name from Emp_logintbl where empid='" + employeeid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;

        }
        public DataSet GetEmpID(int empid)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tblEmployeeDetails where Employee_Id='" + empid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Get_Status(string statusid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Status_Type from tbl_StatusType where Status_Id='" + statusid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet GetStatus()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_StatusType where Status_Type in ('Opened','Closed')";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetStatus_foremp()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_StatusType where Status_Type in ('Processing','Pending','Completed')";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetIssue_FilterClient(string sClient_Name)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker where Client_Name='" + sClient_Name + "' and IsDelete='1'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetProjectName(string sProjectName)
        {
            DataSet ds = new DataSet();
            string sqry = "select Client_Id from tbl_ProjectMaster where Project_Name='" + sProjectName + "' ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetProjectName_all()
        {
            DataSet ds = new DataSet();
            string sqry = "select  Project_Name from tbl_ProjectMaster ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet GetClientName_Id(int iClientId)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ClientMaster where Client_Id='" + iClientId + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region Insert Leave Request
        public int insert_leave(string sEmp_code, string sEmp_name, string sDate, string sFromDate,string stodate, string sReason, string sStatus,string sType)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_LeaveForm(Emp_code, Emp_Name, Date, FromDate,ToDate, Leave_Reason, Leave_Status,Leave_Type) values('" + sEmp_code + "','" + sEmp_name + "','" + sDate + "','" + sFromDate + "','" + sReason + "','" + sStatus + "','" + stodate + "','" + sType + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        #endregion
        public DataSet Get_LeaveStatus(string sEmp_code)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_LeaveForm where Emp_code='" + sEmp_code + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region taskassigndate
        public DataSet taskassigndate(string sEmployeeId, string sdate)
        {
            DataSet ds = new DataSet();
            string getdoc = " select A.Comments,A.TaskAssignmentId,a.TaskDate,A.Task,A.EmployeeId,B.Name,A.Document from tblAssignment A,tblEmployeeDetails B where a.EmployeeId=b.Employee_Id and A.EmployeeId='" + sEmployeeId + "' and a.TaskDate='" + sdate + "' order by TaskAssignmentId desc";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #endregion
        public int UpdateAssignemntStaus(string sEmplyeeId, string sTaskDate, string sTask, string sComments, int sStatus, string sEmpAssignId, string sDoc, string sEnd, string prty, int ttoal)
        {
            int idoc = 0;
            int iSuccess = 0;
            string sts = string.Empty;
            string datte = DateTime.Now.ToString("yyyy-MM-dd");
            string datte1 = DateTime.Now.ToString("dd/MM/yyyy");

            string sQry = "  update tblAssignment set EmployeeId='" + sEmplyeeId + "',TaskDate='" + sTaskDate + "',Task='" + sTask + "',Comments='" + sComments + "',status='" + sStatus + "',Document='" + sDoc + "',taskenddate='" + sEnd + "',taskprty='" + prty + "',calculate='" + ttoal + "',markdate='" + datte + "',lastdate='" + datte1 + "' where TaskAssignmentId='" + sEmpAssignId + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            if (sStatus == 0)
            {
                sts = "Open";
            }
            else if (sStatus == 1)
            {
                sts = "Completed";
            }
            else
            {
                sts = "Reopen";
            }

            string task1 = "update tbl_task1 set points='" + ttoal + "',markdate='" + datte + "' where assignid='" + sEmpAssignId + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(task1);

            DateTime dat = DateTime.Now;
            string curntdate = dat.ToString("MM/dd/yyyy");


            string emp = "Admin";
            string sAtask = "insert into tbltaskstatus(Emloyeename,EmployeeID,date,Todaystask,Status,Comments,AssignId,taskpercentage,document,points,markdate) values('" + emp + "','7','" + curntdate + "','" + sTask + "','" + sts + "','" + sComments + "','" + sEmpAssignId + "','','" + sDoc + "','" + ttoal + "','" + datte + "')";
            idoc = dbObj.InlineExecuteNonQuery(sAtask);

            return iSuccess;
        }
        public int UpdateAssignemntStausnew(string sEmplyeeId, string sTaskDate, string sTask, string sComments, int sStatus, string sEmpAssignId, string sDoc, string sEnd, string prty, int ttoal)
        {
            int idoc = 0;
            int iSuccess = 0;
            string sts = string.Empty;
            string datte = DateTime.Now.ToString("yyyy-MM-dd");
            string datte1 = DateTime.Now.ToString("dd/MM/yyyy");

            string sQry = "  update tblAssignment set EmployeeId='" + sEmplyeeId + "',TaskDate='" + sTaskDate + "',Task='" + sTask + "',Comments='" + sComments + "',status='" + sStatus + "',Document='" + sDoc + "',taskenddate='" + sEnd + "',taskprty='" + prty + "',lastdate='" + datte1 + "' where TaskAssignmentId='" + sEmpAssignId + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            if (sStatus == 0)
            {
                sts = "Open";
            }
            else if (sStatus == 1)
            {
                sts = "Completed";
            }
            else
            {
                sts = "Reopen";
            }

            return iSuccess;
        }


        public DataSet file_download1(string Feildid)
        {
            DataSet ds = new DataSet();
            string sqry = "  select Document from tblAssignment where TaskAssignmentId='" + Feildid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region updateAssignmentCmts
        public int updateAssignmentCmts(string sComts, string sAssignId)
        {

            int itask = 0;
            string sQry = "update tblAssignment set Comments='" + sComts + "' where TaskAssignmentId='" + sAssignId + "'";
            itask = dbObj.InlineExecuteNonQuery(sQry);
            return itask;
        }
        #endregion
        #region UpdateToday task
        public int UpdateTodaytask(string sStatus, string sComts, string sAssignId)
        {

            int itask = 0;
            string sQry = "update tbl_task1 set Status='" + sStatus + "',Comments='" + sComts + "' where AssignId='" + sAssignId + "'";
            itask = dbObj.InlineExecuteNonQuery(sQry);
            return itask;
        }
        #endregion
        #region taskassigndate1
        public DataSet taskassigndate1(string sAssignID)
        {
            DataSet ds = new DataSet();
            string getdoc = " select TaskAssignmentId,Document from tblAssignment where TaskAssignmentId='" + sAssignID + "'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #endregion
        public DataSet CheckFileisther(string sAssignId)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_task1 where AssignId='" + sAssignId + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet Get_LeaveStatus_Emp(string sEmp_code, string Date)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_LeaveForm where Emp_code='" + sEmp_code + "' and Date='" + Date + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        public DataSet Get_LeaveStatus_admin(string sDate)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_LeaveForm where Date ='" + sDate + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        public DataSet Get_Leave()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_LeaveForm";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #region
        public DataSet get

            (int eid)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from Emp_suggestionAll where ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion

        public DataSet Get_empleave(string Emp_code)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_LeaveForm where Emp_code='" + Emp_code + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        #endregion
        public DataSet TaskGrid_emp(int eid)
        {
            DataSet ds = new DataSet();
            //  string getdoc = "  select * from tblAssignment where EmployeeId ='"+eid+"' ";
            //  string getdoc = "select case ai.status when  0 then 'InComplete' else 'Completed' end as status1, ai.*,emp.Name from tblAssignment as ai inner join tblEmployeeDetails as emp on emp.Employee_Id=ai.EmployeeId where ai.EmployeeId='" + eid + "'";
            string getdoc = "select case ai.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, ai.*,emp.Name,sat.status as satu from tblAssignment as ai inner join tblEmployeeDetails as emp on emp.Employee_Id=ai.EmployeeId inner join tblstatus as sat on sat.statusid=ai.Taskprty where ai.EmployeeId='" + eid + "' and ai.status='0'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        public DataSet TaskGrid_emp_today(int eid, string sToday)
        {
            DataSet ds = new DataSet();
            //string getdoc = "select * from tblAssignment where EmployeeId ='"+eid+"' and TaskDate='" + sToday + "'";
            string getdoc = "select case ai.status when  0 then 'Open' when 1 then 'Completed' else 'Reopen' end as status1, ai.*,emp.Name,sat.status as satu from tblAssignment as ai inner join tblEmployeeDetails as emp on emp.Employee_Id=ai.EmployeeId inner join tblstatus as sat on sat.statusid=ai.Taskprty where EmployeeId ='" + eid + "' and TaskDate='" + sToday + "' and ai.status='0'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #region TaskGridbyName
        public DataSet TaskGridbyName(string sName)
        {
            DataSet ds = new DataSet();
            string getdoc = "  select A.TaskAssignmentId,A.EmployeeId,A.TaskDate,B.Name from tblAssignment A,tblEmployeeDetails B where A.EmployeeId=B.Employee_Id and B.Name='" + sName + "'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #endregion


        public int leave_status(string sStatus, string sEmp_code)
        {
            int iSuccess = 0;
            string sQry = "update  tbl_LeaveForm set Leave_Status='" + sStatus + "'where Emp_code='" + sEmp_code + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        //#region gridviewtask
        //public DataSet taskgridview()
        //{
        //    DataSet ds = new DataSet();
        //    string gridtask = "select * from tbl_task ";
        //    ds = dbObj.InlineExecuteDataSet(gridtask);
        //    return ds;
        //}
        //#endregion

        #region insert Empsuggestion
        public int insert_Sug(string semp_name, string semp_id, string sdate, string sproject, string sempsug)
        {

            int isug = 0;
            string sQry = "insert into Emp_suggestion(Emloyeename,EmployeeID,date,Project,EmployeeSuggestion) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + sproject + "','" + sempsug + "')";
            isug = dbObj.InlineExecuteNonQuery(sQry);
            return isug;
        }
        #endregion
        #region insert Empsuggestion
        public int insert_Sug1(string semp_name, string semp_id, string sdate, string sempsug)
        {

            int isug = 0;
            string sQry = "insert into Emp_suggestionAll(Emloyeename,EmployeeID,date,Message) values('" + semp_name + "','" + semp_id + "','" + sdate + "','" + sempsug + "')";
            isug = dbObj.InlineExecuteNonQuery(sQry);
            return isug;
        }
        #endregion
        #region insert Empproject
        public int insert_Empproject(string emp_name, string Projects)
        {

            int isug = 0;
            string sQry = "insert into tbl_empprojects(Employeename,Projects) values('" + emp_name + "','" + Projects + "')";
            isug = dbObj.InlineExecuteNonQuery(sQry);
            return isug;
        }
        #endregion
        #region gridviewsug
        public DataSet Suggridview()
        {
            DataSet ds = new DataSet();
            string Suggrid = "select * from Emp_suggestion ";
            ds = dbObj.InlineExecuteDataSet(Suggrid);
            return ds;
        }
        #endregion
        #region gridviewsug
        public DataSet salgrid()
        {
            DataSet ds = new DataSet();
            string salgrid1 = "select * from tbl_SalaryPayable ";
            ds = dbObj.InlineExecuteDataSet(salgrid1);
            return ds;
        }
        #endregion
        #region insert Doc
        public int insert_Doc(string sdate, string sfilename, string sdescription, string sfilepath)
        {

            int idoc = 0;
            string sQry = "insert into tbl_doc(Date,Filename,Description,Filepath) values('" + sdate + "','" + sfilename + "','" + sdescription + "','" + sfilepath + "')";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region
        public DataSet getcolors()
        {
            DataSet ds = new DataSet();
            string colors = "select * from tbl_colors ";
            ds = dbObj.InlineExecuteDataSet(colors);
            return ds;

        }

        #endregion
        #region
        public DataSet getuserpass(int empid)
        {
            DataSet ds = new DataSet();
            string pass = "select * from Emp_logintbl where empid='" + empid + "'";
            ds = dbObj.InlineExecuteDataSet(pass);
            return ds;

        }

        #endregion
        #region IChange colors
        public int insert_colors(string Menucolor, string Backgroundcolor)
        {

            int idoc = 0;
            string sQry = "insert into tbl_colors(Menucolor,backgroundcolor) values('#" + Menucolor + "','#" + Backgroundcolor + "')";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region setuser
        public int update_setuser(string username, string password, int empid)
        {

            int idoc = 0;
            string sQry = "update Emp_logintbl set UserName='" + username + "',Password='" + password + "' where empid='" + empid + "'";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region UChange colors
        public int Update_colors(string Menucolor, string Backgroundcolor)
        {

            int idoc = 0;
            string sQry = "update tbl_colors set Menucolor='#" + Menucolor + "', backgroundcolor='#" + Backgroundcolor + "'";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region insert Logo
        public int insert_Logo(string filename, string contenttype, string data)
        {

            int idoc = 0;
            string sQry = "insert into tbl_logo(FileName,ContentType,Data) values('" + filename + "','" + contenttype + "','" + data + "')";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion

        #region insert Company profile
        public int insert_CompanyProfile(string companyname, string address, string admin, string contact)
        {

            int idoc = 0;
            string sQry = "insert into tbl_compprofile(CompanyName,Address,Admin,ContactNo) values('" + companyname + "','" + address + "','" + admin + "','" + contact + "')";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region update Company profile
        public int update_CompanyProfile(string companyname, string address, string admin, string contact)
        {

            int idoc = 0;
            string sQry = "update tbl_compprofile set CompanyName='" + companyname + "',Address='" + address + "',Admin='" + admin + "',ContactNo='" + contact + "'";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region Update Logo
        public int Update_Logo(string filename, string contenttype, string data, string id)
        {

            int idoc = 0;
            string sQry = "update tbl_logo set  FileName='" + filename + "',ContentType='" + contenttype + "',Data='" + data + "' where Id='" + id + "' ";
            idoc = dbObj.InlineExecuteNonQuery(sQry);
            return idoc;
        }
        #endregion
        #region
        public DataSet getimage()
        {
            DataSet ds = new DataSet();
            string getimg = "select * from tbl_logo ";
            ds = dbObj.InlineExecuteDataSet(getimg);
            return ds;

        }
        #endregion
        #region docgridview
        public DataSet gridviewdoc()
        {
            DataSet ds = new DataSet();
            string griddoc = "select * from tbl_doc ";
            ds = dbObj.InlineExecuteDataSet(griddoc);
            return ds;
        }
        #endregion
        #region attendance grid
        public DataSet attendence(string sToday)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from Attendance_tbl where convert(nvarchar,convert(datetime,login_DateTime,103),103)=convert(nvarchar,(convert(datetime,'" + sToday + "',103)),103)";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region CheckEmp_code
        public DataSet CheckEmp_code(string Emp_code)
        {
            DataSet ds = new DataSet();
            string cmd = "select * from tblEmployeeDetails where Emp_code='" + Emp_code + "'";
            ds = dbObj.InlineExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        #region Check_Clientname
        public DataSet Check_Clientname(string Client_Name)
        {
            DataSet ds = new DataSet();
            string cmd = "select Client_Name from tbl_ClientMaster where Client_Name='" + Client_Name + "'";
            ds = dbObj.InlineExecuteDataSet(cmd);
            return ds;
        }
        #endregion

        public DataSet empissue_download2(string reportid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Doccument from tbl_Emp_IssueReport where Report_id='" + reportid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        public DataSet file_download2(string reportid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Doccument from tbl_IssueTracker where Issue_Id='" + reportid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet file_downloadissue(string issueid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Doccument from tbl_IssueTracker  where Issue_Id='" + issueid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet file_download(string Feildid)
        {
            DataSet ds = new DataSet();
            string sqry = "select FilePath from tbl_doc where Feildid='" + Feildid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        public DataSet getisuue_issuetracker(int issueid)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker where Issue_Id='" + issueid + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        public int insert_clientDetails(string Date, string Companyname, string Primarycontact, string Secondarycontact, string Appointmentdate, string Appointmenttime, string clientcontact, string clientmailid, string Address, string Landmark, string References)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_clientdetails(Date ,CompanyName ,PrimaryContact ,SecondaryContact ,AppointmentDate,ClientContactNumber ,ClientMailid  ,Address  ,Landmark ,Reference,Appointmenttime) values('" + Date + "','" + Companyname + "','" + Primarycontact + "','" + Secondarycontact + "','" + Appointmentdate + "','" + Appointmenttime + "','" + clientcontact + "','" + clientmailid + "','" + Address + "','" + Landmark + "','" + References + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
            throw new NotImplementedException();
        }
        #region mesasge
        public int insert_message(string Date, string Message, string todate)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_messages (Date,Message,Todate) values('" + Date + "','" + Message + "', convert(datetime,'" + Date + "',103))";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion
        #region durationbydate
        public DataSet getdurationbydate(string fromDate, string Todate)
        {
            DataSet ds = new DataSet();
            string getbrld = " select * from Attendance_tbl where cast(LogIn_DateTime as DATE) between '" + fromDate + "' and '" + Todate + "' ";
            ds = dbObj.InlineExecuteDataSet(getbrld);
            return ds;
        }
        #endregion
        #region workdaysbonus
        public DataSet workdaysbonus(string sdoj, string doj1, string empcode)
        {
            DataSet ds = new DataSet();
            string getbrld = "select COUNT(*) as col from Attendance_tbl where cast(LogIn_DateTime as DATE) between '" + sdoj + "' and '" + doj1 + "' and Emp_code='" + empcode + "'";
            ds = dbObj.InlineExecuteDataSet(getbrld);
            return ds;
        }
        #endregion
        #region getduration
        public DataSet getdurationdetails()
        {
            DataSet ds = new DataSet();
            string getbrld = "select * from Attendance_tbl ";
            ds = dbObj.InlineExecuteDataSet(getbrld);
            return ds;
        }
        #endregion
        #region getbirthday
        public DataSet getbirthday()
        {
            DataSet ds = new DataSet();
            string getbrld = "select * from  tblEmployeeDetails";
            ds = dbObj.InlineExecuteDataSet(getbrld);
            return ds;
        }
        #endregion
        #region totalleave
        public DataSet totalleavedays(string fromDate, string Todate)
        {
            DataSet ds = new DataSet();
            string getbrld = " select * from Attendance_tbl where cast(LogIn_DateTime as DATE) between '" + fromDate + "' and '" + Todate + "'   ";
            ds = dbObj.InlineExecuteDataSet(getbrld);
            return ds;
        }
        #endregion totalleave
        #region totalleavedash
        public DataSet totalleavedaysdash(string fromDate, string Todate, string empcode)
        {
            DataSet ds = new DataSet();
            string getbrld = " select * from Attendance_tbl where cast(LogIn_DateTime as DATE) between '" + fromDate + "' and '" + Todate + "'   and Emp_code='" + empcode + "'";
            ds = dbObj.InlineExecuteDataSet(getbrld);
            return ds;
        }
        #endregion totalleave
        #region getsearchcount
        public int getsearchcount(string fromDate, string Todate)
        {
            DataSet ds = new DataSet();
            string get = " SELECT DATEDIFF(day, cast('" + fromDate + "' as DATE), cast('" + Todate + "' as DATE))";
            int i = (int)dbObj.InlineExecuteScalar(get);

            return i;
        }
        #endregion totalleavedash1
        #region getsearchcount
        public int getsearchcountdash1(string fromDate, string Todate, string empcode)
        {
            DataSet ds = new DataSet();
            string get = " SELECT DATEDIFF(day, cast('" + fromDate + "' as DATE), cast('" + Todate + "' as DATE))";
            int i = (int)dbObj.InlineExecuteScalar(get);

            return i;
        }
        #endregion totalleave
        #region clientgrid
        public DataSet Clientt_grid()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_clientdetails ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region Msggrid
        public DataSet Msg_grid()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_messages ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region get individual employee details
        public DataSet Empdetails_grid(string empcode)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblEmployeeDetails where Employee_Id='" + empcode + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
        #region holygrid
        public DataSet Hol_grid()
        {
            DataSet ds = new DataSet();
            string sqry = " select * from tbl_Holiday ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region Get_cld
        public DataSet getcldetails(string ClientId)
        {
            DataSet ds = new DataSet();
            string getCld = "select * from tbl_clientdetails where  ClientId='" + ClientId + "'";
            ds = dbObj.InlineExecuteDataSet(getCld);
            return ds;
        }
        #endregion
        #region Get_msg
        public DataSet getmsgdetails(string msgid)
        {
            DataSet ds = new DataSet();
            string getCld = "select * from tbl_messages where  MsgId='" + msgid + "'";
            ds = dbObj.InlineExecuteDataSet(getCld);
            return ds;
        }


        #endregion
        #region Get_empetails
        public DataSet getempdetails(string emplopyeeid)
        {
            DataSet ds = new DataSet();
            string getCld = "select * from tblEmployeeDetails where  Employee_Id='" + emplopyeeid + "'";
            ds = dbObj.InlineExecuteDataSet(getCld);
            return ds;
        }

        #endregion
        #region Get_saldetails
        public DataSet Get_saldetails(string emplopyeeid)
        {
            DataSet ds = new DataSet();
            string getCld = "select * from tblEmployeeDetails where  Employee_Id='" + emplopyeeid + "'";
            ds = dbObj.InlineExecuteDataSet(getCld);
            return ds;
        }

        #endregion

        #region update Cld
        public int cld_update(string Date, string Companyname, string Primarycontact, string Secondarycontact, string Appointmentdate, string clientcontact, string clientmailid, string Address, string Landmark, string References, string clientid)
        {
            int i;
            string cldupdate = "update tbl_clientdetails set  Date='" + Date + "',CompanyName='" + Companyname + "',PrimaryContact='" + Primarycontact + "',SecondaryContact='" + Secondarycontact + "',AppointmentDate='" + Appointmentdate + "',ClientContactNumber='" + clientcontact + "',ClientMailid='" + clientmailid + "',Address='" + Address + "',Landmark='" + Landmark + "',Reference='" + References + "' where ClientId='" + clientid + "'";
            i = dbObj.InlineExecuteNonQuery(cldupdate);
            return i;

        }
        #endregion
        #region update Msg
        public int Msg_update(string Date, string todate, string Message, string msgid)
        {
            int i;
            string msgupdate = "update tbl_messages set  Date='" + Date + "',Todate='" + Convert.ToDateTime(todate).ToString("yyyy-MM-dd") + "',Message='" + Message + "' where MsgId='" + msgid + "'";
            i = dbObj.InlineExecuteNonQuery(msgupdate);
            return i;

        }
        #endregion
        #region delete cldgrid
        public int deletecl(string clientid)
        {
            int iSucess = 0;
            string cld = "delete from tbl_clientdetails where ClientId='" + clientid + "'";
            iSucess = dbObj.InlineExecuteNonQuery(cld);
            return iSucess;
        }
        #endregion
        #region delete msggrid
        public int deleteMsg(string Msgid)
        {
            int iSucess = 0;
            string cld = "delete from tbl_messages where MsgId='" + Msgid + "'";
            iSucess = dbObj.InlineExecuteNonQuery(cld);
            return iSucess;
        }
        #endregion
        #region Get_docc
        public DataSet getdocc(string Fieldid)
        {
            DataSet ds = new DataSet();
            string getdoc = "select * from tbl_doc where  Feildid='" + Fieldid + "'";
            ds = dbObj.InlineExecuteDataSet(getdoc);
            return ds;
        }
        #endregion
        #region update doc
        public int doc_update(string Date, string Filename, string Description, string Filepath, string Fieldid)
        {
            int i;
            string cldupdate = "update tbl_doc set Date='" + Date + "',Filename='" + Filename + "',Description='" + Description + "',Filepath='" + Filepath + "' where Feildid='" + Fieldid + "'";
            i = dbObj.InlineExecuteNonQuery(cldupdate);
            return i;

        }
        #endregion
        #region DaysAttended
        public DataSet Leave_details(string sEmp_name, int iMonth, int iYear)
        {
            DataSet ds = new DataSet();
            string sqry = "select COUNT(*) as Att_Days from Attendance_tbl where  Employee_Name='" + sEmp_name + "' and  Month(LogIn_DateTime)='" + iMonth + "' and year(LogIn_DateTime)='" + iYear + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region emp_name
        public DataSet emp_name()
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select Name from tblEmployeeDetails ";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region DaysinMonth
        public DataSet DaysinMonth()
        {
            DataSet ds = new DataSet();
            string hrmgrid = "Select day(dateadd(mm,DateDiff(mm, -1, getdate()),0) -1)";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }
        #endregion
        #region Leave_Applied
        public DataSet Leave_Applied(string sEmp_name, int iMonth, int iYear, int iType)
        {
            DataSet ds = new DataSet();
            string sqry = "  select COUNT(*) as leave from tbl_LeaveForm where Emp_Name='" + sEmp_name + "' and  month(convert (datetime,Fromdate,103))='" + iMonth + "' and year(convert (datetime,Fromdate,103))='" + iYear + "' and Leave_Type='" + iType + "' and Leave_Status='Approved'";

            //string sqry = "select COUNT(*) as leave from tbl_LeaveForm where Emp_Name='" + sEmp_name + "' and  Day(Fromdate)='" + iMonth + "' and year(Fromdate)='" + iYear + "' and Leave_Type='" + iType + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region Leave_Chart
        public DataSet Leave_chart(int iMonth, int iYear)
        {
            DataSet ds = new DataSet();
            string sqry = "select COUNT(*) as leave from tbl_LeaveForm where  Day(Fromdate)='" + iMonth + "' and year(Fromdate)='" + iYear + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region GetOver Teime
        public DataSet GetOverTeime(string sEmp_name, int iMonth)
        {
            DataSet ds = new DataSet();
            string sqry = "  select sum(CONVERT(int, LEFT(overtimeHours,2))) as total from Attendance_tbl where Employee_Name='" + sEmp_name + "' and Month(LogIn_DateTime)='" + iMonth + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region insert_SalaryPayable
        public int insert_SalaryPayable(int iEmp_id, string sEmp_Name, float fSalary, int iMonth, int iYear, float fSalary_payable)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_SalaryPayable(Employee_Id ,Employee_Name ,Salary ,Month ,Year,Salary_Payable) values('" + iEmp_id + "','" + sEmp_Name + "','" + fSalary + "','" + iMonth + "','" + iYear + "','" + fSalary_payable + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
            throw new NotImplementedException();
        }
        #endregion
        #region individual_leavegrid
        public DataSet individual_leavegrid(int employeeid)
        {
            DataSet leave = new DataSet();
            string sqry = "select * from tbl_LeaveForm where Emp_code='" + employeeid + "'";
            leave = dbObj.InlineExecuteDataSet(sqry);
            return leave;
        }
        #endregion
        #region getrmpcode
        public DataSet get_empcode(int employeeid)
        {
            DataSet leave = new DataSet();
            string sqry = "select Emp_code from tblEmployeeDetails where Employee_Id='" + employeeid + "'";
            leave = dbObj.InlineExecuteDataSet(sqry);
            return leave;
        }
        #endregion
        #region get_clientName
        public DataSet get_clientName(int client_id)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ClientMaster where Client_Id='" + client_id + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region get_employeeName
        public DataSet get_employeeName()
        {
            DataSet ds = new DataSet();
            string sqry = "select Name,Employee_Id from tblEmployeeDetails ";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region getproject_ID
        public DataSet getproject_ID(string Project_name)
        {
            DataSet ds = new DataSet();
            string sqry = "Select Project_id from tbl_ProjectMaster where Project_Name='" + Project_name + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #endregion
        #region
        public DataSet get_projects(string employeename)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ProjectMaster where Emp_Name='" + employeename + "' and IsDelete='0'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region
        public DataSet get_allprojects()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ProjectMaster where IsDelete='0'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region
        public int delete_record(string subid)
        {
            int delete = 0;
            string sqry = "delete  from tbl_ProjectMaster where Subprojectid='" + subid + "'";
            delete = dbObj.InlineExecuteNonQuery(sqry);
            return delete;
        }
        #endregion
        #region get_empname
        public DataSet get_empname(int empid)
        {
            DataSet ds = new DataSet();
            string sqry = "select Employee_Name from Emp_logintbl where empid='" + empid + "' and IsDelete='0'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region getissues
        public DataSet getdetails()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueType";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region getstatus
        public DataSet getstatus()
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tblstatus";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }
        #endregion
        #region
        public DataSet get_closedissue(string clientname)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker where  Client_Name='" + clientname + "' and IsDelete='0'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;

        }
        #endregion






        #region issue Chat
        public int insertissue_chat(int IssueID, DateTime Date, string Description, string Reference, string ChatName)
        {
            int iSuccess = 0;
            string sQry = "insert into tbl_Chat(IssueID,Date,Description,Reference,Chat_Name) values(" + IssueID + ",'" + Convert.ToDateTime(Date).ToString("yyyy-MM-dd") + "','" + Description + "','" + Reference + "','" + ChatName + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion

        public DataSet maxissueid()
        {
            DataSet ds = new DataSet();
            string sqry = "select Max(Issue_Id) as Issue_Id from tbl_IssueTracker";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet GetChat_POPUP(int iId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbl_Chat where IssueID=" + iId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet getissue()
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select count(*)as issue from tbl_IssueTracker where Status='1'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }

        public DataSet todaygetissue(string date)
        {
            DataSet ds = new DataSet();
            string hrmgrid = "select count(*)as issue from tbl_IssueTracker where Date='" + date + "'";
            ds = dbObj.InlineExecuteDataSet(hrmgrid);
            return ds;
        }

        public DataSet get_openedissue(string clientname, int IsDelete)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_IssueTracker where  Client_Name='" + clientname + "' and IsDelete=" + IsDelete + "";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;

        }

        //public DataSet selectTicketno(string sIssueType, string clientname)
        //{
        //    DataSet ds = new DataSet();
        //    string sqry = "select * from tbl_IssueTracker where Issue_type='" + sIssueType + "' and Client_Name='" + clientname + "' and IsDelete='1'";
        //    ds = dbObj.InlineExecuteDataSet(sqry);
        //    return ds;
        //}


        public DataSet get_projectTeam(string ProjectName)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_ProjectMaster where Project_Name='" + ProjectName + "'";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet SearchClientName(int id, string clientname)
        {
            DataSet ds = new DataSet();
            if (id == 1)
            {
                string sqry = "select * from tbl_ClientMaster where Client_Id='" + clientname + "'";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            else if (id == 2)
            {
                string sqry = "select * from tbl_ClientMaster  where Client_Name like'%" + clientname + "%'";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            return ds;
        }

        public DataSet ClientAppointment(string id, string name)
        {
            DataSet ds = new DataSet();
            if (id == "1")
            {
                string sQry = "select * from tbl_clientdetails where CompanyName like'%" + name + "%'";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
            else if (id == "2")
            {
                string sQry = "select * from tbl_clientdetails where ClientContactNumber like'%" + name + "%'";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
            else if (id == "3")
            {
                string sQry = "select * from tbl_clientdetails where Address like'%" + name + "%'";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
            return ds;
        }


        public DataSet empissuedet(string sIssueType, int name)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_Emp_IssueReport as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Issue_ID='" + name + "' and Issue_type='" + sIssueType + "' and IsDelete='1' order by Date desc";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet empissuereport(string sIssueType)
        {
            DataSet ds = new DataSet();
            string sqry = "select * from tbl_Emp_IssueReport as a inner join tbl_StatusType as b on a.Status=b.Status_Id where Issue_type='" + sIssueType + "' and IsDelete='1' order by Date desc";
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }

        public DataSet searchProjectName(string Empname, string name, string id)
        {
            DataSet ds = new DataSet();
            if (id == "1")
            {
                string sqry = "select distinct Project_Name, Client_Id,Project_id,Project_Type,Emp_Name from tbl_ProjectMaster where Emp_Name='" + Empname + "' and Project_Name like'%" + name + "%' and IsDelete='0'";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            else if (id == "2")
            {
                string sqry = "select distinct Project_Name, Client_Id,Project_id,Project_Type,Emp_Name from tbl_ProjectMaster where Emp_Name='" + Empname + "' and Emp_Name like'%" + name + "%' and IsDelete='0'";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            return ds;
        }

        public DataSet Searchallprojects(string name, string id)
        {
            DataSet ds = new DataSet();
            if (id == "1")
            {
                string sqry = "select * from tbl_ProjectMaster where Project_Name like'%" + name + "%' and IsDelete='0'";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            else if (id == "2")
            {
                string sqry = "select * from tbl_ProjectMaster where Emp_Name like'%" + name + "%' and IsDelete='0'";
                ds = dbObj.InlineExecuteDataSet(sqry);
            }
            return ds;
        }
        public DataSet GetIssuetype(string type)
        {
            DataSet ds = new DataSet();
            //string sqry = "select * from (tbl_ProjectMaster as a inner join tbl_IssueTracker as b on a.Project_Name=b.Project_Name) inner join tbl_StatusType as c on b.Status=c.Status_Id  where Issue_type='" + type + "' and b.IsDelete='1' order by Date desc";
            string sqry = "select * from tbl_IssueTracker as a inner join tbl_StatusType as b on a.Status=b.Status_Id where b.Status_Type='Opened' and a.Issue_type='" + type + "' ";
        
            ds = dbObj.InlineExecuteDataSet(sqry);
            return ds;
        }


        public DataSet getEmpLeave(string empid,string leaveid)
        {
            DataSet ds = new DataSet();
            string sql = "select * from tbl_LeaveForm where Emp_code='" + empid + "' and Leave_Id ='" + leaveid + "'";
            ds = dbObj.InlineExecuteDataSet(sql);
            return ds;
        }

        public DataSet getEmpLeaveid(string empid)
        {
            DataSet ds = new DataSet();
            string sql = "select  max(Leave_Id) as Leave_Id from tbl_LeaveForm where Emp_code='" + empid + "'";
            ds = dbObj.InlineExecuteDataSet(sql);
            return ds;
        }
    }
}

