<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave_Form.aspx.cs" Inherits="HRM.Leave_Form" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <script type="text/javascript" src="../js/combodate.js"></script>
    <script type="text/javascript" src="../js/Moment.js"></script>
    <title></title>
    <script language="javascript" type="text/javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127 || AsciiValue == 46))
                event.returnValue = true;

            else

                event.returnValue = false;

        }
        function validate() {


            var Employee_code = document.getElementById("txtCode").value;
            var Employee_Name = document.getElementById("txtEmpName").value;
            var Today_Date = document.getElementById("txtDate").value;
            var Leave_Date = document.getElementById("txtfromdate").value;
            var Leave_Date = document.getElementById("txttodate").value;
            var Reason = document.getElementById("txtReason").value;
            var Leave_Status = document.getElementById("ddlStatus").value;

            if (Employee_code == "") {
                alert("Enter employee code");

                return false;
            }
            if (Employee_Name == "") {
                alert("Enter Employee Name");

                return false;
            }

            if (Today_Date == "") {
                alert("Enter Today date");
                return false;
            }

            if (Fromdate == "") {
                alert("Enter Fromdate date");
                return false;
            }
            if (Todate == "") {
                alert("Enter To date");
                return false;
            }
            if (Reason == "") {
                alert("Enter your Reason");
                return false;
            }

            //            if (Leave_Status == "") {
            //                alert("Enter Your ");
            //                return false;
            //            }
        }  
        
    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
       <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
   
</head>
<body>
    <div>
        <menu:menu ID="menu" runat="server" />
        <div class="row">
        </div>
    </div>
    <div class="container" style="margin-top:-12px">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-default">
                    <div>
                        <br />
                        <br />
                   <h2  style="text-align:left;color:#6600ff;font-weight:bold;text-align:center" >Leave Form</h2> 
                        
                    </div>
                    <div class="panel-body">
                        <div class="row">
                          <div class="col-lg-2"></div>
                            <div class="col-lg-3">
                                <form id="Form2" runat="server" method="post">
                                <fieldset>
                                    <div class="form-group">
                                        <label>
                                            Employee Code:</label>
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Employee Name:</label>
                                        <asp:TextBox ID="txtClientId" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Today Date:
                                        </label>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"> </asp:TextBox>
                                    </div>
                                
                                     
                                     
                                            <label>
                                                From Date:
                                            </label>
                                            <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control"> </asp:TextBox>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                                runat="server" Format="dd/MM/yyyy" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                               
                                       <div class="form-group">

                                            <label>
                                                From Time:
                                            </label>
                                             <div class="col-lg-12">
                                            <div class="col-lg-6">
                                            <asp:DropDownList ID="ddlHour" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            </div>

                                           <div class="col-lg-6">
                                            <asp:DropDownList ID="ddlMin" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            </div>
                                            </div>
                                      </div>
                                        <asp:Label runat="server" ID="lblFromdateTime" Visible="false"></asp:Label>
                                

                                 
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblError" ForeColor="Red" Visible="false"></asp:Label>
                                    </div>
                                   
                                      </div>
                                         <div class="col-lg-1"></div>
                                      <div class="col-lg-3">

                                       <div class="form-group">
                                        <label>
                                            Leave Type:
                                        </label>
                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control form-inline"
                                            Enabled="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="Casual" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Sick" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Maternity" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Short Leave" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            To Date:
                                        </label>
                                        <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                            runat="server" Format="dd/MM/yyyy" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Reason:
                                        </label>
                                        <asp:TextBox ID="txtReason" runat="server" Placeholder="Enter Reason" CssClass="form-control"> </asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Leave Status</label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-inline"
                                            Enabled="false">
                                            <asp:ListItem Text="Request" Value="Request"></asp:ListItem>
                                            <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                            <asp:ListItem Text="DisApproved" Value="DisApproved"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px"
                                            class="btn btn-success" OnClick="btnSubmit_Click1" />
                                        <asp:Button ID="btnrefresh" runat="server" Text="Reset" 
                                            class="btn btn-danger" Width="100px" OnClick="btnrefresh_Click" />
                                    </div>
                                      </div>
                                    
                                </fieldset>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
