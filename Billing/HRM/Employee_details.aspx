<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_details.aspx.cs"
    Inherits="HRM.Employee_details" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>Employee_details - bootsrap</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script src="" type="text/javascript"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    <style type="text/css">
        .button-success, .button-error, .button-warning, .button-secondary
        {
            color: white;
            border-radius: 7px;
            text-shadow: 0 7px 5px rgba(0, 0, 0, 0.2);
        }
        
        .button-success
        {
            background: rgb(28, 184, 65); /* this is a green */
        }
        
        .button-error
        {
            background: rgb(202, 60, 60); /* this is a maroon */
        }
        
        .button-warning
        {
            background: rgb(223, 117, 20); /* this is an orange */
        }
        
        .button-secondary
        {
            background: rgb(66, 184, 221); /* this is a light blue */
        }
        
        
        
        
        .index1
        {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            background-color: orange;
            padding-top: 10px;
            padding-bottom: 10px;
            margin-left: 525px;
            margin-right: 525px;
            font-family: Californian FB;
        }
        .button1
        {
            margin-left: 70px;
        }
        .pad
        {
            padding left:300px;
        }
    </style>
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
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script language="javascript" type="text/javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127 || AsciiValue == 46))
                event.returnValue = true;

            else

                event.returnValue = false;

        }
        function validate() {

            var Employee_Id = document.getElementById("txtemployid").value;
            var Employee_code = document.getElementById("txtemploycode").value;
            var Employee_Name = document.getElementById("txtname").value;
            var Date_of_Birth = document.getElementById("txtdob").value;
            var Address = document.getElementById("txtaddress").value;

            var Mobile_No = document.getElementById("txtphno").value;
            var patterphno = /^[\s()+-]*([0-9][\s()+-]*){10,10}$/;



            var Service = document.getElementById("ddlservice").value;
            var Desigination = document.getElementById("ddldesignation").value;

            var Salary = document.getElementById("txtsalary").value;

            var pattern1 = /^-?[0-9]+(.[0-9]{1,6})?$/;
            var pattern2 = /^-?[0-9]+([0-9]{1,6})?$/;
            var pfno = document.getElementById("txtpfno").value;
            var esino = document.getElementById("txtESINO").value;
            //            var Email = document.getElementById("txtemail").value;
            //            var regexmail = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;

            var Password = document.getElementById("txtpwd").value;
            var pattern3 = /^(?=.*\d)(?=.*[a-z])[a-z\d]{2,}$/i;

            //         var pattern1 = /^(?=.*\d)(?=.*[a-z])[a-z\d]{2,}$/i;
            //         var pattern3 = /^.*(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\d\W]).*$/;
            //         var pattern3 = ^(?=[^\d_].*?\d)\w(\w|[!@#$%]){7,20};
            //         var pattern3 = (?=^.{6,255}$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*;

            var Documents_Submitted = document.getElementById("txtDocumentsSubmitted").value;

            if (Employee_Id == "") {
                alert("Enter Customer Name.");

                return false;
            }
            if (Employee_code == "") {
                alert("Enter employee code.");

                return false;
            }



            if (Employee_Name == "") {
                alert("Enter Employee Name");

                return false;
            }

            if (Date_of_Birth == "-Select Date-") {
                alert("Enter Your age.");
                return false;
            }

            if (Address == "") {
                alert("Enter your Address.");
                return false;
            }


           // if (!patterphno.test(Mobile_No)) {
           //     alert("It is not valid mobile number");
            //    return false;
           // }
            if (pfno == "") {
                alert("enter Pf no.");
                return false;
            }
            if (esino == "") {
                alert("enter esino no.");
                return false;
            }


            if (Service == "--Select Service--") {
                alert("Enter Your service");
                return false;
            }

           // if (Desigination == "") {
              //  alert("Enter Your desigination");
                //return false;
        //    }


            // if (Salary.match(pattern1) == null) {
            //     alert("Please Enter Valid Principal Amount.");
            //     return false;
            // }

            //            if (!regexmail.test(Email)) {
            //                alert("It is not valid mailId");
            //                return false;
            //            }


            if (Password.match(pattern3) == null) {
                alert('not alpha anumeric');
                return false;
            }


            //            if (Password.length < 7) {
            //                alert('Please enter password miniumum 7 chars');
            //                Password.focus();
            //                return false;
            //            }

            if (Documents_Submitted == "") {
                alert("Enter yes or no.");
                return false;
            }
            if (Employee_Id == "" && Employee_code == "" && Employee_Name == "" && Date_of_Birth == "-Select Date-" && Address == "" && Mobile_No == "" && Service == "--Select Service--" && Desigination == "" && Salary == "" && Email == "" && Password == "" && Documents_Submitted == "") {
                alert("Enter All Fields");
                return false;
            }
        }
        
        
    </script>
</head>
<body>
    <div>
        <menu:menu ID="menu" runat="server" />
        <div class="row">
            <div class="col-lg-12" style="margin-top:-45px">
                <br />
                <br />
                  <h2  style="text-align:center;color:#6600ff;font-weight:bold" > Employee Registration</h2> 
                
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="Form2" runat="server" method="get">
                                <asp:UpdatePanel ID="Panel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Employee id</label>
                                            <asp:TextBox CssClass="form-control" ID="txtemployid" MaxLength="60" runat="server"
                                                Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3 ">
                                            <label>
                                                Employee Code</label>
                                            <asp:TextBox CssClass="form-control" ID="txtemploycode" MaxLength="60" AutoPostBack="true"
                                                runat="server" OnTextChanged="txtemploycode_TextChanged"></asp:TextBox>
                                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Employee Name</label>
                                            <asp:TextBox CssClass="form-control" ID="txtname" MaxLength="60" Width="100%" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Date of Birth:</label>
                                            <asp:TextBox ID="txtdob" runat="server" Text="Select Date" CssClass="form-control"> </asp:TextBox>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdob" runat="server"
                                                Format="dd/MM/yyyy" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Date of Joining:</label>
                                            <asp:TextBox ID="txtdoj" runat="server" Text="Select Date" CssClass="form-control"> </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtdoj" runat="server"
                                                Format="dd/MM/yyyy" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Address</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="60"  TextMode="MultiLine" Height="34px"
                                                ID="txtaddress" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Mobile No</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="10" Width="100%" ID="txtphno" runat="server"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers" 

ValidChars=""  TargetControlID="txtphno" />
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Branches</label>
                                            <asp:DropDownList ID="ddlbranches" runat="server" Width="100%" AutoPostBack="true"
                                                CssClass="form-control" OnSelectedIndexChanged="ddlbranches_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Service</label>
                                            <asp:DropDownList ID="ddlservice" runat="server" Width="100%" AutoPostBack="true"
                                                CssClass="form-control" OnSelectedIndexChanged="ddlservice_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-lg-3" style="display:none">
                                            <label>
                                                Desigination</label>
                                            <asp:DropDownList ID="ddldesignation" runat="server" Width="100%" AutoPostBack="true"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Job Type</label>
                                            <asp:DropDownList ID="ddljobtype" runat="server" Width="100%" AutoPostBack="true"
                                                CssClass="form-control" OnSelectedIndexChanged="ddljobtype_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-lg-3" style="display:none">
                                            <label>
                                                Salary</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="15" Width="100%"  ID="txtsalary" runat="server">0</asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,Custom" 

ValidChars="."  TargetControlID="txtsalary" />
                                        </div>
                                        <div class="form-group col-lg-3" style="display:none">
                                            <label>
                                                Annual salary</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="15" Width="100%" ID="txtannulasal" 
                                                runat="server">0</asp:TextBox>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"  runat="server" FilterType="Numbers,Custom" 

ValidChars="."  TargetControlID="txtannulasal" />
                                        </div>
                                        <div class="form-group col-lg-3" style="display:none">
                                            <label>
                                                P.F.NO</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="60" Width="100%" ID="txtpfno" runat="server">0</asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3" style="display:none">
                                            <label>
                                                E.S.I.NO</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="60" Width="100%" ID="txtESINO" runat="server">0</asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Email</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="60" Width="100%" ID="txtemail" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3">
                                            <label>
                                                Password</label>
                                            <asp:TextBox CssClass="form-control" TextMode="Password" MaxLength="60" Width="100%"
                                                ID="txtpwd" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-3" style="display:none">
                                            <label>
                                                Documents Submitted</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="60" Width="100%" ID="txtDocumentsSubmitted"
                                                runat="server">None</asp:TextBox>
                                        </div>
                                            <div class="form-group col-lg-3">
                                            <label>Status</label>
                                            <asp:DropDownList runat="server" ID="ddlStatus" Width="100%" AutoPostBack="true"
                                                CssClass="form-control">
                                            <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Releaved" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Abscond" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                         <div class="form-group col-lg-3">
                                          <label>Date of Leaving</label>
                                            <asp:TextBox CssClass="form-control" Visible="true" MaxLength="60" Width="100%"
                                                ID="ttDateofLeaving" runat="server"></asp:TextBox>
                                                   <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="ttDateofLeaving" runat="server"
                                                Format="dd/MM/yyyy" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                           <div class="form-group col-lg-3">
                                            <asp:Label runat="server" ID="lblcontract" Visible="false">Contract Period</asp:Label>
                                            <asp:TextBox CssClass="form-control" Visible="false" MaxLength="60" Width="100%"
                                                ID="txtcontract" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6"></div>                                     
                                 
                                            <div>
                                                <div class="col-lg-1">
                                                    <asp:Button ID="btnsubmit" Width="100px" runat="server" CssClass="btn btn-success"
                                                        Text="SUBMIT" OnClientClick="return validate();" OnClick="btnsubmit_Click1" />
                                                </div>
                                                <div  class="col-lg-2">
                                                    <asp:Button ID="btnReset" Width="100px" runat="server" CssClass="btn btn-danger "
                                                        Text="Reset" OnClick="btnReset_Click" />
                                                </div>
                                            </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
