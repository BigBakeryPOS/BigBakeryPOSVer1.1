<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedBack_Form.aspx.cs" Inherits="Billing.Accountsbootstrap.FeedBack_Form" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
<style type="text/css">
    .scaledRadioButtons
{
        transform: scale(2, 2);
        -ms-transform: scale(2, 2); 
        -webkit-transform: scale(2, 2);
}

.table-striped1>tbody>tr:nth-child(even){background-color:#81d8d0}.table-striped1>tbody>tr:nth-child(odd){background-color:#81d8d0}
/* Background Gradient for Analagous Colors */
.gradient2
{
    background-color: #08D0AA;
    /* For WebKit (Safari, Chrome, etc) */
    background: #08D0AA -webkit-gradient(linear, left top, left bottom, from(#0871D0), to(#08D0AA)) no-repeat;
    /* Mozilla,Firefox/Gecko */
    background: #08D0AA -moz-linear-gradient(top, #0871D0, #08D0AA) no-repeat;
    /* IE 5.5 - 7 */
    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#08D0AA) no-repeat;
    /* IE 8 */
    -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#0871D0)" no-repeat;
}

</style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Customer Sales Report</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
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
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }

        function switchViews(obj, imG) {
            var div = document.getElementById(obj);
            var img = document.getElementById(imG);
            if (div.style.display == "none") {
                div.style.display = "inline";


                img.src = "../images/minus.gif";

            }
            else {
                div.style.display = "none";
                img.src = "../images/plus.gif";

            }
        }
    </script>
</head>
<body>
   <usc:Header ID="Header" runat="server" Visible="false" />
    <form runat="server" id="form1" method="post" style="margin-top: 0px">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:UpdatePanel ID="Updatepnel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        </h1>
                       
                </div>
                
                </div>
                <!-- /.col-lg-12 -->
            </div>
              <div class="container-fluid">
            <div class="row">
                               <div  class="col-lg-2"></div>
                                <div class="col-lg-8">
                                  <div class="table-responsive">
                                  <table class="table-responsive table table-striped1 ">
                                  <thead>
                                      <tr>
                                          <th  Width="250px" colspan="2" >
                                           <h2>Kindly Share your Details With Us</h2></th>
                                              <th >
                                          
                                          
                                      </tr>
                                  </thead>
                                   <tr>
                                    <td> <asp:Label ID="Label6" runat="server"><b>Name</b>  </asp:Label></td>
                                   <td><asp:TextBox CssClass="form-control" id="txtname" runat="server"></asp:TextBox></td>
                                     
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                   <tr>
                                    <td> <asp:Label ID="Label8" runat="server"><b>Email Address </b> </asp:Label></td>
                                   <td><asp:TextBox CssClass="form-control" id="txtEmail" runat="server"></asp:TextBox></td>
                                     
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>

                                   <tr>
                                 
                                   <td>
                                   <label>Date</label>
                                  <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="Pick Your Date" ></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cal" runat="server" CssClass="cal_Theme1" TargetControlID="txtDate" Animated="true"></ajaxToolkit:CalendarExtender>
                                   </td>
                                   <td>
                                      <asp:Label ID="Label7" runat="server"><b>Mobile Number </b> </asp:Label>
                                   <asp:TextBox CssClass="form-control" id="txtMobile" runat="server"></asp:TextBox>
                                   </td>
                                   </tr>
                                   <tr>
                                   <td>
                                   <h4>Your Special Day</h4>
                                   </td>
                                   <td>
                                   <asp:CheckBoxList ID="che" runat="server">
                                   <asp:ListItem Value="your" Text="Your Birthday"></asp:ListItem>
                                   <asp:ListItem Value="your" Text="Daughter's Birthday"></asp:ListItem>
                                   <asp:ListItem Value="your" Text="Son's Birthday"></asp:ListItem>
                                   <asp:ListItem Value="your" Text="Wife Birthday"></asp:ListItem>
                                   <asp:ListItem Value="your" Text="Mother's Birthday"></asp:ListItem>
                                   <asp:ListItem Value="your" Text="Father's Birthday"></asp:ListItem>
                                   <asp:ListItem Value="your" Text="Wedding Anniversary"></asp:ListItem>
                                   </asp:CheckBoxList>
                                   </td>
                                   </tr>
                                 
                                
                                  </table>
                                
                                  </div>
                            </div>
                               <div  class="col-lg-2"></div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        </div>
            <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                        <!-- Row1-->
                       
                            <div class="row">
                            <div  class="col-lg-2"></div>
                                <div class="col-lg-8">
                                  <div class="table-responsive">
                                  <table border="0" class="table-responsive table table-striped1 ">
                                  <thead>
                                      <tr>
                                          <th Width="250px" >
                                          <asp:Label ID="lbl1" runat="server" >  RATE YOUR EXPERIENCE </asp:Label>
                                            </th>
                                              <th >
                                           <asp:Image ID="img1" runat="server" ImageUrl="~/images/Excellent.png" Width="50px" Height="50px"/></th>
                                              <th >
                                             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Very_good.png" Width="50px" Height="50px"/></th>
                                              <th >
                                             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Good.png" Width="50px" Height="50px" /></th>
                                              <th >
                                              <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Bad.png" Width="50px" Height="50px"/></th>
                                              <th >
                                           <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Very_Bad.png" Width="50px" Height="50px" /></th>
                                      </tr>
                                  </thead>
                                   <tr>
                                    <td> <asp:Label ID="lblCash_handover" runat="server"  Width="130px"><b>Our Store </b> </asp:Label></td>
                                   <td><asp:RadioButton ID="rb_Store_Exec" runat="server" CssClass="form-group" GroupName="store"/></td>
                                      <td><asp:RadioButton ID="rb_Store_VG" runat="server" CssClass="form-group" GroupName="store" /></td>
                                         <td><asp:RadioButton ID="rb_Store_Good" runat="server" CssClass="form-group" GroupName="store" /></td>
                                            <td><asp:RadioButton ID="rb_Store_Bad" runat="server" CssClass="form-group" GroupName="store" /></td>
                                               <td><asp:RadioButton ID="rb_Store_VB" runat="server" CssClass="form-group" GroupName="store" /></td>
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                   <tr>
                                    <td> <asp:Label ID="Label1" runat="server"  Width="130px"><b>Our Lobbies</b>  </asp:Label></td>
                                   <td><asp:RadioButton ID="rb_Lobbies_Exec" runat="server" CssClass="form-group" GroupName="Lobbies" /></td>
                                      <td><asp:RadioButton ID="rb_Lobbies_VG" runat="server" CssClass="form-group" GroupName="Lobbies" /></td>
                                         <td><asp:RadioButton ID="rb_Lobbies_Good" runat="server" CssClass="form-group" GroupName="Lobbies" /></td>
                                            <td><asp:RadioButton ID="rb_Lobbies_Bad" runat="server" CssClass="form-group" GroupName="Lobbies" /></td>
                                               <td><asp:RadioButton ID="rb_Lobbies_VB" runat="server" CssClass="form-group" GroupName="Lobbies" /></td>
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                   <tr>
                                    <td> <asp:Label ID="Label2" runat="server"  Width="130px"><b>Our F & B </b> </asp:Label></td>
                                   <td><asp:RadioButton ID="rb_FB_Exec" runat="server" CssClass="form-group" GroupName="FB" /></td>
                                      <td><asp:RadioButton ID="rb_FB_VG" runat="server" CssClass="form-group" GroupName="FB" /></td>
                                         <td><asp:RadioButton ID="rb_FB_Good" runat="server" CssClass="form-group" GroupName="FB" /></td>
                                            <td><asp:RadioButton ID="rb_FB_Bad" runat="server" CssClass="form-group" GroupName="FB" /></td>
                                               <td><asp:RadioButton ID="rb_FB_VB" runat="server" CssClass="form-group" GroupName="FB" /></td>
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                   <tr>
                                    <td> <asp:Label ID="Label3" runat="server"  Width="130px"><b>Our Ambition  </b></asp:Label></td>
                                   <td><asp:RadioButton ID="rb_Amb_Exec" runat="server" CssClass="form-group" GroupName="Ambition" /></td>
                                      <td><asp:RadioButton ID="rb_Amb_VG" runat="server" CssClass="form-group" GroupName="Ambition" /></td>
                                         <td><asp:RadioButton ID="rb_Amb_Good" runat="server" CssClass="form-group" GroupName="Ambition" /></td>
                                            <td><asp:RadioButton ID="rb_Amb_Bad" runat="server" CssClass="form-group" GroupName="Ambition" /></td>
                                               <td><asp:RadioButton ID="rb_Amb_VB" runat="server" CssClass="form-group" GroupName="Ambition" /></td>
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                   <tr>
                                    <td> <asp:Label ID="Label4" runat="server"  Width="130px"><b>Our Service </b> </asp:Label></td>
                                   <td><asp:RadioButton ID="rb_Service_Exec" runat="server" CssClass="form-group" GroupName="Service" /></td>
                                      <td><asp:RadioButton ID="rb_Service_VG" runat="server" CssClass="form-group" GroupName="Service" /></td>
                                         <td><asp:RadioButton ID="rb_Service_Good" runat="server" CssClass="form-group" GroupName="Service" /></td>
                                            <td><asp:RadioButton ID="rb_Service_Bad" runat="server" CssClass="form-group" GroupName="Service" /></td>
                                               <td><asp:RadioButton ID="rb_Service_VB" runat="server" CssClass="form-group" GroupName="Service" /></td>
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                   <tr>
                                    <td> <asp:Label ID="Label5" runat="server"  Width="130px"><b>Overall Experience</b>  </asp:Label></td>
                                   <td><asp:RadioButton ID="rb_Experience_Exec" runat="server" CssClass="form-group" GroupName="Experience" /></td>
                                      <td><asp:RadioButton ID="rb_Experience_VG" runat="server" CssClass="form-group" GroupName="Experience" /></td>
                                         <td><asp:RadioButton ID="rb_Experience_Good" runat="server" CssClass="form-group" GroupName="Experience" /></td>
                                            <td><asp:RadioButton ID="rb_Experience_Bad" runat="server" CssClass="form-group" GroupName="Experience" /></td>
                                               <td><asp:RadioButton ID="rb_Experience_VB" runat="server" CssClass="form-group" GroupName="Experience" /></td>
                                 <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                   </tr>
                                     <tr><td align="center" colspan="6"><asp:Button ID="btnSave" CssClass="btn btn-primary " 
                                          Text="Save" runat="server" onclick="btnSave_Click" />
                                  <asp:Button ID="btnreset" CssClass="btn btn-danger " Text="Reset" 
                                           runat="server" onclick="btnreset_Click" /></td>
                                   </tr>
                                  </table>
                                  
                                  </div>
                            </div>
                             <div  class="col-lg-2"></div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                         <!-- Row1-->
                           <!--Row2-->
                           
                           
                           <!--Row2-->
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
            </div></div>
        </ContentTemplate>
        <Triggers>
           
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
