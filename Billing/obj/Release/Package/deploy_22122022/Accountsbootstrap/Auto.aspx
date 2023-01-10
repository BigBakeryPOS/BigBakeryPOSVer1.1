<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auto.aspx.cs" Inherits="Billing.Accountsbootstrap.Auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
	<style type="text/css">
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
		
	</style>
	<link rel="stylesheet" href="Style/chosen.css" />
    <link href="Style/chosen.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form runat="server" id="form1">
    <asp:UpdatePanel ID="updatepanel" runat="server" >
    <ContentTemplate>
     <asp:ScriptManager ID="script" runat="server"  EnablePartialRendering="true"></asp:ScriptManager>
    	<div id="container">
			<h2>Selected Value :
				<asp:Label runat="server" ID="lblSelectedValue" Style="color: red"></asp:Label></h2>

                <label id="lbltest" runat="server" ></label>
			<div class="side-by-side clearfix">
            <table>
            <tr>
            <td>
            <asp:DropDownList data-placeholder="Choose a Category..." runat="server"  AutoPostBack="true"
                        ID="cboCountry" class="chzn-select" Style="width: 350px;" 
                        onselectedindexchanged="cboCountry_SelectedIndexChanged">
						<asp:ListItem Text="" Value=""></asp:ListItem>
						<asp:ListItem Text="Ahemdabad" Value="Ahendabad"></asp:ListItem>
						<asp:ListItem Text="Bangalore" Value="Bangalore"></asp:ListItem>
						<asp:ListItem Text="Chennai" Value="Chennai"></asp:ListItem>
						<asp:ListItem Text="Aagra" Value="Aagra"></asp:ListItem>
						<asp:ListItem Text="Mumbai" Value="Mumbai"></asp:ListItem>
						<asp:ListItem Text="Hydrabad" Value="Hydrabad"></asp:ListItem>
						<asp:ListItem Text="Calcutta" Value="Calcutta"></asp:ListItem>
						<asp:ListItem Text="Patna" Value="Patna"></asp:ListItem>
						<asp:ListItem Text="Delhi" Value="Delhi"></asp:ListItem>
						<asp:ListItem Text="Noida" Value="Noida"></asp:ListItem>
						<asp:ListItem Text="Mangalore" Value="Mangalore"></asp:ListItem>
						<asp:ListItem Text="Goa" Value="Goa"></asp:ListItem>
						

					</asp:DropDownList><asp:Button runat="server" ID="btnSelect" Text="Get Selected" OnClick="btnSelect_Click" />
            </td>
            <td>
             <asp:DropDownList data-placeholder="Choose a Category..." runat="server" ID="ddlItems" class="chzn-select" Style="width: 350px;"></asp:DropDownList>
            </td>
            </tr>
            </table>
				<div>

					

				</div>
               
			</div>

		</div>
   
	
   
    	<div id="Div1">
			 <div  class="side-by-side clearfix">
               
                </div>
			<div class="side-by-side clearfix">

				
               
			</div>

		</div>
   <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script src="Scripts/jquery.min.js" type="text/javascript"></script>
		<script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script type="text/javascript">		    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
	</ContentTemplate>
     <Triggers>
    <asp:PostBackTrigger ControlID="cboCountry" />
    </Triggers>
     <Triggers>
    <asp:PostBackTrigger ControlID="ddlItems" />
    </Triggers>
    </asp:UpdatePanel>
    
	
    </form>
</body>
</html>
