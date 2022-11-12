<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendence.aspx.cs" Inherits="HRM.Attendence" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
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

    <!--<script type="text/javascript">
        $(document).ready(function () {
        
//         Client Side Search (Autocomplete)
//         Get the search Key from the TextBox
//         Iterate through the 1st Column.
//         td:nth-child(1) - Filters only the 1st Column
//         If there is a match show the row [$(this).parent() gives the Row]
//         Else hide the row [$(this).parent() gives the Row]

            $('#txtsearch').keyup(function (event) {
            var searchKey = $(this).val().toLowerCase();
            $("#gvemp tr td:nth-child(1)".each(function () {
                var cellText = $(this).text().toLowerCase();
                if (cellText.indexOf(searchKey) >= 0) {
                    $(this).parent().show();
                }
                else {
                    $(this).parent().hide();
                }
            });
        });
           });

    </script>-->

    <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }    
</script>
    

    
 
    


    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <link href="../Accountsbootstrap/css/mGrid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form" runat="server">
    <menu:menu ID="menu" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="Upanel" runat="server">
    <ContentTemplate>
    <div class="container" align="center">
        <h2>Attendence</h2>
        <div class="row">
        <div class="form-group">
        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control-static" Placeholder="Enter Employee Name" onkeyup="Search_Gridview(this, 'gvemp')"></asp:TextBox>
        </div>
        <asp:GridView ID="gvemp" runat="server" AutoGenerateColumns="false" 
                CssClass="mGrid" onrowcommand="gvemp_RowCommand">
        <Columns>
        <asp:BoundField DataField="emp_code" HeaderText="EmpCode" />
        <asp:BoundField DataField="Name" HeaderText="Employee Name" />
        <asp:BoundField DataField="employee_id" HeaderText="EmpID" />
        <asp:TemplateField HeaderText="Login">
        
        <ItemTemplate>
        <asp:Button ID="btnlog" runat="server" Width="200px" Text="In" BackColor="Red" ForeColor="White"   CommandName="checking" CommandArgument='<%#Eval("emp_code")+","+Eval("Name")+","+Eval("employee_id") %>' />
        </ItemTemplate>
        </asp:TemplateField>

          <asp:TemplateField HeaderText="Status">
        
        <ItemTemplate>
      <asp:Label ID="lblststus" runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        
        </asp:GridView>
        
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:Label ID="lblempid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblempname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbllogintime" runat="server"></asp:Label>
    <asp:Label ID="lbllogtime" runat="server"></asp:Label>
    <asp:Label ID="id" runat="server"></asp:Label>
    <asp:Label ID="lbleid" runat="server"></asp:Label>
    <asp:Label ID="lbllogdate" runat="server"></asp:Label>
    <asp:Label ID="ltime" runat="server"></asp:Label>
    <asp:Label ID="lblattedance" runat="server"></asp:Label>
    </form>
</body>
</html>
