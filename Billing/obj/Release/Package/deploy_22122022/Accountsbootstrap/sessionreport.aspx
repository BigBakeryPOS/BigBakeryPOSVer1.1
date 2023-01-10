<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sessionreport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.sessionreport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <link rel="stylesheet" type="text/css" href="css/mGrid.css" />
    <style type="text/css">
        .table-striped1 > tbody > tr:nth-child(even)
        {
            background-color: #81d8d0;
        }
        .table-striped1 > tbody > tr:nth-child(odd)
        {
            background-color: #81d8d0;
        }
        /* Background Gradient for Analagous Colors */
        .gradient2
        {
            background-color: #08D0AA; /* For WebKit (Safari, Chrome, etc) */
            background: #08D0AA -webkit-gradient(linear, left top, left bottom, from(#0871D0), to(#08D0AA)) no-repeat; /* Mozilla,Firefox/Gecko */
            background: #08D0AA -moz-linear-gradient(top, #0871D0, #08D0AA) no-repeat; /* IE 5.5 - 7 */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#08D0AA) no-repeat; /* IE 8 */
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#0871D0)" no-repeat;
        }
    </style>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= griddenomination.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Session Report</title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css">
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
    <script type="text/javascript" language="javascript">
        var oldRowColor;

        // this function is used to change the backgound color

        function ChangeColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                oldRowColor = obj.className;

                obj.className = "HighLightRowColor";

            }

        }

        // this function is used to reset the background color 
        function ResetColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                obj.className = oldRowColor;

            }

        }

    </script>
    <style type="text/css">
        .RowStyleBackGroundColor
        {
            background-color: White;
        }
        
        .RowAlternateStyleBackGroundColor
        {
            background-color: White;
        }
        
        .HighLightRowColor
        {
            background-color: Yellow;
            font-weight: bold;
            font-size: xx-large;
            color: White;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= deno.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            //prtWindow.document.write('<html><head></head>');
            //prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            //prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
    <style>
        .messagepop
        {
            border: 1px solid #999999;
            cursor: default;
            display: none;
            margin-top: 15px;
            position: absolute;
            text-align: left;
            width: 394px;
            height: 100px;
            z-index: 50;
            padding: 25px 25px 20px;
            border-radius: 7px;
            background: #e84c3d;
            margin: 30px auto 0;
            padding: 6px;
            color: White;
            top: 50%;
            left: 50%;
            margin-left: -400px;
            margin-top: -40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <asp:Label ID="lbldefaultcur" runat="server" Visible="false" Text="INR"></asp:Label>
    <div class="col-lg-4">
        <div class="panel panel-custom1">
		<div class="panel-header">
				<h1 class="page-header"> Session Close Entry</h1>
		</div>
                <div class="panel-body panel-form-right">
        
                <div class="list-group">
                    <label>
                        Select Session Type</label>
                    <asp:DropDownList ID="drpsessiontype" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <br />
                 <label>
                        Details Notes</label>
                    <asp:TextBox ID="txtnotes" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
               
           <br />
                 <div class="table-responsive panel-grid-left">
                    <asp:GridView ID="griddenomination" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="" />
                            <asp:TemplateField HeaderText="No's">
                                <ItemTemplate>
                                    <asp:Label ID="lblDenominationid" Visible="false" runat="server" Text='<%#Eval("Denominationid")%>'></asp:Label>
                                    <asp:Label ID="lblname" Visible="false" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                    <asp:Label ID="lblvalue" Visible="false" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                    <asp:TextBox ID="lblnos" runat="server" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <%--<RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                        <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />--%>
                    </asp:GridView>
                    
               
                
                    <label>
                        Total Amount :</label>
                    <asp:Label ID="lblgrandtotal" Font-Size="25px" ForeColor="Red" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Save" Enabled="true" CssClass="btn btn-primary pos-btn1" Width="100px"
                        OnClick="Button1_Click" />
                    <asp:Label ID="lblErr" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:Button ID="btncalc" runat="server" Text="Calculate" CssClass="btn btn-info" Width="100px"
                        OnClick="btncalc_Click" TabIndex="11" />
            </div>
        </div>
        <%-- <div class="col-lg-12">
            Select Date:<asp:TextBox ID="date" runat="server" AutoPostBack="true" CssClass="cal_Theme1"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="date" Format="yyyy-MM-dd">
            </ajaxToolkit:CalendarExtender>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Text="print" OnClick="btnPrintFromCodeBehind_Click" />
        </div>
        <div class="col-lg-12">
            <asp:GridView ID="gvlist" runat="server" CssClass="table-condensed">
            </asp:GridView>
            <label>
                Total :</label><asp:Label ID="lbltotl" runat="server"></asp:Label>
        </div>--%>
    </div>
    </div>
     <div class="col-lg-8">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Session Close Details</h1>
	    </div>
   
    <div class="panel-body">
        <div class="col-lg-12">
                <div class="table-responsive panel-grid-left">
                <asp:GridView ID="griddetails" runat="server" OnRowCommand="gvorderToday_RowCommand" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="sessionname" HeaderText="Session Type Name" />
                        <asp:BoundField DataField="cashdate" HeaderText="Cash Date" DataFormatString='{0:dd/MM/yyyy hh:MM:ss tt}' />
                        <asp:BoundField DataField="Totalcash" HeaderText="Total" DataFormatString='{0:f}' />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" CommandArgument='<%#Eval("cashsessionid") %>' CommandName="Del"
                                    runat="server">
                                    <asp:Image ID="imgdprint" runat="server" ImageUrl="~/images/delete.png" visible="false"/>
                                    <button type="button" class="btn btn-danger btn-md">
												<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
												</button>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Print">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("cashsessionid") %>' CommandName="Print"
                                    runat="server">
                                    <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" width="55px"  Visible="false"/>
                                    <button type="button" class="btn btn-default btn-md">
						            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					            </button>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
                                 <table  id="deno" visible="false" runat="server">
                    <thead>
                        <tr>
                            <th colspan="2">
                                Denomination Table For Cash Session Details
                            </th>
                        </tr>
                    </thead>
                    <tr>
                        <td colspan="2">
                            <div class="table-responsive panel-grid-left"> 
                            <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" padding="0" spacing="0" border="0" cssClass="table table-striped pos-table">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="" />
                                    <asp:TemplateField HeaderText="No's">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnos" Visible="true" runat="server" Text='<%#Eval("Nos")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" Text='<%#Eval("Total","{0:f}")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <%--<RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />--%>
                                <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                            </asp:GridView>
                            </div>
                            <div>
                                <label>
                                    Total Amount :</label>
                                <asp:Label ID="lblDenototal" Font-Size="25px" ForeColor="Red" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                         </td>
                    </tr>
                </table>
            </div>
            </div>
            </div>
            </div>
             
    </div>
    </div>
    </div>
    </form>
</body>
</html>
