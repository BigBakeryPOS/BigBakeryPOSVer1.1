<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Branch.aspx.cs" Inherits="Billing.Accountsbootstrap.Login_Branch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>POS Billing - Login</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- ubi style -->
	<link href="../css/pos_style.css" rel="stylesheet">
	<!-- ubi style -->
	<link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
</head>

<body class="loginpage">
        <div align="center">
            <label>
                MAC ADDRESS:</label><asp:Label ID="macaddress" runat="server" ></asp:Label>
          </div>
          <div class="container">
          <form class="form-signin" id="Form1" runat="server">
       <div class="panel panel-custom1">
             <div class="panel-heading">
			<div class="row">
				<div class="col-xs-12 text-center margin-x-lg">
					<asp:Image ID="log" src='<%#Eval("Image")%>' class="avatar" runat="server" />
				</div> 
			</div>
            </div>

            <div class="panel-body">
			  <div class="row">
				<div class="col-sm-12">
					<h3 class="text-center"><asp:LinkButton Text="LOGIN" ID="LinkButton1" OnClick="btnSeeting_OnClick" runat="server"></asp:LinkButton> </h3>
					<label for="inputEmail">User name</label>
                    <asp:TextBox ID="username" runat="server" AutoComplete="Off" class="form-control input-md"></asp:TextBox>
					<label for="inputPassword">Password</label>
                    <asp:TextBox ID="password" runat="server" AutoComplete="Off" TextMode="Password" class="form-control input-md" ></asp:TextBox>
					<label for="inputEmpcode">Emp Code</label>
					<asp:TextBox ID="txtemp" runat="server" AutoComplete="Off"  TextMode="Password" class="form-control input-md"></asp:TextBox>
					<%--<button class="btn btn-lg btn-primary pos-btn1 btn-block margin-x-md" type="submit">LOGIN</button>--%>
                    <asp:TextBox ID="txtEmail" runat="server"  AutoComplete="Off"  Visible="false" AutoPostBack="true" OnTextChanged="UserName_OnTextChanged"></asp:TextBox>
                    <asp:Button class="btn btn-lg btn-primary pos-btn1 btn-block margin-x-md" OnClick="LoginButton_Click" ID="btn" Text="LOGIN"  runat="server" />

                    <div class="user-bottom fix">
                        <br />
                        <asp:Button ID="btnOTP" Visible="false" runat="server" Text="Send OTP" CssClass="common-btn rjc"
                            Style="background: #90133b none repeat scroll 0 0; border: 1px solid transparent;
                            border-radius: 4px; color: #fff; display: inline-block; font-size: 14px; font-weight: 700;
                            line-height: 35px; padding: 0 20px; text-transform: uppercase; white-space: nowrap;
                            transition: .3s;" OnClick="btnOTPClick" />
                        <div class="col-lg-24 col-md-4 col-sm-4 col-xs-12" id="IDOtpEnter" runat="server">
                            <div class="user-info-single">
                                <label style="font-size: 12px; color: wheat;">
                                    Enter OTP <span class="required">*</span></label>
                                <asp:TextBox ID="txtOTP" Style="width: 55px; height: 23px;" Visible="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnComplete" runat="server" Visible="false" Text="Verify OTP" CssClass="common-btn rjc"
                            Style="background: #90133b none repeat scroll 0 0; border: 1px solid transparent;
                            border-radius: 4px; color: #fff; display: inline-block; font-size: 14px; font-weight: 700;
                            line-height: 35px; padding: 0 20px; text-transform: uppercase; white-space: nowrap;
                            transition: .3s;" OnClick="btnComplete_OnClick" />
                    </div>
				</div>
				 
			  </div>
            </div>
            </div>
			<div class="row clearfix">
			<div class="col-sm-6 margin-x-md">
				<div class="postel">
				<span class="glyphicon glyphicon-headphones pos-color pos-list-icons" aria-hidden="true"></span>
				<b class="pos-color uppercase">Support</b><br>
				<b>+91 91235 15998</b>
				</div>
			</div>
			<div class="col-sm-6 margin-x-md">
				<div class="posemail">
				<span class="glyphicon glyphicon-envelope pos-color pos-list-icons" aria-hidden="true"></span>
				<b class="pos-color uppercase">Email</b><br>
				<b><a href="mailto:contactus@bigdbiz.in">contactus@bigdbiz.in</a></b>
				</div>
			</div>
		</div>
        </form>
        <div class="row">
				<div class="col-sm-12 text-center">
				<h3 class="uppercase">Our Other Products</h3>
					<img src="/images/other-products.png" title="Other Products" class="img-responsive" style="margin: auto;">
				</div>
		</div>
        </div>
</body>
</html>
