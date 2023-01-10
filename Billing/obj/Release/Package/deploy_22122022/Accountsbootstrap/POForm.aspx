

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POForm.aspx.cs" Inherits="Billing.Accountsbootstrap.POForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head runat="server">

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

</head> 
<body>
 <usc:Header ID="Header" runat="server" /> 
 <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
<form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>                
   


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12" style="margin-top: 47px;">
                                    
                                       
                               <div class="form-group" style="text-align:center;">
                               <h2>Bigdbiz</h2>
                                            
    
                                           <%--<h2> <asp:Label ID="lblcompanyname" runat="server"></asp:Label> </h2><br />
                                            <b><asp:Label ID="lblarea" runat="server"></asp:Label><br />--%>
                                            Madurai - 625014 Phone No : 045-24345360<br />
                                           
                                            Email id : directors@bigdbiz.com Web : www.bigdbiz.com<br />
                                            TIN NO : 123456789 CST NO : 987654321</b>
                                           
                                        </div>	     
                                        <div class="form-group" style="text-align:center;">
                                            
                                           <h2>Purchase Order </h2>
                                           
                                           
                                        </div>	                                       
										
                                   
                                </div>
                                <div class="row">
                                <div class="col-lg-12">

                               
                                <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                 <div class="row">
                                <div class="col-lg-12">
                                <div class="form-group">
                                <label>Company Name</label>
                                <asp:TextBox ID="txtcompanyname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqrdval" runat="server" ValidationGroup="val1" ControlToValidate="txtcompanyname" style="color:Red" ErrorMessage="Enter Company Name"></asp:RequiredFieldValidator><br />
                                <label>To Address</label>
                                <%--<textarea class="form-control" cols="" id="txttoaddr" rows="3"></textarea>--%>

                                <asp:TextBox ID="txttoaddr" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="rqrtoaddr" runat="server" ValidationGroup="val1" ControlToValidate="txttoaddr" style="color:Red" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                                </div>
                                </div>
                                </div>
                                </td>
                               
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               
                                <td>
                                 
                                <div class="col-lg-6">
                                 
                                
                                <label>PO Date</label>
                                            <asp:TextBox CssClass="form-control" ID="txtpodate" runat="server" Text="--Select Date--"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtpodate" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1" ControlToValidate="txtpodate" style="color:Red" ErrorMessage="Enter PO Date"></asp:RequiredFieldValidator><br />
                              
                               
                                
                                <label>PO NO : </label><asp:TextBox ID="txtpono" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="val1" ControlToValidate="txtpono" style="color:Red" ErrorMessage="Enter PO NO"></asp:RequiredFieldValidator><br />
                               
                                
                                
                                <b>TIN NO: </b><asp:TextBox ID="txttinno" CssClass="form-control" runat="server"></asp:TextBox><br />
                           
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="val1" ControlToValidate="txttinno" style="color:Red" ErrorMessage="Enter TIN NO"></asp:RequiredFieldValidator>
                              <%--  <label>Purpose Report</label>--%>
                                
                               <%--  <textarea class="form-control" cols="" id="txtpurpose" rows="3"></textarea>--%>
                                <%--<asp:TextBox ID="txtpurpose" runat="server" CssClass="form-control" Height="150px"></asp:TextBox>--%>
                                </div>
                               
                                </td>
                                </tr>
                                </table>
                                 </div>
                                
                               </div>
                               </div>
                                </div>


                                 <div class="row">
                                 <div class="col-lg-12">
                               <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <asp:GridView ID="gvEditPODet" runat="server" style="margin-left: 128px;" CssClass="myGridStyle"></asp:GridView>
                       
            <asp:GridView ID="grvPODetails" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="97%" Style="text-align: left" onselectedindexchanged="grvPODetails_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                   
                    <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <asp:TextBox ID="txtitemname" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtitemname"
                                ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PO Qty/UOM">
                        <ItemTemplate>
                            <asp:TextBox ID="txtpoQty" runat="server" MaxLength="25" Width="66px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpoQty"
                                ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Rate/UOM Rupees(Rs.)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtrateQty" runat="server" MaxLength="50" Width="66px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtrateQty"
                                ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Disc %">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdis" runat="server" MaxLength="50" Width="66px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdis"
                                ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Disc Amt">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdisamt" runat="server" MaxLength="50" Width="66px"  OnTextChanged="txtdisamt_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdisamt"
                                ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Amount Rupees(Rs.)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtamt" runat="server" MaxLength="50" Width="66px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtamt"
                                ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-success" Text="Add New Row" OnClick="ButtonAdd_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>

                   
                   
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <center>
                <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" ValidationGroup="val1" OnClick="btnSave_Click" />
            </center>
            </td>
            </tr>
            </table>
            </div>
            </div>
        </div>
        </div>
        </div>

                                <div class="row">
                                <div class="col-lg-12">
                                <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                <tr>
                                <td>
                                <label>Terms & Conditions :</label>
                                
                                <b>DELIVERY SCHEDULE - WITH IN 10 DAYS</b><br />
                                <b>PAYEMENT OF TERMS - 60 DAYS</b><br />
                                <b>Others - INSPECTION REPORT & DRAWINGS TC SENT ALONG WITH DC</b><br /> 
                                <b>Despatch Instruction - MATERIAL TO BE DELIVERED AT OUR\</b><br />
                                 Amount in words :
                                </td>

                                <td>
                                <b>Total Amount : </b><asp:TextBox ID="txttotal" runat="server" 
                                        CssClass="form-control" ></asp:TextBox><br />
                               
                                </td>
                                </tr>
                                </table>
                                 </div>
                                
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

