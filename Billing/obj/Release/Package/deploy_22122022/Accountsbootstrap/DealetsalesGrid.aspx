<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealetsalesGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.DealetsalesGrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/DealerMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Sales Grid </title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
        function alertMessage() {

            alert('This Bill Not Allow To Cancel.Please Contact Administrator!!!');
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
   <script type="text/javascript">

       function alertorder() {
           alert('Are You Sure, You want to cancel This Customer sales!');
       }
    </script>
    
</head> 
<body  >
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"   Visible="false">  </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"  Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row">
                <div class="col-lg-12" align="center" >
                    <h1 class="page-header" style="margin-top:0px">Dealer Sales Details</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row" align="center"  >
                <div class="col-lg-12"  >
                    <div class="panel panel-default"  >
                        
                        <div class="panel-body"  >
                            <div class="row"  >
                                <div >
                                    <form runat="server" id="form1" method="post">
                                    <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      <asp:ScriptManager ID="script" runat="server"  EnablePartialRendering="true"></asp:ScriptManager>
                                    <div class="form-group"  >
                                            <label>Filter By</label>
                                            <asp:DropDownList ID="ddlbillno" CssClass="form-control"  style="width:175px;" 
                                                runat="server">
                                            <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>

                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlcustomername" CssClass="form-control" Visible="false" runat="server" style="width:150px;"></asp:DropDownList>
                                                 
                                                  

                                               
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search"   onkeyup="Search_Gridview(this, 'gvCustsales')" style="margin-top: 10px;"  /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" style="margin-top: 10px;"  /> 
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" 
                                                style="margin-top: 10px;" onclick="btnadd_Click" />  
                                        </div> 
                                        <div class="form-group">
                                        <label>Enter Billno</label>
                                        <asp:TextBox ID="txtAutoName" runat="server" CssClass="form-control" Width="200px" placeholder="Enter Billno and Press Tab" onkeyup="Search_Gridview(this, 'gvsales')"  
                                               ></asp:TextBox>
                                                
                                        </div>
                              

                               <div class="col-lg-6" align="center" >
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td  style="width:35%" >

                                
                                <asp:GridView ID="gvsales" align="center"  runat="server" AllowPaging="true" 
                                        PageSize="50"   AutoGenerateColumns="false" CssClass="mGrid"  
                                        EmptyDataText="No Records Found" onrowcommand="gvsales_RowCommand"  >
                                 <HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1" Mode="Numeric"  />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
   
    <asp:BoundField HeaderText="Contact Name" DataField="VendorName" />
     <asp:BoundField HeaderText="Sales Excempted " DataField="ExemptedTotal" DataFormatString="{0:f}" />
    <asp:BoundField HeaderText="Net Amount" DataField="NetAmount"  DataFormatString="{0:f}" />
    <asp:BoundField HeaderText="Tax Amount" DataField="VatTotal" DataFormatString="{0:f}" />
   
    <asp:BoundField HeaderText="Total Amount" DataField="GrandTotal"  DataFormatString="{0:f}" />
     <asp:BoundField HeaderText="Prepared by" DataField="Prepared"  />
     <asp:TemplateField HeaderText="Edit" Visible="false">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="edit"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
      
     </ItemTemplate>
    
     
     
     </asp:TemplateField>
     <asp:TemplateField HeaderText="Cancel Sales">
     <ItemTemplate>
           <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="cancel" ><asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png" /></asp:LinkButton>

            <ajaxToolkit:modalpopupextender
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="btndelete"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="btndelete" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>

   </ItemTemplate>
    
     
     
     </asp:TemplateField>

      <asp:TemplateField HeaderText="View Details">
     <ItemTemplate>
           <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="view" ><asp:Image ID="vie" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>

       <asp:TemplateField HeaderText="Print">
     <ItemTemplate>
           <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="print" ><asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>
   </Columns>
   
 <FooterStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />
   </asp:GridView>
                                </td>
                                 
                                
                                </tr>
                                
                                    
                                
                                </table>
                                   </td>
                                   </tr>
                                   </table>
                                </div>
                                <div id="pahe"  >
                                <iframe id="visit" height="450px" width="100%" scrolling="auto"  runat="server">
                                
                                </iframe>
                                </div>



                                     </ContentTemplate>
                                    </asp:UpdatePanel>


                                       <asp:panel Width="30%" class="popupConfirmation" id="DivDeleteConfirmation"  
	style="display: none; background:#fffbd6"  runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div align="center"  style="color:Red" class="TitlebarLeft">
                Warning Message!!!</div>
            <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div  align="center" style="color:Red" class="popup_Body">
         <asp:TextBox ID="txtRef" runat="server"  placeholder="Enter Reference BillNo" ></asp:TextBox>
            <p>
           
                Are you sure want to Cancel this Bill?
            </p>
        </div>
        <div align="center" class="popup_Buttons">
            <input id="ButtonDeleleOkay" type="button" value="Yes" />
            <input id="ButtonDeleteCancel" type="button" value="No" />
        </div>
    </div>
</asp:panel> 
                                   
                                    </form>
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
            </div>


</body>

</html>
