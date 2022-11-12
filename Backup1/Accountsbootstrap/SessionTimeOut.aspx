<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionTimeOut.aspx.cs" Inherits="Billing.Accountsbootstrap.SessionTimeOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1" runat="server">

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>PO Form</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Styles/style1.css" rel="stylesheet"/>
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
  <script type="text/javascript">
      function myFunction() {
          window.open("http://localhost:49197/Accountsbootstrap/itempage.aspx?Mode=Purchase", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
      }
</script>
</head> 
<body>

              
<form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>                
   


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="panel-body">
                            <div class="row" style="margin-left:450px;font-size:larger;color:Red;margin-top:200px""  >
                                  
                                  <label id="lbl" runat="server">Your Session Has Timed Out Please Login Again</label>
                                </div>
                                
                                 <div class="row"  style="margin-left:500px"  >
                                  
                                  <asp:Image  ID="imgTimeOut" runat="server" ImageUrl="~/images/Time out.png" />
                                </div>
                                <div class="row"  style="margin-left:550px"  >
                                <asp:LinkButton ID="link" runat="server" Text="Click Here To login Again" 
                                        onclick="link_Click" ></asp:LinkButton>
                                </div>
                                </div>


                                 
        </div>

                                

                              
                               

                                <!-- /.col-lg-6 (nested) -->
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
           
</ContentTemplate>
</asp:UpdatePanel>
 </form>
</body>

</html>
