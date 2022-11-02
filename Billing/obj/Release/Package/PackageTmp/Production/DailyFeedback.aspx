<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyFeedback.aspx.cs" Inherits="Billing.Production.DailyFeedback" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#d6ecf7">
  <usc:Header ID="Header" runat="server" />   
    <form id="form1" runat="server">
    <div class="row" style="margin-top:60px">
      <div class="container" >
            
              
               <legend style="text-align:left">Daily Feedback</legend>
               <div class="col-lg-12">
              <div class="form-group col-lg-4">
 <asp:DropDownList ID="drp" Width="300px" CssClass="form-control" runat="server"></asp:DropDownList>
 </div>
 <div class="form-group col-lg-4">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:TextBox ID="txtstartdate" Width="300px" CssClass="form-control" runat="server"></asp:TextBox>
                    
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtstartdate"
                        runat="server" Format="dd/MM/yyyy" CssClass="ajax__calendar">
                    </ajaxToolkit:CalendarExtender>
                    </div>
   </div>

     <asp:GridView ID="ingrid" runat="server" AutoGenerateColumns="False" 
                      AllowPaging="True" PageSize="8" 
                      CssClass="myGridStyle">                  
                                    
                                 <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" 
                                     PreviousPageText="Previous" />   
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
         <Columns>
        <asp:BoundField DataField="days" HeaderText="days" SortExpression="days" />


         
      
        
         </Columns>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
   

               </div>
                  </div>
                 
   
    </form>
</body>
</html>
