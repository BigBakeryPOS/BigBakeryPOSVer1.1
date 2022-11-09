<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Billing.Accountsbootstrap.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Login page</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />

   <%-- <script language="javascript" type="text/javascript">
        function showMacAddress() {
           // alert("fire");
            var obj = new ActiveXObject("WbemScripting.SWbemLocator");
            var s = obj.ConnectServer(".");
            var properties = s.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
            var e = new Enumerator(properties);
            var output;
            output = '<table border="0" cellPadding="5px" cellSpacing="1px" bgColor="#CCCCCC">';
            output = output + '<tr bgColor="#EAEAEA"><td>Caption</td><td>MACAddress</td></tr>';
            while (!e.atEnd()) {
                e.moveNext();
                var p = e.item();
                if (!p) continue;
                output = output + '<tr bgColor="#FFFFFF">';
                output = output + '<td>' + p.Caption; +'</td>';
                output = output + '<td>' + p.MACAddress + '</td>';
                output = output + '</tr>';
            }
            output = output + '</table>';
            document.getElementById("box").innerHTML = output;
            alert(output);
        }
</script>--%>

</head>

<body background="../images/BlackForrestRe.png" style="text-align:center;background-position:center;  background-repeat: no-repeat;  background-attachment: fixed;background-color:White"  >
 <label>MAC ADDRESS:</label><asp:Label  ID="macaddress" runat="server"></asp:Label>
    <div class="container">
        <div class="row" >
           
                    <div class="panel-body" style="margin-left:100px">
                        <form id="Form1"  runat="server">
                       
                            <fieldset>
                              
                                   <div class="form-group">
                                            
                                            <asp:TextBox CssClass="form-control" ID="username" placeholder="Enter your UserName" Width="300px" MaxLength="150" runat="server"></asp:TextBox>
											<asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="address" controltovalidate="username" errormessage="Please enter your UserName" style="color:Red" />
                                        
                               
                                    <asp:TextBox ID="password" TextMode="Password" runat="server" CssClass="form-control"  Width="300px" placeholder="Enter your Password"></asp:TextBox>
                                   
                                     <asp:Button CssClass="btn"   BackColor="#d3363b" Font-Bold="true" ForeColor="White" ID="LoginButton" Height="40px" runat="server" Width="100px"  style="margin-right:750px;margin-top:20px" Text="Sign In" 
                            ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click"/>
                                </div>
                                    
                                   
                                    
                                <!-- Change this to a button or input when using this as a form -->
                                
                            <asp:Button Visible="false" class="btn btn-lg btn-success btn-block" ID="regform" runat="server" 
                            CommandName="RegForm" Text="Registration Form" onclick="Registration_Form"/>
                            <asp:Button Visible="false" class="btn btn-lg btn-success btn-block" ID="plan" runat="server" 
                            CommandName="Plan" Text="Plan"/>
                                
                            </fieldset>
                            
                        </form>
                        
               
            </div>
        </div>
    </div>
    
                        
    <!-- jQuery -->
    <script type="text/javascript" src="../js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript"  src="../js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script type="text/javascript" src="../js/plugins/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script type="text/javascript" src="../js/sb-admin-2.js"></script>

</body>

</html>
